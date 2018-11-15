<!-- default file list -->
*Files to look at*:

* [MyGridControl.cs](./CS/Q472824/CustomGrid/MyGridControl.cs) (VB: [MyGridControl.vb](./VB/Q472824/CustomGrid/MyGridControl.vb))
* [MyGridView.cs](./CS/Q472824/CustomGrid/MyGridView.cs) (VB: [MyGridViewInfoRegistrator.vb](./VB/Q472824/CustomGrid/MyGridViewInfoRegistrator.vb))
* [MyGridViewInfoRegistrator.cs](./CS/Q472824/CustomGrid/MyGridViewInfoRegistrator.cs) (VB: [MyGridViewInfoRegistrator.vb](./VB/Q472824/CustomGrid/MyGridViewInfoRegistrator.vb))
* **[Form1.cs](./CS/Q472824/Form1.cs) (VB: [Form1.vb](./VB/Q472824/Form1.vb))**
* [Program.cs](./CS/Q472824/Program.cs) (VB: [Program.vb](./VB/Q472824/Program.vb))
<!-- default file list end -->
# How to show field names instead of column captions in the unbound expression editor


<p>This example demonstrates how to show field names instead of column captions in the unbound expression editor by creating a GridControl's descendant. The main idea is to create a GridView's descendant. After that, override its CreateColumnCollection method and then return your custom GridColumnCollection which will contain custom GridColumns. Then override the GridColumn's IDataColumnInfoProvider.GetInfo method and return your custom MyGridColumnIDataColumnInfoWrapper class where you can override the IDataColumnInfo.Caption property and return a corresponding column's FieldName property.</p>

<br/>


