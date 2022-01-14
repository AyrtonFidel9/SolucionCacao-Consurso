// Function 1
$('input').on('blur keyup', function () {
    if ($(this).hasClass("input-validation-error")) {
        $(this).parent().find("div.error-msg").html($(this).parent().find("span").find("span").html());
        $(this).parent().find("div.error-msg").removeClass("hide");       
    } else {
        $(this).parent().find("div.error-msg").addClass("hide");
    }
});
// Function 2
$("form").submit(function () {
    if (!$(this).valid()) {
        ValidateFields();
    }
    else {
        return true;
    }
});
// Function 3
function ValidateFields() {
    $('input').each(function () {
        if ($(this).hasClass("input-validation-error")) {
            $(this).parent().find("div.error-msg").html($(this).parent().find("span").find("span").html());
            $(this).parent().find("div.error-msg").removeClass("hide");
        } else {
            $(this).parent().find("div.error-msg").addClass("hide");
        }
    });
}