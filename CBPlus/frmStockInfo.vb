Imports AppCore
Imports System.Resources
Imports CommonLibrary
Imports System.Xml

Public Class frmStockInfo

#Region "Variables"

    Private GridStockInfo As GridEx

    Private _parentObjName As String

    Private _parentClause As String

    Private _linkValue As String

    Private _linkField As String

    Private _nextDate As String

    Private _isRiskManagement As Boolean

    Private _moduleCode As String

    Private _objectName As String

    Private _tableName As String

    Private _exeFlag As Integer

    Private _keyFieldName As String

    Private _keyFieldType As String

    Private _keyFieldValue As String

    Private _busDate As String

    Private _branchId As String

    Private _tellerId As String

    Private _authString As String

    Private _localObject As String

    Private _userLanguage As String

    Private _resourceManager As ResourceManager

    Private _tellerRight As String

    Private _groupCareBy As String
#End Region

#Region "Control events"
    Private Sub UpdatePrice(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdatePrice.Click
        Try
            Dim errorSource As String
            Dim errorCode As String
            Dim errorMessage As String
            Dim strMessage As String
            Dim ws As New AppCore.BDSDeliveryManagement
            Dim ret As Long

            Me.UseWaitCursor = True
            Me.Cursor = Cursors.WaitCursor

            strMessage = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "BD.Router", gc_ActionAdhoc, , , "updatePriceFromGW")
            ret = ws.Message(strMessage)

            If ret <> 0 Then
                GetErrorFromMessage(strMessage, errorSource, errorCode, errorMessage, Me.UserLanguage)

                MessageBox.Show(String.Format("{0}: {1} [{2}]", errorCode, errorMessage, errorSource), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                MessageBox.Show(ResourceManager.GetString("MSG_UPDATE_SUCCESSFUL"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            LogError.Write("Error source: _DIRECT.frmStockInfo.UpdatePrice" & vbNewLine _
             & "Error code: System error!" & vbNewLine _
             & "Error message: " & ex.Message, EventLogEntryType.Error)
        Finally
            Me.UseWaitCursor = False
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub GetAllStockInfo(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetAllStockInfo.Click
        Try
            Dim strMessage As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "BD.Router", gc_ActionAdhoc, , , "getAllStockInfor")

            Dim ws As New AppCore.BDSDeliveryManagement
            ws.Message(strMessage)

            Dim xmlDocument As New Xml.XmlDocument
            xmlDocument.LoadXml(strMessage)


            Dim xmlBPSNode As New XmlDocument

            Dim xmlMessage As String = String.Empty

            If xmlDocument.SelectSingleNode("ObjectMessage/BPSData") Is Nothing Then
                MsgBox(ResourceManager.GetString("MSG_NO_DATA_FOUND"))
                Exit Sub
            End If

            xmlMessage = xmlDocument.SelectSingleNode("ObjectMessage/BPSData").InnerText

            xmlBPSNode.LoadXml(xmlMessage)

            Dim ds As New DataSet
            ds.ReadXml(New XmlNodeReader(xmlBPSNode))

            GridStockInfo.BeginInit()

            GridStockInfo.SetDataBinding(ds, "StockInfor")
            'GridStockInfo.DataMember = "StockInfor"
            'FillDataGrid(GridStockInfo, xmlMessage, gc_RootNamespace & "." & Me.Name & "-" & UserLanguage, , , , , )

            '<FloorCode>10</FloorCode>
            '<FullName>Công ty Cổ phần Tập đoàn Ma San</FullName>
            '<Id>00000000-0000-0000-0000-000000000000</Id>
            '<PRIOR_PRICE i:nil="true"/>
            '<PT_MATCH_PRICE i:nil="true"/>
            '<PT_MATCH_QTTY i:nil="true"/>
            '<PT_TOTAL_TRADED_QTTY>0</PT_TOTAL_TRADED_QTTY>
            '<PT_TOTAL_TRADED_VALUE>0</PT_TOTAL_TRADED_VALUE>
            '<Status> | | | | | | </Status>
            '<StockId>2024</StockId>
            '<StockType>2</StockType>
            '<TOTAL_BID_QTTY i:nil="true"/>
            '<TOTAL_OFFER_QTTY i:nil="true"/>
            '<averagePrice i:nil="true"/>
            '<bidPrice1>110000</bidPrice1>
            '<bidPrice2>109000</bidPrice2>
            '<bidPrice3>108000</bidPrice3>
            '<bidVol1>4770</bidVol1>
            '<bidVol2>15320</bidVol2>
            '<bidVol3>11610</bidVol3>
            '<ceiling>116000</ceiling>
            '<change>3000</change>
            '<closePrice>111000</closePrice>
            '<closeVol>0</closeVol>
            '<floor>106000</floor>
            '<foreignBuy i:nil="true"/>
            '<foreignRemain i:nil="true"/>
            '<foreignRoom i:nil="true"/>
            '<foreignSell i:nil="true"/>
            '<high>112000</high>
            '<low>109000</low>
            '<offerPrice1>111000</offerPrice1>
            '<offerPrice2>112000</offerPrice2>
            '<offerPrice3>113000</offerPrice3>
            '<offerVol1>20860</offerVol1>
            '<offerVol2>21240</offerVol2>
            '<offerVol3>20850</offerVol3>
            '<open>111000</open>
            '<priceOne i:nil="true"/>
            '<priceTwo i:nil="true"/>
            '<reference>108000</reference>
            '<symbol>MSN</symbol>
            '<totalTrading>224650</totalTrading>
            '<totalTradingValue>247980</totalTradingValue>
            '<tradingdate>0001-01-01T00:00:00</tradingdate>

            'Hide columns
            GridStockInfo.Columns("FloorCode").Visible = False
            GridStockInfo.Columns("Id").Visible = False
            GridStockInfo.Columns("PRIOR_PRICE").Visible = False
            GridStockInfo.Columns("PT_MATCH_PRICE").Visible = False
            GridStockInfo.Columns("PT_MATCH_QTTY").Visible = False
            GridStockInfo.Columns("PT_TOTAL_TRADED_QTTY").Visible = False
            GridStockInfo.Columns("PT_TOTAL_TRADED_VALUE").Visible = False
            GridStockInfo.Columns("Status").Visible = False
            GridStockInfo.Columns("StockId").Visible = False
            GridStockInfo.Columns("StockType").Visible = False
            GridStockInfo.Columns("TOTAL_BID_QTTY").Visible = False
            GridStockInfo.Columns("TOTAL_OFFER_QTTY").Visible = False
            GridStockInfo.Columns("averagePrice").Visible = False
            GridStockInfo.Columns("bidPrice1").Visible = False
            GridStockInfo.Columns("bidPrice2").Visible = False
            GridStockInfo.Columns("bidPrice3").Visible = False
            GridStockInfo.Columns("bidVol1").Visible = False
            GridStockInfo.Columns("bidVol2").Visible = False
            GridStockInfo.Columns("bidVol3").Visible = False
            GridStockInfo.Columns("change").Visible = False
            GridStockInfo.Columns("closeVol").Visible = False
            GridStockInfo.Columns("foreignBuy").Visible = False
            GridStockInfo.Columns("foreignRemain").Visible = False
            GridStockInfo.Columns("foreignRoom").Visible = False
            GridStockInfo.Columns("foreignSell").Visible = False
            GridStockInfo.Columns("high").Visible = False
            GridStockInfo.Columns("low").Visible = False
            GridStockInfo.Columns("offerPrice1").Visible = False
            GridStockInfo.Columns("offerPrice2").Visible = False
            GridStockInfo.Columns("offerPrice3").Visible = False
            GridStockInfo.Columns("offerVol1").Visible = False
            GridStockInfo.Columns("offerVol2").Visible = False
            GridStockInfo.Columns("offerVol3").Visible = False
            GridStockInfo.Columns("priceOne").Visible = False
            GridStockInfo.Columns("priceTwo").Visible = False
            GridStockInfo.Columns("open").Visible = False
            GridStockInfo.Columns("priceOne").Visible = False
            GridStockInfo.Columns("totalTrading").Visible = False
            GridStockInfo.Columns("totalTradingValue").Visible = False
            GridStockInfo.Columns("tradingdate").Visible = False
            GridStockInfo.Columns("ceiling").Visible = False
            GridStockInfo.Columns("floor").Visible = False

            GridStockInfo.Columns("symbol").Title = ResourceManager.GetString("HEADER_GRID_SYMBOL")
            GridStockInfo.Columns("FullName").Title = ResourceManager.GetString("HEADER_GRID_FULLNAME")
            GridStockInfo.Columns("closePrice").Title = ResourceManager.GetString("HEADER_GRID_MATCH_PRICE")
            GridStockInfo.Columns("reference").Title = ResourceManager.GetString("HEADER_GRID_REF")

            GridStockInfo.Columns("symbol").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
            GridStockInfo.Columns("FullName").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            GridStockInfo.Columns("closePrice").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
            GridStockInfo.Columns("reference").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right

            GridStockInfo.EndInit()

            GridStockInfo.Columns("FullName").Width = GridStockInfo.Columns("FullName").GetFittedWidth()

        Catch ex As Exception
            LogError.Write("Error source: _DIRECT.frmStockInfo.GetAllStockInfo" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
        End Try


    End Sub

    Private Sub OnFormLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OnInit()
    End Sub

#End Region

#Region "Private methods"
    Private Sub OnInit()
        ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & Me.Name & "-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        Me.Text = ResourceManager.GetString("FORM_TITLE")
        GridStockInfo = New GridEx

        Dim cmrContactsHeader As New Xceed.Grid.ColumnManagerRow
        cmrContactsHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        cmrContactsHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        GridStockInfo.FixedHeaderRows.Add(cmrContactsHeader)

        pnStockInfo.Controls.Clear()
        Me.pnStockInfo.Controls.Add(GridStockInfo)
        GridStockInfo.Dock = Windows.Forms.DockStyle.Fill
    End Sub
#End Region

#Region "Properties"
    Public Property ParentObjName() As String Implements IForm.ParentObjName
        Get
            Return _parentObjName
        End Get
        Set(ByVal value As String)
            _parentObjName = value
        End Set
    End Property

    Public Property ParentClause() As String Implements IForm.ParentClause
        Get
            Return _parentClause
        End Get
        Set(ByVal value As String)
            _parentClause = value
        End Set
    End Property

    Public Property LinkValue() As String Implements IForm.LinkValue
        Get
            Return _linkValue
        End Get
        Set(ByVal value As String)
            _linkValue = value
        End Set
    End Property

    Public Property LinkField() As String Implements IForm.LinkField
        Get
            Return _linkField
        End Get
        Set(ByVal value As String)
            _linkField = value
        End Set
    End Property

    Public Property NextDate() As String Implements IForm.NextDate
        Get
            Return _nextDate
        End Get
        Set(ByVal value As String)
            _nextDate = value
        End Set
    End Property

    Public Property IsRiskManagement() As Boolean Implements IForm.IsRiskManagement
        Get
            Return _isRiskManagement
        End Get
        Set(ByVal value As Boolean)
            _isRiskManagement = value
        End Set
    End Property

    Public Property ModuleCode() As String Implements IForm.ModuleCode
        Get
            Return _moduleCode
        End Get
        Set(ByVal value As String)
            _moduleCode = value
        End Set
    End Property

    Public Property ObjectName() As String Implements IForm.ObjectName
        Get
            Return _objectName
        End Get
        Set(ByVal value As String)
            _objectName = value
        End Set
    End Property

    Public Property TableName() As String Implements IForm.TableName
        Get
            Return _tableName
        End Get
        Set(ByVal value As String)
            _tableName = value
        End Set
    End Property

    Public Property ExeFlag() As Integer Implements IForm.ExeFlag
        Get
            Return _exeFlag
        End Get
        Set(ByVal value As Integer)
            _exeFlag = value
        End Set
    End Property

    Public Property KeyFieldName() As String Implements IForm.KeyFieldName
        Get
            Return _keyFieldName
        End Get
        Set(ByVal value As String)
            _keyFieldName = value
        End Set
    End Property

    Public Property KeyFieldType() As String Implements IForm.KeyFieldType
        Get
            Return _keyFieldType
        End Get
        Set(ByVal value As String)
            _keyFieldType = value
        End Set
    End Property

    Public Property KeyFieldValue() As String Implements IForm.KeyFieldValue
        Get
            Return _keyFieldValue
        End Get
        Set(ByVal value As String)
            _keyFieldValue = value
        End Set
    End Property

    Public Property BusDate() As String Implements IForm.BusDate
        Get
            Return _busDate
        End Get
        Set(ByVal value As String)
            _busDate = value
        End Set
    End Property

    Public Property BranchId() As String Implements IForm.BranchId
        Get
            Return _branchId
        End Get
        Set(ByVal value As String)
            _branchId = value
        End Set
    End Property

    Public Property TellerId() As String Implements IForm.TellerId
        Get
            Return _tellerId
        End Get
        Set(ByVal value As String)
            _tellerId = value
        End Set
    End Property

    Public Property AuthString() As String Implements IForm.AuthString
        Get
            Return _authString
        End Get
        Set(ByVal value As String)
            _authString = value
        End Set
    End Property

    Public Property LocalObject() As String Implements IForm.LocalObject
        Get
            Return _localObject
        End Get
        Set(ByVal value As String)
            _localObject = value
        End Set
    End Property

    Public Property UserLanguage() As String Implements IForm.UserLanguage
        Get
            Return _userLanguage
        End Get
        Set(ByVal value As String)
            _userLanguage = value
        End Set
    End Property

    Public Property ResourceManager() As ResourceManager Implements IForm.ResourceManager
        Get
            Return _resourceManager
        End Get
        Set(ByVal value As ResourceManager)
            _resourceManager = value
        End Set
    End Property

    Public Property TellerRight() As String Implements IForm.TellerRight
        Get
            Return _tellerRight
        End Get
        Set(ByVal value As String)
            _tellerRight = value
        End Set
    End Property

    Public Property GroupCareBy() As String Implements IForm.GroupCareBy
        Get
            Return _groupCareBy
        End Get
        Set(ByVal value As String)
            _groupCareBy = value
        End Set
    End Property
#End Region
End Class