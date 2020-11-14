using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace HttpHelper
{
    public static class FileHelper
    {
        public static DataTable GetTableGB(string Path,int StartLine)
        {
            DataTable dt = new DataTable();
            try
            {
                
                using (FileStream fs = new FileStream(Path, FileMode.Open, FileAccess.Read))
                {
                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                    StreamReader sr = new StreamReader(fs,Encoding.GetEncoding("GB2312"));
                    for (int i = 0; i < StartLine; i++)
                    {
                        sr.ReadLine();
                    }
                    string ReadStr = sr.ReadLine();
                    foreach (var item in ReadStr.Split(','))
                    {
                        dt.Columns.Add(item);
                    }
                    string FixStr = string.Empty;
                    while((ReadStr = sr.ReadLine())!=null)
                    {
                        ReadStr = FixStr + ReadStr;
                        DataRow dr = dt.NewRow();
                        string[] fileds = ReadStr.Split(',');
                        if(fileds.Length>=dt.Columns.Count)
                        {
                            for (int i = 0; i < fileds.Length; i++)
                            {
                                dr[i] = fileds[i];
                            }
                            dt.Rows.Add(dr);
                            FixStr = string.Empty;
                        }
                        else
                        {
                            FixStr = ReadStr;
                            continue;
                        }
                        
                    }
                }
                return dt;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public static DataTable GetTable(string Path, int StartLine)
        {
            DataTable dt = new DataTable();
            try
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                using (FileStream fs = new FileStream(Path, FileMode.Open, FileAccess.Read))
                {
                    StreamReader sr = new StreamReader(fs);
                    for (int i = 0; i < StartLine; i++)
                    {
                        sr.ReadLine();
                    }
                    string ReadStr = sr.ReadLine();
                    foreach (var item in ReadStr.Split(','))
                    {
                        dt.Columns.Add(item);
                    }
                    while ((ReadStr = sr.ReadLine()) != null)
                    {
                        DataRow dr = dt.NewRow();
                        string[] fileds = ReadStr.Split(',');
                        for (int i = 0; i < fileds.Length; i++)
                        {
                            dr[i] = fileds[i];
                        }
                        dt.Rows.Add(dr);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
