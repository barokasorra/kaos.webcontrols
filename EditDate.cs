using System;
using System.Web.UI;
using System.Web.UI.WebControls; 
using System.ComponentModel;

namespace KAOS.WebControls
{
	/// <summary>
	/// Summary description for EditDate.
	/// </summary>
	[
	DefaultProperty("Text"),
	ToolboxData("<{0}:EditDate ReadWrite=true RequeridoClientSide=true ValidarClientSide=false MensagemErroValidacao=\"Data Inválida\" TextoErroValidacao=\"Data Inválida\" ValorInicial= \"1/1/1900\" ValorFinal=\"1/1/2050\" runat=server></{0}:EditDate>"),
	]
	public class EditDate : Edit 
	{
		protected override void OnInit(EventArgs e) {
			this.TipodeValidacao = ValidationDataType.Date;
			base.OnInit(e);
		}
		
		protected override void OnPreRender(EventArgs e) {
			base.OnPreRender(e); 
			JavaScriptUtil.RegisterDataScriptForControl(this); 
		}

		protected override void Render(HtmlTextWriter output) {
			this.Columns = 10;
			base.Render(output); 
		}
	}
}
