var b = new business();
var cs = new commonService();
var cl = new commonLogic();
var csts = new constants();

var objBusiness = [];
var objBusinessHash = {};

$(document).ready(function () {
    console.log("ready!");

    bindHandlebarsTemplates();

    pageLoad();

    switchView();

    //Show Dashboard by default
    $("#dashboardTemplate").show();
    showModal();

    // create DateTimePicker from input HTML element
    $("#datetimepicker").kendoDateTimePicker({
        value: new Date()
    });

    initAutocomplete();

    loadGlobalDataObjects();

    bindEventListeners();
});

//binds handlebars templates on initial load
function bindHandlebarsTemplates() {
    $("#divHandlebarsTemplate").append(Handlebars.compile($("#dashboardTemplate").html()));
    $("#divHandlebarsTemplate").append(Handlebars.compile($("#createBusinessTemplate").html()));
    $("#divHandlebarsTemplate").append(Handlebars.compile($("#createCustomerTemplate").html()));
    $("#divHandlebarsTemplate").append(Handlebars.compile($("#createUserTemplate").html()));
    $("#divHandlebarsTemplate").append(Handlebars.compile($("#createTaskTemplate").html()));
    $("#divHandlebarsTemplate").append(Handlebars.compile($("#createCustomerTypeTemplate").html()));
    $("#divHandlebarsTemplate").append(Handlebars.compile($("#createTaskTypeTemplate").html()));
    $("#divHandlebarsTemplate").append(Handlebars.compile($("#viewBusinessTemplate").html()));
};

//binds misc jquery event listeners on initial load
function bindEventListeners() {
    //b.bind();
};

//sets up page for initial load
function pageLoad() {
    $(".hideSection").hide();
    $(".showOnLoad").addClass("active");
    $("#divDashboard").show();
};

function loadGlobalDataObjects() {
    //console.log("loadGlobalDataObjects");

    //Get Business Data / Populate Global Objects
    $.when(cs.get_Business()).done(function (ret) {
        //console.log("get_Business_Result");
        //console.log(ret);

        objBusiness = ret;

        for (var i = 0; i < objBusiness.length; i++) {

            var business = {
                BusinessId: objBusiness[i][csts.BusinessId]
                , Name: objBusiness[i][csts.Name]
                , BusinessTypeId: objBusiness[i][csts.BusinessTypeId]
                , Email: objBusiness[i][csts.Email]
                , Phone1: objBusiness[i][csts.Phone1]
                , Phone1Ext: objBusiness[i][csts.Phone1Ext]
                , Phone2: objBusiness[i][csts.Phone2]
                , Phone2Ext: objBusiness[i][csts.Phone2Ext]
                , Address1: objBusiness[i][csts.Address1]
                , Address2: objBusiness[i][csts.Address2]
                , City: objBusiness[i][csts.City]
                , State: objBusiness[i][csts.State]
                , Zip: objBusiness[i][csts.Zip]
                , Comments: objBusiness[i][csts.Comments]
            };

            objBusinessHash[objBusiness[i].BusinessId] = business;
        }

        console.log("objBusiness");
        console.log(objBusiness);
        console.log("objBusinessHash");
        console.log(objBusinessHash);

        b.bind();
    });
    
    
}

//determines what section to show
function switchView() {
    $(".linkSelect").click(function () {
        $(".active").removeClass("active");
        $(this).parent().addClass("active");
        $(".hideSection").hide();
        $("#" + $(this).data("show")).show();
    });
};



function showModal() {
    $("#btnShowModal").click(function () {
        //alert("clicked");

        var myWindow = $("#window"),
                        undo = $("#undo");

        undo.click(function () {
            myWindow.data("kendoWindow").open();
            undo.fadeOut();
        });

        function onClose() {
            undo.fadeIn();
        }

        //var headerHtml = "<div>test</div>"; 
        //headerHtml.append($("<span class='k-window-title'>Business Name goes here...</span>"));
        //$("#window_wnd_title").append("<span class='k-window-title'>Business Name goes here...</span>");
        myWindow.kendoWindow({
            width: "600px",
            height: "600px",
            title: "Business Name goes here...",
            //title: function () {
            //    $("#window_wnd_title").append("<span class='k-window-title'>Business Name goes here...</span>");
            //    //return $("<span class='k-window-title'>Business Name goes here...</span>");
            //},
            visible: false,
            actions: ["Pin","Minimize","Maximize","Close"],
            close: onClose
        }).data("kendoWindow").center().open();

    });
}

//Google Maps API Autocomplete logic
var placeSearch;
var autocomplete;
var componentForm = {
    street_number: 'short_name',
    route: 'long_name',
    locality: 'long_name',
    administrative_area_level_1: 'short_name',
    country: 'long_name',
    postal_code: 'short_name'
};



function initAutocomplete() {
    console.log("initAutocomplete");
    // Create the autocomplete object, restricting the search to geographical
    // location types.
    autocomplete = new google.maps.places.Autocomplete(
        /** @type {!HTMLInputElement} */(document.getElementById('autocomplete')),
        { types: ['geocode'] });
    console.log(document.getElementById('autocomplete'));
    console.log("autocomplete");
    console.log(autocomplete);
    // When the user selects an address from the dropdown, populate the address
    // fields in the form.
    autocomplete.addListener('place_changed', fillInAddress);
};

function fillInAddress() {
    console.log("fillInAddress");
    // Get the place details from the autocomplete object.
    var place = autocomplete.getPlace();

    for (var component in componentForm) {
        document.getElementById(component).value = '';
        document.getElementById(component).disabled = false;
    }

    // Get each component of the address from the place details
    // and fill the corresponding field on the form.
    for (var i = 0; i < place.address_components.length; i++) {
        var addressType = place.address_components[i].types[0];
        if (componentForm[addressType]) {
            var val = place.address_components[i][componentForm[addressType]];
            document.getElementById(addressType).value = val;
        }
    }
};

// Bias the autocomplete object to the user's geographical location,
// as supplied by the browser's 'navigator.geolocation' object.
function geolocate() {
    if (navigator.geolocation) {
        console.log(navigator.geolocation);
        navigator.geolocation.getCurrentPosition(function (position) {
            var geolocation = {
                lat: position.coords.latitude,
                lng: position.coords.longitude
            };
            var circle = new google.maps.Circle({
                center: geolocation,
                radius: position.coords.accuracy
            });
            //console.log("circle");
            //console.log(circle);
            autocomplete.setBounds(circle.getBounds());
        });
    }
};
