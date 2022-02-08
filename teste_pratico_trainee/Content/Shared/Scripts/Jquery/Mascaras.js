$(document).ready(() => {
    Mascaras.init();
})

let Mascaras = {
    telefone: {
        init: (seletor) => { $(seletor ?? ".telefone").unmask().mask("(00) 90000-0000") }
    },
    cep: {
        init: (seletor) => { $(seletor ?? ".cep").unmask().mask("00.000-000") }
    },
    cpf: {
        init: (seletor) => { $(seletor ?? ".cpf").unmask().mask("000.000.000.00") }
    },
    rg: {
        init: (seletor) => { $(seletor ?? ".rg").unmask().mask("AA-99.999.999") }
    },
    numero: {
        init: (seletor) => { $(seletor ?? ".numero").unmask().mask("0#") }
    },
    dinheiro: {
        init: (seletor) => { $(seletor ?? ".dinheiro").unmask().mask("#.##0,00", {reverse: true}) }
    },
    datetimePicker: {
        init: (seletor, config) => {
            let obj = {
                "singleDatePicker": true,
                "timePicker": true,
                "timePicker24Hour": true,
                "timePickerIncrement": 1,
                "drops": "auto",
                "locale": {
                    "format": "DD/MM/YYYY hh:mm",
                    "separator": " - ",
                    "applyLabel": "Aplicar",
                    "cancelLabel": "Cancelar",
                    "fromLabel": "De",
                    "toLabel": "Até",
                    "customRangeLabel": "Personalizado",
                    "weekLabel": "W",
                    "daysOfWeek": [
                        "Dom",
                        "Seg",
                        "Ter",
                        "Qua",
                        "Qui",
                        "Sex",
                        "Sab",
                    ],
                    "monthNames": [
                        "Janeiro",
                        "Fevereiro",
                        "Março",
                        "Abril",
                        "Maio",
                        "Junho",
                        "Julho",
                        "Agosto",
                        "Setembro",
                        "Outubro",
                        "Novembro",
                        "Dezembro"
                    ]
                }
            }
            if (config) obj = { ...obj, ...config };
            $(seletor ?? '.datetimePicker').daterangepicker(obj);
        }
    },
    datetimeFormat: {
        init: (seletor) => {
            let el = $(seletor ?? '.datetimeFormat')
            el.html(moment(el.html()).format("dddd, DD/MMM/YYYY [às] HH:mm"));
        }
    },
    datePicker: {
        init: (seletor, config) => {
            let obj = {
                "singleDatePicker": true,
                "drops": "auto",
                "locale": {
                    "format": "DD/MM/YYYY",
                    "separator": " - ",
                    "applyLabel": "Aplicar",
                    "cancelLabel": "Cancelar",
                    "fromLabel": "De",
                    "toLabel": "Até",
                    "customRangeLabel": "Personalizado",
                    "weekLabel": "W",
                    "daysOfWeek": [
                        "Dom",
                        "Seg",
                        "Ter",
                        "Qua",
                        "Qui",
                        "Sex",
                        "Sab",
                    ],
                    "monthNames": [
                        "Janeiro",
                        "Fevereiro",
                        "Março",
                        "Abril",
                        "Maio",
                        "Junho",
                        "Julho",
                        "Agosto",
                        "Setembro",
                        "Outubro",
                        "Novembro",
                        "Dezembro"
                    ]
                }
            }
            if (config) obj = { ...obj, ...config };
            $(seletor ?? '.datePicker').daterangepicker(obj);
        }
    },
    dateFormat: {
        init: (seletor) => {
            let el = $(seletor ?? '.dateFormat')
            el.html(moment(el.html()).format("dddd, DD/MMM/YYYY"));
        }
    },
    reset: {
        init: (seletor) => { $(seletor ?? ".reset").unmask() }
    },

    init: () => {
        Mascaras.telefone.init();
        Mascaras.cep.init();
        Mascaras.cpf.init();
        Mascaras.rg.init();
        Mascaras.numero.init();
        Mascaras.dinheiro.init();
        Mascaras.datetimePicker.init();
        Mascaras.datetimeFormat.init();
        Mascaras.datePicker.init();
        Mascaras.dateFormat.init();
    }
}
