$(document).ready(() => {
    Carregar_clientes()
})

function Carregar_clientes() {
    $.post("/Cliente/Cliente_Listar", ({ Clientes }) => { Imprimi_Datatable(Clientes) })
}

    $("#filtrar").on("click", () => {
        let Cliente = {
            Nome: $("#nome").val(),
            Sexo: $("#sexo").val(),
            EstadoCivil: $("#estado_civil").val(),
            CPF:$("#cpf").cleanVal(),
        }
        $.post("/Cliente/Cliente_Filtro", Cliente , ({ Clientes }) => { Imprimi_Datatable(Clientes) })
    })
    $("#resetar").on("click", () => {
        $("#nome").val(""),
        $("#sexo").val("")
        $("#estado_civil").val("")
        $("#cpf").val(""),
        Carregar_clientes()
    })

function Imprimi_Datatable(values) {
        $("#datatable").html('')
        if (values.length == 0) return swal.fire({ icon: "warning", title:"Nenhum Cliente Encontrado"})
            values.forEach(v => {
            let template_cliente = $($("#template_table").html());
            template_cliente.find(".table-id").html(v.Id)
            template_cliente.find(".table-nome").html(v.Nome)
            template_cliente.find(".table-cpf").html(v.CPF)
            template_cliente.find(".table-rg").html(v.RG)
            template_cliente.find(".btn-editar").attr("href",`/Cliente/Editar/${v.Id}`)
            template_cliente.find(".btn-deletar").attr("href", `${v.Id}`)
            $("#datatable").append(template_cliente)
            })
    Deletar_clientes()
}

function Deletar_clientes() {
    $(".btn-deletar").on("click", function (e) {
        e.preventDefault()
        let Cliente = {
            Id:$(this).attr("href")
        }

        Swal.fire({
            title: 'Deseja Deletar Esse Cliente?',
            showDenyButton: true,
            confirmButtonText: 'Deletar',
            denyButtonText: `Cancelar`,
        }).then((result) => {
            if (result.isConfirmed) {
                $.post({
                    url: "/Cliente/Cliente_Deletar",
                    data: Cliente,
                    success: () => {
                        Carregar_clientes()
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