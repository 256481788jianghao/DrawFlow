using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawFlow.DataTypes
{
    public enum DF_FileType
    {
        MindFile,
        BaseFlowFile
    }
    public class DF_File
    {
        public DF_FileType fType { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }
        public TabPage RelativePage { get; set; }
    }
}
