function DataUtil(src,mask,e)
{
	var key;
	var keychar;
	var reg;

	var i = src.value.length;
	var str = src.value;
	var saida = mask.substring(0,1);
	var texto = mask.substring(i);
	var temp;
	var pos;
		
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

	if (key == 47) {
		if (i == 0) {return false;} 
		if (str.substring(i-1,i) == '/') {return false;}
		
		if (str.indexOf('/') != -1) {
			pos = str.indexOf('/');
			temp = str.substring(pos+1,i);
				if (temp.indexOf('/') != -1) {return false;}
		}	
	}

	if (texto.substring(0,1) != saida && str.substring(i-1,i) != '/' && key != 47)
  	{
		if (str.substring(1,2) != '/' || i != 5) {
		src.value += texto.substring(0,1);}
  	}

	keychar = String.fromCharCode(key);
	reg = /[0-9/]/;
	
	if ( i < 10) {return reg.test(keychar);}
	else {reg = /\D\d/;return reg.test(keychar);}
}