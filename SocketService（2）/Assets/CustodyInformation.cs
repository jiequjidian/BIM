using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CustodyInformation
{
    /// <summary>
    /// 增加
    /// </summary>
    /// <param name="performance_Model"></param>
    /// <returns></returns>
    public static int AddInsert(Custody_Information_model Custody)
    {

        StringBuilder SbSql = new StringBuilder();

        SbSql.Append(@"INSERT INTO [dbo].[Custody_Information]
           ([WorkingState]
           ,[ManagementInstitutions]
           ,[InstallationPosition]
           ,[LaintenanceOrganizations]
           ,[PersonName]
           ,[phone])");
        SbSql.AppendFormat(@" VALUES
           ({0}
           , '{1}'
           , '{2}'
           , '{3}'
           , {4}
           , '{5}')", Custody.WorkingState, Custody.ManagementInstitutions, Custody.InstallationPosition, Custody.LaintenanceOrganizations, Custody.PersonName, Custody.phone);

        int reusolt = 0;
        try
        {
            reusolt = SqlHelper.ExecuteSql(SbSql.ToString());
        }
        catch (Exception ex)
        {
            reusolt = 0;
        }
        return reusolt;
    }

    /// <summary>
    /// 删除
    /// </summary>
    public static int Delete(Custody_Information_model Custody)
    {
        StringBuilder SbSql = new StringBuilder();

        SbSql.Append(" delete from Custody_Information ");
        SbSql.AppendFormat(" where  id = {0}", Custody.id);
        int reusolt = 0;
        try
        {
            reusolt = SqlHelper.ExecuteSql(SbSql.ToString());
        }
        catch (Exception ex)
        {
            reusolt = 0;
        }
        return reusolt;
    }

    /// <summary>
    /// 修改
    /// </summary>
    /// <returns></returns>
    public static int Change(Custody_Information_model Custody)
    {
        StringBuilder SbSql = new StringBuilder();

        SbSql.Append("UPDATE [dbo].[Custody_Information]");
        SbSql.AppendFormat("  SET [id] = {0} where  id = {1}", Custody.id, Custody.id);
        int reusolt = 0;
        try
        {
            reusolt = SqlHelper.ExecuteSql(SbSql.ToString());
        }
        catch (Exception ex)
        {
            reusolt = 0;
        }
        return reusolt;
    }

    /// <summary>
    /// 查询
    /// </summary>
    /// <returns></returns>
    public static string Query()
    {
        StringBuilder SbSql = new StringBuilder();

        SbSql.Append("seletc * from Custody_Information");
        string Json_performance = string.Empty;
        try
        {
            DataSet dataSet = SqlHelper.QueryDataSet(SbSql.ToString());
            Json_performance = DataToJson.Dataset2Json(dataSet);
        }
        catch (Exception ex)
        {
        }
        return Json_performance;
    }

}
