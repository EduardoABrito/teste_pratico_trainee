$(document).ready(() => {
    Endereco_listar()
    getCep()
})

$("#cliente_editar").submit(function (e) {
    e.preventDefault()
    let Cliente = {
        Id: $(`#id`).val(),
        Nome: $(`input[name="nome"]`).val(),
        Sexo: $(`#sexo`).val(),
        DataNascimento: $(`input[name="dt_nascimento"]`).val(),
        EstadoCivil: $(`#estado_civil`).val(),
        CPF: $(`input[name="cpf"]`).cleanVal(),
        RG: $(`input[name="rg"]`).cleanVal(),
    }
    $.post({
        url: "/Cliente/Cliente_Editar",
        data:  Cliente,
        success: () => {
            Swal.fire({
                icon: "success",
                title: "Atualizado Com sucesso",
                timer: 2000,
                toast: true,
                position: "top-end",
                showConfirmButton: false,
                timerProgressBar: true,
            }).then(() => {
                location.reload()
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

function editar() {
    $(".btn-editar").on("click", function (e) {
        e.preventDefault()
        $.post({
            url: "/Endereco/Endereco_Listar_id",
            data: { id: $(this).val() },
            success: ({ Endereco }) => {
                $("#cadastrar_endereco").hide()
                $(".endereco-table").hide()
                $(".endereco").show()
                $("#id_endereco").val(Endereco.Id)
                $("#cep").val(Endereco.CEP)
                $("#logradouro").val(Endereco.Logradouro)
                $("#numero").val(Endereco.Numero)
                $("#bairro").val(Endereco.Bairro)
                $("#cidade").val(Endereco.Cidade)
                $("#uf").val(Endereco.UF)
                $(`#tipo_id option[value=${Endereco.Id_tipo}]`).attr('selected', 'selected');
                $("#complemento").val(Endereco.Complemento)
            }
        })

    })
}

function Endereco_listar() {

    $.post("/Endereco/Endereco_Listar_ClienteId", { Cliente_id : $("#id").val() } , ({ Enderecos }) =>
    {
        $("#datatable").html('')
        Enderecos.forEach(v => {
            let template_Enderecos = $($("#template_Enderecos").html());

            template_Enderecos.find(".table-id").html(v.Id)
            template_Enderecos.find(".table-logradouro").html(v.Logradouro)
            template_Enderecos.find(".table-numero").html(v.Numero)
            template_Enderecos.find(".table-bairro").html(v.Bairro)
            template_Enderecos.find(".table-complemento").html(v.Complemento)
            template_Enderecos.find(".table-cidade").html(v.Cidade)
            template_Enderecos.find(".table-uf").html(v.UF)
            template_Enderecos.find(".table-cep").html(v.CEP)
            template_Enderecos.find(".btn-editar").attr("value", `${v.Id}`)
            template_Enderecos.find(".btn-deletar").attr("value", `${v.Id}`)

            $("#datatable").append(template_Enderecos)
        })
        editar()
        Deletar_enderecos()
    })
}

function voltar() {
    $("#id_endereco").val("")
    $("#cep").val("")
    $("#logradouro").val("")
    $("#numero").val("")
    $("#bairro").val("")
    $("#cidade").val("")
    $("#uf").val("")
    $(`#tipo_id option`).removeAttr('selected', 'selected');
    $("#complemento").val("")
    $(".endereco").hide()
    $(".endereco-table").show()
    $("#cadastrar_endereco").show()

}

$("#voltar").on("click", function (e) {
    e.preventDefault()
    voltar()
})

$("#form_endereco").submit(function (e) {
    e.preventDefault()
    let Cliente = {
        id: $("#id").val()
    }
    let Endereco = {
        Id:$("#id_endereco").val(),
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
        url: "/Endereco/Endereco_Editar_id",
        data: { Endereco, Cliente },
        success: () => {
            Endereco_listar()
            voltar()
            Swal.fire({
                icon: "success",
                title: "Salvo Com sucesso",
                timer: 2000,
                toast: true,
                position: "top-end",
                showConfirmButton: false,
                timerProgressBar: true,
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

$("#cadastrar_endereco").on("click", function (e) {
    e.preventDefault()
    $(this).hide()
    $(".endereco-table").hide()
    $(".endereco").show()
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

function Deletar_enderecos() {
    $(".btn-deletar").on("click", function (e) {
        e.preventDefault()
        let Endereco = {
            Id: $(this).val()
        }
        Swal.fire({
            title: 'Deseja Deletar Esse Endereco?',
            showDenyButton: true,
            confirmButtonText: 'Deletar',
            denyButtonText: `Cancelar`,
        }).then((result) => {
            if (result.isConfirmed) {
                $.post({
                    url: "/Endereco/Endereco_Deletar",
                    data: Endereco,
                    success: () => {
                        Endereco_listar()
                        Swal.fire({
                            icon: "success",
                            title: "Deletado Com Sucesso",
                            timer: 2000,
                            timerProgressBar: true,
                            toast: true,
                            position: "top-end",
                            showConfirmButton: false,
                        })
                    }
                })
            }
        })
    })
}