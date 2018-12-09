//Carga lista de postulantes
window.onload = getjson();

//Refresh de lista de postulantes
 function refreshList(){
    var ul = document.getElementById("post_table");
    while(ul.firstChild) ul.removeChild(ul.firstChild);
    getjson();
    clearState();
  };

//Declaracion variables para checkboxes
var clearState, state1, state2, state3, state4, state5, state6, state7, editionSelected;
state1 = false; state2 = false; state3 = false; state4 = false; state5 = false; state6 = false; state7 = false; editionSelected = null;


//Funciones para alternar estado de checkboxes
function toggleCheckbox1()
{
    state1 = !state1;
    filterFunction();
}
function toggleCheckbox2()
{
    state2 = !state2;
    filterFunction();
}
function toggleCheckbox3()
{
    state3 = !state3;
    filterFunction();
}
function toggleCheckbox4()
{
    state4 = !state4;
    filterFunction();
}
function toggleCheckbox5()
{
    state5 = !state5;
    filterFunction();
}
function toggleCheckbox6()
{
    state6 = !state6;
    filterFunction();
}
function toggleCheckbox7()
{
    state7 = !state7;
    filterFunction();
}
function getEdition(selectObject){
    editionSelected = selectObject.value;
    filterFunction();
    console.log(editionSelected);
}

//Funcion para resetear checkboxes y busqueda
function clearState(){
  state1 = false; state2 = false; state3 = false; state4 = false; state5 = false; state6 = false; state7 = false;
    document.getElementById("nameSearch").value = "";
filterFunction();  
$('input[type=checkbox]').prop('checked',false);    
}

//Funcion de filtro por nombre y estado
function filterFunction() {
  var input, filter, a, i;
  input = document.getElementById("nameSearch");
  filter = input.value.toUpperCase();
  div = document.getElementById("post_table");
  a = div.getElementsByTagName("li");
    
  for (i = 0; i < a.length; i++) {
if (a[i].innerHTML.toUpperCase().indexOf(filter) > -1 && ((dataPost[i].state == "Pending contact" && state1 == true) || (dataPost[i].state == "Scheduled Assessment" && state2 == true) || (dataPost[i].state == "FinishedAssessment" && state3 == true) || (dataPost[i].state == "Pending Interview" && state4 == true) || (dataPost[i].state == "Finished Interview" && state5 == true) || (dataPost[i].state == "Approved" && state6 == true) || (dataPost[i].state == "Rejected" && state7 == true) || state1 == false && state2 == false && state3 == false && state4 == false && state5 == false && state6 == false && state7 == false && (editionSelected == "none" || "1")))
    
    {
      a[i].style.display = "";
    }
      
    else {
      a[i].style.display = "none";
    }
  }
} 

//Variable auxiliar para guardar lista de postulantes
var dataPost;

//Funcion para obtener lista desde DB
function getjson(){
 $.ajax({
        type: "GET",
        url: "/api/management/Postulant/",
        success: function (data) {
            dataPost = (data);
            var $ul = $('#post_table')
            $.each(data, function(idx, item){
            $ul.append('<li>' + '<dt>' + item.lastname + ', ' + item.name +'<div id=" ' + item.id +
             '" class="ver_detalles" onclick="detailsRedirect(' + item.id + ')">Ver Detalles</div>'+
             '</dt>'+ '<dd>' + item.state + '</dd>'+'</li>')
          })
      },
  });
}

//Funcion de redireccion al postulante al clickear en "Ver detalles"
function detailsRedirect(postId){
    var url = "details.html?postId=" + (postId);
    window.location = url;
}