using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketService.Model
{
    /// <summary>
    /// 管养信息
    /// </summary>
    public class Custody_Information_model
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 工作状态
        /// </summary>
        public int WorkingState { get; set; }
        /// <summary>
        /// 管理机构
        /// </summary>
        public string ManagementInstitutions { get; set; }
        /// <summary>
        /// 安装位置
        /// </summary>
        public string InstallationPosition { get; set; }
        /// <summary>
        /// 设备维护机构名称
        /// </summary>
        public string LaintenanceOrganizations { get; set; }
        /// <summary>
        /// 负责人姓名
        /// </summary>
        public string PersonName { get; set; }
        /// <summary>
        /// 负责人电话
        /// </summary>
        public string phone { get; set; }
    }
}
