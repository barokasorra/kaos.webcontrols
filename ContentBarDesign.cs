using System ;
using System.Globalization ;

namespace KAOS.WebControls
{
	/// <summary>
	/// Summary description for RichEditDesign.
	/// </summary>
	public class ContentBarDesign : System.Web.UI.Design.ControlDesigner 
	{
		public ContentBarDesign() 
		{
		
		}

		public override string GetDesignTimeHtml() 
		{
			ContentBar oControl = (ContentBar)Component;
			return String.Format( CultureInfo.InvariantCulture,
				"<div><table width=\"100%\" height=\"15px\" bgcolor=\"#f5f5f5\" bordercolor=\"#c7c7c7\" cellpadding=\"0\" cellspacing=\"0\" border=\"1\"><tr><td valign=\"middle\" align=\"center\">ContentBar - <b>{0}</b></td></tr></table></div>",
				oControl.ID ) ;
		}
	}
}