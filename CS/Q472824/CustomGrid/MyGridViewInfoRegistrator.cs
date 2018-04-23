using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base.ViewInfo;
using DevExpress.XtraGrid.Views.Base.Handler;

namespace CustomGrid.CustomGrid {
    public class MyGridViewInfoRegistrator : GridInfoRegistrator {
        public override string ViewName {
            get { return "MyGridView"; }
        }

        public override BaseView CreateView(GridControl grid) {
            return new MyGridView(grid as GridControl);
        }
    }
}
