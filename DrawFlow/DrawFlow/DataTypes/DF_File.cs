using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawFlow.DataTypes
{
    public class DF_File
    {
        public string Name { get; set; }
        public string FilePath { get; set; }
        public TabPage RelativePage { get; set; }
    }
}
