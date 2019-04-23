using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXPTClient
{
    public class Comm
    {
        /// <summary>
        /// Web引用
        /// </summary>
        WebReference.Service1 service = new WebReference.Service1();

        string login_name = "qlyytz";
        string password = "qlyytz123";

        public string SendMessage(string phoneNum,string msg, string sendTime)
        {
            WriteLog(DateTime.Now.ToString("yyyy-MM-dd"), "[" + DateTime.Now.ToString() + "]发送短信到：" 
                + phoneNum + ",内容：" + msg + ",发送时间：" + sendTime);

            string result = service.SendSms4(login_name, password, phoneNum, msg, sendTime, "", "");

            WriteLog(DateTime.Now.ToString("yyyy-MM-dd"), "[" + DateTime.Now.ToString() + "]发送结果：" + result);

            return result;
        }

        /// <summary>
        /// 日志记录
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public string WriteLog(string fileName, string msg)
        {
            string path = Neusoft.FrameWork.WinForms.Classes.Function.CurrentPath + "\\Logs\\DXPTLog";
            try
            {
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }

                fileName = path + "\\" + fileName + ".log";

                if (!System.IO.File.Exists(fileName))
                {
                    System.IO.StreamWriter sw = System.IO.File.CreateText(fileName);
                    sw.Close();
                }
                string writeMsg = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "==>" + msg;
                System.IO.TextWriter writer = System.IO.File.AppendText(fileName);
                writer.WriteLine(writeMsg);
                writer.Close();
                return writeMsg + "\r\n";
            }
            catch (Exception ex)
            {
                return "记录日志异常：" + ex.Message + "[" + ex.Message + "]";
            }
        }
    }
}
