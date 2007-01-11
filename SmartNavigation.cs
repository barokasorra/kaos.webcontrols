using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace KAOS.WebControls
{
	/// <summary>
	/// Summary description for SmartNavigation.
	/// </summary>
	[
	DefaultProperty("Enabled"),
	ToolboxData("<{0}:SmartNavigation Enabled=true runat=server></{0}:SmartNavigation>"),
	]
	public class SmartNavigation : Control
	{
		private Boolean _enabled = true;
		
		[
		Description("Permite especificar se o smartnavigation vai ser ativado ou não."),
		Category("Design"),
		DefaultValue(true),
		Bindable(true),
		]
		public Boolean Enabled
		{
			get {return this._enabled ;}
			set {this._enabled=value;}
		}

		protected override void Render(HtmlTextWriter writer)
		{
			if (_enabled)
			{
				writer.Write("<input type=\"hidden\" id=\"" + this.ID + "_OffsetY\" name=\"" + this.ID + "_OffsetY\" value=\"0\">\n");
				writer.Write("<input type=\"hidden\" id=\"" + this.ID + "_OffsetX\" name=\"" + this.ID + "_OffsetX\" value=\"0\">\n");
				writer.Write("<script language=\"Javascript\">\n");
				writer.Write("function " + this.ID + "_OnScroll(){\n");
				writer.Write("document.getElementById(\"" + this.ID  + "_OffsetY\").value = document.body.scrollTop;\n");
				writer.Write("document.getElementById(\"" + this.ID  + "_OffsetX\").value = document.body.scrollLeft ;\n");
				writer.Write("}\n");
				writer.Write("if (window.addEventListener){\n");
				writer.Write("window.addEventListener('scroll'," + this.ID  + "_OnScroll, false);\n");
				writer.Write("window.addEventListener('click'," + this.ID  + "_OnScroll, false);\n");
				writer.Write("window.addEventListener('keypress'," + this.ID  + "_OnScroll, false);\n");
				writer.Write("}\n");		
				writer.Write("else {\n");
				writer.Write("window.attachEvent('onscroll'," + this.ID  + "_OnScroll);\n");
				writer.Write("}\n");		
				if (Page.IsPostBack )
				{
					writer.Write("function " + this.ID + "_OnLoad(){\n");
					writer.Write("window.scrollTo(" +  Page.Request.Form[this.ID + "_OffsetX"]+ "," + Page.Request.Form[this.ID + "_OffsetY"] + ");\n");
					writer.Write("}\n");
					writer.Write("if (window.addEventListener){\n");
					writer.Write("window.addEventListener('load'," + this.ID  + "_OnLoad, false);\n");
					writer.Write("}\n");		
					writer.Write("else{\n");
					writer.Write("window.attachEvent('onload'," + this.ID  + "_OnLoad);\n");
					writer.Write("}\n");
				}		
				writer.Write("</script>\n");
			
				this.RenderChildren(writer);
			}
		}
	}
}
