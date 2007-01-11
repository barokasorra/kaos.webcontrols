using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel; 

namespace KAOS.WebControls
{
	/// <summary>
	/// Summary description for EditDatePopUp.
	/// </summary>
	[
	DefaultProperty("CaminhoJavaScript"),
	ToolboxData("<{0}:EditDatePopUp ReadWrite = true RequeridoClientSide=true ValidarClientSide=false MensagemErroValidacao=\"Data Inválida\" TextoErroValidacao=\"Data Inválida\" ValorInicial= \"1/1/1900\" ValorFinal=\"1/1/2050\" CaminhoJavaScript=\"calendar/popcalendar.js\" CaminhoImage=\"calendar/cal.gif\" MaxLength=\"10\" runat=\"server\"></{0}:EditDatePopUp>"),
	]
	public class EditDatePopUp : System.Web.UI.WebControls.WebControl,INamingContainer 
	{
		private string _CaminhoJs;
		EditDate txtData = new EditDate();
		Image imgCalendar = new Image(); 
		
		[
		EditorAttribute(typeof(System.Web.UI.Design.UrlEditor), typeof(System.Drawing.Design.UITypeEditor)),
		Category("Edição"), Description("Caminho do javascript do calendário")
		]
		public string CaminhoJavaScript
		{
			get {return _CaminhoJs;}
			set {_CaminhoJs = value;}
		}

		[
		EditorAttribute(typeof(System.Web.UI.Design.UrlEditor), typeof(System.Drawing.Design.UITypeEditor)),
		Category("Edição"), Description("Caminho da imagem do calendário")
		]
		public string CaminhoImage 
		{
			get {EnsureChildControls();return imgCalendar.ImageUrl;}
			set {EnsureChildControls();imgCalendar.ImageUrl = value;}
		}

		[
		Description("Altera o modo de exibição do controle para ReadWrite"),
		Category("Edição"),
		DefaultValue(true),
		Bindable(true),
		]
		public virtual Boolean ReadWrite
		{
			get {EnsureChildControls();return this.txtData.ReadWrite;}
			set {EnsureChildControls();this.txtData.ReadWrite=value;}
			//get {return _ReadWrite;}
			//set {_ReadWrite=value;}
		}

		[
		Description("The text value."),
		Category("Appearance"),
		Bindable(true),
		]
		public virtual string Text 
		{
			get {this.EnsureChildControls();return this.txtData.Text;}
			set {this.EnsureChildControls();this.txtData.Text = value;}
		}

		[
		Description("The maximum numbers of characters that can be entered."),
		Category("Behavior"),
		Bindable(true),
		DefaultValue(10),
		]
		public virtual Int32 MaxLength {
			get {this.EnsureChildControls(); return this.txtData.MaxLength;}
			set {this.EnsureChildControls();this.txtData.MaxLength = value;}
		}

		[
		Description("Permite especificar se o campo é requerido ou não"),
		Category("Validação"),
		DefaultValue(true),
		Bindable(true),
		]
		public virtual Boolean Requerido {
			get {this.EnsureChildControls();return this.txtData.Requerido;}
			set {this.EnsureChildControls();this.txtData.Requerido =value;}
		}

		[
		Description("Mensagem de erro a ser exibida quando o controle é querido"),
		Category("Validação"),
		Bindable(true),
		]
		public virtual String MensagemErroRequerido 
		{
			get {this.EnsureChildControls();return this.txtData.MensagemErroRequerido;}
			set {this.EnsureChildControls();this.txtData.MensagemErroRequerido=value;}
		}

		[
		Description("String a ser exibida ao lado do controle quando o controle é requerido"),
		Category("Validação"),
		Bindable(true),
		]
		public virtual String TextoErroRequerido
		{
			get {this.EnsureChildControls();return this.txtData.TextoErroRequerido;}
			set {this.EnsureChildControls();this.txtData.TextoErroRequerido=value;}
		}

		[
		Description("Mensagem de erro a ser exibida quando o campo é inválido"),
		Category("Validação"),
		Bindable(true),
		]
		public virtual String MensagemErroValidacao
		{
			get {this.EnsureChildControls();return this.txtData.MensagemErroValidacao;}
			set {this.EnsureChildControls();this.txtData.MensagemErroValidacao=value;}
		}

		[
		Description("String a ser exibida ao lado do controle quando o campo é inválido"),
		Category("Validação"),
		Bindable(true),
		]
		public virtual String TextoErroValidacao
		{
			get {this.EnsureChildControls();return this.txtData.TextoErroValidacao;}
			set {this.EnsureChildControls();this.txtData.TextoErroValidacao=value;}
		}

		[
		Description("Digite o valor inicial a ser comparado com o valor final"),
		Category("Validação"),
		Bindable(true),
		]
		public virtual String ValorInicial
		{
			get {this.EnsureChildControls();return this.txtData.ValorInicial;}
			set{this.EnsureChildControls();this.txtData.ValorInicial=value;}
		}

		[
		Description("Digite o valor final a ser comparado com o valor inicial"),
		Category("Validação"),
		Bindable(true),
		]
		public virtual String ValorFinal
		{
			get {this.EnsureChildControls();return this.txtData.ValorFinal;}
			set{this.EnsureChildControls();this.txtData.ValorFinal=value;}
		}

		[
		Description("Permite especificar se o campo será validado ou não"),
		Category("Validação"),
		DefaultValue(true),
		Bindable(true),
		]
		public virtual Boolean Validar 
		{
			get {this.EnsureChildControls();return this.txtData.Validar;}
			set {this.EnsureChildControls();this.txtData.Validar=value;}
		}

		[
		Description("CSS Class name applied to the control."),
		Category("Appearance"),
		Bindable(true),
		]
		public override string CssClass
		{
			get{this.EnsureChildControls();return this.txtData.CssClass;}
			set{this.EnsureChildControls();this.txtData.CssClass=value;}
		}

		[
		Description("Permite especificar se a validação de campo requerido será executada do lado do cliente ou não"),
		Category("Validação"),
		DefaultValue(true),
		Bindable(true),
		ReadOnly(false),
		]
		public virtual Boolean RequeridoClientSide 
		{
			get {this.EnsureChildControls();return this.txtData.RequeridoClientSide;}
			set {this.EnsureChildControls();this.txtData.RequeridoClientSide=value;}
		}

		[
		Description("Permite especificar se a validação de comparação será executada do lado do cliente ou não"),
		Category("Validação"),
		DefaultValue(true),
		Bindable(true),
		ReadOnly(false),
		]
		public virtual Boolean ValidarClientSide 
		{
			get {this.EnsureChildControls();return this.txtData.ValidarClientSide;}
			set {this.EnsureChildControls();this.txtData.ValidarClientSide=value;}
		}

		[
		Description("Permite especificar se o campo pulará automaticamente para o próximo campo da tela ao atingir o tamanho máximo"),
		Category("Validação"),
		DefaultValue(true),
		Bindable(true),
		]
		public virtual Boolean AutoTab 
		{
			get {this.EnsureChildControls(); return this.txtData.AutoTab;}
			set {this.EnsureChildControls();this.txtData.AutoTab = value;}
		}

		protected override void CreateChildControls()
		{
			txtData.ID = "txtData";
			Controls.Add(txtData);
			
			Controls.Add(new LiteralControl("&nbsp;"));
  
			imgCalendar.ID = "imgCalendar";
			imgCalendar.Height = 16;
			imgCalendar.Width = 16;
			imgCalendar.Attributes.Add("style","cursor:pointer");
			imgCalendar.Attributes.Add("alt","Clique aqui para abrir o calendário."); 
			Controls.Add(imgCalendar);
 
			Controls.Add(new LiteralControl("&nbsp;"));

			//this.txtData.Attributes.Add("onfocus","javascript:popUpCalendar(document.getElementById(\"" + imgCalendar.ClientID + "\"),document.getElementById(\"" + txtData.ClientID + "\"), \"dd/mm/yyyy\");");
			//this.txtData.Attributes.Add("onClick","javascript:popUpCalendar(this,document.getElementById(\"" + txtData.ClientID + "\"), \"dd/mm/yyyy\");"); 
			//this.txtData.Attributes.Add("onBlur","javascript:hideCalendar()");
		}

		protected override void OnPreRender(EventArgs e)
		{
	    
			if (this.txtData.ReadWrite  == false && this.txtData._Comparador.IsValid==true && this.txtData._Requerido.IsValid==true) 
			{
				imgCalendar.Visible = false;
			}
			else 
			{
				if(!this.Page.IsClientScriptBlockRegistered("jsCalendarSource"))
				{
					this.Page.RegisterClientScriptBlock("jsCalendarSource","<script type=\"text/javascript\" src=\"" + _CaminhoJs + "\"></script>");
				}
				imgCalendar.Attributes.Add("onClick","javascript:popUpCalendar(this,document.getElementById(\"" + txtData.ClientID + "\"), \"dd/mm/yyyy\");" + this.txtData.ClientID + ".focus();");  
				imgCalendar.Visible = true;
			}
		}

		protected override object SaveViewState() 
		{
			EnsureChildControls();
			object[] state = new object[3];
			object objBase = base.SaveViewState();
			state[0] = objBase;
			state[1] = txtData.Text;
			state[2] = this.imgCalendar.Visible; 
			return state;
		}

		protected override void LoadViewState(object savedState) 
		{
			object[] state = (object[])savedState;
			base.LoadViewState (state[0]);
			EnsureChildControls();
			txtData.Text = state[1].ToString();
			this.imgCalendar.Visible = Convert.ToBoolean(state[2]);
		}
	}
}
