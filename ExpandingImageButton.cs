using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.ComponentModel;


namespace KAOS.WebControls {

	/// <summary>
	/// A clientscript-enabled push-style button which toggles the visibility of another control on the page.
	/// </summary>
	/// <remarks>
	/// This button has no server-side click event, as the action it performs is done on the clientside.
	/// </remarks>
	[
	DefaultProperty("ExpandedImageUrl"),
	]
	public class ExpandingImageButton : System.Web.UI.WebControls.WebControl, INamingContainer {
		
		#region Properties
		/// <summary>
		/// Gets or sets the ID of the control which is the target of the visibility-toggling behavior.
		/// </summary>
		[
		Description("Gets or sets the ID of the control which is the target of the visibility-toggling behavior."),
		Category("Behavior"),
		DefaultValue(""),
		Bindable(true),
		]
		public virtual String ControlToToggle {
			get {
				object savedState = this.ViewState["ControlToToggle"];
				if ( savedState != null ) {
					return (String)savedState; 
				}
				else {
					return "";
				}
			}
			set {
				this.ViewState["ControlToToggle"] = value;
				this.cachedTargetControl = null;
			}
		}

		/// <summary>
		/// Gets or sets the expanded state of the target control.
		/// </summary>
		[
		Description("Gets or sets the expanded state of the target control."),
		Category("Appearance"),
		DefaultValue(true),
		Bindable(true),
		]
		public virtual Boolean Expanded {
			get {
				object savedState = this.ViewState["Expanded"];
				if ( savedState != null ) {
					return (Boolean)savedState; 
				}
				else {
					return true;
				}
			}
			set {
				this.ViewState["Expanded"] = value;
			}
		}

		/// <summary>
		/// Gets or sets the indicator of whether clientscript is used for the behavior.
		/// </summary>
		/// <remarks>
		/// When set to false, a postback is performed in order to set the visibility of the target control.
		/// </remarks>
		[
		Description("Gets or sets the indicator of whether clientscript is used for the behavior."),
		Category("Behavior"),
		DefaultValue(true),
		]
		public virtual Boolean EnableClientScript {
			get {
				object savedState = this.ViewState["EnableClientScript"];
				if ( savedState != null ) {
					return (Boolean)savedState; 
				}
				else {
					return true;
				}
			}
			set {
				this.ViewState["EnableClientScript"] = value;
			}
		}

		/// <summary>
		/// Gets or sets the url of the image shown when the target control is in the expanded state.
		/// </summary>
		[
		Description("Gets or sets the url of the image shown when the target control is in the expanded state."),
		Category("Appearance"),
		DefaultValue(""),
		Bindable(true),
		]
		public virtual String ExpandedImageUrl {
			get {
				object savedState = this.ViewState["ExpandedImageUrl"];
				if ( savedState != null ) {
					return (String)savedState;
				}	
				return "";
			}
			set {
				this.ViewState["ExpandedImageUrl"] = value;
			}
		}

		/// <summary>
		/// Gets or sets the url of the image shown when the target control is in the contracted state.
		/// </summary>
		[
		Description("Gets or sets the url of the image shown when the target control is in the contracted state."),
		Category("Appearance"),
		DefaultValue(""),
		Bindable(true),
		]
		public virtual String ContractedImageUrl {
			get {
				object savedState = this.ViewState["ContractedImageUrl"];
				if ( savedState != null ) {
					return (String)savedState;
				}
				return "";
			}
			set {
				this.ViewState["ContractedImageUrl"] = value;
			}
		}

		/// <summary>
		/// Gets or sets the alt-text applied when the target control is in the expanded state.
		/// </summary>
		[
		Description("Gets or sets the alt-text applied when the target control is in the expanded state."),
		Category("Appearance"),
		DefaultValue(""),
		Bindable(true),
		]
		public virtual String ExpandedAlternateText {
			get {
				object savedState = this.ViewState["ExpandedAlternateText"];
				if ( savedState != null ) {
					return (String)savedState;
				}	
				return "";
			}
			set {
				this.ViewState["ExpandedAlternateText"] = value;
			}
		}

		/// <summary>
		/// Gets or sets the alt-text applied when the target control is in the contracted state.
		/// </summary>
		[
		Description("Gets or sets the alt-text applied when the target control is in the contracted state."),
		Category("Appearance"),
		DefaultValue(""),
		Bindable(true),
		]
		public virtual String ContractedAlternateText {
			get {
				object savedState = this.ViewState["ContractedAlternateText"];
				if ( savedState != null ) {
					return (String)savedState;
				}
				return "";
			}
			set {
				this.ViewState["ContractedAlternateText"] = value;
			}
		}

		#endregion

		#region Render Path
		/// <summary>
		/// Overrides <see cref="Control.CreateChildControls"/>.
		/// </summary>
		protected override void CreateChildControls() {
			base.CreateChildControls ();

			button = new System.Web.UI.WebControls.ImageButton();
			button.CausesValidation = false;
			button.ID = "clicker";
			button.Click += new System.Web.UI.ImageClickEventHandler( this.button_Click );
			this.Controls.Add(button);

			tracker = new HtmlInputHidden();
			tracker.Name = "tracker";
			tracker.ID = "tracker";
			tracker.ServerChange += new EventHandler( this.ClientExpanedStateChanged );
			this.Controls.Add(tracker);
		}


		/// <summary>
		/// Overrides <see cref="Control.OnPreRender"/>.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPreRender(EventArgs e) {
			base.OnPreRender (e);
			
			if ( this.EnableClientScript ) {
				this.RegisterClientScript();
				this.tracker.Visible = true;
			} else {
				this.tracker.Visible = false;
			}
			this.ApplyExpansionState();
		}

		/// <summary>
		/// Overrides <see cref="Control.Render"/>
		/// </summary>
		protected override void Render(HtmlTextWriter writer) {
			this.EnsureChildControls();
			if ( this.Expanded ) {
				this.button.ImageUrl = this.ExpandedImageUrl;
				this.button.AlternateText = this.ExpandedAlternateText;
			} else {
				this.button.ImageUrl = this.ContractedImageUrl;
				this.button.AlternateText = this.ContractedAlternateText;
			}
			base.Render (writer);
		}


		/// <summary>
		/// Overrides <see cref="WebControl.RenderContents"/>.
		/// </summary>
		/// <param name="writer"></param>
		protected override void RenderContents(HtmlTextWriter writer) {
			this.RenderChildren(writer);
		}

		#endregion

		/// <summary>
		/// Overrides <see cref="Control.Controls"/>.
		/// </summary>
		public override ControlCollection Controls {
			get {
				this.EnsureChildControls();
				return base.Controls;
			}
		}


		/// <summary>
		/// Applies the <see cref="Expanded"/> value to the server control set by <see cref="ControlToToggle"/>.
		/// </summary>
		protected virtual void ApplyExpansionState() {
			this.tracker.Value = this.Expanded.ToString();
			
			if ( this.EnableClientScript ) {
				if ( this.Expanded ) {
					if ( this.targetStyle["display"] != null ) {
						this.targetStyle.Remove("display");
					}
				} else {
					this.targetStyle["display"] = "none";
				}
			} else {
				this.targetControl.Visible = this.Expanded;
			}
		}

		/// <summary>
		/// when clientside rendering is enabled, this will alert the control to clientside changes in the Expanded state.
		/// </summary>
		private void ClientExpanedStateChanged( Object sender, EventArgs e ) {
			try {
				Boolean clientExpanedValue = Boolean.Parse( tracker.Value );
				this.Expanded = clientExpanedValue;
			} catch {}
		}

		/// <summary>
		/// If clientscript is disabled, the button will cause a postback, which will need to be handled by changin the Expanded state.
		/// </summary>
		private void button_Click(Object sender, ImageClickEventArgs e) {
			this.Expanded = !this.Expanded;
		}



		/// <summary>
		/// Registers the clientscript with the page.
		/// </summary>
		protected virtual void RegisterClientScript() {
			ExpandingButtonScriptUtil.RegisterScriptForControl(this.button,this.targetControl,this.tracker,this.ExpandedAlternateText + "__" + this.ExpandedImageUrl, this.ContractedAlternateText + "__" + this.ContractedImageUrl);
		}


		private Control targetControl {
			get {
				if ( cachedTargetControl == null ) {
					this.cachedTargetControl = this.NamingContainer.FindControl(this.ControlToToggle);
				}
				return this.cachedTargetControl;
			}
		}
		private Control cachedTargetControl = null;

		private System.Web.UI.CssStyleCollection targetStyle {
			get {
				WebControl targetWebControl = this.targetControl as WebControl;
				if ( targetWebControl != null ) {
					return targetWebControl.Style;
				}
				System.Web.UI.HtmlControls.HtmlControl targetHtmlControl = this.targetControl as System.Web.UI.HtmlControls.HtmlControl;
				if ( targetWebControl != null ) {
					return targetHtmlControl.Style;
				}
				return null;
			}
		}

		private System.Web.UI.HtmlControls.HtmlInputHidden tracker;
		private System.Web.UI.WebControls.ImageButton button;
	}
}
