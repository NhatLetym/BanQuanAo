$(document).ready(function () {
    Update_Total_Price();
    console.log(formater);
    $('.btn-plus').click(function () {
        var parent = $(this).parent()
        $(parent).find('.txt-amount').val(parseInt($(parent).find('.txt-amount').val()) + 1)
        Update_Total_Price()
    })
    $('.btn-sub').click(function () {
        var parent = $(this).parent()
        if (Number($(parent).find('.txt-amount').val()) > 1) {

            $(parent).find('.txt-amount').val(parseInt($(parent).find('.txt-amount').val()) - 1)
        }
        Update_Total_Price()
    })
})


//Chi tiet SP
function positons() {
    document.getElementById("positon").style.display = "block";
    document.getElementById("photo-info").style.display = "none";
    document.getElementById("lich-trinh-1").style.background = "red";
    document.getElementById("lich-trinh-2").style.background = "white";
    //document.getElementById("positon").style.height = "800px"
}

function photoinfos() {
    document.getElementById("positon").style.display = "none";
    document.getElementById("photo-info").style.display = "block";
    document.getElementById("lich-trinh-2").style.background = "red";
    document.getElementById("lich-trinh-1").style.background = "white";
    //document.getElementById("photo-info").style.height = "1200px"
}