function placeOrder(orderNumber){
    console.log("Customer Order:", orderNumber);

    cookAndDeliver(function(){
        console.log("Delivering food for order number:", orderNumber);
    });
}

function cookAndDeliver(callback){
    setTimeout(callback, 5000);
}

placeOrder(100);
placeOrder(101);