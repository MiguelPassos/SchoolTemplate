$(document).ready(function () {
    var phoneMask = function (val, field) {
        return val.replace(/\D/g, '').length === 11 ? '(00) 00000-0000' : '(00) 0000-00009';
    },
    options = {
        onKeyPress: function (val, e, field, options) {
            field.mask(phoneMask.apply({}, arguments), options);
        }
    };

    $('.phone').mask(phoneMask, options);
    $('.cpf').mask('999.999.999-99');
    $('.cnpj').mask('99.999.999/9999-99');
    $('.date').mask('99/99/9999');
    $('.time').mask('99:99:99');
    $('.datetime').mask('99/99/9999 99:99:99');
});