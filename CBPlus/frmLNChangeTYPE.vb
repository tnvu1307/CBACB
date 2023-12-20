Imports AppCore
Imports CommonLibrary

Public Class frmLNChangeTYPE

    Private mv_strLanguage As String
    Private mv_ResourceManager As Resources.ResourceManager
    Private c_ResourceManager As String = "_DIRECT.frmLNChangeTYPE-"
    Private c_SearchResourceManager As String = "AppCore.frmSearch-"
    Private v_blnLoad As Boolean = True

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


    Private Sub frmLNChangeTYPE_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadResource(Me.grbLNChangeTYPEParameter)
        LoadACTYPE()
        Me.txtDESC.Text = mv_ResourceManager.GetString("DefaultDescription") & Me.lblBANKNAME.Text
    End Sub

    Private Sub LoadACTYPE()
        Dim v_strCmdSQL, v_strObjMsg, v_strFLDNAME, v_strVALUE As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Try

            v_strCmdSQL = "select * from " & _
                 "( " & _
                 "SELECT ACTYPE VALUECD, ACTYPE VALUE,ACTYPE || ': ' || TYPENAME DISPLAY FROM LNTYPE WHERE STATUS = 'Y' AND APPRV_STS = 'A' " & _
                 "union all " & _
                 "SELECT 'ALL' VALUECD, 'ALL' VALUE,'All loan type' DISPLAY FROM dual " & _
                 ") order by case when VALUECD = 'ALL' then 0 else 1 end, VALUECD "
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            Me.cboOLDLNTYPE.Clears()
            FillComboEx(v_strObjMsg, Me.cboOLDLNTYPE, "", Me.UserLanguage)
            If Me.cboOLDLNTYPE.SelectedIndex > 0 Then Me.cboOLDLNTYPE.SelectedIndex = 1

            v_strCmdSQL = "SELECT ACTYPE VALUECD, ACTYPE VALUE,ACTYPE || ': ' || TYPENAME DISPLAY FROM LNTYPE WHERE STATUS = 'Y' AND APPRV_STS = 'A' ORDER BY ACTYPE "
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            Me.cboNEWLNTYPE.Clears()
            FillComboEx(v_strObjMsg, Me.cboNEWLNTYPE, "", Me.UserLanguage)
            If Me.cboNEWLNTYPE.SelectedIndex > 0 Then Me.cboNEWLNTYPE.SelectedIndex = 1

            v_blnLoad = False

        Catch ex As Exception

        End Try
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

            If mv_isCareBy = True Then
                mv_strSearchFilter &= " AND REPLACE(CUSTID,'.') IN (SELECT CUSTID FROM CFMAST WHERE INSTR('" & mv_strGroupCareBy & "',CAREBY)>0) "
            End If

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
                strRow = strRow.Replace("<$OLDLNTYPE>", Me.cboOLDLNTYPE.SelectedValue)
                strRow = strRow.Replace("<$NEWLNTYPE>", Me.cboNEWLNTYPE.SelectedValue)
                strRow = strRow.Replace("<$DESCRIPTION>", Me.txtDESC.Text)

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

    Private Sub cboOLDLNTYPE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOLDLNTYPE.SelectedIndexChanged
        Try
            SearchGrid.DataRows.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cboOLDLNTYPE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboOLDLNTYPE.Validating
 
    End Sub

    Protected Overrides Sub SetTransactForm()
        mv_frmTransactScreen = New frmTransactMaster(Me.mv_strLanguage)
    End Sub

    Protected Overrides Function OnExecute() As Int32
        If Not Me.cboOLDLNTYPE.SelectedValue <> Me.cboNEWLNTYPE.SelectedValue Then
            MessageBox.Show(mv_ResourceManager.GetString("frmLNChangeTYPE.NotCurrentLNTYPE"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Function
        End If

        If (mv_strSearchFilter Is Nothing OrElse mv_strSearchFilter.Length < 10) And (mv_strSearchFilterStore Is Nothing OrElse mv_strSearchFilterStore.Length < 10) Then
            If MessageBox.Show(mv_ResourceManager.GetString("frmLNChangeTYPE.NotIncludeSearchFilter"), Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) <> Windows.Forms.DialogResult.OK Then
                Exit Function
            End If
        End If
        MyBase.OnExecute()
    End Function

    Private Sub cboNEWLNTYPE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboNEWLNTYPE.SelectedIndexChanged
        Try
            If Not v_blnLoad Then
                OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, 1)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class