using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security;
using System.Security.Cryptography;

namespace WebApplication1.Tool
{
    public static class Tool
    {
        /// <summary>
        /// Md5加密
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static string MD5(string pwd)
        {
            System.Security.Cryptography.MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.Default.GetBytes(pwd);
            byte[] md5data = md5.ComputeHash(data);
            md5.Clear();
            string str = "";
            for (int i = 0; i < md5data.Length; i++)
            {
                str += md5data[i].ToString("x").PadLeft(2, '0');

            }
            return str.ToLower();
        }

        public static int Obj2Int(object obj, int default_value)
        {
            try
            {
                int result = int.Parse(obj.ToString());
                return result;
            }
            catch
            {
                return default_value;
            }
        }

        public static int Obj2Int(object obj)
        {
            return Obj2Int(obj, 0);
        }

        public static int RequestQstrInt(string q, int default_value)
        {
            if (HttpContext.Current.Request.QueryString[q] != null)
            {
                return Obj2Int(HttpContext.Current.Request.QueryString[q], default_value);
            }
            else
            {
                return default_value;
            }
        }
        public static int RequestQstrInt(string q)
        {
            return RequestQstrInt(q, 0);
        }

        public static string ReStr(string str, int count)
        {
            string result = "";
            for (int i = 0; i < count; i++)
            {
                result += str;
            }
            return result;
        }

    }
}