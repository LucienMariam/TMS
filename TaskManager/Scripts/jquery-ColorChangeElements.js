$(document).ready(function () {
    $("a").mouseover(function () { $(this).css("color", "purple"); });
    $("a").mouseout(function () { $(this).css("color", "gray"); });
    $("a").click(function () { $(this).css("color", "green"); });
});