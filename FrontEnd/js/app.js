
var Send = function(){

		var  jsonData = {
						"name":$('#nome').val(),
						"email":$('#email').val(),
						"phone":$('#fone').val(),
						"state":$('#estado').val(),
						"city":$('#cidade').val(),
						"text":$('#msg').val(),
						};

		var formData = new 	FormData();
		

		var files = $("#file").get(0).files;
		formData.append('files', files[0]);
		formData.append('curriculos', JSON.stringify(jsonData));
	
		$.ajax({
			url:'http://localhost:51124/api/curriculo',
			type:"POST",
			data: formData,
			contentType: false,
			processData: false,
			success: function(){
				swal("Parabens!", "Seu curriculo foi entregue e será avaliado!", "success");
				$('#form').trigger("reset");
				return false;
			},
			error: function(){
                swal("Atenção", "Erro inesperado", "error");
				return false;
			}
		});
	return false;
}

//$("#btnPostFile").on('click',Send);

