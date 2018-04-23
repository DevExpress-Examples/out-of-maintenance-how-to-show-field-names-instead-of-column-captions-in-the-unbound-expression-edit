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
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors.Design
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Internal
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.Data

Namespace CustomGrid.CustomGrid
    Public Class MyGridView
        Inherits GridView

        Public Sub New()
            Me.New(Nothing)
        End Sub

        Public Sub New(ByVal grid As GridControl)
            MyBase.New(grid)
            ' put your initialization code here
        End Sub

        Protected Overrides ReadOnly Property ViewName() As String
            Get
                Return "MyGridView"
            End Get
        End Property

        Protected Overrides Function CreateColumnCollection() As GridColumnCollection
            Return New MyGridColumnCollection(Me)
        End Function

        Public Overrides Sub ShowUnboundExpressionEditor(ByVal column As GridColumn)
            Using form As ExpressionEditorForm = New UnboundColumnExpressionEditorForm(New MyGridColumnIDataColumnInfoWrapper(column, GridColumnIDataColumnInfoWrapperEnum.ExpressionEditor), Nothing)
                If Me.GridControl IsNot Nothing Then
                    form.SetMenuManager(Me.GridControl.MenuManager)
                End If
                form.StartPosition = FormStartPosition.CenterParent
                Dim ea As New UnboundExpressionEditorEventArgs(form, column)
                OnUnboundExpressionEditorCreated(ea)
                If Not ea.ShowExpressionEditor Then
                    Return
                End If
                If GetFormResult(form) = DialogResult.OK Then
                    column.UnboundExpression = form.Expression
                End If
            End Using
        End Sub

        Private Function GetFormResult(ByVal frm As Form) As DialogResult
            If Me.GridControl IsNot Nothing AndAlso Me.GridControl.FindForm() IsNot Nothing Then
                Return frm.ShowDialog(Me.GridControl.FindForm())
            End If
            Return frm.ShowDialog()
        End Function
    End Class

    Public Class MyGridColumnCollection
        Inherits GridColumnCollection

        Public Sub New(ByVal view As ColumnView)
            MyBase.New(view)
        End Sub

        Protected Overrides Function CreateColumn() As GridColumn
            Return New MyGridColumn()
        End Function
    End Class

    Public Class MyGridColumn
        Inherits GridColumn
        Implements IDataColumnInfoProvider

        Private Function IDataColumnInfoProvider_GetInfo(ByVal arguments As Object) As IDataColumnInfo Implements IDataColumnInfoProvider.GetInfo
            Dim fieldType As GridColumnIDataColumnInfoWrapperEnum = GridColumnIDataColumnInfoWrapperEnum.ExpressionEditor
            If arguments IsNot Nothing AndAlso System.Enum.IsDefined(GetType(GridColumnIDataColumnInfoWrapperEnum), arguments) Then
                fieldType = DirectCast(arguments, GridColumnIDataColumnInfoWrapperEnum)
            End If
            Return New MyGridColumnIDataColumnInfoWrapper(Me, fieldType)
        End Function
    End Class

    Public Class MyGridColumnIDataColumnInfoWrapper
        Inherits GridColumnIDataColumnInfoWrapper
        Implements IDataColumnInfo

        Private column As GridColumn

        Private fieldType As GridColumnIDataColumnInfoWrapperEnum

        Public Sub New(ByVal column As GridColumn, ByVal fieldType As GridColumnIDataColumnInfoWrapperEnum)
            MyBase.New(column, fieldType)
            Me.column = column
            Me.fieldType = fieldType
        End Sub

        Private ReadOnly Property IDataColumnInfo_Caption() As String Implements IDataColumnInfo.Caption
            Get
                Return DirectCast(Me, IDataColumnInfo).FieldName
            End Get
        End Property

        Private ReadOnly Property IDataColumnInfo_Columns() As List(Of IDataColumnInfo) Implements IDataColumnInfo.Columns
            Get
                Dim res As New List(Of IDataColumnInfo)()
                If View Is Nothing Then
                    Return res
                End If
                For Each col As GridColumn In View.Columns
                    If col Is Me.column Then
                        Continue For
                    End If
                    If (Not col.OptionsColumn.ShowInExpressionEditor) AndAlso fieldType = GridColumnIDataColumnInfoWrapperEnum.ExpressionEditor Then
                        Continue For
                    End If
                    res.Add(New MyGridColumnIDataColumnInfoWrapper(col, Me.fieldType))
                Next col
                Return res
            End Get
        End Property

        Private ReadOnly Property View() As ColumnView
            Get
                Return column.View
            End Get
        End Property
    End Class
End Namespace
