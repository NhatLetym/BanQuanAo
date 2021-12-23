var formater = Intl.NumberFormat("vi", {
    style: 'currency',
    currency: 'VND',
    minimumFractionDigits: 0
});

function replaceDot(s){
	while(s.indexOf(".")>=0)
		s = s.replace(".", "");
	return s;
}

function Update_Total_Price(){
    var data = $('.item-price')
    var total_price=0
    for(var i=0;i<data.length;i++){
        var price = $(data[i]).text()
		
        var parent = $(data[i]).parent().parent()
        var amount = parent.find('.txt-amount').val()
        price = price.toString().replace(' đ','')
		
        price = replaceDot(price);
        total_price+= Number(price) * amount
    }
    console.log(total_price);
    $('.tmp-price').text(formater.format(total_price.toString()));
    $('.total-price').text(formater.format(total_price.toString()));
   
}


//So Luong
$(document).ready(function(){
    Update_Total_Price();
	console.log(formater);
    $('.btn-plus').click(function(){
        var parent = $(this).parent()
        $(parent).find('.txt-amount').val(parseInt($(parent).find('.txt-amount').val())+1)
        Update_Total_Price()
    })
    $('.btn-sub').click(function(){
        var parent = $(this).parent()
        if(Number($(parent).find('.txt-amount').val()) > 1) {

            $(parent).find('.txt-amount').val(parseInt($(parent).find('.txt-amount').val())-1)
        }
        Update_Total_Price()
    })
})


////Chi tiet SP
//function positons() {
//    document.getElementById("positon").style.display = "block";
//    document.getElementById("photo-info").style.display = "none";
//    document.getElementById("lich-trinh-1").style.background = "red";
//    document.getElementById("lich-trinh-2").style.background = "white";
//    //document.getElementById("positon").style.height = "800px"
//}

//function photoinfos() {
//    document.getElementById("positon").style.display = "none";
//    document.getElementById("photo-info").style.display = "block";
//    document.getElementById("lich-trinh-2").style.background = "red";
//    document.getElementById("lich-trinh-1").style.background = "white";
//    //document.getElementById("photo-info").style.height = "1200px"
//}