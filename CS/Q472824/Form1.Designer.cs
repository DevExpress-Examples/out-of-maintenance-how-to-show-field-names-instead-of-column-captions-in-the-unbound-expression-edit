using CustomGrid.CustomGrid;
namespace Q472824 {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.gridControl1 = new CustomGrid.CustomGrid.MyGridControl();
            this.gridView1 = new CustomGrid.CustomGrid.MyGridView();
            this.myGridColumn1 = new CustomGrid.CustomGrid.MyGridColumn();
            this.myGridColumn2 = new CustomGrid.CustomGrid.MyGridColumn();
            this.myGridColumn3 = new CustomGrid.CustomGrid.MyGridColumn();
            this.myGridColumn4 = new CustomGrid.CustomGrid.MyGridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(284, 262);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.myGridColumn1,
            this.myGridColumn2,
            this.myGridColumn3,
            this.myGridColumn4});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // myGridColumn1
            // 
            this.myGridColumn1.Caption = "Col1";
            this.myGridColumn1.FieldName = "1";
            this.myGridColumn1.Name = "myGridColumn1";
            this.myGridColumn1.Visible = true;
            this.myGridColumn1.VisibleIndex = 0;
            // 
            // myGridColumn2
            // 
            this.myGridColumn2.Caption = "Col2";
            this.myGridColumn2.FieldName = "2";
            this.myGridColumn2.Name = "myGridColumn2";
            this.myGridColumn2.Visible = true;
            this.myGridColumn2.VisibleIndex = 1;
            // 
            // myGridColumn3
            // 
            this.myGridColumn3.Caption = "Col3";
            this.myGridColumn3.FieldName = "3";
            this.myGridColumn3.Name = "myGridColumn3";
            this.myGridColumn3.Visible = true;
            this.myGridColumn3.VisibleIndex = 2;
            // 
            // myGridColumn4
            // 
            this.myGridColumn4.Caption = "myGridColumn4";
            this.myGridColumn4.FieldName = "myGridColumn4";
            this.myGridColumn4.Name = "myGridColumn4";
            this.myGridColumn4.ShowUnboundExpressionMenu = true;
            this.myGridColumn4.UnboundExpression = "[1] + [2] + [3]";
            this.myGridColumn4.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.myGridColumn4.Visible = true;
            this.myGridColumn4.VisibleIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.gridControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MyGridControl gridControl1;
        private MyGridView gridView1;
        private MyGridColumn myGridColumn1;
        private MyGridColumn myGridColumn2;
        private MyGridColumn myGridColumn3;
        private MyGridColumn myGridColumn4;
    }
}

