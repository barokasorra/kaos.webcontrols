using System ;
using System.Globalization ;

namespace KAOS.WebControls
{
	/// <summary>
	/// Summary description for RichEditDesign.
	/// </summary>
	public class RichEditDesign : System.Web.UI.Design.ControlDesigner 
	{
		public RichEditDesign() {
		
		}

		public override string GetDesignTimeHtml() {
			RichEdit oControl = (RichEdit)Component;
			return String.Format( CultureInfo.InvariantCulture,
				"<div><table width=\"{0}\" height=\"{1}\" bgcolor=\"#f5f5f5\" bordercolor=\"#c7c7c7\" cellpadding=\"0\" cellspacing=\"0\" border=\"1\"><tr><td valign=\"middle\" align=\"center\">RichEdit - <b>{2}</b></td></tr></table></div>",
				oControl.Width,
				oControl.Height,
				oControl.ID ) ;
		}
	}
}
