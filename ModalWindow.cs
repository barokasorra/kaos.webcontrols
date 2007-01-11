using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KAOS.WebControls
{
	/// <summary>
	/// Summary description for ModalWindow.
	/// </summary>
	[
	ToolboxData("<{0}:ModalWindow runat=server></{0}:ModalWindow>"),
	]
	public class ModalWindow : System.Web.UI.WebControls.WebControl
	{
		
		private String _url= "./GetCodigo.htm";
		private String _Field_to_Update= "";
		private String _Script_After= "";
		private Int32 _WindowsWidth= 300;
		private Int32 _WindowsHeight= 200;
		private Boolean _ShowAlertMessages= true;

		private String Message1 = "Você cancelou esta operação";
		private String Message2 = "Não foi inserido nenhum valor!";

		[
		Description("URL, page to open"),Category("ModalWindow"),Bindable(true),DefaultValue("./GetCodigo.htm"),
		]
		public virtual String url 
		{
			get {return this._url;}
			set {this._url=value;}
		}

		[
		Description("Field to Update or leave Blank. Case sensitive."),Category("ModalWindow"),
		]
		public virtual String Field_to_Update 
		{
			get {return this._Field_to_Update;}
			set {this._Field_to_Update=value;}
			//set {this._Field_to_Update="document.getElementById('"+value+"').value";}
		}

		[
		Description("Script After sucess return. Leave Blank or Java Script"),Category("ModalWindow"),
		]
		public virtual String Script_After 
		{
			get {return this._Script_After;}
			set {this._Script_After=value;}
		}

		[
		Description("Width for new Window"),Category("ModalWindow"),Bindable(true),DefaultValue(300),
		]
		public virtual Int32 WindowsWidth 
		{
			get {return this._WindowsWidth;}
			set {this._WindowsWidth=value;} 
		}

		[
		Description("Height for new Window"),Category("ModalWindow"),Bindable(true),DefaultValue(200),
		]
		public virtual Int32 WindowsHeight 
		{
			get {return this._WindowsHeight;}
			set {this._WindowsHeight=value;} 
		}

		[
		Description("Show Alert Messages after Show Modal Window ?"),Category("ModalWindow"),DefaultValue(true),
		]
		public virtual Boolean ShowAlertMessages 
		{
			get {return this._ShowAlertMessages;}
			set {this._ShowAlertMessages=value;}
		}

		protected Boolean Eh_IE_5_5_or_More() 
		{
			//if (Page.Request.Browser.Browser.ToUpper() == "IE" && Page.Request.Browser.MajorVersion == 5)
			if (Page.Request.Browser.Browser.ToUpper() == "IE")  
			{return true;}
			else {return false;}
		}

		protected String GetClientScript_IE_5_5_OpenModal() 
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append("<script>"); 
			sb.Append("function doModal(url, Width, Height, sStatus) {");
			sb.Append("var cSearchValue=showModalDialog(url,0,");
			sb.Append("\"");
			sb.Append("dialogWidth:");
			sb.Append("\"");
			sb.Append("+ Width +");
			sb.Append("\"");
			sb.Append("px;dialogHeight:");
			sb.Append("\"");
			sb.Append("+ Height +");
			sb.Append("\"");
			sb.Append("px");
			sb.Append("\"");
			sb.Append(");");
			sb.Append("if (sStatus==");
			sb.Append("\"1\"){");
			sb.Append("if (cSearchValue==-1 || cSearchValue==null) ");
			sb.Append("{ cSearchValue=");
			sb.Append("\"\";");
			sb.Append("alert('");
			sb.Append(this.Message1);
			sb.Append("'); } ");
			sb.Append("else if (cSearchValue==");
			sb.Append("\"\")");
			sb.Append("{ alert('");
			sb.Append(this.Message2);
			sb.Append("'); } }");
			sb.Append("if (cSearchValue==null) cSearchValue=");
			sb.Append("\"\";");
			sb.Append("return(cSearchValue);}");
			sb.Append("</script>");
			return sb.ToString();
		}


		protected String GetClientScript_No_IE_OpenModal() 
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append("<script>"); 
			sb.Append("function doModal(url, Width, Height, sStatus) {");
			sb.Append("var cSearchValue=window.open(url,");
			sb.Append("\"");
			sb.Append("\"");
			sb.Append(",");
			sb.Append("\"");
			sb.Append("Width=");
			sb.Append("\"");
			sb.Append("+ Width +");
			sb.Append("\"");
			sb.Append("'"); 
			sb.Append("px");
			sb.Append("'"); 
			sb.Append(",Height="); 
			sb.Append("\"");
			sb.Append("+ Height +");
			sb.Append("\"");
			sb.Append("'");
			sb.Append("px");
			sb.Append("'");
			sb.Append(",");
			sb.Append("resizable=0,scrollbars=0");
			sb.Append("\"");
			sb.Append(");");
			sb.Append("if (sStatus==");
			sb.Append("\"1\"){");
			sb.Append("if (cSearchValue==-1 || cSearchValue==null) ");
			sb.Append("{ cSearchValue=");
			sb.Append("\"\";");
			sb.Append("alert('");
			sb.Append(this.Message1);
			sb.Append("'); } ");
			sb.Append("else if (cSearchValue==");
			sb.Append("\"\")");
			sb.Append("{ alert('");
			sb.Append(this.Message2);
			sb.Append("'); } }");
			sb.Append("if (cSearchValue==null) cSearchValue=");
			sb.Append("\"\";");
			sb.Append("return(cSearchValue);}");
			sb.Append("</script>");
			return sb.ToString();
		}
		
		protected String GetClientScript_OpenModal() 
		{
			if (this.Eh_IE_5_5_or_More()) 
			{ 
				return this.GetClientScript_IE_5_5_OpenModal();}
			else {return this.GetClientScript_No_IE_OpenModal();}
		}

		protected override void OnPreRender(EventArgs e) 
		{ 
			if (!Page.IsClientScriptBlockRegistered("ModalWindow")) 
			{
				Page.RegisterClientScriptBlock("ModalWindow", this.GetClientScript_OpenModal());
			}
			base.OnPreRender(e);
		}

//		protected override void Render(HtmlTextWriter output) 
//		{
//			String sStatus = "0";
//			if (this.ShowAlertMessages == true) {sStatus="1";}
//			String sField = "";
//			if (this.Field_to_Update != "") {sField=this.Field_to_Update + "=";} 
//			sField = sField + "CADS_doModal('" +this.url+ "', " +this.WindowsWidth+ ", " +this.WindowsHeight+ ", " +sStatus+ ");" + this.Script_After;
//			output.AddAttribute(HtmlTextWriterAttribute.Onclick,sField); 
//			output.AddStyleAttribute("CURSOR","hand");
//			base.Render(output);
//		}
	}
}
