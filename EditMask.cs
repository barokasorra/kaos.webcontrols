using System;
using System.Web.UI;
using System.Web.UI.WebControls; 
using System.ComponentModel;

namespace KAOS.WebControls
{
	/// <summary>
	/// Summary description for EditMask.
	/// </summary>
	[
	DefaultProperty("Text"),
	ToolboxData("<{0}:EditMask ReadWrite = true Mascara = \"@@@@-####\" Validar=false RequeridoClientSide=true ValidarClientSide=false runat=server></{0}:EditMask>"),
	]
	public class EditMask : Edit
	{
		private String _mascara = "";
		
		[
		Description("String a ser exibida ao lado do controle quando o email é inválido"),
		Category("Validação"),
		Bindable(true),
		DefaultValue(""),
		]
		public String Mascara
		{
			get {return this._mascara;}
			set{this._mascara = value;}
		}

		protected override void OnPreRender(EventArgs e) {
			base.OnPreRender(e);
			JavaScriptUtil.RegisterMaskScriptForControl(this,this._mascara); 
		}
	}
}
