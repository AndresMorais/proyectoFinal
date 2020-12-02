// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// APARECE EL ALERT LUEGO DE PRESIONAR EL BOTON CARGAR LEGISLACION
$(document).ready(function(){

$('#BotonCargarNota').on('click', function(){
        alert('SE HA REALIZADO LA CARGA CON EXITO');
})
});