function validateEmail(email) {
  var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
  return re.test(email);
}

function validate() {
  var email = $("#email").val();
  if (!validateEmail(email)) {
    swal("Erro", "Email invalido!", "error");
  } else if($("#nome").val().trim()  == ""){
      swal("Erro", "Nome em branco!", "error");
  } else if($("#fone").val().trim()  == ""){
      swal("Erro", "Telefone Invalido!", "error");
  } else if($("#cidade").val().trim()  == ""){
      swal("Erro", "Cidade Invalida!", "error");   
  } else if($("#estado").val().trim()  == ""){
      swal("Erro", "Estado Invalido!", "error");
  } else if($("#file").val().trim()  == ""){
      swal("Erro", "Arquivo de curriculo não foi carregado!", "error");
  } else {
      Send();
  }
  return false;
}

$("#btnPostFile").on("click", validate);