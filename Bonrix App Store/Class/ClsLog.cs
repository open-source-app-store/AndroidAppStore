using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Bonrix_App_Store.Class
{
    public static class ClsLog
    {
        public static void LogException(Exception exc, string source)
        {
            try
            {
                // Include enterprise logic for logging exceptions 
                // Get the absolute path to the log file 

                string LogDirectory = ConfigurationManager.AppSettings["LogDirectory"].ToString();
                DirectoryInfo objDirectoryInfo = new DirectoryInfo(LogDirectory);
                if (!objDirectoryInfo.Exists)
                {
                    Directory.CreateDirectory(LogDirectory);
                }

                LogDirectory = LogDirectory + "ErrorLog_" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";
                //if(!File.Exists(LogDirectory))
                //{
                //    //LogDirectory = LogDirectory + "ErrorLog_" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";                    
                //}

                // Open the log file for append and write the log
                StreamWriter sw = new StreamWriter(LogDirectory, true);
                sw.WriteLine("************************************************************ {0} ************************************************************", DateTime.Now);
                if (exc.InnerException != null)
                {
                    sw.Write("Inner Exception Type: ");
                    sw.WriteLine(exc.InnerException.GetType().ToString());
                    sw.Write("Inner Exception: ");
                    sw.WriteLine(exc.InnerException.Message);
                    sw.Write("Inner Source: ");
                    sw.WriteLine(exc.InnerException.Source);
                    if (exc.InnerException.StackTrace != null)
                    {
                        sw.WriteLine("Inner Stack Trace: ");
                        sw.WriteLine(exc.InnerException.StackTrace);
                    }
                }
                sw.Write("Exception Type: ");
                sw.WriteLine(exc.GetType().ToString());
                sw.WriteLine("Exception: " + exc.Message);
                sw.WriteLine("Source: " + source);
                sw.WriteLine("Stack Trace: ");
                if (exc.StackTrace != null)
                {
                    sw.WriteLine(exc.StackTrace);
                    sw.WriteLine();
                }
                sw.Close();
            }
            catch (Exception ex)
            {

            }
        }

        public static void Url_Log(string type, string Request_Response)
        {
            try
            {
                // Include enterprise logic for logging exceptions 
                // Get the absolute path to the log file 

                string LogDirectory = ConfigurationManager.AppSettings["LogDirectory"].ToString();
                DirectoryInfo objDirectoryInfo = new DirectoryInfo(LogDirectory);
                if (!objDirectoryInfo.Exists)
                {
                    Directory.CreateDirectory(LogDirectory);
                }

                LogDirectory = LogDirectory + "AppStore " + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";

                // Open the log file for append and write the log
                StreamWriter sw = new StreamWriter(LogDirectory, true);
                //string textWrite = "";
                StringBuilder sb = new StringBuilder();
                sw.WriteLine("************************************************************ {0} ************************************************************", DateTime.Now);
                //textWrite = textWrite.Insert(0, "************************************************************ {0} ************************************************************" + DateTime.Now + Environment.NewLine);
                if (type.ToLower() == "request")
                {
                    //textWrite = textWrite.Insert(0, "Request : " + Environment.NewLine);
                    //sw.Write("Request : ");
                    sb.AppendLine("Request : ");
                }
                else
                {
                    //textWrite = textWrite.Insert(0, "Response : " + Environment.NewLine);
                    //sw.Write("Response : ");
                    sb.AppendLine("Response : ");
                }
                //textWrite = textWrite.Insert(0, Request_Response.ToString() + Environment.NewLine);
                //sw.WriteLine(textWrite);
                //sw.WriteLine(Request_Response.ToString() + Environment.NewLine);
                sb.AppendLine(Request_Response.ToString());
                sw.WriteLine(sb);
                sw.Close();
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}