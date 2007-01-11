using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace KAOS.WebControls
{
	[ToolboxData("<{0}:ExpandingRadio TextoItemDiv=\"item1=div1,item2=div2\" runat=server></{0}:ExpandingRadio>")]
	public class ExpandingRadio : System.Web.UI.WebControls.RadioButton 
	{
		private string _textoItemDiv = "";

		[
		Description("Especifique a condição para o controle das divs. Ex: 'animal=divdoanimal,casa=divdacasa'"),
		Category("ExpandingRadio"),
		Bindable(true),
		DefaultValue(""),
		]
		public string TextoItemDiv 
		{
			get {return this._textoItemDiv;}
			set {this._textoItemDiv = value;}
		}

		protected override void OnPreRender(EventArgs e) 
		{
			base.OnPreRender(e);
			string _script = JavaScriptUtil.RegisterItemControlDivsScriptForControl(this._textoItemDiv,"radio",this.Text);
			JavaScriptUtil.RegisterItemControlDivsForPage(this.Page);
			this.Attributes.Add("onclick",_script); 
		}
	} 
}
