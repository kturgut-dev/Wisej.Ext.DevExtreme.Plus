using AIOERP.UI.Common.Helpers.Devextreme.DxDataGrid.Column;
using System;
using System.Collections.Generic;
using System.Linq;
using Wisej.Ext.DevExtreme.Plus.Extensions;
using Wisej.Web;

namespace Wisej.Ext.DevExtreme.Plus
{
    public partial class dxBaseConfigurator
    {
        public void BeginCustomLoading()
        {
            dxInstance.Instance.beginCustomLoading();
        }

        public void EndCustomLoading()
        {
            dxInstance.Instance.endCustomLoading();
        }

        public dxBaseConfigurator KeyExpr(string key = "Id")
        {
            dxInstance.Options.keyExpr = key;
            return this;
        }

        public dxBaseConfigurator MasterDetail(bool enabled, string template, string functionJS = "")
        {
            //"masterDetail": {
            //    "enabled": true,
            //    "template": "detailTemplateInit"
            //}
            dxInstance.Options.masterDetail = new
            {
                enabled,
                template
            };

            if (functionJS != null)
            {
                List<Wisej.Web.Ext.DevExtreme.dxBase.WidgetFunction> WidgetFunctions = dxInstance.WidgetFunctions?.ToList();
                if (WidgetFunctions == null)
                    WidgetFunctions = new List<Wisej.Web.Ext.DevExtreme.dxBase.WidgetFunction>();

                WidgetFunctions.Add(new Wisej.Web.Ext.DevExtreme.dxBase.WidgetFunction()
                {
                    Name = template,
                    Source = functionJS
                });

                dxInstance.WidgetFunctions = WidgetFunctions.ToArray();
            }

            return this;
        }

        public dxBaseConfigurator OnRowPrepared(string functionJS = "")
        {
            if (functionJS != null)
            {
                List<Wisej.Web.Ext.DevExtreme.dxBase.WidgetEventHandler> WidgetFunctions = dxInstance.WidgetEvents?.ToList();
                if (WidgetFunctions == null)
                    WidgetFunctions = new List<Wisej.Web.Ext.DevExtreme.dxBase.WidgetEventHandler>();

                WidgetFunctions.Add(new Wisej.Web.Ext.DevExtreme.dxBase.WidgetEventHandler()
                {
                    Name = "onRowPrepared",
                    Source = functionJS
                });

                dxInstance.WidgetEvents = WidgetFunctions.ToArray();
            }

            return this;
        }

        public dxBaseConfigurator LoadPanel(bool visible = false, bool showIndicator = true)
        {
            dxInstance.Options.loadPanel = new
            {
                height = 100,
                width = 250,
                shadingColor = "#ddd",
                showIndicator = showIndicator,
                visible = visible,
                hideOnOutsideClick = false,
                shading = true,
                showPane = true
            };
            return this;
        }

        public dxBaseConfigurator SetDataSource(object dataSource)
        {
            dxInstance.Options.dataSource = dataSource;
            if (dataSourceChanged != null)
                dataSourceChanged(dxInstance, new WidgetEventArgs("dataSourceChanged", dataSource));

            return this;
        }

        public dxBaseConfigurator SetColumns(List<object> columns)
        {
            dxInstance.Options.columns = columns;
            return this;
        }

        public dxBaseConfigurator SetColumns(object[] columns)
        {
            dxInstance.Options.columns = columns;
            return this;
        }

        //public dxDataGridConfigurator GroupPanel(DxGroupPanel settings)
        //{
        //    dxDataGridInstance.Options.groupPanel = settings;
        //    return this;
        //}

        public dxBaseConfigurator GroupPanel(bool value, string emptyPanelText = "Sütuna göre gruplamak için bir sütun başlığını buraya sürükleyin")
        {
            dxInstance.Options.groupPanel = new
            {
                visible = value,
                emptyPanelText = emptyPanelText
            };
            return this;
        }

        public dxBaseConfigurator Grouping(bool autoExpandAll = false, bool contextMenuEnabled = false, bool allowCollapsing = true)
        {
            dxInstance.Options.grouping = new
            {
                autoExpandAll = autoExpandAll,
                contextMenuEnabled = contextMenuEnabled,
                allowCollapsing = allowCollapsing
            };
            return this;
        }

        public dxBaseConfigurator ColumnFixing(bool value)
        {
            dxInstance.Options.columnFixing = new
            {
                enabled = value
            };
            return this;
        }

        public dxBaseConfigurator ShowColumnLines(bool value)
        {
            dxInstance.Options.showColumnLines = value;
            return this;
        }

        private object Popup(string title = "Kayıt Bilgi")
        {
            return new
            {
                title = title,
                showTitle = true,
                width = 1000,
                height = 600,
                dragEnabled = true,
                closeOnOutsideClick = true,
                showCloseButton = true,
            };
        }

        public dxBaseConfigurator HoverStateEnabled(bool value)
        {
            dxInstance.Options.hoverStateEnabled = value;
            return this;
        }

        public dxBaseConfigurator ColumnResizingMode(string value = "widget") // nextColumn - widget
        {
            dxInstance.Options.columnResizingMode = value;
            return this;
        }

        public dxBaseConfigurator RowAlternationEnabled(bool value)
        {
            dxInstance.Options.rowAlternationEnabled = value;
            return this;
        }

        //'infinite' | 'standard' | 'virtual'
        public dxBaseConfigurator Scrolling(ScrollingMode mode)
        //public dxDataGridConfigurator Scrolling(string mode = "standard")
        {
            dxInstance.Options.scrolling = new { mode = Enum.GetName(typeof(ScrollingMode), mode).ToLower() };
            return this;
        }

        public dxBaseConfigurator Paging(bool enabled = false, int pageSize = 100, int pageIndex = 0)
        {
            dxInstance.Options.paging = new
            {
                enabled = enabled,
                pageSize = pageSize,
                pageIndex = pageIndex
            };
            return this;
        }

        public dxBaseConfigurator Pager(bool visible)
        {
            dxInstance.Options.pager = new
            {
                visible = visible,
                showPageSizeSelector = true,
                displayMode = "compact",
                allowedPageSizes = new int[] { 100, 500, 1000 },
                showInfo = false
            };
            return this;
        }

        //public dxDataGridConfigurator MultipleSelection(bool value) // onClick - onLongTap - always - none
        //{
        //    dxInstance.Options.selection = new
        //    {
        //        mode = value ? "multiple" : "single"
        //    };
        //    return this;
        //}

        // onClick - onLongTap - always - none
        public dxBaseConfigurator MultipleSelection(bool value, string showCheckBoxesMode = "always")
        {
            dxInstance.Options.selection = new
            {
                mode = value ? "multiple" : "single",
                showCheckBoxesMode = showCheckBoxesMode
            };
            return this;
        }

        public bool IsMultipleSelectionActive { get { return dxInstance.Options.selection != null && dxInstance.Options.selection?.mode == "multiple"; } }

        public dxBaseConfigurator ShowRowLines(bool value)
        {
            dxInstance.Options.showRowLines = value;
            return this;
        }

        public dxBaseConfigurator ShowBorders(bool value)
        {
            dxInstance.Options.showBorders = value;
            return this;
        }

        public dxBaseConfigurator AllowColumnResizing(bool value)
        {
            dxInstance.Options.allowColumnResizing = value;
            return this;
        }

        public dxBaseConfigurator FilterPanel(bool value)
        {
            dxInstance.Options.filterPanel = new { visible = value };
            return this;
        }

        public dxBaseConfigurator ColumnChooser(bool value)
        {
            dxInstance.Options.columnChooser = new
            {
                enabled = value,
                //mode = "select",
                //search = new
                //{
                //    enabled = true,
                //    editorOptions = new { placeholder = "Sütün Ara" }
                //},
                //selection = new
                //{
                //    recursive = true,
                //    selectByClick = true,
                //    allowSelectAll = true,
                //},
                //position = new
                //{
                //    my = "right top",
                //    at = "right bottom",
                //    of = ".dx-datagrid-column-chooser-button"
                //}
            };
            return this;
        }

        //public dxDataGridConfigurator ColumnFixing(bool value)
        //{
        //    dxInstance.Options.columnFixing = new
        //    {
        //        enabled = value,
        //    };
        //    return this;
        //}

        public dxBaseConfigurator AllowColumnReordering(bool value)
        {
            dxInstance.Options.allowColumnReordering = value;
            return this;
        }

        public dxBaseConfigurator ColumnAutoWidth(bool value)
        {
            dxInstance.Options.columnAutoWidth = value;
            return this;
        }

        public dxBaseConfigurator FocusedRowEnabled(bool value)
        {
            dxInstance.Options.focusedRowEnabled = value;
            return this;
        }

        public dxBaseConfigurator RowDragging(bool value, Action<object> onOrder)
        {
            dxInstance.Options.rowDragging = new
            {
                allowReordering = value,
                //onReorder = onOrder
            };
            //dxInstance.Options.rowDragging.onReorder(onOrder);
            return this;
        }

        public dxBaseConfigurator Editing(EditingMode mode, bool allowInsert, bool allowUpdate, bool allowDelete, string popupText = "", bool useIcons = false)
        {
            dxInstance.Options.editing = new
            {
                allowUpdating = allowUpdate,
                allowDeleting = allowDelete,
                allowAdding = allowInsert,
                confirmDelete = true,
                startEditAction = "dblClick",
                useIcons = useIcons,
                mode = Enum.GetName(typeof(EditingMode), mode).ToLower(),
                texts = new
                {
                    confirmDeleteMessage = "Silmek istediğinize emin misiniz?",
                    confirmDeleteTitle = "Silme Onayı",
                    saveRowChanges = "Kaydet",
                    cancelRowChanges = "İptal",
                    editRow = "Düzenle",
                    deleteRow = "Sil",
                    addRow = "Ekle"
                },
                popup = string.IsNullOrWhiteSpace(popupText) ? null : Popup(popupText)
            };
            return this;
        }

        public dxBaseConfigurator Selection(string value = "single")
        {
            dxInstance.Options.selection = new
            {
                mode = value,
            };
            return this;
        }

        public dxBaseConfigurator FilterRow(bool visible, string applyFilter = "auto")
        {
            dxInstance.Options.filterRow = new
            {
                visible = visible,
                applyFilter = applyFilter,
            };
            return this;
        }

        public dxBaseConfigurator Export(bool enabled)
        {
            dxInstance.Options.export = new
            {
                enabled = enabled,
                formats = new List<string>() { "pdf", "excel" }
            };
            //            Wisej.Web.Ext.DevExtreme.dxBase.WidgetEventHandler widgetEventHandler1 = new Wisej.Web.Ext.DevExtreme.dxBase.WidgetEventHandler();

            //            widgetEventHandler1.Name = "onExporting";
            //            widgetEventHandler1.Source = @"if(e.format == 'pdf'){

            //      console.log(e);
            //      const doc = new jsPDF();

            //      DevExpress.pdfExporter.exportDataGrid({
            //        jsPDFDocument: doc,
            //        component: e.component,
            //        indent: 5,
            //      }).then(() => {
            //        doc.save('export-pdf.pdf');
            //      });
            //              }
            //else{ 
            //  const workbook = new ExcelJS.Workbook();
            //      const worksheet = workbook.addWorksheet('Employees');

            //      DevExpress.excelExporter.exportDataGrid({
            //        component: e.component,
            //        worksheet,
            //        autoFilterEnabled: true,
            //      }).then(() => {
            //        workbook.xlsx.writeBuffer().then((buffer) => {
            //          saveAs(new Blob([buffer], { type: 'application/octet-stream' }), 'export-excel.xlsx');
            //        });
            //      });
            //     // e.cancel = true;
            //}";
            //            this.dxInstance.WidgetEvents = new Wisej.Web.Ext.DevExtreme.dxBase.WidgetEventHandler[] {
            //        widgetEventHandler1};
            this.dxInstance.WidgetFunctions = new Wisej.Web.Ext.DevExtreme.dxBase.WidgetFunction[0];

            return this;
        }

        public dxBaseConfigurator HeaderFilter(bool visible)
        {
            dxInstance.Options.headerFilter = new
            {
                visible = visible,
            };
            return this;
        }

        //public dxDataGridConfigurator SearchPanel(DxSearchPanel value)
        //{
        //    dxDataGridInstance.Options.searchPanel.visible = value;
        //    return this;
        //}

        public dxBaseConfigurator SearchPanel(bool value)
        {
            dxInstance.Options.searchPanel = new { visible = value };
            return this;
        }

        public dxBaseConfigurator ColumnMinWidth(int value)
        {
            dxInstance.Options.columnMinWidth = value;
            return this;
        }

        public dxDataGridConfiguratorSummary CreateSummary()
        {
            return new dxDataGridConfiguratorSummary();
        }

        public dxBaseConfigurator AutoCreateSummary(bool totalItemsCreate = true, bool groupItemsCreate = true)
        {
            dxDataGridConfiguratorSummary summary = ((dxDataGridConfiguratorSummary)this.dxInstance.Options.summary) ?? new dxDataGridConfiguratorSummary();

            object[] cols = Columns;
            if (cols != null)
            {
                for (int i = 0; i < cols.Length; i++)
                {
                    dynamic col = cols[i].ToDynamic();
                    if (ObjectExtensions.DynamicDoesPropertyExist(col, "format") && Convert.ToString(col.format).StartsWith("#,"))
                    {
                        if (totalItemsCreate)
                        {
                            bool totalItemExists = summary.totalItems.Any(x => x.column == col.dataField);
                            if (!totalItemExists)
                            {
                                summary.totalItems.Add(new DxTotalItem(col.dataField));
                            }
                        }

                        if (groupItemsCreate)
                        {
                            bool groupItemExists = summary.groupItems.Any(x => x.column == col.dataField);
                            if (!groupItemExists)
                            {
                                summary.groupItems.Add(new DxGroupItem(col.dataField));
                            }
                        }
                    }
                }

                this.dxInstance.Options.summary = summary;
            }

            return this;
        }

        public dxBaseConfigurator Summary(dxDataGridConfiguratorSummary summary)
        {
            this.dxInstance.Options.summary = summary;
            #region Example Code
            //dxDataGridConfigurator_Main.dxInstance.Options.summary = new
            //{
            //    groupItems = new object[]
            //   {
            //        new
            //        {
            //            column = "SupplierName",
            //            summaryType = "count",
            //            showInColumn = "SupplierName",
            //            showInGroupFooter = true
            //        },
            //   },
            //    totalItems = new object[]
            //   {
            //        new
            //        {
            //            column = "SupplierName",
            //            summaryType = "count"
            //        },
            //        new
            //        {
            //            column = "Yekun",
            //            summaryType = "sum",
            //            valueFormat = UI.Common.Helpers.Devextreme.DxDataGrid.Column.DxColumnFormat.CurrencyFormat,
            //            displayFormat = "{0} ₺",
            //            showInGroupFooter = true
            //        },
            //   }
            //};
            #endregion
            return this;
        }

    }

    public class dxDataGridConfiguratorSummary
    {
        public List<DxGroupItem> groupItems { get; set; }
        public List<DxTotalItem> totalItems { get; set; }

        public dxDataGridConfiguratorSummary()
        {
            groupItems = new List<DxGroupItem>();
            totalItems = new List<DxTotalItem>();
        }

        public dxDataGridConfiguratorSummary AddAllSummary(string colName)
        {
            groupItems.Add(new DxGroupItem(colName));
            totalItems.Add(new DxTotalItem(colName));
            return this;
        }
        public dxDataGridConfiguratorSummary AddAllSummary(string colName, string summaryType)
        {
            groupItems.Add(new DxGroupItem(colName, summaryType));
            totalItems.Add(new DxTotalItem(colName, summaryType));
            return this;
        }
    }

    public class DxGroupItem
    {
        public bool alignByColumn { get; set; } = false;
        public bool showInGroupFooter { get; set; } = true;
        public string column { get; set; } = null;
        public string showInColumn { get; set; } = null;
        public string summaryType { get; set; } = "sum"; //  'avg' | 'count' | 'custom' | 'max' | 'min' | 'sum'
        public string displayFormat { get; set; } = "{0}";
        public string valueFormat { get; set; } = DxColumnFormat.DoubleFormat;

        public DxGroupItem()
        {

        }

        public DxGroupItem(string col)
        {
            column = col;
            showInColumn = col;
        }

        public DxGroupItem(string col, string summaryType)
        {
            column = col;
            showInColumn = col;
            this.summaryType = summaryType;
            //this.valueFormat = summaryType;
        }

        public DxGroupItem(string column, string displayFormat, string summaryType)
        {
            this.column = column;
            this.showInColumn = column;
            this.displayFormat = displayFormat;
            this.valueFormat = displayFormat;
            this.summaryType = summaryType;
        }
    }

    public class DxTotalItem
    {
        /// <summary>
        /// 'number'	'right'
        //'boolean'	'center'
        //'string'	'left'
        //'date'	'left'
        //'datetime'	'left'
        //'guid'	'left'
        /// </summary>
        //public string alignment { get; set; } = "left"; // 'center' | 'left' | 'right'
        public string column { get; set; } = null;
        //public string cssClass { get; set; } = null;
        public bool showInGroupFooter { get; set; } = true;
        public object displayFormat { get; set; } = "{0}";
        public object valueFormat { get; set; } = DxColumnFormat.DoubleFormat;
        public string summaryType { get; set; } = "sum"; // 'avg' | 'count' | 'custom' | 'max' | 'min' | 'sum'

        public DxTotalItem()
        {

        }

        public DxTotalItem(string column)
        {
            this.column = column;
        }

        public DxTotalItem(string column, string summaryType)
        {
            this.column = column;
            this.summaryType = summaryType;
            if (summaryType == "count")
            {
                valueFormat = "#,##0.##";
            }
        }

        public DxTotalItem(string column, string valueFormat, string summaryType)
        {
            this.column = column;
            this.summaryType = summaryType;
            this.valueFormat = valueFormat;
            if (summaryType == "count")
            {
                this.valueFormat = "#,##0.##";
            }
        }

    }

    public enum ScrollingMode
    {
        Infinite,
        Standard,
        Virtual
    }

    public enum EditingMode
    {
        Batch,
        Cell,
        Row,
        Form,
        Popup
    }
    //public class DxColumn
    //{
    //    public bool visible { get; set; }
    //    public string caption { get; set; }
    //    public string dataField { get; set; }
    //    public object width { get; set; } = "auto";

    //    //https://js.devexpress.com/Documentation/ApiReference/UI_Components/dxDataGrid/Configuration/columns/#dataType
    //    //'string' | 'number' | 'date' | 'boolean' | 'object' | 'datetime'
    //    public object dataType { get; set; } = "string";

    //    public DxColumn()
    //    {

    //    }

    //    public DxColumn(string _caption, string _dataField)
    //    {
    //        caption = _caption;
    //        dataField = _dataField;
    //    }
    //}

    public class DxGroupPanel
    {
        public bool Visible { get; set; } = true;

        public DxGroupPanel()
        {

        }

        public DxGroupPanel(bool isVisible)
        {
            Visible = isVisible;
        }
    }

    public class DxSearchPanel
    {
        public bool Visible { get; set; } = true;
        //public string text { get; set; }

        public DxSearchPanel()
        {

        }

        public DxSearchPanel(bool isVisible)
        {
            Visible = isVisible;
        }
    }
}
