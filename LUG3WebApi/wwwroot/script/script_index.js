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

// MODAL LOGIN

var modal = document.getElementById('id01');

window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
        removeEventListener();
    }
}

// VALIDATE LOGIN

$(document).ready(function () {
    $("#modal-content").validate({
        rules: {
            user: {
                required: true,
                email: true,
            },
            psw: {
                required: true,
            },
        },
        messages: {
            user: {
                required: 'Por favor ingresa tu usuario',
                email: 'Por favor ingresa un usuario v�lido',
            },
            psw: {
                required: 'Por favor ingresa tu contrase�a'
            },
        },
    });

    // AJAX LOGIN
    $("#but1").click(function() {
        var userName = $("#user").val();
        var password = $("#psw").val();
        
        $.ajax({
            method: "GET",
            url: "/api/Login",
            headers: {
                userName: userName,
                password: password,
            },
        }).done(function(userinfo) {            
            if(userinfo) {
                var infouser = JSON.parse(JSON.stringify(userinfo));
                setLoginCookie({userName: userName, token : infouser.token});
                redirect(infouser);
            } else {
                swal("Error!", "Por favor revisa los campos", "error");
            }
        })        
    });
})

//CHANGE WINDOW
function redirect(infouser) {
    var loginT = infouser['loginType'];
    if (loginT == 1) {
        var url = "postulant_view.html?postId=" + (infouser.idPostulant);
        window.location.replace(url);
    } else if (loginT == 2){
        var url = "/list_post.html"
        window.location.replace(url);
    }
}

//SET COOKIE
function setLoginCookie(userinfo) {
    var data = btoa(JSON.stringify(userinfo));
    document.cookie = "logininfo=" + data;
}
