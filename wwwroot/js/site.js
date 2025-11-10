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

// $(document).ready(function () {
//     $(".date-input-field").each(function () {
//         var inputElement = $(this);

//         // **KEY CHANGE:** Get the actual DOM element of the wrapper, not its ID.
//         // We use [0] to get the raw DOM element from the jQuery object.
//         var containerElement = inputElement.closest('.date-wrapper')[0];

//         inputElement.datepicker({
//             format: "dd/mm/yyyy",
//             autoclose: true,
//             todayHighlight: true,

//             // Pass the DOM element directly to the 'container' option
//             container: containerElement,

//             orientation: "bottom right",
//             rtl: true
//         });
//     });
// });