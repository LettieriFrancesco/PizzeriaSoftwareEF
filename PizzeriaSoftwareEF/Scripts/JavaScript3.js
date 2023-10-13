$(document).ready(function () {
    $.ajax({
        method: "GET",
        url: "totaleGiornalieri",
        success: function (data) {
            console.log(data)
            let div = `
            Numero ordini:
            ${data.NumeroEvasi} </br>
            Importo:
            ${data.TotaleEvasiGiornalieri}
            
            `
            $("#elementi").append(div)
        }
    })
})