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

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Registrator

Namespace CustomGrid.CustomGrid
    Public Class MyGridControl
        Inherits GridControl

        Private gridView1 As DevExpress.XtraGrid.Views.Grid.GridView

        Protected Overrides Function CreateDefaultView() As BaseView
            Return CreateView("MyGridView")
        End Function

        Protected Overrides Sub RegisterAvailableViewsCore(ByVal collection As InfoCollection)
            MyBase.RegisterAvailableViewsCore(collection)
            collection.Add(New MyGridViewInfoRegistrator())
        End Sub

        Private Sub InitializeComponent()
            Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
            DirectCast(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' gridView1
            ' 
            Me.gridView1.GridControl = Me
            Me.gridView1.Name = "gridView1"
            ' 
            ' MyGridControl
            ' 
            Me.MainView = Me.gridView1
            Me.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView1})
            DirectCast(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
    End Class
End Namespace
