using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DataToJson
{
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
}
