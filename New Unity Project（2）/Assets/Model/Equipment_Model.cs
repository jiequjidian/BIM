using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Assets.Model
{
    public class Equipment_model
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string E_ID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string E_Name { get; set; }
        /// <summary>
        /// 类型编号
        /// </summary>
        public string E_Type { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string E_Specifications { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public string E_Number { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string E_Unit { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string E_Remarks { get; set; }
    }
}