$.ajax({
    url: '/CPanel/Values/MainCategoryContentAjax',
    dataType: "json",
    success: function (Data) {
        $(Data).each(function (index, value) {
            $("#MainId").append($("<option></option>").val(value.id).html(value.name));
        })
        $.ajax({
            url: '/CPanel/Values/SubCategoryContentAjax/' + $('#MainId').val(),
            dataType: "json",
            success: function (Data) {
                $(Data).each(function (index, value) {
                    $("#SubId").append($("<option></option>").val(value.id).html(value.name));
                })
            }
        });
    }
});

$("#MainId").change(function () {
    $('#SubId option[value!="-1"]').remove();
    $.ajax({
        url: '/CPanel/Values/SubCategoryContentAjax/' + $('#MainId').val(),
        dataType: "json",
        success: function (Data) {
            $(Data).each(function (index, value) {
                $("#SubId").append($("<option></option>").val(value.id).html(value.name));
            })
        }
    });
});