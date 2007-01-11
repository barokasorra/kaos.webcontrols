using System;
using System.Resources;
using System.Web.UI;

namespace KAOS.WebControls {
	
	/// <summary>
	/// The utility class which deals with the clientscript used by the ExpandingButton controls.
	/// </summary>
	/// <remarks>
	/// This class is not neccessary for use of the controls.
	/// It is public in case a developer wants to create their own expanding button that does not derive from the built in ones.
	/// </remarks>
	public class ExpandingButtonScriptUtil {
		
		/// <summary>
		/// Does the actual regististration of the script with the page.
		/// </summary>
		/// <param name="expander">The control to be registered as an expanding button.</param>
		/// <param name="target">The control to be targeted by the button.</param>
		/// <param name="tracker">The control which tracks, on the clientside, the state of the target control.</param>
		/// <param name="expandedValue">The value of the control in its expanded state.</param>
		/// <param name="contractedValue">The value of the control in its contracted state.</param>
		public static void RegisterScriptForControl(Control expander, Control target, Control tracker, String expandedValue, String contractedValue ) {
			if ( expander.Page == null ) {
				return;
			}

			String type = "u";
			if ( expander is System.Web.UI.WebControls.Button ) 
			{
				type = "b";
			} 
			else if ( expander is System.Web.UI.WebControls.LinkButton ) 
			{
				type = "l";
			} 
			else if ( expander is System.Web.UI.WebControls.ImageButton ) 
			{
				type = "i";
			} 
			else if ( expander is System.Web.UI.WebControls.CheckBox ) 
			{
				type = "c";
			}

			String exValue = expandedValue;
			String ctValue = contractedValue;
			if ( exValue != String.Empty && ctValue == String.Empty ) {
				ctValue = exValue;
			} else if ( ctValue != String.Empty && exValue == String.Empty ) {
				exValue = ctValue;
			}

			System.Web.UI.Page thePage = expander.Page;

			String trackerID = "";
			if ( tracker != null ) {
				trackerID = tracker.ClientID;
			}

			if ( !thePage.IsClientScriptBlockRegistered(scriptKey) ) {
				thePage.RegisterClientScriptBlock(scriptKey,libraryScript);
			}
			thePage.RegisterStartupScript(scriptKey,startupScript);
			thePage.RegisterArrayDeclaration(arrayName, "'" + expander.ClientID + "','" + target.ClientID + "','" + trackerID + "','" + System.Web.HttpUtility.HtmlEncode(exValue) + "','" + System.Web.HttpUtility.HtmlEncode(ctValue) + "','" + type +  "'");
		}

		private static String scriptKey = typeof(ExpandingButtonScriptUtil).FullName;
		private static String arrayName = "MetaBuilders_WebControls_ExpandingButtons";
		
		private static String libraryScript {
			get {
				using (System.IO.StreamReader reader = new System.IO.StreamReader(typeof(ExpandingButtonScriptUtil).Assembly.GetManifestResourceStream(typeof(ExpandingButtonScriptUtil), "ExpandingButtonScriptUtil.js"))) { 
						return "<script language='javascript' type='text/javascript' >\r\n<!--\r\n" + reader.ReadToEnd() + "\r\n//-->\r\n</script>";
				}
			}
		}

		private static String startupScript {
			get {
				return @"
<script language='javascript' type='text/javascript' >
<!--
	ExpandingButtons_Init();
// -->
</script>";
			}
		}
	}
}
