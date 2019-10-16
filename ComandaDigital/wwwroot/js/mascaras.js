/*  -----mascara-----
		Tipos de mascaras:
			maskSoNumeros, maskTelefone, maskCpf
			maskCep, maskCnpj, maskMoeda, maskData
		Exemplo: <input onkeypress="mascara(this,maskTelefone)" maxlength="14" />
*/
function mascara(o,f) {
    v_obj = o;
    v_fun = f;
    setTimeout("execmascara()", 1);
}

function execmascara() {
    v_obj.value = v_fun(v_obj.value);
}

function maskSoNumeros(v){
    return v.replace(/\D/g,"");
}
function maskData(v) {
	v=v.replace(/\D/g,"");
	v=v.replace(/^(\d{2})(\d)/,"$1/$2");
	v=v.replace(/(\d{2})(\d)/,"$1/$2");
	return v;
}
function maskTelefone(v) {
    v=v.replace(/\D/g,"");
    v=v.replace(/^(\d\d)(\d)/g,"($1) $2");
    v=v.replace(/(\d{4})(\d)/,"$1-$2");
    return v;
}

function maskCpf(v) {
    v=v.replace(/\D/g,"");
    v=v.replace(/(\d{3})(\d)/,"$1.$2");
    v=v.replace(/(\d{3})(\d)/,"$1.$2");
    v=v.replace(/(\d{3})(\d{1,2})$/,"$1-$2");
    return v;
}

function maskCep(v) {
    v=v.replace(/D/g,"");
    v=v.replace(/^(\d{5})(\d)/,"$1-$2");
    return v;
}

function maskCnpj(v) {
    v=v.replace(/\D/g,"");
    v=v.replace(/^(\d{2})(\d)/,"$1.$2");
    v=v.replace(/^(\d{2})\.(\d{3})(\d)/,"$1.$2.$3");
    v=v.replace(/\.(\d{3})(\d)/,".$1/$2");
    v=v.replace(/(\d{4})(\d)/,"$1-$2");
    return v;
}
function maskMoeda(v) {
    v = v.replace(/\D/g, ""); //Remove tudo o que não é dígito	
    v = v.replace(/(\d+)(\d{2})/, "$1,$2"); //Insere a vĂ­rgula	
   // v=v.replace(/^(0+)(\d)/g,"$2"); //remove "0" Ă  esquerda
    return v;
}