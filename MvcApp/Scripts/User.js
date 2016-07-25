
function post_User() {
    var userObj = {
        userTypeId: $("#ddlUserType").val()
        , userName: $("#txtUserName").val()
        , email: $("#txtUserEmail").val()
        , firstName: $("#txtUserFName").val()
        , lastName: $("#txtUserLName").val()
        , mobilePhone: $("#txtUserMobilePhone").val()
        , address1: $("#txtUserAddress1").val()
        , address2: $("#txtUserAddress2").val()
        , city: $("#txtUserCity").val()
        , state: $("#ddlState").val()
        , zip: $("#txtUserZip").val()
        , comments: $("#taUserComments").val()
    };
    console.log(userObj);
}

function validateUser() {
    //$(".userErrorMsgContainer").remove();
    $(".userErrorMsgContainer").empty();
    $(".validateUserForm").removeClass("inputError");
    var errors = [];
    
    if ($("#ddlUserType").val() == 0) {
        $("#ddlUserType").addClass("inputError");
        errors.push("User Type Required!");
    }

    if ($("#txtUserName").val() == "") {
        $("#divUserName").addClass("inputError");
        errors.push("User Name Required!");
    }

    if ($("#txtUserEmail").val() == "") {
        $("#divUserEmail").addClass("inputError");
        errors.push("Email Required!");
    }

    if ($("#txtUserFName").val() == "") {
        $("#txtUserFName").addClass("inputError");
        errors.push("First Name Required!");
    }

    if ($("#txtUserLName").val() == "") {
        $("#txtUserLName").addClass("inputError");
        errors.push("Last Name Required!");
    }
    console.log(errors);
    if (errors.length > 0) {
        for (var i = 0; i < errors.length; i++) {
            var errorMarkup = $("<div class='alert alert-danger alert-dismissible' role='alert'>" + errors[i] + "<button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button></div>");
            $(".userErrorMsgContainer").append(errorMarkup);
            //$(".userErrorMsgContainer").append(errors[i]);
            console.log("Why isnt this working");
        }
    }
    else {
        postUser();
    }
}