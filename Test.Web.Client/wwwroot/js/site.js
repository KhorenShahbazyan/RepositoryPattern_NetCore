// Write your Javascript code.

var apiurl = 'http://localhost:58245//api';

$(function () {  
        $.ajax({
            url: apiurl + '/Categories',
            type: 'GET',
            dataType: 'json',
            cache: false,
            data: {},
            success: function (data) {               
                PrepareCategoryList(data);
            }
        });  
});

function GetProducts(category) {
    $.ajax({
        url: apiurl + '/Products',
        type: 'GET',
        dataType: 'json',
        cache: false,
        data: { categoryid: category },
        success: function (data) {            
            PrepareProductGrid(data);
        }
    });
}

function changeCategory(value) {
    if (value.length == 0) {
        var row = "";
        $("#product").html(row); 
    }
    else {
        GetProducts(value);
    }
}
var _cart = [];
var _orderId = 0;
function AddCart(productid, productprice) {    
    var number = document.getElementById("number" + productid);

    var productorder = {
        productId: productid,
        count: parseInt(number.value),
        price: parseFloat(productprice)
    }
    _cart.push(productorder);

    var totalCount = 0;
    var totalPrice = 0;
    for (var i = 0; i < _cart.length; i++) {
        totalCount += _cart[i]["count"];
        totalPrice += (_cart[i]["price"] * _cart[i]["count"]);
    }

    document.getElementById("CartTotalCount").innerHTML = totalCount;
    document.getElementById("CartTotalPrice").innerHTML = totalPrice;
    number.value = "1";   
    
}

function AddOrder() {
    
    var productorders = [];
    if (Array.isArray(_cart)) {
        for (var i = 0; i < _cart.length; i++) {             
           productorders.push({ ProductId: _cart[i]["productId"], OrderCount: _cart[i]["count"] });
        }
    }    
    
    $.ajax({
        url: apiurl + '/AddOrder',
        type: 'POST',
        contentType: 'application/json',
        cache: false,
        data: JSON.stringify(productorders),
        success: function (data) {

            _orderId = data;
            document.getElementById("CartTotalCount").innerHTML = "0";
            document.getElementById("CartTotalPrice").innerHTML = "0";
            _cart = []; 
            document.getElementById("yourcart").display = 'none';  
        }
    });
}

  

// Prepare 
function PrepareCategoryList(data) {
    var sel = document.getElementById('CategoryList');
    if (sel != undefined) {
        data.forEach(function (item, index) {
            var opt = document.createElement('option');
            opt.innerHTML = item.name;
            opt.value = item.id;
            sel.appendChild(opt);
        });

        var seletedcategory = sel.options[sel.selectedIndex].value;
        GetProducts(seletedcategory);
    }
}

function PrepareProductGrid(data) {
    var row = "";
    $.each(data, function (index, item) {
        row += '<tr>' +
                    '<td>' + item.name + '</td> ' +
                    '<td> ' + item.description + '</td >' +
                    '<td> ' + item.price + '</td >' +
            '<td> <input class="ordercount" type="number" id="number' + item.id + '" value="1" min="1" max="100" /> ' +
            '<input type="button" value="Add" onclick="AddCart(' + item.id + ', ' + item.price + ' )">'
                    '</td >' +                    
               '</tr>';
    });
    $("#product").html(row);  
} 

function redirectShopping() {
    var info = document.getElementById("yourcart");          
    if (_orderId == 0) {
        info.style.display = 'block';        
    }
    else {
        info.style.display = 'none';  
        window.location.href = '/Home/RedirectToShopping?orderId=' + _orderId;
    }
}

function redirect(action) {
    window.location.href = '/Home/' + action + '/ ';   
}

 




