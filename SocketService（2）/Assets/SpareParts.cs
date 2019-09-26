using System;
using System.Data;
using System.Text;

public class SpareParts
{
    static string StrJson = string.Empty;

    #region 入库(SpareParts_in)

    /// <summary>
    /// 入库
    /// </summary>
    /// <param name="sp_im"></param>
    /// <returns></returns>
    public int addSpareParts(SpareParts_in_model sp_im)
    {
        StringBuilder sql = new StringBuilder();

        sql.Append("INSERT INTO SpareParts_in(OddNumbers,Date,Purpose,Department,WarehouseName,Receiver,AmountMoney,WarehouseKeeper,Auditor,Abstract,SparePartsList)");
        sql.AppendFormat(" VALUES({0},'{1}','{2}','{3}','{4}','{5}',{6},'{7}','{8}','{9}',{10}");
        int i = 0;
        try
        {
            i = SqlHelper.ExecuteSql(sql.ToString());
        }
        catch (Exception)
        {
            //StrJson = "[ {\"error\":\"" + ex.Message + "\"} ]";
            //StrJson = null;
        }

        return i;
    }

    #endregion

    #region 出库(SpareParts_out)

    /// <summary>
    /// 出库
    /// </summary>
    /// <param name="sp_im"></param>
    /// <param name="sp_lm"></param>
    public int outSpareParts(SpareParts_out_model sp_om)
    {
        StringBuilder sql = new StringBuilder();

        sql.Append("INSERT INTO SpareParts_out(OddNumbers,Date,Purpose,Department,Receiver,AmountMoney,WarehouseKeeper,Auditor,Abstract,SparePartsList)");
        sql.AppendFormat(" VALUES({0},'{1}','{2}','{3}','{4}','{5}',{6},'{7}','{8}','{9}',{10}");
        int i = 0;
        try
        {
            i = SqlHelper.ExecuteSql(sql.ToString());
        }
        catch (Exception)
        {
            //StrJson = "[ {\"error\":\"" + ex.Message + "\"} ]";
            //StrJson = null;
        }

        return i;
    }

    #endregion

    #region 清单表(SpareParts_List)

    /// <summary>
    /// 查询清单表
    /// </summary>
    /// <returns></returns>
    public int querySparePartsList()
    {
        StringBuilder sql = new StringBuilder();

        sql.Append("SELECT id,sp_Name,sp_Specifications,sp_Company,sp_Number,sp_UnitPrice,sp_money,sp_Explain,sp_state FROM SpareParts_List");
        int i = 0;
        try
        {
            i = SqlHelper.ExecuteSql(sql.ToString());
        }
        catch (Exception)
        {
            //StrJson = "[ {\"error\":\"" + ex.Message + "\"} ]";
            //StrJson = null;
        }

        return i;
    }

    /// <summary>
    /// 查询清单表中是否存在
    /// </summary>
    /// <param name="sp_lm"></param>
    /// <returns></returns>
    public int querySparePartsList(SpareParts_List_model sp_lm)
    {
        StringBuilder sql = new StringBuilder();

        sql.Append("SELECT id,sp_Name,sp_Specifications,sp_Company,sp_Number,sp_UnitPrice,sp_money,sp_Explain,sp_state FROM SpareParts_List");
        sql.Append(" where sp_Name = '{0}' and sp_Specifications='{1}' and sp_Company='{2}' and sp_UnitPrice={3}");
        int i = 0;
        try
        {
            i = SqlHelper.ExecuteSql(sql.ToString());
        }
        catch (Exception)
        {
            //StrJson = "[ {\"error\":\"" + ex.Message + "\"} ]";
            //StrJson = null;
        }

        return i;
    }

    /// <summary>
    /// 新品入库添加清单表
    /// </summary>
    /// <param name="sp_lm"></param>
    /// <returns></returns>
    public int addSparePartsList(SpareParts_List_model sp_lm)
    {
        StringBuilder sql = new StringBuilder();

        sql.Append("INSERT INTO SpareParts_List(ApplicantUnit,DeviceName,Specifications,Number)");
        sql.Append(" VALUES({0},'{1}','{2}','{3}','{4}')");
        int i = 0;
        try
        {
            i = SqlHelper.ExecuteSql(sql.ToString());
        }
        catch (Exception)
        {
            //StrJson = "[ {\"error\":\"" + ex.Message + "\"} ]";
            //StrJson = null;
        }

        return i;
    }

    /// <summary>
    /// 旧品入库修改清单表
    /// </summary>
    /// <param name="sp_lm"></param>
    /// <returns></returns>
    public int uptSparePartsList(SpareParts_List_model sp_lm)
    {
        StringBuilder sql = new StringBuilder();

        sql.AppendFormat("UPDATE SpareParts_List SET sp_Number=sp_Number+{0},sp_money =sp_money+sp_Number*{0} WHERE id = 1", 10);

        int i = 0;
        try
        {
            i = SqlHelper.ExecuteSql(sql.ToString());
        }
        catch (Exception)
        {
            //StrJson = "[ {\"error\":\"" + ex.Message + "\"} ]";
            //StrJson = null;
        }

        return i;
    }

    #endregion
}
