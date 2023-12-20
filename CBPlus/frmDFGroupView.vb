Imports AppCore
Imports CommonLibrary

Public Class frmDFGroupView

    Private mv_strLanguage As String
    Private mv_ResourceManager As Resources.ResourceManager
    Private c_ResourceManager As String = "_DIRECT.frmDFGroupView-"
    Private c_SearchResourceManager As String = "AppCore.frmSearch-"

    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New(pv_strLanguage)

        'This call is required by the Windows Form Designer.
        mv_strLanguage = pv_strLanguage
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())

        InitializeComponent()
    End Sub


    Private Sub LoadResource(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control

        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is Label Then
                CType(v_ctrl, Label).Text = mv_ResourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is TabControl Then
                CType(v_ctrl, TabControl).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Button Then
                CType(v_ctrl, Button).Text = mv_ResourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is CheckBox Then
                CType(v_ctrl, CheckBox).Text = mv_ResourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString(v_ctrl.Name)
            End If
        Next

    End Sub

    Private Sub txtCUSTBANK_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCUSTBANK.KeyUp
        Try
            If e.KeyCode = Keys.F5 Then
                Dim frm As New frmSearch(Me.UserLanguage)
                frm.TableName = "CFBANK"
                frm.ModuleCode = "CF"
                frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                frm.IsLocalSearch = gc_IsNotLocalMsg
                frm.IsLookup = "Y"
                frm.SearchOnInit = False
                frm.BranchId = Me.BranchId
                frm.TellerId = Me.TellerId
                frm.ShowDialog()
                Me.txtCUSTBANK.Text = Trim(frm.ReturnValue)
                Me.lblBANKNAME.Text = frm.RefValue

                frm.Dispose()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub frmDFGroupView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadResource(Me.grbDFGroupParameter)
        Me.txtDESC.Text = mv_ResourceManager.GetString("DefaultDescription") & Me.lblBANKNAME.Text
        Me.txtCONFIRMAMT.Text = "0"
        Me.txtEXPECTEDAMT.Text = "0"
        Me.txtINUSEDLIMIT.Text = "0"
        Me.txtCUSTLIMIT.Text = "0"
    End Sub

    Protected Overrides Sub Grid_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not SearchGrid.CurrentColumn Is Nothing Then
            If SearchGrid.CurrentColumn.FieldName = "__TICK" Then
                If SearchGrid.CurrentCell.Value = "X" Then
                    SearchGrid.CurrentCell.Value = String.Empty
                Else
                    SearchGrid.CurrentCell.Value = "X"
                End If
            End If
            Dim v_dblConfirmAmt As Double = 0
            For i As Integer = 0 To SearchGrid.DataRows.Count - 1
                If SearchGrid.DataRows.Item(i).Cells("__TICK").Value = "X" Then
                    If Math.Max(Math.Min(CDbl(SearchGrid.DataRows.Item(i).Cells("DFAMT").Value), CDbl(SearchGrid.DataRows.Item(i).Cells("OUTSTANDING").Value)), 0) = 0 Then
                        SearchGrid.DataRows.Item(i).Cells("__TICK").Value = String.Empty
                    Else
                        v_dblConfirmAmt = v_dblConfirmAmt + Math.Max(Math.Min(CDbl(SearchGrid.DataRows.Item(i).Cells("DFAMT").Value), CDbl(SearchGrid.DataRows.Item(i).Cells("OUTSTANDING").Value)), 0)
                    End If
                End If
            Next
            Me.txtCONFIRMAMT.Text = FormatNumber(v_dblConfirmAmt)
        End If
    End Sub

    Protected Overrides Function OnSearch(Optional ByVal pv_strIsLocal As String = "", Optional ByVal pv_strModule As String = "", Optional ByVal page As Int32 = 1) As Int32
        Dim i, j As Integer
        Dim v_xColumn As Xceed.Grid.Column, v_strFLDNAME, Value As String
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim strRow, vd As String
        Dim rownumber, v_intFrom, v_intTo As Int32
        Try

            mv_strSearchFilter = String.Empty

            For i = 0 To lstCondition.Items.Count - 1
                If lstCondition.GetItemChecked(i) Then
                    mv_strSearchFilter &= " AND " & hFilter(lstCondition.Items(i).ToString())
                End If
            Next i

            'Filter by Careby - TungNT modified
            If mv_isCareBy = True Then
                If ModuleCode & "." & mv_strObjName = OBJNAME_CF_AFMAST Then
                    mv_strSearchFilter &= " AND INSTR('" & mv_strGroupCareBy & "',CAREBYID)>0 "
                ElseIf (ModuleCode & "." & mv_strObjName = OBJNAME_OD_ODCANCEL) Or ModuleCode & "." & mv_strObjName = "OD.ODMASTVIEW" Or ModuleCode & "." & mv_strObjName = "OD.ODMAST" Then
                    mv_strSearchFilter &= " AND REPLACE(CUSTODYCD,'.') IN (SELECT CUSTODYCD FROM CFMAST WHERE INSTR('" & mv_strGroupCareBy & "',CAREBY)>0) "
                ElseIf (ModuleCode & "." & mv_strObjName = "OD.ODCTCIVIEW") Then
                    mv_strSearchFilter &= " AND REPLACE(CUSTID,'.') IN (SELECT CUSTID FROM CFMAST WHERE INSTR('" & mv_strGroupCareBy & "',CAREBY)>0) "
                End If
            End If
            'End Modified

            mv_strSearchFilter = Mid(mv_strSearchFilter, 5)

            If (pv_strIsLocal <> "") And (pv_strModule <> "") Then
                v_intTo = page * mv_rowpage
                v_intFrom = v_intTo + 1 - mv_rowpage

                If (mv_strSrOderByCmd <> "") And (mv_strSearchFilter <> "") Then
                    mv_strSearchFilter &= "ORDER BY " & mv_strSrOderByCmd
                End If

                If mv_strSearchFilter = "" Then
                    If mv_strSrOderByCmd <> "" Then
                        mv_strSearchFilter = " 0=0 ORDER BY " & mv_strSrOderByCmd
                    Else
                        mv_strSearchFilter = " 0 = 0 "
                    End If
                    If Me.chkALL.Checked = True Then
                        strRow = "SELECT * FROM ( SELECT T1.*,ROWNUM RN FROM(" & mv_strCmdSql & " AND " & mv_strSearchFilter & ")T1)" ' WHERE RN BETWEEN " & v_intFrom & " AND " & v_intTo
                    Else
                        strRow = "SELECT * FROM ( SELECT T1.*,ROWNUM RN FROM(" & mv_strCmdSql & " AND " & mv_strSearchFilter & ")T1) WHERE RN BETWEEN " & v_intFrom & " AND " & v_intTo
                    End If
                    mv_strCmdSqlTemp = mv_strCmdSql & " AND " & mv_strSearchFilter
                Else
                    If Me.chkALL.Checked = True Then
                        strRow = "SELECT * FROM ( SELECT T1.*,ROWNUM RN FROM(SELECT * FROM (" & mv_strCmdSql & ") T WHERE  " & mv_strSearchFilter & ")T1)" '  WHERE RN BETWEEN " & v_intFrom & " AND " & v_intTo
                    Else
                        strRow = "SELECT * FROM ( SELECT T1.*,ROWNUM RN FROM(SELECT * FROM (" & mv_strCmdSql & ") T WHERE  " & mv_strSearchFilter & ")T1)  WHERE RN BETWEEN " & v_intFrom & " AND " & v_intTo
                    End If

                    mv_strCmdSqlTemp = "SELECT * FROM (" & mv_strCmdSql & ") T WHERE  " & mv_strSearchFilter
                End If
                If SearchByTransact = True Then
                    strRow = strRow.Replace("<$BRID>", HO_BRID)
                Else
                    strRow = strRow.Replace("<$BRID>", Me.BranchId)
                End If

                strRow = strRow.Replace("<$HO_BRID>", HO_BRID)
                strRow = strRow.Replace("<$BUSDATE>", Me.BusDate)
                strRow = strRow.Replace("<$AFACCTNO>", Me.AFACCTNO)
                strRow = strRow.Replace("<$CUSTID>", Me.CUSTID)
                strRow = strRow.Replace("<@KEYVALUE>", LinkValue)
                strRow = strRow.Replace("<$TELLERID>", Me.TellerId)
                strRow = strRow.Replace("<$CUSTBANK>", Me.txtCUSTBANK.Text.Replace(".", ""))
                strRow = strRow.Replace("<$DFTYPE>", Me.cboDFTYPE.SelectedValue)

                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, IsLocalSearch, gc_MsgTypeObj, pv_strModule, _
                                                    gc_ActionInquiry, strRow)
                v_ws.Message(v_strObjMsg)
                Me.FULLDATA = v_strObjMsg
                'Fill data into search grid
                FillDataGrid(SearchGrid, v_strObjMsg, c_SearchResourceManager & UserLanguage, mv_strTableName, , v_intFrom, v_intTo, CountRow())
                'Format data in search grid
                For Each v_xColumn In SearchGrid.Columns
                    v_strFLDNAME = UCase(Trim(v_xColumn.FieldName))
                    For i = 0 To mv_arrSrFieldSrch.GetLength(0) - 1
                        If UCase(mv_arrSrFieldSrch(i)) = v_strFLDNAME Then
                            v_xColumn.FormatSpecifier = mv_arrSrFieldFormat(i)
                            Exit For
                        End If
                    Next
                Next
            End If


            Cursor.Current = Cursors.Default
            SetFocusGrid(Value)
            Me.btnNEXT.Enabled = True
            Me.btnBACK.Enabled = True
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    Private Sub getCustBankInfo(ByVal pv_strCustBank As String)
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strBankName, v_strCustLimit, v_strInusedLimit As String
        Dim v_strCmdSQL, v_strObjMsg, v_strValue, v_strFLDNAME As String
        Dim v_xmlDocument As New XmlDocumentEx
        Dim v_nodeList As Xml.XmlNodeList
        Try
            If pv_strCustBank.Length <> 0 Then

                v_strCmdSQL = "SELECT CUSTID CUSTBANK, FULLNAME BANKNAME, MRLOANLIMIT CUSTLIMIT, 0 INUSEDLIMIT FROM CFMAST WHERE ISBANKING = 'Y' AND CUSTID ='" & pv_strCustBank & "'"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL, , , , , , , , gc_CommandText)
                v_ws.Message(v_strObjMsg)


                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")


                For i As Integer = 0 To v_nodeList.Count - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = Trim(.InnerText.ToString)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "BANKNAME"
                                    v_strBankName = v_strValue
                                Case "CUSTLIMIT"
                                    v_strCustLimit = v_strValue
                                Case "INUSEDLIMIT"
                                    v_strInusedLimit = v_strValue
                            End Select
                        End With
                    Next
                Next

                Me.txtCUSTLIMIT.Text = v_strCustLimit
                Me.txtINUSEDLIMIT.Text = v_strInusedLimit
                Me.lblBANKNAME.Text = v_strBankName
            Else
                Me.txtCUSTLIMIT.Text = "0"
                Me.txtINUSEDLIMIT.Text = "0"
                Me.lblBANKNAME.Text = String.Empty
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtCUSTBANK_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCUSTBANK.Validating
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strSQL, v_strObjMsg As String
        Try
            getCustBankInfo(Me.txtCUSTBANK.Text.Replace(".", ""))

            'Load DFTYPE
            If Me.txtCUSTBANK.Text.Length <> 0 Then
                v_strSQL = " select dft.actype VALUE, dft.actype || ': ' || dft.typename DISPLAY, dft.typename EN_DISPLAY from dftype dft, lntype lnt " & ControlChars.CrLf _
                        & " where(dft.lntype = lnt.actype) " & ControlChars.CrLf _
                        & " and lnt.rrtype = 'B' and lnt.custbank = '" & txtCUSTBANK.Text.Replace(".", "") & "' "
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)

                'FillComboEx(v_strObjMsg, cboCODEID, "", Me.UserLanguage)
                FillComboDataSource(v_strObjMsg, cboDFTYPE)
                If cboDFTYPE.Items.Count > 0 Then
                    cboDFTYPE.SelectedIndex = 0
                Else
                    MsgBox(mv_ResourceManager.GetString("DFTYPEINVALID"), MsgBoxStyle.Information, Me.Text)
                    Me.ActiveControl = Me.txtCUSTBANK
                    Me.txtCUSTBANK.Text = ""
                    Exit Sub
                End If
            Else
                If cboDFTYPE.Items.Count > 0 Then
                    Me.cboDFTYPE.Items.Clear()
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Overrides Function OnExecute() As Integer
        Try
            ExecDFGroup()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub ExecDFGroup()
        Dim v_strValue, v_strFLDNAME, v_strFLDCD, v_strFLDCODE, v_strTLTXCD, v_strMODCODE, v_strFLDDEFVAL, v_strFIELDTYPE As String, i, j, v_intRow As Integer
        Dim v_strPostingDate As String
        Dim lngReturn As Long
        Dim v_strDFGROUPID, v_strDFTXSTRING As String
        Try

            If Len(Me.txtCUSTBANK.Text) = 0 Or String.Compare(txtCUSTBANK.Text, "") = 0 Then
                MsgBox(mv_ResourceManager.GetString("CustBankIsNull"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If

            If Len(Me.txtEXPECTEDAMT.Text) = 0 Then
                MsgBox(mv_ResourceManager.GetString("ExpectedAmtIsNull"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If

            If Len(Me.txtCONFIRMAMT.Text) = 0 Or CDbl(Me.txtCONFIRMAMT.Text) <= 0 Then
                MsgBox(mv_ResourceManager.GetString("ConfirmAmtIsNull"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If

            If CDbl(Me.txtCONFIRMAMT.Text) > CDbl(Me.txtEXPECTEDAMT.Text) Then
                MsgBox(mv_ResourceManager.GetString("ConfirmAmtIsBiggerThanExpectedAmt"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If

            If CDbl(Me.txtCUSTLIMIT.Text) - CDbl(Me.txtINUSEDLIMIT.Text) < CDbl(Me.txtCONFIRMAMT.Text) Then
                MsgBox(mv_ResourceManager.GetString("ConfirmAmtIsOverLimit"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If

            'Cac truong hop xu ly dac biet khi thuc hien Execute.
            'Xu ly xong thoat ra.
            'Khi execute goi den giao dich thi thuc hien o day
            'Căn cứ vào SEARCHCODE để lấy mã giao dịch (TLTXCD) và nạp các giá trị mặc định cho trư?ng giao dịch FLDCD.
            v_strFLDDEFVAL = String.Empty
            v_strMODCODE = "DF" 'String.Empty
            v_strTLTXCD = "2676" 'String.Empty

            If Not Me.chkExeAll.Checked Then
                If Not SearchGrid Is Nothing Then
                    If SearchGrid.DataRows.Count > 0 Then
                        For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                            If Not SearchGrid.DataRows(v_intRow) Is Nothing Then
                                If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then

                                    'get DFGROUPID
                                    v_strDFGROUPID = GetDealAccount()
                                    'get TXSTRING 
                                    v_strDFTXSTRING = GetDFGroupParaString(Me.TellerId, v_strDFGROUPID, SearchGrid.DataRows(v_intRow).Cells("AFACCTNO").Value, SearchGrid.DataRows(v_intRow).Cells("DFTYPE").Value, Math.Max(Math.Min(SearchGrid.DataRows(v_intRow).Cells("OUTSTANDING").Value, SearchGrid.DataRows(v_intRow).Cells("DFAMT").Value), 0))


                                    v_strFLDCD = "20"
                                    v_strValue = Replace(v_strDFGROUPID, ".", "")
                                    v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & v_strFLDCD & "." & v_strValue & "]"

                                    v_strFLDCD = "30"
                                    v_strValue = Me.txtDESC.Text & mv_ResourceManager.GetString("RRTYPEDESC") & lblBANKNAME.Text
                                    v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & v_strFLDCD & "." & v_strValue & "]"

                                    v_strFLDCD = "06"
                                    v_strValue = v_strDFTXSTRING
                                    v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & v_strFLDCD & "." & v_strValue & "]"

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
                                            Exit Sub
                                        End If
                                        'mv_frmTransactScreen.OnSubmit()
                                        mv_frmTransactScreen.Dispose()
                                        'Reset lai gia tri
                                        v_strFLDDEFVAL = String.Empty
                                    End If
                                End If
                            End If
                        Next
                    End If
                End If
            Else
                'N?u dây là màn hình tra c?u cho phép th?c hi?n giao d?ch k? ti?p
                If Not SearchGrid Is Nothing Then
                    If SearchGrid.DataRows.Count > 0 Then
                        For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                            If Not SearchGrid.DataRows(v_intRow) Is Nothing Then
                                If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then

                                    'get DFGROUPID
                                    v_strDFGROUPID = GetDealAccount()
                                    'get TXSTRING 
                                    v_strDFTXSTRING = GetDFGroupParaString(Me.TellerId, v_strDFGROUPID, SearchGrid.DataRows(v_intRow).Cells("AFACCTNO").Value, SearchGrid.DataRows(v_intRow).Cells("DFTYPE").Value, Math.Max(Math.Min(SearchGrid.DataRows(v_intRow).Cells("OUTSTANDING").Value, SearchGrid.DataRows(v_intRow).Cells("DFAMT").Value), 0))


                                    v_strFLDCD = "20"
                                    v_strValue = Replace(v_strDFGROUPID, ".", "")
                                    v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & v_strFLDCD & "." & v_strValue & "]"

                                    v_strFLDCD = "30"
                                    v_strValue = Me.txtDESC.Text & mv_ResourceManager.GetString("RRTYPEDESC") & lblBANKNAME.Text
                                    v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & v_strFLDCD & "." & v_strValue & "]"

                                    v_strFLDCD = "06"
                                    v_strValue = v_strDFTXSTRING
                                    v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & v_strFLDCD & "." & v_strValue & "]"

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
                                            Exit Sub
                                        End If
                                        'mv_frmTransactScreen.OnSubmit()
                                        mv_frmTransactScreen.Dispose()
                                        'Reset lai gia tri
                                        v_strFLDDEFVAL = String.Empty
                                    End If
                                End If
                            End If
                        Next
                    End If
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Function GetDealAccount() As String
        Dim v_strClause, v_strAutoID As String
        Dim v_int, v_intCount As Integer
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strVALUE As String
        'Lấy ra số tự tăng
        v_strClause = "SEQ_DFMAST"
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_wsBDS As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strDealAccount As String
        Try

            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strClause, "GetInventory")
            v_wsBDS.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_strAutoID = v_xmlDocument.DocumentElement.Attributes("CLAUSE").Value
            'Tạo số hiệu lệnh = Mã chi nhánh + Ngày hệ thống + Số tự tăng
            v_strDealAccount = Me.BranchId & Mid(Replace(Me.BusDate, "/", vbNullString), 1, 4) & Mid(Replace(Me.BusDate, "/", vbNullString), 7, 2) & Strings.Right(gc_FORMAT_ODAUTOID & CStr(v_strAutoID), Len(gc_FORMAT_ODAUTOID))

        Catch ex As Exception
            Throw ex
        End Try
        Return v_strDealAccount
    End Function

    Private Function GetDFGroupParaString(ByVal pv_strTLID As String, ByVal pv_strDFGROUPID As String, ByVal pv_strAFACCTNO As String, ByVal pv_strDFTYPE As String, ByVal pv_dblDFAMT As Double) As String

        Dim v_strReference, v_strDFGroupString As String
        Dim v_int, v_intCount As Integer
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strVALUE As String
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            v_strReference = "'" & pv_strTLID & "','" & pv_strDFGROUPID & "','" & pv_strAFACCTNO & "','" & pv_strDFTYPE & "'," & pv_dblDFAMT.ToString & ""
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "DF.DFMAST", gc_ActionAdhoc, , , "GetDFGroupParaString", , , v_strReference)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_strDFGroupString = v_xmlDocument.DocumentElement.Attributes(gc_AtributeRESERVER).Value
        Catch ex As Exception
            Throw ex
        End Try
        Return v_strDFGroupString
    End Function
End Class