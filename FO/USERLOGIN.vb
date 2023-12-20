Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data

Public Class USERLOGIN
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "USERLOGIN"
    End Sub


    Overrides Function Adhoc(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strFuncName As String
        Dim v_strObjMsg As String

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            v_strFuncName = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeFUNCNAME), Xml.XmlAttribute).Value)

            v_strObjMsg = pv_xmlDocument.InnerXml
            Select Case Trim(v_strFuncName)
                Case "ChangePassword"
                    v_lngErrCode = ChangePassword(v_strObjMsg)
                Case "VerifyUser"
                    v_lngErrCode = VerifyUser(v_strObjMsg)
                Case "TradingScreen"
                    v_lngErrCode = TradingScreen(v_strObjMsg)
                Case "GetServerTime"
                    v_lngErrCode = GetServerTime(v_strObjMsg)
            End Select
            v_strMessage = v_strObjMsg
            Return v_lngErrCode

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function TradingScreen(ByRef pv_strObjMsg As String) As Long
        Dim v_obj As DataAccess, v_ds As DataSet, v_strSQL As String
        Dim v_strErrorSource As String = ATTR_TABLE & ".TradingScreen"
        Dim XMLDocument As New XmlDocumentEx, XMLOrder As New XmlDocumentEx
        Dim v_nodeData, v_nodeOldData As Xml.XmlNode
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK, v_strTICKET As String
        Try
            'XMLDocument.LoadXml(pv_strObjMsg)
            'Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            'Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value) 'Noi dung lenh dat vao
            'XMLOrder.LoadXml(v_strClause)

            Dim v_strDEF_SCREEN_DATAXML As String = "<Table><CDTYPE>FO</CDTYPE><CDNAME>BOOK</CDNAME><CDVAL>A</CDVAL><CDCONTENT>Active</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>BOOK</CDNAME><CDVAL>I</CDVAL><CDCONTENT>Inactive</CDCONTENT><LSTODR>1</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>EXECTYPE</CDNAME><CDVAL>NB</CDVAL><CDCONTENT>Normal buy</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>EXECTYPE</CDNAME><CDVAL>NS</CDVAL><CDCONTENT>Normal sell</CDCONTENT><LSTODR>1</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>EXECTYPE</CDNAME><CDVAL>MS</CDVAL><CDCONTENT>Mortage sell</CDCONTENT><LSTODR>1</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>PRICETYPE</CDNAME><CDVAL>LO</CDVAL><CDCONTENT>Limited order</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>PRICETYPE</CDNAME><CDVAL>ATO</CDVAL><CDCONTENT>ATO</CDCONTENT><LSTODR>2</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>PRICETYPE</CDNAME><CDVAL>ATC</CDVAL><CDCONTENT>ATC</CDCONTENT><LSTODR>3</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>SEARCHBY</CDNAME><CDVAL>ACCTNO</CDVAL><CDCONTENT>Account</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>SEARCHBY</CDNAME><CDVAL>CFCUSTODYCD</CDVAL><CDCONTENT>Custody code</CDCONTENT><LSTODR>1</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>WATCHLIST</CDNAME><CDVAL>DEFMKT</CDVAL><CDCONTENT>Default</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>WATCHLIST</CDNAME><CDVAL>UDFMKT</CDVAL><CDCONTENT>User defined</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TIMETYPE</CDNAME><CDVAL>T</CDVAL><CDCONTENT>Today</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_EN</CDNAME><CDVAL>SYMBOL</CDVAL><CDCONTENT>Code</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_EN</CDNAME><CDVAL>FLOORPRICE</CDVAL><CDCONTENT>Floor</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_EN</CDNAME><CDVAL>BASICPRICE</CDVAL><CDCONTENT>Ref.</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_EN</CDNAME><CDVAL>CEILINGPRICE</CDVAL><CDCONTENT>Ceil</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_EN</CDNAME><CDVAL>BESTBUYPRC3</CDVAL><CDCONTENT>P3</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_EN</CDNAME><CDVAL>BESTBUYVOL3</CDVAL><CDCONTENT>Q3</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_EN</CDNAME><CDVAL>BESTBUYPRC2</CDVAL><CDCONTENT>P2</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_EN</CDNAME><CDVAL>BESTBUYVOL2</CDVAL><CDCONTENT>Q2</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_EN</CDNAME><CDVAL>BESTBUYPRC1</CDVAL><CDCONTENT>P1</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_EN</CDNAME><CDVAL>BESTBUYVOL1</CDVAL><CDCONTENT>Q1</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_EN</CDNAME><CDVAL>CURRPRICE</CDVAL><CDCONTENT>Curr</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_EN</CDNAME><CDVAL>MATCHVOL</CDVAL><CDCONTENT>Trade qty</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_EN</CDNAME><CDVAL>MATCHCHG</CDVAL><CDCONTENT>+/-</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_EN</CDNAME><CDVAL>BESTSELPRC1</CDVAL><CDCONTENT>P1</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_EN</CDNAME><CDVAL>BESTSELVOL1</CDVAL><CDCONTENT>Q1</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_EN</CDNAME><CDVAL>BESTSELPRC2</CDVAL><CDCONTENT>P2</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_EN</CDNAME><CDVAL>BESTSELVOL2</CDVAL><CDCONTENT>Q2</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_EN</CDNAME><CDVAL>BESTSELPRC3</CDVAL><CDCONTENT>P3</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_EN</CDNAME><CDVAL>BESTSELVOL3</CDVAL><CDCONTENT>Q3</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_EN</CDNAME><CDVAL>HIGHESTPRICE</CDVAL><CDCONTENT>High</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_EN</CDNAME><CDVAL>LOWESTPRICE</CDVAL><CDCONTENT>Low</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_VN</CDNAME><CDVAL>SYMBOL</CDVAL><CDCONTENT>CK</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_VN</CDNAME><CDVAL>FLOORPRICE</CDVAL><CDCONTENT>Sàn</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_VN</CDNAME><CDVAL>BASICPRICE</CDVAL><CDCONTENT>Tham chiếu</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_VN</CDNAME><CDVAL>CEILINGPRICE</CDVAL><CDCONTENT>Trần</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_VN</CDNAME><CDVAL>BESTBUYPRC3</CDVAL><CDCONTENT>G3</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_VN</CDNAME><CDVAL>BESTBUYVOL3</CDVAL><CDCONTENT>KL3</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_VN</CDNAME><CDVAL>BESTBUYPRC2</CDVAL><CDCONTENT>G2</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_VN</CDNAME><CDVAL>BESTBUYVOL2</CDVAL><CDCONTENT>KL2</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_VN</CDNAME><CDVAL>BESTBUYPRC1</CDVAL><CDCONTENT>G1</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_VN</CDNAME><CDVAL>BESTBUYVOL1</CDVAL><CDCONTENT>KL1</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_VN</CDNAME><CDVAL>CURRPRICE</CDVAL><CDCONTENT>Giá HT</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_VN</CDNAME><CDVAL>MATCHVOL</CDVAL><CDCONTENT>KL GD</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_VN</CDNAME><CDVAL>MATCHCHG</CDVAL><CDCONTENT>+/-</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_VN</CDNAME><CDVAL>BESTSELPRC1</CDVAL><CDCONTENT>G1</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_VN</CDNAME><CDVAL>BESTSELVOL1</CDVAL><CDCONTENT>KL1</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_VN</CDNAME><CDVAL>BESTSELPRC2</CDVAL><CDCONTENT>G2</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_VN</CDNAME><CDVAL>BESTSELVOL2</CDVAL><CDCONTENT>KL2</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_VN</CDNAME><CDVAL>BESTSELPRC3</CDVAL><CDCONTENT>G3</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_VN</CDNAME><CDVAL>BESTSELVOL3</CDVAL><CDCONTENT>KL3</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_VN</CDNAME><CDVAL>HIGHESTPRICE</CDVAL><CDCONTENT>Cao nhất</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_VN</CDNAME><CDVAL>LOWESTPRICE</CDVAL><CDCONTENT>Thấp nhất</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>TICKER_VN</CDNAME><CDVAL>FOREIGNBUY</CDVAL><CDCONTENT>NN mua</CDCONTENT><LSTODR>0</LSTODR></Table>"
            'Get list of FO_GeneralView: OnLine customer service
            v_strDEF_SCREEN_DATAXML = v_strDEF_SCREEN_DATAXML & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>SERVICELINK_EN</CDNAME><CDVAL>MRACCINQ</CDVAL><CDCONTENT>Account inquiry</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>SERVICELINK_EN</CDNAME><CDVAL>FO0001</CDVAL><CDCONTENT>Order history</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>SERVICELINK_EN</CDNAME><CDVAL>FO0002</CDVAL><CDCONTENT>Cash account statement</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>SERVICELINK_EN</CDNAME><CDVAL>FO0003</CDVAL><CDCONTENT>Custody account statement</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>SERVICELINK_EN</CDNAME><CDVAL>CHGLOGINPWD</CDVAL><CDCONTENT>Change login password</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>SERVICELINK_EN</CDNAME><CDVAL>CHGTRADINGPWD</CDVAL><CDCONTENT>Change trading password</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>SERVICELINK_EN</CDNAME><CDVAL>ALLOCATELIMIT</CDVAL><CDCONTENT>Allocate margin limit</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>SERVICELINK_EN</CDNAME><CDVAL>RELEASELIMIT</CDVAL><CDCONTENT>Release margin limit</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>SERVICELINK_EN</CDNAME><CDVAL>OTHER</CDVAL><CDCONTENT>Other...</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>SERVICELINK_VN</CDNAME><CDVAL>MRACCINQ</CDVAL><CDCONTENT>Truy vấn tài khoản</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>SERVICELINK_VN</CDNAME><CDVAL>FO0001</CDVAL><CDCONTENT>Lịch sử lệnh</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>SERVICELINK_VN</CDNAME><CDVAL>FO0002</CDVAL><CDCONTENT>Các giao dịch tiền gửi</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>SERVICELINK_VN</CDNAME><CDVAL>FO0003</CDVAL><CDCONTENT>Các giao dịch chứng khoán</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>SERVICELINK_VN</CDNAME><CDVAL>CHGLOGINPWD</CDVAL><CDCONTENT>Thay đổi mật khẩu đăng nhập</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>SERVICELINK_VN</CDNAME><CDVAL>CHGTRADINGPWD</CDVAL><CDCONTENT>Thay đổi mật khảu giao dịch</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>SERVICELINK_VN</CDNAME><CDVAL>ALLOCATELIMIT</CDVAL><CDCONTENT>Cấp hạn mức margin</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>SERVICELINK_VN</CDNAME><CDVAL>RELEASELIMIT</CDVAL><CDCONTENT>Thu hồi hạn mức margin</CDCONTENT><LSTODR>0</LSTODR></Table>" & ControlChars.CrLf & _
                        "<Table><CDTYPE>FO</CDTYPE><CDNAME>SERVICELINK_VN</CDNAME><CDVAL>OTHER</CDVAL><CDCONTENT>Khác...</CDCONTENT><LSTODR>0</LSTODR></Table>"

            v_obj = New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)

            'Get current transaction date
            Dim v_strCURRDATE As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "CURRDATE", v_strCURRDATE)
            v_strDEF_SCREEN_DATAXML = v_strDEF_SCREEN_DATAXML & ControlChars.CrLf & _
                "<Table><CDTYPE>FO</CDTYPE><CDNAME>BUSDATE</CDNAME><CDVAL>BUSDATE</CDVAL><CDCONTENT>" + v_strCURRDATE + "</CDCONTENT><LSTODR>0</LSTODR></Table>"

            'Get Securities TRADELOT, TRADEUNIT, TRADEBUYSELL & TICKSIZE


            pv_strObjMsg = v_strDEF_SCREEN_DATAXML
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            Throw ex
        Finally
            XMLOrder = Nothing
            XMLDocument = Nothing
            If Not v_obj Is Nothing Then v_obj = Nothing
        End Try
    End Function

    Private Function VerifyUser(ByRef pv_strObjMsg As String) As Long
        Dim v_obj As DataAccess, v_ds As DataSet, v_strSQL As String
        Dim v_strErrorSource As String = ATTR_TABLE & ".VerifyUser"
        Dim XMLDocument As New XmlDocumentEx, XMLOrder As New XmlDocumentEx
        Dim v_nodeData, v_nodeOldData As Xml.XmlNode
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK, v_strTICKET As String
        Try
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value) 'Noi dung lenh dat vao
            XMLOrder.LoadXml(v_strClause)

            Dim v_strUSERNAME, v_strLOGINPWD, v_strTRADINGPWD As String
            v_strUSERNAME = String.Empty
            v_strLOGINPWD = String.Empty
            v_strTRADINGPWD = String.Empty
            v_strTICKET = String.Empty
            v_nodeData = XMLOrder.SelectSingleNode("RootTrade/objBODY/User")
            Dim v_strFUNCNAME As String = CStr(v_nodeData.Attributes("CLASS").Value)
            For i As Integer = 0 To v_nodeData.ChildNodes.Count - 1
                Select Case v_nodeData.ChildNodes(i).Name
                    Case "USERNAME"
                        v_strUSERNAME = v_nodeData.ChildNodes(i).InnerXml
                    Case "LOGINPWD"
                        v_strLOGINPWD = v_nodeData.ChildNodes(i).InnerXml
                    Case "TRADINGPWD"
                        v_strTRADINGPWD = v_nodeData.ChildNodes(i).InnerXml
                End Select
            Next

            v_obj = New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)

            If v_strFUNCNAME = "USERLOGIN" Then
                'Kiem tra user co hop le khong
                v_strSQL = "select username || TO_CHAR(SYSDATE,'DDMMYYYYHHMMSS') USERTICKET from userlogin  where status='A' and upper(username)='" + v_strUSERNAME.Trim.ToUpper + "' and LOGINPWD=GENENCRYPTPASSWORD('" + v_strLOGINPWD.Trim.ToUpper + "')"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 0 Then
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: System error!" & vbNewLine _
                                 & "Error message: " & v_strSQL & "." & ControlChars.CrLf & ATTR_TABLE & "." & v_strUSERNAME, "EventLogEntryType.Error")
                    Return ERR_SA_ACCTNO_NOTFOUND
                Else
                    v_strTICKET = CStr(v_ds.Tables(0).Rows(0)("USERTICKET")).Trim
                End If
            ElseIf v_strFUNCNAME = "USERTRADING" Then
                'Kiem tra user co hop le khong
                v_strSQL = "select username || TO_CHAR(SYSDATE,'DDMMYYYYHHMMSS') USERTICKET from userlogin  where status='A' and upper(username)='" + v_strUSERNAME.Trim.ToUpper + "' and TRADINGPWD=GENENCRYPTPASSWORD('" + v_strTRADINGPWD.Trim.ToUpper + "')"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 0 Then
                    'Kiem tra voi third party, neu khong hop le tra ve loi nhu sau
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: System error!" & vbNewLine _
                                 & "Error message: " & v_strSQL & "." & ControlChars.CrLf & ATTR_TABLE & "." & v_strUSERNAME, "EventLogEntryType.Error")
                    Return ERR_SA_ACCTNO_NOTFOUND
                Else
                    v_strTICKET = CStr(v_ds.Tables(0).Rows(0)("USERTICKET")).Trim
                End If
            End If
            pv_strObjMsg = v_strTICKET
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            Throw ex
        Finally
            XMLOrder = Nothing
            XMLDocument = Nothing
        End Try
    End Function

    Private Function ChangePassword(ByRef pv_strObjMsg As String) As Long
        Dim v_obj As DataAccess, v_ds As DataSet, v_strSQL As String
        Dim v_strErrorSource As String = ATTR_TABLE & ".MaintainUserMarketWatch"
        Dim XMLDocument As New XmlDocumentEx, XMLOrder As New XmlDocumentEx
        Dim v_nodeData, v_nodeOldData As Xml.XmlNode
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Try
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value) 'Noi dung lenh dat vao
            XMLOrder.LoadXml(v_strClause)

            Dim v_strUSERNAME, v_strOLDPASSWORD, v_strNEWPASSWORD, v_strACTION, v_strRETURN As String
            v_nodeData = XMLOrder.SelectSingleNode("RootTrade/objBODY/User")
            For i As Integer = 0 To v_nodeData.ChildNodes.Count - 1
                Select Case v_nodeData.ChildNodes(i).Name
                    Case "ACTION"
                        v_strACTION = v_nodeData.ChildNodes(i).InnerXml
                    Case "USERNAME"
                        v_strUSERNAME = v_nodeData.ChildNodes(i).InnerXml
                    Case "OLDPASSWORD"
                        v_strOLDPASSWORD = v_nodeData.ChildNodes(i).InnerXml
                    Case "NEWPASSWORD"
                        v_strNEWPASSWORD = v_nodeData.ChildNodes(i).InnerXml
                End Select
            Next

            v_obj = New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)

            If v_strACTION = "CHGLOGINPWD" Then
                'Kiem tra user co hop le khong
                v_strSQL = "select username || TO_CHAR(SYSDATE,'DDMMYYYYHHMMSS') USERTICKET from userlogin  where status='A' and upper(username)='" + v_strUSERNAME.Trim.ToUpper + "' and LOGINPWD=GENENCRYPTPASSWORD('" + v_strOLDPASSWORD.Trim.ToUpper + "')"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 0 Then
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: System error!" & vbNewLine _
                                 & "Error message: " & v_strSQL & "." & ControlChars.CrLf & ATTR_TABLE & "." & v_strUSERNAME, "EventLogEntryType.Error")
                    Return ERR_SA_ACCTNO_NOTFOUND
                Else
                    v_strSQL = "UPDATE USERLOGIN SET LASTCHANGED=SYSDATE, LOGINPWD=GENENCRYPTPASSWORD(UPPER('" & v_strNEWPASSWORD.Trim.ToUpper & "')) WHERE UPPER(USERNAME)='" & v_strUSERNAME.Trim.ToUpper & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If
            ElseIf v_strACTION = "CHGTRADINGPWD" Then
                'Kiem tra user co hop le khong
                v_strSQL = "select username || TO_CHAR(SYSDATE,'DDMMYYYYHHMMSS') USERTICKET from userlogin  where status='A' and upper(username)='" + v_strUSERNAME.Trim.ToUpper + "' and TRADINGPWD=GENENCRYPTPASSWORD('" + v_strOLDPASSWORD.Trim.ToUpper + "')"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 0 Then
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: System error!" & vbNewLine _
                                 & "Error message: " & v_strSQL & "." & ControlChars.CrLf & ATTR_TABLE & "." & v_strUSERNAME, "EventLogEntryType.Error")
                    Return ERR_SA_ACCTNO_NOTFOUND
                Else
                    v_strSQL = "UPDATE USERLOGIN SET LASTCHANGED=SYSDATE, TRADINGPWD=GENENCRYPTPASSWORD(UPPER('" & v_strNEWPASSWORD.Trim.ToUpper & "')) WHERE UPPER(USERNAME)='" & v_strUSERNAME.Trim.ToUpper & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If
            End If
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            Throw ex
        Finally
            XMLOrder = Nothing
            XMLDocument = Nothing
        End Try

    End Function

    Private Function GetServerTime(ByRef pv_strObjMsg As String) As Long
        Dim v_obj As DataAccess, v_ds As DataSet, v_strSQL As String
        Dim v_strErrorSource As String = ATTR_TABLE & ".MaintainUserMarketWatch"
        Dim XMLDocument As New XmlDocumentEx, XMLOrder As New XmlDocumentEx
        Dim v_nodeData, v_nodeOldData As Xml.XmlNode
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Try
            v_obj = New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
            v_strSQL = "SELECT TO_CHAR(SYSDATE,'HH24MISS') SYSTEMTIME, S1.VARVALUE FROMTIME, S2.VARVALUE  TOTIME,S3.VARVALUE  ATCSTARTTIME FROM SYSVAR S1,SYSVAR S2,SYSVAR S3 WHERE S1.GRNAME='SYSTEM' AND S1.VARNAME ='OLFROMTIME' AND S2.GRNAME='SYSTEM' AND S2.VARNAME ='OLTOTIME' AND S3.GRNAME='SYSTEM' and S3.VARNAME='ATCSTARTTIME'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            Dim v_strSYSTEMTIME As String = v_ds.Tables(0).Rows(0)("SYSTEMTIME")
            Dim v_strFROMTIME As String = v_ds.Tables(0).Rows(0)("FROMTIME")
            Dim v_strTOTIME As String = v_ds.Tables(0).Rows(0)("TOTIME")
            Dim v_strATCStartTime As String = v_ds.Tables(0).Rows(0)("ATCSTARTTIME")
            pv_strObjMsg = v_strSYSTEMTIME & ":" & v_strFROMTIME & ":" & v_strTOTIME & ":" & v_strATCStartTime
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            Throw ex
        Finally
            XMLOrder = Nothing
            XMLDocument = Nothing
        End Try

    End Function
End Class
