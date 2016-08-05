var commonLogic = function () {

    this.createWindow = function (obj) {
        
        var kWindow = $("<div id='" + obj.Id + "'></div>");
        var undo = $("#undo");
        $("body").append(kWindow);
        
        undo.click(function () {
            kWindow.data("kendoWindow").open();
            undo.fadeOut();
        });

        function onClose() {
            undo.fadeIn();
        }

        //var headerHtml = "<div>test</div>"; 
        //headerHtml.append($("<span class='k-window-title'>Business Name goes here...</span>"));
        //$("#window_wnd_title").append("<span class='k-window-title'>Business Name goes here...</span>");
        kWindow.kendoWindow({
            width: obj.width,
            height: obj.height,
            title: obj.title,
            //title: function () {
            //    $("#window_wnd_title").append("<span class='k-window-title'>Business Name goes here...</span>");
            //    //return $("<span class='k-window-title'>Business Name goes here...</span>");
            //},
            visible: false,
            actions: ["Pin", "Minimize", "Maximize", "Close"],
            close: onClose
        }).data("kendoWindow");
        kWindow.data("kendoWindow").content(obj.content);
        kWindow.data("kendoWindow").center().open();

    };

    //GeoLocation Logging Logic
    this.getLocation = function () {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(showPosition);
        }
    };

    function showPosition(position) {
        console.log("showPosition");
        lat = position.coords.latitude;
        long = position.coords.longitude;
        $("#hdnLat").val(lat);
        $("#hdnLong").val(long);
    };

};