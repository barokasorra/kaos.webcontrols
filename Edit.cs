using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls; 

namespace KAOS.WebControls
{
	/// <summary>
	/// Summary description for Edit.
	/// </summary>
	[
	DefaultProperty("Text"),
	ToolboxData("<{0}:Edit ReadWrite=true Alinhar=false Validar=false RequeridoClientSide=true ValidarClientSide=false runat=server></{0}:Edit>"),
	]
	public class Edit : System.Web.UI.WebControls.TextBox
	{
		private Boolean _autoTab = true;
		//private Boolean _ReadWrite = true;
		private String _ErrTxtReq = "Campo Requerido";
		private String _ErrMsgReq = "Campo Requerido";
		public RequiredFieldValidator _Requerido = new RequiredFieldValidator();
		LiteralControl _Espaco = new LiteralControl("&nbsp;");
		
		public RangeValidator _Comparador = new RangeValidator();
		private ValidationDataType _TipodeValidacao; 
		private String _ValorInicial;
		private String _ValorFinal;
		private String _ErrMsg = "Dado Inválido";
		private String _ErrTxt = "*";
		private Boolean _Align = true;
		
		
		[
		Description("Permite especificar se o campo será alinhado ou não"),
		Category("Edição"),
		DefaultValue(true),
		Bindable(true),
		//ReadOnly(true),
		]
		public virtual Boolean Alinhar {
			get {return this._Align;}
			set {this._Align=value;}
		}
		
		protected virtual ValidationDataType TipodeValidacao{
			get {return this._TipodeValidacao;}
			set {this._TipodeValidacao=value;}
		}

		[
		Description("String a ser exibida ao lado do controle quando o campo é inválido"),
		Category("Validação"),
		Bindable(true),
		]
		public virtual String TextoErroValidacao
		{
			get {return _ErrTxt;}
			set{_ErrTxt = value;}
		}

		[
		Description("Mensagem de erro a ser exibida quando o campo é inválido"),
		Category("Validação"),
		Bindable(true),
		]
		public virtual String MensagemErroValidacao
		{
			get {return _ErrMsg;}
			set {_ErrMsg = value;}
		}
		
		[
		Description("Digite o valor inicial a ser comparado com o valor final"),
		Category("Validação"),
		Bindable(true),
		]
		public virtual String ValorInicial
		{
			get {return _ValorInicial;}
			set{_ValorInicial = value;}
		}

		[
		Description("Digite o valor final a ser comparado com o valor inicial"),
		Category("Validação"),
		Bindable(true),
		]
		public virtual String ValorFinal
		{
			get {return _ValorFinal;}
			set{_ValorFinal = value;}
		}

		[
		Description("String a ser exibida ao lado do controle quando o controle é requerido"),
		Category("Validação"),
		Bindable(true),
		]
		public virtual String TextoErroRequerido{
			get {return _ErrTxtReq;}
			set{_ErrTxtReq = value;}
		}
		
		[
		Description("Mensagem de erro a ser exibida quando o controle é requerido"),
		Category("Validação"),
		Bindable(true),
		]
		public virtual String MensagemErroRequerido{
			get {return _ErrMsgReq;}
			set {_ErrMsgReq = value;}
		}
 
		[
		Description("Altera o modo de exibição do controle para ReadWrite"),
		Category("Edição"),
		DefaultValue(""),
		Bindable(true),
		]
		public Boolean ReadWrite 
		{
			get 
			{
				return (Boolean)IsNull(ViewState["ReadWrite"],"");
				//return _ReadWrite;
			}
			set 
			{
				//_ReadWrite=value;
				ViewState["ReadWrite"] = value;
			}
		}
		
		[
		Description("Permite especificar se o campo é requerido ou não"),
		Category("Validação"),
		DefaultValue(true),
		Bindable(true),
		]
		public virtual Boolean Requerido {
			get {EnsureChildControls();return _Requerido.Enabled;}
			set {EnsureChildControls();_Requerido.Enabled = Convert.ToBoolean(value);}
		}

		[
		Description("Permite especificar se o campo será validado ou não"),
		Category("Validação"),
		DefaultValue(true),
		Bindable(true),
		]
		public virtual Boolean Validar {
			get {this.EnsureChildControls();return this._Comparador.Enabled;}
			set {this.EnsureChildControls();this._Comparador.Enabled = Convert.ToBoolean(value);}
		}

		[
		Description("Permite especificar se a validação de campo requerido será executada do lado do cliente ou não"),
		Category("Validação"),
		DefaultValue(true),
		Bindable(true),
		ReadOnly(true),
		]
		public virtual Boolean RequeridoClientSide {
			get {this.EnsureChildControls();return this._Requerido.EnableClientScript;}
			set {this.EnsureChildControls();this._Requerido.EnableClientScript = Convert.ToBoolean(value);}
		}

		[
		Description("Permite especificar se a validação de comparação será executada do lado do cliente ou não"),
		Category("Validação"),
		DefaultValue(true),
		Bindable(true),
		//ReadOnly(true),
		]
		public virtual Boolean ValidarClientSide 
		{
			get {this.EnsureChildControls();return this._Comparador.EnableClientScript;}
			set {this.EnsureChildControls();this._Comparador.EnableClientScript = Convert.ToBoolean(value);}
		}

		[
		Description("Permite especificar se o campo pulará automaticamente para o próximo campo da tela ao atingir o tamanho máximo"),
		Category("Validação"),
		DefaultValue(true),
		Bindable(true),
		]
		public virtual Boolean AutoTab 
		{
			get {return this._autoTab;}
			set {this._autoTab=value;}
		}

		protected string AutoTabJs() {
			return	"<script language=\"javascript\"> " +
					"function Tab(AInput, AEvent){ " +
					"var KeyCode = (navigator.appName.indexOf(\"Netscape\") != -1) ? AEvent.which : AEvent.keyCode; " +
					"var NavKeys = [0,8,9,16,17,18,27,35,36,37,38,39,40,46]; " +
					"var obj; " +
					"if(AInput.value.length >= AInput.maxLength && !KeyInNavKeys(NavKeys, KeyCode)) { " +
					"obj = AInput.form[(GetFieldIndex(AInput)+1) % AInput.form.length]; " +
					"while (obj.type == 'hidden'){ " +
					"obj = AInput.form[(GetFieldIndex(obj)+1) % AInput.form.length]; " +
					"} " +
					"obj.focus(); " +
					"} " +
					"function KeyInNavKeys(ANavKeys, AKeyCode) { " +
					"var found = false, i = 0; " +
					"while(!found && i < ANavKeys.length) " +
					"if(ANavKeys[i] == AKeyCode) " +
					"found = true; " +
					"else " +
					"i++; " +
					"return found; " +
					"} " +
					"function GetFieldIndex(AInput) { " +
					"var j = -1, i = 0, found = false; " +
					"while (i < AInput.form.length && j == -1) " +
					"if (AInput.form[i] == AInput) j = i; " +
					"else i++; " +
					"return j; " +
					"} " +
					"} " +
					"</script>";
		}

		protected override void OnInit(EventArgs e) 
		{
			if (_Requerido.Enabled) 
			{
				_Requerido.ControlToValidate = this.ID;
				_Requerido.Text = this.TextoErroRequerido; 
				_Requerido.ErrorMessage = this.MensagemErroRequerido;
				_Requerido.Font.Name = "Verdana";
				_Requerido.Font.Size = System.Web.UI.WebControls.FontUnit.XXSmall;
				_Requerido.Display = ValidatorDisplay.Dynamic; 
				Controls.Add(this._Espaco);
				Controls.Add(this._Requerido);
			}
			
			if (this._Comparador.Enabled)
			{
				this._Comparador.Type = this.TipodeValidacao; 
				this._Comparador.ControlToValidate= this.ID;
				this._Comparador.Text = this.TextoErroValidacao; 
				this._Comparador.ErrorMessage = this.MensagemErroValidacao; 
				this._Comparador.MaximumValue = this.ValorFinal;
				this._Comparador.MinimumValue = this.ValorInicial;
				this._Comparador.Font.Name = "Verdana";
				this._Comparador.Font.Size = System.Web.UI.WebControls.FontUnit.XXSmall;
				this._Comparador.Display = ValidatorDisplay.Dynamic; 
				Controls.Add(this._Comparador);
			}
		}

		protected override void OnPreRender(EventArgs e){
			base.OnPreRender(e);

			if (!Page.IsClientScriptBlockRegistered("AUTOTAB"))
			{
				Page.RegisterClientScriptBlock("AUTOTAB", this.AutoTabJs());
			}

			if (this.AutoTab) {
				this.Attributes.Add("onKeyUp", "Tab( this, event )"); 
			}

			if (this.ReadWrite == false && this._Comparador.IsValid == true && this._Requerido.IsValid == true )
			{
				//this.Attributes.Remove("onfocus");
				//this.Attributes.Remove("onBlur");
				
				if (!this.Alinhar) 
				{this.Attributes.Add("style","background-color:transparent;border-style:none;TEXT-ALIGN: left;FONT-WEIGHT: bold");}
				else 
				{this.Attributes.Add("style","background-color:transparent;border-style:none;TEXT-ALIGN: right;FONT-WEIGHT: bold");}
				
				this.ReadOnly = true;
			}
			else {
				this.Attributes.Remove("style");
				this.Attributes.Add("style","TEXT-ALIGN: left");
				//muito esquisito ...
				//this.Attributes.Add("onfocus","javascript: if (this.style.textAlign=='right'){this.style.textAlign='left';}");
				//this.Attributes.Add("onBlur","javascript:this.style.textAlign='right'"); 
				
				this.ReadOnly = false;
			}
		}

		protected override void Render(HtmlTextWriter output)
		{
			base.Render (output);

			if (_Requerido.Enabled) 
			{ 
				_Espaco.RenderControl(output); 
				_Requerido.RenderControl(output);
			}
			
			if (this._Comparador.Enabled) 
			{
				this._Comparador.RenderControl(output);
			}
		}	
	
		#region IPostBackDataHandler Members .. armazena estado entre postbacks

		//verifica c eh nulo antes de inserir no Viewstate
		private object IsNull( object valueToCheck, object replacementValue )
		{
			return valueToCheck == null ? replacementValue : valueToCheck ;
		}

		public void RaisePostDataChangedEvent()
		{
			// TODO:  Add Edit.RaisePostDataChangedEvent implementation
		}

		public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
		{
			// TODO:  Add Edit.LoadPostData implementation
			this.ReadWrite = Convert.ToBoolean(postCollection[postDataKey]);
			return false;
		}

		#endregion
	}
}
