
function GetOrderedProducts(id) {
    $.ajax({
        url: apiurl + '/Orderes',
        type: 'GET',
        dataType: 'json',
        cache: false,
        data: { orderId : id},
        success: function (data) {      
            PrepareShoppingGrid(data);
        },
        error: function (textStatus, errorThrown) {          
        }
    });
}

function PrepareShoppingGrid(data) {
    var row = "";
    let _totalPrice = 0;
    let _totalCount = 0
    $.each(data, function (index, item) {
        _totalCount += item.count;
        _totalPrice += item.price;
        row += '<tr>' +
            '<td> <a href="/Home/ProductDetail/' + item.productId + '"> ' + item.productName + ' </a> </td> ' +
            '<td> ' + item.price + '</td >' +
            '<td> ' + item.count + '</td >' +
            '<td> <input type="button" value="Delete" onclick="DeleteProductOreder(' + item.productOrederId + ', ' +  item.orderId + ')"> </td >' +
            '</tr>';
    });
    if(row != "")
        row += '<tr class="total-row"> <td> TOTAL </td> <td> ' + _totalPrice + ' </td> <td>' + _totalCount + ' </td> <td> </td> </tr> '
    $("#shopping").html(row);
}


function DeleteProductOreder(id, orderId) {    
    $.ajax({
        url: apiurl + '/DeleteProductOreder',
        type: 'POST',        
        cache: false,
        data: { productOrderId : id },
        success: function (data) {
            GetOrderedProducts(orderId);
        }
    });
}
