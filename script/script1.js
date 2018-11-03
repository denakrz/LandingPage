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