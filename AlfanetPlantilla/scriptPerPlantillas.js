function pageLoad() {
    $(".txtDependencias").autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Ajax.asmx/GetDependencias",
                data: "{'keyword':'" + request.term + "'}",
                dataType: "json",
                success: function (data) {
                    response(data.d);
                },
                error: function (xhr, status, error) {
                    alert('Uncaught Error.\n' + xhr.responseText);
                }
            });
        },
        minLength: 2
    });
}