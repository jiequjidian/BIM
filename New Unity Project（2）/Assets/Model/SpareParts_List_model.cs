using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Model
{
    public class SpareParts_List_model
    {
        public int id { get; set; }
        public string sp_Name { get; set; }
        public string sp_Specifications { get; set; }
        public string sp_Company { get; set; }
        public int sp_Number { get; set; }
        public float sp_UnitPrice { get; set; }
        public float sp_money { get; set; }
        public string sp_Explain { get; set; }
        public int sp_state { get; set; }
    }
}
