using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    public class TensionControlState
    {
        public string SelectedSection { get; set; }
        public string LabelArea { get; set; }
        public string LabelEspesor { get; set; }
        public string LabelD { get; set; }
        public string LabelH { get; set; }
        public string LabelAn { get; set; }
        public string LabelFt { get; set; } 
        public string DBox { get; set; }
        public string DaBox { get; set; }
        public string HBox { get; set; }
        public string CtBox { get; set; }
        public string Sy { get; set;}
        public string AceroF { get; set; }
        public Dictionary<string, SeccionData> SeccionesData { get; set; }
    }
}
