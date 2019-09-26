using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketService.Model
{
    /// <summary>
    /// 基本信息
    /// </summary>
    public class Basic_Information_model
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 资产名称
        /// </summary>
        public string AssetName { get; set; }
        /// <summary>
        /// 图像
        /// </summary>
        //public image DeviceImage { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public int DeviceType { get; set; }
        /// <summary>
        /// 安装日期
        /// </summary>
        public string InstallDate { get; set; }
        /// <summary>
        /// 验收日期
        /// </summary>
        public string DateAcceptance { get; set; }
        /// <summary>
        /// 质保日期
        /// </summary>
        public string WarrantyDate { get; set; }
        /// <summary>
        /// 制造商
        /// </summary>
        public string Manufacturer { get; set; }
        /// <summary>
        /// 承建商
        /// </summary>
        public string Contractor { get; set; }
    }
}
