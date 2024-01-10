$(document).ready(function () {
    toggleUrlInput();
    $("#toggle-dropdown").change(function () {
        toggleUrlInput();
    });
});

function toggleUrlInput() {
    var selectedValue = $("#toggle-dropdown").val();
    if (selectedValue === "TrainMotion") {
        $("#url-label").show();
        $("#url-input").show();
    } else {
        $("#url-input").hide();
        $("#url-label").hide();
    }
}