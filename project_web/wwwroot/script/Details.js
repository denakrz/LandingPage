//traer con get las cosas que completo del formulario
window.onload = getPostulantById();
window.onload = getOtherKnowledge();
window.onload = getAttachedFiles();
window.onload = getMeetings();
window.onload = getResult();
window.onload = state();


$("#updatePersonalData").onclick = updatePersonalData();
function updatePersonalData()
{
    var $dataPersonal = JSON.stringify({
    Name: $("#name").val(),
    Lastname: $("#lastname").val(),
    Birth: $("#birth").val(),
    Dni: $("#dni").val(),
    Email: $("#email").val(),
    PhoneHome: $("#phoneHome").val(),
    PhoneMobile: $("#phoneMobile").val(),
    GitHub: $("#github").val(),
    LinkedIn: $("#LinkedIn").val()
    });

    $.ajax({
        type: "PUT",
        url: "api/Management/Postulant/Modif",
        data: $dataPersonal,
        success: function(data)
        {
            alert("Actualizacion con exito")
        }
    })

}

function translateData(toTranslate){
    if (toTranslate == "basic"){
        return 'Básico'
    }
    if (toTranslate == "intermediate"){
        return 'Intermedio'
    }
    if (toTranslate == "advanced"){
        return 'Avanzado'
    }
    if (toTranslate == undefined){
        return 'Ninguno'
    }
    if (toTranslate == "true") {
        return 'Sí'
    }
    if (toTranslate == "false") {
        return 'No'
    }
    if (toTranslate == "yes"){
        return 'Si'
    }
    if (toTranslate == "no") {
        return 'No'
    }
    else{
        return toTranslate
    }    
    
}

function getQuery() {
    const query = window.location.search;
    const A = String(query);
    const B = "?postId=";
    const getDiff = (string, diffBy) => string.split(diffBy).join('');
    const C = getDiff(A, B);
    return C;
}

function clearBirthHour(birthToClear){
    const query = birthToClear;
    const A = String(query);
    const B = " 12:00:00 AM";
    const getDiff = (string, diffBy) => string.split(diffBy).join('');
    const C = getDiff(A, B);
    return C;
}

function getPostulantById() {
    $.ajax({
        type: "GET",
        url: "/api/Management/Postulant/" + getQuery(), //getQuery(),  //"1", // document.querystring "1", para recorte de la url de juan el id 
        success: function (data) {
            var $personalData = $('#PersonalData')
            var $postulant = $('#postulant')
            var $editPersonalData = $('#modalContentPersonalData')
            $personalData.append('<ul>' +
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
                '<label>' +'<b>' + ' Nombre:' + '</b>' + '</label>' + '<input type="text" class="input" id="name" value="' + data.name + '">' + '<br>' + 
                '<label>' + '<b>' + 'Apellido:' + '</b>' + '</label>' + '<input type="text" class="input"  id="lastname" value = " ' + data.lastname + '"><br>' +
                '<label>' + '<b>' + 'Fecha de nacimiento:' + '</b>' + '</label>' + '<input type="text" class="input"  id="birthday" value="' + data.birthday + '"><br>' + '<label>' + '<b>' + 'DNI:' + '</b>' + '</label>' + '<input type="text" class="input" id="dni" value="' + data.dni + '"><br> ' + '<label>' + '<b>' + ' Email:' + '</b>' + '</label><input type="text" class="input" id="email" value="' + data.email + '"><br>' +
                '<label>' + '<b>' + 'Teléfono:' + '</b>' + '</label>' + '<input type="text" class="input" id="phoneHome" value="' + translateData(data.phoneHome) + '"><br>' +
                '<label>' + '<b>' + 'Celular:' + '</b>' + '</label>' + '<input type="text" class="input" id="phoneMobile" value="' + translateData(data.phoneMobile) + '"><br>' +
                '<label>' + '<b>' + 'Github:' + '</b>' + '</label><input type="text" class="input" id="github" value="' + translateData(data.gitHub) + '"><br>' +
                '<label>' + '<b>' + 'Linkedin:' + '</b>' + '</label>' + '<input type="text" class="input" id="LinkedIn" value="' + translateData(data.LinkedIn) + '"><br>'
            )
        }
    })
}

function getOtherKnowledge() {
    $.ajax({
        type: "GET",
        url: "api/Management/Form/" + getQuery(),
        success: function (data) {
            var $otherKnowledge = $("#OtherKnowledge")
            var $studies = $("#studies")
            var $modalContentStudies = $("#modalContentStudies")
            var $modalContentOtherKnowledge = $("#modalContentOtherKnowledge")
            $otherKnowledge.prepend('<ul>' + 
            '<li>'+'<b>'+'Inglés: '+'</b>' + translateData(data.english) + '</li>' +
            '<li>'+'<b>'+'Nivel de habla de inglés: '+'</b>' + translateData(data.speakEnglish) + '</li>' +
            '<li>'+'<b>'+'Nivel de escritura de inglés: '+'</b>' + translateData(data.writtenEnglish) + '</li>' +
            '<li>'+'<b>'+'Nivel de escucha de inglés: '+'</b>' + translateData(data.listenEnglish) + '</li>' +
            '<li>'+'<b>'+'Tecnologías: '+'</b>' + translateData(data.technologies) + '</li>' +
            '<li>'+'<b>'+'Por quien escuchó del programa: '+'</b>' + data.infoProg + '</li>' +
            '<li>'+'<b>'+'Otros por los que escuchó del programa: '+'</b>' + data.other + '</li>' +
            '<li>'+'<b>'+'Interés en el programa: '+'</b>' + data.intProg + '</li>' +
            '<li>'+'<b>'+'Circulo cercano se habla de programacion: '+'</b>' + translateData(data.converTheme) + '</li>' +
            '<li>'+'<b>'+'Vió código fuente: '+'</b>' + translateData(data.cod) + '</li>' +
            '<li>'+'<b>'+'Herramientas instaladas: '+'</b>' + data.tools + '</li>' +
            '<li>'+'<b>'+'Acceso permanente a pc: '+'</b>' + translateData(data.pc) + '</li>' +
            '<li>'+'<b>'+'Experiencia previa programando: '+'</b>' + data.experience + '</li>' +
            '</ul>'
            )
            $modalContentOtherKnowledge.prepend(
              
            '<label>'+'<b>'+'Inglés: '+'</b>' + '</label>'+ '<input type="text" class="input" value="' + translateData(data.english) + '">' + '<br>' +   
            '<label>'+'<b>'+'Nivel de habla de inglés: '+'</b>' + '</label>'+'<input type="text" class="input" value="' + translateData(data.speakEnglish)  + '">' + '<br>'  +
            '<label>'+'<b>'+'Nivel de escritura de inglés: '+'</b>' + '</label>'+ '<input type="text" class="input" value="' + translateData(data.writtenEnglish) + '">' + '<br>'   +
            '<label>'+'<b>'+'Nivel de escucha de inglés: '+'</b>' + '</label>'+'<input type="text" class="input" value="' +  translateData(data.listenEnglish)  + '">' + '<br>'   +
            '<label>'+'<b>'+'Tecnologías: '+'</b>' + '</label>'+ '<input type="text" class="input" value="' + translateData(data.technologies) + '">' + '<br>'   +
            '<label>'+'<b>'+'Por quien escucho del programa: '+'</b>' + '</label>'+'<input type="text" class="input" value="' + data.infoProg  + '">' + '<br>'    +
            '<label>'+'<b>'+'Otros por los que escuchó del programa: '+'</b>' + '</label>'+ '<input type="text" class="input" value="' + data.other  + '">' + '<br>'   +
            '<label>'+'<b>'+'Interés en el programa: '+'</b>' + '</label>'+ '<input type="text" class="input" value="' + data.intProg  + '">' + '<br>'   +
            '<label>'+'<b>'+'Circulo cercano se habla de programación: '+'</b>' + '</label>'+ '<input type="text" class="input" value="' + translateData(data.converTheme)  + '">' + '<br>'   +
            '<label>'+'<b>'+'Vio código fuente: '+'</b>' + '</label>'+ '<input type="text" class="input" value="' + translateData(data.cod)  + '">' + '<br>'   +
            '<label>'+'<b>'+'Herramientas instaladas: '+'</b>' + '</label>'+ '<input type="text" class="input" value="' + data.tools  + '">' + '<br>'   +
            '<label>'+'<b>'+'Acceso permanente a pc: '+'</b>'  + '</label>'+ '<input type="text" class="input" value="' + translateData(data.pc)  + '">' + '<br>'  +
            '<label>'+'<b>'+'Experiencia previa programando: '+'</b>' + '</label>'+ '<input type="text" class="input" value="' + data.experience  + '">' + '<br>'   
            )
            
            $studies.append(
                '<ul>' +
                '<li>'+'<b>' + 'Institución: '+'</b>' + data.institution + '</li>' +
                '<li>' +'<b>'+ 'Carrera: '+'</b>' + data.career + '</li>' +
                '</ul>'
            )
            $modalContentStudies.prepend('<label>' + ' Institucion:' + '</label>' + '<input type="text" class="input" value="' + data.institution + '">' + '<br>' + '<label>' + 'Carrera:' + '</label>' + '<input type="text" class="input" value = " ' + data.career + '"><br>')
        }
    })
}

function getMeetings() {
    $.ajax({
        type: "GET",
        url: "api/Management/Meeting/" + getQuery(),
        success: function (data) {
            console.log(data.datetime)
            var $Meetings = $("#Meetings")
            var $modalContentMeetings = $("#modalContentMeetings")
            $Meetings.append('<ul>' 
            + '<li>'+'<b>' +'Fecha: '+'</b>'+ translateData(data.datetime) + '</li>' +
            '</ul>'
            )
            $modalContentMeetings.prepend('<label>' + ' Fecha: ' + '</label>' + '<input type="text" class="input" value="' + data.date + '">' + '<br>' + '<label>' + 'Hora: ' + '</label>' + '<input type="text" class="input" value = " ' + data.time + '"><br>')
        }
    })
}


function getResult() {
    $.ajax({
        type: "GET",
        url: "api/Management/Result/" + getQuery(),
        success: function (data) {
            var $Result = $("#Result")
            var $modalContentResult = $("#modalContentResult")
            $Result.append('<ul>'
            +'<li>'+'<b>' +'Observación: '+'</b>'+ translateData(data.observation) + '</li>'
            +'<li>'+'<b>' +'Name: '+'</b>'+ translateData(data.name) + '</li>'
            +'<li>'+'<b>' +'Form: '+'</b>'+ translateData(data.form) + '</li>'
            +'</ul>')

           
            $modalContentResult.prepend('<label>'+'<b>' + ' Observación: ' + '</b>'+ '</label>' + '<input type="text" class="input" value="' + data.observation + '">' + '<br>' )
            
        }
    })
}

function getAttachedFiles() {
    $.ajax({
        type: "GET",
        url: "api/Management/Attached/" + getQuery(),
        success: function (data) {
            var $AttachedFiles = $("#AttachedFiles")
            $AttachedFiles.prepend(
                '<ul>' 
                +'<li>'+'<b>'+'Nombre archivo: '+'</b>' + translateData(data.Name) + '</li>' +
                '</ul>'
            )
        }
    })
}
 function state()
 {
     $.ajax({
         type: "GET",
         url: "/api/Management/State/" + getQuery(),
         success: function (data){
            var $estado = $("#estado") 
            var $modalState = $("#modalContentState")
            if(data == 1)
             {
                $estado.append(
                '<ul>' 
                +'<li>'+'<b>'+'Descripción: '+'</b>' + data + '</li>' +
                '</ul>'
                )
                $modalState.prepend('<label>'+'<b>' + ' Observación: ' + '</b>'+ '</label>' + '<input type="text" class="input" value="' + data + '">' + '<br>' )
             }
             if(data == 2){
                $estado.append(
                '<ul>' 
                +'<li>'+'<b>'+'Descripción: '+'</b>' + data + '</li>' +
                '</ul>')
                $modalState.prepend('<label>'+'<b>' + ' Observación: ' + '</b>'+ '</label>' + '<input type="text" class="input" value="' + data + '">' + '<br>' )
             }
             if(data == 3){
                $estado.append(
                '<ul>' 
                +'<li>'+'<b>'+'Descripción: '+'</b>' + data + '</li>' +
                '</ul>')
                $modalState.prepend('<label>'+'<b>' + ' Observación: ' + '</b>'+ '</label>' + '<input type="text" class="input" value="' + data + '">' + '<br>' )
             }
             if(data == 4){
                $estado.append(
                '<ul>' 
                +'<li>'+'<b>'+'Descripción: '+'</b>' + data + '</li>' +
                '</ul>')
                $modalState.prepend('<label>'+'<b>' + ' Observación: ' + '</b>'+ '</label>' + '<input type="text" class="input" value="' + data + '">' + '<br>' )
             }
             if(data == 5){
                $estado.append(
                '<ul>' 
                +'<li>'+'<b>'+'Descripción: '+'</b>' + data + '</li>' +
                '</ul>')
                $modalState.prepend('<label>'+'<b>' + ' Observación: ' + '</b>'+ '</label>' + '<input type="text" class="input" value="' + data.state + '">' + '<br>' )
             }
             if(data == 6){
                $estado.append(
                '<ul>' 
                +'<li>'+'<b>'+'Descripción: '+'</b>' + data + '</li>' +
                '</ul>')
                $modalState.prepend('<label>'+'<b>' + ' Observación: ' + '</b>'+ '</label>' + '<input type="text" class="input" value="' + data + '">' + '<br>' )
             }
             if(data == 7){

                $estado.append(
                '<ul>' 
                +'<li>'+'<b>'+'Descripción: '+'</b>' + data + '</li>' +
                '</ul>')
                $modalState.prepend('<label>'+'<b>' + ' Observación: ' + '</b>'+ '</label>' + '<input type="text" class="input" value="' + data + '">' + '<br>' )
             }
             if(data == 8){
                $estado.append(
                '<ul>' 
                +'<li>'+'<b>'+'Descripción: '+'</b>' + data + '</li>' +
                '</ul>')
                $modalState.prepend('<label>'+'<b>' + ' Observación: ' + '</b>'+ '</label>' + '<input type="text" class="input" value="' + data + '">' + '<br>' )
             }
         }
     })
 }