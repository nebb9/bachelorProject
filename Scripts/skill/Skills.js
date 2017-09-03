

    $('.btn-bootstrap-dialog').click(function () {
        var url = $('#bootstrapDialog').data('url');

        $.get(url, function (data) {
            $('#bootstrapDialog').html(data);

            $('#bootstrapDialog').modal('show');
        });
    });
