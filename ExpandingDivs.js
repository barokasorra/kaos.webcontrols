function Hide(me,condition,type, condradio)
{
	var i;
	var j;
	var arrayConditionDiv = condition.split(",");
	var conditionControl;
	var tempCondDiv = "";
	var tempCond = "";
	var tempDiv = "";
	var divs = document.getElementsByTagName('div');
 
	for(i=0;i < arrayConditionDiv.length;i++) 
	{	
		tempCondDiv = arrayConditionDiv[i];
		tempCond = tempCondDiv.slice(0,tempCondDiv.indexOf("="));
		tempDiv = tempCondDiv.slice(tempCondDiv.indexOf("=")+1, tempCondDiv.length);
		
		if (type == "combo") 
		{
			conditionControl = me.item(me.selectedIndex).text;
		}
		else if (type == "radio") 
		{
			conditionControl = condradio;			
		}

		if (conditionControl == tempCond)
		{			
			for(j=0;j<divs.length;j++)
			{
				if(divs[j].id.match(tempDiv)) 
				{
					divs[j].style.display="block";
				}
			}	
		}
		else 
		{
			for(j=0;j<divs.length;j++)
			{
				if(divs[j].id.match(tempDiv)) 
				{
					divs[j].style.display="none";
				}
			}
		}	
	}
}