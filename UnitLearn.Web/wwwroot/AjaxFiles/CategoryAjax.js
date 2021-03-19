$.ajax({
    url: '/CPanel/Values/MainCategoryContentAjax',
    dataType: "json",
    success: function (Data) {
        $(Data).each(function (index, value) {
            $("#MainCategoryId").append($("<option></option>").val(value.id).html(value.name));
        })
        $.ajax({
            url: '/CPanel/Values/SubCategoryContentAjax/' + $('#MainCategoryId').val(),
            dataType: "json",
            success: function (Data) {
                $(Data).each(function (index, value) {
                    $("#SubCategoryId").append($("<option></option>").val(value.id).html(value.name));
                })
            }
        });
    }
});

$("#MainCategoryId").change(function () {
    $('#SubCategoryId option[value!=""]').remove();
    $.ajax({
        url: '/CPanel/Values/SubCategoryContentAjax/' + $('#MainCategoryId').val(),
        dataType: "json",
        success: function (Data) {
            $(Data).each(function (index, value) {
                $("#SubCategoryId").append($("<option></option>").val(value.id).html(value.name));
            })
        }
    });
});