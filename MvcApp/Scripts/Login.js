$(document).ready(function () {

    $("#txtEmail").focus();

    var cl = new commonLogic();

    cl.getLocation();

    $("#btnLoginSubmit").click(function (e) {

        $(".inputError").removeClass("inputError");
        $(".ulErrorMsg").empty();

        var errors = [];

        if ($("#txtEmail").val() == "") {
            $("#txtEmail").addClass("inputError");
            errors.push("Email Required!");
        }

        if ($("#txtPassword").val() == "") {
            $("#txtPassword").addClass("inputError");
            errors.push("Password Required!");
        }
            
        if (errors.length > 0) {
            for (var i = 0; i < errors.length; i++) {
                $(".ulErrorMsg").append("<li>" + errors[i] + "</li>");
            }

            e.preventDefault();
        }
    });

});