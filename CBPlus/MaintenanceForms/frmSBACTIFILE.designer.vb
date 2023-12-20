Imports AppCore

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSBACTIFILE
    Inherits AppCore.frmXtraMaintenance

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSBACTIFILE))
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.lblREFID = New DevExpress.XtraEditors.LabelControl()
        Me.txtREFID = New DevExpress.XtraEditors.TextEdit()
        Me.txtNOTES = New DevExpress.XtraEditors.TextEdit()
        Me.txtAUTOID = New DevExpress.XtraEditors.TextEdit()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.tblNOTES = New DevExpress.XtraEditors.LabelControl()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.lblFILETYP = New DevExpress.XtraEditors.LabelControl()
        Me.lblFILEDATA = New DevExpress.XtraEditors.LabelControl()
        Me.txtFILEDATA = New AppCore.ButtonEditCustom()
        Me.btnBrowse = New DevExpress.XtraEditors.SimpleButton()
        Me.txtFILETYP = New DevExpress.XtraEditors.TextEdit()
        Me.gclTitle = New DevExpress.XtraEditors.GroupControl()
        Me.panelPreview = New System.Windows.Forms.Panel()
        Me.DataTable1 = New System.Data.DataTable()
        Me.DataTable2 = New System.Data.DataTable()
        Me.DataTable123 = New System.Data.DataTable()
        Me.DataTable3 = New System.Data.DataTable()
        Me.DataTable130 = New System.Data.DataTable()
        Me.popmenu = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.btnDownLoad = New DevExpress.XtraBars.BarButtonItem()
        CType(Me.txtREFID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNOTES.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAUTOID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.txtFILEDATA.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFILETYP.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gclTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gclTitle.SuspendLayout()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable123, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable130, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.popmenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblREFID
        '
        Me.lblREFID.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblREFID.Location = New System.Drawing.Point(3, 6)
        Me.lblREFID.Name = "lblREFID"
        Me.lblREFID.Size = New System.Drawing.Size(30, 13)
        Me.lblREFID.TabIndex = 1
        Me.lblREFID.Tag = "REFID"
        Me.lblREFID.Text = "REFID"
        '
        'txtREFID
        '
        Me.txtREFID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtREFID.Location = New System.Drawing.Point(163, 3)
        Me.txtREFID.Name = "txtREFID"
        Me.txtREFID.Properties.ReadOnly = True
        Me.txtREFID.Size = New System.Drawing.Size(639, 20)
        Me.txtREFID.TabIndex = 27
        Me.txtREFID.Tag = "REFID"
        '
        'txtNOTES
        '
        Me.txtNOTES.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNOTES.Location = New System.Drawing.Point(163, 29)
        Me.txtNOTES.Name = "txtNOTES"
        Me.txtNOTES.Size = New System.Drawing.Size(639, 20)
        Me.txtNOTES.TabIndex = 8
        Me.txtNOTES.Tag = "NOTES"
        '
        'txtAUTOID
        '
        Me.txtAUTOID.EditValue = "txtAUTOID"
        Me.txtAUTOID.Location = New System.Drawing.Point(152, 3)
        Me.txtAUTOID.Name = "txtAUTOID"
        Me.txtAUTOID.Size = New System.Drawing.Size(4, 20)
        Me.txtAUTOID.TabIndex = 31
        Me.txtAUTOID.Tag = "AUTOID"
        Me.txtAUTOID.Visible = False
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupControl1.Controls.Add(Me.TableLayoutPanel3)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 50)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(809, 572)
        Me.GroupControl1.TabIndex = 2
        Me.GroupControl1.Tag = "GroupControl1"
        Me.GroupControl1.Text = "Thêm mới quỹ hưu trí đầu tư"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 149.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 11.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.txtNOTES, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtREFID, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblREFID, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtAUTOID, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tblNOTES, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(2, 21)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(805, 53)
        Me.TableLayoutPanel1.TabIndex = 32
        '
        'tblNOTES
        '
        Me.tblNOTES.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tblNOTES.Location = New System.Drawing.Point(3, 33)
        Me.tblNOTES.Name = "tblNOTES"
        Me.tblNOTES.Size = New System.Drawing.Size(33, 13)
        Me.tblNOTES.TabIndex = 20
        Me.tblNOTES.Tag = "NOTES"
        Me.tblNOTES.Text = "NOTES"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 161.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.btnSave, 2, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.lblFILETYP, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.lblFILEDATA, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.txtFILEDATA, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnBrowse, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.txtFILETYP, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.gclTitle, 0, 2)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(2, 73)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 3
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(805, 497)
        Me.TableLayoutPanel3.TabIndex = 30
        Me.TableLayoutPanel3.Tag = "FILEDATA"
        '
        'btnSave
        '
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(716, 28)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(86, 24)
        Me.btnSave.TabIndex = 36
        Me.btnSave.Tag = "btnSave"
        Me.btnSave.Text = "Save file"
        '
        'lblFILETYP
        '
        Me.lblFILETYP.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFILETYP.Location = New System.Drawing.Point(3, 33)
        Me.lblFILETYP.Name = "lblFILETYP"
        Me.lblFILETYP.Size = New System.Drawing.Size(39, 13)
        Me.lblFILETYP.TabIndex = 33
        Me.lblFILETYP.Tag = "FILETYP"
        Me.lblFILETYP.Text = "FILETYP"
        '
        'lblFILEDATA
        '
        Me.lblFILEDATA.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFILEDATA.Location = New System.Drawing.Point(3, 6)
        Me.lblFILEDATA.Name = "lblFILEDATA"
        Me.lblFILEDATA.Size = New System.Drawing.Size(48, 13)
        Me.lblFILEDATA.TabIndex = 1
        Me.lblFILEDATA.Tag = "FILEDATA"
        Me.lblFILEDATA.Text = "FILEDATA"
        '
        'txtFILEDATA
        '
        Me.txtFILEDATA.ActionControl = AppCore.ButtonEditCustom.ActionEnum.ADD
        Me.txtFILEDATA.DataByte = Nothing
        Me.txtFILEDATA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFILEDATA.Location = New System.Drawing.Point(164, 3)
        Me.txtFILEDATA.Name = "txtFILEDATA"
        Me.txtFILEDATA.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "", -1, True, False, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, "", Nothing, Nothing, True)})
        Me.txtFILEDATA.Properties.ReadOnly = True
        Me.txtFILEDATA.Size = New System.Drawing.Size(546, 20)
        Me.txtFILEDATA.TabIndex = 33
        Me.txtFILEDATA.Tag = "FILEDATA"
        '
        'btnBrowse
        '
        Me.btnBrowse.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnBrowse.Image = CType(resources.GetObject("btnBrowse.Image"), System.Drawing.Image)
        Me.btnBrowse.Location = New System.Drawing.Point(716, 3)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(86, 19)
        Me.btnBrowse.TabIndex = 34
        Me.btnBrowse.Text = "Browse"
        '
        'txtFILETYP
        '
        Me.txtFILETYP.Location = New System.Drawing.Point(164, 28)
        Me.txtFILETYP.Name = "txtFILETYP"
        Me.txtFILETYP.Size = New System.Drawing.Size(546, 20)
        Me.txtFILETYP.TabIndex = 32
        Me.txtFILETYP.Tag = "FILETYP"
        '
        'gclTitle
        '
        Me.TableLayoutPanel3.SetColumnSpan(Me.gclTitle, 3)
        Me.gclTitle.Controls.Add(Me.panelPreview)
        Me.gclTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gclTitle.Location = New System.Drawing.Point(3, 58)
        Me.gclTitle.Name = "gclTitle"
        Me.gclTitle.Size = New System.Drawing.Size(799, 436)
        Me.gclTitle.TabIndex = 35
        Me.gclTitle.Tag = "PREVIEW_PDF"
        Me.gclTitle.Text = "Preview"
        '
        'panelPreview
        '
        Me.panelPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelPreview.Location = New System.Drawing.Point(2, 21)
        Me.panelPreview.Name = "panelPreview"
        Me.panelPreview.Size = New System.Drawing.Size(795, 413)
        Me.panelPreview.TabIndex = 0
        '
        'DataTable1
        '
        Me.DataTable1.Namespace = ""
        Me.DataTable1.TableName = "COMBOBOX"
        '
        'DataTable2
        '
        Me.DataTable2.Namespace = ""
        Me.DataTable2.TableName = "COMBOBOX"
        '
        'DataTable123
        '
        Me.DataTable123.Namespace = ""
        Me.DataTable123.TableName = "COMBOBOX"
        '
        'DataTable3
        '
        Me.DataTable3.Namespace = ""
        Me.DataTable3.TableName = "COMBOBOX"
        '
        'DataTable130
        '
        Me.DataTable130.Namespace = ""
        Me.DataTable130.TableName = "COMBOBOX"
        '
        'popmenu
        '
        Me.popmenu.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnDownLoad)})
        Me.popmenu.Manager = Me.BarManager1
        Me.popmenu.Name = "popmenu"
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnDownLoad})
        Me.BarManager1.MaxItemId = 3
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(809, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 666)
        Me.barDockControlBottom.Size = New System.Drawing.Size(809, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 666)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(809, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 666)
        '
        'btnDownLoad
        '
        Me.btnDownLoad.Caption = "BarButtonItem1"
        Me.btnDownLoad.Id = 2
        Me.btnDownLoad.Name = "btnDownLoad"
        '
        'frmSBACTIFILE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(809, 666)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "frmSBACTIFILE"
        Me.Tag = "frmSBACTIFILE"
        Me.Text = "frmSBACTIFILE"
        Me.Controls.SetChildIndex(Me.barDockControlTop, 0)
        Me.Controls.SetChildIndex(Me.barDockControlBottom, 0)
        Me.Controls.SetChildIndex(Me.barDockControlRight, 0)
        Me.Controls.SetChildIndex(Me.barDockControlLeft, 0)
        Me.Controls.SetChildIndex(Me.GroupControl1, 0)
        CType(Me.txtREFID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNOTES.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAUTOID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        CType(Me.txtFILEDATA.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFILETYP.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gclTitle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gclTitle.ResumeLayout(False)
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable123, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable130, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.popmenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtNOTES As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblREFID As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents txtREFID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents DataTable1 As System.Data.DataTable
    Friend WithEvents DataTable2 As System.Data.DataTable
    Friend WithEvents txtAUTOID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents DataTable123 As System.Data.DataTable
    Friend WithEvents DataTable3 As System.Data.DataTable
    Friend WithEvents DataTable130 As System.Data.DataTable
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblFILEDATA As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtFILEDATA As AppCore.ButtonEditCustom
    Friend WithEvents btnBrowse As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents gclTitle As DevExpress.XtraEditors.GroupControl
    Friend WithEvents panelPreview As System.Windows.Forms.Panel
    Friend WithEvents tblNOTES As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblFILETYP As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtFILETYP As DevExpress.XtraEditors.TextEdit
    Friend WithEvents popmenu As DevExpress.XtraBars.PopupMenu
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnDownLoad As DevExpress.XtraBars.BarButtonItem
End Class
