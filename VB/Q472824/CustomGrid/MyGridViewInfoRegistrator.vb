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
Imports DevExpress.XtraGrid.Views.Base.ViewInfo
Imports DevExpress.XtraGrid.Views.Base.Handler

Namespace CustomGrid.CustomGrid
    Public Class MyGridViewInfoRegistrator
        Inherits GridInfoRegistrator

        Public Overrides ReadOnly Property ViewName() As String
            Get
                Return "MyGridView"
            End Get
        End Property

        Public Overrides Function CreateView(ByVal grid As GridControl) As BaseView
            Return New MyGridView(TryCast(grid, GridControl))
        End Function
    End Class
End Namespace
