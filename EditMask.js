function MaskInput(src,mask_original,e)
{
	var key;
	var keychar;
	var reg_num = /[0-9]/;
	var reg_char = /[A-z]/;
	
	var mychar = /@/gi;
	var mask = mask_original.replace(mychar,"#");
	
	var i = src.value.length;
	var saida = mask.substring(0,1);
	var texto = mask.substring(i);
	var maskLength = mask.length;

	var temp = mask_original.charAt(i);

	if(window.event) {
		// for IE, e.keyCode or window.event.keyCode can be used
		key = e.keyCode; 
	}
	else if(e.which) {
		// netscape
		key = e.which; 
	}
	else {
		// no event, so pass through
		return true;
	}

	if (i >= maskLength) return false;

	keychar = String.fromCharCode(key);

	if (temp == "@") {return reg_char.test(keychar);}
	else if (temp == "#") {return reg_num.test(keychar);}
	else if (temp == "X") {return true;}
	else {

	if (texto.substring(0,1) != saida) 
  	{
		src.value += texto.substring(0,1);
  	}
	}		
}