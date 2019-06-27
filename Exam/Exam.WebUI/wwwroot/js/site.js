//$(function () {
//    $('#btnlogin').click(function () {
//        $("#form1").valid();
//    });
//}
function GetAnswer(sender, answerID) {
    $(sender).parent().siblings("input").val(answerID);
    $(sender).parent().siblings().children("input").css("background-color","white");
    $(sender).css("background-color","yellow");
}
function ajaxWired(sender) {

    $.ajax({
        url: "/AJAX/GetWiredContent",
        type: "GET",
        data: { "WiredID": $(sender).val() },
        success: function (data) {
            $("#write_status textarea").val(data);
        },
        error: function (e) {
            alert(e.status)
        }
    });
}
function examFinish(sender) {
    if ($("#question_1").val().length<1) $("#question_1").val(0);
    if ($("#question_2").val().length < 1) $("#question_2").val(0);
    if ($("#question_3").val().length < 1) $("#question_3").val(0);
    if ($("#question_4").val().length < 1) $("#question_4").val(0);
    var answers = $("#question_1").val() + "," + $("#question_2").val() + "," + $("#question_3").val() + "," + $("#question_4").val();
    $.ajax({
        url: "/AJAX/ExamResult",
        type: "GET",
        data: { "_answers": answers },
        success: function (data) {
            var i = 0;
            $.each(data, function (index, item) {
                i++;
                var q = "#question_" + i;
                var ans = "#option_" + $(q).val();
                if (item == 1) {
                    $(ans).css("background-color", "green");
                }
                else if (item == 0) {
                    $(ans).css("background-color", "red");
                }
                else {
                    $(ans).css("background-color", "blue");
                }
            })
        },
        error: function (e) {
            alert(e.status)
        }
    });
}