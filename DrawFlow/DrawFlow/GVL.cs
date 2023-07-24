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
        public static DF_File CurFile { get; set; } = null;


        public static int shape_pad = 8;
        public static int text_pad = shape_pad + 2;
    }
}
