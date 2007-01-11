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
	ToolboxData("<{0}:EditTime ReadWrite=true RequeridoClientSide=true ValidarClientSide=true runat=server></{0}:EditTime>"),
	]
	public class EditTime : EditNumber
	{
		RegularExpressionValidator Regex = new RegularExpressionValidator();
		private String _jsRegExp = @"/[0-9:]/";
		private String _exp = @"^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$";
		private String _RegexMsg = "Hora Inválida";
		private String _RegexTxt = "Hora Inválida";

		[
		Description("Permite especificar se o campo será validado ou não"),
		Category("Validação"),
		DefaultValue(true),
		Bindable(true),
		]
		public override Boolean Validar 
		{
			get {return this.Regex.Enabled;}
			set {this.Regex.Enabled=value;}
		}
			
		[
		Description("Permite especificar se a validação do campo será executada do lado do cliente ou não"),
		Category("Validação"),
		DefaultValue(true),
		Bindable(true),
		ReadOnly(false),
		]
		public override Boolean ValidarClientSide 
		{
			get {return this.Regex.EnableClientScript;}
			set {this.Regex.EnableClientScript = value;}
		}

		[
		Category("Validação"),
		DefaultValue(true),
		ReadOnly(true),
		]
		public override String ValorInicial 
		{
			get {return base.ValorInicial;}
			set {this.ValorInicial=value;}
		}

		[
		Category("Validação"),
		DefaultValue(true),
		ReadOnly(true),
		]
		public override String ValorFinal 
		{
			get {return base.ValorFinal;}
			set {base.ValorFinal=value;}
		}

		[
		Description("String a ser exibida ao lado do controle quando a hora é inválida"),
		Category("Validação"),
		Bindable(true),
		]
		public override String TextoErroValidacao
		{
			get {return this._RegexTxt;}
			set{this._RegexTxt = value;}
		}

		[
		Description("Mensagem de erro a ser exibida quando a hora é inválida"),
		Category("Validação"),
		Bindable(true),
		]
		public override String MensagemErroValidacao
		{
			get {return this._RegexMsg;}
			set {this._RegexMsg = value;}
		}

		protected override void OnInit(EventArgs e) 
		{
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
			this.Attributes.Remove("onkeypress"); 
			//JavaScriptUtil.RegisterNumberScriptForControl(this,_jsRegExp);
			JavaScriptUtil.RegisterMaskScriptForControl(this,"##:##:##");
			if (!this.Regex.IsValid) 
			{
				this.Attributes.Remove("style");
				this.Attributes.Add("style","TEXT-ALIGN: left");
				this.ReadOnly = false;
			}
		}

		protected override void Render(HtmlTextWriter output) 
		{
			this.Columns = 10;
			base.Render(output);
			this.Regex.RenderControl(output); 
		}
	}
}