using System;
using System.Web.UI;
using System.Web.UI.WebControls; 
using System.ComponentModel;

namespace KAOS.WebControls
{
	/// <summary>
	/// Summary description for EditNumber.
	/// </summary>
	[
	DefaultProperty("Text"),
	ToolboxData("<{0}:EditNumber ReadWrite=true RequeridoClientSide=true ValidarClientSide=false MensagemErroValidacao=\"Número Inválido\" TextoErroValidacao=\"Número Inválido\" ValorInicial= \"0\" ValorFinal=\"100000\" runat=server></{0}:EditNumber>"),
	]
	public class EditNumber : Edit
	{
		protected override void OnInit(EventArgs e) 
		{
			this.TipodeValidacao = ValidationDataType.Integer;
			base.OnInit(e);
		}

		protected override void OnPreRender(EventArgs e) 
		{
			base.OnPreRender(e); 
			JavaScriptUtil.RegisterNumberScriptForControl(this,@"/\d/"); 
		}

		protected override void Render(HtmlTextWriter output) 
		{
			this.Columns = 10;
			base.Render(output);
		}
	}
}
