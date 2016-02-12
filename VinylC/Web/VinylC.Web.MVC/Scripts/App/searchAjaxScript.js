(function () {
    $('#SearchString').on('input', (function () {
        var controller = $(location).attr('pathname').split('/')[1];
        var url = '/' + controller + '/Search';

        if (this.value.length >= 3) {
            var query = $('#SearchString').val();

            $.get(url, { searchString: query }, function (data) {
                $("#all-pages").hide();
                $("#products-pagination").hide();
                $("#search-options").hide();
               
                $("#ajax-search-results").html(data)
                    .show();
            });
        }

        if (this.value.length === 0) {
            $("#all-pages").show();
            $("#products-pagination").show();
            $("#search-options").show();
            $("#ajax-search-results").hide()
        }
    }));
})();