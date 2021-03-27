$.ajax({
    url: '/CPanel/Values/CountryAjax',
    dataType: "json",
    success: function (Data) {
        $(Data).each(function (index, value) {
            $("#CountryId").append($("<option></option>").val(value.id).html(value.name));
        })
        $.ajax({
            url: '/CPanel/Values/GovernorateAjax/' + $('#CountryId').val(),
            dataType: "json",
            success: function (Data) {
                $(Data).each(function (index, value) {
                    $("#GovernorateId").append($("<option></option>").val(value.id).html(value.name));
                })
                $.ajax({
                    url: '/CPanel/Values/StateAjax?idG=' + $('#GovernorateId').val() + '&idC=' + $('#CountryId').val(),
                    dataType: "json",
                    success: function (Data) {
                        $(Data).each(function (index, value) {
                            $("#StateId").append($("<option></option>").val(value.id).html(value.name));
                        })
                    }
                });
            }
        });
    }
});

$("#CountryId").change(function () {
    $('#GovernorateId option[value!=""]').remove();
    $('#StateId option[value!=""]').remove();
    $.ajax({
        url: '/CPanel/Values/GovernorateAjax/' + $('#CountryId').val(),
        dataType: "json",
        success: function (Data) {
            $(Data).each(function (index, value) {
                $("#GovernorateId").append($("<option></option>").val(value.id).html(value.name));
            })
        }
    });
});

$("#GovernorateId").change(function () {
    $('#StateId option[value!=""]').remove();
    $.ajax({
        url: '/CPanel/Values/StateAjax?idG=' + $('#GovernorateId').val() + '&idC=' + $('#CountryId').val(),
        dataType: "json",
        success: function (Data) {
            $(Data).each(function (index, value) {
                $("#StateId").append($("<option></option>").val(value.id).html(value.name));
            })
        }
    });
});