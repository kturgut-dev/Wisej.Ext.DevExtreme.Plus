using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIOERP.UI.Common.Helpers.Devextreme.DxDataGrid.Column
{
    public class DxColumn
    {
        public string dataField { get; set; }
        public string format { get; set; } = "";
        public string caption { get; set; }
        public object width { get; set; } = "auto";
        public bool visible { get; set; } = true;
        public bool allowEditing { get; set; } = true;
        public object autoExpandGroup { get; set; } = true; //bool
        public int? groupIndex { get; set; } = null;
        public object groupCellTemplate { get; set; } = null;
        public int? visibleIndex { get; set; } = null;
        //public object visibleIndex { get; set; } = true;
        public bool allowFiltering { get; set; } = true;
        public DxColumnForm formItem { get; set; } = null;
        //public object dataType { get; set; } = "string";
        public DxColumn()
        {

        }

        public DxColumn(string headerText, string field)
        {
            caption = headerText;
            dataField = field;
        }
    }
}
