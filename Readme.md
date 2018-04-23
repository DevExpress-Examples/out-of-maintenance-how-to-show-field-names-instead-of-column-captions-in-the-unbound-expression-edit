# How to show field names instead of column captions in the unbound expression editor


<p>This example demonstrates how to show field names instead of column captions in the unbound expression editor by creating a GridControl's descendant. The main idea is to create a GridView's descendant. After that, override its CreateColumnCollection method and then return your custom GridColumnCollection which will contain custom GridColumns. Then override the GridColumn's IDataColumnInfoProvider.GetInfo method and return your custom MyGridColumnIDataColumnInfoWrapper class where you can override the IDataColumnInfo.Caption property and return a corresponding column's FieldName property.</p>

<br/>


