
$(document).ready(() => {
    getCep();
})

function getCep() {
    $(`input[name="cep"]`).on('blur keyup', function () {
        let cep = $(`input[name="cep"]`).cleanVal()
        if (cep.length == 8) {
            $.getJSON(`https://viacep.com.br/ws/${cep}/json/`, function (data) {
                if (!("erro" in data)) {
                    Object.entries(data).forEach(([k, v]) => $(`input[id$='${k}']`).val(v));
                    $(`input[name="logradouro"]`).val(data.logradouro)
                    $(`input[name="bairro"]`).val(data.bairro)
                    $(`input[name="cidade"]`).val(data.localidade)
                    $(`input[name="uf"]`).val(data.uf)
                }
            })
        }
    })
}

$("#cliente_cadastrar").submit(function (e) {
    e.preventDefault();
    let Cliente = {
        Nome: $(`input[name="nome"]`).val(),
        Sexo: $(`#sexo`).val(),
        DataNascimento: $(`input[name="dt_nascimento"]`).val(),
        EstadoCivil: $(`#estado_civil`).val(),
        CPF: $(`input[name="cpf"]`).cleanVal(),
        RG: $(`input[name="rg"]`).cleanVal(),
    }
    let Endereco = {
        CEP: $(`input[name="cep"]`).cleanVal(),
        Id_tipo: $(`#tipo_id`).val(),
        Logradouro: $(`input[name="logradouro"]`).val(),
        Numero: $(`input[name="numero"]`).val(),
        Bairro: $(`input[name="bairro"]`).val(),
        Cidade: $(`input[name="cidade"]`).val(),
        UF: $(`input[name="uf"]`).val(),
        Complemento: $(`input[name="complemento"]`).val(),

    }
    $.post({
        url: "/Cliente/Cliente_Cadastrar",
        data: { Cliente, Endereco },
        success: () => {
            Swal.fire({
                icon: "success",
                title: "Criado Com sucesso",
                timer: 2000,
                timerProgressBar: true,
                toast: true,
                position: "top-end",
                showConfirmButton: false,
            }).then(() => {
                Swal.fire({
                    title: 'Deseja Cadastrar Outro Cliente?',
                    showDenyButton: true,
                    confirmButtonText: 'Sim',
                    denyButtonText: `Não`,
                }).then((result) => {
                    /* Read more about isConfirmed, isDenied below */
                    if (result.isConfirmed) {
                        location.reload()
                    } else if (result.isDenied) {
                        window.location.href = "/Home/Index";
                    }
                })
            })
        },
        error: () => {
            Swal.fire({
                icon: "error",
                title: "Erro Interno encontrado",
                timer: 2000,
                timerProgressBar: true,
            })
        }
        })
})