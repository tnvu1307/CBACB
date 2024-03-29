Imports System.IO
Imports System.Text
Imports CommonLibrary
Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports System.Collections
Imports System.Xml.XmlReader
Imports CrystalDecisions.CrystalReports.Engine
Imports DevExpress.XtraReports.UI
Imports System.Collections.Generic

Partial Public Class frmReportParameter

    Dim dicParamaterXtraReport As Dictionary(Of String, String)

    Public Function CreateReportXtraReport(ByVal v_ds As DataSet, Optional ByVal acctNo As String = "", Optional ByVal custodyCd As String = "") As Boolean
        Dim result As Boolean = False
        Try
            'Check
            If CheckCreateXtraReport() = False Then

                v_ds.WriteXml(ReportDirectory & CMDID & ".xml", XmlWriteMode.WriteSchema)
                Return False
            End If
            If v_ds.Tables.Count = 0 Then
                MessageBox.Show(mv_ResourceManager.GetString("frmReportParameter.Nodata"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If
            'Check if nodata  is exists
            Dim v_hasData As Boolean = True
            For Each v_dt As DataTable In v_ds.Tables
                If v_dt.Rows.Count = 0 And v_dt.TableName <> colPictureName Then
                    v_hasData = False
                    Exit For
                End If
            Next
            If Not v_hasData Then
                MessageBox.Show(mv_ResourceManager.GetString("frmReportParameter.Nodata"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If


            'Init Paramater
            dicParamaterXtraReport = New Dictionary(Of String, String)
            dicParamaterXtraReport.Add(gc_RPT_FORMULAR_HEADOFFICE, HeadOffice)
            dicParamaterXtraReport.Add(gc_RPT_FORMULAR_HEADOFFICE_EN, HeadOffice_En)
            dicParamaterXtraReport.Add(gc_RPT_FORMULAR_COMPANY_NAME, BranchName)
            dicParamaterXtraReport.Add(gc_RPT_FORMULAR_COMPANY_NAME_EN, BranchName_En)
            dicParamaterXtraReport.Add(gc_RPT_FORMULAR_ADDRESS, BranchAddress)
            dicParamaterXtraReport.Add(gc_RPT_FORMULAR_ADDRESS_EN, BranchAddress_En)
            dicParamaterXtraReport.Add(gc_RPT_FORMULAR_PHONE_FAX, BranchPhoneFax)
            dicParamaterXtraReport.Add(gc_RPT_FORMULAR_PHONE_FAX_EN, BranchPhoneFax_en)
            dicParamaterXtraReport.Add(gc_RPT_FORMULAR_REPORT_TITLE, ReportTitle)
            dicParamaterXtraReport.Add(gc_RPT_FORMULAR_CREATED_DATE, CreatedDate)
            dicParamaterXtraReport.Add(gc_RPT_FORMULAR_CREATED_DATE_EN, CreatedDate_En)
            dicParamaterXtraReport.Add(gc_RPT_FORMULAR_CREATED_DATE_VN_EN, CreatedDate_VN_EN)
            dicParamaterXtraReport.Add(gc_RPT_FORMULAR_CREATED_BY, Teller)
            dicParamaterXtraReport.Add(gc_RPT_FORMULAR_DEPOSITID, DepositID)
            dicParamaterXtraReport.Add(gc_RPT_FORMULAR_WEBSITE, Website)

            For j As Integer = 0 To mv_intNumOfParam - 1
                Try
                    If (mv_arrObjFields(j).FieldName = "F_DATE") And Not dicParamaterXtraReport.ContainsKey(gc_RPT_FORMULAR_FROM_DATE) Then
                        dicParamaterXtraReport.Add(gc_RPT_FORMULAR_FROM_DATE, mv_arrRptParam(j + IIf(IsPublic = "Y", 0, 2)).ParamValue)
                    ElseIf (mv_arrObjFields(j).FieldName = "T_DATE") And Not dicParamaterXtraReport.ContainsKey(gc_RPT_FORMULAR_TO_DATE) Then
                        dicParamaterXtraReport.Add(gc_RPT_FORMULAR_TO_DATE, mv_arrRptParam(j + IIf(IsPublic = "Y", 0, 2)).ParamValue)
                    End If
                    If dicParamaterXtraReport.ContainsKey(gc_RPT_FORMULAR_FROM_DATE) And dicParamaterXtraReport.ContainsKey(gc_RPT_FORMULAR_TO_DATE) Then
                        Exit For
                    End If
                Catch ex As Exception
                    Continue For
                End Try
            Next

            Dim v_strCriterias As String = String.Empty
            v_strCriterias &= mv_arrRptParam(0).ParamCaption & ": " & mv_arrRptParam(0).ParamDescription
            If (ReportArea <> gc_REPORT_AREA_ALL) Then
                v_strCriterias &= "|" & mv_arrRptParam(1).ParamCaption & ": " & mv_arrRptParam(1).ParamDescription
            End If

            For j As Integer = 2 To mv_arrRptParam.Length - 1
                If (mv_arrRptParam(j).ParamName <> "F_DATE") And (mv_arrRptParam(j).ParamName <> "T_DATE") Then
                    If (mv_arrRptParam(j).ParamName.Length() > 0) And (mv_arrRptParam(j).ParamDescription.Length > 0) Then
                        v_strCriterias &= "|" & mv_arrRptParam(j).ParamCaption & ": " & mv_arrRptParam(j).ParamDescription
                    End If
                End If
            Next

            dicParamaterXtraReport.Add(gc_RPT_FORMULAR_REPORT_CRITERIAS, v_strCriterias)

            'Load Template
            Dim fileNameRepx As String = CMDID + ".repx"
            Dim fullPath As String = ReportDirectory & fileNameRepx
            Dim report As XtraReport
            Try
                report = XtraReport.FromFile(fullPath, True)
            Catch ex As Exception
                'trung.luu: 15-04-2020 Bị lỗi template report
                MessageBox.Show("Report template is error: " & fullPath & ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
            'Set data
            report.DataSource = v_ds
            'Set param value
            Dim paramaters = report.Parameters
            If paramaters.Count > 0 Then
                For Each prm As DevExpress.XtraReports.Parameters.Parameter In paramaters
                    If dicParamaterXtraReport.ContainsKey(prm.Name) Then
                        prm.Value = dicParamaterXtraReport(prm.Name)
                    End If
                Next
            End If

            'Formula

            Dim fileName As String = ""
            If String.IsNullOrEmpty(acctNo) Or String.IsNullOrEmpty(custodyCd) Then
                fileName = ReportTempDirectory & "\" & CMDID & TellerId
            Else
                fileName = ReportTempDirectory & "\" & acctNo & custodyCd
            End If
            Try
                report.CreateDocument()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            End Try
            report.PrintingSystem.SaveDocument(fileName & ".prnx")
            If IsPublic = "Y" Then
                report.ExportToPdf(fileName & ".pdf")
            End If

            result = True
        Catch ex As Exception
            result = False
        End Try
            Return result

    End Function

    Public Function CheckCreateXtraReport() As Boolean
        Dim result As Boolean = True
        Try
            'Check ton tai template hay khong
            Dim v_dirInfo As New DirectoryInfo(ReportDirectory)
            Dim v_fileInfo() As FileInfo = v_dirInfo.GetFiles("*.repx")
            Dim fileNameRepx As String = CMDID + ".repx"

            Dim fileExist As Boolean = False
            For Each v_file As FileInfo In v_fileInfo
                If v_file.Name = fileNameRepx Then
                    fileExist = True
                    Exit For
                End If
            Next
            If fileExist = False Then
                Throw New Exception(mv_ResourceManager.GetString("frmReportParameter.FileNotExists"))
            End If
        Catch ex As Exception
            result = False
            MessageBox.Show(ex.Message)
        End Try
        Return result
    End Function
End Class
