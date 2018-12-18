window.onload = getjson();
window.onload = getState();
window.onload = getMet();


function getQuery() {
    //A = Query completa
    //B = Lo que queres eliminar
    //getDiff Diferencia
    //C = Se queda con el numero
    const query = window.location.search;
    const A = String(query);
    const B = "?postId=";
    const getDiff = (string, diffBy) => string.split(diffBy).join('');
    const C = getDiff(A, B);
    return C;
}

function getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for(var i = 0; i <ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

function createCookie(name,value,days) {
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 *1000));
        var expires = "; expires=" + date.toGMTString();
    } else {
        var expires = "";
    }
    document.cookie = name + "=" + value + expires + "; path=/";
}

function eraseCookie(name) {    
    createCookie(name,"",-1);
}

function getjson() {
    console.log("hola soy una funcion");
    var userData = JSON.parse(atob(getCookie("logininfo")));
    $.ajax({
        type: "GET",
        url: "/api/management/Postulant/" + getQuery(), // + postulantId(),
        headers: {
            Auth: userData.token,
            User: userData.userName
        },
        success: function (data) {
            document.getElementById("user_name").innerHTML = "Welcome, " + data.name + "!";
        },
        fail: function (data) {
            document.getElementById("user_name").innerHTML = "Welcome!";
        }
    });
}

var state 

function getState() {
    console.log("holaSoyUnState");
    var userData = JSON.parse(atob(getCookie("logininfo")));
    $.ajax({
        type: "GET",
        url: "/api/Management/Postulant/" + getQuery(), 
        headers: {
            Auth: userData.token,
            User: userData.userName
        },
        success: function (data) {
            state = data.idState;
            document.getElementById("int01").innerHTML = "Tu estado es: " + translateData(state) + ".";
            stepBar();
        }
    })
}

var meeting

function getMet() {
    var userData = JSON.parse(atob(getCookie("logininfo")));
    $.ajax({
        type: "GET",
        url: "/api/Postulant/" + getQuery(),
        headers: {
            Auth: userData.token,
            User: userData.userName
        },
        success: function (data) {
            meeting = data.dateTime;
            if (meeting == null) {
                document.getElementById("int02").innerHTML = "Aún no hay reuniones agendadas."
            } else {
                    var str = meeting;
                    var res = str.split("T");
                    document.getElementById("int02").innerHTML = "Tu próxima reunión es el día: " + res[0] + "<br> En el horario: " + res[1]
            }

        },
        
    })
}


// ESTADOS POSTULANTE 

function translateData(toTranslate) {
    if (toTranslate == "1") {
        return 'Pendiente de contacto | Postulación'
    }
    if (toTranslate == "2") {
        return 'Entrevista grupal'
    }
    if (toTranslate == "3") {
        return 'Entrevista grupal finalizada'
    }
    if (toTranslate == "4") {
        return 'Entrevista individual'
    }
    if (toTranslate == "5") {
        return 'Bienvenido a Lagash University!'
    }
    if (toTranslate == "6") {
        return 'Bienvenido a Lagash University!'
    }
    if (toTranslate == "7") {
        return 'Decidimos no continuar con tu perfil.'
    }
    if (toTranslate == "null") {
        return 'No hay reuniones agendadas, aún.'
    }
    else {
        return toTranslate
    }

}

// STEP BY STEP BAR --> best negrada ever pero no me funcionaba y estaba a un día de la demo.

function stepBar() {
    if (state == "1") {
        $('.progress .circle:nth-of-type(' + (1)).addClass('active');
    }
    if (state == "2") {
        $('.progress .circle:nth-of-type(' + (1)).addClass('done');
        $('.progress .bar:nth-of-type(' + (1)).addClass('done');
        $('.progress .circle:nth-of-type(' + (2)).addClass('active');
        $('.progress .circle:nth-of-type(' + (3)).removeClass('active');

    }
    if (state == "3") {
        $('.progress .circle:nth-of-type(' + (1)).addClass('done');
        $('.progress .bar:nth-of-type(' + (1)).addClass('done');
        $('.progress .circle:nth-of-type(' + (2)).addClass('done');
        $('.progress .bar:nth-of-type(' + (2)).addClass('done');
        $('.progress .circle:nth-of-type(' + (3)).removeClass('active');
    }
    if (state == "4") {
        $('.progress .circle:nth-of-type(' + (1)).addClass('done');
        $('.progress .bar:nth-of-type(' + (1)).addClass('done');
        $('.progress .circle:nth-of-type(' + (2)).addClass('done');
        $('.progress .bar:nth-of-type(' + (2)).addClass('done');
        $('.progress .circle:nth-of-type(' + (3)).addClass('done');
    }
    if (state == "5") {
        $('.progress .circle:nth-of-type(' + (1)).addClass('done');
        $('.progress .bar:nth-of-type(' + (1)).addClass('done');
        $('.progress .circle:nth-of-type(' + (2)).addClass('done');
        $('.progress .bar:nth-of-type(' + (2)).addClass('done');
        $('.progress .circle:nth-of-type(' + (3)).addClass('done');
        $('.progress .bar:nth-of-type(' + (3)).addClass('done');
        $('.progress .circle:nth-of-type(' + (4)).addClass('done');
        $('.progress .bar:nth-of-type(' + (4)).addClass('done');
        $('.progress .circle:nth-of-type(' + (5)).addClass('done');
    }
    if (state == "6") {
        $('.progress .circle:nth-of-type(' + (1)).addClass('done');
        $('.progress .bar:nth-of-type(' + (1)).addClass('done');
        $('.progress .circle:nth-of-type(' + (2)).addClass('done');
        $('.progress .bar:nth-of-type(' + (2)).addClass('done');
        $('.progress .circle:nth-of-type(' + (3)).addClass('done');
        $('.progress .bar:nth-of-type(' + (3)).addClass('done');
        $('.progress .circle:nth-of-type(' + (4)).addClass('done');
        $('.progress .bar:nth-of-type(' + (4)).addClass('done');
        $('.progress .circle:nth-of-type(' + (5)).addClass('done');
        $('.progress .bar:nth-of-type(' + (5)).addClass('done');
        $('.progress .circle:nth-of-type(' + (6)).addClass('done');

    }
};

