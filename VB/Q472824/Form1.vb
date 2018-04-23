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
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Namespace Q472824
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub
    End Class
End Namespace
