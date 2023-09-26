using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIOERP.UI.Common.Helpers.Devextreme.DxDataGrid.Column
{
    public class DxColumnForm : DxColumn
    {
        //public bool visible { get; set; } = true;
        //'dxAutocomplete' | 'dxCalendar' | 'dxCheckBox' | 'dxColorBox' | 'dxDateBox' | 'dxDropDownBox' | 'dxHtmlEditor' | 'dxLookup' | 'dxNumberBox' | 'dxRadioGroup' | 'dxRangeSlider' | 'dxSelectBox' | 'dxSlider' | 'dxSwitch' | 'dxTagBox' | 'dxTextArea' | 'dxTextBox'
        public string editorType { get; set; }
        public object editorOptions { get; set; }
        public object label { get; set; }

        public DxColumnForm()
        {

        }
    }

    public class DxColumnFormLabel
    {
        public string text { get; set; }
        public string location { get; set; } = "top";
        public bool visible { get; set; } = true;
        public bool showColon { get; set; } = true;
        public string alignment { get; set; } = "left";
    }
}
