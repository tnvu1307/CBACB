Imports CommonLibrary
Imports AppCore

Public Class frmOOD
    Inherits AppCore.frmMaintenance

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
    Friend WithEvents lblOrgOrderID As System.Windows.Forms.Label
    Friend WithEvents txtOrgOrderID As System.Windows.Forms.TextBox
    Friend WithEvents lblBOrS As System.Windows.Forms.Label
    Friend WithEvents txtBOrS As System.Windows.Forms.TextBox
    Friend WithEvents txtSymbol As System.Windows.Forms.TextBox
    Friend WithEvents lblSymbol As System.Windows.Forms.Label
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents lblQuantity As System.Windows.Forms.Label
    Friend WithEvents lblPrice As System.Windows.Forms.Label
    Friend WithEvents txtPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtSEName As System.Windows.Forms.TextBox
    Friend WithEvents lblTxNum As System.Windows.Forms.Label
    Friend WithEvents txtTxNum As System.Windows.Forms.TextBox
    Friend WithEvents lblTxDate As System.Windows.Forms.Label
    Friend WithEvents txtTxDate As System.Windows.Forms.TextBox
    Friend WithEvents lblCustID As System.Windows.Forms.Label
    Friend WithEvents txtCustID As System.Windows.Forms.TextBox
    Friend WithEvents txtCustName As System.Windows.Forms.TextBox
    Friend WithEvents pnlInfo As System.Windows.Forms.Panel
    Friend WithEvents lblCustodyCode As System.Windows.Forms.Label
    Friend WithEvents txtCUSTODYCD As System.Windows.Forms.TextBox
    Friend WithEvents lblLine1 As System.Windows.Forms.Label
    Friend WithEvents lblLine2 As System.Windows.Forms.Label
    Friend WithEvents lblLine3 As System.Windows.Forms.Label
    Friend WithEvents lblLine4 As System.Windows.Forms.Label
    Friend WithEvents lblLine5 As System.Windows.Forms.Label
    Friend WithEvents lblVia As System.Windows.Forms.Label
    Friend WithEvents lblTradePlace As System.Windows.Forms.Label
    Friend WithEvents txtTradePlace As System.Windows.Forms.TextBox
    Friend WithEvents txtVia As System.Windows.Forms.TextBox
    Friend WithEvents lblLine6 As System.Windows.Forms.Label
    Friend WithEvents pnlDisplay As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pnlInfo = New System.Windows.Forms.Panel
        Me.lblTradePlace = New System.Windows.Forms.Label
        Me.txtTradePlace = New System.Windows.Forms.TextBox
        Me.lblVia = New System.Windows.Forms.Label
        Me.txtVia = New System.Windows.Forms.TextBox
        Me.lblCustodyCode = New System.Windows.Forms.Label
        Me.txtCUSTODYCD = New System.Windows.Forms.TextBox
        Me.txtCustName = New System.Windows.Forms.TextBox
        Me.lblCustID = New System.Windows.Forms.Label
        Me.txtCustID = New System.Windows.Forms.TextBox
        Me.lblTxDate = New System.Windows.Forms.Label
        Me.txtTxDate = New System.Windows.Forms.TextBox
        Me.lblTxNum = New System.Windows.Forms.Label
        Me.txtTxNum = New System.Windows.Forms.TextBox
        Me.txtSEName = New System.Windows.Forms.TextBox
        Me.txtPrice = New System.Windows.Forms.TextBox
        Me.lblPrice = New System.Windows.Forms.Label
        Me.txtQuantity = New System.Windows.Forms.TextBox
        Me.lblQuantity = New System.Windows.Forms.Label
        Me.txtSymbol = New System.Windows.Forms.TextBox
        Me.lblSymbol = New System.Windows.Forms.Label
        Me.txtBOrS = New System.Windows.Forms.TextBox
        Me.lblBOrS = New System.Windows.Forms.Label
        Me.lblOrgOrderID = New System.Windows.Forms.Label
        Me.txtOrgOrderID = New System.Windows.Forms.TextBox
        Me.pnlDisplay = New System.Windows.Forms.Panel
        Me.lblLine6 = New System.Windows.Forms.Label
        Me.lblLine5 = New System.Windows.Forms.Label
        Me.lblLine4 = New System.Windows.Forms.Label
        Me.lblLine3 = New System.Windows.Forms.Label
        Me.lblLine2 = New System.Windows.Forms.Label
        Me.lblLine1 = New System.Windows.Forms.Label
        Me.pnlInfo.SuspendLayout()
        Me.pnlDisplay.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(380, 308)
        Me.btnOK.Name = "btnOK"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(540, 308)
        Me.btnCancel.Name = "btnCancel"
        '
        'Panel1
        '
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(634, 50)
        '
        'lblCaption
        '
        Me.lblCaption.Name = "lblCaption"
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(460, 308)
        Me.btnApply.Name = "btnApply"
        '
        'pnlInfo
        '
        Me.pnlInfo.Controls.Add(Me.lblTradePlace)
        Me.pnlInfo.Controls.Add(Me.txtTradePlace)
        Me.pnlInfo.Controls.Add(Me.lblVia)
        Me.pnlInfo.Controls.Add(Me.txtVia)
        Me.pnlInfo.Controls.Add(Me.lblCustodyCode)
        Me.pnlInfo.Controls.Add(Me.txtCUSTODYCD)
        Me.pnlInfo.Controls.Add(Me.txtCustName)
        Me.pnlInfo.Controls.Add(Me.lblCustID)
        Me.pnlInfo.Controls.Add(Me.txtCustID)
        Me.pnlInfo.Controls.Add(Me.lblTxDate)
        Me.pnlInfo.Controls.Add(Me.txtTxDate)
        Me.pnlInfo.Controls.Add(Me.lblTxNum)
        Me.pnlInfo.Controls.Add(Me.txtTxNum)
        Me.pnlInfo.Controls.Add(Me.txtSEName)
        Me.pnlInfo.Controls.Add(Me.txtPrice)
        Me.pnlInfo.Controls.Add(Me.lblPrice)
        Me.pnlInfo.Controls.Add(Me.txtQuantity)
        Me.pnlInfo.Controls.Add(Me.lblQuantity)
        Me.pnlInfo.Controls.Add(Me.txtSymbol)
        Me.pnlInfo.Controls.Add(Me.lblSymbol)
        Me.pnlInfo.Controls.Add(Me.txtBOrS)
        Me.pnlInfo.Controls.Add(Me.lblBOrS)
        Me.pnlInfo.Controls.Add(Me.lblOrgOrderID)
        Me.pnlInfo.Controls.Add(Me.txtOrgOrderID)
        Me.pnlInfo.Location = New System.Drawing.Point(8, 52)
        Me.pnlInfo.Name = "pnlInfo"
        Me.pnlInfo.Size = New System.Drawing.Size(576, 236)
        Me.pnlInfo.TabIndex = 13
        '
        'lblTradePlace
        '
        Me.lblTradePlace.Location = New System.Drawing.Point(256, 72)
        Me.lblTradePlace.Name = "lblTradePlace"
        Me.lblTradePlace.TabIndex = 23
        Me.lblTradePlace.Tag = "lblTradePlace"
        Me.lblTradePlace.Text = "lblTradePlace"
        '
        'txtTradePlace
        '
        Me.txtTradePlace.Location = New System.Drawing.Point(360, 72)
        Me.txtTradePlace.Name = "txtTradePlace"
        Me.txtTradePlace.ReadOnly = True
        Me.txtTradePlace.TabIndex = 22
        Me.txtTradePlace.Tag = "TRADEPLACE"
        Me.txtTradePlace.Text = "txtTradePlace"
        '
        'lblVia
        '
        Me.lblVia.Location = New System.Drawing.Point(256, 40)
        Me.lblVia.Name = "lblVia"
        Me.lblVia.TabIndex = 21
        Me.lblVia.Tag = "lblVia"
        Me.lblVia.Text = "lblVia"
        '
        'txtVia
        '
        Me.txtVia.Location = New System.Drawing.Point(360, 40)
        Me.txtVia.Name = "txtVia"
        Me.txtVia.ReadOnly = True
        Me.txtVia.TabIndex = 20
        Me.txtVia.Tag = "VIA"
        Me.txtVia.Text = "txtVia"
        '
        'lblCustodyCode
        '
        Me.lblCustodyCode.Location = New System.Drawing.Point(256, 8)
        Me.lblCustodyCode.Name = "lblCustodyCode"
        Me.lblCustodyCode.TabIndex = 19
        Me.lblCustodyCode.Tag = "lblCustodyCode"
        Me.lblCustodyCode.Text = "lblCustodyCode"
        '
        'txtCUSTODYCD
        '
        Me.txtCUSTODYCD.Location = New System.Drawing.Point(360, 8)
        Me.txtCUSTODYCD.Name = "txtCUSTODYCD"
        Me.txtCUSTODYCD.ReadOnly = True
        Me.txtCUSTODYCD.TabIndex = 18
        Me.txtCUSTODYCD.Tag = "CUSTODYCD"
        Me.txtCUSTODYCD.Text = "txtCUSTODYCD"
        '
        'txtCustName
        '
        Me.txtCustName.Location = New System.Drawing.Point(220, 104)
        Me.txtCustName.Name = "txtCustName"
        Me.txtCustName.ReadOnly = True
        Me.txtCustName.Size = New System.Drawing.Size(336, 21)
        Me.txtCustName.TabIndex = 17
        Me.txtCustName.Tag = "FULLNAME"
        Me.txtCustName.Text = "txtCustName"
        '
        'lblCustID
        '
        Me.lblCustID.Location = New System.Drawing.Point(8, 104)
        Me.lblCustID.Name = "lblCustID"
        Me.lblCustID.TabIndex = 16
        Me.lblCustID.Tag = "lblCustID"
        Me.lblCustID.Text = "lblCustID"
        '
        'txtCustID
        '
        Me.txtCustID.Location = New System.Drawing.Point(112, 104)
        Me.txtCustID.Name = "txtCustID"
        Me.txtCustID.ReadOnly = True
        Me.txtCustID.TabIndex = 15
        Me.txtCustID.Tag = "CUSTID"
        Me.txtCustID.Text = "txtCustID"
        '
        'lblTxDate
        '
        Me.lblTxDate.Location = New System.Drawing.Point(8, 72)
        Me.lblTxDate.Name = "lblTxDate"
        Me.lblTxDate.TabIndex = 14
        Me.lblTxDate.Tag = "lblTxDate"
        Me.lblTxDate.Text = "lblTxDate"
        '
        'txtTxDate
        '
        Me.txtTxDate.Location = New System.Drawing.Point(112, 72)
        Me.txtTxDate.Name = "txtTxDate"
        Me.txtTxDate.ReadOnly = True
        Me.txtTxDate.TabIndex = 13
        Me.txtTxDate.Tag = "TXDATE"
        Me.txtTxDate.Text = "txtTxDate"
        '
        'lblTxNum
        '
        Me.lblTxNum.Location = New System.Drawing.Point(8, 40)
        Me.lblTxNum.Name = "lblTxNum"
        Me.lblTxNum.TabIndex = 12
        Me.lblTxNum.Tag = "lblTxNum"
        Me.lblTxNum.Text = "lblTxNum"
        '
        'txtTxNum
        '
        Me.txtTxNum.Location = New System.Drawing.Point(112, 40)
        Me.txtTxNum.Name = "txtTxNum"
        Me.txtTxNum.ReadOnly = True
        Me.txtTxNum.TabIndex = 11
        Me.txtTxNum.Tag = "TXNUM"
        Me.txtTxNum.Text = "txtTxNum"
        '
        'txtSEName
        '
        Me.txtSEName.Location = New System.Drawing.Point(220, 168)
        Me.txtSEName.Name = "txtSEName"
        Me.txtSEName.ReadOnly = True
        Me.txtSEName.Size = New System.Drawing.Size(336, 21)
        Me.txtSEName.TabIndex = 10
        Me.txtSEName.Tag = "SENAME"
        Me.txtSEName.Text = "txtSEName"
        '
        'txtPrice
        '
        Me.txtPrice.Location = New System.Drawing.Point(112, 232)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.ReadOnly = True
        Me.txtPrice.TabIndex = 9
        Me.txtPrice.Tag = "PRICE"
        Me.txtPrice.Text = "txtPrice"
        '
        'lblPrice
        '
        Me.lblPrice.Location = New System.Drawing.Point(8, 232)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.TabIndex = 8
        Me.lblPrice.Tag = "lblPrice"
        Me.lblPrice.Text = "lblPrice"
        '
        'txtQuantity
        '
        Me.txtQuantity.Location = New System.Drawing.Point(112, 200)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.ReadOnly = True
        Me.txtQuantity.TabIndex = 7
        Me.txtQuantity.Tag = "QTTY"
        Me.txtQuantity.Text = "txtQuantity"
        '
        'lblQuantity
        '
        Me.lblQuantity.Location = New System.Drawing.Point(8, 200)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.TabIndex = 6
        Me.lblQuantity.Tag = "lblQuantity"
        Me.lblQuantity.Text = "lblQuantity"
        '
        'txtSymbol
        '
        Me.txtSymbol.Location = New System.Drawing.Point(112, 168)
        Me.txtSymbol.Name = "txtSymbol"
        Me.txtSymbol.ReadOnly = True
        Me.txtSymbol.TabIndex = 5
        Me.txtSymbol.Tag = "SYMBOL"
        Me.txtSymbol.Text = "txtSymbol"
        '
        'lblSymbol
        '
        Me.lblSymbol.Location = New System.Drawing.Point(8, 168)
        Me.lblSymbol.Name = "lblSymbol"
        Me.lblSymbol.TabIndex = 4
        Me.lblSymbol.Tag = "lblSymbol"
        Me.lblSymbol.Text = "lblSymbol"
        '
        'txtBOrS
        '
        Me.txtBOrS.Location = New System.Drawing.Point(112, 136)
        Me.txtBOrS.Name = "txtBOrS"
        Me.txtBOrS.ReadOnly = True
        Me.txtBOrS.TabIndex = 3
        Me.txtBOrS.Tag = "BORS"
        Me.txtBOrS.Text = "txtBOrS"
        '
        'lblBOrS
        '
        Me.lblBOrS.Location = New System.Drawing.Point(8, 136)
        Me.lblBOrS.Name = "lblBOrS"
        Me.lblBOrS.TabIndex = 2
        Me.lblBOrS.Tag = "lblBOrS"
        Me.lblBOrS.Text = "lblBOrS"
        '
        'lblOrgOrderID
        '
        Me.lblOrgOrderID.Location = New System.Drawing.Point(8, 8)
        Me.lblOrgOrderID.Name = "lblOrgOrderID"
        Me.lblOrgOrderID.TabIndex = 1
        Me.lblOrgOrderID.Tag = "lblOrgOrderID"
        Me.lblOrgOrderID.Text = "lblOrgOrderID"
        '
        'txtOrgOrderID
        '
        Me.txtOrgOrderID.Location = New System.Drawing.Point(112, 8)
        Me.txtOrgOrderID.Name = "txtOrgOrderID"
        Me.txtOrgOrderID.ReadOnly = True
        Me.txtOrgOrderID.TabIndex = 0
        Me.txtOrgOrderID.Tag = "ORGORDERID"
        Me.txtOrgOrderID.Text = "txtOrgOrderID"
        '
        'pnlDisplay
        '
        Me.pnlDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDisplay.Controls.Add(Me.lblLine6)
        Me.pnlDisplay.Controls.Add(Me.lblLine5)
        Me.pnlDisplay.Controls.Add(Me.lblLine4)
        Me.pnlDisplay.Controls.Add(Me.lblLine3)
        Me.pnlDisplay.Controls.Add(Me.lblLine2)
        Me.pnlDisplay.Controls.Add(Me.lblLine1)
        Me.pnlDisplay.Location = New System.Drawing.Point(4, 52)
        Me.pnlDisplay.Name = "pnlDisplay"
        Me.pnlDisplay.Size = New System.Drawing.Size(624, 240)
        Me.pnlDisplay.TabIndex = 14
        '
        'lblLine6
        '
        Me.lblLine6.Location = New System.Drawing.Point(7, 208)
        Me.lblLine6.Name = "lblLine6"
        Me.lblLine6.Size = New System.Drawing.Size(608, 23)
        Me.lblLine6.TabIndex = 5
        Me.lblLine6.Text = "lblLine6"
        Me.lblLine6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLine5
        '
        Me.lblLine5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLine5.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLine5.Location = New System.Drawing.Point(348, 12)
        Me.lblLine5.Name = "lblLine5"
        Me.lblLine5.Size = New System.Drawing.Size(268, 56)
        Me.lblLine5.TabIndex = 4
        Me.lblLine5.Text = "lblLine5"
        Me.lblLine5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLine4
        '
        Me.lblLine4.Location = New System.Drawing.Point(8, 144)
        Me.lblLine4.Name = "lblLine4"
        Me.lblLine4.Size = New System.Drawing.Size(608, 23)
        Me.lblLine4.TabIndex = 3
        Me.lblLine4.Text = "Label4"
        Me.lblLine4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLine3
        '
        Me.lblLine3.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLine3.Location = New System.Drawing.Point(8, 92)
        Me.lblLine3.Name = "lblLine3"
        Me.lblLine3.Size = New System.Drawing.Size(608, 44)
        Me.lblLine3.TabIndex = 2
        Me.lblLine3.Text = "Label3"
        Me.lblLine3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLine2
        '
        Me.lblLine2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLine2.Location = New System.Drawing.Point(8, 44)
        Me.lblLine2.Name = "lblLine2"
        Me.lblLine2.Size = New System.Drawing.Size(332, 23)
        Me.lblLine2.TabIndex = 1
        Me.lblLine2.Text = "Label2"
        '
        'lblLine1
        '
        Me.lblLine1.Location = New System.Drawing.Point(8, 12)
        Me.lblLine1.Name = "lblLine1"
        Me.lblLine1.Size = New System.Drawing.Size(332, 23)
        Me.lblLine1.TabIndex = 0
        Me.lblLine1.Text = "Label1"
        '
        'frmOOD
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(634, 343)
        Me.Controls.Add(Me.pnlDisplay)
        Me.Controls.Add(Me.pnlInfo)
        Me.Name = "frmOOD"
        Me.Text = "frmOOD"
        Me.Controls.SetChildIndex(Me.pnlInfo, 0)
        Me.Controls.SetChildIndex(Me.pnlDisplay, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnApply, 0)
        Me.pnlInfo.ResumeLayout(False)
        Me.pnlDisplay.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Overrides "
    Public Overrides Sub OnInit()
        Dim v_ctrl As Windows.Forms.Control

        Try
            MyBase.OnInit()
            OnView()
            'Load Resource Manager
            ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & Me.Name & "-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            LoadUserInterface(Me)
            DisplayInfo()
            'Me.tabGeneral.Dispose()
            '  Me.TabPage1.Dispose()
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("InitDialogFailed"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Public Overrides Sub FillData()
        Dim v_strFilter As String
        Dim v_strFLDNAME, v_strValue As String
        Dim v_strFieldType, v_strDataType As String
        Dim v_ctrl As Windows.Forms.Control

        Try
            Select Case KeyFieldType
                Case "C"
                    v_strFilter = KeyFieldName & " = '" & KeyFieldValue & "'"
                Case "D"
                    v_strFilter = KeyFieldName & " = TO_DATE('" & KeyFieldValue & "', '" & gc_FORMAT_DATE & "')"
                Case "N"
                    v_strFilter = KeyFieldName & " = " & KeyFieldValue.ToString()
            End Select

            Dim v_strCmdInquiry As String

            v_strCmdInquiry = "SELECT C.ACTYPE, D.TYPENAME, ORGORDERID, E.CDCONTENT BORS, A.CODEID, A.SYMBOL , PRICE / L.TRADEUNIT PRICE, QTTY, " & vbCrLf & _
                            "   G.CDCONTENT TRADEPLACE, F.CDCONTENT VIA, A.TXDATE, A.TXNUM, J.FULLNAME, J.CUSTODYCD, K.FULLNAME SENAME, J.CUSTID " & vbCrLf & _
                            "FROM OOD A, SBSECURITIES B, ODMAST C, ODTYPE D, AFMAST I, CFMAST J, ISSUERS K, ALLCODE E, ALLCODE F, ALLCODE G, SECURITIES_INFO L " & vbCrLf & _
                            "WHERE(A.CODEID = B.CODEID And A.ORGORDERID = C.ORDERID And C.ACTYPE = D.ACTYPE)" & vbCrLf & _
                            "   AND A.CODEID = L.CODEID " & ControlChars.CrLf & _
                            "   AND C.AFACCTNO = I.ACCTNO AND I.CUSTID = J.CUSTID " & vbCrLf & _
                            "   AND B.ISSUERID = K.ISSUERID " & vbCrLf & _
                            "   AND (A.BORS = E.CDVAL AND E.CDNAME = 'BORS' AND E.CDTYPE = 'OD') " & vbCrLf & _
                            "   AND (C.VIA = F.CDVAL AND F.CDNAME = 'VIA' AND F.CDTYPE = 'OD')" & vbCrLf & _
                            "   AND (B.TRADEPLACE = G.CDVAL AND G.CDNAME = 'TRADEPLACE' AND G.CDTYPE = 'OD')" & vbCrLf & _
                            "   AND OODSTATUS IN ('N','B') AND " & v_strFilter

            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionInquiry, v_strCmdInquiry)
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
            v_ws.Message(v_strObjMsg)

            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_nodeList As Xml.XmlNodeList

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            If v_nodeList.Count = 1 Then
                For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                    With v_nodeList.Item(0).ChildNodes(i)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString
                    End With

                    For j As Integer = 0 To UBound(mv_arrObjFields) - 1
                        If mv_arrObjFields(j).FieldName = Trim(v_strFLDNAME) Then
                            v_strFieldType = mv_arrObjFields(j).FieldType
                            v_strDataType = mv_arrObjFields(j).DataType
                            Exit For
                        End If
                    Next

                    SetControlValue(Me, v_strFLDNAME, v_strFieldType, v_strValue, v_strDataType)
                Next
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try

    End Sub

    Public Overrides Sub OnSave()
        'Cập nhật trạng thái lệnh trong OOD thành S
        Dim v_strFilter As String
        Dim v_strFLDNAME, v_strValue As String
        Dim v_strFieldType, v_strDataType As String
        Dim v_ctrl As Windows.Forms.Control

        Try
            Select Case KeyFieldType
                Case "C"
                    v_strFilter = KeyFieldName & " = '" & KeyFieldValue & "'"
                Case "D"
                    v_strFilter = KeyFieldName & " = TO_DATE('" & KeyFieldValue & "', '" & gc_FORMAT_DATE & "')"
                Case "N"
                    v_strFilter = KeyFieldName & " = " & KeyFieldValue.ToString()
            End Select

            Dim v_strCmdInquiry As String

            v_strCmdInquiry = "UPDATE OOD SET OODSTATUS = 'S', TLIDSENT = '" & TellerId & "' WHERE " & v_strFilter

            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdhoc, v_strCmdInquiry)
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

            MsgBox(ResourceManager.GetString("SentSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
            Me.DialogResult = DialogResult.OK
            MyBase.OnClose()

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Public Overrides Sub LoadUserInterface(ByRef pv_ctrl As System.Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control

        Try
            pv_ctrl.BackColor = System.Drawing.SystemColors.InactiveCaptionText
            'Enable/disable OK, Apply buttons
            btnOK.Visible = (ExeFlag <> ExecuteFlag.View)
            btnApply.Enabled = True '(ExeFlag <> ExecuteFlag.View)

            For Each v_ctrl In pv_ctrl.Controls
                If TypeOf (v_ctrl) Is Button Then
                    CType(v_ctrl, Button).Text = ResourceManager.GetString(v_ctrl.Tag)
                ElseIf TypeOf (v_ctrl) Is Panel Then
                    LoadUserInterface(v_ctrl)
                End If
            Next

            'Load caption của form, label caption
            If (Me.Text.Trim() = String.Empty) Then
                Me.Text = ResourceManager.GetString(Me.Name)
            End If
            lblCaption.Text = ResourceManager.GetString(lblCaption.Tag & ExeFlag.ToString())

            btnApply.Focus()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Overrides Sub OnClose()
        Dim v_strFilter As String
        Dim v_strFLDNAME, v_strValue As String
        Dim v_strFieldType, v_strDataType As String
        Dim v_ctrl As Windows.Forms.Control

        Try
            Select Case KeyFieldType
                Case "C"
                    v_strFilter = KeyFieldName & " = '" & KeyFieldValue & "'"
                Case "D"
                    v_strFilter = KeyFieldName & " = TO_DATE('" & KeyFieldValue & "', '" & gc_FORMAT_DATE & "')"
                Case "N"
                    v_strFilter = KeyFieldName & " = " & KeyFieldValue.ToString()
            End Select

            Dim v_strCmdInquiry As String

            v_strCmdInquiry = "UPDATE OOD SET OODSTATUS = 'N' WHERE " & v_strFilter

            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdhoc, v_strCmdInquiry)
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

            'MsgBox(ResourceManager.GetString("SentSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
            'Me.DialogResult = DialogResult.OK
            MyBase.OnClose()

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try

    End Sub

    Private Sub OnView()
        Dim v_strFilter As String
        Dim v_strFLDNAME, v_strValue As String
        Dim v_strFieldType, v_strDataType As String
        Dim v_ctrl As Windows.Forms.Control

        Try
            Select Case KeyFieldType
                Case "C"
                    v_strFilter = KeyFieldName & " = '" & KeyFieldValue & "'"
                Case "D"
                    v_strFilter = KeyFieldName & " = TO_DATE('" & KeyFieldValue & "', '" & gc_FORMAT_DATE & "')"
                Case "N"
                    v_strFilter = KeyFieldName & " = " & KeyFieldValue.ToString()
            End Select

            Dim v_strCmdInquiry As String

            v_strCmdInquiry = "UPDATE OOD SET OODSTATUS = 'B' WHERE " & v_strFilter

            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdhoc, v_strCmdInquiry)
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

            'MsgBox(ResourceManager.GetString("SentSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
            'Me.DialogResult = DialogResult.OK
            'MyBase.OnClose()

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub
    Private Sub DisplayInfo()
        Try
            pnlInfo.Visible = False
            If txtBOrS.Text = "Sell" Then
                lblLine1.ForeColor = System.Drawing.Color.Red
                lblLine2.ForeColor = System.Drawing.Color.Red
                lblLine3.ForeColor = System.Drawing.Color.Red
                lblLine4.ForeColor = System.Drawing.Color.Red
                lblLine5.ForeColor = System.Drawing.Color.Red
                lblLine6.ForeColor = System.Drawing.Color.Red
            Else
                lblLine1.ForeColor = System.Drawing.Color.Blue
                lblLine2.ForeColor = System.Drawing.Color.Blue
                lblLine3.ForeColor = System.Drawing.Color.Blue
                lblLine4.ForeColor = System.Drawing.Color.Blue
                lblLine5.ForeColor = System.Drawing.Color.Blue
                lblLine6.ForeColor = System.Drawing.Color.Blue
            End If

            lblLine1.Text = "TxDate: " & txtTxDate.Text & " - TxNum: " & Strings.Left(txtTxNum.Text, 4) & "." & Strings.Right(txtTxNum.Text, 6)
            lblLine2.Text = "Customer Name: " & txtCustName.Text
            lblLine3.Text = txtBOrS.Text & " | " & txtSymbol.Text & " | Quantity: " & FormatNumber(txtQuantity.Text, 0) & " | Price: " & FormatNumber(txtPrice.Text, 1)
            lblLine4.Text = "( " & txtSymbol.Text & " ) " & txtSEName.Text
            lblLine5.Text = " Custody Code : " & Strings.Left(txtCUSTODYCD.Text, 4) & "." & Strings.Mid(txtCUSTODYCD.Text, 5, 3) & "." & Strings.Right(txtCUSTODYCD.Text, 3)
            lblLine6.Text = " Via : " & txtVia.Text & " - Trade place: " & txtTradePlace.Text

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub
#End Region

End Class
