Imports CommonLibrary
Imports AppCore

Public Class frmSBCURRENCY
    Inherits AppCore.frmMaintenance
    Public ExchangerateGrid As GridEx
    Private v_strSender As String = String.Empty




#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents txtCCYNAME As System.Windows.Forms.TextBox
    Friend WithEvents txtCCYDECIMAL As System.Windows.Forms.TextBox
    Friend WithEvents cboACTIVE As ComboBoxEx
    Friend WithEvents lblCCYCD As System.Windows.Forms.Label
    Friend WithEvents lblSHORTCD As System.Windows.Forms.Label
    Friend WithEvents lblCCYNAME As System.Windows.Forms.Label
    Friend WithEvents lblCCYDECIMAL As System.Windows.Forms.Label
    Friend WithEvents lblACTIVE As System.Windows.Forms.Label
    Friend WithEvents txtSHORTCD As System.Windows.Forms.TextBox
    Friend WithEvents txtCCYCD As FlexMaskEditBox
    Friend WithEvents grbInfo As System.Windows.Forms.GroupBox
    Friend WithEvents tabSBCURRENCY As System.Windows.Forms.TabControl
    Friend WithEvents tabCURRENCY As System.Windows.Forms.TabPage
    Friend WithEvents tabEXCHANGERATE As System.Windows.Forms.TabPage
    Friend WithEvents pnEXCHANGERATE As System.Windows.Forms.Panel
    Friend WithEvents btnCADD As System.Windows.Forms.Button
    Friend WithEvents btnCVIEW As System.Windows.Forms.Button
    Friend WithEvents btnCEDIT As System.Windows.Forms.Button
    Friend WithEvents btnCDEL As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtCCYNAME = New System.Windows.Forms.TextBox
        Me.txtCCYDECIMAL = New System.Windows.Forms.TextBox
        Me.cboACTIVE = New AppCore.ComboBoxEx
        Me.lblCCYCD = New System.Windows.Forms.Label
        Me.lblSHORTCD = New System.Windows.Forms.Label
        Me.lblCCYNAME = New System.Windows.Forms.Label
        Me.lblCCYDECIMAL = New System.Windows.Forms.Label
        Me.lblACTIVE = New System.Windows.Forms.Label
        Me.txtSHORTCD = New System.Windows.Forms.TextBox
        Me.txtCCYCD = New AppCore.FlexMaskEditBox
        Me.grbInfo = New System.Windows.Forms.GroupBox
        Me.tabSBCURRENCY = New System.Windows.Forms.TabControl
        Me.tabCURRENCY = New System.Windows.Forms.TabPage
        Me.tabEXCHANGERATE = New System.Windows.Forms.TabPage
        Me.btnCDEL = New System.Windows.Forms.Button
        Me.btnCEDIT = New System.Windows.Forms.Button
        Me.btnCVIEW = New System.Windows.Forms.Button
        Me.btnCADD = New System.Windows.Forms.Button
        Me.pnEXCHANGERATE = New System.Windows.Forms.Panel
        Me.grbInfo.SuspendLayout()
        Me.tabSBCURRENCY.SuspendLayout()
        Me.tabCURRENCY.SuspendLayout()
        Me.tabEXCHANGERATE.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(396, 285)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(554, 50)
        '
        'lblCaption
        '
        Me.lblCaption.Name = "lblCaption"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(316, 285)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.TabIndex = 1
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(476, 285)
        Me.btnApply.Name = "btnApply"
        '
        'txtCCYNAME
        '
        Me.txtCCYNAME.Location = New System.Drawing.Point(88, 52)
        Me.txtCCYNAME.MaxLength = 50
        Me.txtCCYNAME.Name = "txtCCYNAME"
        Me.txtCCYNAME.Size = New System.Drawing.Size(352, 21)
        Me.txtCCYNAME.TabIndex = 2
        Me.txtCCYNAME.Tag = "CCYNAME"
        Me.txtCCYNAME.Text = "txtCCYNAME"
        '
        'txtCCYDECIMAL
        '
        Me.txtCCYDECIMAL.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCCYDECIMAL.Location = New System.Drawing.Point(88, 80)
        Me.txtCCYDECIMAL.Name = "txtCCYDECIMAL"
        Me.txtCCYDECIMAL.Size = New System.Drawing.Size(128, 21)
        Me.txtCCYDECIMAL.TabIndex = 3
        Me.txtCCYDECIMAL.Tag = "CCYDECIMAL"
        Me.txtCCYDECIMAL.Text = "txtCCYDECIMAL"
        '
        'cboACTIVE
        '
        Me.cboACTIVE.DisplayMember = "DISPLAY"
        Me.cboACTIVE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboACTIVE.Location = New System.Drawing.Point(320, 80)
        Me.cboACTIVE.MaxLength = 20
        Me.cboACTIVE.Name = "cboACTIVE"
        Me.cboACTIVE.Size = New System.Drawing.Size(120, 21)
        Me.cboACTIVE.TabIndex = 4
        Me.cboACTIVE.Tag = "ACTIVE"
        Me.cboACTIVE.ValueMember = "VALUE"
        '
        'lblCCYCD
        '
        Me.lblCCYCD.Location = New System.Drawing.Point(8, 24)
        Me.lblCCYCD.Name = "lblCCYCD"
        Me.lblCCYCD.Size = New System.Drawing.Size(80, 21)
        Me.lblCCYCD.TabIndex = 16
        Me.lblCCYCD.Tag = "CCYCD"
        Me.lblCCYCD.Text = "lblCCYCD"
        Me.lblCCYCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSHORTCD
        '
        Me.lblSHORTCD.Location = New System.Drawing.Point(160, 24)
        Me.lblSHORTCD.Name = "lblSHORTCD"
        Me.lblSHORTCD.Size = New System.Drawing.Size(80, 21)
        Me.lblSHORTCD.TabIndex = 17
        Me.lblSHORTCD.Tag = "SHORTCD"
        Me.lblSHORTCD.Text = "lblSHORTCD"
        Me.lblSHORTCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCCYNAME
        '
        Me.lblCCYNAME.Location = New System.Drawing.Point(8, 52)
        Me.lblCCYNAME.Name = "lblCCYNAME"
        Me.lblCCYNAME.Size = New System.Drawing.Size(80, 21)
        Me.lblCCYNAME.TabIndex = 18
        Me.lblCCYNAME.Tag = "CCYNAME"
        Me.lblCCYNAME.Text = "lblCCYNAME"
        Me.lblCCYNAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCCYDECIMAL
        '
        Me.lblCCYDECIMAL.Location = New System.Drawing.Point(8, 80)
        Me.lblCCYDECIMAL.Name = "lblCCYDECIMAL"
        Me.lblCCYDECIMAL.Size = New System.Drawing.Size(90, 21)
        Me.lblCCYDECIMAL.TabIndex = 19
        Me.lblCCYDECIMAL.Tag = "CCYDECIMAL"
        Me.lblCCYDECIMAL.Text = "lblCCYDECIMAL"
        Me.lblCCYDECIMAL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblACTIVE
        '
        Me.lblACTIVE.Location = New System.Drawing.Point(240, 80)
        Me.lblACTIVE.Name = "lblACTIVE"
        Me.lblACTIVE.Size = New System.Drawing.Size(80, 21)
        Me.lblACTIVE.TabIndex = 20
        Me.lblACTIVE.Tag = "ACTIVE"
        Me.lblACTIVE.Text = "lblACTIVE"
        Me.lblACTIVE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSHORTCD
        '
        Me.txtSHORTCD.Location = New System.Drawing.Point(240, 24)
        Me.txtSHORTCD.MaxLength = 50
        Me.txtSHORTCD.Name = "txtSHORTCD"
        Me.txtSHORTCD.Size = New System.Drawing.Size(200, 21)
        Me.txtSHORTCD.TabIndex = 1
        Me.txtSHORTCD.Tag = "SHORTCD"
        Me.txtSHORTCD.Text = "txtSHORTCD"
        '
        'txtCCYCD
        '
        Me.txtCCYCD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCCYCD.Location = New System.Drawing.Point(88, 24)
        Me.txtCCYCD.Name = "txtCCYCD"
        Me.txtCCYCD.Size = New System.Drawing.Size(48, 21)
        Me.txtCCYCD.TabIndex = 0
        Me.txtCCYCD.Tag = "CCYCD"
        Me.txtCCYCD.Text = "txtCCYCD"
        '
        'grbInfo
        '
        Me.grbInfo.Controls.Add(Me.lblCCYCD)
        Me.grbInfo.Controls.Add(Me.txtCCYCD)
        Me.grbInfo.Controls.Add(Me.txtSHORTCD)
        Me.grbInfo.Controls.Add(Me.lblSHORTCD)
        Me.grbInfo.Controls.Add(Me.txtCCYNAME)
        Me.grbInfo.Controls.Add(Me.lblCCYNAME)
        Me.grbInfo.Controls.Add(Me.txtCCYDECIMAL)
        Me.grbInfo.Controls.Add(Me.lblCCYDECIMAL)
        Me.grbInfo.Controls.Add(Me.cboACTIVE)
        Me.grbInfo.Controls.Add(Me.lblACTIVE)
        Me.grbInfo.Location = New System.Drawing.Point(8, 16)
        Me.grbInfo.Name = "grbInfo"
        Me.grbInfo.Size = New System.Drawing.Size(448, 112)
        Me.grbInfo.TabIndex = 0
        Me.grbInfo.TabStop = False
        Me.grbInfo.Tag = "grbInfo"
        Me.grbInfo.Text = "grbInfo"
        '
        'tabSBCURRENCY
        '
        Me.tabSBCURRENCY.Controls.Add(Me.tabCURRENCY)
        Me.tabSBCURRENCY.Controls.Add(Me.tabEXCHANGERATE)
        Me.tabSBCURRENCY.Location = New System.Drawing.Point(6, 56)
        Me.tabSBCURRENCY.Name = "tabSBCURRENCY"
        Me.tabSBCURRENCY.SelectedIndex = 0
        Me.tabSBCURRENCY.Size = New System.Drawing.Size(544, 224)
        Me.tabSBCURRENCY.TabIndex = 3
        Me.tabSBCURRENCY.Tag = "tabSBCURRENCY"
        '
        'tabCURRENCY
        '
        Me.tabCURRENCY.Controls.Add(Me.grbInfo)
        Me.tabCURRENCY.Location = New System.Drawing.Point(4, 22)
        Me.tabCURRENCY.Name = "tabCURRENCY"
        Me.tabCURRENCY.Size = New System.Drawing.Size(536, 198)
        Me.tabCURRENCY.TabIndex = 0
        Me.tabCURRENCY.Tag = "tabCURRENCY"
        Me.tabCURRENCY.Text = "tabCURRENCY"
        '
        'tabEXCHANGERATE
        '
        Me.tabEXCHANGERATE.Controls.Add(Me.btnCDEL)
        Me.tabEXCHANGERATE.Controls.Add(Me.btnCEDIT)
        Me.tabEXCHANGERATE.Controls.Add(Me.btnCVIEW)
        Me.tabEXCHANGERATE.Controls.Add(Me.btnCADD)
        Me.tabEXCHANGERATE.Controls.Add(Me.pnEXCHANGERATE)
        Me.tabEXCHANGERATE.Location = New System.Drawing.Point(4, 22)
        Me.tabEXCHANGERATE.Name = "tabEXCHANGERATE"
        Me.tabEXCHANGERATE.Size = New System.Drawing.Size(536, 198)
        Me.tabEXCHANGERATE.TabIndex = 1
        Me.tabEXCHANGERATE.Tag = "tabEXCHANGERATE"
        Me.tabEXCHANGERATE.Text = "tabEXCHANGERATE"
        '
        'btnCDEL
        '
        Me.btnCDEL.Location = New System.Drawing.Point(296, 16)
        Me.btnCDEL.Name = "btnCDEL"
        Me.btnCDEL.TabIndex = 105
        Me.btnCDEL.Tag = "btnCDEL"
        Me.btnCDEL.Text = "btnCDEL"
        '
        'btnCEDIT
        '
        Me.btnCEDIT.Location = New System.Drawing.Point(200, 16)
        Me.btnCEDIT.Name = "btnCEDIT"
        Me.btnCEDIT.TabIndex = 104
        Me.btnCEDIT.Tag = "btnCEDIT"
        Me.btnCEDIT.Text = "btnCEDIT"
        '
        'btnCVIEW
        '
        Me.btnCVIEW.Location = New System.Drawing.Point(104, 16)
        Me.btnCVIEW.Name = "btnCVIEW"
        Me.btnCVIEW.TabIndex = 103
        Me.btnCVIEW.Tag = "btnCVIEW"
        Me.btnCVIEW.Text = "btnCVIEW"
        '
        'btnCADD
        '
        Me.btnCADD.Location = New System.Drawing.Point(16, 16)
        Me.btnCADD.Name = "btnCADD"
        Me.btnCADD.TabIndex = 100
        Me.btnCADD.Tag = "btnCADD"
        Me.btnCADD.Text = "btnCADD"
        '
        'pnEXCHANGERATE
        '
        Me.pnEXCHANGERATE.Location = New System.Drawing.Point(8, 48)
        Me.pnEXCHANGERATE.Name = "pnEXCHANGERATE"
        Me.pnEXCHANGERATE.Size = New System.Drawing.Size(520, 136)
        Me.pnEXCHANGERATE.TabIndex = 0
        Me.pnEXCHANGERATE.Tag = "pnEXCHANGERATE"
        '
        'frmSBCURRENCY
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(554, 311)
        Me.Controls.Add(Me.tabSBCURRENCY)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Name = "frmSBCURRENCY"
        Me.Tag = "SBCURRENCY"
        Me.Text = "frmSBCURRENCY"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnApply, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.tabSBCURRENCY, 0)
        Me.grbInfo.ResumeLayout(False)
        Me.tabSBCURRENCY.ResumeLayout(False)
        Me.tabCURRENCY.ResumeLayout(False)
        Me.tabEXCHANGERATE.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub InitExternal()
        ExchangerateGrid = New GridEx

        Dim v_cmrContactsHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrContactsHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrContactsHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        ExchangerateGrid.FixedHeaderRows.Add(v_cmrContactsHeader)
        ExchangerateGrid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(System.String)))
        ExchangerateGrid.Columns.Add(New Xceed.Grid.Column("CCYCD", GetType(System.String)))
        ExchangerateGrid.Columns.Add(New Xceed.Grid.Column("EDATE", GetType(System.String)))
        ExchangerateGrid.Columns.Add(New Xceed.Grid.Column("RATENUM", GetType(System.String)))
        ExchangerateGrid.Columns.Add(New Xceed.Grid.Column("RATEBCY", GetType(System.String)))
        ExchangerateGrid.Columns.Add(New Xceed.Grid.Column("RATEUSD", GetType(System.String)))
        ExchangerateGrid.Columns.Add(New Xceed.Grid.Column("RATELCY", GetType(System.String)))

        ExchangerateGrid.Columns("AUTOID").Title = ResourceManager.GetString("grid.CCYCD")
        ExchangerateGrid.Columns("CCYCD").Title = ResourceManager.GetString("grid.CCYCD")
        ExchangerateGrid.Columns("EDATE").Title = ResourceManager.GetString("grid.EDATE")
        ExchangerateGrid.Columns("RATENUM").Title = ResourceManager.GetString("grid.RATENUM")
        ExchangerateGrid.Columns("RATEBCY").Title = ResourceManager.GetString("grid.RATEBCY")
        ExchangerateGrid.Columns("RATEUSD").Title = ResourceManager.GetString("grid.RATEUSD")
        ExchangerateGrid.Columns("RATELCY").Title = ResourceManager.GetString("grid.RATELCY")

        ExchangerateGrid.Columns("AUTOID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        ExchangerateGrid.Columns("CCYCD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        ExchangerateGrid.Columns("EDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ExchangerateGrid.Columns("RATENUM").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ExchangerateGrid.Columns("RATEBCY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ExchangerateGrid.Columns("RATEUSD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ExchangerateGrid.Columns("RATELCY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ExchangerateGrid.Columns("AUTOID").Width = 0
        pnEXCHANGERATE.Controls.Clear()
        pnEXCHANGERATE.Controls.Add(ExchangerateGrid)
        ExchangerateGrid.Dock = Windows.Forms.DockStyle.Fill
    End Sub
    Private Sub LoadExchangerate()
        Try
            If Not ExchangerateGrid Is Nothing Then
                'Remove các bản ghi cũ
                ExchangerateGrid.DataRows.Clear()
                Dim v_strSQL As String = "SELECT DISTINCT AUTOID,SBCURRENCY.SHORTCD CCYCD, EDATE,A0.CDCONTENT RATENUM, RATEBCY, RATEUSD,RATELCY FROM SBFXRT SBFXRT, ALLCODE A0,SBCURRENCY SBCURRENCY " & _
                " WHERE A0.CDTYPE = 'SY' and A0.CDNAME ='RATENUM' AND A0.CDVAL = RATENUM and SBCURRENCY.CCYCD = SBFXRT.CCYCD AND SBFXRT.CCYCD='" & Me.txtCCYCD.Text & "'"
                Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "CF.CFCONTACT", _
                    gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                'FillDataGrid(ContactsGrid, v_strObjMsg, gc_RootNamespace & "." & Me.Name & "-" & UserLanguage)
                FillDataGrid(ExchangerateGrid, v_strObjMsg, "")
            End If
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub
    Public Sub showfrmIRRATE(ByVal pv_intExecFlag As Integer)
        Try
            Dim v_frm As frmSBFXRT
            v_frm = New frmSBFXRT
            v_frm.ExeFlag = pv_intExecFlag
            v_frm.UserLanguage = UserLanguage
            v_frm.ModuleCode = ModuleCode
            v_frm.ObjectName = "SA.SBFXRT"
            v_frm.TableName = "SBFXRT"
            v_frm.LocalObject = "N"
            v_frm.BusDate = Me.BusDate
            v_frm.CCYCD = Me.txtCCYCD.Text
            v_frm.Text = "" 'Lay tu resource
            'v_strKeyFieldName = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells(mv_strKeyColumn).FieldName
            'v_strKeyFieldValue = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells(mv_strKeyColumn).Value
            If Not (pv_intExecFlag = ExecuteFlag.AddNew) Then
                v_frm.KeyFieldName = "AUTOID"
                v_frm.KeyFieldType = "N"
                v_frm.KeyFieldValue = Trim(CType(ExchangerateGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
            End If

            If (pv_intExecFlag = ExecuteFlag.AddNew) Then
                v_frm.ExeFlag = ExecuteFlag.AddNew
                'v_frm.v_strSYMBOL = Me.txtSYMBOL.Text
                'v_frm.v_strCODEID = Me.txtCODEID.Text

            ElseIf (pv_intExecFlag = ExecuteFlag.View) Then
                v_frm.ExeFlag = ExecuteFlag.View

            ElseIf (pv_intExecFlag = ExecuteFlag.Edit) Then
                v_frm.ExeFlag = ExecuteFlag.Edit

            ElseIf (pv_intExecFlag = ExecuteFlag.Delete) Then
                v_frm.ExeFlag = ExecuteFlag.Delete
            End If
            v_frm.ShowDialog()
        Catch ex As Exception
            Throw ex

        End Try
    End Sub
    Protected Overridable Function OnDelete(Optional ByVal pv_strIsLocal As String = "", Optional ByVal pv_strModule As String = "") As Int32
        Dim v_strKeyFieldName, v_strKeyFieldValue As String
        Dim v_strClause As String

        Try
            If MsgBox(ResourceManager.GetString("DelConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                'Update mouse pointer
                Cursor.Current = Cursors.WaitCursor

                If (pv_strIsLocal <> "") And (pv_strModule <> "") Then
                    If Not (ExchangerateGrid.CurrentRow Is Nothing) Then
                        ' If Not (ContactsGrid.CurrentRow Is ContactsGrid.FixedFooterRows.Item(1)) Then
                        v_strKeyFieldName = CType(ExchangerateGrid.CurrentRow, Xceed.Grid.DataRow).Cells("RATEID").FieldName
                        v_strKeyFieldValue = CType(ExchangerateGrid.CurrentRow, Xceed.Grid.DataRow).Cells("RATEID").Value

                        Select Case KeyFieldType
                            Case "D"
                                v_strClause = v_strKeyFieldName & " = TO_DATE('" & v_strKeyFieldValue & "', '" & gc_FORMAT_DATE & "')"
                            Case "N"
                                v_strClause = v_strKeyFieldName & " = " & v_strKeyFieldValue
                            Case "C"
                                v_strClause = v_strKeyFieldName & " = '" & v_strKeyFieldValue & "'"
                        End Select

                        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, pv_strIsLocal, gc_MsgTypeObj, pv_strModule, gc_ActionDelete, , v_strClause)
                        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                        Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                        'Kiểm tra thông tin và xử lý lỗi (nếu có) từ message trả về
                        Dim v_strErrorSource, v_strErrorMessage As String                        

                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                        If v_lngErrorCode <> 0 Then
                            'Update mouse pointer
                            Cursor.Current = Cursors.Default
                            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text)
                            Exit Function
                        End If

                        'Remove dòng dữ liệu đã xoá khỏi grid
                        ExchangerateGrid.CurrentRow.Remove()
                        'Else
                        '    Update mouse pointer
                        '    Cursor.Current = Cursors.Default
                        '    MsgBox(ResourceManager.GetString("frmSearch.Footer"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text)
                        '    Exit Function
                        'End If
                    Else

                        Exit Function
                    End If
                End If

                'Đồng bộ lại thông tin
                'LoadCFContacts(Me.txtACCTNO.Text)
                'OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName)

                'Update mouse pointer
                Cursor.Current = Cursors.Default
                MsgBox(ResourceManager.GetString("DelSuccess"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text)
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try

    End Function
#Region " Overrides Methods "
    Public Overrides Sub OnInit()
        Dim v_ctrl As Windows.Forms.Control

        Try
            MyBase.OnInit()

            'Load Resource Manager
            ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & Me.Name & "-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            LoadUserInterface(Me)
            InitExternal()
            LoadExchangerate()
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("InitDialogFailed"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Public Overrides Sub OnSave()
        Dim v_strObjMsg As String

        Try
            'Update mouse pointer
            Cursor.Current = Cursors.WaitCursor

            MyBase.OnSave()
            If Not DoDataExchange(True) Then
                Exit Sub
            End If

            Select Case ExeFlag
                Case ExecuteFlag.AddNew
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdd, , , , gc_AutoIdUnused)
                    BuildXMLObjData(mv_dsInput, v_strObjMsg)

                    Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                    'Kiểm tra thông tin và xử lý lỗi (nếu có) từ message trả về
                    Dim v_strErrorSource, v_strErrorMessage As String                    

                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text)
                        Exit Sub
                    End If

                    MsgBox(ResourceManager.GetString("AddnewSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
                    If v_strSender <> "btnApply" Then
                        Me.DialogResult = DialogResult.OK
                        MyBase.OnClose()
                    Else
                        Me.btnCADD.Enabled = True
                        Me.btnCDEL.Enabled = True
                        Me.btnCVIEW.Enabled = True
                        Me.btnCEDIT.Enabled = True
                    End If
                Case ExecuteFlag.Edit
                    Dim v_strClause As String

                    Select Case KeyFieldType
                        Case "C"
                            v_strClause = KeyFieldName & " = '" & KeyFieldValue & "'"
                        Case "D"
                            v_strClause = KeyFieldName & " = TO_DATE('" & KeyFieldValue & "', '" & gc_FORMAT_DATE & "')"
                        Case "N"
                            v_strClause = KeyFieldName & " = " & KeyFieldValue.ToString()
                    End Select

                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionEdit, , v_strClause)
                    BuildXMLObjData(mv_dsInput, v_strObjMsg, mv_dsOldInput, ExecuteFlag.Edit)

                    Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                    'Kiểm tra thông tin và xử lý lỗi (nếu có) từ message trả về
                    Dim v_strErrorSource, v_strErrorMessage As String                    

                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text)
                        Exit Sub
                    End If

                    MsgBox(ResourceManager.GetString("EditSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
                    Me.DialogResult = DialogResult.OK
                    MyBase.OnClose()
            End Select

            'Update mouse pointer
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Public Overrides Function DoDataExchange(Optional ByVal pv_blnSaved As Boolean = False) As Boolean
        Try
            If Not ControlValidation(pv_blnSaved) Then
                Return False
            End If

            Return MyBase.DoDataExchange(pv_blnSaved)
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function

    Overrides Sub LoadUserInterface(ByRef pv_ctrl As Windows.Forms.Control)
        MyBase.LoadUserInterface(pv_ctrl)

        'Sửa chỗ này cho từng form maintenance khác nhau
        If (ExeFlag = ExecuteFlag.Edit) Then
            txtCCYCD.Enabled = False
        Else
            Me.btnCADD.Enabled = False
            Me.btnCDEL.Enabled = False
            Me.btnCVIEW.Enabled = False
            Me.btnCEDIT.Enabled = False
        End If
    End Sub
#End Region

#Region " Control validations "
    Private Function ControlValidation(Optional ByVal pv_blnSaved As Boolean = False) As Boolean
        Try
            If pv_blnSaved Then
                Return MyBase.VerifyRules()
            End If

            Return True
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function
#End Region

    Private Sub btnCADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCADD.Click
        showfrmIRRATE(ExecuteFlag.AddNew)
        LoadExchangerate()
    End Sub

    Private Sub btnCVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCVIEW.Click
        showfrmIRRATE(ExecuteFlag.View)
        LoadExchangerate()
    End Sub

    Private Sub btnCEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCEDIT.Click
        showfrmIRRATE(ExecuteFlag.Edit)
        LoadExchangerate()
    End Sub

    Private Sub btnCDEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCDEL.Click
        OnDelete("N", ModuleCode & ".IRRATE")
        LoadExchangerate()
    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        v_strSender = "btnApply"
    End Sub
End Class
