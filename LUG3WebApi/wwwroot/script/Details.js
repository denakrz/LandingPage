//traer con get las cosas que completo del formulario
window.onload = state();
window.onload = getPostulantById();
window.onload = getOtherKnowledge();
window.onload = getAttachedFiles();
window.onload = getResult();
window.onload = getMeetings();

// window.onload = getStudies();


function getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
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

function cancelState() {
    var userData = JSON.parse(atob(getCookie("logininfo")));
    $.ajax({
        type: "POST",
        url: "/api/Email/" + name + "/" + lastName + "/" + "hrtestlagash@gmail.com" + "/7", //"hrtestlagash@gmail.com" para probar
        headers: {
            Auth: userData.token,
            User: userData.userName
        },
        success: function (data) {
            console.log("Se rechazo con exito")

        }
    })
}

function changeState() {
    var userData = JSON.parse(atob(getCookie("logininfo")));
    if (readState == 1) {
        var userData = JSON.parse(atob(getCookie("logininfo")));
        $.ajax({
            type: "GET",
            url: "api/Login/GenerateUserPostulant",
            headers: {
                Auth: userData.token,
                User: userData.userName
            },
            success: function (data) {
                console.log("Se guardo el usuario con exito")
            }
        })
        var userData = JSON.parse(atob(getCookie("logininfo")));
        $.ajax({

            type: "POST",
            url: "/api/Email/" + name + "/" + lastName + "/" + email + "/2", //"hrtestlagash@gmail.com" para probar 
            headers: {
                Auth: userData.token,
                User: userData.userName
            },
            success: function (data) {
                console.log("Se notifico con exito")

            }
        })
    }
    if (readState == 2) {
        var userData = JSON.parse(atob(getCookie("logininfo")));
        $.ajax({
            type: "POST",
            url: "/api/Email/" + name + "/" + lastName + "/" + email + "/3", //"hrtestlagash@gmail.com" para probar 
            headers: {
                Auth: userData.token,
                User: userData.userName
            },
            success: function (data) {
                console.log("Se notifico con exito")

            }
        })
    }
    if (readState == 3) {
        var userData = JSON.parse(atob(getCookie("logininfo")));
        $.ajax({
            type: "POST",
            url: "/api/Email/" + name + "/" + lastName + "/" + email + "/4", //"hrtestlagash@gmail.com" para probar 
            headers: {
                Auth: userData.token,
                User: userData.userName
            },
            success: function (data) {
                console.log("Se notifico con exito")

            }
        })
    }
    if (readState == 4) {
        var userData = JSON.parse(atob(getCookie("logininfo")));
        $.ajax({
            type: "POST",
            url: "/api/Email/" + name + "/" + lastName + "/" + email + "/5", //"hrtestlagash@gmail.com" para probar 
            headers: {
                Auth: userData.token,
                User: userData.userName
            },
            success: function (data) {
                console.log("Se notifico con exito")

            }
        })
    }
    if (readState == 5) {
        var userData = JSON.parse(atob(getCookie("logininfo")));
        $.ajax({
            type: "POST",
            url: "/api/Email/" + name + "/" + lastName + "/" + email + "/6", //"hrtestlagash@gmail.com" para probar 
            headers: {
                Auth: userData.token,
                User: userData.userName
            },
            success: function (data) {
                console.log("Se notifico con exito")

            }
        })
    }

}

function updatePersonalData() {
    var $dataPersonal = {
        "id": getQuery(),
        "Name": $("#name").val(),
        "Lastname": $("#lastname").val(),
        "Birthday": $("#birthday").val(),
        "Dni": $("#dni").val(),
        "Email": $("#email").val(),
        "PhoneHome": $("#phoneHome").val(),
        "PhoneMobile": $("#phoneMobile").val(),
        "GitHub": $("#github").val(),
        "LinkedIn": $("#LinkedIn").val(),
        "idState": readState,
        "iteration": 1,
        "country": 1
    };
    var userData = JSON.parse(atob(getCookie("logininfo")));
    var toJson = JSON.stringify($dataPersonal)
    var userData = JSON.parse(atob(getCookie("logininfo")));
    $.ajax({
        type: "PUT",
        url: "api/Management/Postulant/Modif",
        headers: {
            Auth: userData.token,
            User: userData.userName
        },
        data: toJson,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $('#PersonalData').html("");
            $('#postulant').html("");
            $('#editablePersData').html("");

            getPostulantById();
        },
        fail: function (data) {
            swal("Error!", "Vuelve a intentarlo", "error");
        }
    })

}

function createMeeting() {
    var postulantData = {
        "idInstance": readState,
        "idPostulant": getQuery(),
        "DateTime": $("#meetDate").val() + " " + $("#meetTime").val()
    }
    var toJson = JSON.stringify(postulantData)

    if (readState == 1 || readState == 3 || readState == 5 //(check actual states)
    ) {
        var userData = JSON.parse(atob(getCookie("logininfo")));
        $.ajax({
            type: "POST",
            url: "api/management/meeting/",
            headers: {
                Auth: userData.token,
                User: userData.userName
            },
            data: toJson,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            error: function (data) {
                swal("Success!", "Se ha agregado una reunión!", "success");
                $('#estado').html("")
                state()
                $('#Meetings').html("")
                getMeetings()
            }
        })
    } else {
        swal("Error!", "No corresponde agregar reunión", "error");
    }
}

function translateData(toTranslate) {
    if (toTranslate == "basic") {
        return 'Básico'
    }
    if (toTranslate == "intermediate") {
        return 'Intermedio'
    }
    if (toTranslate == "advanced") {
        return 'Avanzado'
    }
    if (toTranslate == undefined) {
        return 'Ninguno'
    }
    if (toTranslate == "") {
        return 'Ninguno'
    }
    if (toTranslate == "true") {
        return 'Sí'
    }
    if (toTranslate == "false") {
        return 'No'
    }
    if (toTranslate == "yes") {
        return 'Si'
    }
    if (toTranslate == "no") {
        return 'No'
    }
    if (toTranslate == "Pending contact") {
        return 'Pendiente de contacto'
    }
    if (toTranslate == "Scheduled Assessment") {
        return 'Evaluacion programada'
    }
    if (toTranslate == "FinishedAssessment") {
        return 'Evaluación finalizada'
    }
    if (toTranslate == "Pending Interview") {
        return 'Entrevista pendiente'
    }
    if (toTranslate == "Finished Interview") {
        return 'Entrevista finalizada'
    }
    if (toTranslate == " Approved") {
        return 'Aprobado'
    }
    if (toTranslate == "Rejected") {
        return 'Rechazado'
    }
    if (toTranslate == "Canceled") {
        return 'Cancelado'
    }
    if (toTranslate == "secondary") {
        return 'Secundario'
    }
    if (toTranslate == "tertiary") {
        return 'Terciario'
    }
    if (toTranslate == "universitary") {
        return 'Universitario'
    }
    if (toTranslate == "finished") {
        return 'Terminado'
    }
    if (toTranslate == "onGoing" || toTranslate == "ongoing") {
        return 'En curso'
    }
    if (toTranslate == "abandoned") {
        return 'Abandonado'
    }
    if (toTranslate == "1") {
        return 'Form';
    }
    if (toTranslate == "2") {
        return 'Resume';
    }
    if (toTranslate == "3") {
        return 'DNI';
    }
    if (toTranslate == "4") {
        return 'CUIL';
    }
    if (toTranslate == "5") {
        return 'Certificate';
    } else {
        return toTranslate
    }
}


var readState

function state() {
    var userData = JSON.parse(atob(getCookie("logininfo")));
    $.ajax({
        type: "GET",
        url: "api/Management/State/All/" + getQuery(),
        headers: {
            Auth: userData.token,
            User: userData.userName
        },
        success: function (data) {
            var $estado = $("#estado")
            var $modalState = $("#modalContentState")
            readState = data[0].id
            if (data[0].id == 1) {
                $estado.append(
                    '<ul>' +
                    '<li>' + '<b>' + 'Descripción: ' + '</b>' + translateData(data[0].state) + '</li>' +
                    '</ul>'
                )
                $modalState.prepend('<label>' + '<b>' + ' Descripción: ' + '</b>' + '</label>' + '<input type="text" class="input" value="' + translateData(data[0].state) + '" readonly>' + '<br>')
            }
            if (data[0].id == 2) {
                $estado.append(
                    '<ul>' +
                    '<li>' + '<b>' + 'Descripción: ' + '</b>' + translateData(data[0].state) + '</li>' +
                    '</ul>')
                $modalState.prepend('<label>' + '<b>' + ' Descripción: ' + '</b>' + '</label>' + '<input type="text" class="input" value="' + translateData(data[0].state) + '" readonly>' + '<br>')
            }
            if (data[0].id == 3) {
                $estado.append(
                    '<ul>' +
                    '<li>' + '<b>' + 'Descripción: ' + '</b>' + translateData(data[0].state) + '</li>' +
                    '</ul>')
                $modalState.prepend('<label>' + '<b>' + ' Descripción: ' + '</b>' + '</label>' + '<input type="text" class="input" value="' + translateData(data[0].state) + '" readonly>' + '<br>')
            }
            if (data[0].id == 4) {
                $estado.append(
                    '<ul>' +
                    '<li>' + '<b>' + 'Descripción: ' + '</b>' + translateData(data[0].state) + '</li>' +
                    '</ul>')
                $modalState.prepend('<label>' + '<b>' + ' Descripción: ' + '</b>' + '</label>' + '<input type="text" class="input" value="' + translateData(data[0].state) + '" readonly>' + '<br>')
            }
            if (data[0].id == 5) {
                $estado.append(
                    '<ul>' +
                    '<li>' + '<b>' + 'Descripción: ' + '</b>' + translateData(data[0].state) + '</li>' +
                    '</ul>')
                $modalState.prepend('<label>' + '<b>' + ' Descripción: ' + '</b>' + '</label>' + '<input type="text" class="input" value="' + translateData(data[0].state) + '" readonly>' + '<br>')
            }
            if (data[0].id == 6) {
                $estado.append(
                    '<ul>' +
                    '<li>' + '<b>' + 'Descripción: ' + '</b>' + translateData(data[0].state) + '</li>' +
                    '</ul>')
                $modalState.prepend('<label>' + '<b>' + ' Descripción: ' + '</b>' + '</label>' + '<input type="text" class="input" value="' + translateData(data[0].state) + '" readonly>' + '<br>')
            }
            if (data[0].id == 7) {

                $estado.append(
                    '<ul>' +
                    '<li>' + '<b>' + 'Descripción: ' + '</b>' + translateData(data[0].state) + '</li>' +
                    '</ul>')
                $modalState.prepend('<label>' + '<b>' + ' Descripción: ' + '</b>' + '</label>' + '<input type="text" class="input" value="' + translateData(data[0].state) + '" readonly>' + '<br>')
            }
            if (data[0].id == 8) {
                $estado.append(
                    '<ul>' +
                    '<li>' + '<b>' + 'Descripción: ' + '</b>' + translateData(data[0].state) + '</li>' +
                    '</ul>')
                $modalState.prepend('<label>' + '<b>' + ' Descripción: ' + '</b>' + '</label>' + '<input type="text" class="input" value="' + translateData(data[0].state) + '" readonly>' + '<br>')
            }
        }
    })
}

function getQuery() {
    const query = window.location.search;
    const A = String(query);
    const B = "?postId=";
    const getDiff = (string, diffBy) => string.split(diffBy).join('');
    const C = getDiff(A, B);
    return C;
}

function clearBirthHour(birthToClear) {
    const query = birthToClear;
    const A = String(query);
    const B = " 12:00:00 AM";
    const getDiff = (string, diffBy) => string.split(diffBy).join('');
    const C = getDiff(A, B);
    return C;
}
var name
var lastName
var email

function getPostulantById() {
    var userData = JSON.parse(atob(getCookie("logininfo")));
    $.ajax({
        type: "GET",
        url: "/api/Management/Postulant/" + getQuery(), //getQuery(),  //"1", // document.querystring "1", para recorte de la url de juan el id 
        headers: {
            Auth: userData.token,
            User: userData.userName
        },
        success: function (data) {
            var $personalData = $('#PersonalData')
            var $postulant = $('#postulant')
            var $editPersonalData = $('#modalContentPersonalData')
            name = data.name
            lastName = data.lastname
            email = data.email
            $personalData.append('<ul >' +
                '<li>' + '<b>' + 'Nombre: ' + '</b>' + data.name + '</li> ' +
                '<li>' + '<b>' + 'Apellido: ' + '</b>' + data.lastname + '</li>' +
                '<li>' + '<b>' + 'Fecha de nacimiento: ' + '</b>' + clearBirthHour(data.birthday) + '</li>' +
                '<li>' + '<b>' + 'DNI: ' + '</b>' + data.dni + '</li>' +
                '<li>' + '<b>' + 'Email: ' + '</b>' + data.email + '</li>' +
                '<li>' + '<b>' + 'Teléfono: ' + '</b>' + translateData(data.phoneHome) + '</li>' +
                '<li>' + '<b>' + 'Celular: ' + '</b>' + translateData(data.phoneMobile) + '</li>' +
                '<li>' + '<b>' + 'GitHub: ' + '</b>' + translateData(data.gitHub) + '</li>' +
                '<li>' + '<b>' + 'LinkedIn: ' + '</b>' + translateData(data.linkedIn) + '</li>' +
                '</ul>')

            $postulant.append('<h1>' + data.lastname + ', ' + data.name + '</h1>')
            $editPersonalData.prepend(
                '<div id="editablePersData">' +
                '<label>' + '<b>' + ' Nombre:' + '</b>' + '</label>' + '<input type="text" class="input" id="name" value="' + data.name + '">' + '<br>' +
                '<label>' + '<b>' + 'Apellido:' + '</b>' + '</label>' + '<input type="text" class="input"  id="lastname" value ="' + data.lastname + '"><br>' +
                '<label>' + '<b>' + 'Fecha de nacimiento:' + '</b>' + '</label>' + '<input type="text" class="input"  id="birthday" value="' + clearBirthHour(data.birthday) + '" readonly><br>' + '<label>' + '<b>' + 'DNI:' + '</b>' + '</label>' + '<input type="text" class="input" id="dni" value="' + data.dni + '"><br> ' + '<label>' + '<b>' + ' Email:' + '</b>' + '</label><input type="text" class="input" id="email" value="' + data.email + '"><br>' +
                '<label>' + '<b>' + 'Teléfono:' + '</b>' + '</label>' + '<input type="text" class="input" id="phoneHome" value="' + translateData(data.phoneHome) + '"><br>' +
                '<label>' + '<b>' + 'Celular:' + '</b>' + '</label>' + '<input type="text" class="input" id="phoneMobile" value="' + translateData(data.phoneMobile) + '"><br>' +
                '<label>' + '<b>' + 'Github:' + '</b>' + '</label><input type="text" class="input" id="github" value="' + translateData(data.gitHub) + '"><br>' +
                '<label>' + '<b>' + 'Linkedin:' + '</b>' + '</label>' + '<input type="text" class="input" id="LinkedIn" value="' + translateData(data.LinkedIn) + '"><br>' +
                '</div>'
            )
        }
    })
}

function getOtherKnowledge() {
    var userData = JSON.parse(atob(getCookie("logininfo")));
    $.ajax({
        type: "GET",
        url: "api/Management/Form/" + getQuery(),
        headers: {
            Auth: userData.token,
            User: userData.userName
        },
        success: function (data) {
            var $otherKnowledge = $("#OtherKnowledge")
            var $studies = $("#studies")
            var $modalContentStudies = $("#modalContentStudies")
            //var $modalContentOtherKnowledge = $("#modalContentOtherKnowledge")
            $otherKnowledge.prepend('<ul>' +
                '<li>' + '<b>' + 'Inglés: ' + '</b>' + translateData(data.english) + '</li>' +
                '<li>' + '<b>' + 'Nivel de habla de inglés: ' + '</b>' + translateData(data.speakEnglish) + '</li>' +
                '<li>' + '<b>' + 'Nivel de escritura de inglés: ' + '</b>' + translateData(data.writtenEnglish) + '</li>' +
                '<li>' + '<b>' + 'Nivel de escucha de inglés: ' + '</b>' + translateData(data.listenEnglish) + '</li>' +
                '<li>' + '<b>' + 'Tecnologías: ' + '</b>' + translateData(data.technologies) + '</li>' +
                '<li>' + '<b>' + 'Por quién escuchó del programa: ' + '</b>' + data.infoProg + '</li>' +
                '<li>' + '<b>' + 'Otros por los que escuchó del programa: ' + '</b>' + data.other + '</li>' +
                '<li>' + '<b>' + 'Interés en el programa: ' + '</b>' + data.intProg + '</li>' +
                '<li>' + '<b>' + 'Círculo cercano se habla de programacion: ' + '</b>' + translateData(data.converTheme) + '</li>' +
                '<li>' + '<b>' + 'Vió código fuente: ' + '</b>' + translateData(data.cod) + '</li>' +
                '<li>' + '<b>' + 'Herramientas instaladas: ' + '</b>' + data.tools + '</li>' +
                '<li>' + '<b>' + 'Acceso permanente a pc: ' + '</b>' + translateData(data.pc) + '</li>' +
                '<li>' + '<b>' + 'Experiencia previa programando: ' + '</b>' + data.experience + '</li>' +
                '</ul>'
            )
            $studies.append(
                '<ul>' +
                '<li>' + '<b>' + 'Nivel: ' + '</b>' + translateData(data.study) + '</li>' +
                '<li>' + '<b>' + 'Estado: ' + '</b>' + translateData(data.study1) + '</li>' +
                '<li>' + '<b>' + 'Institución: ' + '</b>' + data.institution + '</li>' +
                '<li>' + '<b>' + 'Carrera: ' + '</b>' + data.career + '</li>' +
                '</ul>'
            )
            $modalContentStudies.prepend('<label>' + ' Institucion:' + '</label>' + '<input type="text" class="input" value="' + data.institution + '">' + '<br>' + '<label>' + 'Carrera:' + '</label>' + '<input type="text" class="input" value = " ' + data.career + '"><br>')
        }
    })
}
var meetId, getIdInstance

function getMeetings() {
    var userData = JSON.parse(atob(getCookie("logininfo")));
    $.ajax({
        type: "GET",
        url: "api/Management/Meeting/" + getQuery(),
        headers: {
            Auth: userData.token,
            User: userData.userName
        },
        success: function (data) {
            if (readState > 1) {
                var i = data.length - 1
                getIdInstance = data[i].idInstance;
                meetId = data[i].id;
                var DateTime = data[i].dateTime;
                splitDateTime = DateTime.split(" ");
            } else {
                splitDateTime = ""
            }
            var $Meetings = $("#Meetings");
            var $modalContentMeetings = $("#modalContentMeetings");
            idInstance =
                $Meetings.append('<ul>' +
                    '<li>' + '<b>' + 'Fecha: ' + '</b>' + translateData(splitDateTime[0]) + '</li>' +
                    '<li>' + '<b>' + 'Hora: ' + '</b>' + translateData(splitDateTime[1]) + '</li>' +
                    '</ul>'
                )
            $modalContentMeetings.prepend('<label>' + ' Fecha: ' + '</label>' + '<input type="date" id="meetDate" class="input" value="' + data.date + '">' + '<br>' +
                '<label>' + 'Hora: ' + '</label>' + '<input type="time" id="meetTime" class="input" value = " ' + data.time + '"><br>')
        }
    })
}

var getIdResult

function getResult() {
    var userData = JSON.parse(atob(getCookie("logininfo")));
    $.ajax({
        type: "GET",
        url: "api/Management/ResultView/" + getQuery(),
        headers: {
            Auth: userData.token,
            User: userData.userName
        },
        success: function (data) {
            var i = data.length - 1;
            var $Result = $("#Result")
            var $modalContentResult = $("#modalContentResult")
            if (data.length == 0) {
                $Result.append('<ul id="resultList">' +
                    '<li>' + '<b>' + 'Observación: ' + '</b>' + 'Ninguno' + '</li>' +
                    '<li>' + '<b>' + 'Estado: ' + '</b>' + 'Ninguno' + '</li>' +
                    '</ul>')
                $modalContentResult.prepend(
                    '<label>' + '<b>' + ' Resumen: ' + '</b>' + '</label>' + '<input id="fileResult" type="file" class="input" value="' + 'Ninguno' + '">' + '<br>' +
                    '<label>' + '<b>' + ' Observación: ' + '</b>' + '</label>' + '<input id="observation" type="text" class="input" value="' + 'Ninguno' + '">' + '<br>' +
                    '<label>' + '<b>' + ' Estado: ' + '</b>' + '</label>' + '<select id="okSelect" class="input"> <option value="1">Positivo</option> <option value="0">Negativo</option></select>' + '<br>'
                )
            } else {
                getIdResult = data[i].id;
                $Result.append('<ul id="resultList">' +
                    '<li>' + '<b>' + 'Observación: ' + '</b>' + translateData(data[0].observation) + '</li>' +
                    '<li>' + '<b>' + 'Estado: ' + '</b>' + translateData(data[0].ok) + '</li>' +
                    '<li onclick="getResultFile()">' + '<b>' + 'Estado: ' + '</b>' + translateData(data[0].name) + '</li>' +
                    '</ul>')
                $modalContentResult.prepend(
                    '<label>' + '<b>' + ' Resumen: ' + '</b>' + '</label>' + '<input id="fileResult" type="file" class="input" value="' + data.form + '">' + '<br>' +
                    '<label>' + '<b>' + ' Observación: ' + '</b>' + '</label>' + '<input id="observation" type="text" class="input" value="' + data.observation + '">' + '<br>' +
                    '<label>' + '<b>' + ' Estado: ' + '</b>' + '</label>' + '<select id="okSelect" class="input"> <option value="1">Positivo</option> <option value="0">Negativo</option></select>' + '<br>'

                )
            }
        },
        error: function (data) {
            console.log("Error")
            swal("Error!", "Algo salió mal", "error");
        }
    })
}

function getResultFile() {
    var userData = JSON.parse(atob(getCookie("logininfo")));
    console.log(userData)
    $.fileDownload("api/Management/Result/File/" + getIdResult, {
        httpMethod: "POST",
        beforeSend: function (request) {
            request.setRequestHeader("Auth", userData.token);
            request.setRequestHeader("User", userData.userName);
        },
        contentType: "application/json",
        success: function () {
            swal("Success!", "Transacción exitosa", "success");
        },
        error: function(){
            swal("Error!", "Algo salió mal", "error");
        }
    });
}

function getNameFile() {
    var userData = JSON.parse(atob(getCookie("logininfo")));
    $.ajax({
        type: "GET",
        url: "api/Management/Attached/" + getQuery() + "/" + nameAttached,
        headers: {
            Auth: userData.token,
            User: userData.userName
        },
        success: function (data) {
            alert(nameAttached)
        }
    })
}

var nameAttached

function getAttachedFiles() {
    var userData = JSON.parse(atob(getCookie("logininfo")));
    $.ajax({
        type: "GET",
        url: "api/Management/Attached/" + getQuery(),
        headers: {
            Auth: userData.token,
            User: userData.userName
        },
        success: function (data) {
            var i = data.length - 1
            nameAttached = data[i].name
            var $AttachedFiles = $("#AttachedFiles")
            if (nameAttached !== undefined) {
            
                $AttachedFiles.prepend(
                    '<ul>' +
                    '<li>' + '<b>' + 'Nombre archivo: ' + '</b>'  + translateData(data[i].name)  + '</li>' +
                    '</ul>'
                )
            } else {
                $AttachedFiles.prepend(
                    '<ul>' +
                    '<li>' + '<b>' + 'Nombre archivo: ' + '</b>' +  translateData(data[i].name) + '</li>' +
                    '</ul>'
                )
            }
        }

    })
}

function downloadAttachedFile(){
    var userData = JSON.parse(atob(getCookie("logininfo")));

    $.fileDownload("api/Management/Attached/" + getQuery() + "/" + nameAttached,
    {
        httpMethod: "POST",
        beforeSend: function (request) {
         
            request.setRequestHeader("Auth", userData.token);
            request.setRequestHeader("User", userData.userName);
        },
        contentType: "application/json",
        success: function () {
            swal("Success!", "Transacción exitosa", "success");
        },
        error: function(){
            swal("Error!", "Algo salió mal", "error");
        }
        
    })
}

function getValueTypeFile() {
    var $selectTypeFile = $('#typeFile')
    getIdTypeAttached = $selectTypeFile.val()
    if ($selectTypeFile.val() == "1") {
        return "1"
    }
    if ($selectTypeFile.val() == "2") {
        return "2"
    }
    if ($selectTypeFile.val() == "3") {
        return "3"
    }
    if ($selectTypeFile.val() == "4") {
        return "4"
    }
    if ($selectTypeFile.val() == "5") {
        return "5"
    } else {
        return undefined
    }
}
var getIdTypeAttached

function addAttachedFiles() {
    var userData = JSON.parse(atob(getCookie("logininfo")));
    var resultData = new FormData;
    jQuery.each(jQuery('#fileR')[0].files, function (i, file) {
        resultData.append('file' + i, file);
    });
    resultData.append('IdTypeAttached', getIdTypeAttached);
    resultData.append('Name', nameAttached);
    $.ajax({
        type: "POST",
        url: "api/Management/Attached/" + getQuery() + "/" + getValueTypeFile(),
        headers: {
            Auth: userData.token,
            User: userData.userName

        },
        data: resultData,
        contentType: false,
        cache: false,
        processData: false,
        success: function (data) {
            console.log("Se subio un archivo con exito")
        }
    })
}

function putResults() {
    var userData = JSON.parse(atob(getCookie("logininfo")));
    var e = document.getElementById("okSelect");
    var strUser = e.options[e.selectedIndex].value;
    var resultData = new FormData;
    jQuery.each(jQuery('#fileResult')[0].files, function (i, file) {
        resultData.append('file' + i, file);
    });
    resultData.append('idInstance', getIdInstance);
    resultData.append('idMeeting', meetId);
    resultData.append('Observation', $("#observation").val());
    resultData.append('OK', strUser);
    var userData = JSON.parse(atob(getCookie("logininfo")));
    $.ajax({
        type: 'POST',
        url: 'api/management/result/' + getQuery(),
        headers: {
            Auth: userData.token,
            User: userData.userName
        },
        data: resultData,
        contentType: false,
        cache: false,
        processData: false,
        success: function (data) {
            swal("Success!", "Transacción exitosa", "success");
        },
        error: function (data) {
            swal("Error!", "Algo ha salido mal.", "error");
        }
    });


}