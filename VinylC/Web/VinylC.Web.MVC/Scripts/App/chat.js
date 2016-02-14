(function () {
    var chat = $.connection.chat;

    chat.client.addMessage = function (name, message) { 
        $('#all-messages').prepend('<div class="alert alert-dismissible alert-info"><button type="button" class="close" data-dismiss="alert">×</button><p>' + htmlEscape(message) + '</p><p class="text-muted"><span class="glyphicon glyphicon-user"></span> ' + htmlEscape(name) + '</p></div>');
    };

    $.connection.hub.start().done(function () {
        $("#send-message-button").click(function () {
            var name = window.currentUsernameName;
            var message = $("#send-message-text").val();
            $("#send-message-text").val("").focus();

            chat.server.newMessage(name, message);
        });
    })
    .fail(function () {
        console.log('Could not Connect!');
    });

    var entityMap = {
        "&": "&amp;",
        "<": "&lt;",
        ">": "&gt;",
        '"': '&quot;',
        "'": '&#39;',
        "/": '&#x2F;'
    };

    function htmlEscape(string) {
        return String(string).replace(/[&<>"'\/]/g, function (symbol) {
            return entityMap[symbol];
        });
    };
})();