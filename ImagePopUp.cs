using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KAOS.WebControls
{
	/// <summary>
	/// Summary description for ImagePopUp.
	/// </summary>
	[
	DefaultProperty("url"),
	ToolboxData("<{0}:ImagePopUp runat=server></{0}:ImagePopUp>"),
	]
	public class ImagePopUp : ModalWindow
	{
		private ImageHighLighting _image = new ImageHighLighting();

		[
		Description("Image File Name (gif / jpg)"),
		Category("ImageHighLighting"),
		Bindable(true),
		DefaultValue("popupIcon.gif"),
		]
		public virtual String Image_src
		{
			get {this.EnsureChildControls();return this._image.Image_src;} 
			set {this.EnsureChildControls();this._image.Image_src = value;}
		}

		[
		Description("Directory to find the images for the menu.  Need to have 'image_src' here!"),
		Category("ImageHighLighting"),
		Bindable(true),
		DefaultValue("images/"),
		]
		public virtual String ImagesDir 
		{
			get {this.EnsureChildControls();return this._image.ImagesDir;}
			set {this.EnsureChildControls();this._image.ImagesDir = value;}
		}

		[
		Description("Text Alternative"),
		Category("ImageHighLighting"),
		Bindable(true),
		DefaultValue("..."),
		]
		public virtual String Alt 
		{
			get {this.EnsureChildControls();return this._image.Alt;}
			set {this.EnsureChildControls();this._image.Alt = value;}
		}

		[
		Description("HighLighting Start, Value 0% to 100%, 100=No HighLighting"),
		Category("ImageHighLighting"),
		Bindable(true),
		DefaultValue(100),
		]
		public virtual Int32 HighLighting 
		{
			get {this.EnsureChildControls();return this._image.HighLighting;}
			set {this.EnsureChildControls();this._image.HighLighting = value;}
		}

		protected override void OnInit(EventArgs e) { 
			Controls.Add(this._image); 
		}

		protected override void OnPreRender(EventArgs e) {
			base.OnPreRender(e);

			String sStatus = "0";
			if (this.ShowAlertMessages == true) {sStatus="1";}
			String sField = "";
			//if (this.Field_to_Update != "") {sField=this.Field_to_Update + "=";}
			if (base.Field_to_Update != "") {sField="document.getElementById('"+base.Field_to_Update+"').value"+"=";}
			sField = sField + "doModal('" +this.url+ "', " +this.WindowsWidth+ ", " +this.WindowsHeight+ ", " +sStatus+ ");" + this.Script_After;
				
			this.Attributes.Add("onclick",sField);
			this.Attributes.Add("style","cursor:pointer;cursor:hand");
		}
	}
}

