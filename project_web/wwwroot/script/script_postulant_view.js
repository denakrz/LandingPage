// STEP BY STEP BAR

$(document).ready(function () {
    var i = 1;
    $('.progress .circle').removeClass().addClass('circle');
    $('.progress .bar').removeClass().addClass('bar');
    setInterval(function () {
        $('.progress .circle:nth-of-type(' + i + ')').addClass('active');

        $('.progress .circle:nth-of-type(' + (i - 1) + ')').removeClass('active').addClass('done');

        $('.progress .circle:nth-of-type(' + (i - 1) + ') .label').html('&#10003;');

        $('.progress .bar:nth-of-type(' + (i - 1) + ')').addClass('active');

        $('.progress .bar:nth-of-type(' + (i - 2) + ')').removeClass('active').addClass('done');

        i++;

        if (i == 0) {
            $('.progress .bar').removeClass().addClass('bar');
            $('.progress div.circle').removeClass().addClass('circle');
            i = 1;
        }
    }, 2000);  // --> cambiaría según estado del postulante!
});

// AJAX

/*function postulantId() {

}*/

function getjson() {
    $.ajax({
        type: "GET",
        url: "/api/management/Postulant/2", // + postulantId(), -> cuando el login se digne a andar.
        success: function (data) {
            //document.getElementById("user-name").innerHTML = "Welcome" + data.Name;
            console.log(data);
        },
        fail: function (data) {
            console.log("error")
        }
    });
}
