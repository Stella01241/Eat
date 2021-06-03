using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication11.Helper
{
    public class LoginHelper
    {
        //宣告兩個sessionkey登入帳號/登入狀態
        private const string _sessionKey = "IsLogined";
        private const string _sessionkey_Account = "Account";
        /// <summary> 檢查是否有登入 </summary>
        /// <returns></returns>
        public static bool HasLogined()
        {
            var val = HttpContext.Current.Session[_sessionKey];

            if (val != null)
                return true;
            else
                return false;
        }
        public static bool TryLogin(string account, string pwd)
        {
            if (LoginHelper.HasLogined())
                return true;

            // READ DB And check account / pwd
            DataTable dt = AccountManger.GetAccount(account);
            //假如Dt沒有資料回傳False
            if (dt == null || dt.Rows.Count == 0)
            {
                return false;
            }
            //抓資料庫的密碼來做比對
            string dbPwd = dt.Rows[0].Field<string>("Password");
            bool isPasswordRight = string.Compare(dbPwd, pwd) == 0;
            if (isPasswordRight)
            {
                HttpContext.Current.Session[_sessionkey_Account] = account;
                HttpContext.Current.Session[_sessionKey] = true;
                return true;

            }
            else
            {
                return false;
            }
        }

    }
}