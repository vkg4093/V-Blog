$(function () {
    //multiple.select jquery
    $('#ms').change(function () {
        alert('Selected texts: ' + $(this).multipleSelect('getSelects', 'text'));

    }).multipleSelect({
        width: '100%'
    });
    //Custome function that reset the form and remove all the validation error 
    $.fn.resetValidation = function () {

        var $form = this.closest('form');

        //reset jQuery Validate's internals
        $form.validate().resetForm();

        //reset unobtrusive validation summary, if it exists
        $form.find("[data-valmsg-summary=true]")
            .removeClass("validation-summary-errors")
            .addClass("validation-summary-valid")
            .find("ul").empty();

        //reset unobtrusive field level, if it exists
        $form.find("[data-valmsg-replace]")
            .removeClass("field-validation-error")
            .addClass("field-validation-valid")
            .empty();

        return $form;
    };
});

function hideMessage() {
    setTimeout("$('#divMessage').hide();", 1000)
}

$(function () {

    $('#btnSubmit').click(function () {
        alert("Thanks you have subscribe successfully !!");
        $('#adPopup').modal('hide');
    });


});

var show = function () {
    //$('#adPopup').modal('show');
};

$(window).load(function () {
    //var timer = window.setTimeout(show, 5000);
});
