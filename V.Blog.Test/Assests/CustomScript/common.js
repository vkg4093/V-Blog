$(".OnlyNumeric").keydown(function (event) {
    // Allow: backspace, delete, tab, escape, and enter
    if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || event.keyCode == 13 ||
        // Allow: Ctrl+A
        (event.keyCode == 65 && event.ctrlKey === true) ||
        // Allow: home, end, left, right
        (event.keyCode >= 35 && event.keyCode <= 39)) {
        // let it happen, don't do anything
        return;
    }
    else {
        // Ensure that it is a number and stop the keypress
        if (event.shiftKey || (event.keyCode <= 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
            event.preventDefault();
        }
    }
});

$(".NumericOnly").keydown(function (event) {

    // Allow: backspace, delete, tab, escape, and enter
    if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || event.keyCode == 13 ||
        // Allow: Ctrl+A
            (event.keyCode == 65 && event.ctrlKey === true) ||
        // Allow: home, end, left, right
            (event.keyCode >= 35 && event.keyCode <= 39)) {
        // let it happen, don't do anything
        return;
    }
    else {
        // Ensure that it is a number and stop the keypress
        if (event.shiftKey || (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
            event.preventDefault();
        }
    }
});

$(".AlphabeticOnly").keypress(function (e) {
    var key;
    key = e.which ? e.which : e.keyCode;
    if ((key >= 65 && key <= 91) || (key >= 97 && key < 123) || key == 8 || key == 9 || (key >= 37 && key <= 40) || key == 46 || /*key == 35 || key == 36 ||*/key == 116) {
        return true;
    }
    else {
        return false;
    }
});

$(".AlphabaticWithSpace").keypress(function (e) {
    var key;
    key = e.which ? e.which : e.keyCode;
    if ((key >= 65 && key <= 91) || (key >= 97 && key < 123) || key == 8 || key == 9 || key == 32 || (key >= 37 && key <= 40) || key == 46 || /*key == 35 || key == 36 ||*/key == 116) {
        return true;
    }
    else {
        return false;
    }
});
//--------- This is the jquery code that would be used to set all the textboxes with class AlphaNumericOnly as to accept Alpha-numerics only -------------//
$(".AlphaNumericOnly").keypress(function (e) {
    var key;
    key = e.which ? e.which : e.keyCode;
    if ((key >= 65 && key <= 90) || (key == 32) || (key >= 97 && key <= 122) || key == 8 || key == 9 || key == 32 || (key >= 37 && key <= 40) || key == 46 || /* key == 35 || key == 36 ||*/key == 116 || (key >= 48 && key <= 57)) {
        return true;
    }
    else {
        return false;
    }
}); //End
