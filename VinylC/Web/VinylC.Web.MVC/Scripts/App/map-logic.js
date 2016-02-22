(function () {

    $(document).ready(function () {
        Initialize();
    });

    function Initialize() {

        google.maps.visualRefresh = true;

        var firstElement = $(".list-group-item").first()[0];

        genereteMap(firstElement);

        $(".list-group-item.chengable").click(function (ev) {
            var element = ev.currentTarget;
            genereteMap(element);
        });
    }

    function genereteMap(element) {

        var Location = new google.maps
            .LatLng(parse(element.getAttribute('data-longitude')),
                    parse(element.getAttribute('data-latitude')));

        var mapOptions = {
            zoom: 15,
            center: Location
        };

        var map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);

        var marker = new google.maps.Marker({
            'position': new google.maps.LatLng(parse(element.getAttribute('data-longitude')),
                    parse(element.getAttribute('data-latitude'))),
            'map': map
        });

        marker.setIcon('http://maps.google.com/mapfiles/ms/icons/red-dot.png')

        var placeId = element.getAttribute('data-id') | 0;

        var infowindow = new google.maps.InfoWindow({
            content: '<div><form action="/Place/SendOpinion" method="post"><input type="hidden" value=' + placeId + ' name="placeId" /><textarea type="text" placeholder="Share your opinion" name="opinion" class="form-control" rows="3"></textarea><input type="submit" value="Submit" class="btn btn-xs btn-success full-width"></form></div>'
        });

        google.maps.event.addListener(marker, 'click', function () {
            infowindow.open(map, marker);
        });
    }

    function parse(st) {
        if (st.indexOf(",") === 2) {
            st = st.replace(".", "").replace(",", ".");
        } else {
            st = st.replace(",", "");
        }
        return parseFloat(st, 10)
    }
})();