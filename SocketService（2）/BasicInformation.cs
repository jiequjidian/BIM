using SocketService;
using SocketService.Model;
using System;
using System.Data;
using System.Text;

/// <summary>
/// 资产
/// </summary>
public class BasicInformation
{
    static StringBuilder SbSql;
    static string StrJson = string.Empty;

    /// <summary>
    /// 按设备类型，查询设备信息
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string GetEquipmentType(string str)
    {
        SbSql = new StringBuilder();

        SbSql.Append("SELECT id,AssetName,DeviceImage,DeviceType,InstallDate,DateAcceptance,WarrantyDate,Manufacturer,Contractor FROM dbo.Basic_Information");
        SbSql.AppendFormat(" where DeviceType = (select TYPE_ID from AssetClasses where TYPE_NAME='{0}')", str);
        try
        {
            DataSet ds = SqlHelper.Query(SbSql.ToString(), null);
            StrJson = Dataset2Json(ds);
        }
        catch (Exception ex)
        {
            LogHelper.error(ex.Message);
            StrJson = null;
        }

        return StrJson;
    }

    /// <summary>
    /// 查询设备类型
    /// </summary>
    /// <returns></returns>
    public static string Query_EquipmentType()
    {
        SbSql = new StringBuilder();

        SbSql.AppendFormat("select Type_ID,Type_Name from AssetClasses");
        try
        {
            DataSet ds = SqlHelper.Query(SbSql.ToString(), null);
            StrJson = Dataset2Json(ds);
        }
        catch (Exception ex)
        {
            LogHelper.error(ex.Message);
            StrJson = null;
        }

        return StrJson;
    }

    #region Equipment表，增删改查

    /// <summary>
    /// 模糊查询
    /// </summary>
    /// <param name="str">设备名称</param>
    /// <returns></returns>
    public static string FuzzyQuery_Equipment(string str)
    {
        SbSql = new StringBuilder();

        SbSql.Append("SELECT id,AssetName,DeviceImage,DeviceType,InstallDate,DateAcceptance,WarrantyDate,Manufacturer,Contractor FROM Basic_Information");
        SbSql.AppendFormat(" where AssetName like '%{0}%'", str);
        try
        {
            DataSet ds = SqlHelper.Query(SbSql.ToString(), null);
            StrJson = Dataset2Json(ds);
        }
        catch (Exception ex)
        {
            LogHelper.error(ex.Message);
            StrJson = null;
        }

        return StrJson;
    }


    /// <summary>
    /// 修改
    /// </summary>
    /// <returns></returns>
    public static int Update_Equipment(Basic_Information_model BI)
    {
        SbSql = new StringBuilder();

        int i = 0;
        SbSql.AppendFormat("update Basic_Information set AssetName='{0}',DeviceType={1},InstallDate='{2}',DateAcceptance='{3}',WarrantyDate='{4}',Manufacturer='{5}',Contractor='{6}'", BI.AssetName, BI.DeviceType, BI.InstallDate, BI.DateAcceptance, BI.WarrantyDate, BI.Manufacturer, BI.Contractor);
        SbSql.AppendFormat(" where id={0}", BI.id);
        try
        {
            i = SqlHelper.ExecuteSql(SbSql.ToString());
        }
        catch (Exception ex)
        {
            LogHelper.error(ex.Message);
            StrJson = null;
        }

        return i;
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <returns></returns>
    public static int Insert_Equipment(Basic_Information_model BI)
    {
        SbSql = new StringBuilder();

        int i = 0;
        SbSql.AppendFormat("INSERT INTO Basic_Information(AssetName,DeviceType,InstallDate,DateAcceptance,WarrantyDate,Manufacturer,Contractor)");
        SbSql.AppendFormat(" VALUES ('{0}',{1},'{2}','{3}','{4}','{5}','{6}')", BI.AssetName, BI.DeviceType, BI.InstallDate, BI.DateAcceptance, BI.WarrantyDate, BI.Manufacturer, BI.Contractor);
        try
        {
            i = SqlHelper.ExecuteSql(SbSql.ToString());
        }
        catch (Exception ex)
        {
            LogHelper.error(ex.Message);
            StrJson = null;
        }

        return i;
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <returns></returns>
    public static int Delete_Equipment(int id)
    {
        SbSql = new StringBuilder();

        int i = 0;
        SbSql.AppendFormat("DELETE FROM Basic_Information WHERE id = {0}", id);
        try
        {
            i = SqlHelper.ExecuteSql(SbSql.ToString());
        }
        catch (Exception ex)
        {
            LogHelper.error(ex.Message);
            StrJson = null;
        }

        return i;
    }
    #endregion

    #region Json格式转换
    /// <summary>  
    /// DataSet转换成Json格式  
    /// </summary>  
    /// <param name="ds">DataSet</param> 
    /// <returns></returns>  
    public static string Dataset2Json(DataSet ds)
    {
        string json = string.Empty;
        try
        {
            foreach (DataTable dt in ds.Tables)
            {
                json = DataTable2Json(dt);
            }
        }
        catch
        {
            return null;
        }

        return json.ToString();
    }

    /// <summary>
    /// table转json
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static string DataTable2Json(DataTable dt)
    {
        StringBuilder jsonBuilder = new StringBuilder();
        //jsonBuilder.Append("{\"Name\":\"" + dt.TableName + "\",\"Rows");
        jsonBuilder.Append("[");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            jsonBuilder.Append("{");
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                jsonBuilder.Append("\"");
                jsonBuilder.Append(dt.Columns[j].ColumnName);
                jsonBuilder.Append("\":\"");
                jsonBuilder.Append(dt.Rows[i][j].ToString().Replace("\"", "\\\""));
                jsonBuilder.Append("\",");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("},");
        }
        jsonBuilder.Remove(jsonBuilder.Length - 1, 1);

        jsonBuilder.Append("]");
        return jsonBuilder.ToString();
    }
    #endregion

}