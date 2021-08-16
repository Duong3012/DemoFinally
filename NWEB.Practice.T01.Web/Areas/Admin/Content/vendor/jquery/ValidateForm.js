
$("#FormSaleOff").validate({
    rules: {
        SaleOff: "required",
    },

    messages: {
        SaleOff: "Please enter your SaleOff.",
    },

    submitHandler: function (form) {
        form.submit();
    }
});