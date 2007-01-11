using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KAOS.WebControls
{
	/// <summary>
	/// Summary description for DataGridGrouped.
	/// </summary>
	[
	DefaultProperty("IndexesColumn"),
	ToolboxData("<{0}:DataGridGrouped runat=server></{0}:DataGridGrouped>"),
	]
	public class DataGridGrouped : DataGrid 
	{ 
		private string _IndexesColumn = "";
		private string _CssClassNiveis = "";
		private Boolean _MostrarHeaderNoNivel = false;

		public DataGridGrouped() {
			this.PreRender += new System.EventHandler(this.DataGridGrouping_OnPreRender);
		}

		[
		Description("Index das colunas que serão quebras, separadas por virgula. Não utilize o index 0"),
		CategoryAttribute("DataGridGrouped"),
		]
		public String IndexesColumn {
			get {return this._IndexesColumn;}
			set {this._IndexesColumn = value;}
		}

		[
		Description("Estilo das quebras, separadas por virgula, e na respectiva ordem dos indexes"),
		CategoryAttribute("DataGridGrouped")
		]
		public String CssClassNiveis 
		{
			get {return this._CssClassNiveis ;}
			set {this._CssClassNiveis=value;}
		}

		[
		Description("Permite mostrar o Header da coluna, que foi promovida, na quebra do grid."),
		CategoryAttribute("DataGridGrouped"),
		]
		public Boolean MostrarHeaderNoNivel 
		{
			get {return this._MostrarHeaderNoNivel;}
			set {this._MostrarHeaderNoNivel=value;}
		}

		private string RetornaEspace(int y)
		{
			int i = 0;
			string _spc = "&nbsp;";
			for (i=0;i<y;i++) {_spc += "&nbsp;";}
			return _spc;
		} 

	//======================================================================
		private void DataGridGrouping_OnPreRender(object sender, System.EventArgs e)
		{
			string[] _index = this._IndexesColumn.Split(Convert.ToChar(",")); 
			string[] _class = this._CssClassNiveis.Split(Convert.ToChar(",")); 

			DataGrid dgMain = (DataGrid)sender;
			Table tblMain = (Table)dgMain.Controls[0];
			string strPreviousValue = "";
			
			int j = 0;
			string[] _temp = new string[_index.Length];

			for (j=0; j <= _index.GetUpperBound(0);j++) 
			{ 
				for(int intCount = 0; intCount < tblMain.Controls.Count; intCount++)
				{
					DataGridItem objItem = (DataGridItem)tblMain.Controls[intCount];
				
					if (objItem.ItemType == ListItemType.Header) 
					{
						int c = 0;
						foreach(string x in _index) 
						{
							_temp.SetValue(objItem.Cells[Convert.ToInt32(x)].Text,c++);
							objItem.Cells[Convert.ToInt32(x)].Visible = false;
						}
					} 

					if (objItem.ItemType == ListItemType.Item || objItem.ItemType == ListItemType.AlternatingItem)
					{
						if (objItem.Cells.Count != 1) 
						{ 
							string strValue = objItem.Cells[Convert.ToInt32(_index[j])].Text;
							if (strValue != strPreviousValue)
							{
								strPreviousValue = strValue;
								DataGridItem dgiNew = new DataGridItem(0, 0, ListItemType.Item);
								TableCell tdNew = new TableCell();
								tdNew.ColumnSpan = objItem.Cells.Count;
								
								if (this._MostrarHeaderNoNivel) {tdNew.Text = this.RetornaEspace(j)+_temp[j] + strValue;}
								else {tdNew.Text = this.RetornaEspace(j)+strValue;}
								
								tdNew.CssClass = _class[j];

								dgiNew.Cells.Add(tdNew);
								tblMain.Controls.AddAt(tblMain.Controls.IndexOf(objItem), dgiNew);
							} 
							else 
							{
								objItem.Cells[Convert.ToInt32(_index[j])].Visible = false;
								objItem.Cells[0].Text = this.RetornaEspace(j) + objItem.Cells[0].Text;
							}
						}
					}
				}
			}
		}
	//======================================================================
	}
}
