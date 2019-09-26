using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketService.Model
{
    /// <summary>
    /// 安装信息
    /// </summary>
    public class Installation_Iinformation_model
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 安装方式
        /// </summary>
        public string Installation { get; set; }
        /// <summary>
        /// 设备尺寸
        /// </summary>
        public string EquipmentSize { get; set; }
        /// <summary>
        /// 材质
        /// </summary>
        public string Material { get; set; }
        /// <summary>
        /// 型号
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// 接地方式
        /// </summary>
        public string GroundingMethod { get; set; }
        /// <summary>
        /// 接地电阻
        /// </summary>
        public string GroundingResistance { get; set; }
        /// <summary>
        /// 接地工艺
        /// </summary>
        public string GroundingTechnology { get; set; }
    }
}
