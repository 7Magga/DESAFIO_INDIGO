
function mCEP() {

	var cep = document.getElementById('cep')
	if (cep.textContent.length == 5) {
		cep.nodeValue += '-'
	}

}