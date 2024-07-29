﻿using AkumsPrintingApplication.PL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace AkumsPrintingApplication.DataLayer
{
    public class DL_CartonLabelPrinting
    {
        Common obj = new Common();
        SqlCommand cmd = null;
        public DataTable GetPrinterIP()
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_PRINTING_DATA";
                cmd.Parameters.AddWithValue("@type", "GETPRINTERIP");
                cmd.Parameters.AddWithValue("@SiteCode", PCommon.SiteCode);
                cmd.Parameters.AddWithValue("@LINECODE", PCommon.LineCode);
                DataSet ds = obj.ExecuteDataset(cmd);
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                throw ex;
            }
            return dt;
        }
        public DataTable BindCustomerCode()
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_PRINTING_DATA";
                cmd.Parameters.AddWithValue("@type", "BINDCUSTOMERCODE");
                DataSet ds = obj.ExecuteDataset(cmd);
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                throw ex;
            }
            return dt;
        }
        public DataTable GetCustomerDetails(string sCustomerCode)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_PRINTING_DATA";
                cmd.Parameters.AddWithValue("@type", "GETCUSTOMERDETAILS");
                cmd.Parameters.AddWithValue("@CUSTOMERCODE", sCustomerCode);
                DataSet ds = obj.ExecuteDataset(cmd);
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                throw ex;
            }
            return dt;
        }

        public DataTable ScanProcessCode(string sProcessCode)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_PRINTING_DATA";
                cmd.Parameters.AddWithValue("@type", "SCANPROCESS");
                cmd.Parameters.AddWithValue("@SiteCode", PCommon.SiteCode);
                cmd.Parameters.AddWithValue("@PROCESSCODE", sProcessCode);
                cmd.Parameters.AddWithValue("@LINECODE", PCommon.LineCode);
                DataSet ds = obj.ExecuteDataset(cmd);
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                throw ex;
            }
            return dt;
        }

        public DataTable BindLicence()
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_PRINTING_DATA";
                cmd.Parameters.AddWithValue("@type", "BINDLICENCE");
                cmd.Parameters.AddWithValue("@SiteCode", PCommon.SiteCode);
                DataSet ds = obj.ExecuteDataset(cmd);
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                throw ex;
            }
            return dt;
        }
        public DataTable BindCondition()
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_PRINTING_DATA";
                cmd.Parameters.AddWithValue("@type", "BINDCONDITION");
                cmd.Parameters.AddWithValue("@SiteCode", PCommon.SiteCode);
                DataSet ds = obj.ExecuteDataset(cmd);
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                throw ex;
            }
            return dt;
        }

        public DataTable SavePrintingData(PL_CartonLabelPrinting request)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_SHIPPER_PRINTING";
                cmd.Parameters.AddWithValue("@type", "SAVEDATA");
                cmd.Parameters.AddWithValue("@ManufactureCode", PCommon.SiteCode);
                cmd.Parameters.AddWithValue("@ProcessOrder", request.ProcessOrder);
                cmd.Parameters.AddWithValue("@BatchNo", request.BatchNo);
                cmd.Parameters.AddWithValue("@PrintedExpiryLabelFormat", request.PrintedExpiryLabelFormat);
                cmd.Parameters.AddWithValue("@Licence", request.Licence);
                cmd.Parameters.AddWithValue("@Quantity", request.Quantity);               
                cmd.Parameters.AddWithValue("@GrossWeight", request.GrossWeight);
                cmd.Parameters.AddWithValue("@Condition", request.Condition);
                cmd.Parameters.AddWithValue("@TargetShipper", request.TargetShipper);
                cmd.Parameters.AddWithValue("@Remarks", request.Remarks);
                cmd.Parameters.AddWithValue("@CustomerCode", request.CustomerCode);
                cmd.Parameters.AddWithValue("@PrintLine",PCommon.LineCode);
                cmd.Parameters.AddWithValue("@PrintedBy", PCommon.UserID);
                cmd.Parameters.AddWithValue("@isNotForSale", request.isNotForSale);
                cmd.Parameters.AddWithValue("@isNrx", request.isNrx);
                cmd.Parameters.AddWithValue("@isPhysicianSample", request.isPhysicianSample);
                cmd.Parameters.AddWithValue("@LL", request.isLl);
                cmd.Parameters.AddWithValue("@TM", request.isTm);
                cmd.Parameters.AddWithValue("@R", request.isR);
                cmd.Parameters.AddWithValue("@Subsidiary", request.isSubsidary);
                cmd.Parameters.AddWithValue("@PrintRequired", request.isPrintReqiured);
                cmd.Parameters.AddWithValue("@MonthInNum", request.MonthInName);
                cmd.Parameters.AddWithValue("@MonthInChar", request.MonthInChar);
                cmd.Parameters.AddWithValue("@YearInTwoDigit", request.YearInTwoDigit);
                cmd.Parameters.AddWithValue("@MAXWT", request.MaxWt);
                cmd.Parameters.AddWithValue("@MINWT", request.MinWt);
                cmd.Parameters.AddWithValue("@TAREWT", request.TareWt);
                cmd.Parameters.AddWithValue("@NETWeight", request.NetWeight);
                cmd.Parameters.AddWithValue("@MonthInCharYear", request.MonthInCharYear);
                cmd.Parameters.AddWithValue("@VerificationRemarks", request.RejectionRemarks);
                cmd.Parameters.AddWithValue("@mrp", request.Mrp);
                cmd.Parameters.AddWithValue("@CustomerName", request.Customer);
                cmd.Parameters.AddWithValue("@ProductDescription", request.ProductName);
                DataSet ds = obj.ExecuteDataset(cmd);
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                throw ex;
            }
            return dt;
        }

        public DataTable SaveTestPrintingData(PL_CartonLabelPrinting request)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_SHIPPER_PRINTING";
                cmd.Parameters.AddWithValue("@type", "SAVETESTDATA");
                cmd.Parameters.AddWithValue("@ManufactureCode", PCommon.SiteCode);
                cmd.Parameters.AddWithValue("@ProcessOrder", request.ProcessOrder);
                cmd.Parameters.AddWithValue("@BatchNo", request.BatchNo);
                cmd.Parameters.AddWithValue("@PrintedExpiryLabelFormat", request.PrintedExpiryLabelFormat);
                cmd.Parameters.AddWithValue("@Licence", request.Licence);
                cmd.Parameters.AddWithValue("@Quantity", request.Quantity);
                cmd.Parameters.AddWithValue("@GrossWeight", request.GrossWeight);
                cmd.Parameters.AddWithValue("@Condition", request.Condition);
                cmd.Parameters.AddWithValue("@TargetShipper", request.TargetShipper);
                cmd.Parameters.AddWithValue("@Remarks", request.Remarks);
                cmd.Parameters.AddWithValue("@CustomerCode", request.CustomerCode);
                cmd.Parameters.AddWithValue("@PrintLine", PCommon.LineCode);
                cmd.Parameters.AddWithValue("@PrintedBy", PCommon.UserID);
                cmd.Parameters.AddWithValue("@isNotForSale", request.isNotForSale);
                cmd.Parameters.AddWithValue("@isNrx", request.isNrx);
                cmd.Parameters.AddWithValue("@isPhysicianSample", request.isPhysicianSample);
                cmd.Parameters.AddWithValue("@LL", request.isLl);
                cmd.Parameters.AddWithValue("@TM", request.isTm);
                cmd.Parameters.AddWithValue("@R", request.isR);
                cmd.Parameters.AddWithValue("@Subsidiary", request.isSubsidary);
                cmd.Parameters.AddWithValue("@PrintRequired", request.isPrintReqiured);
                cmd.Parameters.AddWithValue("@MonthInNum", request.MonthInName);
                cmd.Parameters.AddWithValue("@MonthInChar", request.MonthInChar);
                cmd.Parameters.AddWithValue("@YearInTwoDigit", request.YearInTwoDigit);
                cmd.Parameters.AddWithValue("@MonthInCharYear", request.MonthInCharYear);
                cmd.Parameters.AddWithValue("@MAXWT", request.MaxWt);
                cmd.Parameters.AddWithValue("@MINWT", request.MinWt);
                cmd.Parameters.AddWithValue("@TareWt", request.TareWt);
                cmd.Parameters.AddWithValue("@CustomerName", request.Customer);
                cmd.Parameters.AddWithValue("@ProductDescription", request.ProductName);
                cmd.Parameters.AddWithValue("@NETWeight", request.NetWeight);
                cmd.Parameters.AddWithValue("@mrp", request.Mrp);


                DataSet ds = obj.ExecuteDataset(cmd);
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                throw ex;
            }
            return dt;
        }

        public DataTable GetPlantDetails()
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_SHIPPER_PRINTING";
                cmd.Parameters.AddWithValue("@type", "GETPLANTDETAILS");
                cmd.Parameters.AddWithValue("@ManufactureCode", PCommon.SiteCode);
                DataSet ds = obj.ExecuteDataset(cmd);
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                throw ex;
            }
            return dt;
        }

        public DataTable GetPrintingData(string sSerialNo)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_SHIPPER_PRINTING";
                cmd.Parameters.AddWithValue("@type", "GETSHIPPERDATA");
                cmd.Parameters.AddWithValue("@SHIPPERBARCODE", sSerialNo);
                DataSet ds = obj.ExecuteDataset(cmd);
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                throw ex;
            }
            return dt;
        }
        public DataTable ValidateShipperData(string UserID,string sPassword,string sModule)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_PRINTING_DATA";
                cmd.Parameters.AddWithValue("@type", "VALIDATESHIPPERUSER");
                cmd.Parameters.AddWithValue("@SITECODE", PCommon.SiteCode);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@Password", sPassword);
                cmd.Parameters.AddWithValue("@MODULENAME", sModule);
                
                DataSet ds = obj.ExecuteDataset(cmd);
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                throw ex;
            }
            return dt;
        }

        public DataTable SaveRePrintingData(string sShipperbarcode)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_SHIPPER_PRINTING";
                cmd.Parameters.AddWithValue("@type", "REPRINTBARCODE");
                cmd.Parameters.AddWithValue("@ManufactureCode", PCommon.SiteCode);
                cmd.Parameters.AddWithValue("@PrintLine", PCommon.LineCode);
                cmd.Parameters.AddWithValue("@PrintedBy", PCommon.UserID);
                cmd.Parameters.AddWithValue("@SHIPPERBARCODE", sShipperbarcode);
                
                DataSet ds = obj.ExecuteDataset(cmd);
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                throw ex;
            }
            return dt;
        }

        public DataTable GetLastPrintedData(string sProcessCode)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_SHIPPER_PRINTING";
                cmd.Parameters.AddWithValue("@type", "GETLASTPRINTEDDATA");
                cmd.Parameters.AddWithValue("@ProcessOrder", sProcessCode);
                DataSet ds = obj.ExecuteDataset(cmd);
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                throw ex;
            }
            return dt;
        }

        public DataSet GetShipperPrintingData(string sBatchNo)
        {
            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_SHIPPER_PRINTING";
                cmd.Parameters.AddWithValue("@type", "GETBATCHPRINTINGDATA");
                cmd.Parameters.AddWithValue("@Batchno", sBatchNo);
                ds = obj.ExecuteDataset(cmd);
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                throw ex;
            }
            return ds;
        }
    }
}
