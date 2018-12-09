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
    }
}