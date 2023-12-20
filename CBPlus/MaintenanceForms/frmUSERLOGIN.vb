Imports CommonLibrary
Imports System.Xml.XmlNode
Imports System.Xml
Imports TestBase64
Imports ZetaCompressionLibrary
Imports System.IO
Imports AppCore
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO.File
Imports System.IO.Path
Imports System.Windows.Forms.Application
Imports System.Text
Imports System.Globalization
Imports System.Configuration
Imports System.Threading
Imports log4net
Imports DevExpress.XtraPdfViewer
Imports DevExpress.XtraEditors

Public Class frmUSERLOGIN
    Inherits AppCore.frmXtraMaintenance
#Region "Declare constants and variables"
    Public mv_strAUTID As String
    Public mv_strREFID As String
    Private mv_arrImageUpload() As ImageUpload
    Private mv_CurrImageUpload As ImageUpload
    Private mv_srcFileName As String
    Private mv_srcFiletype As String
    Private mv_base64 As String

    Public RefeshData As Action = Nothing

    Private c_split_char As Char = ";"
    Dim mv_arrUnAssLstSTC As New ArrayList
    Dim mv_arrAssLstSTC As New ArrayList
#Region "Control Hinden"
    'Friend WithEvents txtAUTOID As TextEdit
    Friend WithEvents txtROLEView As TextEdit
    Friend WithEvents txtROLEMaker As TextEdit
    Friend WithEvents txtROLEApprove As TextEdit


    Friend WithEvents txtLISTCUSTODYCD As TextEdit
#End Region

#End Region

#Region "private sub"
    Public Overrides Sub OnInit()

        ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & Me.Name & "-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LocalObject = gc_IsNotLocalMsg
        InitControlHinden()
        MyBase.OnInit()
        LoadUserInterface(Me)
        FormInit()
        'LoadLstGTC()
        If ExeFlag <> ExecuteFlag.AddNew Then
            lueROLE.Enabled = False
            teREFFAMEMBERID.Enabled = False
            txtUSERNAME.Enabled = False
            subFieldBaseOnRole(lueROLE.EditValue)
            If lueROLE.EditValue <> "Other" Then
                LoadLstGTC()
            End If
        End If

    End Sub

    Private Sub LoadLstGTC()
        Dim v_ws As New BDSDeliveryManagement
        Try
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_xmlNodeList As Xml.XmlNodeList
            Dim v_strSQL As String

            Dim tlgroup As String = ""

            v_strSQL = "SELECT TLGROUP FROM TLPROFILES WHERE TLID = '" & Me.TellerId & "'"
            Dim v_strMsgObj As String = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, Me.ObjectName, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strMsgObj)

            v_xmlDocument.LoadXml(v_strMsgObj)
            v_xmlNodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            Dim v_strFLDNAME, v_strValue As String
            For i As Integer = 0 To v_xmlNodeList.Count - 1
                For j As Integer = 0 To v_xmlNodeList.Item(i).ChildNodes.Count - 1
                    With v_xmlNodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString

                        Select Case Trim(v_strFLDNAME)
                            Case "TLGROUP"
                                tlgroup = Trim(v_strValue)
                        End Select
                    End With
                Next
            Next

            If lueROLE.EditValue = "GCB" Then
                v_strSQL = "select CF.CUSTODYCD, CF.FULLNAME " & ControlChars.CrLf _
                         & "from cfmast cf ,(select *from famembers where roles = 'GCB' AND activestatus ='Y') fa " & ControlChars.CrLf _
                         & "where cf.status <> 'C' " & ControlChars.CrLf _
                         & "and cf.gcbid = fa.autoid " & ControlChars.CrLf _
                         & "and fa.shortname = '" & teREFFAMEMBERID.Text & "' " & ControlChars.CrLf _
                         & "and (CASE WHEN '" & tlgroup & "' = '013' THEN 'Y' ELSE CF.SUPEBANK END) = CF.SUPEBANK "
            ElseIf lueROLE.EditValue = "AMC" Then
                v_strSQL = "select CF.CUSTODYCD, CF.FULLNAME " & ControlChars.CrLf _
                         & "from cfmast cf ,(select *from famembers where roles = 'AMC' AND activestatus ='Y') fa " & ControlChars.CrLf _
                         & "where cf.status <> 'C' " & ControlChars.CrLf _
                         & "and cf.amcid = fa.autoid " & ControlChars.CrLf _
                         & "and fa.shortname = '" & teREFFAMEMBERID.Text & "' " & ControlChars.CrLf _
                         & "and (CASE WHEN '" & tlgroup & "' = '013' THEN 'Y' ELSE CF.SUPEBANK END) = CF.SUPEBANK "
            ElseIf lueROLE.EditValue = "CTCK" Then
                v_strSQL = "select CF.CUSTODYCD, CF.FULLNAME " & ControlChars.CrLf _
                         & "from cfmast cf , (select *from famembers where roles = 'BRK' AND activestatus ='Y') fa, fabrokerage fab " & ControlChars.CrLf _
                         & "where cf.status <> 'C' " & ControlChars.CrLf _
                         & "and cf.custodycd = fab.custodycd " & ControlChars.CrLf _
                         & "and fab.brkid = fa.autoid " & ControlChars.CrLf _
                         & "and fa.shortname = '" & teREFFAMEMBERID.Text & "' " & ControlChars.CrLf _
                         & "and (CASE WHEN '" & tlgroup & "' = '013' THEN 'Y' ELSE CF.SUPEBANK END) = CF.SUPEBANK "
            ElseIf lueROLE.EditValue = "AP" Then
                v_strSQL = "select dd.REFCASAACCT, dd.CCYCD, dd.ACCOUNTTYPE " & ControlChars.CrLf _
                         & "from ddmast dd, cfmast cf " & ControlChars.CrLf _
                         & "where dd.status <> 'C' " & ControlChars.CrLf _
                         & "and cf.status <> 'C' " & ControlChars.CrLf _
                         & "and cf.custodycd = dd.custodycd " & ControlChars.CrLf _
                         & "and cf.custodycd = '" & teREFFAMEMBERID.Text & "' " & ControlChars.CrLf _
                         & "and (CASE WHEN '" & tlgroup & "' = '013' THEN 'Y' ELSE CF.SUPEBANK END) = CF.SUPEBANK "
            ElseIf lueROLE.EditValue = "Other" Then
                v_strSQL = "SELECT CF.CUSTODYCD, CF.FULLNAME FROM CFMAST CF WHERE CF.STATUS ='A' and (CASE WHEN '" & tlgroup & "' = '013' THEN 'Y' ELSE CF.SUPEBANK END) = CF.SUPEBANK "
            Else
                v_strSQL = "select CF.CUSTODYCD, CF.FULLNAME from CFMAST CF WHERE CUSTODYCD = '" & teREFFAMEMBERID.Text & "' and (CASE WHEN '" & tlgroup & "' = '013' THEN 'Y' ELSE CF.SUPEBANK END) = CF.SUPEBANK "
            End If


            v_strMsgObj = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, Me.ObjectName, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strMsgObj)


            v_xmlDocument.LoadXml(v_strMsgObj)
            v_xmlNodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If ExeFlag = ExecuteFlag.AddNew Then
                mv_arrUnAssLstSTC.Clear()
                lbLstSTC.Items.Clear()
            End If

            Dim v_strCUSTODYCD, v_strFULLNAME, v_strREFCASAACCT, v_strCCYCD, v_strACCOUNTTYPE As String
            For i As Integer = 0 To v_xmlNodeList.Count - 1
                v_strCUSTODYCD = String.Empty
                v_strFULLNAME = String.Empty
                v_strREFCASAACCT = String.Empty
                v_strCCYCD = String.Empty
                v_strACCOUNTTYPE = String.Empty

                For j As Integer = 0 To v_xmlNodeList.Item(i).ChildNodes.Count - 1
                    With v_xmlNodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString

                        Select Case Trim(v_strFLDNAME)
                            Case "CUSTODYCD"
                                v_strCUSTODYCD = Trim(v_strValue)
                            Case "FULLNAME"
                                v_strFULLNAME = Trim(v_strValue)
                                'mv_arrUnAssLstSTC.Add(Trim(v_strValue))
                            Case "REFCASAACCT"
                                v_strREFCASAACCT = Trim(v_strValue)
                            Case "CCYCD"
                                v_strCCYCD = Trim(v_strValue)
                            Case "ACCOUNTTYPE"
                                v_strACCOUNTTYPE = Trim(v_strValue)
                        End Select
                    End With
                Next
                If lueROLE.EditValue = "AP" Then
                    mv_arrUnAssLstSTC.Add(New ValueDescriptionPair(v_strREFCASAACCT, v_strREFCASAACCT & " - " & v_strCCYCD & " - " & v_strACCOUNTTYPE))
                Else
                    If Len(v_strCUSTODYCD) > 0 Then
                        mv_arrUnAssLstSTC.Add(New ValueDescriptionPair(v_strCUSTODYCD, v_strCUSTODYCD & " - " & v_strFULLNAME))
                    End If
                End If
            Next

            If ExeFlag <> ExecuteFlag.AddNew Then
                Dim l_strSTC As String = mv_dsOldInput.Tables(0).Rows(0)("LISTCUSTODYCD").ToString
                If Len(l_strSTC) > 0 Then
                    Dim l_arrSTC = l_strSTC.Split(c_split_char)
                    For Each stc As String In l_arrSTC
                        For Each obj As ValueDescriptionPair In mv_arrUnAssLstSTC
                            If stc = obj.Value Then
                                mv_arrAssLstSTC.Add(obj)
                                mv_arrUnAssLstSTC.Remove(obj)
                                Exit For
                            End If
                        Next

                    Next
                End If
            End If


            For Each stc As ValueDescriptionPair In mv_arrUnAssLstSTC
                lbLstSTC.Items.Add(stc)
            Next
            For Each stc As ValueDescriptionPair In mv_arrAssLstSTC
                lbAssSTC.Items.Add(stc)
            Next
            If ExeFlag = ExecuteFlag.AddNew Then
                If lbAssSTC.Items.Count > 0 Then
                    For stc As Integer = 0 To lbAssSTC.Items.Count - 1
                        For Each obj As ValueDescriptionPair In mv_arrUnAssLstSTC
                            If lbAssSTC.Items(stc).ToString = obj.ToString Then
                                mv_arrUnAssLstSTC.Remove(obj)
                                Exit For
                            End If
                        Next
                    Next
                    lbLstSTC.Items.Clear()
                    If lueROLE.EditValue = "AP" Then
                        lbAssSTC.Items.Clear()
                    End If
                    lbLstSTC.Items.AddRange(mv_arrUnAssLstSTC.ToArray)
                End If
            End If
        Catch ex As Exception
            LogError.Write("frmUSERLOGIN.LoadLstGTC()::" & ex.Message, EventLogEntryType.Error)
        End Try
    End Sub

    Private Sub InitControlHinden()
        'txtAUTOID = New TextEdit()
        'txtAUTOID.Tag = "AUTOID"
        'txtAUTOID.Name = "txtAUTOID"
        'Me.Controls.Add(txtAUTOID)

        txtROLEView = New TextEdit()
        txtROLEView.Tag = "ROLECD"
        txtROLEView.Name = "txtROLECD"
        Me.Controls.Add(txtROLEView)

        txtROLEMaker = New TextEdit()
        txtROLEMaker.Tag = "ROLEMAKER"
        txtROLEMaker.Name = "txtROLEMAKER"
        Me.Controls.Add(txtROLEMaker)

        txtROLEApprove = New TextEdit()
        txtROLEApprove.Tag = "ROLEAPPROVE"
        txtROLEApprove.Name = "txtROLEAPPROVE"
        Me.Controls.Add(txtROLEApprove)

        txtLISTCUSTODYCD = New TextEdit()
        txtLISTCUSTODYCD.Tag = "LISTCUSTODYCD"
        txtLISTCUSTODYCD.Name = "txtLISTCUSTODYCD"
        Me.Controls.Add(txtLISTCUSTODYCD)
    End Sub

    Private Sub FormInit()
        Dim v_strSQL As String
        Dim v_ds As New DataSet
        Dim v_strObjMsg As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement 'Dim v_ws As New BDSDelivery.BDSDelivery
        Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode
        Dim v_strValue, v_strFLDNAME As String

        LoadRoleCD()

        If ExeFlag = ExecuteFlag.AddNew Then
            'GetAUTOID()
            'txtLOGINPWD.Text = RandomString(7, True)
            'txtTRADINGPWD.Text = RandomString(7, True)

            lblREFFAMEMBERID_DESC.Text = String.Empty
        Else
            Dim roleViewArr() As String = Nothing
            Dim roleMakerArr() As String = Nothing
            Dim roleApproveArr() As String = Nothing
            If Not String.IsNullOrEmpty(txtROLEView.Text) Then
                roleViewArr = txtROLEView.Text.Split(",")
            End If

            If Not String.IsNullOrEmpty(txtROLEMaker.Text) Then
                roleMakerArr = txtROLEMaker.Text.Split(",")
            End If

            If Not String.IsNullOrEmpty(txtROLEApprove.Text) Then
                roleApproveArr = txtROLEApprove.Text.Split(",")
            End If

            Dim dtRole As DataTable = GridControlRole.DataSource
            If (dtRole IsNot Nothing AndAlso dtRole.Rows.Count > 0) Then
                For Each r As DataRow In dtRole.Rows
                    If (roleViewArr IsNot Nothing AndAlso roleViewArr.Length > 0 AndAlso roleViewArr.Contains(r("ROLE"))) Then
                        r("IS_VIEW") = True
                    End If
                    If (roleMakerArr IsNot Nothing AndAlso roleMakerArr.Length > 0 AndAlso roleMakerArr.Contains(r("ROLE"))) Then
                        r("IS_MAKER") = True
                    End If
                    If (roleApproveArr IsNot Nothing AndAlso roleApproveArr.Length > 0 AndAlso roleApproveArr.Contains(r("ROLE"))) Then
                        r("IS_APPROVE") = True
                    End If
                Next
            End If
            GridControlRole.RefreshDataSource()

            lblREFFAMEMBERID_DESC.Text = GetRefValue(teREFFAMEMBERID.EditValue)
        End If

    End Sub

    Public Function RandomString(ByVal size As Integer, ByVal lowerCase As Boolean) As String
        Dim builder As StringBuilder = New StringBuilder()
        Dim random As Random = New Random()
        Dim ch As Char

        For i As Integer = 0 To size - 1
            ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)))
            builder.Append(ch)
        Next

        If lowerCase Then Return builder.ToString().ToLower()
        Return builder.ToString()
    End Function

    Private Sub LoadRoleCD()
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strSQL As String
        If lueROLE.EditValue = "AP" Then
            v_strSQL = "select  * from allcode a where a.cdtype='SY' and a.cdname='SYROLE' and cdval = 'CB' order by a.lstodr"
        Else
            v_strSQL = "select  * from allcode a where a.cdtype='SY' and a.cdname='SYROLE' order by a.lstodr"
        End If
        Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, _
            gc_ActionInquiry, v_strSQL, , )
        v_ws.Message(v_strObjMsg)
        Dim v_nodeList As Xml.XmlNodeList
        Dim XmlDocument As New Xml.XmlDocument
        Dim v_strFLDNAME, v_strValue, v_strID, v_strFUNDNAME As String
        v_strID = String.Empty
        XmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = XmlDocument.SelectNodes("/ObjectMessage/ObjData")

        Dim dt As DataTable = New DataTable()
        dt.Columns.Add(New DataColumn("ROLE", GetType(String)))
        dt.Columns.Add(New DataColumn("IS_VIEW", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("IS_MAKER", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("IS_APPROVE", GetType(Boolean)))


        For i As Integer = 0 To v_nodeList.Count - 1
            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                With v_nodeList.Item(i).ChildNodes(j)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strValue = .InnerText.ToString

                    Select Case Trim(v_strFLDNAME)
                        Case "CDCONTENT"
                            v_strID = CStr(v_strValue).Trim
                            Dim r As DataRow = dt.NewRow()
                            r("ROLE") = v_strValue
                            dt.Rows.Add(r)
                    End Select
                End With
            Next
        Next

        GridControlRole.DataSource = dt
    End Sub

    Overrides Sub LoadUserInterface(ByRef pv_ctrl As Windows.Forms.Control)
        MyBase.LoadUserInterface(pv_ctrl)
        'Load rieng cho form
        If (ExeFlag <> ExecuteFlag.AddNew) Then
            'txtLOGINPWD.Properties.ReadOnly = True
            'txtTRADINGPWD.Properties.ReadOnly = True
            cboAUTHTYPE.Properties.ReadOnly = True
            'txtTOKENID.Properties.ReadOnly = True

        End If
        If ExeFlag = ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve Then
            Me.Panel1.Enabled = False
        End If
    End Sub

    Private Function VerifyRule(Optional ByVal pv_blnSaved As Boolean = False) As Boolean
        Try
            If pv_blnSaved Then

                If Len(teREFFAMEMBERID.EditValue) = 0 Then
                    teREFFAMEMBERID.Focus()
                    If lueROLE.EditValue = "STC" Then
                        Throw New Exception(ResourceManager.GetString("CustodycdInvalid"))
                    ElseIf lueROLE.EditValue <> "Other" Then
                        Throw New Exception(ResourceManager.GetString("RefFAMemberIdInvalid"))
                    End If
                End If
                If Len(txtEMAIL.EditValue) = 0 OrElse InStr(txtEMAIL.EditValue, "@") = 0 Then
                    txtEMAIL.Focus()
                    Throw New Exception(ResourceManager.GetString("EmailInvalid"))
                End If
                If Len(txtUSERNAME.EditValue) = 0 Then
                    txtUSERNAME.Focus()
                    Throw New Exception(ResourceManager.GetString("UserNameInvalid"))
                End If
            End If

            Return True
            'Check vali
            'Return MyBase.VerifyRules
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, gc_ApplicationTitle)
            Return False
        End Try
    End Function

    Private Sub GetAUTOID()
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strSQL As String = "SELECT SEQ_SBACTIFILE.NEXTVAL ID from DUAL"
        Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, _
            gc_ActionInquiry, v_strSQL, , )
        v_ws.Message(v_strObjMsg)
        Dim v_nodeList As Xml.XmlNodeList
        Dim XmlDocument As New Xml.XmlDocument
        Dim v_strFLDNAME, v_strValue, v_strID, v_strFUNDNAME As String
        v_strID = String.Empty
        XmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = XmlDocument.SelectNodes("/ObjectMessage/ObjData")

        For i As Integer = 0 To v_nodeList.Count - 1
            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                With v_nodeList.Item(i).ChildNodes(j)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strValue = .InnerText.ToString

                    Select Case Trim(v_strFLDNAME)
                        Case "ID"
                            v_strID = CStr(v_strValue).Trim
                            'txtAUTOID.Text = v_strID
                    End Select
                End With
            Next
        Next
    End Sub

    Public Overrides Sub OnSave()
        Dim v_strObjMsg As String

        Try
            'Update mouse pointer
            Cursor.Current = Cursors.WaitCursor

            txtROLEView.Text = ""
            txtROLEMaker.Text = ""
            txtROLEApprove.Text = ""


            Dim dtRole As DataTable = GridControlRole.DataSource
            If (dtRole IsNot Nothing) Then
                Dim drViews As DataRow() = dtRole.Select("IS_VIEW = 1")
                If (drViews.Length > 0) Then
                    For Each r As DataRow In drViews
                        txtROLEView.Text += r("ROLE") + ","
                    Next
                End If

                Dim drMakers As DataRow() = dtRole.Select("IS_MAKER = 1")
                If (drMakers.Length > 0) Then
                    For Each r As DataRow In drMakers
                        txtROLEMaker.Text += r("ROLE") + ","
                    Next
                End If

                Dim drApproves As DataRow() = dtRole.Select("IS_APPROVE = 1")
                If (drApproves.Length > 0) Then
                    For Each r As DataRow In drApproves
                        txtROLEApprove.Text += r("ROLE") + ","
                    Next
                End If
            End If

            If String.IsNullOrEmpty(txtROLEView.Text) Then
                MsgBox(ResourceManager.GetString("RequiredRoleCD"))
                Return
            End If

            If lueROLE.EditValue = "GCB" Or lueROLE.EditValue = "AMC" Then
                If lbAssSTC.Items.Count = 0 Then
                    MsgBox(ResourceManager.GetString("lbAssSTCInvalid"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    lbAssSTC.Focus()
                    Exit Sub
                End If
            End If

            If (Not String.IsNullOrEmpty(txtROLEView.Text)) Then
                txtROLEView.Text = txtROLEView.Text.Substring(0, txtROLEView.Text.Length - 1)
            End If

            If (Not String.IsNullOrEmpty(txtROLEMaker.Text)) Then
                txtROLEMaker.Text = txtROLEMaker.Text.Substring(0, txtROLEMaker.Text.Length - 1)
            End If

            If (Not String.IsNullOrEmpty(txtROLEApprove.Text)) Then
                txtROLEApprove.Text = txtROLEApprove.Text.Substring(0, txtROLEApprove.Text.Length - 1)
            End If


            If ExeFlag = ExecuteFlag.AddNew Then
                'txtTRADINGPWD.Text = TripleDesEncryptData(txtTRADINGPWD.Text)
                'txtLOGINPWD.Text = TripleDesEncryptData(txtLOGINPWD.Text)
            End If

            'Verify data 
            If (VerifyRule(True) = False) Then
                Exit Sub
            End If

            MyBase.OnSave()
            If Not DoDataExchange(True) Then
                Exit Sub
            End If
            BuildExternalField()
            Select Case ExeFlag
                Case ExecuteFlag.AddNew

                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdd, , "USERNAME = '" & txtUSERNAME.Text & "'", , gc_AutoIdUnused)
                    BuildXMLObjData(mv_dsInput, v_strObjMsg)

                    Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                    'Kiểm tra thông tin và xử lý lỗi (nếu có) từ message trả v?
                    Dim v_strErrorSource, v_strErrorMessage As String

                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage)
                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Sub
                    End If

                    MsgBox(ResourceManager.GetString("AddnewSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Me.DialogResult = DialogResult.OK
                    MyBase.OnClose()
                Case ExecuteFlag.Edit

                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionEdit, , "USERNAME = '" & txtUSERNAME.Text & "'")
                    BuildXMLObjData(mv_dsInput, v_strObjMsg, mv_dsOldInput, ExecuteFlag.Edit)

                    Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                    'Ki�ểm tra thông tin và xử lý lỗi (nếu có) từ message trả v?
                    Dim v_strErrorSource, v_strErrorMessage As String

                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage)
                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Sub
                    End If

                    MsgBox(ResourceManager.GetString("EditSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Me.DialogResult = DialogResult.OK
                    MyBase.OnClose()

            End Select
            If RefeshData IsNot Nothing Then
                Me.RefeshData()
            End If
            'Update mouse pointer
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
    Public Overrides Function DoDataExchange(Optional pv_blnSaved As Boolean = False) As Boolean
        If Not pv_blnSaved AndAlso ExeFlag <> ExecuteFlag.AddNew Then
            getUserLoginInfo()
        End If
        Return MyBase.DoDataExchange(pv_blnSaved)
    End Function
    Private Sub getUserLoginInfo()
        Try
            Dim v_ws As New BDSDeliveryManagement
            Dim v_sql As String = "SELECT ROLE FROM USERLOGIN WHERE username = '" & KeyFieldValue & "'"
            Dim v_strObjMsg As String = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, Me.ObjectName, gc_ActionInquiry, v_sql)
            v_ws.Message(v_strObjMsg)
            Dim xmlDocument As New Xml.XmlDocument
            xmlDocument.LoadXml(v_strObjMsg)

            Dim v_nodeList As Xml.XmlNodeList = xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            Dim role, v_strFLDNAME, v_strValue As String
            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString

                        Select Case Trim(v_strFLDNAME)
                            Case "ROLE"
                                role = CStr(v_strValue).Trim
                                'txtAUTOID.Text = v_strID
                        End Select
                    End With
                Next
            Next
            subFieldBaseOnRole(role)
        Catch ex As Exception
            LogError.Write("frmUSERLOGIN.getUserLoginInfo::KeyFieldValue=" & KeyFieldValue & vbNewLine & ex.Message, EventLogEntryType.Error)
        End Try
    End Sub

    Private Sub BuildExternalField()
        Dim assStc As String = String.Empty
        If lbAssSTC.Items.Count > 0 Then
            For i As Integer = 0 To lbAssSTC.Items.Count - 1
                assStc &= CType(lbAssSTC.Items(i), ValueDescriptionPair).Value & c_split_char
            Next
            assStc = assStc.Remove(Len(assStc) - 1)
            mv_dsInput.Tables(0).Rows(0)("LISTCUSTODYCD") = assStc
        End If
    End Sub

    Private Sub processDisableButton(Optional ByVal enable As Boolean = False)
        sbAssAll.Enabled = enable
        sbAssOne.Enabled = enable
        sbUnAssAll.Enabled = enable
        sbUnAssOne.Enabled = enable
    End Sub

    Public Overrides Sub OnApprv()

        Dim v_frm As New frmApprove
        v_frm.ExeFlag = ExeFlag
        v_frm.UserLanguage = UserLanguage
        v_frm.ModuleCode = ModuleCode
        v_frm.ObjectName = ObjectName
        v_frm.TableName = Mid(ObjectName, 4)
        v_frm.LocalObject = LocalObject
        v_frm.Text = Text
        v_frm.TellerId = TellerId
        v_frm.TellerRight = TellerRight
        v_frm.GroupCareBy = GroupCareBy
        v_frm.AuthString = AuthString
        v_frm.BranchId = BranchId
        v_frm.BusDate = Me.BusDate
        v_frm.KeyFieldName = KeyFieldName
        v_frm.KeyFieldType = KeyFieldType
        v_frm.KeyFieldValue = KeyFieldValue

        v_frm.LinkValue = LinkValue
        v_frm.LinkField = LinkField
        v_frm.ShowDialog()
        If v_frm.apprv = True Then
            Me.Close()
        End If
    End Sub

#End Region

#Region "event"
    Private Sub teREFFAMEMBERID_Leave(sender As Object, e As EventArgs) Handles teREFFAMEMBERID.Leave
        teREFFAMEMBERID.Text = teREFFAMEMBERID.Text.ToUpper
        lblREFFAMEMBERID_DESC.Text = GetRefValue(CType(sender, Control).Text) 'GetFundName(CType(sender, Control).Text)
        txtEMAIL.EditValue = GetEmail(CType(sender, Control).Text)
        LoadLstGTC()
    End Sub
    Private Sub lueROLE_EditValueChanged(sender As Object, e As EventArgs) Handles lueROLE.EditValueChanged
        Try
            If ExeFlag = ExecuteFlag.AddNew Then
                Dim v_role As String = lueROLE.EditValue
                subFieldBaseOnRole(v_role)
                teREFFAMEMBERID.EditValue = String.Empty
                lblREFFAMEMBERID_DESC.Text = String.Empty
                LoadRoleCD()
            End If
        Catch ex As Exception
            LogError.Write("frmUSERLOGIN.lueROLE_EditValueChanged::" & ex.Message, EventLogEntryType.Error)
        End Try
    End Sub
    Private Sub subFieldBaseOnRole(ByVal role As String)
        If role = "STC" Then
            If ExeFlag = ExecuteFlag.AddNew Then
                lcREFFAMEMBERID.Enabled = True
                teREFFAMEMBERID.Enabled = True
            End If
            lcREFFAMEMBERID.Text = ResourceManager.GetString("ROLE_STC")
            teREFFAMEMBERID.Tag = "CUSTODYCD"
            unAssignALL()
            processDisableButton()
        ElseIf role = "GCB" Then
            If ExeFlag = ExecuteFlag.AddNew Then
                lcREFFAMEMBERID.Enabled = True
                teREFFAMEMBERID.Enabled = True
            End If
            lcREFFAMEMBERID.Text = ResourceManager.GetString("ROLE_GCB")
            teREFFAMEMBERID.Tag = "REFFAMEMBERID"

            processDisableButton(True)
        ElseIf role = "AP" Then
            
            lcREFFAMEMBERID.Text = ResourceManager.GetString("ROLE_STC")
            teREFFAMEMBERID.Tag = "CUSTODYCD"
            grcSTC.Text = ResourceManager.GetString("grcAP")
            grcLstSTC.Text = ResourceManager.GetString("grcLstAP")
            grcAssSTC.Text = ResourceManager.GetString("grcAssAP")
            If ExeFlag = ExecuteFlag.AddNew Then
                lcREFFAMEMBERID.Enabled = True
                teREFFAMEMBERID.Enabled = True
            End If
            processDisableButton(True)
        ElseIf role = "AMC" Then
            
            lcREFFAMEMBERID.Text = ResourceManager.GetString("ROLE_GCB")
            'teREFFAMEMBERID.Tag = "REFFAMEMBERID_AMC"
            If ExeFlag = ExecuteFlag.AddNew Then
                For a As Integer = 0 To mv_arrObjFields.Count - 2
                    If mv_arrObjFields(a).FieldName = "REFFAMEMBERID" Then
                        If mv_arrObjFields(a).SearchCode <> "" Then
                            mv_arrObjFields(a).SearchCode = "FAMEMBERSCODE_AMC"
                        End If
                    End If
                Next
                lcREFFAMEMBERID.Enabled = True
                teREFFAMEMBERID.Enabled = True
            End If
            processDisableButton(True)
        ElseIf role = "Other" Then
            lcREFFAMEMBERID.Enabled = False
            teREFFAMEMBERID.Enabled = False
            processDisableButton(True)
            LoadLstGTC()
        Else
            
            lcREFFAMEMBERID.Text = ResourceManager.GetString("ROLE_GCB")
            'teREFFAMEMBERID.Tag = "REFFAMEMBERID_AMC"
            If ExeFlag = ExecuteFlag.AddNew Then
                For a As Integer = 0 To mv_arrObjFields.Count - 2
                    If mv_arrObjFields(a).FieldName = "REFFAMEMBERID" Then
                        If mv_arrObjFields(a).SearchCode <> "" Then
                            mv_arrObjFields(a).SearchCode = "FAMEMBERSCODE_BRK"
                        End If
                    End If
                Next
                lcREFFAMEMBERID.Enabled = True
                teREFFAMEMBERID.Enabled = True
            End If
            processDisableButton(True)

        End If
    End Sub
#End Region
#Region "Simple Button Event"
    Private Sub sbAssAll_Click(sender As Object, e As EventArgs) Handles sbAssAll.Click
        AssignAll()
    End Sub
    Private Sub sbAssOne_Click(sender As Object, e As EventArgs) Handles sbAssOne.Click
        AssignOne()
    End Sub
    Private Sub sbUnAssOne_Click(sender As Object, e As EventArgs) Handles sbUnAssOne.Click
        unAssignOne()
    End Sub
    Private Sub sbUnAssAll_Click(sender As Object, e As EventArgs) Handles sbUnAssAll.Click
        unAssignALL()
    End Sub

    Private Sub AssignAll()
        For i As Integer = 0 To lbLstSTC.Items.Count - 1
            lbAssSTC.Items.Add(lbLstSTC.Items(0))
            lbLstSTC.Items.RemoveAt(0)
        Next
    End Sub

    Private Sub AssignOne()
        For i As Integer = 0 To lbLstSTC.SelectedItems.Count - 1
            lbAssSTC.Items.Add(lbLstSTC.SelectedItems(0))
            lbLstSTC.Items.Remove(lbLstSTC.SelectedItems(0))
        Next
    End Sub

    Private Sub unAssignOne()
        For i As Integer = 0 To lbAssSTC.SelectedItems.Count - 1
            lbLstSTC.Items.Add(lbAssSTC.SelectedItems(0))
            lbAssSTC.Items.Remove(lbAssSTC.SelectedItems(0))
        Next
    End Sub

    Private Sub unAssignALL()
        For i As Integer = 0 To lbAssSTC.Items.Count - 1
            lbLstSTC.Items.Add(lbAssSTC.Items(0))
            lbAssSTC.Items.RemoveAt(0)
        Next
    End Sub
#End Region
#Region "Function"
    Private Function GetRefValue(key As String) As String
        Dim v_ws As New BDSDeliveryManagement
        Try
            Dim v_fullname, v_strSQL As String
            If lueROLE.EditValue = "STC" Then
                v_strSQL = "SELECT FULLNAME FROM CFMAST WHERE CUSTODYCD = '" & key & "'"
            Else
                v_strSQL = "SELECT FULLNAME FROM FAMEMBERS WHERE shortname = '" & key & "'"
            End If
            Dim v_strMsgObj = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, Me.ObjectName, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strMsgObj)

            Dim v_nodeList As Xml.XmlNodeList
            Dim XmlDocument As New Xml.XmlDocument
            Dim v_strFLDNAME, v_strValue As String
            XmlDocument.LoadXml(v_strMsgObj)
            v_nodeList = XmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString

                        Select Case Trim(v_strFLDNAME)
                            Case "FULLNAME"
                                v_fullname = Trim(v_strValue)
                        End Select
                    End With
                Next
            Next

            Return v_fullname
        Catch ex As Exception
            LogError.Write("frmUSERLOGIN.GetRefValue::key=" & key & vbNewLine & ex.Message, EventLogEntryType.Error)
        Finally
            If v_ws IsNot Nothing Then
                v_ws = Nothing
            End If
        End Try
    End Function
    Private Function GetEmail(key As String) As String
        Dim v_ws As New BDSDeliveryManagement
        Try
            Dim v_email, v_strSQL As String
            If lueROLE.EditValue = "STC" Then
                v_strSQL = "SELECT EMAIL FROM CFMAST WHERE CUSTODYCD = '" & key & "'"
            ElseIf lueROLE.EditValue = "AMC" Then
                v_strSQL = "SELECT EMAIL FROM FAMEMBERS WHERE roles = 'AMC' AND activestatus ='Y' and shortname = '" & key & "'"
            ElseIf lueROLE.EditValue = "GCB" Then
                v_strSQL = "SELECT EMAIL FROM FAMEMBERS WHERE roles = 'GCB' AND activestatus ='Y' and shortname = '" & key & "'"
            ElseIf lueROLE.EditValue = "CTCK" Then
                v_strSQL = "SELECT EMAIL FROM FAMEMBERS WHERE roles = 'BRK' AND activestatus ='Y' and shortname = '" & key & "'"
            End If
            Dim v_strMsgObj = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, Me.ObjectName, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strMsgObj)

            Dim v_nodeList As Xml.XmlNodeList
            Dim XmlDocument As New Xml.XmlDocument
            Dim v_strFLDNAME, v_strValue As String
            XmlDocument.LoadXml(v_strMsgObj)
            v_nodeList = XmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString

                        Select Case Trim(v_strFLDNAME)
                            Case "EMAIL"
                                v_email = Trim(v_strValue)
                        End Select
                    End With
                Next
            Next

            Return v_email
        Catch ex As Exception
            LogError.Write("frmUSERLOGIN.GetEmail::key=" & key & vbNewLine & ex.Message, EventLogEntryType.Error)
        Finally
            If v_ws IsNot Nothing Then
                v_ws = Nothing
            End If
        End Try
    End Function
#End Region


    Private Sub txtUSERNAME_GotFocus(sender As Object, e As EventArgs) Handles txtUSERNAME.GotFocus
        If txtUSERNAME.Enabled AndAlso Len(txtUSERNAME.Text) = 0 Then
            getUserNameFormat()
        End If
    End Sub

    Private Sub getUserNameFormat()
        Dim v_ws As New BDSDeliveryManagement
        Try
            Dim v_strCLAUSE = lueROLE.EditValue & "|" & teREFFAMEMBERID.EditValue
            Dim v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, Me.ObjectName, gc_ActionAdhoc, , v_strCLAUSE, "getUserNameFormat")
            v_ws.Message(v_strObjMsg)
            Dim xmlDocument As New Xml.XmlDocument
            xmlDocument.LoadXml(v_strObjMsg)

            If xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER) Is Nothing Then
                txtUSERNAME.Text = String.Empty
            Else
                txtUSERNAME.Text = xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridViewRole_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridViewRole.CellValueChanged
        Try
            If (e.Column.FieldName = "IS_MAKER" OrElse e.Column.FieldName = "IS_APPROVE") Then
                Dim v As Boolean = IIf(e.Value IsNot Nothing, CType(e.Value, Boolean), False)
                If (v) Then
                    Dim dr As DataRow = GridViewRole.GetDataRow(e.RowHandle)
                    If (dr IsNot Nothing) Then
                        dr("IS_VIEW") = True
                    End If
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RepositoryItemCheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit1.CheckedChanged
        btnOK.Focus()
    End Sub

    Private Sub txtCustodycd_TextChanged(sender As Object, e As EventArgs) Handles txtCustodycd.TextChanged
        If txtCustodycd.Text.Length > 0 Then
            Dim items = From it In lbLstSTC.Items.Cast(Of Object)()
                    Where it.ToString().IndexOf(txtCustodycd.Text, StringComparison.CurrentCultureIgnoreCase) >= 0
            Dim matchingItemList As List(Of Object) = items.ToList()
            lbLstSTC.BeginUpdate()
            lbLstSTC.Items.Clear()
            For Each a In matchingItemList
                lbLstSTC.Items.Add(a)
            Next
        Else
            'TRUNG.LUU: 02-04-20201
            'If lbLstSTC.Items.Count > 0 Then
            '    For r As Integer = 0 To lbLstSTC.Items.Count - 1
            '        mv_arrUnAssLstSTC.Remove(lbLstSTC.Items(r))
            '    Next
            'End If
            lbLstSTC.Items.Clear()
            lbLstSTC.Items.AddRange(mv_arrUnAssLstSTC.ToArray)
        End If
        lbLstSTC.EndUpdate()
    End Sub

    Private Sub lbLstSTC_DoubleClick(sender As Object, e As EventArgs) Handles lbLstSTC.DoubleClick
        Try
            For i As Integer = 0 To lbLstSTC.SelectedItems.Count - 1
                lbAssSTC.Items.Add(lbLstSTC.SelectedItems(0))
                lbLstSTC.Items.Remove(lbLstSTC.SelectedItems(0))
                mv_arrUnAssLstSTC.Remove(lbLstSTC.SelectedItems(0))
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub lbAssSTC_DoubleClick(sender As Object, e As EventArgs) Handles lbAssSTC.DoubleClick
        Try
            For i As Integer = 0 To lbAssSTC.SelectedItems.Count - 1
                lbLstSTC.Items.Add(lbAssSTC.SelectedItems(0))
                lbAssSTC.Items.Remove(lbAssSTC.SelectedItems(0))
                mv_arrAssLstSTC.Remove(lbAssSTC.SelectedItems(0))
            Next
        Catch ex As Exception
        End Try
    End Sub
End Class
