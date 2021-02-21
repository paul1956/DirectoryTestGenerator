﻿' Licensed to the .NET Foundation under one or more agreements.
' The .NET Foundation licenses this file to you under the MIT license.
' See the LICENSE file in the project root for more information.

Imports System.ComponentModel
Imports System.IO

Public Class Form1

    Private ReadOnly _templatePart1 As XCData = <![CDATA[' Licensed to the .NET Foundation under one or more agreements.
' The .NET Foundation licenses this file to you under the MIT license.
' See the LICENSE file in the project root for more information.

Imports System.IO
Imports System.Reflection
Imports System.Threading
Imports CSharpToVBApp
Imports CSharpToVBConverter
Imports CSharpToVBConverter.ConversionResult

Imports Microsoft.CodeAnalysis
Imports Microsoft.CodeAnalysis.Emit

Imports Xunit

Namespace ConvertDirectory.Tests

    ''' <summary>
    ''' Return False to skip test
    ''' </summary>
    <TestClass()> Public Class TestCompile
        Private _lastFileProcessed As String

        Public Shared ReadOnly Property EnableRoslynTests() As Boolean
            Get
                Return Directory.Exists(GetRoslynRootDirectory) AndAlso Environment.GetEnvironmentVariable("EnableRoslynTests") = "True"
            End Get
        End Property

        Private Async Function TestProcessDirectoryAsync(SourceDirectory As String) As Task(Of Boolean)
            Return Await ProcessDirectoryAsync(MainForm:=Nothing, SourceDirectory, TargetDirectory:="", StopButton:=Nothing, ListBoxFileList:=Nothing, SourceLanguageExtension:="cs", New ProcessingStats(""), AddressOf Me.TestProcessFileAsync, CancellationToken.None).ConfigureAwait(continueOnCapturedContext:=True)
        End Function

        Friend Function TestProcessFileAsync(MainForm As Form1, PathWithFileName As String, TargetDirectory As String, _0 As String, CSPreprocessorSymbols As List(Of String), VBPreprocessorSymbols As List(Of KeyValuePair(Of String, Object)), OptionalReferences() As MetadataReference, SkipAutoGenerated As Boolean, CancelToken As CancellationToken) As Task(Of Boolean)
            ' Save to TargetDirectory not supported
            Assert.True(String.IsNullOrWhiteSpace(TargetDirectory))
            ' Do not delete the next line or the parameter it is needed by other versions of this routine
            _lastFileProcessed = PathWithFileName
            Using fs As FileStream = File.OpenRead(PathWithFileName)
                Dim requestToConvert As ConvertRequest = New ConvertRequest(mSkipAutoGenerated:=True, mProgress:=Nothing, mCancelToken:=CancelToken) With {
                    .SourceCode = fs.GetFileTextFromStream()
                }

                Dim resultOfConversion As ConversionResult = ConvertInputRequest(requestToConvert, New DefaultVBOptions, CSPreprocessorSymbols, VBPreprocessorSymbols, CSharpReferences(Assembly.Load("System.Windows.Forms").Location, OptionalReferences).ToArray, ReportException:=Nothing, mProgress:=Nothing, CancelToken:=CancellationToken.None)
                If resultOfConversion.ResultStatus = ResultTriState.Failure Then
                    Return Task.FromResult(False)
                End If
                Dim compileResult As (CompileSuccess As Boolean, EmitResult As EmitResult) = CompileVisualBasicString(StringToBeCompiled:=resultOfConversion.ConvertedCode, VBPreprocessorSymbols, DiagnosticSeverity.Error, resultOfConversion)
                If Not compileResult.CompileSuccess OrElse resultOfConversion.GetFilteredListOfFailures().Any Then
                    Dim msg As String = If(compileResult.CompileSuccess, resultOfConversion.GetFilteredListOfFailures()(0).GetMessage, "Fatal Compile error")
                    Throw New ApplicationException($"{PathWithFileName} failed to compile with error :{vbCrLf}{msg}")
                    Return Task.FromResult(False)
                End If
            End Using
            Return Task.FromResult(True)
        End Function
        ]]>
    Private ReadOnly _templatePart1Body As XCData = <![CDATA[
        <Trait("Category", "SkipWhenLiveUnitTesting")>
        <SkippableFact>
        Public Async Function %0ConvertAsync() As Task
            Skip.IfNot(EnableRoslynTests)
            Assert.True(Await Me.TestProcessDirectoryAsync(Path.Combine(GetRoslynRootDirectory(), "src", "%1")).ConfigureAwait(True), $"Failing file {_lastFileProcessed}")
        End Function
]]>

    Private ReadOnly _templatePart2 As XCData = <![CDATA[
    End Class
End Namespace
]]>

    Private _currentBuffer As Control
    Private _srcPath As String
    Private _roslynPath As String

    Private Property CurrentBuffer As Control
        Get
            Return _currentBuffer
        End Get
        Set(value As Control)
            _currentBuffer = value
            If value IsNot Nothing Then
                _currentBuffer.Focus()
            End If
        End Set
    End Property

    Private Shared Function XCDataToString(Optional data As XCData = Nothing) As String
        Return data?.Value.Replace(vbLf, Environment.NewLine)
    End Function

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

        If TypeOf Me.CurrentBuffer Is RichTextBox Then
            Dim sourceBuffer As RichTextBox = CType(Me.CurrentBuffer, RichTextBox)
            ContextMenu.Items(ContextMenu.IndexOf(NameOf(ContextMenuCopy))).Enabled = sourceBuffer.TextLength > 0 And sourceBuffer.SelectedText.Any
            ContextMenu.Items(ContextMenu.IndexOf(NameOf(ContextMenuCut))).Enabled = sourceBuffer.TextLength > 0 And sourceBuffer.SelectedText.Any
            ContextMenu.Items(ContextMenu.IndexOf(NameOf(ContextMenuPaste))).Enabled = sourceBuffer.CanPaste(DataFormats.GetFormat(DataFormats.Rtf)) OrElse sourceBuffer.CanPaste(DataFormats.GetFormat(DataFormats.Text))
            ContextMenu.Items(ContextMenu.IndexOf(NameOf(ContextMenuRedo))).Enabled = sourceBuffer.CanRedo
            ContextMenu.Items(ContextMenu.IndexOf(NameOf(ContextMenuUndo))).Enabled = sourceBuffer.CanUndo
        Else
            ContextMenu.Items(ContextMenu.IndexOf(NameOf(ContextMenuCut))).Enabled = False
            ContextMenu.Items(ContextMenu.IndexOf(NameOf(ContextMenuPaste))).Enabled = False
            ContextMenu.Items(ContextMenu.IndexOf(NameOf(ContextMenuRedo))).Enabled = False
            ContextMenu.Items(ContextMenu.IndexOf(NameOf(ContextMenuUndo))).Enabled = False
        End If
    End Sub

    Private Sub ContextMenuUndo_Click(sender As Object, e As EventArgs) Handles ContextMenuUndo.Click
        Dim sourceControl As RichTextBox = CType(Me.ContextMenuStrip1.SourceControl, RichTextBox)
        If sourceControl IsNot Nothing AndAlso sourceControl.CanUndo Then
            sourceControl.Undo()
        End If
    End Sub

    ' Call the procedure using the top nodes of the TreeView.
    Private Sub CreateBody(aTreeView As TreeView, RTB As RichTextBox)
        Dim nameParts As New SortedDictionary(Of String, String)
        For Each n As TreeNode In aTreeView.Nodes(0).Nodes
            Me.CreateBodyRecursive(n, RTB, nameParts)
        Next

        For Each kvp As KeyValuePair(Of String, String) In nameParts
            RTB.AppendText(XCDataToString(_templatePart1Body).Replace("%0", kvp.Key).Replace("%1", kvp.Value))
        Next
    End Sub

    Private Sub CreateBodyRecursive(n As TreeNode, RTB As RichTextBox, ByRef NameParts As SortedDictionary(Of String, String))
        If Directory.GetFiles(n.FullPath, "*.cs").Any Then
            Dim namePart As String = Me.GetNamePart(n)
            Dim pathPart As String = String.Join(""", """, Me.GetNameParts(n))
            NameParts.Add(namePart, pathPart)

        End If
        For Each aNode As TreeNode In n.Nodes
            Me.CreateBodyRecursive(aNode, RTB, NameParts)
        Next
    End Sub

    Private Function GetNamePart(n As TreeNode) As String
        Return String.Join("", Me.GetNameParts(n)).Replace(".", "")
    End Function

    Private Function GetNameParts(n As TreeNode) As String()
        Dim relativePath As String = n.FullPath.Replace(_srcPath, "")
        Return relativePath.Split("\", StringSplitOptions.RemoveEmptyEntries)
    End Function

    Private Sub mnuFileSelectRootDirectory_Click(sender As Object, e As EventArgs) Handles mnuFileSelectRootDirectory.Click
        Dim SourceFolderName As String
        Using OFD As New FolderBrowserDialog
            With OFD
                .Description = "Select root folder..."
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
                _srcPath = .SelectedPath
                _roslynPath = Directory.GetParent(.SelectedPath).FullName
            End With
        End Using
        Me.TreeView1.ExpandAll()
        Me.RichTextBox1.Text = XCDataToString(_templatePart1)
        Me.CreateBody(Me.TreeView1, Me.RichTextBox1)
        Me.RichTextBox1.AppendText(XCDataToString(_templatePart2))
        Me.RichTextBox1.Select(0, 0)
        Me.RichTextBox1.ScrollToCaret()
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Dim RTB As RichTextBox = CType(Me.TabControl1.SelectedTab.Controls(0), RichTextBox)
        Select Case Me.TabControl1.SelectedTab.Text
            Case "TreeView"
            Case "Header Template"
                RTB.Text = XCDataToString(_templatePart1)
            Case "Body Template"
                Me.CreateBody(Me.TreeView1, RTB)
            Case "Footer Template"
                RTB.AppendText(XCDataToString(_templatePart2))
            Case Else
                Stop
        End Select
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
    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        ' Determine by checking the Node property of the TreeViewEventArgs.
        Dim csFileList As String() = Directory.GetFiles(e.Node.FullPath, "*.cs")
        ' Determine by checking the Node property of the TreeViewEventArgs.
        '  e.Node
        Dim name As String = Me.GetNamePart(Me.TreeView1.SelectedNode)
        If Me.TreeView1.SelectedNode.Level = 0 OrElse Me.TreeView1.SelectedNode.Nodes.Count > 0 Then
            Exit Sub
        End If
        Dim start As Integer = Me.RichTextBox1.Find(name)
        If start < 0 Then
            Stop
        End If
        Me.RichTextBox1.Select(start, name.Length)
        Me.RichTextBox1.SelectionBackColor = Color.Orange
        Me.RichTextBox1.ScrollToCaret()
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

    Private Sub mnuClearHighLights_Click(sender As Object, e As EventArgs) Handles mnuClearHighLights.Click
        Me.RichTextBox1.SelectAll()
        Me.RichTextBox1.SelectionBackColor = Color.White
        Me.RichTextBox1.ScrollToCaret()
    End Sub
End Class
