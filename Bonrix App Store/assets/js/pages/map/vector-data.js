var MapsVector = function() {
    var e = function(e) {
        var o = {
            map: "world_en",
            backgroundColor: null,
            borderColor: "#333333",
            borderOpacity: .5,
            borderWidth: 1,
            color: "#c6c6c6",
            enableZoom: !0,
            hoverColor: "#9dbd78",
            hoverOpacity: null,
            values: sample_data,
            normalizeFunction: "linear",
            scaleColors: ["#E8E8E8", "#C1C1C5"],
            selectedColor: "#b6ce9a",
            selectedRegion: null,
            showTooltip: !0,
            onRegionOver: function(e, o) {
                "ca" == o && e.preventDefault()
            },
            onRegionClick: function(e, o, r) {
                var a = 'You clicked "' + r + '" which has the code: ' + o.toUpperCase();
                alert(a)
            }
        };
        o.map = e + "_en";
        var r = jQuery("#vmap_" + e);
        r && (r.width(r.parent().width()), r.vectorMap(o))
    };
    return {
        init: function() {
            e("world"), e("usa"), e("europe"), e("russia"), e("germany"), App.addResizeHandler(function() {
                e("world"), e("usa"), e("europe"), e("russia"), e("germany")
            })
        }
    }
}();
jQuery(document).ready(function() {
    MapsVector.init()
});