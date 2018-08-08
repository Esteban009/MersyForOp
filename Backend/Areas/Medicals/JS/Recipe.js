
$(document).ready(function () {

    var detalle = "<br><br>";
    var theRealUrl;
    $('input,textarea,select').attr('disabled', true);
    
    //$('#BtnPrintA4').click(function () {
    //  //  theRealUrl = '@Url.Action("RecipeA4", "Reports", new { area = "Medicals", id = Model.Patient.Person.AuthorId, description = "Receta Medica" })';
    //    printRecibe();
    //});

    $('#BtnPrint').click(function () {
        theRealUrl = '@Url.Action("DetailsPrint", "Reports", new { area = "Configurations",' + $('#AuthorId').val() + ' , description = "Receta Medica" })';
        printRecibe();

        var url = theRealUrl;
        url = url + "&body=" + encodeURIComponent(detalle);
        var win = window.open(url);

        if (win) {
            //Browser has allowed it to be opened
            win.focus();
        } else {
            //Browser has blocked it
            alert("Porfavor, debes permitir que se abran las ventanas emergentes o el reporte no va a salir :'( ");
        }
    });

    function printRecibe () {
        var recipeDate = $('#RecipeDate').val();
        var patientName = $('#PatientName').val();
        var texto = $('#RecipeText').val();
        texto = texto.replace(/\n/g, "<br>");
        texto = texto.replace(/ /g, '\u00a0');
        var recipeText = "<span>" + texto + "</span>";
        var observation = $('#Observations').val();
        var place = $('#Place').val();

        detalle = "<br><br>";
            detalle += " Fecha: <b>" + recipeDate + "</b>  <br>";
        detalle = "<br><br>";

        detalle += "Se otorga la presente receta a: <b>" + patientName + "</b>   <br> <br><br>";
        detalle += "<u><b>Medicamento(s) e Indicacion(es)</b></u> ";
            detalle += " <br> <br> " + recipeText + " <br> <br> <br>";
            if (observation != '') {
                detalle += "<u><b>Observacion(es)</b></u> <br><br>";
                detalle += "" + observation + " <br><br><br> <br>";
        }
    // detalle += "<br><br><br><br>  ";
           
            detalle += " Expido la presente Certificación en: " + place+ "    <br>";

           
            detalle += "<br><br><br><br>  ";
            detalle += "<center> Firma Medico:___________________________________</center>";

            //detalle += "<div style='position:absolute; width:100%; bottom=1px;' align='right'>Firma Medico:_______________________________</div>";

        

            //var url = '@Url.Action("DetailsPrint", "Reports", new {area = "Configurations", id = Model.Patient.Person.AuthorId, description = "Receta Medica"})';
            //url = url + "&body=" + encodeURIComponent(detalle);
            //var win = window.open(url);

            //if (win) {
            //    //Browser has allowed it to be opened
            //    win.focus();
            //} else {
            //    //Browser has blocked it
            //    alert("Porfavor, debes permitir que se abran las ventanas emergentes o el reporte no va a salir :'( ");
            //}


    };

 
 

});
