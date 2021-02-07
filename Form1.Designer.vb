<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileSelectRootDirectory = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuClearHighLights = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.RichTextBox2 = New System.Windows.Forms.RichTextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.RichTextBox3 = New System.Windows.Forms.RichTextBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.RichTextBox4 = New System.Windows.Forms.RichTextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ContextMenuUndo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuRedo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ContextMenuCut = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuPaste = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuClearHighLights})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip1.Size = New System.Drawing.Size(1600, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFileSelectRootDirectory})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.mnuFile.Size = New System.Drawing.Size(37, 20)
        Me.mnuFile.Text = "File"
        '
        'mnuFileSelectRootDirectory
        '
        Me.mnuFileSelectRootDirectory.Name = "mnuFileSelectRootDirectory"
        Me.mnuFileSelectRootDirectory.Size = New System.Drawing.Size(184, 22)
        Me.mnuFileSelectRootDirectory.Text = "Select Root Directory"
        '
        'mnuClearHighLights
        '
        Me.mnuClearHighLights.Name = "mnuClearHighLights"
        Me.mnuClearHighLights.Size = New System.Drawing.Size(104, 20)
        Me.mnuClearHighLights.Text = "Clear Highlights"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 24)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1600, 426)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.RichTextBox1)
        Me.TabPage1.Controls.Add(Me.TreeView1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1592, 398)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TreeView"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.RichTextBox1.Location = New System.Drawing.Point(539, 3)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(1050, 392)
        Me.RichTextBox1.TabIndex = 1
        Me.RichTextBox1.Text = ""
        '
        'TreeView1
        '
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Left
        Me.TreeView1.Location = New System.Drawing.Point(3, 3)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(530, 392)
        Me.TreeView1.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.RichTextBox2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1592, 398)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Header Template"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'RichTextBox2
        '
        Me.RichTextBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox2.Location = New System.Drawing.Point(3, 3)
        Me.RichTextBox2.Name = "RichTextBox2"
        Me.RichTextBox2.Size = New System.Drawing.Size(1586, 392)
        Me.RichTextBox2.TabIndex = 0
        Me.RichTextBox2.Text = ""
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.RichTextBox3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 24)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1592, 398)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Body Template"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'RichTextBox3
        '
        Me.RichTextBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox3.Location = New System.Drawing.Point(0, 0)
        Me.RichTextBox3.Name = "RichTextBox3"
        Me.RichTextBox3.Size = New System.Drawing.Size(1592, 398)
        Me.RichTextBox3.TabIndex = 0
        Me.RichTextBox3.Text = ""
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.RichTextBox4)
        Me.TabPage4.Location = New System.Drawing.Point(4, 24)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(1592, 398)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Footer Template"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'RichTextBox4
        '
        Me.RichTextBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox4.Location = New System.Drawing.Point(3, 3)
        Me.RichTextBox4.Name = "RichTextBox4"
        Me.RichTextBox4.Size = New System.Drawing.Size(1586, 392)
        Me.RichTextBox4.TabIndex = 0
        Me.RichTextBox4.Text = ""
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(36, 36)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContextMenuUndo, Me.ContextMenuRedo, Me.ContextMenuSeparator1, Me.ContextMenuCut, Me.ContextMenuCopy, Me.ContextMenuPaste, Me.ContextMenuSelectAll})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(165, 142)
        '
        'ContextMenuUndo
        '
        Me.ContextMenuUndo.Image = CType(resources.GetObject("ContextMenuUndo.Image"), System.Drawing.Image)
        Me.ContextMenuUndo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ContextMenuUndo.Name = "ContextMenuUndo"
        Me.ContextMenuUndo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.ContextMenuUndo.Size = New System.Drawing.Size(164, 22)
        Me.ContextMenuUndo.Text = "Undo"
        '
        'ContextMenuRedo
        '
        Me.ContextMenuRedo.Image = CType(resources.GetObject("ContextMenuRedo.Image"), System.Drawing.Image)
        Me.ContextMenuRedo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ContextMenuRedo.Name = "ContextMenuRedo"
        Me.ContextMenuRedo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
        Me.ContextMenuRedo.Size = New System.Drawing.Size(164, 22)
        Me.ContextMenuRedo.Text = "Redo"
        '
        'ContextMenuSeparator1
        '
        Me.ContextMenuSeparator1.Name = "ContextMenuSeparator1"
        Me.ContextMenuSeparator1.Size = New System.Drawing.Size(161, 6)
        '
        'ContextMenuCut
        '
        Me.ContextMenuCut.Image = CType(resources.GetObject("ContextMenuCut.Image"), System.Drawing.Image)
        Me.ContextMenuCut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ContextMenuCut.Name = "ContextMenuCut"
        Me.ContextMenuCut.ShortcutKeyDisplayString = "Ctrl+X"
        Me.ContextMenuCut.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.ContextMenuCut.Size = New System.Drawing.Size(164, 22)
        Me.ContextMenuCut.Text = "Cut"
        '
        'ContextMenuCopy
        '
        Me.ContextMenuCopy.Image = CType(resources.GetObject("ContextMenuCopy.Image"), System.Drawing.Image)
        Me.ContextMenuCopy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ContextMenuCopy.Name = "ContextMenuCopy"
        Me.ContextMenuCopy.ShortcutKeyDisplayString = "Ctrl+C"
        Me.ContextMenuCopy.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.ContextMenuCopy.Size = New System.Drawing.Size(164, 22)
        Me.ContextMenuCopy.Text = "Copy"
        '
        'ContextMenuPaste
        '
        Me.ContextMenuPaste.Image = CType(resources.GetObject("ContextMenuPaste.Image"), System.Drawing.Image)
        Me.ContextMenuPaste.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ContextMenuPaste.Name = "ContextMenuPaste"
        Me.ContextMenuPaste.ShortcutKeyDisplayString = "Ctrl+V"
        Me.ContextMenuPaste.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.ContextMenuPaste.Size = New System.Drawing.Size(164, 22)
        Me.ContextMenuPaste.Text = "Paste"
        '
        'ContextMenuSelectAll
        '
        Me.ContextMenuSelectAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ContextMenuSelectAll.Name = "ContextMenuSelectAll"
        Me.ContextMenuSelectAll.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.ContextMenuSelectAll.Size = New System.Drawing.Size(164, 22)
        Me.ContextMenuSelectAll.Text = "Select All"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1600, 450)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents RichTextBox2 As RichTextBox
    Friend WithEvents RichTextBox3 As RichTextBox
    Friend WithEvents RichTextBox4 As RichTextBox
    Friend WithEvents mnuFile As ToolStripMenuItem
    Friend WithEvents mnuFileSelectRootDirectory As ToolStripMenuItem
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents ContextMenuCopy As ToolStripMenuItem
    Friend WithEvents ContextMenuCut As ToolStripMenuItem
    Friend WithEvents ContextMenuPaste As ToolStripMenuItem
    Friend WithEvents ContextMenuRedo As ToolStripMenuItem
    Friend WithEvents ContextMenuSelectAll As ToolStripMenuItem
    Friend WithEvents ContextMenuSeparator1 As ToolStripSeparator
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ContextMenuUndo As ToolStripMenuItem
    Friend WithEvents mnuClearHighLights As ToolStripMenuItem
End Class
