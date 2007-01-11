using System;
using System.Web.UI;
using System.Web.UI.WebControls; 
using System.ComponentModel;

namespace KAOS.WebControls
{
	/// <summary>
	/// Summary description for EditEmail.
	/// </summary>
	[
	DefaultProperty("Text"),
	ToolboxData("<{0}:EditEmail ReadWrite=true RequeridoClientSide=true ValidarClientSide=false runat=server></{0}:EditEmail>"),
	]
	public class EditEmail : Edit
	{
		RegularExpressionValidator Regex = new RegularExpressionValidator();
		private String _exp = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
		private String _RegexMsg = "Email Inv�lido";
		private String _RegexTxt = "Email Inv�lido";

		[
		Description("Permite especificar se o campo ser� validado ou n�o"),
		Category("Valida��o"),
		DefaultValue(true),
		Bindable(true),
		ReadOnly(true),
		]
		public override Boolean Validar 
		{
			get {return this.Regex.Enabled;}
			set {this.Regex.Enabled=value;}
		}

		[
		Description("Permite especificar se a valida��o do campo ser� executada do lado do cliente ou n�o"),
		Category("Valida��o"),
		DefaultValue(true),
		Bindable(true),
		ReadOnly(true),
		]
		public override Boolean ValidarClientSide 
		{
			get {return this.Regex.EnableClientScript;}
			set {this.Regex.EnableClientScript = value;}
		}

		[
		Category("Valida��o"),
		DefaultValue(true),
		ReadOnly(true),
		]
		public override String ValorInicial {
			get {return base.ValorInicial;}
			set {this.ValorInicial=value;}
		}

		[
		Category("Valida��o"),
		DefaultValue(true),
		ReadOnly(true),
		]
		public override String ValorFinal {
			get {return base.ValorFinal;}
			set {base.ValorFinal=value;}
		}
		
		[
		Description("String a ser exibida ao lado do controle quando o email � inv�lido"),
		Category("Valida��o"),
		Bindable(true),
		]
		public override String TextoErroValidacao
		{
			get {return this._RegexTxt;}
			set{this._RegexTxt = value;}
		}

		[
		Description("Mensagem de erro a ser exibida quando o email � inv�lido"),
		Category("Valida��o"),
		Bindable(true),
		]
		public override String MensagemErroValidacao
		{
			get {return this._RegexMsg;}
			set {this._RegexMsg = value;}
		}

		protected override void OnInit(EventArgs e) {
			base.Alinhar = false; 
			base.Validar = false;
			base.OnInit(e);
			this.Regex.ControlToValidate = this.ID;  
			this.Regex.ValidationExpression = this._exp;
			this.Regex.ErrorMessage= this._RegexMsg;
			this.Regex.Text = this._RegexTxt;
			this.Regex.Font.Name = "Verdana";
			this.Regex.Font.Size = System.Web.UI.WebControls.FontUnit.XXSmall;
			this.Regex.Display = ValidatorDisplay.Dynamic;
			Controls.Add(this.Regex);  	
		}

		protected override void OnPreRender(EventArgs e) 
		{
			base.OnPreRender(e);
			if (!this.Regex.IsValid) {
				this.Attributes.Remove("style");
				this.Attributes.Add("style","TEXT-ALIGN: left");
				this.ReadOnly = false;
			} 
		}

		protected override void Render(HtmlTextWriter output) {
			base.Render(output);
			this.Regex.RenderControl(output); 
		}
	}
}
