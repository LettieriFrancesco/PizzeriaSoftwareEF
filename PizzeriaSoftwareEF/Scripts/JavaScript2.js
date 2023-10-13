$(document).ready(function () {
    $("#btnCarrello").click(function () {
        let input = $("#Quantita").val()
        $.ajax({
            method: "POST",
            url: "../Carrello",
            data: { quantita: input },
            success: function (data) { }
        })
    
    } )
      
})