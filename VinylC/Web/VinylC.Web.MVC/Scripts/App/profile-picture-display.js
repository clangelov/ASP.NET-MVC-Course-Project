(function () {
    var canAddMore = false;

    $("#Avatar").on('focusout', function (ev) {

        var pic = $('#Avatar').val();
        if (pic) {

            var patt = new RegExp("([a-z\-_0-9\/\:\.]*\.(jpg|jpeg|png|gif))");
            var res = patt.test(pic);

            if (res && !canAddMore) {
                canAddMore = true;
                var img = $('<img id="dynamic">');
                img.attr('src', pic);
                img.css('width', '75%')
                img.addClass('img-responsive');
                img.addClass('center-block')
                img.appendTo('#PicturePreview');
            }

            if (res && canAddMore) {
                $('#dynamic').attr('src', pic);
            }
        }
    });
})();