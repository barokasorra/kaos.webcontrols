using System;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KAOS.WebControls
{
	/// <summary>
	/// Summary description for ContentBar.
	/// </summary>
	/// 	
	[
	DefaultEvent("Click"),
	DefaultProperty("Src"),
	ToolboxData("<{0}:ContentBar Contracted=false Src=\"index.htm\" Width=200 Height=500 TextLinkNews=\"Noticias\" Description=\"Barra de conteúdo\" CaminhoIconeNews=\"./contentbar/news.gif\" CaminhoIcone=\"./contentbar/icon.gif\" CaminhoVoltar=\"./contentbar/back.gif\" ClassTable=\"contentbar\" runat=server></{0}:ContentBar>"),
	Designer("KAOS.WebControls.ContentBarDesign"),
	]
	public class ContentBar: System.Web.UI.WebControls.WebControl, IPostBackDataHandler, INamingContainer
	{
		System.Web.UI.WebControls.Label _description = new System.Web.UI.WebControls.Label(); 
		System.Web.UI.WebControls.LinkButton _link = new System.Web.UI.WebControls.LinkButton();
		
		private string _src = "";
		private string _caminhoIcone = "";
		private string _caminhoIconeNews = "";
		private string _caminhoVoltar = "";
//		private string _assunto = "";
		private string _classTable = "";

//		[
//		Description("..."),
//		Category("ContentBar"),
//		]
//		public string Assunto {
//			get {return this._assunto;}
//			set {this._assunto = value;}
//		}

		[
		Description("Permite especificar o texto do link do painel de noticias."),
		Category("ContentBar"),
		Bindable(true),
		DefaultValue(""),
		]
		public string TextLinkNews {
			get {this.EnsureChildControls();return this._link.Text;}
			set {this.EnsureChildControls();this._link.Text = value;}
		}
		
		[
		Description("Permite especificar a descrição que será mostrada na barra superior."),
		Category("ContentBar"),
		Bindable(true),
		DefaultValue(""),
		]
		public string Description {
			get {this.EnsureChildControls();return this._description.Text;}
			set {this.EnsureChildControls();this._description.Text = value;}
		}
		
		[
		Description("Permite especificar o caminho do icone que ficará sobre o painel de noticias."),
		Category("ContentBar"),
		Bindable(true),
		DefaultValue(""),
		]
		public string CaminhoIconeNews {
			get {return this._caminhoIconeNews;}
			set {this._caminhoIconeNews = value;}
		}
		
		[
		Description("Permite especificar o caminho do icone que ficará a esquerda na barra superior."),
		Category("ContentBar"),
		Bindable(true),
		DefaultValue(""),
		]
		public string CaminhoIcone {
			get {return this._caminhoIcone;}
			set {this._caminhoIcone = value;}
		}

		[
		Description("Permite especificar o caminho do icone de voltar da barra superior"),
		Category("ContentBar"),
		Bindable(true),
		DefaultValue(""),
		]
		public string CaminhoVoltar {
			get {return this._caminhoVoltar;}
			set {this._caminhoVoltar = value;}
		}

		[
		Description("Permite especificar o estilo da que será aplicada a barra superior."),
		Category("ContentBar"),
		Bindable(true),
		DefaultValue(""),
		]
		public string ClassTable {
			get {return this._classTable;}
			set {this._classTable = value;}
		}

		[
		Description("Permite especificar se a barra de conteúdo será visivel ou não."),
		Category("ContentBar"),
		Bindable(true),
		DefaultValue(""),
		]
		public Boolean Contracted {
			get {return (Boolean)IsNull(ViewState["Contracted"],"");}
			set {ViewState["Contracted"] = value;}
		}

		[
		Description("Permite especificar a url que será aberta pela barra de conteúdo."),
		Category("ContentBar"),
		Bindable(true),
		DefaultValue(""),
		]
		public string Src {
			get {return this._src;}
			set {this._src = value;}
		}

		private object IsNull( object valueToCheck, object replacementValue )
		{
			return valueToCheck == null ? replacementValue : valueToCheck ;
		}

		public bool LoadPostData (string postDataKey,NameValueCollection postCollection) 
		{
			this.Contracted  = Convert.ToBoolean(postCollection[postDataKey]);
			return false;
		}

		public void RaisePostDataChangedEvent () 
		{ 
			//implements ...
		}

		protected override void CreateChildControls() 
		{ 
			Controls.Add(this._description);
			Controls.Add(this._link);  
		}

		#region Events
		public event EventHandler Click 
		{
			add {this._link.Click += value;}
			remove {this._link.Click -= value;}
		}

		private void HideIframe(object sender, System.EventArgs e) {
			if (this.Contracted) {this.Contracted = false;}
			else {this.Contracted = true;}
		}

		protected override void OnInit(EventArgs e) 
		{
			this.Click += new System.EventHandler(this.HideIframe);
		}
		#endregion
		
		#region RenderPath
		protected string IsCaminhoFundoTable() 
		{
			if (this._classTable != "") 
			{
				return string.Format("<table width=\"100%\" class=\"{0}\">",this._classTable); 
			}
			else {
				return string.Format("<table width=\"100%\">"); 
			}
		}

		protected string IsCaminhoIcone() 
		{
			if (this._caminhoIcone != "") 
			{
				return string.Format("<img src=\"{0}\" />&nbsp;",this._caminhoIcone);
			}
			else {return "";}
		}

		protected string IsCaminhoVoltar() {
			if (this._caminhoVoltar != "") 
			{
				return string.Format("<img src=\"{0}\" onclick=\"javacript:history.back();\" style=\"cursor:pointer;\" />&nbsp;",this._caminhoVoltar);
			}
			else {return "";}
		}

		protected string IsContracted(){
			if (!this.Contracted) 
			{ 
				System.Text.StringBuilder sb = new System.Text.StringBuilder();
				sb.Append(string.Format("<iframe id=\"{0}\" src=\"{1}\" frameSpacing=\"0\" marginHeight=\"0\" frameBorder=\"0\"","content_"+this.ClientID,this._src));
				sb.Append(string.Format(" scrolling=\"no\" align=\"right\" style=\"position:absolute;display:block;width:{0};height:{1}\">",this.Width,this.Height)); 
				sb.Append(string.Format("</iframe>"));
				return sb.ToString();
			} 
			else {return "";}

			//if (this.Contracted) {return "display:none";}
			//else {return "display:block";}
		}

		protected string IsCaminhoIconeNews() 
		{
			if (this._caminhoIconeNews != "") 
			{
				return string.Format("<img src=\"{0}\" />&nbsp;",this._caminhoIconeNews);
			}
			else {return "";}
		}

		protected override void Render(HtmlTextWriter writer) { 
			writer.Write("<div width=\"100%\" align=\"top\">");
			writer.Write(this.IsCaminhoFundoTable());
			
			writer.Write("<tr>");
			
			writer.Write("<td width=\"1%\">");
			writer.Write(this.IsCaminhoVoltar());
			writer.Write("</td>");
			
			writer.Write("<td width=\"1%\">");
			writer.Write(this.IsCaminhoIcone());
			writer.Write("</td>");
			
			//writer.Write("<td width=\"64%\" align=\"middle\">");
			writer.Write("<td width=\"60%\">");
			this._description.RenderControl(writer); 
			writer.Write("</td>");
			
			writer.Write("<td align=\"right\" width=\"15%\">");
			writer.Write(this.IsCaminhoIconeNews());
			writer.Write("<font class=linknews>");
			this._link.RenderControl(writer);
			writer.Write("</font>");
			writer.Write("</td>");
			
			writer.Write("</tr>");
			
			writer.Write("</table>");
			writer.Write("</div>");
			writer.Write(this.IsContracted()); 
			//writer.Write("<iframe id=\"{0}\" src=\"{1}\" frameSpacing=\"0\" marginHeight=\"0\" frameBorder=\"0\"","cadscontent_"+this.ClientID,this._src);
			//writer.Write(" scrolling=\"no\" align=\"right\" style=\"{0};width:{1};height:{2}\">",this.IsContracted(),this.Width,this.Height); 
			//writer.Write("</iframe>"); 			
		}
		#endregion
	
	}
}
