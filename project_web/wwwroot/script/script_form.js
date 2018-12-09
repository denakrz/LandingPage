// SHOW TOPBUTTON WHEN THE USER SCROLLS DOWN 20PX

window.onscroll = function () { scrollFunction() };

function scrollFunction() {
    if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
        document.getElementById("topButton").style.display = "block";
    } else {
        document.getElementById("topButton").style.display = "none";
    }
}

// SCROLL TO THE TOP 
function topFunction() {
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
}

// VALIDATE

$(document).ready(function () {
    $("#formPostulants").validate({
        rules: {
            name: {
                required: true
            },
            lastname: {
                required: true
            },
            dni: {
                required: true,
                number: true,
            },
            birth: {
                required: true,
                date: true,
            },
            email: {
                required: true,
                email: true
            },
            phoneHome: {
                required: false,
                number: true,
            },
            phoneMobile: {
                required: true,
                number: true,
            },
            github: {
                required: false,
            },
            linkedin: {
                required: false,
            },
            study: {
                required: true
            },
            institution: {
                required: true,
            },
            career: {
                required: true,
            },
            study1: {
                required: true
            },
            english: {
                required: true
            },
            speakEnglish: {
                required: "#engYes:checked",
            },
            writtenEnglish: {
                required: "#engYes:checked",
            },
            listenEnglish: {
                required: "#engYes:checked",
            },
            technologies: {
                required: true
            },
            infoProg: {
                required: true
            },
            other: {
                required: "#ot3:selected",
            },
            intProg: {
                required: true
            },
            converTheme: {
                required: true
            },
            cod: {
                required: true
            },
            pc: {
                required: true
            },
            experience: {
                required: true
            }
        },
        messages: {
            name: {
                required: 'Por favor ingresa tu nombre.',
            },
            lastname: {
                required: 'Por favor ingresa tu apellido.',
            },
            dni: {
                required: 'Por favor ingresa tu DNI',
                number: 'Por favor ingresa un formato válido, números sin espacios ni puntos.'
            },
            birth: {
                required: 'Por favor ingresa tu fecha de nacimiento.',
                min: 'Tu edad debe ser de 18 a 24 años',
                max: 'Tu edad debe ser de 18 a 24 años'
            },
            email: {
                required: 'Por favor ingresa una dirección de email.',
                email: 'Por favor ingresa un email válido.'
            },
            study: {
                required: 'Por favor selecciona una opción.',
            },
            phoneHome: {
                number: 'Por favor ingresa un formato válido.',
            },
            phoneMobile: {
                required: 'Por favor ingresa tu número personal.',
                number: 'Por favor ingresa un formato válido.'
            },
            institution: {
                required: 'Por favor ingresa una institución.',
            },
            career: {
                required: 'Por favor ingresa una carrera.',
            },
            study1: {
                required: 'Por favor selecciona una opción.'
            },
            english: {
                required: 'Por favor selecciona una opción.'
            },
            speakEnglish: {
                required: 'Por favor selecciona un nivel.'
            },
            writtenEnglish: {
                required: 'Por favor selecciona un nivel.'
            },
            listenEnglish: {
                required: 'Por favor selecciona un nivel.'
            },
            technologies: {
                required: 'Por favor contanos qué tecnologías te interesan.'
            },
            infoProg: {
                required: 'Por favor selecciona una opción.'
            },
            other: {
                required: 'Por favor contanos dónde escuchaste del programa.'
            },
            intProg: {
                required: 'Por favor contanos porqué te interesa la programación.'
            },
            converTheme: {
                required: 'Por favor selecciona una opción.'
            },
            cod: {
                required: 'Por favor selecciona una opción.'
            },
            pc: {
                required: 'Por favor selecciona una opción.'
            },
            experience: {
                required: 'Por favor contanos cualquier experiencia que tengas en programación!'
            }
        },

    });
})

//SHOW ENGLISH

function hide() {
    if (document.getElementById("engYes").checked) {
        //document.getElementById("nivels").style.display="";
        $('#nivels').show();
    } else {
        document.getElementById("nivels").style.display = "none";
        $('#nivels').hide();
    }
}

// SHOW OTHER

function hid() {
    if (document.getElementById("ot3").selected) {
        $('#others').show();
    } else {
        document.getElementById("others").style.display = "none";
        $('#others').hide();
    }
}

// AUTOCOMPLETE
$(function () {
    var alreadyFilled = false;
    var states = ['Escuela Da Vinci', 'Instituto Tecnológico de Buenos Aires', 'Universidad Abierta Interamericana', 'Universidad de Belgrano', 'Universidad de Buenos Aires', 'Universidad Nacional de La Matanza', 'Universidad de La Plata', 'Universidad de Lomas de Zamora', 'Universidad Tecnológica Nacional'];

    function initDialog() {
        clearDialog();
        for (var i = 0; i < states.length; i++) {
            $('.dialog').append('<div>' + states[i] + '</div>');
        }
    }

    function clearDialog() {
        $('.dialog').empty();
    }
    $('.autocomplete input').click(function () {
        if (!alreadyFilled) {
            $('.dialog').addClass('open');
        }

    });
    $('body').on('click', '.dialog > div', function () {
        $('.autocomplete input').val($(this).text()).focus();
        $('.autocomplete .close').addClass('visible');
        alreadyFilled = true;
    });
    $('.autocomplete .close').click(function () {
        alreadyFilled = false;
        $('.dialog').addClass('open');
        $('.autocomplete input').val('').focus();
        $(this).removeClass('visible');
    });

    function match(str) {
        str = str.toLowerCase();
        clearDialog();
        for (var i = 0; i < states.length; i++) {
            if (states[i].toLowerCase().startsWith(str)) {
                $('.dialog').append('<div>' + states[i] + '</div>');
            }
        }
    }
    $('.autocomplete input').on('input', function () {
        $('.dialog').addClass('open');
        alreadyFilled = false;
        match($(this).val());
    });
    $('body').click(function (e) {
        if (!$(e.target).is("input, .close")) {
            $('.dialog').removeClass('open');
        }
    });
    initDialog();
});

// BACK CONNECTION

$(document).ready(function () {
    $("#button").click(function (e) {
        e.preventDefault();
        if (!$('#formPostulants').valid()) {
            return;
        }

        var dataString = JSON.stringify({
            Name: $("#name").val(),
            Lastname: $("#lastname").val(),
            Birth: $("#birth").val(),
            Dni: $("#dni").val(),
            Email: $("#email").val(),
            PhoneHome: $("#phoneHome").val(),
            PhoneMobile: $("#phoneMobile").val(),
            Github: $("#github").val(),
            Linkedin: $("#linkedin").val(),
            Study: $('input[name="study"]:checked').val(),
            Institution: $("#institution").val(),
            Career: $("#career").val(),
            Study1: $('input[name="study1"]:checked').val(),
            English: $('input[name="english"]:checked').val(),
            SpeakEnglish: $('select[name=speakEnglish] option:selected').val(),
            WrittenEnglish: $('select[name=writtenEnglish] option:selected').val(),
            ListenEnglish: $('select[name=listenEnglish] option:selected').val(),
            Technologies: $("#technologies").val(),
            InfoProg: $('select[name=infoProg] option:selected').val(),
            Other: $("#other").val(),
            intProg: $("#intProg").val(),
            other: $("#other").val(),
            ConverTheme: $('input[name="converTheme"]:checked').val(),
            Cod: $('input[name="cod"]:checked').val(),
            Tools: $("#tools").val(),
            Pc: $('input[name="pc"]:checked').val(),
            Experience: $("#experience").val(),
        });

        $.ajax({
            type: "POST",
            url: "api/Register/",
            data: dataString,
            contentType: "application/json; charset=utf-8",
            //dataType: "json",
            success: function (response) {
                swal({
                    title: "Registro exitoso!",
                    text: "En breve te contactaremos vía e-mail",
                    icon: "success",
                    button: "Okey!",
                });
            },
            error: function (response) {
                swal("Error!", "Revise los campos, si el error persiste contactese con un administrador.", "error");
            }
        });
        return false;
    });
});