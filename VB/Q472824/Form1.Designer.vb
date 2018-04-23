' Developer Express Code Central Example:
' How to show field names instead of column captions in the unbound expression editor
' 
' This example demonstrates how to show field names instead of column captions in
' the unbound expression editor by creating a GridControl's descendant. The main
' idea is to create a GridView's descendant. After that, override its
' CreateColumnCollection method and then return your custom GridColumnCollection
' which will contain custom GridColumns. Then override the GridColumn's
' IDataColumnInfoProvider.GetInfo method and return your custom
' MyGridColumnIDataColumnInfoWrapper class where you can override the
' IDataColumnInfo.Caption property and return a corresponding column's FieldName
' property.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=T192021

Imports CustomGrid.CustomGrid
Namespace Q472824
    Partial Public Class Form1
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.gridControl1 = New CustomGrid.CustomGrid.MyGridControl()
            Me.gridView1 = New CustomGrid.CustomGrid.MyGridView()
            Me.myGridColumn1 = New CustomGrid.CustomGrid.MyGridColumn()
            Me.myGridColumn2 = New CustomGrid.CustomGrid.MyGridColumn()
            Me.myGridColumn3 = New CustomGrid.CustomGrid.MyGridColumn()
            Me.myGridColumn4 = New CustomGrid.CustomGrid.MyGridColumn()
            DirectCast(Me.gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' gridControl1
            ' 
            Me.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.gridControl1.Location = New System.Drawing.Point(0, 0)
            Me.gridControl1.MainView = Me.gridView1
            Me.gridControl1.Name = "gridControl1"
            Me.gridControl1.Size = New System.Drawing.Size(284, 262)
            Me.gridControl1.TabIndex = 0
            Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView1})
            ' 
            ' gridView1
            ' 
            Me.gridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() { Me.myGridColumn1, Me.myGridColumn2, Me.myGridColumn3, Me.myGridColumn4})
            Me.gridView1.GridControl = Me.gridControl1
            Me.gridView1.Name = "gridView1"
            ' 
            ' myGridColumn1
            ' 
            Me.myGridColumn1.Caption = "Col1"
            Me.myGridColumn1.FieldName = "1"
            Me.myGridColumn1.Name = "myGridColumn1"
            Me.myGridColumn1.Visible = True
            Me.myGridColumn1.VisibleIndex = 0
            ' 
            ' myGridColumn2
            ' 
            Me.myGridColumn2.Caption = "Col2"
            Me.myGridColumn2.FieldName = "2"
            Me.myGridColumn2.Name = "myGridColumn2"
            Me.myGridColumn2.Visible = True
            Me.myGridColumn2.VisibleIndex = 1
            ' 
            ' myGridColumn3
            ' 
            Me.myGridColumn3.Caption = "Col3"
            Me.myGridColumn3.FieldName = "3"
            Me.myGridColumn3.Name = "myGridColumn3"
            Me.myGridColumn3.Visible = True
            Me.myGridColumn3.VisibleIndex = 2
            ' 
            ' myGridColumn4
            ' 
            Me.myGridColumn4.Caption = "myGridColumn4"
            Me.myGridColumn4.FieldName = "myGridColumn4"
            Me.myGridColumn4.Name = "myGridColumn4"
            Me.myGridColumn4.ShowUnboundExpressionMenu = True
            Me.myGridColumn4.UnboundExpression = "[1] + [2] + [3]"
            Me.myGridColumn4.UnboundType = DevExpress.Data.UnboundColumnType.Object
            Me.myGridColumn4.Visible = True
            Me.myGridColumn4.VisibleIndex = 3
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(284, 262)
            Me.Controls.Add(Me.gridControl1)
            Me.Name = "Form1"
            Me.Text = "Form1"
            DirectCast(Me.gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        #End Region

        Private gridControl1 As MyGridControl
        Private gridView1 As MyGridView
        Private myGridColumn1 As MyGridColumn
        Private myGridColumn2 As MyGridColumn
        Private myGridColumn3 As MyGridColumn
        Private myGridColumn4 As MyGridColumn
    End Class
End Namespace

