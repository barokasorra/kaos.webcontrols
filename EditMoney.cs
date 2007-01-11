using System;
using System.Web.UI;
using System.Web.UI.WebControls; 
using System.ComponentModel;

namespace KAOS.WebControls
{
	/// <summary>
	/// Summary description for EditMoney.
	/// </summary>
	[
	DefaultProperty("Text"),
	ToolboxData("<{0}:EditMoney ReadWrite=true RequeridoClientSide=true ValidarClientSide=false MaxLength = 20 MensagemErroValidacao=\"Valor Inválido\" TextoErroValidacao=\"Valor Inválido\" ValorInicial= \"0,00\" ValorFinal=\"99.999,99\" runat=server></{0}:EditMoney>"),
	]
	public class EditMoney : Edit
	{
	
		//private Boolean _decpoint = true;
		//private String dp;

		/*[
		Description("Utilizar vírgula como ponto decimal"),
		Category("Edição"),
		DefaultValue(true),
		Bindable(true),
		]
		public virtual Boolean VirgulaPontoDecimal {
			get {return _decpoint;}
			set {_decpoint = value;}
		}*/

		protected override void OnInit(EventArgs e) 
		{
			this.TipodeValidacao = ValidationDataType.Currency;
			base.OnInit(e);
		}

		protected override void OnPreRender(EventArgs e) {
			base.OnPreRender(e); 
			//if (!_decpoint) {dp = "',','.'";} else {dp="'.',','";}
			//JavaScriptUtil.RegisterMoneyScriptForControl(this,this.dp);
			JavaScriptUtil.RegisterMoneyScriptForControl(this);
		}

		protected override void Render(HtmlTextWriter output) 
		{
			this.Columns = 10;
			base.Render(output);
		}	
	}
}
