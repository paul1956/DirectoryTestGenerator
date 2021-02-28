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
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.FastTabPage = New System.Windows.Forms.TabPage()
        Me.RichTextBoxFast = New System.Windows.Forms.RichTextBox()
        Me.SlowerTabPage = New System.Windows.Forms.TabPage()
        Me.RichTextBoxSlower = New System.Windows.Forms.RichTextBox()
        Me.SlowestTabPage = New System.Windows.Forms.TabPage()
        Me.RichTextBoxSlowest = New System.Windows.Forms.RichTextBox()
        Me.UnknownTabPage = New System.Windows.Forms.TabPage()
        Me.RichTextBoxUnknown = New System.Windows.Forms.RichTextBox()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.RichTextBox2 = New System.Windows.Forms.RichTextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
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
        Me.TabControl2.SuspendLayout()
        Me.FastTabPage.SuspendLayout()
        Me.SlowerTabPage.SuspendLayout()
        Me.SlowestTabPage.SuspendLayout()
        Me.UnknownTabPage.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
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
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 24)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1600, 426)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TabControl2)
        Me.TabPage1.Controls.Add(Me.TreeView1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1592, 398)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TreeView"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.FastTabPage)
        Me.TabControl2.Controls.Add(Me.SlowerTabPage)
        Me.TabControl2.Controls.Add(Me.SlowestTabPage)
        Me.TabControl2.Controls.Add(Me.UnknownTabPage)
        Me.TabControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl2.Location = New System.Drawing.Point(533, 3)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(1056, 392)
        Me.TabControl2.TabIndex = 1
        '
        'FastTabPage
        '
        Me.FastTabPage.Controls.Add(Me.RichTextBoxFast)
        Me.FastTabPage.Location = New System.Drawing.Point(4, 24)
        Me.FastTabPage.Name = "FastTabPage"
        Me.FastTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.FastTabPage.Size = New System.Drawing.Size(1048, 364)
        Me.FastTabPage.TabIndex = 0
        Me.FastTabPage.Text = "Fast Tests"
        Me.FastTabPage.UseVisualStyleBackColor = True
        '
        'RichTextBoxFast
        '
        Me.RichTextBoxFast.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBoxFast.Location = New System.Drawing.Point(3, 3)
        Me.RichTextBoxFast.Name = "RichTextBoxFast"
        Me.RichTextBoxFast.Size = New System.Drawing.Size(1042, 358)
        Me.RichTextBoxFast.TabIndex = 0
        Me.RichTextBoxFast.Text = ""
        '
        'SlowerTabPage
        '
        Me.SlowerTabPage.Controls.Add(Me.RichTextBoxSlower)
        Me.SlowerTabPage.Location = New System.Drawing.Point(4, 24)
        Me.SlowerTabPage.Name = "SlowerTabPage"
        Me.SlowerTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.SlowerTabPage.Size = New System.Drawing.Size(1048, 364)
        Me.SlowerTabPage.TabIndex = 1
        Me.SlowerTabPage.Text = "Slower Tests"
        Me.SlowerTabPage.UseVisualStyleBackColor = True
        '
        'RichTextBoxSlower
        '
        Me.RichTextBoxSlower.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBoxSlower.Location = New System.Drawing.Point(3, 3)
        Me.RichTextBoxSlower.Name = "RichTextBoxSlower"
        Me.RichTextBoxSlower.Size = New System.Drawing.Size(1042, 358)
        Me.RichTextBoxSlower.TabIndex = 0
        Me.RichTextBoxSlower.Text = ""
        '
        'SlowestTabPage
        '
        Me.SlowestTabPage.Controls.Add(Me.RichTextBoxSlowest)
        Me.SlowestTabPage.Location = New System.Drawing.Point(4, 24)
        Me.SlowestTabPage.Name = "SlowestTabPage"
        Me.SlowestTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.SlowestTabPage.Size = New System.Drawing.Size(1048, 364)
        Me.SlowestTabPage.TabIndex = 2
        Me.SlowestTabPage.Text = "Slowest Test"
        Me.SlowestTabPage.UseVisualStyleBackColor = True
        '
        'RichTextBoxSlowest
        '
        Me.RichTextBoxSlowest.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBoxSlowest.Location = New System.Drawing.Point(3, 3)
        Me.RichTextBoxSlowest.Name = "RichTextBoxSlowest"
        Me.RichTextBoxSlowest.Size = New System.Drawing.Size(1042, 358)
        Me.RichTextBoxSlowest.TabIndex = 1
        Me.RichTextBoxSlowest.Text = ""
        '
        'UnknownTabPage
        '
        Me.UnknownTabPage.Controls.Add(Me.RichTextBoxUnknown)
        Me.UnknownTabPage.Location = New System.Drawing.Point(4, 24)
        Me.UnknownTabPage.Name = "UnknownTabPage"
        Me.UnknownTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.UnknownTabPage.Size = New System.Drawing.Size(1048, 364)
        Me.UnknownTabPage.TabIndex = 3
        Me.UnknownTabPage.Text = "Unknown Speed Tests"
        Me.UnknownTabPage.UseVisualStyleBackColor = True
        '
        'RichTextBoxUnknown
        '
        Me.RichTextBoxUnknown.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBoxUnknown.Location = New System.Drawing.Point(3, 3)
        Me.RichTextBoxUnknown.Name = "RichTextBoxUnknown"
        Me.RichTextBoxUnknown.Size = New System.Drawing.Size(1042, 358)
        Me.RichTextBoxUnknown.TabIndex = 0
        Me.RichTextBoxUnknown.Text = ""
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
        Me.TabPage3.Controls.Add(Me.RichTextBox4)
        Me.TabPage3.Location = New System.Drawing.Point(4, 24)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1592, 398)
        Me.TabPage3.TabIndex = 3
        Me.TabPage3.Text = "Footer Template"
        Me.TabPage3.UseVisualStyleBackColor = True
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
        Me.TabControl2.ResumeLayout(False)
        Me.FastTabPage.ResumeLayout(False)
        Me.SlowerTabPage.ResumeLayout(False)
        Me.SlowestTabPage.ResumeLayout(False)
        Me.UnknownTabPage.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents RichTextBox2 As RichTextBox
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
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents FastTabPage As TabPage
    Friend WithEvents SlowerTabPage As TabPage
    Friend WithEvents SlowestTabPage As TabPage
    Friend WithEvents UnknownTabPage As TabPage
    Friend WithEvents RichTextBoxFast As RichTextBox
    Friend WithEvents RichTextBoxSlower As RichTextBox
    Friend WithEvents RichTextBoxSlowest As RichTextBox
    Friend WithEvents RichTextBoxUnknown As RichTextBox
End Class
