
//Bloco de funções 
function chamadaResultado(CepModel) {

    alert("Chamada automatica");
    document.getElementById('cep').value = (CepModel.cep)

}

function abrirCorreios(valor) {

    var cep = valor.replace(/\D/g, '');

    if (cep != "") {

        var validacep = /^[0-9]{8}$/;

        if (validacep.test(cep)) {

            document.getElementById('cep').value = cep.substring(0, 5)
                + "-"
                + cep.substring(5);

            window.location.href = "/Busca/Buscando/" + cep;
        }
        else
        {
            alert("Insira um cep válido.");
        }
    }
    else
    {
        alert("Insira um CEP.")
    }
}

/*
var cep = valor.replace(/\D/g, '');

if (cep != "") {

    var validacep = /^[0-9]{8}$/;

    if (validacep.test(cep)) {

        document.getElementById('rua').value = "...";
        document.getElementById('bairro').value = "...";
        document.getElementById('cidade').value = "...";
        document.getElementById('uf').value = "...";
        document.getElementById('ibge').value = "...";
        
        //var script = document.createElement('script');
        //script.src = 'https://viacep.com.br/ws/' + cep + '/json/?callback=meu_callback';
        //document.body.appendChild(script);
        
        window.location.href = "/Busca/Buscando/" + cep

    } 
    else
    {
        limpa_formulário_cep();
        alert("Formato de CEP inválido.");
    }
}
else
{
    limpa_formulário_cep();
}
*/

function limpa_formulário_cep() {

    document.getElementById('rua').value = ("");
    document.getElementById('bairro').value = ("");
    document.getElementById('cidade').value = ("");
    document.getElementById('uf').value = ("");
    document.getElementById('cep').value = ("");
}
