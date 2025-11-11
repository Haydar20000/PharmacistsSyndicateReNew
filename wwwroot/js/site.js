// This Code Belong For Diamond Key Software solutions

// for datepicker
$(document).ready(function () {
    $(".date-input-field").each(function () {
        var inputElement = $(this);

        inputElement.datepicker({
            format: "dd/mm/yyyy",
            autoclose: true,
            todayHighlight: true,

            // KEY CHANGE: REMOVE the 'container' setting
            // The calendar will now be appended to the document <body>

            orientation: "bottom right",
            rtl: true
        });
    });
});

