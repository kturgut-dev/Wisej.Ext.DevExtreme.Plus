namespace AIOERP.UI.Common.Helpers.Devextreme.DxDataGrid.Column
{
    public class DxLookupDataSource
    {
        public object dataSource { get; set; }
        public string valueExpr { get; set; } = "Id";
        public string displayExpr { get; set; } = "Name";

        public DxLookupDataSource()
        {

        }

        public DxLookupDataSource(object ds, string valueExpr, string displayExpr)
        {
            this.dataSource = ds;
            this.valueExpr = valueExpr;
            this.displayExpr = displayExpr;
        }

        public DxLookupDataSource(object ds)
        {
            this.dataSource = ds;
        }

    }

    public static class DxColumnFormat
    {
        public static class Date
        {
            public static string Normal { get; } = "dd/MM/yyyy";
            public static string MonthYear { get; } = "MM/yyyy";
            public static string UpperMonthYear { get; } = "MMMM/yyyy";
        }

        public static string DateFormat { get; } = "dd/MM/yyyy";
        public static string DateTimeFormat { get; } = "dd/MM/yyyy HH:mm";
        
        public static string DecimalFormat { get; } = "#,##0.####00";
        public static string DoubleFormat { get; } = "#,##0.00";
        
        public static string CurrencySymbolFormat { get; } = "#,##0.####00 ₺";
        public static string DoubleCurrencySymbolFormat { get; } = "#,##0.00 ₺";
    }
}
