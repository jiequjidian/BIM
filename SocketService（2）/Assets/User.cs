using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

public class User
{
    static string StrJson = string.Empty;
    public static string login2(string name,string pwd)
    {
        StringBuilder sql = new StringBuilder(); 

        sql.Append("select u.ID,u.Name,u.Gender,u.DateOfBirth,u.Age,u.Pwd,u.Department,u.DocumentType,u.PhoneNumber,u.Title,u.TelephoneStation,u.Phone,r.RoleName from r_user_role rur");
        sql.Append(" inner join [User] as u on u.ID = rur.user_id");
        sql.Append(" inner join role as r on r.ID = rur.role_id");
        sql.AppendFormat(" where u.Name = '{0}' and u.Pwd = '{1}'", name, pwd);

        try
        {
            DataSet ds = SqlHelper.Query(sql.ToString(), null);
            StrJson = DataToJson.Dataset2Json(ds);
        }
        catch (Exception)
        {
            //StrJson = "[ {\"error\":\"" + ex.Message + "\"} ]";
            StrJson = null;
        }

        return StrJson;
    }
}

