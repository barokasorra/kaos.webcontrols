using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls; 

namespace KAOS.WebControls {

	[
	DefaultProperty("text"),
	ToolboxData("<{0}:EditAutoComplete ReadWrite = true Alinhar = false RequeridoClientSide=true Validar=false ValidarClientSide=false Dados=\"'1.1 - Item 1','1.2 - Item 2'\" CaminhoJavaScript=\"autocomplete/actb.js\" NoFindMiddle=true NumeroItems=\"10\" runat=server></{0}:EditAutoComplete>"),
	]
	public class EditAutoComplete : Edit 
	{
		private String _caminhoJs = "";
		private Boolean _noFindMiddle = true;
		private String _dados = "";
		private Int32 _numberItems = 0;

		[
		Description("Permite espeficar se o controle completará palavras em qualquer parte da string"),
		Category("AutoComplete"),
		Bindable(true),
		DefaultValue(true)
		]
		public virtual Boolean NoFindMiddle {
			get {return this._noFindMiddle;}
			set {this._noFindMiddle = value;}
		}

		[
		Description("Permite espeficar quantos items o controle mostrará abaixo do TextBox"),
		Category("AutoComplete"),
		Bindable(true),
		DefaultValue(10)
		]
		public virtual Int32 NumeroItems
		{
			get {return this._numberItems;}
			set {this._numberItems = value;}
		}

		[
		EditorAttribute(typeof(System.Web.UI.Design.UrlEditor), typeof(System.Drawing.Design.UITypeEditor)),
		Category("AutoComplete"), Description("Caminho do javascript do autocompletar"),
		DefaultValue("..."),
		]
		public string CaminhoJavaScript
		{
			get {return this._caminhoJs;}
			set {this._caminhoJs = value;}
		}

		[
		Description("List de items que aparecerá na lista em baixo do TextBox. Formato : '1.1 - Item 1','1.2 - Item 2'"),
		Category("AutoComplete"),
		Bindable(true),
		DefaultValue("..."),
		]
		public string Dados {
			get {return this._dados;}
			set {this._dados=value;}
		}

		protected string RetornaDados () {
			string nomeArray = this.UniqueID.Replace(":","_")+"_Array"; /* possivel problema com ASCX ? (this.clientid) */
			return @"<script>
					var "+nomeArray+"=new Array("
					+this._dados+
					");</script>";
		}

		protected override void OnPreRender(EventArgs e) {
			base.OnPreRender(e);

			this.Page.RegisterClientScriptBlock(this.ClientID+"_Array",this.RetornaDados());
			
			if(!this.Page.IsClientScriptBlockRegistered("jsAutoCompleteSource"))
			{
				this.Page.RegisterClientScriptBlock("jsAutoCompleteSource","<script type=\"text/javascript\" src=\"" + this._caminhoJs + "\"></script>");
			}

			if (this.ReadWrite) 
			{
				this.Attributes.Add("onfocus","actb(this,event,"+this.UniqueID.Replace(":","_")/* possivel problema com ASCX ? (this.clientid) */+"_Array,"+Convert.ToString(this._noFindMiddle).ToLower()+","+this._numberItems+")"); 
				this.Attributes.Add("autocomplete","off"); //pro autocomplete do windows nao atrapalhar
			}
			else
			{
				this.Attributes.Remove("onfocus");
				this.Attributes.Remove("autocomplete");
			}

		}

		protected override void Render(HtmlTextWriter output) {
			base.Render(output);
		}
	} 
}