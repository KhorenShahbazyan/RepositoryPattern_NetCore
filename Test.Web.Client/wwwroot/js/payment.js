function GetOrderTotalPrice(id) {
    $.ajax({
        url: apiurl + '/GetOrderTotalPrice',
        type: 'GET',
        dataType: 'json',
        cache: false,
        data: { orderId: id },
        success: function (data) {
            if (data)
                document.getElementById("ordernumber").innerHTML = "Order N-" + id + " : Total Price-" + data;
        },
        error: function (textStatus, errorThrown) {
          
        }
    });
}

function AddPayment() {

    var _fname = document.getElementById("fname");
    var _lname = document.getElementById("lname");
    var _country = document.getElementById("country");
    var _state = document.getElementById("state");
    var _city = document.getElementById("city");
    var _address = document.getElementById("address");
    var _postalcode = document.getElementById("postalcode");
    var _phone = document.getElementById("phone");
    var _email = document.getElementById("email");

    var _payment = {
        FirstName: _fname.value,
        LastName: _lname.value,
        Address: _address.value,
        City: _city.value,
        State: _state.value,
        PostalCode: _postalcode.value,
        Country: _country.value,
        Phone: _phone.value,
        Email: _email.value
    }

    
    $.ajax({
        url: apiurl + '/AddPayment',
        type: 'POST',       
        cache: false,
        data: _payment,
        success: function (data) {
            
            _fname.innerHTML = "";  
            _lname.innerHTML = "";
            _country.innerHTML = "";
            _state.innerHTML = "";
            _city.innerHTML = "";
            _address.innerHTML = "";
            _postalcode.innerHTML = "";
            _phone.innerHTML = "";
            _email.innerHTML = "";            
            
          
        },
        error: function (textStatus, errorThrown) {
         
        }
    });
}