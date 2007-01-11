using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.ComponentModel;


namespace KAOS.WebControls 
{

	/// <summary>
	/// A clientscript-enabled push-style button which toggles the visibility of another control on the page.
	/// </summary>
	/// <remarks>
	/// This button has no server-side click event, as the action it performs is done on the clientside.
	/// </remarks>
	[
	DefaultProperty("Expanded"),
	]
	public class ExpandingCheckBox : System.Web.UI.WebControls.WebControl, INamingContainer 
	{
		
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
		public virtual String ControlToToggle 
		{
			get 
			{
				object savedState = this.ViewState["ControlToToggle"];
				if ( savedState != null ) 
				{
					return (String)savedState; 
				}
				else 
				{
					return "";
				}
			}
			set 
			{
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
		public virtual Boolean Expanded 
		{
			get 
			{
				object savedState = this.ViewState["Expanded"];
				if ( savedState != null ) 
				{
					return (Boolean)savedState; 
				}
				else 
				{
					return true;
				}
			}
			set 
			{
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
		public virtual Boolean EnableClientScript 
		{
			get 
			{
				object savedState = this.ViewState["EnableClientScript"];
				if ( savedState != null ) 
				{
					return (Boolean)savedState; 
				}
				else 
				{
					return true;
				}
			}
			set 
			{
				this.ViewState["EnableClientScript"] = value;
			}
		}

		/// <summary>
		/// Gets or sets the text shown when the target control is in the expanded state.
		/// </summary>
		/*[
		Description("Gets or sets the text shown when the target control is in the expanded state."),
		Category("Appearance"),
		DefaultValue(""),
		Bindable(true),
		]
		public virtual String ExpandedText 
		{
			get 
			{
				object savedState = this.ViewState["ExpandedText"];
				if ( savedState != null ) 
				{
					return (String)savedState;
				}	
				return "";
			}
			set 
			{
				this.ViewState["ExpandedText"] = value;
			}
		}*/

		/// <summary>
		/// Gets or sets the text shown when the target control is in the contracted state.
		/// </summary>
		/// <remarks>
		/// When left empty, the <see cref="ExpandedText"/> property value is used.
		/// </remarks>
		/*[
		Description("Gets or sets the text shown when the target control is in the contracted state."),
		Category("Appearance"),
		DefaultValue(""),
		Bindable(true),
		]
		public virtual String ContractedText 
		{
			get 
			{
				object savedState = this.ViewState["ContractedText"];
				if ( savedState != null ) 
				{
					return (String)savedState;
				}
				return "";
			}
			set 
			{
				this.ViewState["ContractedText"] = value;
			}
		}*/
		#endregion

		#region Render Path
		/// <summary>
		/// Overrides <see cref="Control.CreateChildControls"/>.
		/// </summary>
		protected override void CreateChildControls() 
		{
			base.CreateChildControls ();
	
			button = new System.Web.UI.WebControls.CheckBox();
			
			//this.button.AutoPostBack = true;
			//button.CausesValidation = false;
			//button.Click += new EventHandler( this.button_Click );
			
			button.ID = "clicker";
			button.CheckedChanged += new EventHandler(this.CheckedChanged);  
			
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
		protected override void OnPreRender(EventArgs e) 
		{
			base.OnPreRender (e);
			
			if ( this.EnableClientScript ) 
			{
				this.RegisterClientScript();
				this.tracker.Visible = true;
			} 
			else 
			{
				this.tracker.Visible = false;
			}
			this.ApplyExpansionState();
		}

		/// <summary>
		/// Overrides <see cref="Control.Render"/>
		/// </summary>
		protected override void Render(HtmlTextWriter writer) 
		{
			this.EnsureChildControls();
			if ( this.Expanded ) 
			{
				this.button.Checked = true;
			} 
			else 
			{
				this.button.Checked =false;;
			}
			base.Render (writer);
		}


		/// <summary>
		/// Overrides <see cref="WebControl.RenderContents"/>.
		/// </summary>
		protected override void RenderContents(HtmlTextWriter writer) 
		{
			this.RenderChildren(writer);
		}

		#endregion

		/// <summary>
		/// Overrides <see cref="Control.Controls"/>.
		/// </summary>
		public override ControlCollection Controls 
		{
			get 
			{
				this.EnsureChildControls();
				return base.Controls;
			}
		}


		/// <summary>
		/// Applies the <see cref="Expanded"/> value to the server control set by <see cref="ControlToToggle"/>.
		/// </summary>
		protected virtual void ApplyExpansionState() 
		{
			this.tracker.Value = this.Expanded.ToString();

			if ( this.EnableClientScript ) 
			{
				if ( this.Expanded ) 
				{
					if ( this.targetStyle["display"] != null ) 
					{
						this.targetStyle.Remove("display");
					}
				} 
				else 
				{
					this.targetStyle["display"] = "none";
				}
			} 
			else 
			{
				this.targetControl.Visible = this.Expanded;
			}
		}

		/// <summary>
		/// when clientside rendering is enabled, this will alert the control to clientside changes in the Expanded state.
		/// </summary>
		private void ClientExpanedStateChanged( Object sender, EventArgs e ) 
		{
			try 
			{
				Boolean clientExpanedValue = Boolean.Parse( tracker.Value );
				this.Expanded = clientExpanedValue;
			} 
			catch {}
		}

		/// <summary>
		/// If the button is clicked serverside, that means the clientscript didnt' run.
		/// toggle the expansion now.
		/// </summary>
		protected void CheckedChanged(Object sender, EventArgs e) 
		{
			this.Expanded = !this.Expanded;
		}

		/// <summary>
		/// Registers the clientscript with the page.
		/// </summary>
		protected virtual void RegisterClientScript() 
		{
			ExpandingButtonScriptUtil.RegisterScriptForControl(this.button ,this.targetControl,this.tracker,"true", "false");
		}


		private Control targetControl 
		{
			get 
			{
				if ( cachedTargetControl == null ) 
				{
					this.cachedTargetControl = this.NamingContainer.FindControl(this.ControlToToggle);
				}
				return this.cachedTargetControl;
			}
		}
		private Control cachedTargetControl = null;

		private System.Web.UI.CssStyleCollection targetStyle 
		{
			get 
			{
				WebControl targetWebControl = this.targetControl as WebControl;
				if ( targetWebControl != null ) 
				{
					return targetWebControl.Style;
				}
				System.Web.UI.HtmlControls.HtmlControl targetHtmlControl = this.targetControl as System.Web.UI.HtmlControls.HtmlControl;
				if ( targetWebControl != null ) 
				{
					return targetHtmlControl.Style;
				}
				return null;
			}
		}

		private System.Web.UI.HtmlControls.HtmlInputHidden tracker;
		private System.Web.UI.WebControls.CheckBox button;
	}
}
