using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KAOS.WebControls
{
	/// <summary>
	/// Summary description for ModalWindow.
	/// </summary>
	[
	DefaultEvent("SelectedIndexChanged"),
	DefaultProperty("url"),
	ToolboxData("<{0}:ComboPopUp Lista=\"item1,item2,item3\" UltimoItem=\"Outros...\" runat=server></{0}:ComboPopUp>"),
	]
	public class ComboPopUp : ModalWindow
	{
		
		private String _valorHidden = "";
		private String _items = "";
		private String _ultimoItemCombo = "";
		private String _itemSelecionado = "";
		DropDownList _combo = new DropDownList();
		System.Web.UI.HtmlControls.HtmlInputHidden  _value = new System.Web.UI.HtmlControls.HtmlInputHidden();
  
		[
		Description("CSS Class name applied to the control."),
		Category("Appearance"),
		Bindable(true),
		]
		public override string CssClass
		{
			get{this.EnsureChildControls();return this._combo.CssClass;}
			set{this.EnsureChildControls();this._combo.CssClass=value;}
		}

		[
		Description("Nome do último item que aparecerá no Combo"),
		Category("ComboPopUp"),
		Bindable(true),
		]
		public virtual String UltimoItem {
			get {this.EnsureChildControls();return this._ultimoItemCombo;}
			set {this.EnsureChildControls();this._ultimoItemCombo=value;}
		}

		[
		Description("Item que aparecerão no Combo. Insira os items separados por virgula."),
		Category("ComboPopUp"),
		Bindable(true),
		]
		public virtual String Lista 
		{
			get {return this._items;}
			set {this._items=value;}
		}

		[
		Description("Utilize para pegar o valor de retorno do hidden ..."),
		Category("ComboPopUp"),
		Bindable(true),
		]
		public virtual String ValordeRetorno 
		{
			get {this.EnsureChildControls();return this._value.Value;}
			set {this.EnsureChildControls();this._value.Value = value;}
		}

		[
		Description("Automatically postback to the server after selection is changed."),
		Category("Behavior"),
		Bindable(true),
		]
		public virtual Boolean AutoPostBack {
			get {this.EnsureChildControls();return this._combo.AutoPostBack;}
			set {this.EnsureChildControls();this._combo.AutoPostBack = value;}
		}

		[
		Description("Field to Update or leave Blank. Case sensitive."),Category("ModalWindow"),
		ReadOnly(true),
		]
		public override String Field_to_Update 
		{
			get {return base.Field_to_Update;}
			set {base.Field_to_Update=value;}
		}

		public virtual ListItem SelectedItem {
			get {this.EnsureChildControls(); return this._combo.SelectedItem;}
		} 

		public virtual Int32 SelectedIndex {
			get {this.EnsureChildControls();return this._combo.SelectedIndex;}
			set {this.EnsureChildControls();this._combo.SelectedIndex = value;}
		}

		public virtual ListItemCollection Items {
			get {this.EnsureChildControls();return this._combo.Items;}
		}
 
		protected ListItem RetornaItem(String stringItem) 
		{
			ListItem _Item = new ListItem();
			String _strTemp = stringItem;
				
			if (_strTemp.IndexOf(";") != -1) 
			{
				_Item.Text = _strTemp.Substring(0,_strTemp.IndexOf(";"));
				_Item.Value = _strTemp.Substring(_strTemp.IndexOf(";")+1,(_strTemp.Length - _strTemp.IndexOf(";"))-1);
			} 
			else 
			{
				_Item.Text = _strTemp;
				_Item.Value = _strTemp;
			}

			return _Item;
		}

		public void LoadCombo() 
		{
			if (this._combo.Items.Count != 0) {this._itemSelecionado = this._combo.SelectedItem.Text;}
 
			this._combo.Items.Clear();
			
			Int32 i = 0;
			String[] arrayList = this._items.Split(Convert.ToChar(","));
 
			if (this._value.Value != "") 
			{
				this._combo.Items.Add(this.RetornaItem(this._value.Value)); 
			}
			
			for (i=0;i<=arrayList.GetUpperBound(0);i++) 
			{
				if (arrayList[i]!=this._value.Value){this._combo.Items.Add(this.RetornaItem(arrayList[i]));} 										
			}

			this._combo.Items.Add(this._ultimoItemCombo);
			this._combo.SelectedIndex = this._combo.Items.IndexOf(this._combo.Items.FindByText(this._itemSelecionado)); 

			if (this._combo.SelectedItem.Text == this.UltimoItem ) 
			{
				this._combo.SelectedIndex = 0;
			}
			//modificacao ...
			this._value.Value = "";
		}

		public String ListaModificada() 
		{
			String _listMod ="";
			Int32 i=0;

			if (this._combo.SelectedItem.Text != this.UltimoItem) 
			{ 
				_listMod = this._combo.SelectedItem.Text + ";" + this._combo.SelectedItem.Value + ",";
			}
			
			for (i=0;i<=(this._combo.Items.Count-2);i++)
			{
				if (this._combo.SelectedItem.Text != this._combo.Items[i].Text)
				{
					_listMod+=this._combo.Items[i].Text + ";" + this._combo.Items[i].Value + ",";
				}
			}
			_listMod = _listMod.Substring(0,_listMod.Length - 1);
			return _listMod;
		}

		public event EventHandler SelectedIndexChanged 
		{
			add {this._combo.SelectedIndexChanged += value;}
			remove {this._combo.SelectedIndexChanged -=value;}
		}

		protected override void OnInit(EventArgs e) {
			this._value.ID="HiddenCombo";
			this._value.Value = this._valorHidden;
			base.Field_to_Update = this._value.ClientID;

			this.LoadCombo();
		}

		protected override void CreateChildControls() {
			Controls.Add(this._value);
			Controls.Add(this._combo);
		}

		protected override void OnPreRender(EventArgs e) {
			base.OnPreRender(e);
			this.LoadCombo();

			String sStatus = "0";
			if (base.ShowAlertMessages == true) {sStatus="1";}
			String sField = "";
			if (base.Field_to_Update != "") {sField="document.getElementById('"+base.Field_to_Update+"').value"+"=";}
			sField = "if (this.item(this.selectedIndex).text =='"+this._ultimoItemCombo+"') {"+sField+"doModal('" +this.url+ "', " +this.WindowsWidth+ ", " +this.WindowsHeight+ ", " +sStatus+ ");" + this.Script_After + "}";
			this._combo.Attributes.Add("onchange",sField);
			this._value.Attributes.Add("onpropertychange",Page.GetPostBackEventReference(this._value));   
		}
	}
}

		