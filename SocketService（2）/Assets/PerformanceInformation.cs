using SocketService.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketService
{
    public class PerformanceInformation
    {
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="performance_Model"></param>
        /// <returns></returns>
        public static int AddInsert(Performance_Information_model performance_Model)
        {

            StringBuilder SbSql = new StringBuilder();

            SbSql.Append("INSERT INTO [dbo].[Performance_Information]([id])");
            SbSql.AppendFormat(" values({0})", performance_Model.id);

            int reusolt = 0;
            try
            {
                reusolt = SqlHelper.ExecuteSql(SbSql.ToString());
            }
            catch (Exception ex)
            {
                LogHelper.error(ex.Message);
                reusolt = 0;
            }
            return reusolt;
        }

        /// <summary>
        /// 删除
        /// </summary>
        public static int Delete(Performance_Information_model performance_Model)
        {
            StringBuilder SbSql = new StringBuilder();

            SbSql.Append(" delete from Performance_Information ");
            SbSql.AppendFormat(" where  id = {0}", performance_Model.id);
            int reusolt = 0;
            try
            {
                reusolt = SqlHelper.ExecuteSql(SbSql.ToString());
            }
            catch (Exception ex)
            {
                LogHelper.error(ex.Message);
                reusolt = 0;
            }
            return reusolt;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public static int Change(Performance_Information_model performance_Model)
        {
            StringBuilder SbSql = new StringBuilder();

            SbSql.Append("UPDATE [dbo].[Performance_Information]");
            SbSql.AppendFormat("  SET[id] = {0} where  id = {1}", performance_Model.id, performance_Model.id);
            int reusolt = 0;
            try
            {
                reusolt = SqlHelper.ExecuteSql(SbSql.ToString());
            }
            catch(Exception ex)
            {
                LogHelper.error(ex.Message);
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

            SbSql.Append("seletc * from Performance_Information");
            string Json_performance = string.Empty;
            try
            {
                DataSet dataSet = SqlHelper.QueryDataSet(SbSql.ToString());
                Json_performance = Commom.Dataset2Json(dataSet);
            }
            catch (Exception ex)
            {
                LogHelper.error(ex.Message);
            }
            return Json_performance;
        }
    }
}
