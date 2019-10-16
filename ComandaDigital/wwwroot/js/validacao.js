/*  -----validarForm-----
	Tipos de data-validacao:
		inputObrigatoria, dataObrigatoria, emailObrigatorio
		cpfObrigatorio, cnpjObrigatorio, selectObrigatorio

*/
function validarForm(idForm) {
    var formulario = document.getElementById(idForm);
    var formValido = true;
    var mensagem = "";

    for (var i = 0; i < formulario.elements.length; i++) {
        var elemento = formulario.elements[i];
        if (elemento.getAttribute("data-validacao") != null && elemento.getAttribute("data-validacao") != "naoObrigatorio") {
            var dataValidacao = elemento.getAttribute("data-validacao").split('|');
        } else {
            var dataValidacao = "naoobrigatorio|xxx".split('|');
        }
        switch (dataValidacao[0]) {
            case "selectObrigatorio":
                if (elemento.disabled != true) {
                    if (elemento.selectedIndex == 0) {
                        mensagem = mensagem + "<label>Selecione um valor para o campo <b>" + dataValidacao[1] + "</b>.</label><br />";
                        formValido = false;
                    }
                }
                break;
            case "selectObrigatorioTag":
                var tags = $('#' + dataValidacao[2]).find('option:selected');
                if (tags.length == 0) {
                    mensagem = mensagem + "<label>Selecione no mínimo um <strong>" + dataValidacao[1] + "</strong>.</label><br />";
                    formValido = false;
                }
                break;
        case "inputObrigatoria":
            if (elemento.disabled != true) {
                if (elemento.value == "") {
                    mensagem = mensagem + "<label>O campo <strong>" + dataValidacao[1] + "</strong> é obrigatório.</label><br />";
                    formValido = false;
                }
            }
            break;
        case "dataObrigatoria":
            if (elemento.value == "") {
                mensagem = mensagem + "<label>O campo <strong>" + dataValidacao[1] + "</strong> é obrigatório.</label><br />";
                formValido = false;
            } else {
                if (!validarData(elemento.value)) {
                    mensagem = mensagem + "<label>O campo <strong>" + dataValidacao[1] + "</strong> deve ser preenchido com uma data válida.</label><br />";
                    formValido = false;
                }
            }
            break;
        case "emailObrigatorio":
            if (elemento.value == "") {
                mensagem = mensagem + "<label>O campo <strong>" + dataValidacao[1] + "</strong> é obrigatório.</label><br />";
                formValido = false;
            } else {
                if (!validarEmail(elemento.value)) {
                    mensagem = mensagem + "<label>O campo <strong>" + dataValidacao[1] + "</strong> deve ser preenchido com um E-Mail válido.</label><br />";
                    formValido = false;
                }
            }
            break;
        case "cpfObrigatorio":
            if (elemento.disabled != true) {
                if (elemento.value == "") {
                    mensagem = mensagem + "<label>O campo <strong>" + dataValidacao[1] + "</strong> é obrigatório.</label><br />";
                    formValido = false;
                } else {
                    if (!validarCpf(elemento.value)) {
                        mensagem = mensagem + "<label>O campo <strong>" + dataValidacao[1] + "</strong> deve ser preenchido com um CPF válido.</label><br />";
                        formValido = false;
                    }
                }
            }
            break;
        case "cnpjObrigatorio":
            if (elemento.disabled != true) {
                if (elemento.value == "") {
                    mensagem = mensagem + "<label>O campo <strong>" + dataValidacao[1] + "</strong> é obrigatório.</label><br />";
                    formValido = false;
                } else {
                    if (!validarCNPJ(elemento.value)) {
                        mensagem = mensagem + "<label>O campo <strong>" + dataValidacao[1] + "</strong> deve ser preenchido com um CNPJ válido.</label><br />";
                        formValido = false;
                    }
                }
            }
            break;
        case "senhaUsuario":
                if (elemento.disabled != true) {
                    var senha = elemento.value;
                    var confirmacaoDeSenha = $("#confirmacaoSenha").val();

                    if (!validarSenha(senha, confirmacaoDeSenha)) {
                        mensagem = mensagem + "<label>O campo <strong>Senha</strong> deve ser igual ao campo <strong>Confirmação Senha</strong>.</label><br />";
                        formValido = false;
                    }
            }
            break;
        }
    }

    if (formValido)
        formulario.submit();
    else
    {
        $("#mensagensDeFalha").html(mensagem);
        $("#modalValidation").modal();
    }
}
function validarSenha(senha, confirmacaoDeSenha) {
    if (senha == confirmacaoDeSenha)
        return true;

    return false;
}
function validarEmail(email) {
	var er = /^[a-zA-Z0-9][a-zA-Z0-9\._-]+@([a-zA-Z0-9\._-]+\.)[a-zA-Z-0-9]{2}/;
	if (!er.exec(email)){
		return false;
	}
	return true;
}
function validarCpf(cpf) {
	cpf = cpf.replace(".","").replace(".","").replace("-","");
	var numeros, digitos, soma, i, resultado, digitos_iguais;
	digitos_iguais = 1;
	if (cpf.length < 11)
		return false;
	for (i = 0; i < cpf.length - 1; i++) {
		if (cpf.charAt(i) != cpf.charAt(i + 1)) {
			digitos_iguais = 0;
			break;
		}
	}
	if (!digitos_iguais) {
		numeros = cpf.substring(0, 9);
		digitos = cpf.substring(9);
		soma = 0;
		for (i = 10; i > 1; i--) {
			soma += numeros.charAt(10 - i) * i;
		}
		resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
		if (resultado != digitos.charAt(0)) {
			return false;
		}
		numeros = cpf.substring(0, 10);
		soma = 0;
		for (i = 11; i > 1; i--) {
			soma += numeros.charAt(11 - i) * i;
		}
		resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
		if (resultado != digitos.charAt(1)) {
			return false;
		}
		return true;
	}
	else {
		return false;
	}
}
function validarCNPJ(cnpj) {
	var i = 0;
	var l = 0;
	var strNum = "";
	var strMul = "6543298765432";
	var character = "";
	var iValido = 1;
	var iSoma = 0;
	var strNum_base = "";
	var iLenNum_base = 0;
	var iLenMul = 0;
	var iSoma = 0;
	var strNum_base = 0;
	var iLenNum_base = 0;

	if (cnpj == "")
		return false;
	cnpj = cnpj.replace(".","").replace(".","").replace("/","").replace("-","");
	l = cnpj.length;
	for (i = 0; i < l; i++) {
		caracter = cnpj.substring(i, i + 1)
		if ((caracter >= '0') && (caracter <= '9'))
			strNum = strNum + caracter;
	};

	if (strNum.length != 14)
		return false;

	strNum_base = strNum.substring(0, 12);
	iLenNum_base = strNum_base.length - 1;
	iLenMul = strMul.length - 1;
	for (i = 0; i < 12; i++)
		iSoma = iSoma +
						parseInt(strNum_base.substring((iLenNum_base - i), (iLenNum_base - i) + 1), 10) *
						parseInt(strMul.substring((iLenMul - i), (iLenMul - i) + 1), 10);

	iSoma = 11 - (iSoma - Math.floor(iSoma / 11) * 11);
	if (iSoma == 11 || iSoma == 10)
		iSoma = 0;

	strNum_base = strNum_base + iSoma;
	iSoma = 0;
	iLenNum_base = strNum_base.length - 1
	for (i = 0; i < 13; i++)
		iSoma = iSoma +
						parseInt(strNum_base.substring((iLenNum_base - i), (iLenNum_base - i) + 1), 10) *
						parseInt(strMul.substring((iLenMul - i), (iLenMul - i) + 1), 10)

	iSoma = 11 - (iSoma - Math.floor(iSoma / 11) * 11);
	if (iSoma == 11 || iSoma == 10)
		iSoma = 0;
	strNum_base = strNum_base + iSoma;
	if (strNum != strNum_base)
		return false;

	return (true);
}
function validarData(dataString){
		var dataArray = dataString.split("/");
		var dia = parseInt(dataArray[0]);
		var mes = parseInt(dataArray[1])-1;
		var ano = parseInt(dataArray[2]);
		var dataReferencia = new Date(ano, mes, dia);

		if((dataReferencia.getDate() != dia) || (dataReferencia.getMonth() != mes) || (dataReferencia.getFullYear() != ano)){
			return false;
		}
		return true;
}

function updateComboCidades(url) {
    url = url + "/" + $("#estados option:selected").val();

    $.ajax({
        type: 'GET',
        url: url,
        contentType: "application/json",
        success: function (json) {
            $('#cidades').empty();
            $("#cidades").append($("<option></option>")); 
            $.each(json.cidades, function (idx, cidade) {
                $("#cidades").append($("<option value='" + cidade.id + "'>" + cidade.nome + "</option>")); 
            });
        },
        error: function (e) {
            console.log(e.message);
        }
    });
}