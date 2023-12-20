Imports AppCore
Imports CommonLibrary
Imports Xceed.Grid.Collections
Imports Xceed.Grid.Editors
Imports System.Xml
Imports System.Configuration.ConfigurationSettings

Public Class frmREAFLNK

    Public MessageData As String
    Private mv_strIpAddress As String
    Private mv_strWsName As String
    Private mv_strCustID As String
    Private mv_arrObjFldVals() As CFieldVal
    Private mv_xmlMGTYPE As XmlDocumentEx

    Public Property CustID() As String
        Get
            Return mv_strCustID
        End Get
        Set(ByVal Value As String)
            mv_strCustID = Value
        End Set
    End Property
    Public Property IpAddress() As String
        Get
            Return mv_strIpAddress
        End Get
        Set(ByVal Value As String)
            mv_strIpAddress = Value
        End Set
    End Property
    Public Property WsName() As String
        Get
            Return mv_strWsName
        End Get
        Set(ByVal Value As String)
            mv_strWsName = Value
        End Set
    End Property


    Public Overrides Sub OnInit()
        ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & Me.Name & "-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())

        Me.cboLink.Visible = False
        Me.tbcHidenTab.TabPages.Add(tpHidenTab)
        Me.tbcREAFLNK.TabPages.Remove(tpHidenTab)

        MyBase.OnInit()

        Me.lblREFULLNAMEText.Text = String.Empty
        Me.lblFUREFULLNAMEText.Text = String.Empty
        Me.lblREFURFULLNAMEText.Text = String.Empty
        LoadUserInterface(Me)
        'Dim v_daysfuture As Double = Convert.ToDouble(Me.txtDAYSFUTURE.Text.ToString())
        If ExeFlag = ExecuteFlag.AddNew Then

            'DieuNDA 28/12/2016 Revert phan cua Vu
            ''Vutn 14/11/2016
            ''Truong “So ngay qua MG tuong lai” mac dinh = “10000” => dtpTODATE
            'Me.dtpTODATE.Value = Me.dtpFRDATE.Value.AddDays(10000)
            ''End Vutn
            Dim v_daysfuture As Double = Convert.ToDouble(Me.txtDAYSFUTURE.Text.ToString())
            Me.dtpTODATE.Value = Me.dtpFRDATE.Value.AddDays(v_daysfuture)
            'End DieuNDA 28/12/2016 Revert phan cua Vu
            Me.txtAFACCTNO.Text = Me.CustID
        End If

    End Sub

    Overrides Sub LoadUserInterface(ByRef pv_ctrl As Windows.Forms.Control)
        MyBase.LoadUserInterface(pv_ctrl)
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


    Public Overrides Sub OnSave()
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strClause As String
            Dim v_strErrorSource, v_strErrorMessage As String
            Dim v_lngErrorCode As Long
            Dim v_strObjMsg, v_strSQL, v_strFLDNAME, v_strVALUE, v_strchk As String
            Dim i, j As Integer
            Dim frmResult As DialogResult
            Cursor.Current = Cursors.WaitCursor
            MyBase.OnSave()

            'Kiem tra du lieu
            If Not DoDataExchange(True) Then
                Exit Sub
            End If

            Select Case ExeFlag
                Case ExecuteFlag.AddNew
                    '21/05/2018 DieuNDA: Them doan canh bao bieu phi dang dong
                    v_strSQL = "select nvl(count(*),0) CHK from remast where ACCTNO = '" & Trim(txtREACCTNO.Text) & "' and status = 'C' "
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQL)
                    v_ws.Message(v_strObjMsg)

                    v_xmlDocument.LoadXml(v_strObjMsg)
                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                    If v_nodeList.Count > 0 Then
                        For i = 0 To v_nodeList.Count - 1
                            For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                                With v_nodeList.Item(i).ChildNodes(j)
                                    'Ghi nhận thuật toán để kiểm tra và tính toán cho từng trư?ng c�ủa giao dịch
                                    v_strVALUE = .InnerText.ToString
                                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                    Select Case Trim(v_strFLDNAME)
                                        Case "CHK"
                                            v_strchk = CInt(Trim(v_strVALUE))

                                    End Select
                                End With
                            Next
                        Next


                        If v_strchk > 0 Then
                            frmResult = MsgBox(ResourceManager.GetString("RemastIsClosed"), MsgBoxStyle.Information + MsgBoxStyle.OkCancel, gc_ApplicationTitle)
                            If frmResult <> Windows.Forms.DialogResult.OK Then
                                Exit Sub
                            End If
                        End If

                    End If
                    'End 21/05/2018 DieuNDA

                    v_strObjMsg = BuildXMLObjMsg(Me.BusDate, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdd, , , , gc_AutoIdUsed, , , , , , Me.ParentObjName, Me.ParentClause)
                    BuildXMLObjData(mv_dsInput, v_strObjMsg)
                    v_lngErrorCode = v_ws.Message(v_strObjMsg)

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
                            mv_dsOldInput = mv_dsInput
                        Case SaveButtonType.OKButton
                            Me.DialogResult = DialogResult.OK
                            MyBase.OnClose()
                    End Select
                Case ExecuteFlag.Edit
                    Select Case KeyFieldType
                        Case "C"
                            v_strClause = KeyFieldName & " = '" & KeyFieldValue & "'"
                        Case "D"
                            v_strClause = KeyFieldName & " = TO_DATE('" & KeyFieldValue & "', '" & gc_FORMAT_DATE & "')"
                        Case "N"
                            v_strClause = KeyFieldName & " = " & KeyFieldValue.ToString()
                    End Select

                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionEdit, , v_strClause, , , , , , , , Me.ParentObjName, Me.ParentClause)
                    BuildXMLObjData(mv_dsInput, v_strObjMsg, mv_dsOldInput, ExecuteFlag.Edit)
                    v_lngErrorCode = v_ws.Message(v_strObjMsg)
                    'Update truong CUSTODYCD vao CFMAST
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
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Sub


    Private Function ControlValidation(Optional ByVal pv_blnSaved As Boolean = False) As Boolean
        Try
            If pv_blnSaved Then
                If Not Me.txtREACCTNO.Text.Length > 0 Then
                    MsgBox(ResourceManager.GetString("REACCTNO_INVALID"), MsgBoxStyle.Information, Me.Text)
                    Me.txtREACCTNO.Focus()
                    Return False
                End If
                If Me.dtpFRDATE.Value < CDate(Me.BusDate) OrElse Me.dtpFRDATE.Value >= Me.dtpTODATE.Value Then
                    MsgBox(ResourceManager.GetString("FRDATE_INVALID"), MsgBoxStyle.Information, Me.Text)
                    Me.txtREACCTNO.Focus()
                    Return False
                End If
                If Me.dtpTODATE.Value < CDate(Me.BusDate) OrElse Me.dtpFRDATE.Value >= Me.dtpTODATE.Value Then
                    MsgBox(ResourceManager.GetString("TODATE_INVALID"), MsgBoxStyle.Information, Me.Text)
                    Me.txtREACCTNO.Focus()
                    Return False
                End If
                Return MyBase.VerifyRules
            End If
            Return True
        Catch ex As Exception
            Throw ex
            Return False
        Finally
        End Try
    End Function

    Private Sub txtREACCTNO_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtREACCTNO.KeyUp
        'Select e.KeyCode
        'Case Keys.F5
        '    Dim frm As New frmSearch(Me.UserLanguage)
        '    'ResetScreen(Me)
        '    frm.TableName = "RECF_NOTDG"
        '    frm.ModuleCode = "RE"
        '    frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
        '    frm.IsLocalSearch = gc_IsNotLocalMsg
        '    frm.IsLookup = "Y"
        '    frm.SearchOnInit = False
        '    frm.BranchId = Me.BranchId
        '    frm.TellerId = Me.TellerId
        '    frm.ShowDialog()
        '    If frm.ReturnValue Is Nothing Then
        '        Me.txtREACCTNO.Text = ""
        '    Else
        '        Me.txtREACCTNO.Text = Trim(frm.ReturnValue.Replace(".", ""))
        '    End If

        '    frm.Dispose()
        'End Select
    End Sub

    Private Sub txtFUREACCTNO_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFUREACCTNO.KeyUp
        'Select Case e.KeyCode
        'Case Keys.F5
        'Dim frm As New frmSearch(Me.UserLanguage)
        'ResetScreen(Me)
        'frm.TableName = "RECF_INTRO"
        'frm.ModuleCode = "RE"
        'frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
        'frm.IsLocalSearch = gc_IsNotLocalMsg
        'frm.IsLookup = "Y"
        'frm.SearchOnInit = False
        'frm.BranchId = Me.BranchId
        'frm.TellerId = Me.TellerId
        'frm.ShowDialog()
        'Me.txtFUREACCTNO.Text = Trim(frm.ReturnValue.Replace(".", ""))
        'frm.Dispose()
        'End Select
    End Sub

    Private Sub LoadREInfo(ByVal pv_strREACCTNO As String)
        Try
            If pv_strREACCTNO.Length > 0 Then

                Dim v_nodeList As Xml.XmlNodeList
                Dim v_xmlDocument As New Xml.XmlDocument
                Dim v_strValue, v_strFLDNAME, v_strTEXT, v_strMINBRATIO, v_strMAXBRATIO As String, i, j As Integer
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                Dim v_strCmdSQL As String, v_strObjMsg As String
                v_strCmdSQL = "SELECT (CF.CUSTID||RF.REACTYPE) REACCT, CF.AUTOID REFRECFLNKID, CFMAST.FULLNAME REFULLNAME, (CFMAST.FULLNAME || '/'|| TYP.TYPENAME || '/'||A2.CDCONTENT) DESC_TYPE, CF.CUSTID " & ControlChars.CrLf _
                                & "FROM RECFDEF RF, RETYPE TYP, ALLCODE A0, ALLCODE A1, ALLCODE A2, RECFLNK CF, CFMAST " & ControlChars.CrLf _
                                & "WHERE A0.CDTYPE='RE' AND A0.CDNAME='REROLE' AND A0.CDVAL=TYP.REROLE " & ControlChars.CrLf _
                                & "        AND A2.CDTYPE = 'RE' AND A2.CDNAME = 'AFSTATUS' AND A2.CDVAL = TYP.AFSTATUS " & ControlChars.CrLf _
                                & "        AND A1.CDTYPE='RE' AND A1.CDNAME='RETYPE' AND A1.CDVAL=TYP.RETYPE " & ControlChars.CrLf _
                                & "        AND RF.REACTYPE=TYP.ACTYPE " & ControlChars.CrLf _
                                & "        AND RF.REFRECFLNKID = CF.AUTOID " & ControlChars.CrLf _
                                & "        AND CF.CUSTID = CFMAST.CUSTID " & ControlChars.CrLf _
                                & "        AND CF.STATUS = 'A' " & ControlChars.CrLf _
                                & "        AND (CF.CUSTID||RF.REACTYPE) = '" & pv_strREACCTNO & "' "
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                If v_nodeList.Count > 0 Then
                    For i = 0 To v_nodeList.Count - 1
                        For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                            With v_nodeList.Item(i).ChildNodes(j)
                                'Ghi nhận thuật toán để kiểm tra và tính toán cho từng trư?ng c�ủa giao dịch
                                v_strValue = .InnerText.ToString
                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                Select Case Trim(v_strFLDNAME)
                                    Case "REFRECFLNKID"
                                        Me.txtREFRECFLNKID.Text = Trim(v_strValue)
                                    Case "REFULLNAME"
                                        Me.lblREFULLNAMEText.Text = Trim(v_strValue)

                                End Select
                            End With
                        Next
                    Next
                Else
                    If ExeFlag = ExecuteFlag.AddNew OrElse ExeFlag = ExecuteFlag.Edit Then
                        MsgBox(ResourceManager.GetString("REACCTNO_INVALID"), MsgBoxStyle.Information, Me.Text)
                        Me.txtREACCTNO.Text = String.Empty
                        Me.txtREACCTNO.Focus()

                    End If
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub LoadFUREInfo(ByVal pv_strREACCTNO As String)
        Try
            If pv_strREACCTNO.Length > 0 Then

                Dim v_nodeList As Xml.XmlNodeList
                Dim v_xmlDocument As New Xml.XmlDocument
                Dim v_strValue, v_strFLDNAME, v_strTEXT, v_strMINBRATIO, v_strMAXBRATIO As String, i, j As Integer
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                Dim v_strCmdSQL As String, v_strObjMsg As String
                v_strCmdSQL = "SELECT (CF.CUSTID||RF.REACTYPE) REACCT, CF.AUTOID FUREFRECFLNKID, CFMAST.FULLNAME FUREFULLNAME, (CFMAST.FULLNAME || '/'|| TYP.TYPENAME || '/'||A2.CDCONTENT) DESC_TYPE, CF.CUSTID " & ControlChars.CrLf _
                                & "FROM RECFDEF RF, RETYPE TYP, ALLCODE A0, ALLCODE A1, ALLCODE A2, RECFLNK CF, CFMAST " & ControlChars.CrLf _
                                & "WHERE A0.CDTYPE='RE' AND A0.CDNAME='REROLE' AND A0.CDVAL=TYP.REROLE " & ControlChars.CrLf _
                                & "        AND A2.CDTYPE = 'RE' AND A2.CDNAME = 'AFSTATUS' AND A2.CDVAL = TYP.AFSTATUS " & ControlChars.CrLf _
                                & "        AND A1.CDTYPE='RE' AND A1.CDNAME='RETYPE' AND A1.CDVAL=TYP.RETYPE " & ControlChars.CrLf _
                                & "        AND RF.REACTYPE=TYP.ACTYPE " & ControlChars.CrLf _
                                & "        AND RF.REFRECFLNKID = CF.AUTOID " & ControlChars.CrLf _
                                & "        AND CF.CUSTID = CFMAST.CUSTID AND TYP.REROLE = 'RD' " & ControlChars.CrLf _
                                & "        AND CF.STATUS = 'A' " & ControlChars.CrLf _
                                & "        AND (CF.CUSTID||RF.REACTYPE) = '" & pv_strREACCTNO & "' "
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                If v_nodeList.Count > 0 Then
                    For i = 0 To v_nodeList.Count - 1
                        For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                            With v_nodeList.Item(i).ChildNodes(j)
                                'Ghi nhận thuật toán để kiểm tra và tính toán cho từng trư?ng c�ủa giao dịch
                                v_strValue = .InnerText.ToString
                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                Select Case Trim(v_strFLDNAME)
                                    Case "FUREFRECFLNKID"
                                        Me.txtFUREFRECFLNKID.Text = Trim(v_strValue)
                                    Case "FUREFULLNAME"
                                        Me.lblFUREFULLNAMEText.Text = Trim(v_strValue)

                                End Select
                            End With
                        Next
                    Next
                Else
                    If ExeFlag = ExecuteFlag.AddNew OrElse ExeFlag = ExecuteFlag.Edit Then
                        MsgBox(ResourceManager.GetString("FUREACCTNO_INVALID"), MsgBoxStyle.Information, Me.Text)
                        Me.txtFUREACCTNO.Text = String.Empty
                        Me.txtFUREACCTNO.Focus()
                    End If
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtREACCTNO_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtREACCTNO.Leave
        If Me.txtREACCTNO.Text.Length > 0 Then
            LoadREInfo(Me.txtREACCTNO.Text.Trim)
        End If
    End Sub

    Private Sub txtFUREACCTNO_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.txtFUREACCTNO.Text.Length > 0 Then
            LoadFUREInfo(Me.txtFUREACCTNO.Text.Trim)
        End If
    End Sub


    Private Sub txtDAYSFUTURE_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDAYSFUTURE.Leave
        If Me.txtDAYSFUTURE.Text.Length > 0 Then
            Dim v_daysfuture As Double = Convert.ToDouble(Me.txtDAYSFUTURE.Text.ToString())
            Me.dtpTODATE.Value = Me.dtpFRDATE.Value.AddDays(v_daysfuture)
        End If
    End Sub

    Private Sub cboMGTYPE_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMGTYPE.SelectedValueChanged
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strACTYPE, v_strSQLString, v_strCOREBANK, v_strBANKACCT, v_strBANKCODE, v_strMAXAVLAMT, v_strAVLADVANCE As String
            Dim v_dblBALDEFOVD As Long
            Dim v_lngCount As Long
            'Cache thong tin ve cac tieu khoan giao dich cua khach hang
            v_strSQLString = "SELECT * FROM ALLCODE WHERE CDTYPE = 'RE' AND CDNAME = 'MGTYPE' AND CDVAL ='B' AND CDVAL = '" & Me.cboMGTYPE.SelectedValue & "'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString)
            v_ws.Message(v_strObjMsg)

            mv_xmlMGTYPE = New XmlDocumentEx
            mv_xmlMGTYPE.LoadXml(v_strObjMsg)
            If Not mv_xmlMGTYPE Is Nothing Then
                v_nodeList = mv_xmlMGTYPE.SelectNodes("/ObjectMessage/ObjData")
                v_lngCount = v_nodeList.Count
                If v_lngCount = 0 Then
                    Me.txtREACCTNONEW.Enabled = False
                Else
                    Me.txtREACCTNONEW.Enabled = True
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_ws = Nothing
        End Try
    End Sub
End Class
