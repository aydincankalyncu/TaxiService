

$("#ToInfo").on("change", function () {
    var jsonData = { fromId: $("#FromInfo").val(), toId: $(this).val() };
    // your get JSON call goes here

    $.ajax({
        type: "POST",
        url: "/Home/GetCardInfo",
        dataType: 'json',
        data: jsonData,
        success: function (data) {
            $("#distance").empty();
            $("#travelTime").empty();
            $("#totalPrice").empty();
            if (data) {
                $("#distance").append("Distance approx: " + data.distance + "km.");
                $("#travelTime").append("Travel Time approx: " + data.travelTime + "minutes.");
                $("#totalPrice").append("Total Price: " + data.oneWayPrice + "€");
            }
        },

        error: function () {
            alert("Hata Oluştu");
        },
        onbeforeclose: function () {
            return onbeforeclose();
        }
    });
});

$("#datepicker").on("click", function () {
    $("#datepicker").datepicker().show();

});

$("#transferType1").on("click", function () {
    $("#testDiv").removeAttr("style").hide();
});

$("#transferType2").on("click", function () {
    $("#testDiv").show();
});

$("#FromInfo1").on("change", function () {
    var jsonData = { fromId: $(this).val() };
    // your get JSON call goes here

    $.ajax({
        type: "POST",
        url: "/Home/DestinationAddress",
        dataType: 'json',
        data: jsonData,
        success: function (data) {
            $("#ToInfo1").empty();
            for (var i = 0; i < data.length; i++) {
                $("#ToInfo1").append("<option value = " + data[i].id + " +>" + data[i].name + "</option>");
            }
            $("#ToInfo1").prop("disabled", false);
        },

        error: function () {
            alert("Hata Oluştu");
        },
        onbeforeclose: function () {
            return onbeforeclose();
        }
    });
});

$("#FromInfo2").on("change", function () {
    var jsonData = { fromId: $(this).val() };
    // your get JSON call goes here

    $.ajax({
        type: "POST",
        url: "/Home/DestinationAddress",
        dataType: 'json',
        data: jsonData,
        success: function (data) {
            $("#ToInfo2").empty();
            for (var i = 0; i < data.length; i++) {
                $("#ToInfo2").append("<option value = " + data[i].id + " +>" + data[i].name + "</option>");
            }
            $("#ToInfo2").prop("disabled", false);
            TestMet();
        },

        error: function () {
            alert("Hata Oluştu");
        },
        onbeforeclose: function () {
            return onbeforeclose();
        }
    });
});

$("#ToInfo2").on("change", function () {
    TestMet();
});

function TestMet() {
    var jsonData = { fromId: $("#FromInfo2").val(), toId: $("#ToInfo2").val() };
    // your get JSON call goes here

    $.ajax({
        type: "POST",
        url: "/Home/GetCardInfo",
        dataType: 'json',
        data: jsonData,
        success: function (data) {
            $("#distance").empty();
            $("#travelTime").empty();
            $("#totalPrice").empty();
            if (data) {
                $("#distance").append("Distance approx: " + data.distance + "km.");
                $("#travelTime").append("Travel Time approx: " + data.travelTime + "minutes.");
                $("#totalPrice").append("Total Price: " + data.oneWayPrice + "€");
            }
        },

        error: function () {
            alert("Hata Oluştu");
        },
        onbeforeclose: function () {
            return onbeforeclose();
        }
    });
}


//$(document).ready(function () {
//    var cultureInfo = $("#languageSelector").val();
//    if (cultureInfo == "de") {
//        $('#book_pick_date,#book_off_date').datepicker({
//            language: "de"
//        });
//    }
//    else if (cultureInfo == "ru") {
//        $('#book_pick_date,#book_off_date').datepicker({
//            language: "ru"
//        });
//    }
    
//});

