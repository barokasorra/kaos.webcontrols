using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KAOS.WebControls
{
	/// <summary>
	/// Summary description for ModalValue.
	/// </summary>
	[
	DefaultProperty("ValordeRetorno"),
	ToolboxData("<{0}:ModalLink Text=\"LinkButton\" ValordeRetorno=\"Valor retornado da modal\" runat=server></{0}:ModalLink>"),
	]

	public class ModalLink : System.Web.UI.WebControls.WebControl, INamingContainer
	{
		System.Web.UI.HtmlControls.HtmlInputHidden  _value = new System.Web.UI.HtmlControls.HtmlInputHidden();
		System.Web.UI.WebControls.LinkButton _link = new System.Web.UI.WebControls.LinkButton(); 
		
		[
		Description("Valor que irá retornar para a tela que chamou a janela modal."),
		Category("ModalLink"),
		Bindable(true),
		DefaultValue("insira um valor"),
		]
		public virtual String ValordeRetorno 
		{
			get {this.EnsureChildControls();return this._value.Value;}
			set {this.EnsureChildControls();this._value.Value = value;}
		}

		[
		Description("The text to be shown for the link."),
		Category("Appearance"),
		Bindable(true),
		DefaultValue(""),
		]
		public virtual String Text {
			get {this.EnsureChildControls();return this._link.Text;}
			set {this.EnsureChildControls();this._link.Text=value;}
		}

		[
		Description("CSS Class name applied to the control."),
		Category("Appearance"),
		Bindable(true),
		]
		public override string CssClass
		{
			get{this.EnsureChildControls();return this._link.CssClass;}
			set{this.EnsureChildControls();this._link.CssClass=value;}
		}
		
		protected string RetornaValueModal()
		{ 
//			return @"<script>
//					function doOk() {
//					var valor = document.getElementById('"+this._value.ClientID+@"').value
//					if (valor != ''){
//					window.returnValue= document.getElementById('"+this._value.ClientID+@"').value
//					window.close();} }
//					</script>";
			return @"<script>
					function doOk(ctl) {
					var valor = document.getElementById(ctl).value
					if (valor != ''){
					window.returnValue= document.getElementById(ctl).value
					window.close();} }
					</script>";
		}

		protected override void CreateChildControls() 
		{
			this._value.ID = "HiddenRetorno";
			Controls.Add(this._value);
			
			this._link.CausesValidation= false;
			this._link.Attributes.Add("onclick","javascript:doOk('"+this._value.ClientID+"');return false;");
			Controls.Add(this._link);
		}

		protected override void OnPreRender(EventArgs e) 
		{ 
			if (!Page.IsClientScriptBlockRegistered("ModalValue")) 
			{
				Page.RegisterClientScriptBlock("ModalValue", this.RetornaValueModal());
			}
		}
	}
}