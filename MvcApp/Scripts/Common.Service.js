var commonService = function () {

    this.get_Business = function () {
        //console.log("get_Business");

        return $.ajax({
            type: "GET",
            url: 'api/Business',//url: 'Business/Post',
            data: "",
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (dataValues) {
                //console.log(dataValues);
                //console.log(dataValues.d);
            },
            //Something went wrong with webservice?
            failure: function (dataValues) {
                alert("WebService Failure: " + dataValues.d);
            },
            error: function (dataValues) {
                alert("WebService Error: " + dataValues.d);
            }
        });
    };

    this.post_Business = function (obj) {
        console.log("post_Business");
        console.log(obj);

        return $.ajax({
            type: "POST",
            url: 'api/Business',//url: 'Business/Post',
            data: JSON.stringify(obj),
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (dataValues) {
                //console.log(dataValues);
                //console.log(dataValues.d);
            },
            //Something went wrong with webservice?
            failure: function (dataValues) {
                alert("WebService Failure: " + dataValues.d);
            },
            error: function (dataValues) {
                alert("WebService Error: " + dataValues.d);
            }
        });
    };

    this.post_Customer = function (obj) {
        console.log("post_Customer");
        console.log(obj);

        return $.ajax({
            type: "POST",
            url: 'api/Customer',//url: 'Business/Post',
            data: JSON.stringify(obj),
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (dataValues) {
                //console.log(dataValues);
                //console.log(dataValues.d);
            },
            //Something went wrong with webservice?
            failure: function (dataValues) {
                alert("WebService Failure: " + dataValues.d);
            },
            error: function (dataValues) {
                alert("WebService Error: " + dataValues.d);
            }
        });
    };

    this.post_CustomerType = function (obj) {
        console.log("post_CustomerType");
        console.log(obj);

        return $.ajax({
            type: "POST",
            url: 'api/CustomerType',//url: 'Business/Post',
            data: JSON.stringify(obj),
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (dataValues) {
                //console.log(dataValues);
                //console.log(dataValues.d);
            },
            //Something went wrong with webservice?
            failure: function (dataValues) {
                alert("WebService Failure: " + dataValues.d);
            },
            error: function (dataValues) {
                alert("WebService Error: " + dataValues.d);
            }
        });
    };

    this.post_User = function (obj) {
        console.log("post_User");
        console.log(obj);

        return $.ajax({
            type: "POST",
            url: 'api/User',//url: 'Business/Post',
            data: JSON.stringify(obj),
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (dataValues) {
                //console.log(dataValues);
                //console.log(dataValues.d);
            },
            //Something went wrong with webservice?
            failure: function (dataValues) {
                alert("WebService Failure: " + dataValues.d);
            },
            error: function (dataValues) {
                alert("WebService Error: " + dataValues.d);
            }
        });
    };

    this.post_Task = function (obj) {
        console.log("post_Task");
        console.log(obj);

        return $.ajax({
            type: "POST",
            url: 'api/Task',//url: 'Business/Post',
            data: JSON.stringify(obj),
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (dataValues) {
                //console.log(dataValues);
                //console.log(dataValues.d);
            },
            //Something went wrong with webservice?
            failure: function (dataValues) {
                alert("WebService Failure: " + dataValues.d);
            },
            error: function (dataValues) {
                alert("WebService Error: " + dataValues.d);
            }
        });
    };

    this.post_TaskType = function (obj) {
        console.log("post_TaskType");
        console.log(obj);

        return $.ajax({
            type: "POST",
            url: 'api/TaskType',//url: 'Business/Post',
            data: JSON.stringify(obj),
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (dataValues) {
                //console.log(dataValues);
                //console.log(dataValues.d);
            },
            //Something went wrong with webservice?
            failure: function (dataValues) {
                alert("WebService Failure: " + dataValues.d);
            },
            error: function (dataValues) {
                alert("WebService Error: " + dataValues.d);
            }
        });
    };
};





 



 

