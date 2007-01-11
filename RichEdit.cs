using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions; 

namespace KAOS.WebControls
{
	/// <summary>
	/// Summary description for RichEdit.
	/// </summary>
	[ 
	DefaultProperty("Text"),
	ToolboxData("<{0}:RichEdit Width=\"550px\" Height=\"400px\" CaminhoDirJavaScript=\"richedit/\" Text=\"&lt;P&gt;&lt;FONT face=Verdana size=2&gt;&lt;/FONT&gt;&lt;/P&gt;\" runat=server></{0}:RichEdit>"), 
	]
	public class RichEdit : System.Web.UI.WebControls.TextBox
	{
		private String _caminhoJs = "";

		[
		EditorAttribute(typeof(System.Web.UI.Design.UrlEditor), typeof(System.Drawing.Design.UITypeEditor)),
		Category("RichEdit"), Description("Caminho do diretório onde está o js e os arquivos do RichEdit. Termina com /"),
		DefaultValue("richedit/"),
		]
		public String CaminhoDirJavaScript
		{
			get {return this._caminhoJs;}
			set {this._caminhoJs = value;}
		}

		protected String NameForm ()
		{
			String s="";
			for (int i = 0 ; i < this.Page.Controls.Count; i++)
			{
				if (this.Page.Controls[i] is System.Web.UI.HtmlControls.HtmlForm)
				{
					s = this.Page.Controls[i].ID;
				}
			}
			return s;
		}

		protected String RTESafe() 
		{
			String tmpString = this.Text.Trim();
			
			tmpString = tmpString.Replace(Convert.ToChar(145),Convert.ToChar(39));
			tmpString = tmpString.Replace(Convert.ToChar(146),Convert.ToChar(39)); 
			tmpString = tmpString.Replace("'","&#39;");

			tmpString = tmpString.Replace(Convert.ToChar(147),Convert.ToChar(34)); 
			tmpString = tmpString.Replace(Convert.ToChar(148),Convert.ToChar(34));
  
			tmpString = tmpString.Replace(Convert.ToChar(10),Convert.ToChar(" ")); 
			tmpString = tmpString.Replace(Convert.ToChar(13),Convert.ToChar(" ")); 
			
			return tmpString;
		}

		protected String PostBack() {
			return @"<script>
					if ( typeof(window['__doPostBack']) != 'undefined') {
					var __oldDoPostBack = __doPostBack;
					__doPostBack = AlwaysFireBeforeFormSubmit; }
					
					function AlwaysFireBeforeFormSubmit (eventTarget, eventArgument) {
						updateRTEs();
						look();
						if (eventTarget != undefined ) {
						return __oldDoPostBack (eventTarget, eventArgument);}
					}
					
					function look() {
						var i;
						var inputs = document.getElementsByTagName('input');
						for (i=0;i < inputs.length;i++) {
							if ( inputs[i].id.indexOf('txtrte') != -1) {
								var idRich = inputs[i].id;
								idRich = idRich.replace('txtrte','rte');
								document.getElementById(inputs[i].id).value = document."+this.NameForm()+@"[idRich].value;
							} 
						}
					}
					</script>";
		}

		private string _oldID = "";
		protected override void OnInit(EventArgs e) {
			base.OnInit(e);
			this._oldID = this.ClientID; 
			this.ID = this.ID+"txtrte"; 
		}
	
		protected override void OnPreRender(EventArgs e) 
		{
			if(!this.Page.IsClientScriptBlockRegistered("jsRte")) 
			{
				System.Text.StringBuilder _script = new System.Text.StringBuilder();
				_script.Append("<script type=\"text/javascript\" src=\"" + this._caminhoJs + "richtext.js" + "\"></script>");
				_script.Append("<script type=\"text/javascript\">");
				_script.Append("initRTE(\""+this._caminhoJs+"images/\", \""+this._caminhoJs+"\", \""+this._caminhoJs+"\");");
				_script.Append("</script>");
				
				this.Page.RegisterClientScriptBlock("jsRte",_script.ToString()+this.PostBack());
				
				System.Web.UI.HtmlControls.HtmlForm frm = (System.Web.UI.HtmlControls.HtmlForm)this.Page.FindControl(this.NameForm());
				frm.Attributes.Add("onSubmit","AlwaysFireBeforeFormSubmit()");
				
				//String _rteValue = "updateRTEs();document.getElementById('"+this.ClientID+"').value=document."+this.NameForm()+"."+this.ClientID+"_rte.value;";
				//this.Page.RegisterOnSubmitStatement("_submit",_rteValue); 
			}
			this.Attributes.Add("style","display:none");
		}
		
		protected override void Render(HtmlTextWriter writer) 
		{
			base.Render(writer);
			writer.Write("<script language=\"JavaScript\" type=\"text/javascript\">");
			writer.Write("writeRichText('{0}rte','{1}','{2}','{3}',true,false)",this._oldID,this.RTESafe(),this.Width,this.Height);
			writer.Write("</script>"); 
		}
	}
}