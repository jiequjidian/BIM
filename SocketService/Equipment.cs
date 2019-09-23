using SocketService.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketService
{
    class Equipment
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

            SbSql.Append("select E_ID,E_Name,E_Type,E_Specifications,E_Number,E_Unit,E_Remarks from Equipment ");
            SbSql.AppendFormat("where E_Type = (select TYPE_ID from EquipmentType where TYPE_NAME='{0}')", str);
            try
            {
                DataSet ds = SqlHelper.Query(SbSql.ToString(), null);
                StrJson = Dataset2Json(ds);
            }
            catch (Exception ex)
            {
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

            SbSql.AppendFormat("select Type_ID,Type_Name from EquipmentType");
            try
            {
                DataSet ds = SqlHelper.Query(SbSql.ToString(), null);
                StrJson = Dataset2Json(ds);
            }
            catch (Exception ex)
            {
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

            SbSql.Append("SELECT E_ID,E_Name,E_Type,E_Specifications,E_Number,E_Unit,E_Remarks FROM Equipment ");
            SbSql.AppendFormat("where E_Name like '%{0}%'", str);
            try
            {
                DataSet ds = SqlHelper.Query(SbSql.ToString(), null);
                StrJson = Dataset2Json(ds);
            }
            catch (Exception ex)
            {
                StrJson = null;
            }

            return StrJson;
        }


        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public static int Update_Equipment(Equipment_Model em)
        {
            SbSql = new StringBuilder();

            int i=0;
            SbSql.AppendFormat("update Equipment SET [E_Name] = '{0}',[E_Specifications] = '{1}',[E_Number] = '{2}',[E_Unit] = '{3}',[E_Remarks] = '{4}' ", em.E_Name, em.E_Specifications, em.E_Number, em.E_Unit, em.E_Remarks);
            SbSql.AppendFormat("where E_ID = {0}", em.E_ID);
            try
            {
                i = SqlHelper.ExecuteSql(SbSql.ToString());
            }
            catch (Exception ex)
            {
                StrJson = null;
            }

            return i;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        public static int Insert_Equipment(Equipment_Model em)
        {
            SbSql = new StringBuilder();

            int i = 0;
            SbSql.AppendFormat("INSERT INTO Equipment(E_Name,E_Type,E_Specifications,E_Number,E_Unit,E_Remarks )", 0);
            SbSql.AppendFormat("VALUES ('{0}',{1},'{2}',{3},'{4}','{5}')", em.E_Name, em.E_Type, em.E_Specifications, em.E_Number, em.E_Unit, em.E_Remarks);
            try
            {
                i = SqlHelper.ExecuteSql(SbSql.ToString());
            }
            catch (Exception ex)
            {
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
            SbSql.AppendFormat("DELETE FROM Equipment WHERE E_ID = {0}", id);
            try
            {
                i = SqlHelper.ExecuteSql(SbSql.ToString());
            }
            catch (Exception ex)
            {
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
}
