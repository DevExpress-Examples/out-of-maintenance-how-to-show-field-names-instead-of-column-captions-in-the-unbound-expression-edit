using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Design;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Internal;
using DevExpress.XtraGrid.Columns;
using DevExpress.Data;

namespace CustomGrid.CustomGrid {
    public class MyGridView : GridView {
        public MyGridView()
            : this(null) {
        }

        public MyGridView(GridControl grid)
            : base(grid) {
            // put your initialization code here
        }

        protected override string ViewName {
            get {
                return "MyGridView";
            }
        }

        protected override GridColumnCollection CreateColumnCollection() {
            return new MyGridColumnCollection(this);
        }

        public override void ShowUnboundExpressionEditor(GridColumn column) {
            using (ExpressionEditorForm form = new UnboundColumnExpressionEditorForm(new MyGridColumnIDataColumnInfoWrapper(column, GridColumnIDataColumnInfoWrapperEnum.ExpressionEditor), null)) {
                if (this.GridControl != null) {
                    form.SetMenuManager(this.GridControl.MenuManager);
                }
                form.StartPosition = FormStartPosition.CenterParent;
                UnboundExpressionEditorEventArgs ea = new UnboundExpressionEditorEventArgs(form, column);
                OnUnboundExpressionEditorCreated(ea);
                if (!ea.ShowExpressionEditor) {
                    return;
                }
                if (GetFormResult(form) == DialogResult.OK) {
                    column.UnboundExpression = form.Expression;
                }
            }
        }

        private DialogResult GetFormResult(Form frm) {
            if (this.GridControl != null && this.GridControl.FindForm() != null) {
                return frm.ShowDialog(this.GridControl.FindForm());
            }
            return frm.ShowDialog();
        }
    }

    public class MyGridColumnCollection : GridColumnCollection {
        public MyGridColumnCollection(ColumnView view)
            : base(view) {
        }

        protected override GridColumn CreateColumn() {
            return new MyGridColumn();
        }
    }

    public class MyGridColumn : GridColumn, IDataColumnInfoProvider {
        IDataColumnInfo IDataColumnInfoProvider.GetInfo(object arguments) {
            GridColumnIDataColumnInfoWrapperEnum fieldType = GridColumnIDataColumnInfoWrapperEnum.ExpressionEditor;
            if (arguments != null && Enum.IsDefined(typeof(GridColumnIDataColumnInfoWrapperEnum), arguments)) {
                fieldType = (GridColumnIDataColumnInfoWrapperEnum)arguments;
            }
            return new MyGridColumnIDataColumnInfoWrapper(this, fieldType);
        }
    }

    public class MyGridColumnIDataColumnInfoWrapper : GridColumnIDataColumnInfoWrapper, IDataColumnInfo {
        private GridColumn column;

        private GridColumnIDataColumnInfoWrapperEnum fieldType;

        public MyGridColumnIDataColumnInfoWrapper(GridColumn column, GridColumnIDataColumnInfoWrapperEnum fieldType)
            : base(column, fieldType) {
            this.column = column;
            this.fieldType = fieldType;
        }

        string IDataColumnInfo.Caption {
            get {
                return ((IDataColumnInfo)this).FieldName;
            }
        }

        List<IDataColumnInfo> IDataColumnInfo.Columns {
            get {
                List<IDataColumnInfo> res = new List<IDataColumnInfo>();
                if (View == null) {
                    return res;
                }
                foreach (GridColumn col in View.Columns) {
                    if (col == this.column) {
                        continue;
                    }
                    if (!col.OptionsColumn.ShowInExpressionEditor && fieldType == GridColumnIDataColumnInfoWrapperEnum.ExpressionEditor) {
                        continue;
                    }
                    res.Add(new MyGridColumnIDataColumnInfoWrapper(col, this.fieldType));
                }
                return res;
            }
        }

        private ColumnView View {
            get {
                return column.View;
            }
        }
    }
}
