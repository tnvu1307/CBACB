Imports CommonLibrary
Imports AppCore
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports System.IO.Path
Imports System.Windows.Forms.Application

Public Class frmSendSecurties
    Inherits AppCore.frmSearch

    Private mv_strLanguage As String
    Private mv_ResourceManager As Resources.ResourceManager
    Private c_ResourceManager As String = "_DIRECT.frmSendSecurities-"
    Private c_SearchResourceManager As String = "AppCore.frmSearch-"
    Private Const LEN_AFACCTNO As Integer = 10
    Private mv_arrObjFields() As CFieldMaster
    Private mv_arrObjFldVals() As CFieldVal
    'System.Windows.Forms.TextBox
    Friend WithEvents txtBANKNAME As System.Windows.Forms.TextBox
    Friend WithEvents lblTXNUM As System.Windows.Forms.Label
    Friend WithEvents txtTXNUM As System.Windows.Forms.Label
    Friend WithEvents cmdPrePrint As System.Windows.Forms.Button
    Friend WithEvents txtBANKACCNAME As System.Windows.Forms.TextBox
    Friend WithEvents lblBANKACCNAME As System.Windows.Forms.Label
    Friend WithEvents lblBANKACC As System.Windows.Forms.Label
    Friend WithEvents txtBANKACC As System.Windows.Forms.TextBox
    Dim mv_strBANKID As String = String.Empty
    Dim mv_strBANKNAME As String = String.Empty
    Dim mv_strBANKACC As String = String.Empty
    Dim mv_strBANKACCNAME As String = String.Empty
    Dim mv_strLastBANKID As String = String.Empty
    Dim mv_strLastCustodyCD As String = String.Empty
    Dim mv_strGLACCOUNT As String = String.Empty
    Dim mv_strSAFACCTNO As String = String.Empty
    Dim mv_strRAFACCTNO As String = String.Empty
    Dim mv_strFULLNAME As String = String.Empty
    Dim mv_strADDRESS As String = String.Empty
    Friend WithEvents lblGLACCTNO As System.Windows.Forms.Label
    Friend WithEvents txtGLACCTNO As System.Windows.Forms.TextBox
    Dim mv_blnAcctEntry As Boolean
    Friend WithEvents lblGLNAME As System.Windows.Forms.Label
    Friend WithEvents txtAMT As System.Windows.Forms.Label
    Friend WithEvents lblAMT As System.Windows.Forms.Label
    Dim mv_dblTotalAmt As Double = 0
    Private BranchName As String
    Private BranchAddress As String
    Private BranchPhoneFax As String
    Private ReportTitle As String
    Private HEADOFFICE As String
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents TabTranferInfo As System.Windows.Forms.TabPage
    Friend WithEvents TabBenefInfo As System.Windows.Forms.TabPage
    Friend WithEvents grbMain As System.Windows.Forms.GroupBox
    Friend WithEvents txtTXDATE As AppCore.FlexMaskEditBox
    Friend WithEvents lblTXDATE As System.Windows.Forms.Label
    Friend WithEvents grbBeneficiary As System.Windows.Forms.GroupBox
    Friend WithEvents txtBENEFNAME As System.Windows.Forms.TextBox
    Friend WithEvents lblBENEFNAME As System.Windows.Forms.Label
    Friend WithEvents txtBENEFBANKNAME As System.Windows.Forms.TextBox
    Friend WithEvents txtBENEFBANKACCT As System.Windows.Forms.TextBox
    Friend WithEvents txtDESCRIPTION As System.Windows.Forms.TextBox
    Friend WithEvents lblDESCRIPTION As System.Windows.Forms.Label
    Friend WithEvents lblBENEFBANKNAME As System.Windows.Forms.Label
    Friend WithEvents lblBENEFBANKACCT As System.Windows.Forms.Label

    Friend WithEvents TabAdvanced As System.Windows.Forms.TabPage
    Friend WithEvents lblRRTYPE As System.Windows.Forms.Label
    Friend WithEvents txtSRCACCTNO As AppCore.FlexMaskEditBox
    Friend WithEvents cboRRTYPE As AppCore.ComboBoxEx
    Friend WithEvents lblAVLPOOL As System.Windows.Forms.Label
    Friend WithEvents lblSCRACCTNO As System.Windows.Forms.Label
    Friend WithEvents lblADVAMT As System.Windows.Forms.Label
    Friend WithEvents txtAVLPOOL As System.Windows.Forms.TextBox
    Friend WithEvents txtADVFEEAMT As System.Windows.Forms.TextBox
    Friend WithEvents lblADVFEEAMT As System.Windows.Forms.Label
    Friend WithEvents txtADVAMT As System.Windows.Forms.TextBox
    Friend WithEvents txtPOOLREMAIN As System.Windows.Forms.TextBox
    Friend WithEvents lblPOOLREMAIN As System.Windows.Forms.Label
    Friend WithEvents grbAdvanced As System.Windows.Forms.GroupBox
    Friend WithEvents lblSAFACCTNO As System.Windows.Forms.Label
    Friend WithEvents cbSAFACCTNO As AppCore.ComboBoxEx
    Friend WithEvents lblRAFACCTNO As System.Windows.Forms.Label
    Friend WithEvents cbRAFACCTNO As AppCore.ComboBoxEx
    Friend WithEvents txtFULLNAME As System.Windows.Forms.TextBox
    Friend WithEvents txtADDRESS As System.Windows.Forms.TextBox

    Friend WithEvents lblFULLNAME As System.Windows.Forms.Label
    Friend WithEvents lblADDRESS As System.Windows.Forms.Label
    Private DEALINGCUSTODYCD As String
    Private Const mv_CONST_PREPRINT As String = "YES"
    Private Const mv_CONST_NOT_PREPRINT As String = "NO"
    Private Const mv_CONST_SEARCHCODE_2248 As String = "SE2248"
    Private Const mv_CONST_SEARCHCODE_3331 As String = "CA3331"
    Private Const mv_CONST_SEARCHCODE_8879 As String = "SE8879"
    Friend WithEvents txtADTXNUM As System.Windows.Forms.TextBox
    Friend WithEvents lblADTXNUM As System.Windows.Forms.Label
    Private Const mv_CONST_SEARCHCODE_ADVANCED As String = "CI1179/CI1178"
    Private mv_strIS1Transaction As String = "Y"
    Private mv_strBANKNAME_REF As String = String.Empty
    Private mv_strBANKACC_REF As String = String.Empty
    Private mv_strBANKCUSNAME_REF As String = String.Empty
    Private mv_strDESC_REF As String = String.Empty


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New(pv_strLanguage)

        'This call is required by the Windows Form Designer.
        mv_strLanguage = pv_strLanguage
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())

        InitializeComponent()

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
    Friend WithEvents lblBANKNAME As System.Windows.Forms.Label

    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSendSecurties))
        Me.TabMain = New System.Windows.Forms.TabControl
        Me.TabTranferInfo = New System.Windows.Forms.TabPage
        Me.grbMain = New System.Windows.Forms.GroupBox
        Me.txtTXDATE = New AppCore.FlexMaskEditBox
        Me.lblTXDATE = New System.Windows.Forms.Label
        Me.lblSAFACCTNO = New System.Windows.Forms.Label
        Me.cbSAFACCTNO = New AppCore.ComboBoxEx
        Me.lblRAFACCTNO = New System.Windows.Forms.Label
        Me.cbRAFACCTNO = New AppCore.ComboBoxEx
        Me.txtFULLNAME = New System.Windows.Forms.TextBox
        Me.txtADDRESS = New System.Windows.Forms.TextBox
        Me.lblFULLNAME = New System.Windows.Forms.Label
        Me.txtFULLNAME = New System.Windows.Forms.TextBox
        Me.lblADDRESS = New System.Windows.Forms.Label
        Me.txtADDRESS = New System.Windows.Forms.TextBox

        CType(Me.mv_SymbolTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabMain.SuspendLayout()
        Me.TabTranferInfo.SuspendLayout()
        Me.grbMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbSearchFilter
        '
        Me.grbSearchFilter.Location = New System.Drawing.Point(5, 177)
        Me.grbSearchFilter.Size = New System.Drawing.Size(859, 126)
        Me.grbSearchFilter.Text = "Điều kiện tìm kiếm:"
        '
        'grbSearchResult
        '
        Me.grbSearchResult.Location = New System.Drawing.Point(8, 304)
        Me.grbSearchResult.Size = New System.Drawing.Size(859, 310)
        Me.grbSearchResult.Text = "Kết quả tìm kiếm:"
        '
        'lstCondition
        '
        Me.lstCondition.Size = New System.Drawing.Size(342, 84)
        '
        'btnNEXT
        '
        Me.btnNEXT.Location = New System.Drawing.Point(64, 621)
        Me.btnNEXT.Text = "Sau"
        '
        'btnBACK
        '
        Me.btnBACK.Location = New System.Drawing.Point(8, 621)
        Me.btnBACK.Text = "Trước"
        '
        'chkALL
        '
        Me.chkALL.Location = New System.Drawing.Point(317, 626)
        '
        'chkExeAll
        '
        Me.chkExeAll.Location = New System.Drawing.Point(744, 625)
        '
        'chkauto
        '
        Me.chkauto.Location = New System.Drawing.Point(517, 625)
        '

        'TabMain
        '
        Me.TabMain.Controls.Add(Me.TabTranferInfo)
        Me.TabMain.Location = New System.Drawing.Point(5, 43)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(861, 130)
        Me.TabMain.TabIndex = 15
        '
        'TabTranferInfo
        '
        Me.TabTranferInfo.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.TabTranferInfo.Controls.Add(Me.grbMain)
        Me.TabTranferInfo.Location = New System.Drawing.Point(4, 22)
        Me.TabTranferInfo.Name = "TabTranferInfo"
        Me.TabTranferInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.TabTranferInfo.Size = New System.Drawing.Size(853, 104)
        Me.TabTranferInfo.TabIndex = 0
        Me.TabTranferInfo.Tag = "TabTranferInfo"
        Me.TabTranferInfo.Text = "Thông tin chung cho giao dịch"
        Me.TabTranferInfo.UseVisualStyleBackColor = True
        '
        'grbMain
        '
        Me.grbMain.BackColor = System.Drawing.SystemColors.GradientActiveCaption

        Me.grbMain.Controls.Add(Me.txtTXDATE)
        Me.grbMain.Controls.Add(Me.lblTXDATE)

        Me.grbMain.Controls.Add(Me.lblSAFACCTNO)
        Me.grbMain.Controls.Add(Me.cbSAFACCTNO)

        Me.grbMain.Controls.Add(Me.lblRAFACCTNO)
        Me.grbMain.Controls.Add(Me.cbRAFACCTNO)

        Me.grbMain.Controls.Add(Me.lblSAFACCTNO)
        Me.grbMain.Controls.Add(Me.cbSAFACCTNO)

        Me.grbMain.Controls.Add(Me.lblFULLNAME)
        Me.grbMain.Controls.Add(Me.txtFULLNAME)

        Me.grbMain.Controls.Add(Me.lblADDRESS)
        Me.grbMain.Controls.Add(Me.txtADDRESS)


        Me.grbMain.Location = New System.Drawing.Point(3, 5)
        Me.grbMain.Name = "grbMain"
        Me.grbMain.Size = New System.Drawing.Size(848, 98)
        Me.grbMain.TabIndex = 0
        Me.grbMain.TabStop = False
        '
        'txtTXDATE
        '
        Me.txtTXDATE.Location = New System.Drawing.Point(96, 16)
        Me.txtTXDATE.Name = "mskTXDATE"
        Me.txtTXDATE.Size = New System.Drawing.Size(83, 21)
        Me.txtTXDATE.TabIndex = 3
        Me.txtTXDATE.Tag = "TXDATE"

        '
        'lblTXDATE
        '
        Me.lblTXDATE.Location = New System.Drawing.Point(8, 17)
        Me.lblTXDATE.Name = "lblTXDATE"
        Me.lblTXDATE.Size = New System.Drawing.Size(92, 20)
        Me.lblTXDATE.TabIndex = 2
        Me.lblTXDATE.Tag = "lblTXDATE"
        Me.lblTXDATE.Text = "lblTXDATE"
        Me.lblTXDATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSAFACCTNO
        '
        Me.lblSAFACCTNO.Location = New System.Drawing.Point(185, 17)
        Me.lblSAFACCTNO.Name = "lblSAFACCTNO"
        Me.lblSAFACCTNO.Size = New System.Drawing.Size(110, 20)
        Me.lblSAFACCTNO.TabIndex = 32
        Me.lblSAFACCTNO.Tag = "lblSAFACCTNO"
        Me.lblSAFACCTNO.Text = "lblSAFACCTNO"
        Me.lblSAFACCTNO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbSAFACCTNO
        '
        Me.cbSAFACCTNO.Location = New System.Drawing.Point(295, 15)
        Me.cbSAFACCTNO.Name = "cbSAFACCTNO"
        Me.cbSAFACCTNO.Size = New System.Drawing.Size(190, 21)
        Me.cbSAFACCTNO.TabIndex = 1
        Me.cbSAFACCTNO.Tag = "cbSAFACCTNO"

        'lblRAFACCTNO
        '
        Me.lblRAFACCTNO.Location = New System.Drawing.Point(483, 17)
        Me.lblRAFACCTNO.Name = "lblRAFACCTNO"
        Me.lblRAFACCTNO.Size = New System.Drawing.Size(100, 20)
        Me.lblRAFACCTNO.TabIndex = 34
        Me.lblRAFACCTNO.Tag = "lblRAFACCTNO"
        Me.lblRAFACCTNO.Text = "lblRAFACCTNO"
        Me.lblRAFACCTNO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbRAFACCTNO
        '
        Me.cbRAFACCTNO.Location = New System.Drawing.Point(583, 13)
        Me.cbRAFACCTNO.Name = "cbRAFACCTNO"
        Me.cbRAFACCTNO.Size = New System.Drawing.Size(190, 21)
        Me.cbRAFACCTNO.TabIndex = 2
        Me.cbRAFACCTNO.Tag = "cbRAFACCTNO"
        'lblFULLNAME
        '
        Me.lblFULLNAME.Location = New System.Drawing.Point(6, 42)
        Me.lblFULLNAME.Name = "lblFULLNAME"
        Me.lblFULLNAME.Size = New System.Drawing.Size(92, 20)
        Me.lblFULLNAME.TabIndex = 14
        Me.lblFULLNAME.Tag = "lblFULLNAME"
        Me.lblFULLNAME.Text = "lblFULLNAME"
        Me.lblFULLNAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFULLNAME
        '
        Me.txtFULLNAME.Location = New System.Drawing.Point(96, 43)
        Me.txtFULLNAME.Name = "txtFULLNAME"
        Me.txtFULLNAME.Size = New System.Drawing.Size(700, 21)
        Me.txtFULLNAME.TabIndex = 3
        Me.txtFULLNAME.Tag = "FULLNAME"
        '
        'txtADDRESS
        '
        Me.txtADDRESS.Location = New System.Drawing.Point(96, 70)
        Me.txtADDRESS.MaxLength = 5
        Me.txtADDRESS.Name = "txtADDRESS"
        Me.txtADDRESS.Size = New System.Drawing.Size(700, 21)
        Me.txtADDRESS.TabIndex = 4
        Me.txtADDRESS.Tag = "txtADDRESS"
        '
        'lblADDRESS
        '
        Me.lblADDRESS.Location = New System.Drawing.Point(6, 67)
        Me.lblADDRESS.Name = "lblADDRESS"
        Me.lblADDRESS.Size = New System.Drawing.Size(92, 20)
        Me.lblADDRESS.TabIndex = 29
        Me.lblADDRESS.Tag = "lblADDRESS"
        Me.lblADDRESS.Text = "lblADDRESS"
        Me.lblADDRESS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmSendSecurties
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(869, 670)
        Me.Controls.Add(Me.TabMain)
        Me.Name = "frmSendSecurties"
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.chkauto, 0)
        Me.Controls.SetChildIndex(Me.TabMain, 0)
        Me.Controls.SetChildIndex(Me.chkALL, 0)
        Me.Controls.SetChildIndex(Me.btnBACK, 0)
        Me.Controls.SetChildIndex(Me.btnNEXT, 0)
        Me.Controls.SetChildIndex(Me.chkExeAll, 0)
        Me.Controls.SetChildIndex(Me.grbSearchFilter, 0)
        Me.Controls.SetChildIndex(Me.grbSearchResult, 0)

        CType(Me.mv_SymbolTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabMain.ResumeLayout(False)
        Me.TabTranferInfo.ResumeLayout(False)
        Me.grbMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Private "
    'Private Function CalcTotalAmt() As Double
    '    Dim v_intRow As Integer
    '    Try
    '        mv_dblTotalAmt = 0
    '        For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
    '            If Not SearchGrid.DataRows(v_intRow) Is Nothing Then
    '                If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then
    '                    mv_dblTotalAmt = mv_dblTotalAmt + CDbl(SearchGrid.DataRows(v_intRow).Cells("AMT").Value)
    '                End If
    '            End If
    '        Next
    '    Catch ex As Exception

    '    End Try
    '    Return mv_dblTotalAmt

    'End Function

    'Private Sub LoadComboRRType()
    '    Try
    '        Dim v_strSQL As String = String.Empty
    '        Dim v_strObjMsg As String = String.Empty
    '        Dim v_ws As New BDSDeliveryManagement
    '        Dim v_xmlDocument As New XmlDocumentEx
    '        Dim v_nodeList As Xml.XmlNodeList
    '        Dim v_strValue, v_strFLDNAME, v_strErrorSource, v_strErrorMessage As String
    '        Dim v_lngError As Long = ERR_SYSTEM_OK

    '        v_strSQL = "SELECT * FROM VW_ADTYPE_INFO"

    '        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
    '        v_lngError = v_ws.Message(v_strObjMsg)

    '        If v_lngError <> ERR_SYSTEM_OK Then
    '            'Thông báo lỗi
    '            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
    '            Cursor.Current = Cursors.Default
    '            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
    '            Exit Sub
    '        End If

    '        FillComboEx(v_strObjMsg, cboRRTYPE, "", Me.UserLanguage)

    '    Catch ex As Exception
    '        LogError.Write("Error source: " & ex.Source & vbNewLine _
    '                     & "Error code: System error!" & vbNewLine _
    '                     & "Error message: " & ex.Message, EventLogEntryType.Error)
    '        MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
    '    End Try
    'End Sub

    'Private Sub SetAdvTypeInfo(ByVal pv_strACTYPE As String)
    '    Try
    '        Dim v_strSQL As String = String.Empty
    '        Dim v_strObjMsg As String = String.Empty
    '        Dim v_ws As New BDSDeliveryManagement
    '        Dim v_xmlDocument As New XmlDocumentEx
    '        Dim v_nodeList As Xml.XmlNodeList
    '        Dim v_strValue, v_strFLDNAME, v_strErrorSource, v_strErrorMessage As String
    '        Dim v_lngError As Long = ERR_SYSTEM_OK
    '        Dim v_dblTotalADVMINFEE, v_dblADVMINFEE, v_dblADVMINFEEBANK As Double

    '        Me.txtADVAMT.Text = Format(0, gc_FORMAT_NUMBER_0)
    '        Me.txtADVFEEAMT.Text = Format(0, gc_FORMAT_NUMBER_0)
    '        Me.txtPOOLREMAIN.Text = Format(0, gc_FORMAT_NUMBER_0)

    '        v_strSQL = "SELECT * FROM VW_ADTYPE_INFO WHERE ACTYPE ='" & pv_strACTYPE & "'"

    '        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
    '        v_lngError = v_ws.Message(v_strObjMsg)

    '        If v_lngError <> ERR_SYSTEM_OK Then
    '            'Thông báo lỗi
    '            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
    '            Cursor.Current = Cursors.Default
    '            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
    '            Exit Sub
    '        End If

    '        v_xmlDocument.LoadXml(v_strObjMsg)
    '        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

    '        For i As Integer = 0 To v_nodeList.Count - 1
    '            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
    '                With v_nodeList.Item(i).ChildNodes(j)
    '                    v_strValue = .InnerText.ToString
    '                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
    '                    Select Case Trim(v_strFLDNAME)
    '                        Case "SCRACCTNO"
    '                            txtSRCACCTNO.Text = Trim(v_strValue)
    '                        Case "AVLPOOL"
    '                            txtAVLPOOL.Text = IIf(gf_IsNumeric(v_strValue), Format(CDbl(v_strValue), gc_FORMAT_NUMBER_0), 0)
    '                    End Select
    '                End With
    '            Next
    '        Next

    '    Catch ex As Exception
    '        LogError.Write("Error source: " & ex.Source & vbNewLine _
    '                     & "Error code: System error!" & vbNewLine _
    '                     & "Error message: " & ex.Message, EventLogEntryType.Error)
    '        MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
    '    End Try
    'End Sub

    Private Function GetTXNUM(ByVal pv_strClause As String) As String
        Dim v_strClause, v_strAutoID As String
        'Lấy ra số tự tăng
        v_strClause = pv_strClause '"POTXNUM"
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_wsBDS As New BDSDeliveryManagement
        Try
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strClause, "GetInventory")
            v_wsBDS.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_strAutoID = v_xmlDocument.DocumentElement.Attributes("CLAUSE").Value

            Dim v_strTXNUM As String
            'Tạo số bảng kê = Mã chi nhánh + Số tự tăng
            v_strTXNUM = Me.BranchId & v_strAutoID.PadLeft(Len(gc_FORMAT_ODAUTOID), "0")

            Return v_strTXNUM
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Function
        Private Sub GetCustInfo(ByVal v_strCustodycd As String)

        Dim v_ws As New BDSDeliveryManagement

        Try
            v_strCustodycd = v_strCustodycd.Replace(".", "").ToUpper

            If mv_strLastCustodyCD <> v_strCustodycd Then
                'Dim v_strCODEID As String = Me.cboCODEID.SelectedValue
                Dim v_nodeList As Xml.XmlNodeList
                Dim v_xmlDocument As New Xml.XmlDocument
                Dim v_strValue, v_strFLDNAME, v_strTEXT As String, i, j As Integer

                Dim v_strCmdSQL As String, v_strObjMsg, v_strCURRPRICE, v_strSQL, v_strClause As String


                'v_strCmdSQL = "SELECT CF.CUSTID BANKID, CF.FULLNAME BANKNAME, CF.ORGINF BANKACC, CF.DESCRIPTION BANKACCNAME  FROM CFMAST CF WHERE CF.CUSTID = '" & v_strBANKID & "'"
                v_strCmdSQL = "SELECT AF.ACCTNO VALUE, AF.ACCTNO FILTER, AF.ACCTNO ||': '|| TYP.TYPENAME DISPLAY,AF.ACCTNO ||': '|| TYP.TYPENAME EN_DISPLAY, AF.ACCTNO ||': '|| TYP.TYPENAME DESCRIPTION, " _
                                & " CF.ADDRESS,CF.FULLNAME FROM CFMAST CF,AFMAST AF,AFTYPE TYP WHERE CF.CUSTID = AF.CUSTID AND AF.ACTYPE=TYP.ACTYPE AND CF.CUSTODYCD = '" & v_strCustodycd & "'"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL, , , , , , , , gc_CommandText)
                v_ws.Message(v_strObjMsg)

                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                v_strTEXT = String.Empty

                For i = 0 To v_nodeList.Count - 1
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = Trim(.InnerText.ToString)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)

                                Case "FULLNAME"
                                    mv_strFULLNAME = v_strValue
                                Case "ADDRESS"
                                    mv_strADDRESS = v_strValue

                            End Select
                        End With
                    Next
                Next

                mv_strLastCustodyCD = v_strCustodycd
                txtFULLNAME.Text = mv_strFULLNAME
                txtADDRESS.Text = mv_strADDRESS
                FillComboEx(v_strObjMsg, cbSAFACCTNO, "", Me.UserLanguage)
                FillComboEx(v_strObjMsg, cbRAFACCTNO, "", Me.UserLanguage)

                If (v_nodeList.Count = 0) Then
                    txtFULLNAME.Text = String.Empty
                    txtADDRESS.Text = String.Empty
                End If




            End If
            If Not (cbSAFACCTNO.SelectedValue Is Nothing) Then
                Me.AFACCTNO = cbSAFACCTNO.SelectedValue.ToString
            Else
                Me.AFACCTNO = ""
            End If
            OnSearch(gc_IsNotLocalMsg, OBJNAME_CA_CAMAST)

        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Information, Me.Text)
        Finally
            'v_ws.Dispose()
        End Try
    End Sub


    Protected Sub LoadResourceLocal(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control

        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is Label Then
                CType(v_ctrl, Label).Text = mv_ResourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                LoadResourceLocal(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is TabControl Then
                CType(v_ctrl, TabControl).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                LoadResourceLocal(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Button Then
                CType(v_ctrl, Button).Text = mv_ResourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is CheckBox Then
                CType(v_ctrl, CheckBox).Text = mv_ResourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString(v_ctrl.Name)
            End If
        Next

    End Sub

    'Protected Function SetPaymentOrderList(ByRef v_strObjMsg As String, ByRef blnFlag As Boolean) As Long
    '    Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
    '    Dim v_strSQL, v_strClause As String
    '    Dim lngReturn As Long
    '    Try
    '        '0. TXDATE 
    '        '1. TXNUM  
    '        '2. AMT
    '        '3. BRID   
    '        '4. STATUS 
    '        '5. BANKID 
    '        '6. BANKNAME 
    '        '7. BANKACC 
    '        '8. BANKACCNAME
    '        '9. GLACCTNO
    '        Dim v_strSTATUS As String = "A"
    '        Dim v_dblAMT As Double = 0
    '        txtTXNUM.Text = GetTXNUM("POTXNUM")
    '        txtAMT.Text = FormatNumber(mv_dblTotalAmt, 0) 'FormatNumber(CalcTotalAmt(), 0)
    '        v_strClause = Me.BusDate & "|" & txtTXNUM.Text & "|" & v_dblAMT & "|" & Me.BranchId & "|" & v_strSTATUS & "|" & txtTXDATE.Text.Replace(".", "") & "|" & txtBANKNAME.Text & "|" & txtBANKACC.Text & "|" & txtBANKACCNAME.Text & "|" & txtGLACCTNO.Text
    '        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, ObjectName, gc_ActionAdhoc, , v_strClause, "SetPaymentOrderList", gc_AutoIdUsed)
    '        blnFlag = True
    '        lngReturn = v_ws.Message(v_strObjMsg)
    '        Return lngReturn

    '    Catch ex As Exception
    '        Return -1
    '    End Try
    'End Function

    'Protected Function OnLocalSearch(ByVal page As Double) As Int32
    '    Dim i, j As Integer
    '    Dim v_xColumn As Xceed.Grid.Column, v_strFLDNAME, Value, pv_strModule As String
    '    Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
    '    Dim strRow, vd As String
    '    Dim rownumber, v_intFrom, v_intTo As Int32
    '    Try
    '        txtADVAMT.Text = 0
    '        txtADVFEEAMT.Text = 0
    '        txtPOOLREMAIN.Text = 0

    '        For i = 0 To lstCondition.Items.Count - 1
    '            If lstCondition.GetItemChecked(i) Then
    '                mv_strSearchFilter &= " AND " & hFilter(lstCondition.Items(i).ToString())
    '            End If
    '        Next i

    '        strRow = "SELECT * FROM VW_ADSCHD_INFO WHERE ADTYPE = '" & cboRRTYPE.SelectedValue & "'"
    '        strRow &= mv_strSearchFilter

    '        v_intTo = page * mv_rowpage
    '        v_intFrom = v_intTo + 1 - mv_rowpage

    '        strRow = "SELECT * FROM ( SELECT T1.*,ROWNUM RN FROM(" & strRow & ")T1) WHERE RN BETWEEN " & v_intFrom & " AND " & v_intTo

    '        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId , IsLocalSearch, gc_MsgTypeObj, pv_strModule, _
    '                                            gc_ActionInquiry, strRow)
    '        v_ws.Message(v_strObjMsg)
    '        Me.FULLDATA = v_strObjMsg
    '        'Fill data into search grid
    '        FillDataGrid(SearchGrid, v_strObjMsg, "AppCore.frmSearch-" & UserLanguage, mv_strTableName, , v_intFrom, v_intTo, CountRow())
    '        'Format data in search grid
    '        For Each v_xColumn In SearchGrid.Columns
    '            v_strFLDNAME = UCase(Trim(v_xColumn.FieldName))
    '            For i = 0 To mv_arrSrFieldSrch.GetLength(0) - 1
    '                If UCase(mv_arrSrFieldSrch(i)) = v_strFLDNAME Then
    '                    v_xColumn.FormatSpecifier = mv_arrSrFieldFormat(i)
    '                    Exit For
    '                End If
    '            Next
    '        Next

    '        ''Update mouse pointer
    '        Cursor.Current = Cursors.Default
    '        SetFocusGrid(Value)
    '        Me.btnNEXT.Enabled = True
    '        Me.btnBACK.Enabled = True

    '    Catch ex As Exception
    '        LogError.Write("Error source: " & ex.Source & vbNewLine _
    '                     & "Error code: System error!" & vbNewLine _
    '                     & "Error message: " & ex.Message, EventLogEntryType.Error)
    '        MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
    '    End Try
    'End Function

    'Protected Overrides Function OnSearch(Optional ByVal pv_strIsLocal As String = "", Optional ByVal pv_strModule As String = "", Optional ByVal page As Int32 = 1) As Int32
    '    Dim i, j As Integer
    '    Dim v_xColumn As Xceed.Grid.Column, v_strFLDNAME, Value As String
    '    Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
    '    Dim strRow, vd As String
    '    Dim v_strADTYPE As String
    '    Dim rownumber, v_intFrom, v_intTo As Int32
    '    Try
    '        'Update mouse pointer
    '        If Not SearchGrid.DataRows.Count = 0 Then
    '            If Not SearchGrid.CurrentRow Is Nothing Then
    '                If KeyColumn Is Nothing Then
    '                Else
    '                    If checkTypeGridCurrentRow(SearchGrid.CurrentRow) Then
    '                        Value = Trim(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells(KeyColumn).Value)
    '                    End If
    '                End If
    '            End If
    '        End If

    '        Cursor.Current = Cursors.WaitCursor

    '        'Update status bar
    '        'ssbPanelStatus.Text = mv_ResourceManager.GetString("frmSearch.Searching")
    '        'ssbPanelExecFlag.Text = String.Empty
    '        mv_strSearchFilter = String.Empty

    '        If CommandType = gc_CommandProcedure Then 'Command Procedure
    '            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId , IsLocalSearch, gc_MsgTypeObj, pv_strModule, _
    '                                              gc_ActionInquiry, StoreName, StoreParam, , , , , , , CommandType)
    '            v_ws.Message(v_strObjMsg)
    '            Me.FULLDATA = v_strObjMsg
    '            'Fill data into search grid
    '            FillDataGrid(SearchGrid, v_strObjMsg, c_SearchResourceManager & UserLanguage, mv_strTableName, , v_intFrom, v_intTo)
    '            'Format data in search grid
    '            For Each v_xColumn In SearchGrid.Columns
    '                v_strFLDNAME = UCase(Trim(v_xColumn.FieldName))
    '                For i = 0 To mv_arrSrFieldSrch.GetLength(0) - 1
    '                    If UCase(mv_arrSrFieldSrch(i)) = v_strFLDNAME Then
    '                        v_xColumn.FormatSpecifier = mv_arrSrFieldFormat(i)
    '                        Exit For
    '                    End If
    '                Next
    '            Next

    '        Else 'Command text. Only for defaul condition
    '            If ModuleCode & "." & mv_strObjName = OBJNAME_CA_CAMAST And Me.CMDMenu <> "" Then
    '                mv_strSearchFilter = " AND TYPEID = '" & Strings.Right(Me.CMDMenu, 3) & "'"
    '            End If

    '            'If InStr(mv_CONST_SEARCHCODE_ADVANCED, mv_strTableName) > 0 Then
    '            '    v_strADTYPE = cboRRTYPE.SelectedValue
    '            '    mv_strSearchFilter = " AND ADTYPE<>'" & v_strADTYPE & "'"
    '            'End If

    '            For i = 0 To lstCondition.Items.Count - 1
    '                If lstCondition.GetItemChecked(i) Then
    '                    mv_strSearchFilter &= " AND " & hFilter(lstCondition.Items(i).ToString())
    '                End If
    '            Next i

    '            'Filter by Careby - TungNT modified
    '            If mv_isCareBy = True Then
    '                If ModuleCode & "." & mv_strObjName = OBJNAME_CF_AFMAST Then
    '                    mv_strSearchFilter &= " AND INSTR('" & mv_strGroupCareBy & "',CAREBYID)>0 "
    '                ElseIf (ModuleCode & "." & mv_strObjName = OBJNAME_OD_ODCANCEL) Or ModuleCode & "." & mv_strObjName = "OD.ODMASTVIEW" Or ModuleCode & "." & mv_strObjName = "OD.ODMAST" Then
    '                    mv_strSearchFilter &= " AND REPLACE(CUSTODYCD,'.') IN (SELECT CUSTODYCD FROM CFMAST WHERE INSTR('" & mv_strGroupCareBy & "',CAREBY)>0) "
    '                ElseIf (ModuleCode & "." & mv_strObjName = "OD.ODCTCIVIEW") Then
    '                    mv_strSearchFilter &= " AND REPLACE(CUSTID,'.') IN (SELECT CUSTID FROM CFMAST WHERE INSTR('" & mv_strGroupCareBy & "',CAREBY)>0) "
    '                End If
    '            End If
    '            'End Modified

    '            mv_strSearchFilter = Mid(mv_strSearchFilter, 5)

    '            If (pv_strIsLocal <> "") And (pv_strModule <> "") Then
    '                v_intTo = page * mv_rowpage
    '                v_intFrom = v_intTo + 1 - mv_rowpage

    '                If (mv_strSrOderByCmd <> "") And (mv_strSearchFilter <> "") Then
    '                    mv_strSearchFilter &= "ORDER BY " & mv_strSrOderByCmd
    '                End If

    '                If mv_strSearchFilter = "" Then
    '                    If mv_strSrOderByCmd <> "" Then
    '                        mv_strSearchFilter = " 0=0 ORDER BY " & mv_strSrOderByCmd
    '                    Else
    '                        mv_strSearchFilter = " 0 = 0 "
    '                    End If
    '                    If Me.chkALL.Checked = True Then
    '                        strRow = "SELECT * FROM ( SELECT T1.*,ROWNUM RN FROM(" & mv_strCmdSql & " AND " & mv_strSearchFilter & ")T1)" ' WHERE RN BETWEEN " & v_intFrom & " AND " & v_intTo
    '                    Else
    '                        strRow = "SELECT * FROM ( SELECT T1.*,ROWNUM RN FROM(" & mv_strCmdSql & " AND " & mv_strSearchFilter & ")T1) WHERE RN BETWEEN " & v_intFrom & " AND " & v_intTo
    '                    End If
    '                    mv_strCmdSqlTemp = mv_strCmdSql & " AND " & mv_strSearchFilter
    '                Else
    '                    If Me.chkALL.Checked = True Then
    '                        strRow = "SELECT * FROM ( SELECT T1.*,ROWNUM RN FROM(SELECT * FROM (" & mv_strCmdSql & ") T WHERE  " & mv_strSearchFilter & ")T1)" '  WHERE RN BETWEEN " & v_intFrom & " AND " & v_intTo
    '                    Else
    '                        strRow = "SELECT * FROM ( SELECT T1.*,ROWNUM RN FROM(SELECT * FROM (" & mv_strCmdSql & ") T WHERE  " & mv_strSearchFilter & ")T1)  WHERE RN BETWEEN " & v_intFrom & " AND " & v_intTo
    '                    End If

    '                    mv_strCmdSqlTemp = "SELECT * FROM (" & mv_strCmdSql & ") T WHERE  " & mv_strSearchFilter
    '                End If
    '                If SearchByTransact = True Then
    '                    strRow = strRow.Replace("<$BRID>", HO_BRID)
    '                Else
    '                    strRow = strRow.Replace("<$BRID>", Me.BranchId)
    '                End If
    '                'TheNN sua
    '                strRow = strRow.Replace("<$HO_BRID>", HO_BRID)
    '                strRow = strRow.Replace("<$BUSDATE>", Me.BusDate)
    '                strRow = strRow.Replace("<$AFACCTNO>", Me.AFACCTNO)
    '                strRow = strRow.Replace("<$CUSTID>", Me.CUSTID)
    '                strRow = strRow.Replace("<@KEYVALUE>", LinkValue)
    '                strRow = strRow.Replace("<$TELLERID>", Me.TellerId)

    '                If InStr(mv_CONST_SEARCHCODE_ADVANCED, mv_strTableName) > 0 Then
    '                    v_strADTYPE = cboRRTYPE.SelectedValue
    '                    strRow = strRow.Replace("<$ADTYPE>", v_strADTYPE)
    '                End If

    '                'Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId , pv_strIsLocal, gc_MsgTypeObj, pv_strModule, _
    '                '                                    gc_ActionInquiry, strRow)
    '                'VanNT
    '                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId , IsLocalSearch, gc_MsgTypeObj, pv_strModule, _
    '                                                    gc_ActionInquiry, strRow)
    '                v_ws.Message(v_strObjMsg)
    '                Me.FULLDATA = v_strObjMsg
    '                'Fill data into search grid
    '                FillDataGrid(SearchGrid, v_strObjMsg, c_SearchResourceManager & UserLanguage, mv_strTableName, , v_intFrom, v_intTo, CountRow())
    '                'Format data in search grid
    '                For Each v_xColumn In SearchGrid.Columns
    '                    v_strFLDNAME = UCase(Trim(v_xColumn.FieldName))
    '                    For i = 0 To mv_arrSrFieldSrch.GetLength(0) - 1
    '                        If UCase(mv_arrSrFieldSrch(i)) = v_strFLDNAME Then
    '                            v_xColumn.FormatSpecifier = mv_arrSrFieldFormat(i)
    '                            Exit For
    '                        End If
    '                    Next
    '                Next
    '            End If
    '        End If


    '        'ssbPanelStatus.Text = String.Empty
    '        'Update mouse pointer
    '        Cursor.Current = Cursors.Default
    '        SetFocusGrid(Value)
    '        Me.btnNEXT.Enabled = True
    '        Me.btnBACK.Enabled = True
    '    Catch ex As Exception
    '        LogError.Write("Error source: " & ex.Source & vbNewLine _
    '                     & "Error code: System error!" & vbNewLine _
    '                     & "Error message: " & ex.Message, EventLogEntryType.Error)
    '        MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
    '    End Try
    'End Function

    Protected Overrides Function OnExecute(ByRef v_strObjMsg As String, ByVal pv_intRow As Integer, ByRef blnFlag As Boolean) As Integer
        If mv_strTableName = mv_CONST_SEARCHCODE_2248 Or mv_strTableName = mv_CONST_SEARCHCODE_8879 Then
            SendSecurities(v_strObjMsg, pv_intRow, blnFlag)
        ElseIf mv_strTableName = mv_CONST_SEARCHCODE_3331 Then
            SendInternalCA(v_strObjMsg, pv_intRow, blnFlag)
        End If
    End Function

    Protected Function SendSecurities(ByRef v_strObjMsg As String, ByVal pv_intRow As Integer, ByRef blnFlag As Boolean) As Integer
        Dim v_strSQL, v_strClause As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode
        Dim v_strValue, v_strFLDNAME, v_strFLDCD, v_strFLDCODE, v_strTLTXCD, v_strMODCODE, v_strFLDDEFVAL, v_strFIELDTYPE As String, i, j, v_intRow As Integer
        Dim v_strPostingDate As String
        Dim lngReturn As Long

        If Len(Trim(Me.txtTXDATE.Text.Replace("/", ""))) = 0 Or String.Compare(Me.txtTXDATE.Text, "") = 0 Then
            MsgBox(mv_ResourceManager.GetString("TXDateNotNull"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
            TabMain.SelectTab(TabTranferInfo)
            Me.txtTXDATE.Focus()
            Exit Function
        End If
        'Cac truong hop xu ly dac biet khi thuc hien Execute.
        'Xu ly xong thoat ra.
        'Khi execute goi den giao dich thi thuc hien o day
        'Căn cứ vào SEARCHCODE để lấy mã giao dịch (TLTXCD) và nạp các giá trị mặc định cho trư?ng giao dịch FLDCD.
        v_strSQL = "SELECT APPMODULES.MODCODE, SEARCH.TLTXCD, SEARCHFLD.FIELDCODE, SEARCHFLD.FLDCD,SEARCHFLD.FIELDTYPE  FROM APPMODULES, SEARCH, SEARCHFLD " & ControlChars.CrLf _
            & "WHERE SEARCH.SEARCHCODE=SEARCHFLD.SEARCHCODE AND APPMODULES.TXCODE=SUBSTR(SEARCH.TLTXCD,1,2) AND LENGTH(SEARCH.TLTXCD)=4 AND SEARCH.SEARCHCODE='" & mv_strTableName & "'"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLTX, gc_ActionInquiry, v_strSQL)
        v_ws.Message(v_strObjMsg)
        v_xmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
        v_strFLDDEFVAL = String.Empty
        v_strMODCODE = String.Empty
        v_strTLTXCD = String.Empty


        If Not Me.chkExeAll.Checked Then
            If Not v_nodeList.Count = 0 Then
                'N?u dây là màn hình tra c?u cho phép th?c hi?n giao d?ch k? ti?p
                If Not SearchGrid Is Nothing Then
                    If SearchGrid.DataRows.Count > 0 Then
                        For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                            If Not SearchGrid.DataRows(v_intRow) Is Nothing Then
                                If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then

                                    'mv_dblTotalAmt = mv_dblTotalAmt + CDbl(SearchGrid.DataRows(v_intRow).Cells("DEPOAMT").Value)
                                    'txtAMT.Text = FormatNumber(mv_dblTotalAmt, 0)

                                    'Có duoc danh dau chon
                                    For i = 0 To v_nodeList.Count - 1
                                        v_strFLDCODE = String.Empty
                                        v_strFLDCD = String.Empty
                                        For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                                            With v_nodeList.Item(i).ChildNodes(j)
                                                v_strValue = .InnerText.ToString
                                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                                Select Case Trim(v_strFLDNAME)
                                                    Case "MODCODE"
                                                        v_strMODCODE = Trim(v_strValue)
                                                    Case "TLTXCD"
                                                        v_strTLTXCD = Trim(v_strValue)
                                                    Case "FIELDCODE"
                                                        v_strFLDCODE = Trim(v_strValue)
                                                    Case "FLDCD"
                                                        v_strFLDCD = Trim(v_strValue)
                                                    Case "FIELDTYPE"
                                                        v_strFIELDTYPE = Trim(v_strValue)
                                                End Select
                                            End With
                                        Next

                                        If v_strFLDCD <> "" Then

                                            If String.Compare(v_strFLDCD, "PD") = 0 Then
                                                If TypeOf (SearchGrid.CurrentRow) Is Xceed.Grid.DataRow Then
                                                    'Neu la truong posting date
                                                    v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value
                                                    v_strValue = Replace(v_strValue, ".", "")
                                                    v_strPostingDate = v_strValue
                                                Else
                                                    v_strPostingDate = String.Empty
                                                End If
                                            Else
                                                If TypeOf (SearchGrid.CurrentRow) Is Xceed.Grid.DataRow Then

                                                    v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value

                                                    If v_strFIELDTYPE = "C" And (v_strFLDCODE <> "DESC" Or v_strFLDCODE <> "DESCRIPTION") Then
                                                        v_strValue = Replace(v_strValue, ".", "")
                                                    End If
                                                    v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & v_strFLDCD & "." & v_strValue & "]"
                                                Else
                                                    v_strFLDDEFVAL = String.Empty
                                                End If

                                            End If
                                        End If
                                    Next

                                    ''ADTXNUM : So bang ke
                                    'v_strFLDCD = "99"
                                    'v_strValue = txtADTXNUM.Text
                                    'v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & v_strFLDCD & "." & v_strValue & "]"

                                    'Nap va thuc hien giao dich
                                    v_strPostingDate = Me.txtTXDATE.Text
                                    SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = String.Empty
                                    SetTransactForm()
                                    If v_strMODCODE <> "" And v_strTLTXCD <> "" Then
                                        mv_frmTransactScreen = New frmTransact(mv_strLanguage)
                                        Try
                                            mv_frmTransactScreen.ObjectName = v_strTLTXCD
                                        Catch ex As Exception
                                            MsgBox(ex.Message)
                                        End Try
                                        mv_frmTransactScreen.ModuleCode = v_strMODCODE
                                        mv_frmTransactScreen.LocalObject = gc_IsNotLocalMsg
                                        mv_frmTransactScreen.BranchId = Me.BranchId
                                        mv_frmTransactScreen.TellerId = Me.TellerId
                                        mv_frmTransactScreen.IpAddress = Me.IpAddress
                                        mv_frmTransactScreen.WsName = Me.WsName
                                        mv_frmTransactScreen.BusDate = Me.BusDate

                                        If IIf(IsDBNull(Len(v_strPostingDate)), 0, Len(v_strPostingDate)) > 0 Then
                                            mv_frmTransactScreen.PostingDate = v_strPostingDate
                                        End If

                                        mv_frmTransactScreen.DefaultValue = v_strFLDDEFVAL
                                        mv_frmTransactScreen.AutoClosedWhenOK = True
                                        'mv_frmTransactScreen.AutoSubmitWhenExecute = True
                                        mv_frmTransactScreen.ShowDialog()
                                        If mv_frmTransactScreen.CancelClick Then
                                            OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                                            Exit Function
                                            blnFlag = False
                                        End If
                                        blnFlag = True
                                        'mv_frmTransactScreen.OnSubmit()
                                        mv_frmTransactScreen.Dispose()
                                        'Reset lai gia tri
                                        v_strFLDDEFVAL = String.Empty
                                    End If
                                End If
                            End If
                        Next
                    End If
                    'Refresh lai màn hình
                    'OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)                 
                End If
            End If
        Else
            If Not v_nodeList.Count = 0 Then
                'N?u dây là màn hình tra c?u cho phép th?c hi?n giao d?ch k? ti?p
                If Not SearchGrid Is Nothing Then
                    If SearchGrid.DataRows.Count > 0 Then
                        For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                            If Not SearchGrid.DataRows(v_intRow) Is Nothing Then
                                If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then

                                    'mv_dblTotalAmt = mv_dblTotalAmt + CDbl(SearchGrid.DataRows(v_intRow).Cells("DEPOAMT").Value)
                                    'txtAMT.Text = FormatNumber(mv_dblTotalAmt, 0)

                                    'Có duoc danh dau chon
                                    For i = 0 To v_nodeList.Count - 1
                                        v_strFLDCODE = String.Empty
                                        v_strFLDCD = String.Empty
                                        For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                                            With v_nodeList.Item(i).ChildNodes(j)
                                                v_strValue = .InnerText.ToString
                                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                                Select Case Trim(v_strFLDNAME)
                                                    Case "MODCODE"
                                                        v_strMODCODE = Trim(v_strValue)
                                                    Case "TLTXCD"
                                                        v_strTLTXCD = Trim(v_strValue)
                                                    Case "FIELDCODE"
                                                        v_strFLDCODE = Trim(v_strValue)
                                                    Case "FLDCD"
                                                        v_strFLDCD = Trim(v_strValue)
                                                    Case "FIELDTYPE"
                                                        v_strFIELDTYPE = Trim(v_strValue)
                                                End Select
                                            End With
                                        Next

                                        If v_strFLDCD <> "" Then

                                            If String.Compare(v_strFLDCD, "PD") = 0 Then
                                                If TypeOf (SearchGrid.CurrentRow) Is Xceed.Grid.DataRow Then
                                                    'Neu la truong posting date
                                                    v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value
                                                    v_strValue = Replace(v_strValue, ".", "")
                                                    v_strPostingDate = v_strValue
                                                Else
                                                    v_strPostingDate = String.Empty
                                                End If
                                            Else
                                                If TypeOf (SearchGrid.CurrentRow) Is Xceed.Grid.DataRow Then

                                                    v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value

                                                    If v_strFIELDTYPE = "C" And (v_strFLDCODE <> "DESC" Or v_strFLDCODE <> "DESCRIPTION") Then
                                                        v_strValue = Replace(v_strValue, ".", "")
                                                    End If
                                                    v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & v_strFLDCD & "." & v_strValue & "]"
                                                Else
                                                    v_strFLDDEFVAL = String.Empty
                                                End If

                                            End If
                                        End If
                                    Next

                                    ''ADTXNUM : So bang ke
                                    'v_strFLDCD = "99"
                                    'v_strValue = txtADTXNUM.Text
                                    'v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & v_strFLDCD & "." & v_strValue & "]"

                                    'Nap va thuc hien giao dich
                                    v_strPostingDate = Me.txtTXDATE.Text
                                    SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = String.Empty
                                    SetTransactForm()
                                    If v_strMODCODE <> "" And v_strTLTXCD <> "" Then
                                        mv_frmTransactScreen = New frmTransact(mv_strLanguage)
                                        Try
                                            mv_frmTransactScreen.ObjectName = v_strTLTXCD
                                        Catch ex As Exception
                                            MsgBox(ex.Message)
                                        End Try
                                        mv_frmTransactScreen.ModuleCode = v_strMODCODE
                                        mv_frmTransactScreen.LocalObject = gc_IsNotLocalMsg
                                        mv_frmTransactScreen.BranchId = Me.BranchId
                                        mv_frmTransactScreen.TellerId = Me.TellerId
                                        mv_frmTransactScreen.IpAddress = Me.IpAddress
                                        mv_frmTransactScreen.WsName = Me.WsName
                                        mv_frmTransactScreen.BusDate = Me.BusDate

                                        If IIf(IsDBNull(Len(v_strPostingDate)), 0, Len(v_strPostingDate)) > 0 Then
                                            mv_frmTransactScreen.PostingDate = v_strPostingDate
                                        End If
                                        mv_frmTransactScreen.DefaultValue = v_strFLDDEFVAL
                                        mv_frmTransactScreen.AutoClosedWhenOK = True
                                        mv_frmTransactScreen.AutoSubmitWhenExecute = True
                                        mv_frmTransactScreen.ShowDialog()
                                        'If mv_frmTransactScreen.CancelClick Then
                                        '    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                                        '    Exit Function
                                        '    blnFlag = False
                                        'End If
                                        blnFlag = True
                                        'mv_frmTransactScreen.OnSubmit()
                                        mv_frmTransactScreen.Dispose()
                                        'Reset lai gia tri
                                        v_strFLDDEFVAL = String.Empty
                                    End If
                                End If
                            End If
                        Next
                    End If
                    'Refresh lai màn hình
                    'OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                End If
            End If
        End If

    End Function
    Protected Function SendInternalCA(ByRef v_strObjMsg As String, ByVal pv_intRow As Integer, ByRef blnFlag As Boolean) As Integer
        Dim v_strSQL, v_strClause As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode
        Dim v_strValue, v_strFLDNAME, v_strFLDCD, v_strFLDCODE, v_strTLTXCD, v_strMODCODE, v_strFLDDEFVAL, v_strFIELDTYPE As String, i, j, v_intRow As Integer
        Dim v_strPostingDate As String
        Dim lngReturn As Long

        If Me.cbRAFACCTNO.SelectedValue Is Nothing Then
            MsgBox(mv_ResourceManager.GetString("RAFACCTNO_NOT_NULL"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
            TabMain.SelectTab(TabTranferInfo)
            Me.cbRAFACCTNO.Focus()
            Exit Function
        End If
        If Me.cbSAFACCTNO.SelectedValue Is Nothing Then
            MsgBox(mv_ResourceManager.GetString("SRAFACCTNO_NOT_NULL"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
            TabMain.SelectTab(TabTranferInfo)
            Me.cbSAFACCTNO.Focus()
            Exit Function
        End If
        'Cac truong hop xu ly dac biet khi thuc hien Execute.
        'Xu ly xong thoat ra.
        'Khi execute goi den giao dich thi thuc hien o day
        'Căn cứ vào SEARCHCODE để lấy mã giao dịch (TLTXCD) và nạp các giá trị mặc định cho trư?ng giao dịch FLDCD.
        v_strSQL = "SELECT APPMODULES.MODCODE, SEARCH.TLTXCD, SEARCHFLD.FIELDCODE, SEARCHFLD.FLDCD,SEARCHFLD.FIELDTYPE  FROM APPMODULES, SEARCH, SEARCHFLD " & ControlChars.CrLf _
            & "WHERE SEARCH.SEARCHCODE=SEARCHFLD.SEARCHCODE AND APPMODULES.TXCODE=SUBSTR(SEARCH.TLTXCD,1,2) AND LENGTH(SEARCH.TLTXCD)=4 AND SEARCH.SEARCHCODE='" & mv_strTableName & "'"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLTX, gc_ActionInquiry, v_strSQL)
        v_ws.Message(v_strObjMsg)
        v_xmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
        v_strFLDDEFVAL = String.Empty
        v_strMODCODE = String.Empty
        v_strTLTXCD = String.Empty


        If Not Me.chkExeAll.Checked Then
            If Not v_nodeList.Count = 0 Then
                'N?u dây là màn hình tra c?u cho phép th?c hi?n giao d?ch k? ti?p
                If Not SearchGrid Is Nothing Then
                    If SearchGrid.DataRows.Count > 0 Then
                        For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                            If Not SearchGrid.DataRows(v_intRow) Is Nothing Then
                                If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then

                                    'mv_dblTotalAmt = mv_dblTotalAmt + CDbl(SearchGrid.DataRows(v_intRow).Cells("DEPOAMT").Value)
                                    'txtAMT.Text = FormatNumber(mv_dblTotalAmt, 0)

                                    'Có duoc danh dau chon
                                    For i = 0 To v_nodeList.Count - 1
                                        v_strFLDCODE = String.Empty
                                        v_strFLDCD = String.Empty
                                        For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                                            With v_nodeList.Item(i).ChildNodes(j)
                                                v_strValue = .InnerText.ToString
                                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                                Select Case Trim(v_strFLDNAME)
                                                    Case "MODCODE"
                                                        v_strMODCODE = Trim(v_strValue)
                                                    Case "TLTXCD"
                                                        v_strTLTXCD = Trim(v_strValue)
                                                    Case "FIELDCODE"
                                                        v_strFLDCODE = Trim(v_strValue)
                                                    Case "FLDCD"
                                                        v_strFLDCD = Trim(v_strValue)
                                                    Case "FIELDTYPE"
                                                        v_strFIELDTYPE = Trim(v_strValue)
                                                End Select
                                            End With
                                        Next

                                        If v_strFLDCD <> "" Then

                                            If String.Compare(v_strFLDCD, "PD") = 0 Then
                                                If TypeOf (SearchGrid.CurrentRow) Is Xceed.Grid.DataRow Then
                                                    'Neu la truong posting date
                                                    v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value
                                                    v_strValue = Replace(v_strValue, ".", "")
                                                    v_strPostingDate = v_strValue
                                                Else
                                                    v_strPostingDate = String.Empty
                                                End If
                                            Else
                                                If TypeOf (SearchGrid.CurrentRow) Is Xceed.Grid.DataRow Then
                                                    'Neu la truong binh thuong 
                                                    'Lay GL Account đưa vào vao dịch
                                                    If String.Compare(v_strFLDCD, "04") = 0 Then 'RAFACCTNO
                                                        v_strValue = cbRAFACCTNO.SelectedValue.ToString
                                                        v_strValue = Replace(v_strValue, ".", "")

                                                    Else
                                                        v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value
                                                    End If

                                                    If v_strFIELDTYPE = "C" And (v_strFLDCODE <> "DESC" Or v_strFLDCODE <> "DESCRIPTION") Then
                                                        v_strValue = Replace(v_strValue, ".", "")
                                                    End If
                                                    v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & v_strFLDCD & "." & v_strValue & "]"
                                                Else
                                                    v_strFLDDEFVAL = String.Empty
                                                End If

                                            End If
                                        End If
                                    Next

                                    ''ADTXNUM : So bang ke
                                    'v_strFLDCD = "99"
                                    'v_strValue = txtADTXNUM.Text
                                    'v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & v_strFLDCD & "." & v_strValue & "]"

                                    'Nap va thuc hien giao dich

                                    SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = String.Empty
                                    SetTransactForm()
                                    If v_strMODCODE <> "" And v_strTLTXCD <> "" Then
                                        mv_frmTransactScreen = New frmTransact(mv_strLanguage)
                                        Try
                                            mv_frmTransactScreen.ObjectName = v_strTLTXCD
                                        Catch ex As Exception
                                            MsgBox(ex.Message)
                                        End Try
                                        mv_frmTransactScreen.ModuleCode = v_strMODCODE
                                        mv_frmTransactScreen.LocalObject = gc_IsNotLocalMsg
                                        mv_frmTransactScreen.BranchId = Me.BranchId
                                        mv_frmTransactScreen.TellerId = Me.TellerId
                                        mv_frmTransactScreen.IpAddress = Me.IpAddress
                                        mv_frmTransactScreen.WsName = Me.WsName
                                        mv_frmTransactScreen.BusDate = Me.BusDate

                                        If IIf(IsDBNull(Len(v_strPostingDate)), 0, Len(v_strPostingDate)) > 0 Then
                                            mv_frmTransactScreen.PostingDate = v_strPostingDate
                                        End If

                                        mv_frmTransactScreen.DefaultValue = v_strFLDDEFVAL
                                        mv_frmTransactScreen.AutoClosedWhenOK = True
                                        'mv_frmTransactScreen.AutoSubmitWhenExecute = True
                                        mv_frmTransactScreen.ShowDialog()
                                        If mv_frmTransactScreen.CancelClick Then
                                            OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                                            Exit Function
                                            blnFlag = False
                                        End If
                                        blnFlag = True
                                        'mv_frmTransactScreen.OnSubmit()
                                        mv_frmTransactScreen.Dispose()
                                        'Reset lai gia tri
                                        v_strFLDDEFVAL = String.Empty
                                    End If
                                End If
                            End If
                        Next
                    End If
                    'Refresh lai màn hình
                    'OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)                 
                End If
            End If
        Else
            If Not v_nodeList.Count = 0 Then
                'N?u dây là màn hình tra c?u cho phép th?c hi?n giao d?ch k? ti?p
                If Not SearchGrid Is Nothing Then
                    If SearchGrid.DataRows.Count > 0 Then
                        For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                            If Not SearchGrid.DataRows(v_intRow) Is Nothing Then
                                If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then

                                    'mv_dblTotalAmt = mv_dblTotalAmt + CDbl(SearchGrid.DataRows(v_intRow).Cells("DEPOAMT").Value)
                                    'txtAMT.Text = FormatNumber(mv_dblTotalAmt, 0)

                                    'Có duoc danh dau chon
                                    For i = 0 To v_nodeList.Count - 1
                                        v_strFLDCODE = String.Empty
                                        v_strFLDCD = String.Empty
                                        For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                                            With v_nodeList.Item(i).ChildNodes(j)
                                                v_strValue = .InnerText.ToString
                                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                                Select Case Trim(v_strFLDNAME)
                                                    Case "MODCODE"
                                                        v_strMODCODE = Trim(v_strValue)
                                                    Case "TLTXCD"
                                                        v_strTLTXCD = Trim(v_strValue)
                                                    Case "FIELDCODE"
                                                        v_strFLDCODE = Trim(v_strValue)
                                                    Case "FLDCD"
                                                        v_strFLDCD = Trim(v_strValue)
                                                    Case "FIELDTYPE"
                                                        v_strFIELDTYPE = Trim(v_strValue)
                                                End Select
                                            End With
                                        Next

                                        If v_strFLDCD <> "" Then

                                            If String.Compare(v_strFLDCD, "PD") = 0 Then
                                                If TypeOf (SearchGrid.CurrentRow) Is Xceed.Grid.DataRow Then
                                                    'Neu la truong posting date
                                                    v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value
                                                    v_strValue = Replace(v_strValue, ".", "")
                                                    v_strPostingDate = v_strValue
                                                Else
                                                    v_strPostingDate = String.Empty
                                                End If
                                            Else
                                                If TypeOf (SearchGrid.CurrentRow) Is Xceed.Grid.DataRow Then
                                                    'Neu la truong binh thuong 
                                                    'Lay GL Account đưa vào vao dịch
                                                    If String.Compare(v_strFLDCD, "04") = 0 Then 'RAFACCTNO
                                                        v_strValue = cbRAFACCTNO.SelectedValue.ToString
                                                        v_strValue = Replace(v_strValue, ".", "")


                                                    Else

                                                        v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value

                                                        'v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value
                                                    End If


                                                    'v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value
                                                    If v_strFIELDTYPE = "C" And (v_strFLDCODE <> "DESC" And v_strFLDCODE <> "DESCRIPTION") Then
                                                        v_strValue = Replace(v_strValue, ".", "")
                                                    End If
                                                    v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & v_strFLDCD & "." & v_strValue & "]"
                                                Else
                                                    v_strFLDDEFVAL = String.Empty
                                                End If

                                            End If
                                        End If
                                    Next

                                    ''ADTXNUM : So bang ke
                                    'v_strFLDCD = "99"
                                    'v_strValue = txtADTXNUM.Text
                                    'v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & v_strFLDCD & "." & v_strValue & "]"

                                    'Nap va thuc hien giao dich

                                    SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = String.Empty
                                    SetTransactForm()
                                    If v_strMODCODE <> "" And v_strTLTXCD <> "" Then
                                        mv_frmTransactScreen = New frmTransact(mv_strLanguage)
                                        Try
                                            mv_frmTransactScreen.ObjectName = v_strTLTXCD
                                        Catch ex As Exception
                                            MsgBox(ex.Message)
                                        End Try
                                        mv_frmTransactScreen.ModuleCode = v_strMODCODE
                                        mv_frmTransactScreen.LocalObject = gc_IsNotLocalMsg
                                        mv_frmTransactScreen.BranchId = Me.BranchId
                                        mv_frmTransactScreen.TellerId = Me.TellerId
                                        mv_frmTransactScreen.IpAddress = Me.IpAddress
                                        mv_frmTransactScreen.WsName = Me.WsName
                                        mv_frmTransactScreen.BusDate = Me.BusDate

                                        If IIf(IsDBNull(Len(v_strPostingDate)), 0, Len(v_strPostingDate)) > 0 Then
                                            mv_frmTransactScreen.PostingDate = v_strPostingDate
                                        End If
                                        mv_frmTransactScreen.DefaultValue = v_strFLDDEFVAL
                                        mv_frmTransactScreen.AutoClosedWhenOK = True
                                        mv_frmTransactScreen.AutoSubmitWhenExecute = True
                                        mv_frmTransactScreen.ShowDialog()
                                        'If mv_frmTransactScreen.CancelClick Then
                                        '    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                                        '    Exit Function
                                        '    blnFlag = False
                                        'End If
                                        blnFlag = True
                                        'mv_frmTransactScreen.OnSubmit()
                                        mv_frmTransactScreen.Dispose()
                                        'Reset lai gia tri
                                        v_strFLDDEFVAL = String.Empty
                                    End If
                                End If
                            End If
                        Next
                    End If
                    'Refresh lai màn hình
                    'OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                End If
            End If
        End If

    End Function

    Protected Function PaymentOrder(ByRef v_strObjMsg As String, ByVal pv_intRow As Integer, ByRef blnFlag As Boolean) As Integer
        Dim v_strSQL, v_strClause As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode
        Dim v_strValue, v_strFLDNAME, v_strFLDCD, v_strFLDCODE, v_strTLTXCD, v_strMODCODE, v_strFLDDEFVAL, v_strFIELDTYPE As String, i, j, v_intRow As Integer
        Dim v_strPostingDate As String
        Dim lngReturn As Long

        If Len(txtTXDATE.Text) = 0 Or String.Compare(txtTXDATE.Text, "") = 0 Then
            MsgBox(mv_ResourceManager.GetString("PleaseChooseDate"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
            TabMain.SelectTab(TabTranferInfo)
            txtTXDATE.Focus()
            Exit Function
        End If
        ' PhuongHT comment theo yeu cau BVS
        'If Len(txtGLACCTNO.Text) = 0 Or String.Compare(txtGLACCTNO.Text, "") = 0 Then
        '    MsgBox(mv_ResourceManager.GetString("GLAcctnoNotNull"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
        '    TabMain.SelectTab(TabTranferInfo)
        '    txtTXDATE.Focus()
        '    Exit Function
        'End If


        txtTXNUM.Text = GetTXNUM("POTXNUM")
        mv_dblTotalAmt = 0
        'Cac truong hop xu ly dac biet khi thuc hien Execute.
        'Xu ly xong thoat ra.
        'Khi execute goi den giao dich thi thuc hien o day
        'Căn cứ vào SEARCHCODE để lấy mã giao dịch (TLTXCD) và nạp các giá trị mặc định cho trư?ng giao dịch FLDCD.
        v_strSQL = "SELECT APPMODULES.MODCODE, SEARCH.TLTXCD, SEARCHFLD.FIELDCODE, SEARCHFLD.FLDCD,SEARCHFLD.FIELDTYPE  FROM APPMODULES, SEARCH, SEARCHFLD " & ControlChars.CrLf _
            & "WHERE SEARCH.SEARCHCODE=SEARCHFLD.SEARCHCODE AND APPMODULES.TXCODE=SUBSTR(SEARCH.TLTXCD,1,2) AND LENGTH(SEARCH.TLTXCD)=4 AND SEARCH.SEARCHCODE='" & mv_strTableName & "'"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLTX, gc_ActionInquiry, v_strSQL)
        v_ws.Message(v_strObjMsg)
        v_xmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
        v_strFLDDEFVAL = String.Empty
        v_strMODCODE = String.Empty
        v_strTLTXCD = String.Empty

        If Not Me.chkExeAll.Checked Then
            If Not v_nodeList.Count = 0 Then
                'N?u dây là màn hình tra c?u cho phép th?c hi?n giao d?ch k? ti?p
                If Not SearchGrid Is Nothing Then
                    If SearchGrid.DataRows.Count > 0 Then
                        For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                            If Not SearchGrid.DataRows(v_intRow) Is Nothing Then
                                If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then

                                    mv_dblTotalAmt = mv_dblTotalAmt + CDbl(SearchGrid.DataRows(v_intRow).Cells("AMT").Value)
                                    txtAMT.Text = FormatNumber(mv_dblTotalAmt, 0)

                                    'Có duoc danh dau chon
                                    For i = 0 To v_nodeList.Count - 1
                                        v_strFLDCODE = String.Empty
                                        v_strFLDCD = String.Empty
                                        For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                                            With v_nodeList.Item(i).ChildNodes(j)
                                                v_strValue = .InnerText.ToString
                                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                                Select Case Trim(v_strFLDNAME)
                                                    Case "MODCODE"
                                                        v_strMODCODE = Trim(v_strValue)
                                                    Case "TLTXCD"
                                                        v_strTLTXCD = Trim(v_strValue)
                                                    Case "FIELDCODE"
                                                        v_strFLDCODE = Trim(v_strValue)
                                                    Case "FLDCD"
                                                        v_strFLDCD = Trim(v_strValue)
                                                    Case "FIELDTYPE"
                                                        v_strFIELDTYPE = Trim(v_strValue)
                                                End Select
                                            End With
                                        Next

                                        If v_strFLDCD <> "" Then

                                            If String.Compare(v_strFLDCD, "PD") = 0 Then
                                                If TypeOf (SearchGrid.CurrentRow) Is Xceed.Grid.DataRow Then
                                                    'Neu la truong posting date
                                                    v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value
                                                    v_strValue = Replace(v_strValue, ".", "")
                                                    v_strPostingDate = v_strValue
                                                Else
                                                    v_strPostingDate = String.Empty
                                                End If
                                            Else
                                                If TypeOf (SearchGrid.CurrentRow) Is Xceed.Grid.DataRow Then
                                                    'Neu la truong binh thuong 
                                                    'Lay GL Account đưa vào vao dịch


                                                    If v_strFIELDTYPE = "C" And (v_strFLDCODE <> "DESC" Or v_strFLDCODE <> "DESCRIPTION") Then
                                                        v_strValue = Replace(v_strValue, ".", "")
                                                    End If
                                                    v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & v_strFLDCD & "." & v_strValue & "]"
                                                Else
                                                    v_strFLDDEFVAL = String.Empty
                                                End If

                                            End If
                                        End If
                                    Next

                                    'Nap va thuc hien giao dich
                                    SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = String.Empty
                                    SetTransactForm()
                                    If v_strMODCODE <> "" And v_strTLTXCD <> "" Then
                                        mv_frmTransactScreen = New frmTransact(mv_strLanguage)
                                        Try
                                            mv_frmTransactScreen.ObjectName = v_strTLTXCD
                                        Catch ex As Exception
                                            MsgBox(ex.Message)
                                        End Try
                                        mv_frmTransactScreen.ModuleCode = v_strMODCODE
                                        mv_frmTransactScreen.LocalObject = gc_IsNotLocalMsg
                                        mv_frmTransactScreen.BranchId = Me.BranchId
                                        mv_frmTransactScreen.TellerId = Me.TellerId
                                        mv_frmTransactScreen.IpAddress = Me.IpAddress
                                        mv_frmTransactScreen.WsName = Me.WsName
                                        mv_frmTransactScreen.BusDate = Me.BusDate

                                        If IIf(IsDBNull(Len(v_strPostingDate)), 0, Len(v_strPostingDate)) > 0 Then
                                            mv_frmTransactScreen.PostingDate = v_strPostingDate
                                        End If

                                        mv_frmTransactScreen.DefaultValue = v_strFLDDEFVAL
                                        mv_frmTransactScreen.AutoClosedWhenOK = True
                                        'mv_frmTransactScreen.AutoSubmitWhenExecute = True
                                        mv_frmTransactScreen.ShowDialog()
                                        If mv_frmTransactScreen.CancelClick Then
                                            OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                                            Exit Function
                                            blnFlag = False
                                        End If
                                        blnFlag = True
                                        'mv_frmTransactScreen.OnSubmit()
                                        mv_frmTransactScreen.Dispose()
                                        'Reset lai gia tri
                                        v_strFLDDEFVAL = String.Empty
                                    End If
                                End If
                            End If
                        Next
                    End If
                    'Refresh lai màn hình
                    'OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)                 
                End If
            End If
        Else
            If Not v_nodeList.Count = 0 Then
                'N?u dây là màn hình tra c?u cho phép th?c hi?n giao d?ch k? ti?p
                If Not SearchGrid Is Nothing Then
                    If SearchGrid.DataRows.Count > 0 Then
                        Dim intCuont As Integer = 0
                        For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                            If Not SearchGrid.DataRows(v_intRow) Is Nothing Then
                                If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then

                                    mv_dblTotalAmt = mv_dblTotalAmt + CDbl(SearchGrid.DataRows(v_intRow).Cells("AMT").Value)
                                    txtAMT.Text = FormatNumber(mv_dblTotalAmt, 0)
                                    intCuont = intCuont + 1
                                    'Có duoc danh dau chon
                                    For i = 0 To v_nodeList.Count - 1
                                        v_strFLDCODE = String.Empty
                                        v_strFLDCD = String.Empty
                                        For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                                            With v_nodeList.Item(i).ChildNodes(j)
                                                v_strValue = .InnerText.ToString
                                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                                Select Case Trim(v_strFLDNAME)
                                                    Case "MODCODE"
                                                        v_strMODCODE = Trim(v_strValue)
                                                    Case "TLTXCD"
                                                        v_strTLTXCD = Trim(v_strValue)
                                                    Case "FIELDCODE"
                                                        v_strFLDCODE = Trim(v_strValue)
                                                    Case "FLDCD"
                                                        v_strFLDCD = Trim(v_strValue)
                                                    Case "FIELDTYPE"
                                                        v_strFIELDTYPE = Trim(v_strValue)
                                                End Select
                                            End With
                                        Next

                                        If v_strFLDCD <> "" Then

                                            If String.Compare(v_strFLDCD, "PD") = 0 Then
                                                If TypeOf (SearchGrid.CurrentRow) Is Xceed.Grid.DataRow Then
                                                    'Neu la truong posting date
                                                    v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value
                                                    v_strValue = Replace(v_strValue, ".", "")
                                                    v_strPostingDate = v_strValue
                                                Else
                                                    v_strPostingDate = String.Empty
                                                End If
                                            Else
                                                If TypeOf (SearchGrid.CurrentRow) Is Xceed.Grid.DataRow Then
                                                    'Neu la truong binh thuong 
                                                    'Lay GL Account đưa vào vao dịch
                                                    'v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value
                                                    If v_strFIELDTYPE = "C" And (v_strFLDCODE <> "DESC" And v_strFLDCODE <> "DESCRIPTION") Then
                                                        v_strValue = Replace(v_strValue, ".", "")
                                                    End If
                                                    v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & v_strFLDCD & "." & v_strValue & "]"
                                                Else
                                                    v_strFLDDEFVAL = String.Empty
                                                End If

                                            End If
                                        End If
                                    Next

                                    'Nap va thuc hien giao dich
                                    SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = String.Empty
                                    SetTransactForm()
                                    If v_strMODCODE <> "" And v_strTLTXCD <> "" Then
                                        mv_frmTransactScreen = New frmTransact(mv_strLanguage)
                                        Try
                                            mv_frmTransactScreen.ObjectName = v_strTLTXCD
                                        Catch ex As Exception
                                            MsgBox(ex.Message)
                                        End Try
                                        mv_frmTransactScreen.ModuleCode = v_strMODCODE
                                        mv_frmTransactScreen.LocalObject = gc_IsNotLocalMsg
                                        mv_frmTransactScreen.BranchId = Me.BranchId
                                        mv_frmTransactScreen.TellerId = Me.TellerId
                                        mv_frmTransactScreen.IpAddress = Me.IpAddress
                                        mv_frmTransactScreen.WsName = Me.WsName
                                        mv_frmTransactScreen.BusDate = Me.BusDate

                                        If IIf(IsDBNull(Len(v_strPostingDate)), 0, Len(v_strPostingDate)) > 0 Then
                                            mv_frmTransactScreen.PostingDate = v_strPostingDate
                                        End If
                                        mv_frmTransactScreen.DefaultValue = v_strFLDDEFVAL
                                        mv_frmTransactScreen.AutoClosedWhenOK = True
                                        mv_frmTransactScreen.AutoSubmitWhenExecute = True
                                        mv_frmTransactScreen.ShowDialog()
                                        If mv_frmTransactScreen.CancelClick Then
                                            OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                                            Exit Function
                                            blnFlag = False
                                        End If
                                        blnFlag = True
                                        'mv_frmTransactScreen.OnSubmit()
                                        mv_frmTransactScreen.Dispose()
                                        'Reset lai gia tri
                                        v_strFLDDEFVAL = String.Empty
                                    End If
                                End If
                            End If
                        Next

                        If intCuont > 1 Then
                            mv_strIS1Transaction = "N"
                        Else
                            mv_strIS1Transaction = "Y"
                        End If
                    End If
                    'Refresh lai màn hình
                    'OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                End If
            End If
        End If


    End Function


    Private Function checkTypeGridCurrentRow(ByVal pv_ExceedRow As Xceed.Grid.Row) As Boolean
        Try
            Dim obj As New Xceed.Grid.DataRow
            obj = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

#End Region

#Region "Overrides"
    Protected Overrides Sub InitDialog()

        MyBase.InitDialog()
        Try

            mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())

            'If mv_strTableName = mv_CONST_SEARCHCODE_2248 Then
            '    LoadResourceLocal(grbMain)
            '    TabTranferInfo.Text = mv_ResourceManager.GetString(TabTranferInfo.Name)
            'End If
            If mv_strTableName = mv_CONST_SEARCHCODE_2248 Or mv_strTableName = mv_CONST_SEARCHCODE_8879 Then
                Me.txtTXDATE.BackColor = System.Drawing.Color.GreenYellow
                Me.txtTXDATE.Focus()
                Me.txtTXDATE.FieldType = FlexMaskEditBox._FieldType.DATE_
                Me.txtTXDATE.Mask = "99/99/9999"
                Me.lblTXDATE.Name = "lblTXDATE"
                Me.txtTXDATE.Name = "mskTXDATE"
                'Me.txtTXDATE.MaskCharInclude = False
                Me.txtTXDATE.Visible = True
                Me.lblTXDATE.Visible = True
                Me.txtTXDATE.Text = Me.BusDate
                Me.chkExeAll.Checked = True
                Me.lblSAFACCTNO.Visible = False
                Me.cbSAFACCTNO.Visible = False
                Me.lblRAFACCTNO.Visible = False
                Me.cbRAFACCTNO.Visible = False
                Me.lblFULLNAME.Visible = False
                Me.txtFULLNAME.Visible = False
                Me.lblADDRESS.Visible = False
                Me.txtADDRESS.Visible = False
                LoadResourceLocal(grbMain)

            ElseIf mv_strTableName = mv_CONST_SEARCHCODE_3331 Then

                Me.txtTXDATE.BackColor = System.Drawing.Color.GreenYellow
                Me.txtTXDATE.Focus()
                Me.txtTXDATE.FieldType = FlexMaskEditBox._FieldType.DATE_
                Me.txtTXDATE.Text = "SHVC"
                Me.lblTXDATE.Name = "lblCustodyCD"
                Me.txtTXDATE.Name = "mskCUSTODYCD"
                'Me.txtTXDATE.MaskCharInclude = False
                Me.txtTXDATE.Visible = True
                Me.lblTXDATE.Visible = True
                Me.chkExeAll.Checked = True
                Me.lblSAFACCTNO.Visible = True
                Me.cbSAFACCTNO.Visible = True
                Me.lblRAFACCTNO.Visible = True
                Me.cbRAFACCTNO.Visible = True
                Me.lblFULLNAME.Visible = True
                Me.txtFULLNAME.Visible = True
                Me.lblADDRESS.Visible = True
                Me.txtADDRESS.Visible = True
                LoadResourceLocal(grbMain)
            End If

        Catch ex As Exception
        Finally
        End Try

    End Sub

    Protected Overrides Sub DoResizeForm()
    End Sub
#End Region

#Region "Form events "

    Private Sub frmPaymentOrder_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Dim v_intPos As Int16
        Dim ctl As Control
        Dim strFLDNAME As String = String.Empty
        Dim v_intIndex As Integer = 0
        Select Case e.KeyCode
            Case Keys.F5
                If Me.ActiveControl.Name = "mskCUSTODYCD" Then
                    Dim frm As New frmSearch(Me.UserLanguage)
                    frm.TableName = "CUSTODYCD_CF"
                    frm.ModuleCode = "CF"
                    frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                    frm.IsLocalSearch = gc_IsNotLocalMsg
                    frm.IsLookup = "Y"
                    frm.SearchOnInit = False
                    frm.BranchId = Me.BranchId
                    frm.TellerId = Me.TellerId
                    frm.ShowDialog()
                    Me.ActiveControl.Text = Trim(frm.ReturnValue)
                    frm.Dispose()
                End If
            Case Keys.Enter
                If Me.ActiveControl.Name = "mskCUSTODYCD" Then
                    'Nạp thông tin tieu khoan
                    If Len(Trim(ActiveControl.Text.Replace(".", ""))) = LEN_AFACCTNO Then
                        GetCustInfo(ActiveControl.Text)
                        SendKeys.Send("{Tab}")
                        e.Handled = True
                    End If
                ElseIf Not TypeOf (Me.ActiveControl) Is Button Then

                    SendKeys.Send("{Tab}")
                    e.Handled = True
                Else
                End If
        End Select
    End Sub

    'Private Sub txtTXDATE_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    GetBankInfo(txtTXDATE.Text)
    'End Sub

    Private Sub FormatNumericTextbox(ByVal pv_ctrl As TextBox)
        Try
            Dim v_strFormat As String
            Dim v_intDecimal As String
            Dim v_intIndex As Integer
            v_intIndex = CType(pv_ctrl, TextBox).Tag
            v_strFormat = mv_arrObjFields(v_intIndex).FieldFormat
            If (v_strFormat.Length > 0) Then
                If (v_strFormat.IndexOf(".") <> -1) Then
                    v_intDecimal = Mid(v_strFormat, v_strFormat.IndexOf(".") + 2).Length()
                Else
                    v_intDecimal = 0
                End If
            Else
                v_intDecimal = 0
            End If

            If IsNumeric(pv_ctrl.Text) Then
                If FormatNumber(pv_ctrl.Text, v_intDecimal) = FRound(CDbl(pv_ctrl.Text)) Then
                    pv_ctrl.Text = FormatNumber(Math.Floor(CDbl(pv_ctrl.Text)), v_intDecimal)
                Else
                    pv_ctrl.Text = FormatNumber(pv_ctrl.Text, v_intDecimal)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtTXDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTXDATE.GotFocus
        txtTXDATE.SelectionStart = txtTXDATE.Text.Trim().Length
    End Sub

    Private Sub txtTXDATE_Validated1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTXDATE.Validated
        'txtTXDATE.Text = Trim(txtTXDATE.Text).PadLeft(10, "0")
        'GetBankInfo(txtTXDATE.Text.Trim())
        If (Len(Trim(Me.txtTXDATE.Text.Replace("/", ""))) = 0 Or String.Compare(Me.txtTXDATE.Text, "") = 0) And (mv_strTableName = mv_CONST_SEARCHCODE_2248 Or mv_strTableName = mv_CONST_SEARCHCODE_8879) Then
            MsgBox(mv_ResourceManager.GetString("TXDateNotNull"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
            TabMain.SelectTab(TabTranferInfo)
            Me.txtTXDATE.Focus()
            Exit Sub
        End If
        If mv_strTableName = mv_CONST_SEARCHCODE_3331 Then

            GetCustInfo(txtTXDATE.Text.Trim())

        End If
    End Sub

    'Private Sub cboRRTYPE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRRTYPE.SelectedIndexChanged
    '    If cboRRTYPE.SelectedValue.ToString.Length <> 0 Then
    '        SetAdvTypeInfo(cboRRTYPE.SelectedValue)
    '        OnSearch(gc_IsNotLocalMsg, OBJNAME_CI_CIMAST)
    '    End If
    'End Sub
    Protected Overridable Sub AdvanceGrid_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim v_dblAdvanceAmt As Double = 0
        Dim v_dblFeeAmt As Double = 0

        For i As Integer = 0 To SearchGrid.DataRows.Count - 1 Step 1
            If Not SearchGrid.DataRows(i) Is Nothing Then
                If SearchGrid.DataRows(i).Cells("__TICK").Value = "X" Then
                    v_dblAdvanceAmt = v_dblAdvanceAmt + CDbl(SearchGrid.DataRows(i).Cells("MAXAVLAMT").Value)
                    v_dblFeeAmt = 0
                End If
            End If
        Next
        Me.txtADVAMT.Text = Format(v_dblAdvanceAmt, gc_FORMAT_NUMBER_0)
        Me.txtADVFEEAMT.Text = Format(v_dblFeeAmt, gc_FORMAT_NUMBER_0)
        Me.txtPOOLREMAIN.Text = Format(CDbl(Me.txtAVLPOOL.Text) - v_dblAdvanceAmt - v_dblFeeAmt, gc_FORMAT_NUMBER_0)
        If CDec(CDbl(Me.txtAVLPOOL.Text) - v_dblAdvanceAmt - v_dblFeeAmt) < 0 Then
            Me.txtPOOLREMAIN.ForeColor = Color.Red
        Else
            Me.txtPOOLREMAIN.ForeColor = Color.Green
        End If
    End Sub
#End Region



    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub cbSAFACCTNO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSAFACCTNO.SelectedIndexChanged
        If Not (cbSAFACCTNO.SelectedValue Is Nothing) Then
            Me.AFACCTNO = cbSAFACCTNO.SelectedValue.ToString
        Else
            Me.AFACCTNO = ""
        End If
        OnSearch(gc_IsNotLocalMsg, OBJNAME_CA_CAMAST)

    End Sub
End Class
