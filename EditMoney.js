//Author:V.V.Perumal Babu
//Date:Feb 18 2005
var theform;
var isIE;
var isNS;

function detectBrowser()
{
	if (window.navigator.appName.toLowerCase().indexOf("netscape") > -1) 
		theform = document.forms["Form1"];
	else 
		theform = document.Form1;
		
	var strUserAgent = navigator.userAgent.toLowerCase();
	isIE = strUserAgent.indexOf("msie") > -1;
	isNS = strUserAgent.indexOf("netscape") > -1;
	
}

function FormatAmtControl(ctl){
	var vMask ;
	var vDecimalAfterPeriod ;
	var ctlVal;
	var iPeriodPos;
	var sTemp;
	var iMaxLen 
	var ctlVal;
	var tempVal;
	ctlVal = ctl.value;
	vDecimalAfterPeriod  = 2
	iMaxLen  = ctl.maxLength;

		if (ctlVal.length != 0) {
		ctlVal =  ctl.value;
		iPeriodPos =ctlVal.indexOf(",");
		if (iPeriodPos<0)
		{
			if (ctl.value.length > (iMaxLen-3))
			{
				sTemp = ctl.value
				 tempVal = sTemp.substr(0,(iMaxLen-3)) + ",00";
			}
			else
			tempVal = ctlVal + ",00"
		}
		else{
			if ((ctlVal.length - iPeriodPos -1)==1)
				tempVal = ctlVal + "0"
			if ((ctlVal.length - iPeriodPos -1)==0)
				tempVal = ctlVal + "00"
			if ((ctlVal.length - iPeriodPos -1)==2)
				tempVal = ctlVal;
			if ((ctlVal.length - iPeriodPos -1)>2){
				tempVal = ctlVal.substring(0,iPeriodPos+3);
			}
		}

	ctl.value=tempVal;
	
	var sTemp = ctl.value;

	if (sTemp.indexOf('.')==-1) {
	if (sTemp.length >= 7 && sTemp.length <= 9 ) {
	ctl.value = sTemp.substring(0,sTemp.length-6)+"."+sTemp.substring(sTemp.length-6,sTemp.length);	
	}
	else if(sTemp.length > 9 && sTemp.length <= 12) {
	ctl.value = sTemp.substring(0,sTemp.length-9)+"."+sTemp.substring(sTemp.length-9,sTemp.length-6)+"."+sTemp.substring(sTemp.length-6,sTemp.length);
	} 
	}
	}
}

function HandleAmountFiltering(ctl){
	var iKeyCode, objInput;
	var iMaxLen 
	var reValidChars = /[0-9,]/;
	var strKey;
	var sValue;
	var event = window.event || arguments.callee.caller.arguments[0];
	iMaxLen  = ctl.maxLength;
	sValue = ctl.value;
	detectBrowser();

	if (isIE) {
		iKeyCode = event.keyCode;
			objInput = event.srcElement;
	} else {
		iKeyCode = event.which;
		objInput = event.target;
	}

	strKey = String.fromCharCode(iKeyCode);

	if (reValidChars.test(strKey))
	{
		if(iKeyCode==44)
		{
			if(objInput.value.indexOf(',')!=-1)
				if (isIE)
					event.keyCode= 0;
				 else
				 {
				 	 if(event.which!=0 && event.which!=8)
					return false;
				 }
		}
		else
		{
			if(objInput.value.indexOf(',')==-1)
			{
				
				if (objInput.value.length>=(iMaxLen-3))
				{
					if (isIE)
						event.keyCode= 0;
					 else
					 {
					 	 if(event.which!=0 && event.which!=8)
						return false;
					 }
				}
			}
			if ((objInput.value.length==(iMaxLen-3)) && (objInput.value.indexOf(',')==-1))
			{
				objInput.value = objInput.value +',';
			}
		}
	}
	else{
		if (isIE)
			event.keyCode= 0;
		 else
		 {
		 	 if(event.which!=0 && event.which!=8)
			 return false;
		 }
	}
}
