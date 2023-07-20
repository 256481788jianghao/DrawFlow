using DrawFlow.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawFlow
{
    public class GVL
    {
        public static List<DF_File> df_file_list = new List<DF_File>();
        public static TabPage CurPage { get; set; } = null;
    }
}
