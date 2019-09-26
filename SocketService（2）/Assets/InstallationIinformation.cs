using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class InstallationIinformation
{
    /// <summary>
    /// 增加
    /// </summary>
    /// <param name="performance_Model"></param>
    /// <returns></returns>
    public static int AddInsert(Installation_Iinformation_model installation)
    {

        StringBuilder SbSql = new StringBuilder();

        SbSql.Append(@"INSERT INTO [dbo].[Installation_Iinformation]
           ([Installation]
           ,[EquipmentSize]
           ,[Material]
           ,[Model]
           ,[Number]
           ,[GroundingMethod]
           ,[GroundingResistance]
           ,[GroundingTechnology])");
        SbSql.AppendFormat(@" VALUES
           ('{0}'
           , '{1}'
           , '{2}'
           , '{3}'
           , {4}
           , '{5}'
           , '{6}'
           , '{7}')", installation.Installation, installation.EquipmentSize, installation.Material, installation.Model, installation.Number, installation.GroundingMethod, installation.GroundingResistance, installation.GroundingTechnology);

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
    public static int Delete(Installation_Iinformation_model installation)
    {
        StringBuilder SbSql = new StringBuilder();

        SbSql.Append(" delete from Installation_Iinformation ");
        SbSql.AppendFormat(" where  id = {0}", installation.id);
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
    public static int Change(Installation_Iinformation_model installation)
    {
        StringBuilder SbSql = new StringBuilder();

        SbSql.Append("UPDATE [dbo].[Installation_Iinformation]");
        SbSql.AppendFormat("  SET [id] = {0} where  id = {1}", installation.id, installation.id);
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

        SbSql.Append("seletc * from Installation_Iinformation");
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
