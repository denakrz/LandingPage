// VALIDATE --> no corre los ifs anidados

// var expr = /^[a-zA-Z0-9_\.\-]+@[a-zA-Z\-]+\.[a-zA-z\-\.]+$/;

/* $(document).ready(function(){
    $("#button").click(function(){
        var name = $("#name").val();
        var email = $("#email").val();
        var lastname = $("#lastname").val();

        if(name == ""){
            $("#message1").fadeIn();
            return false;
        } else {
            $("message1").fadeOut();
            if(email == "" || !expr.test(correo)){
                $("menssage3").fadeIn();
                return false;
            }
        }

        return true;
    });
}); */

function validation() {
    
    var stuSec = document.getElementById("secondary");
    var stuTer = document.getElementById("tertiary");
    var stuUni = document.getElementById("universitary");

    var stuOng = document.getElementById("ongoing");
    var stuFin = document.getElementById("finished");
    var stuAba = document.getElementById("abandoned");

    var engYes = document.getElementById("engYes");
    var engNo = document.getElementById("engNo");

    var speakEnglish = document.getElementById("speakEnglish");
    var speakEngAux = speakEnglish.options[speakEnglish.selectedIndex].value

    var writtenEnglish = document.getElementById("writtenEnglish");
    var writtenEngAux = writtenEnglish.options[writtenEnglish.selectedIndex].value

    var listenEnglish = document.getElementById("listenEnglish");
    var listenEngAux = listenEnglish.options[listenEnglish.selectedIndex].value

    var progYes = document.getElementById("progYes");
    var progNo = document.getElementById("progNo");

    var codYes = document.getElementById("codYes");
    var codNo = document.getElementById("codNo");

    var pcYes = document.getElementById("pcYes");
    var pcNo = document.getElementById("pcNo");

    



    if (stuSec.checked == false && stuTer.checked == false && stuUni.checked == false) {
        alert("Por favor indique su nivel de estudios");
        return false;
    }
    
    
    if (stuOng.checked == false && stuFin.checked == false && stuAba.checked == false) {
        alert("Por favor indique el estado de sus estudios");
        return false;
        
    }


    if (engYes.checked == false && engNo.checked == false) {
        alert("Por favor indique si tiene conocimiento del idioma ingles");
        return false;
    }


    if (speakEngAux  == "Seleccione uno") {
        alert("Indique su nivel hablado de ingles")
        return false;
    }
    
    if (writtenEngAux == "Seleccione uno") {
        alert("Indique su nivel escrito de ingles")
        return false;
    }

      
    if (listenEngAux == "Seleccione uno") {
        alert("Indique su nivel de escucha de ingles")
        return false;
    }

    if (progYes.checked == false && progNo.checked == false) {
        alert("Por favor indique si en su círculo cercano es tema de conversación la programacion");
        return false;
    }

    
    if (codYes.checked == false && codNo.checked == false) {
        alert("Por favor indique si ha leído código fuente de cualquier tipo en alguna oportunidad");
        return false;
    }

    
    if (pcYes.checked == false && pcNo.checked == false) {
        alert("Por favor indique si tiene computadora propia o acceso permanente a una");
        return false;
    }   

}

// AUTOCOMPLETE

$(function() {
    var alreadyFilled = false;
    var states = ['Escuela Da Vinci', 'Instituto Tecnológico de Buenos Aires', 'Universidad Abierta Interamericana', 'Universidad de Belgrano', 'Universidad de Buenos Aires', 'Universidad de La Plata', 'Universidad de Lomas de Zamora', 'Universidad Tecnológica Nacional'];

    function initDialog() {
        clearDialog();
        for (var i = 0; i < states.length; i++) {
            $('.dialog').append('<div>' + states[i] + '</div>');
        }
    }
    function clearDialog() {
        $('.dialog').empty();
    }
    $('.autocomplete input').click(function() {
        if (!alreadyFilled) {
            $('.dialog').addClass('open');
        }

    });
    $('body').on('click', '.dialog > div', function() {
        $('.autocomplete input').val($(this).text()).focus();
        $('.autocomplete .close').addClass('visible');
        alreadyFilled = true;
    });
    $('.autocomplete .close').click(function() {
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
    $('.autocomplete input').on('input', function() {
        $('.dialog').addClass('open');
        alreadyFilled = false;
        match($(this).val());
    });
    $('body').click(function(e) {
        if (!$(e.target).is("input, .close")) {
            $('.dialog').removeClass('open');
        }
    });
    initDialog();
});