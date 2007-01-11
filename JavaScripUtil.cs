using System;
using System.Resources;
using System.Web.UI; 

namespace KAOS.WebControls
{
	public class JavaScriptUtil 
	{
		
		//private static String scriptKey = typeof(JavaScriptUtil).FullName;
 		
		private static String LibraryScript(String NomeJs)
		{
			using(System.IO.StreamReader reader = new System.IO.StreamReader(typeof(JavaScriptUtil).Assembly.GetManifestResourceStream(typeof(JavaScriptUtil),NomeJs)))
			{   
				return "<script language='javascript' type='text/javascript' >\r\n<!--\r\n" + reader.ReadToEnd() + "\r\n//-->\r\n</script>";
			}
		}

		
		#region OnlyData
		private static String DataStartupScript 
		{
			get 
			{
				return	@"return DataUtil(this,'##/##/#####',event);";
			}
		}

		public static void RegisterDataScriptForControl(System.Web.UI.WebControls.TextBox editbox)
		{
			String scriptKey = "data";
			System.Web.UI.Page thePage = editbox.Page;
			if ( !thePage.IsClientScriptBlockRegistered(scriptKey) ) 
			{
				thePage.RegisterClientScriptBlock(scriptKey,LibraryScript("EditDate.js"));
			}
			editbox.Attributes.Add("onkeypress",DataStartupScript);
		}
#endregion

		#region OnlyMoney
		//private static String MoneyStartupScript()
		//private static String MoneyStartupScript(String dp)
		//{
			//return @"return(MoneyUtil(this," + dp + ",event));";
			//return @"return Formata(this,20,event,2);";
		//}

		//public static void RegisterMoneyScriptForControl(System.Web.UI.WebControls.TextBox editbox,String dp) {
		public static void RegisterMoneyScriptForControl(System.Web.UI.WebControls.TextBox editbox) {
			String scriptKey = "money";
			System.Web.UI.Page thePage = editbox.Page;
			if (!thePage.IsClientScriptBlockRegistered(scriptKey)) {
				thePage.RegisterClientScriptBlock(scriptKey,LibraryScript("EditMoney.js"));
			} 
			editbox.Attributes.Add("onkeypress","return HandleAmountFiltering(this);");
			editbox.Attributes.Add("onBlur","FormatAmtControl(this);");
			//editbox.Attributes.Add("onkeypress",MoneyStartupScript());
			//editbox.Attributes.Add("onkeypress",MoneyStartupScript(dp));  
		}
		#endregion

		#region OnlyNumbers and Variations
		private static String NumberStartupScript(String regexp) 
		{
			return @"return NumberUtil(event,"+regexp+");";
		}

		public static void RegisterNumberScriptForControl(System.Web.UI.WebControls.TextBox editbox, String regexp) {
			String scriptKey = "numero";
			System.Web.UI.Page thePage = editbox.Page;
			if (!thePage.IsClientScriptBlockRegistered(scriptKey))
			{
				thePage.RegisterClientScriptBlock(scriptKey,LibraryScript("EditNumber.js")); 
			}
			editbox.Attributes.Add("onkeypress",NumberStartupScript(regexp));  
		}
		#endregion

		#region OnlyEditMasked
		private static string MaskedStartupScript(String mask) {
			return @"return MaskInput(this,'"+ mask +"',event);";
		}

		public static void RegisterMaskScriptForControl(System.Web.UI.WebControls.TextBox editbox, String mask) 
		{
			String scriptKey = "mask";
			System.Web.UI.Page thePage = editbox.Page;
			if (!thePage.IsClientScriptBlockRegistered(scriptKey))
			{
				thePage.RegisterClientScriptBlock(scriptKey,LibraryScript("EditMask.js")); 
			}
			editbox.Attributes.Add("onkeypress",MaskedStartupScript(mask));  
		}
		#endregion

		#region OnlyControlDivs
		public static string RegisterItemControlDivsScriptForControl(string condition, string type) {
			return @"Hide(this,'" + condition + "','" + type + "','')";
		}

		public static string RegisterItemControlDivsScriptForControl(string condition, string type,string condradio) 
		{
			return @"Hide(this,'" + condition + "','" + type + "','" + condradio + "')";
		}

		public static void RegisterItemControlDivsForPage (System.Web.UI.Page thePage){			
			if (!thePage.IsClientScriptBlockRegistered("divscontrol")) {
				thePage.RegisterClientScriptBlock("divscontrol",LibraryScript("ExpandingDivs.js"));
			}
		}
		#endregion
	}
}
