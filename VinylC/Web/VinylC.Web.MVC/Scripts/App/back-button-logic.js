(function () {
    $("#ReturnBackButon").on('click', function (ev) {
        if (document.referrer.indexOf('Create') > -1) {
            window.history.back(2);
        }
        window.history.back(1);
    });
})();