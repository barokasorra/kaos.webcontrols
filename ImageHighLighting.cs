using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KAOS.WebControls
{
	/// <summary>
	/// Summary description for ImageHighLighting for IE only.
	/// </summary>
	[
	DefaultProperty("Image_src"),
	ToolboxData("<{0}:ImageHighLighting runat=server></{0}:ImageHighLighting>"),
	]
	public class ImageHighLighting : System.Web.UI.WebControls.WebControl 
	{
		
		Image imgHigh = new Image(); 

		private String _ImagesDir = "images/";
		private String _image_src = "popupIcon.gif";
		private String _Alt = "...";
		private Int32 _HighLighting = 100;
		
		[
		Description("Image File Name (gif / jpg)"),
		Category("ImageHighLighting"),
		Bindable(true),
		DefaultValue("popupIcon.gif"),
		]
		public virtual String Image_src
		{
			get {return this._image_src;} 
			set {this._image_src = value;}
		}

		[
		Description("Directory to find the images for the menu.  Need to have 'image_src' here!"),
		Category("ImageHighLighting"),
		Bindable(true),
		DefaultValue("images/"),
		]
		public virtual String ImagesDir {
			get {return this._ImagesDir;}
			set {this._ImagesDir = value;}
		}

		[
		Description("Text Alternative"),
		Category("ImageHighLighting"),
		Bindable(true),
		DefaultValue("..."),
		]
		public virtual String Alt {
			get {return this._Alt;}
			set {this._Alt = value;}
		}

		[
		Description("HighLighting Start, Value 0% to 100%, 100=No HighLighting"),
		Category("ImageHighLighting"),
		Bindable(true),
		DefaultValue(100),
		]
		public virtual Int32  HighLighting {
			get {return this._HighLighting;}
			set 
			{
				this._HighLighting = value;
				if (this._HighLighting < 0) {this._HighLighting = 0;}
				if (this._HighLighting > 100) {this._HighLighting = 100;}
			}
		}

		protected String GetClientScript_HighLighting(){
		return @"<script>
function high(obj) { theobject=obj; highlighting=setInterval(""highlightit(theobject)"",50); };
function low(obj, opac)  { clearInterval(highlighting); obj.filters.alpha.opacity=opac; };
function highlightit(obj) { if (obj.filters.alpha.opacity<100) obj.filters.alpha.opacity+=5; else if (highlighting) clearInterval(highlighting); };</script>";
		}
	
		protected override void OnPreRender(EventArgs e) {
			if (this._HighLighting != 100 && !Page.IsClientScriptBlockRegistered("HighLighting")){
			Page.RegisterClientScriptBlock("HighLighting",this.GetClientScript_HighLighting()); 
			}
		}
		
		protected override void Render(HtmlTextWriter output) {	
			//image
			output.AddAttribute("id",this.UniqueID);  
			output.AddAttribute("alt",this._Alt);
			output.AddAttribute("src",this.ImagesDir + this.Image_src);
			output.AddAttribute(HtmlTextWriterAttribute.Border,"0");

			if (this._HighLighting !=100) 
			{
				output.AddAttribute("OnMouseover","high(this)");
				output.AddAttribute("OnMouseLeave","low(this," + this._HighLighting.ToString() + ")");
				output.AddStyleAttribute("FILTER","alpha(opacity=" + this._HighLighting.ToString() + ")");
			}
			output.RenderBeginTag(HtmlTextWriterTag.Img);
			output.RenderEndTag();
		}
	}
}

