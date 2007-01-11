function NumberUtil(e,regexp)
{
	var key;
	var keychar;
	var reg;
	
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

	keychar = String.fromCharCode(key);
	reg = regexp;
	//reg = /\D/;
	return reg.test(keychar);
}