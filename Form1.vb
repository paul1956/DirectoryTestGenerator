' Licensed to the .NET Foundation under one or more agreements.
' The .NET Foundation licenses this file to you under the MIT license.
' See the LICENSE file in the project root for more information.

Imports System.ComponentModel
Imports System.IO
Imports System.Text

Public Class Form1

    Private ReadOnly _skipableDictionary As New SortedDictionary(Of String, (isSkipable As Boolean, Reason As String))

    Private ReadOnly _templateFactBody As XCData = <![CDATA[
            <Trait("Category", "SkipWhenLiveUnitTesting")>
            <Fact>
            Public Async Function %0ConvertAsync() As Task
                Assert.True(Await TestProcessDirectoryAsync(Path.Combine(GetRoslynRootDirectory(), "src", "%1")).ConfigureAwait(True), $"Failing file {_lastFileProcessed}")
            End Function
]]>

    Private ReadOnly _templatePart1 As XCData = <![CDATA[' Licensed to the .NET Foundation under one or more agreements.
' The .NET Foundation licenses this file to you under the MIT license.
' See the LICENSE file in the project root for more information.

Imports System.IO

Imports Xunit

Namespace ConvertDirectory.Tests

]]>

    Private ReadOnly _templatePart2 As XCData = <![CDATA[
End Namespace
]]>

    Private ReadOnly _templateSkipableBody As XCData = <![CDATA[
            <Trait("Category", "SkipWhenLiveUnitTesting")>
            <SkippableFact>
            Public Async Function %0ConvertAsync() As Task
                Skip.IfNot(EnableRoslynTests, "%Reason")
                Assert.True(Await TestProcessDirectoryAsync(Path.Combine(GetRoslynRootDirectory(), "src", "%1")).ConfigureAwait(True), $"Failing file {_lastFileProcessed}")
            End Function
]]>

    Private ReadOnly _testRTBs As New List(Of RichTextBox)
    Private _roslynRootDirectory As String

    Private Shared Function XCDataToString(Optional data As XCData = Nothing) As String
        Return data?.Value.Replace(vbLf, Environment.NewLine)
    End Function

    Private Sub AppendBodyIntoRTB(RTB As RichTextBox, ClassName As String, Body As StringBuilder)
        RTB.Text = XCDataToString(_templatePart1)
        RTB.AppendText($"         <TestClass()>{vbCrLf}         Public Class {ClassName}")
        RTB.AppendText(Body.ToString)
        RTB.AppendText($"{vbCrLf}        End Class{vbCrLf}")
        RTB.AppendText(XCDataToString(_templatePart2))
        RTB.Select(0, 0)
        RTB.ScrollToCaret()
    End Sub

    Private Sub ContextMenuCopy_Click(sender As Object, e As EventArgs) Handles ContextMenuCopy.Click
        If TypeOf Me.ContextMenuStrip1.SourceControl Is RichTextBox Then
            CType(Me.ContextMenuStrip1.SourceControl, RichTextBox).Copy()
        Else
            If Me.ContextMenuStrip1.SourceControl IsNot Nothing Then
                Clipboard.SetText(CType(Me.ContextMenuStrip1.SourceControl, ListBox).SelectedItem.ToString)
            End If
        End If
    End Sub

    Private Sub ContextMenuCut_Click(sender As Object, e As EventArgs) Handles ContextMenuCut.Click
        If TypeOf Me.ContextMenuStrip1.SourceControl Is RichTextBox Then
            CType(Me.ContextMenuStrip1.SourceControl, RichTextBox).Cut()
        End If
    End Sub

    Private Sub ContextMenuPaste_Click(sender As Object, e As EventArgs) Handles ContextMenuPaste.Click
        Dim sourceControl As RichTextBox = CType(Me.ContextMenuStrip1.SourceControl, RichTextBox)
        If sourceControl Is Nothing Then
            Exit Sub
        End If
        If sourceControl.CanPaste(DataFormats.GetFormat(DataFormats.Rtf)) OrElse
            sourceControl.CanPaste(DataFormats.GetFormat(DataFormats.Text)) Then
            sourceControl.Paste()
        End If
    End Sub

    Private Sub ContextMenuRedo_Click(sender As Object, e As EventArgs) Handles ContextMenuRedo.Click
        Dim sourceControl As RichTextBox = CType(Me.ContextMenuStrip1.SourceControl, RichTextBox)
        If sourceControl IsNot Nothing AndAlso sourceControl.CanRedo Then
            sourceControl.Redo()
        End If
    End Sub

    Private Sub ContextMenuSelectAll_Click(sender As Object, e As EventArgs) Handles ContextMenuSelectAll.Click
        Dim sourceControl As RichTextBox = CType(Me.ContextMenuStrip1.SourceControl, RichTextBox)
        If sourceControl IsNot Nothing Then
            sourceControl.SelectAll()
        End If
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As CancelEventArgs) Handles ContextMenuStrip1.Opening
        Dim ContextMenu As ContextMenuStrip = CType(sender, ContextMenuStrip)
        Dim sourceBuffer As RichTextBox = CType(Me.ContextMenuStrip1.SourceControl, RichTextBox)

        ContextMenu.Items(ContextMenu.IndexOf(NameOf(ContextMenuCopy))).Enabled = sourceBuffer.TextLength > 0 And sourceBuffer.SelectedText.Any
        ContextMenu.Items(ContextMenu.IndexOf(NameOf(ContextMenuCut))).Enabled = sourceBuffer.TextLength > 0 And sourceBuffer.SelectedText.Any
        ContextMenu.Items(ContextMenu.IndexOf(NameOf(ContextMenuPaste))).Enabled = sourceBuffer.CanPaste(DataFormats.GetFormat(DataFormats.Rtf)) OrElse sourceBuffer.CanPaste(DataFormats.GetFormat(DataFormats.Text))
        ContextMenu.Items(ContextMenu.IndexOf(NameOf(ContextMenuRedo))).Enabled = sourceBuffer.CanRedo
        ContextMenu.Items(ContextMenu.IndexOf(NameOf(ContextMenuUndo))).Enabled = sourceBuffer.CanUndo
    End Sub

    Private Sub ContextMenuUndo_Click(sender As Object, e As EventArgs) Handles ContextMenuUndo.Click
        Dim sourceControl As RichTextBox = CType(Me.ContextMenuStrip1.SourceControl, RichTextBox)
        If sourceControl IsNot Nothing AndAlso sourceControl.CanUndo Then
            sourceControl.Undo()
        End If
    End Sub

    ' Call the procedure using the top nodes of the TreeView.
    Private Sub CreateBody(aTreeView As TreeView)
        Dim nameParts As New SortedDictionary(Of String, String)
        For Each n As TreeNode In aTreeView.Nodes(0).Nodes
            Me.CreateBodyRecursive(n, nameParts)
        Next

        Dim factBody As New StringBuilder
        factBody.AppendLine()
        Dim skipableBodySlower As New StringBuilder
        skipableBodySlower.AppendLine()
        Dim skipableBodySlowest As New StringBuilder
        skipableBodySlowest.AppendLine()
        Dim skipableBodyOver1Minute As New StringBuilder
        skipableBodyOver1Minute.AppendLine()
        Dim skipableBodyUnknown As New StringBuilder

        For Each kvp As KeyValuePair(Of String, String) In nameParts
            Dim factData As (IsSkipFact As Boolean, Reason As String) = (False, "")
            Dim key As String = $"{kvp.Key}ConvertAsync"
            _skipableDictionary.TryGetValue(key, factData)
            If factData.IsSkipFact AndAlso factData.Reason <> "Unknown" Then
                Select Case factData.Reason
                    Case "Slower Test"
                        skipableBodySlower.Append(XCDataToString(_templateSkipableBody).Replace("%0", kvp.Key) _
                                                                               .Replace("%1", kvp.Value) _
                                                                               .Replace("%Reason", factData.Reason))
                    Case "Slowest Test"
                        skipableBodySlowest.Append(XCDataToString(_templateSkipableBody).Replace("%0", kvp.Key) _
                                                                               .Replace("%1", kvp.Value) _
                                                                               .Replace("%Reason", factData.Reason))
                    Case "Over 1 Minute Test"
                        skipableBodyOver1Minute.Append(XCDataToString(_templateSkipableBody).Replace("%0", kvp.Key) _
                                                                               .Replace("%1", kvp.Value) _
                                                                               .Replace("%Reason", factData.Reason))
                    Case Else
                        skipableBodyUnknown.Append(XCDataToString(_templateSkipableBody).Replace("%0", kvp.Key) _
                                                                               .Replace("%1", kvp.Value) _
                                                                               .Replace("%Reason", "Unknown"))

                End Select
            Else
                factBody.Append(XCDataToString(_templateFactBody).Replace("%0", kvp.Key) _
                                                                 .Replace("%1", kvp.Value))
            End If
        Next
        Me.AppendBodyIntoRTB(Me.RichTextBoxFast, "FastTests", factBody)
        If skipableBodyUnknown.Length > 0 Then
            Me.AppendBodyIntoRTB(Me.RichTextBoxUnknown, "UnknownSpeedTests", skipableBodyUnknown)
        End If
        Me.AppendBodyIntoRTB(Me.RichTextBoxSlower, "SlowerSpeedTests", skipableBodySlower)
        Me.AppendBodyIntoRTB(Me.RichTextBoxSlowest, "SlowestSpeedTests", skipableBodySlowest)
        Me.AppendBodyIntoRTB(Me.RichTextBoxOver1Minute, "Over1MinuteSpeedTests", skipableBodyOver1Minute)
    End Sub

    Private Sub CreateBodyRecursive(n As TreeNode, ByRef NameParts As SortedDictionary(Of String, String))
        If Directory.GetFiles(n.FullPath, "*.cs").Any Then
            Dim namePart As String = Me.GetNamePart(n)
            Dim pathPart As String = String.Join(""", """, Me.GetNameParts(n))
            NameParts.Add(namePart, pathPart)

        End If
        For Each aNode As TreeNode In n.Nodes
            Me.CreateBodyRecursive(aNode, NameParts)
        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        _testRTBs.AddRange({Me.RichTextBoxFast,
                            Me.RichTextBoxSlower,
                            Me.RichTextBoxSlowest,
                            Me.RichTextBoxOver1Minute,
                            Me.RichTextBoxUnknown})
    End Sub

    Private Function GetNamePart(n As TreeNode) As String
        Return String.Join("", Me.GetNameParts(n)).Replace(".", "")
    End Function

    Private Function GetNameParts(n As TreeNode) As String()
        Dim relativePath As String = n.FullPath.Replace(_roslynRootDirectory, "")
        Return relativePath.Split("\", StringSplitOptions.RemoveEmptyEntries)
    End Function

    Private Sub GetTestSubs(TestFilePath As String)
        _skipableDictionary.Clear()

        For Each testFile As String In Directory.EnumerateFiles(TestFilePath)
            Using reader As StreamReader = File.OpenText(testFile)
                Dim line As String = Nothing
                Dim isSkippableFact As Boolean
                Dim functionName As String
                While reader.Peek() <> -1
                    line = reader.ReadLine().Trim
                    isSkippableFact = line.StartsWith("<SkippableFact>")

                    Dim reason As String = ""
                    If isSkippableFact OrElse line.StartsWith("<Fact>") Then
                        ' Get Function Line
                        line = reader.ReadLine().Trim
                        line = line.Replace("Public Async Function", "").Trim
                        functionName = line.Replace("() As Task", "").Trim
                        If isSkippableFact Then
                            line = reader.ReadLine().Trim
                            reason = line.Replace("Skip.IfNot(EnableRoslynTests", "").Replace(", ", "").Replace(")", "").Replace("""", "")
                            reader.ReadLine() ' Skip Assert.True line
                            reader.ReadLine() ' Skip End lien
                        End If
                        If functionName.Contains(" ") Then
                            Stop
                        End If
                        _skipableDictionary.Add(functionName, (isSkippableFact, reason))
                    End If
                End While
            End Using
        Next
    End Sub

    Private Sub mnuFileSelectRootDirectory_Click(sender As Object, e As EventArgs) Handles mnuFileSelectRootDirectory.Click
        Dim SourceFolderName As String
        Using OFD As New FolderBrowserDialog
            With OFD
                .Description = "Select Code Converter root folder..."
                .ShowNewFolderButton = False
                If .ShowDialog(Me) <> DialogResult.OK Then
                    Exit Sub
                End If
                SourceFolderName = .SelectedPath
                If Not Directory.Exists(SourceFolderName) Then
                    MsgBox($"{SourceFolderName} is not a directory.",
                       MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation Or MsgBoxStyle.MsgBoxSetForeground,
                       Title:="Generate Test Folder List")
                    Exit Sub
                End If
                Dim DriveName As String = New DriveInfo(.SelectedPath).RootDirectory.Name
                Me.TreeView1.Nodes.Clear()
                Me.TreeView1.Nodes.Add(.SelectedPath)
                PopulateTreeView(.SelectedPath, Me.TreeView1.Nodes(0))
                _roslynRootDirectory = .SelectedPath
            End With
        End Using

        Me.GetTestSubs(Path.Combine(Directory.GetParent(_roslynRootDirectory).Parent.FullName, "CSharpToVB\CSharpToVB.Tests\Test\ConvertFolders\"))

        Me.TreeView1.ExpandAll()
        Me.CreateBody(Me.TreeView1)
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Dim RTB As RichTextBox = CType(Me.TabControl1.SelectedTab.Controls(0), RichTextBox)
        Select Case Me.TabControl1.SelectedTab.Text
            Case "TreeView"
            Case "Header Template"
                RTB.Text = XCDataToString(_templatePart1)
            Case "Footer Template"
                RTB.AppendText(XCDataToString(_templatePart2))
            Case Else
                Stop
        End Select
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        ' Determine by checking the Node property of the TreeViewEventArgs.
        Dim csFileList As String() = Directory.GetFiles(e.Node.FullPath, "*.cs")
        ' Determine by checking the Node property of the TreeViewEventArgs.
        '  e.Node
        Dim name As String = Me.GetNamePart(Me.TreeView1.SelectedNode)
        If Me.TreeView1.SelectedNode.Level = 0 OrElse Me.TreeView1.SelectedNode.Nodes.Count > 0 Then
            Exit Sub
        End If
        For Each rtb As RichTextBox In _testRTBs
            Dim tabName As String = $"{rtb.Name.Replace("RichTextBox", "")}TabPage"
            Dim start As Integer = rtb.Find(name)
            If start >= 0 Then
                Me.TabControl2.SelectedTab = Me.TabControl2.TabPages.Item(tabName)
                rtb.Select(start, name.Length)
                rtb.SelectionBackColor = Color.Orange
                rtb.ScrollToCaret()
                Exit Sub
            End If
        Next
        Stop
    End Sub

    Private Sub TreeView1_BeforeExpand(sender As Object, e As TreeViewCancelEventArgs) Handles TreeView1.BeforeExpand
        Dim MyExistNode As TreeNode = e.Node
        'Clear TreeNode
        MyExistNode.Nodes.Clear()

        Try
            'Loop For Get Folders
            Dim mypath As String = MyExistNode.FullPath

            'Loop For Get Folders
            Dim csFileList As String() = Directory.GetFiles(mypath, "*.cs")
            If csFileList.Length > 0 Then
                Exit Sub
            End If
            For Each myFolders As String In Directory.GetDirectories(mypath)
                csFileList = Directory.GetFiles(myFolders, "*.cs", SearchOption.AllDirectories)
                If csFileList.Length = 0 Then
                    Continue For
                End If
                Dim FldrNode As TreeNode = MyExistNode.Nodes.Add(Path.GetFileName(myFolders))
                'Here, Expand is use for add Expanding option "[+]" on folder
                FldrNode.Nodes.Add("Expand")
            Next
        Catch ex As Exception

        End Try

    End Sub

    Public Shared Sub PopulateTreeView(directoryValue As String, parentNode As TreeNode)
        Try
            'Loop For Get Folders
            For Each myFolders As String In Directory.GetDirectories(directoryValue)
                Dim FldrNode As TreeNode = parentNode.Nodes.Add(Path.GetFileName(myFolders))
                'Here, Expand is use for add Expanding option "[+]" on folder
                FldrNode.Nodes.Add("Expand")
            Next

            'Loop For Get Files
            For Each MyFiles As String In Directory.GetFiles(directoryValue)
                Dim FLNode As TreeNode = parentNode.Nodes.Add(Path.GetFileName(MyFiles))
            Next
        Catch unauthorized As UnauthorizedAccessException
            parentNode.Nodes.Add("Access Denied")
        End Try
    End Sub

End Class
