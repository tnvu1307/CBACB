Imports System.IO
Imports System.Text
Imports System.Collections
Imports CommonLibrary
Imports AppCore
Imports System.Xml.XmlReader
Imports System.Windows.Forms
Imports System.Windows.Forms.Application

Public Class frmVouchers

#Region " Declare constant and variables "
    Const c_ResourceManager = "AppCore.frmVouchers-"
    Private mv_ResourceManager As Resources.ResourceManager

#End Region

    Private mv_strReturnValue As String = String.Empty
    Private mv_strBranchID As String = String.Empty
    Private mv_strTellerID As String = String.Empty
    Private mv_strTLTXCD As String = String.Empty
    Private mv_strLanguage As String
    Dim v_rdb As RadioButton


    Public Property BranchID() As String
        Get
            Return mv_strBranchID
        End Get
        Set(ByVal Value As String)
            mv_strBranchID = Value
        End Set
    End Property
    Public Property TellerID() As String
        Get
            Return mv_strTellerID
        End Get
        Set(ByVal Value As String)
            mv_strTellerID = Value
        End Set
    End Property
    Public Property ReturnValue() As String
        Get
            Return mv_strReturnValue
        End Get
        Set(ByVal Value As String)
            mv_strReturnValue = Value
        End Set
    End Property

    Public Property TLTXCD() As String
        Get
            Return mv_strTLTXCD
        End Get
        Set(ByVal Value As String)
            mv_strTLTXCD = Value
        End Set
    End Property

    Public ReadOnly Property ResourceManager() As Resources.ResourceManager
        Get
            Return mv_ResourceManager
        End Get
    End Property
    Public Property UserLanguage() As String
        Get
            Return mv_strLanguage
        End Get
        Set(ByVal Value As String)
            mv_strLanguage = Value
        End Set
    End Property

    Protected Overridable Sub LoadResource(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control

        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is Label Then
                'CType(v_ctrl, Label).Text = mv_ResourceManager.GetString("frmVouchers." & v_ctrl.Name)
                CType(v_ctrl, Label).Text = mv_ResourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                'CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString("frmVouchers." & v_ctrl.Name)
                CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Button Then
                'CType(v_ctrl, Button).Text = mv_ResourceManager.GetString("frmVouchers." & v_ctrl.Name)
                CType(v_ctrl, Button).Text = mv_ResourceManager.GetString(v_ctrl.Name)
            End If
        Next
        Me.Text = mv_ResourceManager.GetString("frmVouchers")

    End Sub
    Private Sub frmVouchers_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim v_ws As New BDSDeliveryManagement
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_strValue, v_strFLDNAME, v_strTEXT As String, i, j As Integer
            Dim v_strCmdSQL As String, v_strObjMsg, v_strCURRPRICE, v_strSQL, v_strClause As String
            Dim mv_strVOUCHERID As String = String.Empty
            Dim mv_strVOUCHERDESC As String = String.Empty
            Dim v_Location As Integer
            v_Location = 3
            'mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            'LoadResource(Me)

            v_strCmdSQL = "SELECT * FROM voucherlist A WHERE TLTXCD='" & TLTXCD & "' ORDER BY ODRNUM "
            v_strObjMsg = BuildXMLObjMsg(, BranchID, , TellerID, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL, , , , , , , , gc_CommandText)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            v_strTEXT = String.Empty
            If v_nodeList.Count = 0 Then
                MsgBox(mv_ResourceManager.GetString("NoVoucher"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Me.Close()
            End If
            For i = 0 To v_nodeList.Count - 1
                v_rdb = New RadioButton
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = Trim(.InnerText.ToString)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)

                            Case "VOUCHERID"
                                mv_strVOUCHERID = v_strValue
                                v_rdb.Tag = mv_strVOUCHERID
                                v_rdb.Name = mv_strVOUCHERID
                            Case "VOUCHERDESC"
                                mv_strVOUCHERDESC = v_strValue.Trim()
                                v_rdb.Text = mv_strVOUCHERDESC
                            Case "ODRNUM"
                                If v_strValue = "1" Then
                                    v_rdb.Checked = True
                                End If
                        End Select
                    End With
                Next

                Panel1.Controls.Add(v_rdb)
                v_rdb.SetBounds(3, v_Location, 350, 17)
                v_Location = v_Location + 25
            Next

        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmVouchers.frmVouchers_Load" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Throw ex
        End Try
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            For Each v_rdb As RadioButton In Panel1.Controls.OfType(Of RadioButton)()

                If v_rdb.Checked Then
                    mv_strReturnValue = v_rdb.Tag
                End If
            Next
            Me.Close()
        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmVouchers.btnPrint_Click" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

#Region " Windows Form Designer generated code "
    Public Sub New(ByVal pv_strLanguage As String)
        'MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        mv_strLanguage = pv_strLanguage
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)
    End Sub
#End Region
End Class
