using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIOERP.UI.Common.Helpers.Devextreme.DxDataGrid.Column
{
    public class DxColumnLookup : DxColumn
    {
        public DxLookupDataSource lookup { get; set; }

        public DxColumnLookup()
        {

        }

        public DxColumnLookup(DxLookupDataSource lookup)
        {
            this.lookup = lookup;
        }
    }
}
