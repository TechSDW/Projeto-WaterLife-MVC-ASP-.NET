const price_detail = document.getElementsByClassName("prod-details-prices");
for (i = 0; i < price_detail.length; i++) {
    const btn_cart = price_detail[i].addEventListener("click", addCart);
}

function addCart(event) {
    const name = event.target.parentElement.parentElement.children[0].innerText
        
}