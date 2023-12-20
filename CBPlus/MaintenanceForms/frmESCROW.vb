Imports CommonLibrary
Imports AppCore
Public Class frmESCROW
    Inherits AppCore.frmMaintenance
#Region "Properties"

#End Region

    Overrides Sub LoadUserInterface(ByRef pv_ctrl As Windows.Forms.Control)
        MyBase.LoadUserInterface(pv_ctrl)

        
    End Sub

    Private Function ControlValidation(Optional ByVal pv_blnSaved As Boolean = False) As Boolean
        Dim v_ws As New BDSDeliveryManagement
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_dblCount As Double = 0
        Try
            If pv_blnSaved Then
                
                Return MyBase.VerifyRules
            End If

            Return True
        Catch ex As Exception
            Throw ex
            Return False
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Function

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

    Public Overrides Sub OnInit()
        
        'LoadUserInterface(tpESCROW)
        Try
            MyBase.OnInit()
            ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & Me.Name & "-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            LoadUserInterface(Me)
            Me.TabControl1.TabPages.Remove(tpECROW_FILES)
            If ExeFlag = ExecuteFlag.AddNew Then
                btnApply.Visible = False
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("InitDialogFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try

    End Sub

    


 
    Public Sub New()
        MyBase.New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Overrides Sub OnSave()
        Dim v_strSQL As String
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery

        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strValue As String
        Try
            Cursor.Current = Cursors.WaitCursor

            If ExeFlag = ExecuteFlag.AddNew Then
                v_strSQL = "SELECT SEQ_ESCROW.NEXTVAL AUTOID FROM DUAL "
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, Me.ObjectName, gc_ActionInquiry, v_strSQL)

                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                For i As Integer = 0 To v_nodeList.Count - 1
                    For j As Integer = 0 To v_nodeList.Item(j).ChildNodes.Count - 1
                        With v_nodeList.Item(j).ChildNodes(i)
                            v_strFLDNAME = v_nodeList.Item(j).ChildNodes(i).Attributes.GetNamedItem("fldname").Value.Trim()
                            v_strValue = v_nodeList.Item(j).ChildNodes(i).Attributes.GetNamedItem("oldval").Value.Trim()
                            Select Case v_strFLDNAME
                                Case "AUTOID"
                                    txtAUTOID.Text = v_strValue
                            End Select
                        End With
                    Next
                Next
            End If
            

            MyBase.OnSave()
            If Not DoDataExchange(True) Then
                Exit Sub
            End If

            Select ExeFlag
                Case ExecuteFlag.AddNew
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdd, , , , gc_AutoIdUnused)
                    BuildXMLObjData(mv_dsInput, v_strObjMsg)

                    v_ws = New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                    'Kiểm tra thông tin và xử lý lỗi (nếu có) từ message trả v?
                    Dim v_strErrorSource, v_strErrorMessage As String

                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Sub
                    End If

                    MsgBox(ResourceManager.GetString("AddnewSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)

                    Select Case MyBase.SaveButtonType
                        Case SaveButtonType.ApplyButton
                            KeyFieldValue = GetControlValueByName(KeyFieldName, Me)
                            ExeFlag = ExecuteFlag.Edit
                            LoadUserInterface(Me)
                        Case SaveButtonType.OKButton
                            Me.DialogResult = DialogResult.OK
                            MyBase.OnClose()
                    End Select
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

                    v_ws = New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                    'Ki�ểm tra thông tin và xử lý lỗi (nếu có) từ message trả v?
                    Dim v_strErrorSource, v_strErrorMessage As String

                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Sub
                    End If

                    MsgBox(ResourceManager.GetString("EditSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)

                    Select Case MyBase.SaveButtonType
                        Case SaveButtonType.ApplyButton
                            KeyFieldValue = GetControlValueByName(KeyFieldName, Me)
                            ExeFlag = ExecuteFlag.Edit
                            LoadUserInterface(Me)
                        Case SaveButtonType.OKButton
                            Me.DialogResult = DialogResult.OK
                            MyBase.OnClose()
                    End Select
            End Select


            'Update mouse pointer
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Function VerifyRuleMskCtrl(ByRef pv_MskCtrl As Windows.Forms.Control) As Boolean

        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strCmdSQL, v_strKeyName As String
        Dim v_xmlDoc As XmlDocumentEx
        Dim v_SearchCmdSQL As String = ""
        Dim v_lngCount As Long
        Try
            If Not pv_MskCtrl.Text Is Nothing Then
                v_strCmdSQL = "SELECT FL.FLDNAME, FL.CAPTION, FL.EN_CAPTION, S.SEARCHCMDSQL, S.FIELDCODE KEYNAME " & vbNewLine _
                                & "FROM FLDMASTER FL, V_SEARCHCD S " & vbNewLine _
                                & "WHERE FL.SEARCHCODE = S.SEARCHCODE AND FL.SRMODCODE IS NOT NULL AND S.KEY = 'Y' " & vbNewLine _
                                & "    AND FL.OBJNAME = '" & Me.ObjectName & "' AND FL.FLDNAME = '" & pv_MskCtrl.Tag & "' AND ROWNUM <= 1 "
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)
                v_xmlDoc = New XmlDocumentEx
                v_xmlDoc.LoadXml(v_strObjMsg)
                If Not v_xmlDoc Is Nothing Then
                    v_nodeList = v_xmlDoc.SelectNodes("/ObjectMessage/ObjData")
                    For i As Integer = 0 To v_nodeList.Count - 1
                        For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                            With v_nodeList.Item(i).ChildNodes(j)
                                If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "SEARCHCMDSQL" Then
                                    v_SearchCmdSQL = .InnerText.ToString
                                End If
                                If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "KEYNAME" Then
                                    v_strKeyName = .InnerText.ToString
                                End If
                            End With
                        Next
                    Next
                End If

                If v_SearchCmdSQL.Length > 0 And pv_MskCtrl.Text.Trim.Length > 0 Then
                    v_SearchCmdSQL = v_SearchCmdSQL.Replace("<$TELLERID>", Me.TellerId)
                    v_SearchCmdSQL = v_SearchCmdSQL.Replace("<$BUSDATE>", Me.BusDate)
                    If UserLanguage = "EN" Then
                        v_SearchCmdSQL = v_SearchCmdSQL.Replace("<@CDCONTENT>", "EN_CDCONTENT")
                    Else
                        v_SearchCmdSQL = v_SearchCmdSQL.Replace("<@CDCONTENT>", "CDCONTENT")
                    End If
                    v_SearchCmdSQL = v_SearchCmdSQL.Replace("<$BRID>", Me.BranchId)
                    v_SearchCmdSQL = v_SearchCmdSQL.Replace("<$HO_BRID>", HO_BRID)

                    If pv_MskCtrl.Tag = "SCUSTODYCD" Or pv_MskCtrl.Tag = "BCUSTODYCD" Then
                        v_strCmdSQL = "select replace(CUSTID,'.','') CUSTID, FULLNAME from (" & v_SearchCmdSQL & ") where " & v_strKeyName & " = '" & pv_MskCtrl.Text.Trim.ToUpper & "'"
                    Else
                        v_strCmdSQL = "select * from (" & v_SearchCmdSQL & ") where " & v_strKeyName & " = '" & pv_MskCtrl.Text.Trim.ToUpper & "'"
                    End If


                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                    v_ws.Message(v_strObjMsg)
                    v_xmlDoc = New XmlDocumentEx
                    v_xmlDoc.LoadXml(v_strObjMsg)
                    If Not v_xmlDoc Is Nothing Then
                        v_nodeList = v_xmlDoc.SelectNodes("/ObjectMessage/ObjData")
                        v_lngCount = v_nodeList.Count
                        If v_lngCount = 0 Then
                            MessageBox.Show(ResourceManager.GetString("ERR_DATA_NOTFOUND"), Me.Text, MessageBoxButtons.OK)
                            pv_MskCtrl.Focus()
                            Return False
                        Else
                            pv_MskCtrl.Text = pv_MskCtrl.Text.Trim.ToUpper
                        End If

                        'Xu ly fill data tu searchcode
                        If pv_MskCtrl.Tag = "SCUSTODYCD" Then
                            For i As Integer = 0 To v_nodeList.Count - 1
                                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                                    With v_nodeList.Item(i).ChildNodes(j)
                                        If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "CUSTID" Then
                                            txtSCUSTID.Text = .InnerText.ToString
                                        End If
                                        If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "FULLNAME" Then
                                            txtSFULLNAME.Text = .InnerText.ToString
                                        End If

                                    End With
                                Next
                            Next

                        ElseIf pv_MskCtrl.Tag = "BCUSTODYCD" Then
                            For i As Integer = 0 To v_nodeList.Count - 1
                                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                                    With v_nodeList.Item(i).ChildNodes(j)
                                        If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "CUSTID" Then
                                            txtBCUSTID.Text = .InnerText.ToString
                                        End If
                                        If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "FULLNAME" Then
                                            txtBFULLNAME.Text = .InnerText.ToString
                                        End If

                                    End With
                                Next
                            Next

                        ElseIf pv_MskCtrl.Tag = "SYMBOL" Then
                            For i As Integer = 0 To v_nodeList.Count - 1
                                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                                    With v_nodeList.Item(i).ChildNodes(j)
                                        If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "CODEID" Then
                                            txtCODEID.Text = .InnerText.ToString
                                        End If

                                    End With
                                Next
                            Next

                        ElseIf pv_MskCtrl.Tag = "SBANKID" Then
                            For i As Integer = 0 To v_nodeList.Count - 1
                                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                                    With v_nodeList.Item(i).ChildNodes(j)
                                        If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "BANKNAME" Then
                                            lblSBANKID_REF.Text = .InnerText.ToString
                                        End If

                                    End With
                                Next
                            Next
                        End If

                    
                    End If

                End If




            End If


            Return True
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message & vbNewLine _
                         & "v_strCmdSQL: " & v_strCmdSQL, EventLogEntryType.Error)
            MessageBox.Show(ex.Message)
        Finally
            v_ws = Nothing

        End Try
        Return False
    End Function
    
    Private Sub getDDAccountList(ByRef pv_ctrl As AppCore.ComboBoxEx, ByRef pv_custodycd As String, ByRef pv_accounttype As String)

        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strCmdSQL As String
        Try
            If Not txtBCUSTODYCD.Text Is Nothing AndAlso Len(txtBCUSTODYCD.Text.Trim) >= 10 Then
                'Lay Thong tin DDACCTNO cho combobox.
                v_strCmdSQL = "SELECT FILTERCD, VALUECD, VALUE, DISPLAY, EN_DISPLAY " & vbNewLine _
                            & "FROM VW_CFMAST_DDMAST_ACTIVE mst" & vbNewLine _
                            & "WHERE mst.CUSTODYCD = '" & pv_custodycd.Trim.ToUpper & "' AND mst.ACCOUNTTYPE = '" & pv_accounttype & "'" & vbNewLine _
                            & "ORDER BY mst.VALUE"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)
                FillComboEx(v_strObjMsg, pv_ctrl, "", Me.UserLanguage)
                If pv_ctrl.Items.Count > 0 Then
                    pv_ctrl.SelectedIndex = 0
                End If
            Else
                pv_ctrl.Clears()
            End If

            

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message & vbNewLine _
                         & "v_strCmdSQL: " & v_strCmdSQL, EventLogEntryType.Error)
            MessageBox.Show(ex.Message)
        Finally
            v_ws = Nothing
        End Try
    End Sub

    Private Sub txtSCUSTODYCD_Validating(sender As Object, e As EventArgs) Handles txtSCUSTODYCD.Validating
        If Not VerifyRuleMskCtrl(txtSCUSTODYCD) Then
            txtSCUSTID.Text = ""
            txtSFULLNAME.Text = ""
        End If
    End Sub

    Private Sub txtBCUSTODYCD_TextChanged(sender As Object, e As EventArgs) Handles txtBCUSTODYCD.TextChanged
        getDDAccountList(cboBDDACCTNO_ESCROW, txtBCUSTODYCD.Text, "004")
        getDDAccountList(cboBDDACCTNO_IICA, txtBCUSTODYCD.Text, "001")
    End Sub

    Private Sub txtBCUSTODYCD_Validating(sender As Object, e As EventArgs) Handles txtBCUSTODYCD.Validating
        If Not VerifyRuleMskCtrl(txtBCUSTODYCD) Then
            cboBDDACCTNO_ESCROW.Clears()
            cboBDDACCTNO_IICA.Clears()
            txtBCUSTID.Text = ""
            txtBFULLNAME.Text = ""
        End If
    End Sub

    Private Sub txtSYMBOL_Validating(sender As Object, e As EventArgs) Handles txtSYMBOL.Validating
        If Not VerifyRuleMskCtrl(txtSYMBOL) Then
            txtCODEID.Text = ""
        End If
    End Sub
    Private Sub txtSBANKID_Validating(sender As Object, e As EventArgs) Handles txtSBANKID.Validating
        If Not VerifyRuleMskCtrl(txtSBANKID) Then
            lblSBANKID_REF.Text = ""
        End If
    End Sub

    
    Private Sub txtBLKRATE_TextChanged(sender As Object, e As EventArgs) Handles txtBLKRATE.TextChanged
        If IsNumeric(txtBLKRATE.Text) And IsNumeric(txtAMT.Text) Then
            txtBLKAMT.Text = Format(Math.Round(CDbl(txtAMT.Text) * CDbl(txtBLKRATE.Text) / 100), gc_FORMAT_NUMBER_0)
        Else
            txtBLKAMT.Text = "0"
        End If
    End Sub

    Private Sub txtAMT_TextChanged(sender As Object, e As EventArgs) Handles txtAMT.TextChanged
        If IsNumeric(txtBLKRATE.Text) And IsNumeric(txtAMT.Text) Then
            txtBLKAMT.Text = Format(Math.Round(CDbl(txtAMT.Text) * CDbl(txtBLKRATE.Text) / 100), gc_FORMAT_NUMBER_0)
        Else
            txtBLKAMT.Text = "0"
        End If
    End Sub
End Class