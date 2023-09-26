using AIOERP.UI.Common.Helpers.Devextreme.DxDataGrid.Column;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Wisej.Ext.DevExtreme.Plus.Extensions;
using Wisej.Web;

namespace Wisej.Ext.DevExtreme.Plus
{
    public partial class dxBaseConfigurator
    {
        //public Wisej.Web.Ext.DevExtreme.dxDataGrid dxInstance { get; set; }
        public Wisej.Web.Ext.DevExtreme.dxBase dxInstance { get; set; }
        public dynamic dynamicOptions { get; set; }

        public event WidgetEventHandler focusedRowChanged;
        public event WidgetEventHandler dataSourceChanged;
        public event WidgetEventHandler rowInserted;
        public event WidgetEventHandler rowRemoved;
        public event WidgetEventHandler rowUpdated;
        public event WidgetEventHandler cellClick;
        public event WidgetEventHandler cellDblClick;
        public event WidgetEventHandler focusedCellChanged;
        public event WidgetEventHandler initialized;
        public event WidgetEventHandler rowDblClick;
        public event WidgetEventHandler onOptionChanged;
        public event WidgetEventHandler onCellPrepared;
        public event WidgetEventHandler onEditorPreparing;
        //public event WidgetEventHandler OnRowPrepared;

        //custom names
        public event WidgetEventHandler pageSizeChanged;
        public event WidgetEventHandler pageIndexChanged;
        public event WidgetEventHandler pageSettingsChanged;

        //public dxDataGridConfigurator()
        //{
        //    dynamicOptions = new ExpandoObject();
        //}

        public void SetDefaultColumns(bool visibleId = false, bool visibleCreatedById = false, bool allowFilteringCreatedById = true, bool visibleCreatedDate = false, bool visibleDescription = false, bool visibleLastModifiedById = false, bool visilbeLastModifiedDate = false)
        {

            object[] columns = dxInstance.Options.columns == null ? new object[0] : dxInstance.Options.columns;
            Array.Resize(ref columns, columns.Length + 1);
            columns[columns.Length - 1] = new
            {
                caption = "Kayıt No",
                dataField = "Id",
                width = 120,
                visible = visibleId,
                allowEditing = false,
                visibleIndex = 0,
                formItem = new DxColumnForm() { visible = false },
            };


            dxInstance.Options.columns = columns;
        }
        public object DataSource
        {
            get
            {
                return dxInstance.Options.dataSource;
            }
            set
            {
                this.SetDataSource(value);
                //FocusedRowIndex = 0;
            }
        }

        public object[] Columns
        {
            get
            {
                return dxInstance.Options.columns;
            }
            set
            {
                this.SetColumns(value);
            }
        }

        // yapılacak
        //public Wisej.Web.Ext.DevExtreme.dxDataGrid AddColumn()
        public Wisej.Web.Ext.DevExtreme.dxBase AddColumn()
        {
            return this.dxInstance;
        }

        // yapılacak
        //public Wisej.Web.Ext.DevExtreme.dxDataGrid AddColumns()
        public Wisej.Web.Ext.DevExtreme.dxBase AddColumns()
        {
            return this.dxInstance;
        }

        // yapılacak
        /// <summary>
        /// örnek olarak createdby ıd kolonu özelliğini gmrünüür yapmasını eşitleyecek
        /// </summary>
        /// <param name="colField">CreatedById</param>
        /// <param name="colProperty">Visible</param>
        /// <param name="value">false</param>
        /// <returns></returns>
        //public Wisej.Web.Ext.DevExtreme.dxDataGrid SetColumnProperty(string colField, string colProperty, object value)
        public Wisej.Web.Ext.DevExtreme.dxBase SetColumnProperty(string colField, string colProperty, object value)
        {
            return this.dxInstance;
        }

        public object SelectedRowId
        {
            get
            {
                return dxInstance.UserData.Id;
            }
        }

        public long? GetSelectedRowId()
        {
            try
            {
                return Convert.ToInt64(dxInstance.UserData.Id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public object FocusedRowIndex
        {
            get
            {
                return dxInstance.Options.focusedRowIndex;
            }
            set
            {
                dxInstance.Options.focusedRowIndex = value;
            }
        }

        public dxBaseConfigurator(Wisej.Web.Ext.DevExtreme.dxBase _dxDataGridInstance, bool setDefault = true)
        {
            dynamicOptions = new ExpandoObject();
            dxInstance = _dxDataGridInstance;
            dxInstance.BorderStyle = BorderStyle.Solid;
            dxInstance.WidgetEvent += DxDataGridInstance_WidgetEvent;
            dxInstance.Padding = new Padding(3);
            InitContextMenu();

            //PDF aktarmak için
            //Application.LoadPackages(new[] {
            //    new Widget.Package(){
            //        Name = "jspdf",
            //        Source = "https://cdnjs.cloudflare.com/ajax/libs/jspdf/2.3.1/jspdf.umd.min.js"
            //    },
            //    new Widget.Package(){
            //        Name = "jspdf.autotable",
            //        Source = "https://cdnjs.cloudflare.com/ajax/libs/jspdf-autotable/3.5.14/jspdf.plugin.autotable.min.js"
            //    }
            //});

            if (setDefault)
            {
                SetDefault();
                //default kolonlar gelcek
            }
        }

        //public dxDataGridConfigurator()
        //{
        //    dxInstance = new dxDataGrid();
        //}

        //public dynamic CompileForTreeList()
        //{
        //    return dxInstance.Options;
        //} 

        private void DxDataGridInstance_WidgetEvent(object sender, Wisej.Web.WidgetEventArgs e)
        {
            if (e.Type == "focusedRowChanged")
            {
                dxInstance.UserData.Id = e.Data?.row?.key;
                dxInstance.UserData.RowClickLastData = e.Data;
                if (focusedRowChanged != null)
                    focusedRowChanged(sender, e);
            }
            else if (e.Type == "rowInserted")
            {
                if (rowInserted != null)
                    rowInserted(sender, e);
            }
            else if (e.Type == "rowUpdated")
            {
                if (rowUpdated != null)
                    rowUpdated(sender, e);
            }
            else if (e.Type == "rowRemoved")
            {
                if (rowRemoved != null)
                    rowRemoved(sender, e);
            }
            else if (e.Type == "cellClick")
            {
                dxInstance.UserData.CellClickLastData = e.Data;
                if (cellClick != null)
                    cellClick(sender, e);
            }
            else if (e.Type == "cellDblClick")
            {
                if (cellDblClick != null)
                    cellDblClick(sender, e);
            }
            else if (e.Type == "focusedCellChanged")
            {
                dxInstance.UserData.CellClickLastData = e.Data;
                if (focusedCellChanged != null)
                    focusedCellChanged(sender, e);
            }
            else if (e.Type == "initialized")
            {
                if (initialized != null)
                    initialized(sender, e);
            }
            else if (e.Type == "rowDblClick")
            {
                if (rowDblClick != null)
                    rowDblClick(sender, e);
            }
            else if (e.Type == "cellPrepared")
            {
                if (onCellPrepared != null)
                    onCellPrepared(sender, e);
            }
            else if (e.Type == "editorPreparing")
            {
                if (onEditorPreparing != null)
                    onEditorPreparing(sender, e);
            }
            //else if (e.Type == "rowPrepared")
            //{
            //    if (OnRowPrepared != null)
            //        OnRowPrepared(sender, e);
            //}
            else if (e.Type == "optionChanged")
            {
                //paging https://js.devexpress.com/Documentation/ApiReference/UI_Components/dxDataGrid/Configuration/#onOptionChanged
                if (onOptionChanged != null)
                    onOptionChanged(sender, e);

                if (e.Data.fullName?.ToString() == "paging.pageSize")
                {
                    WidgetEventArgs args = new WidgetEventArgs("pageSizeChanged", e.Data.value);
                    if (pageSizeChanged != null)
                        pageSizeChanged(sender, args);

                    if (pageSettingsChanged != null)
                        pageSettingsChanged(sender, args);
                }
                else if (e.Data.fullName?.ToString() == "paging.pageIndex")
                {
                    WidgetEventArgs args = new WidgetEventArgs("pageIndexChanged", e.Data.value);
                    if (pageIndexChanged != null)
                        pageIndexChanged(sender, args);

                    if (pageSettingsChanged != null)
                        pageSettingsChanged(sender, args);
                }
                //else if (!new List<string>() { "hoveredElement" , "focusedRowIndex", "focusedRowKey", "focusedCellIndex", "focusedColumnIndex" }.Contains( e.Data.fullName?.ToString()) )
                //{

                //}
            }
        }

        public void InitContextMenu()
        {
            if (dxInstance.ContextMenu != null)
            {
                for (int i = 0; i < dxInstance.ContextMenu.MenuItems.Count; i++)
                {
                    MenuItem menu = dxInstance.ContextMenu.MenuItems[i];
                    if (menu.Text == "Yenile")
                    {
                        menu.IconSource = Wisej.Ext.FontAwesome.Icons.Refresh;
                    }
                    else if (menu.Text.Contains("Ekle"))
                    {
                        menu.IconSource = Wisej.Ext.FontAwesome.Icons.Plus;
                    }
                    else if (menu.Text == "Güncelle")
                    {
                        menu.IconSource = Wisej.Ext.FontAwesome.Icons.Pencil;
                    }
                    else if (menu.Text == "Düzenle")
                    {
                        menu.IconSource = Wisej.Ext.FontAwesome.Icons.Pencil;
                    }
                    else if (menu.Text == "Sil")
                    {
                        menu.IconSource = Wisej.Ext.FontAwesome.Icons.Trash;
                    }
                    else if (menu.Text.StartsWith("Onay"))
                    {
                        menu.IconSource = Wisej.Ext.FontAwesome.Icons.Check;
                    }
                    else if (menu.Text.StartsWith("Red"))
                    {
                        menu.IconSource = Wisej.Ext.FontAwesome.Icons.Times;
                    }
                    else if (menu.Text.EndsWith("Aktar"))
                    {
                        menu.IconSource = Wisej.Ext.FontAwesome.Icons.FileO;
                    }
                }

                List<MenuItem> contextMenu = dxInstance.ContextMenu.MenuItems.Cast<MenuItem>().ToList();
                if (!contextMenu.Any(x => x.Text == "Excele Aktar"))
                {
                    MenuItem menuItemExcel = new MenuItem();
                    menuItemExcel.Text = "Excele Aktar";
                    menuItemExcel.Name = "menuItemExcel";
                    menuItemExcel.Click += MenuItemExcel_Click; ;
                    menuItemExcel.IconSource = Wisej.Ext.FontAwesome.Icons.FilesO;

                    dxInstance.ContextMenu.MenuItems.Add(menuItemExcel);
                }

                if (!contextMenu.Any(x => x.Text == "Satırı Kopyala"))
                {
                    MenuItem menuItemCopyRow = new MenuItem();
                    menuItemCopyRow.Text = "Satırı Kopyala";
                    menuItemCopyRow.Name = "menuItemCopyCell";
                    menuItemCopyRow.Click += MenuItemCopyRow_Click;
                    menuItemCopyRow.IconSource = Wisej.Ext.FontAwesome.Icons.Clipboard;

                    dxInstance.ContextMenu.MenuItems.Add(menuItemCopyRow);
                }

                if (!contextMenu.Any(x => x.Text == "Hücreyi Kopyala"))
                {
                    MenuItem menuItemCopyCell = new MenuItem();
                    menuItemCopyCell.Text = "Hücreyi Kopyala";
                    menuItemCopyCell.Name = "menuItemCopyCell";
                    menuItemCopyCell.Click += MenuItemCopyCell_Click;
                    menuItemCopyCell.IconSource = Wisej.Ext.FontAwesome.Icons.Clipboard;

                    dxInstance.ContextMenu.MenuItems.Add(menuItemCopyCell);
                }

                if (!contextMenu.Any(x => x.Text == "Excele Aktar"))
                {
                    MenuItem menuItemColumnChooser = new MenuItem();
                    menuItemColumnChooser.Text = "Sütün Seçici";
                    menuItemColumnChooser.Name = "menuItemColumnChooser";
                    menuItemColumnChooser.Click += MenuItemColumnChooser_Click;
                    menuItemColumnChooser.IconSource = Wisej.Ext.FontAwesome.Icons.Columns;

                    dxInstance.ContextMenu.MenuItems.Add(menuItemColumnChooser);
                }

                if (!contextMenu.Any(x => x.Text == "PDF'e Aktar"))
                {
                    MenuItem menuItemPDF = new MenuItem();
                    menuItemPDF.Text = "PDF'e Aktar";
                    menuItemPDF.Name = "menuItemExcel";
                    menuItemPDF.Click += MenuItemPDF_Click;
                    menuItemPDF.IconSource = Wisej.Ext.FontAwesome.Icons.FilesO;

                    dxInstance.ContextMenu.MenuItems.Add(menuItemPDF);
                }

                //MenuItem menuItemHucreKopyala = new MenuItem();
                //menuItemHucreKopyala.Text = "Hücreyi Kopyala";
                //menuItemHucreKopyala.Name = "menuItemHucreKopyala";
                //menuItemHucreKopyala.Click += MenuItemHucreKopyala_Click;
                //menuItemHucreKopyala.IconSource = Wisej.Ext.FontAwesome.Icons.FilesO;

                //ContextMenu.MenuItems.Add(menuItemHucreKopyala);

                dxInstance.ContextMenu.MenuItemClicked += ContextMenu_MenuItemClicked;
            }
        }

        private async void MenuItemCopyRow_Click(object sender, EventArgs e)
        {
            try
            {
                object[] dataArr = dxInstance.UserData.RowClickLastData?.row?.values;
                if (dataArr != null)
                {
                    string text = string.Join("\t", dataArr);
                    if (!text.IsNullOrEmpty())
                        await Wisej.Ext.ClientClipboard.ClientClipboard.WriteTextAsync(text);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private async void MenuItemCopyCell_Click(object sender, EventArgs e)
        {
            try
            {
                string text = dxInstance.UserData.CellClickLastData?.displayValue;
                if (!text.IsNullOrEmpty())
                    await Wisej.Ext.ClientClipboard.ClientClipboard.WriteTextAsync(text);
            }
            catch (Exception ex)
            {

            }
        }

        private void MenuItemColumnChooser_Click(object sender, EventArgs e)
        {
            dxInstance.Instance.showColumnChooser();
        }

        private void MenuItemPDF_Click(object sender, System.EventArgs e)
        {
            //dxInstance.Eval(@"
            //var doc = new window.jsPDF();
            //DevExpress.pdfExporter.exportDataGrid({
            //	jsPDFDocument: doc,
            //	component: dxDataGridinstance
            //    }).then(function() {
            //    doc.save('export.pdf');
            //});"
            //);//component: $('input[name=""" + dxInstance.Name + @"""]').dxDataGrid('instance')

            this.dxInstance.Eval(@"
            applyPlugin(window.jsPDF);
            var dxDataGridinstance = $('div[name=""" + dxInstance.Name + @"""]').find('.dx-gridbase-container').parent().dxDataGrid('instance');
            //console.info(dxDataGridinstance);

            const doc = new jsPDF();
            window.DevExpress.pdfExporter.exportDataGrid({
            jsPDFDocument: doc,
component: dxDataGridinstance
            }).then(function() {
                doc.save('export-pdf.pdf');

            })");
        }

        private void MenuItemExcel_Click(object sender, System.EventArgs e)
        {
            dxInstance.Instance.exportToExcel(false);
        }

        private void ContextMenu_MenuItemClicked(object sender, MenuItemEventArgs e)
        {
            if (e.MenuItem.Text == "Excele Aktar")
            {
                dxInstance.Instance.exportToExcel(false);
            }
        }

        public void SetDefault()
        {
            this.ColumnFixing(true);
            this.ShowBorders(true);
            this.ColumnResizingMode();
            this.ShowRowLines(true);
            this.HoverStateEnabled(true);
            this.FocusedRowEnabled(true);
            this.AllowColumnResizing(true);
            this.FilterPanel(true);
            this.AllowColumnReordering(true);
            this.ColumnAutoWidth(false);
            this.ColumnChooser(true);
            this.FilterRow(true);
            this.HeaderFilter(true);
            //this.ColumnMinWidth(125);
            //this.Export(true);
            this.Selection();
            this.Scrolling(ScrollingMode.Virtual);
            this.Paging(true);
            this.SetEvents();
            this.KeyExpr();
            //this.LoadPanel();


            //string lcEval = "DevExpress.localization.loadMessages('https://cdn3.devexpress.com/jslib/22.2.6/js/localization/dx.messages.tr.js')";
            //dxInstance.Eval(lcEval);
            //dxInstance.Eval("DevExpress.localization.locale('tr-TR')");


            dxInstance.Update();
        }

        public void GetSelectedRowsData(Action<object> action)
        {
            this.dxInstance.Instance.getSelectedRowsData(action);
        }

        public void SetEvents()
        {
            dxInstance.WiredEvents = new string[] {
                "initialized",
                "focusedRowChanged",
                "rowInserted",
                "rowRemoved",
                "rowUpdated",
                "cellClick",
                "cellDblClick",
                "focusedCellChanged",
                "rowDblClick",
                "optionChanged",
                "cellPrepared",
                "rowPrepared",
                "editorPreparing",
            };
        }

    }

    public static class dxDataGridConfiguratorExtensions
    {
        public static dxBaseConfigurator Create(this Wisej.Web.Ext.DevExtreme.dxBase _dxDataGridInstance, bool setDefault = true)
        {
            return new dxBaseConfigurator(_dxDataGridInstance, setDefault);
        }
    }
}
