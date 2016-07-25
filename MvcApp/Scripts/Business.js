var business = function () {

    //var self = this;

    //this.get = function() {
    //    $.when(cs.get_Business()).done(function (get_Business_Result) {
    //        console.log("get_Business_Result");
    //        console.log(get_Business_Result);
    //        //console.log(get_Business_Result.length);

    //        var businessDataArray = [];

    //        for (var i = 0; i < get_Business_Result.length; i++) {
    //            businessDataArray.push(get_Business_Result[i]);
    //        }
    //        console.log("businessDataArray");
    //        console.log(businessDataArray);

    //        return businessDataArray;
    //    });
    //};

    this.validate = function () {
        var returnVal = true;

        $(".busErrorMsgContainer").empty();
        $(".validateBusinessForm").removeClass("inputError");
        var errors = [];

        if ($("#txtBusName").val() == "") {
            $("#txtBusName").addClass("inputError");
            errors.push("Business Name Required!");
        }

        if ($("#ddlBusType").val() == 0) {
            $("#ddlBusType").addClass("inputError");
            errors.push("Business Type Required!");
        }

        if ($("#txtBusEmail").val() == "") {
            $("#divBusEmail").addClass("inputError");
            errors.push("Email Required!");
        }

        //console.log(errors);
        if (errors.length > 0) {
            var returnVal = false;
            for (var i = 0; i < errors.length; i++) {
                var errorMarkup = $("<div class='alert alert-danger alert-dismissible' role='alert'>" + errors[i] + "<button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button></div>");
                $(".busErrorMsgContainer").append(errorMarkup);
            }
        }

        return returnVal;
    }

    this.post = function () {
        console.log("post_Business");
        var self = this;
        //Data being submitted passed validation (Submit)
        if (self.validate()) {

            var businessObj = {
                Name: $("#txtBusName").val()
                , BusinessTypeId: $("#ddlBusType").val()
                , Email: $("#txtBusEmail").val()
                , Phone1: $("#txtBusPhone1").val()
                , Phone1Ext: $("#txtBusPhone1Ext").val()
                , Phone2: $("#txtBusPhone2").val()
                , Phone2Ext: $("#txtBusPhone2Ext").val()
                , Address1: $("#txtBusAddress1").val()
                , Address2: $("#txtBusAddress2").val()
                , City: $("#txtBusCity").val()
                , State: $("#ddlState").val()
                , Zip: $("#txtBusZip").val()
                , Comments: $("#taBusComments").val()
            };

            //var businessObj = {
            //    Name: "Business Name Update"
            //    , BusinessTypeId: 1
            //    , Email: "Business Email"
            //    , Phone1: "Business Phone 1"
            //    , Phone1Ext: "Business Phone 1 Ext"
            //    , Phone2: "Business Phone 2"
            //    , Phone2Ext: "Business Phone 2 Ext"
            //    , Address1: "Business Address 1"
            //    , Address2: "Business Address 2"
            //    , City: "Business City"
            //    , State: "Business State"
            //    , Zip: "Business Zip"
            //    , Comments: "Business Comments"
            //};
            console.log(businessObj);

            $.when(cs.post_Business(businessObj)).done(function (post_Business_Result) {
                console.log("done");
                console.log(post_Business_Result);
            });
        }
    };

    this.bind = function () {
        console.log("bind");
        var self = this;
        $("#btnCreateBusiness").click(function () {
            console.log("Clicked business create");

            self.post();
        });

        $("#testTable").append($("<thead><tr><th>Business Id</th><th>Business Name</th><th>Business Type</th><th>City</th><th>State</th><th>Zip</th></tr></thead>"));
        var tbody = $("<tbody></tbody>");
        $("#testTable").append(tbody);

        console.log(objBusiness.length);

        for (var i = 0; i < objBusiness.length; i++) {
            //console.log("hit");
            tbody.append($("<tr><td>" + objBusiness[i][csts.BusinessId] + "</td><td><div class='updateBusiness linkElement'>" + objBusiness[i][csts.Name] + "</div></td><td>" + objBusiness[i][csts.BusinessTypeId] + "</td><td>" + objBusiness[i][csts.City] + "</td><td>" + objBusiness[i][csts.State] + "</td><td>" + objBusiness[i][csts.Zip] + "</td></tr>"));
            
            //tbody
        }

        $("#testTable").DataTable();

        $(".updateBusiness").click(function () {
            var row = $(this).closest("tr").children("td");
            var rowBusinessId = row.eq(0).html().replace('&nbsp;', '');
            //console.log(rowBusinessId);
            if (objBusinessHash[rowBusinessId]) {
                var localBusiness = objBusinessHash[rowBusinessId];
                console.log("localBusiness");
                console.log(localBusiness);

                var title = localBusiness[csts.BusinessId] + ": " + localBusiness[csts.Name];

                var template = Handlebars.compile($("#businessDetailTemplate").html());

                var obj = {
                    Id: localBusiness[csts.BusinessId]
                    , title: title
                    , width: csts.defaultWindowWidth
                    , height: csts.defaultWindowHeight
                    , content: template({obj: localBusiness})
                };

                cl.createWindow(obj);
            }
            

            
        });
    };
};

