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

// AUTOCOMPLETE

$(function() {
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
      //  if (!validation()) {
     //       return;
       // }

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
            dataType: "json",
            success: function (response) {
                alert('Ha sido registrado satisfactoriamente');
                //window.location.href = 'https://google.com';
            },
            error: function (response) {
                alert('Error')
            }
        });
        return false;
    });
});