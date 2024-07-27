using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    public class CompressionControlState
    {
        public string SelectedSection { get; set; }
        public string SelectedSteel { get; set; }
        public double Lx { get; set; }
        public double Lz { get; set; }
        public string LabelArea { get; set; }
        public string LabelX { get; set; }
        public string LabelZ { get; set; }
        public string LabelWt { get; set; }
        public string LabelKLr { get; set; }
        public string LabelCc { get; set; }
        public string LabelFa { get; set; }
        public string LabelCa { get; set; }
        public string Acero { get; set; }
        public double Fy { get; set; }
        public Dictionary<string, SeccionData> SeccionesData { get; set; }
    }
}
