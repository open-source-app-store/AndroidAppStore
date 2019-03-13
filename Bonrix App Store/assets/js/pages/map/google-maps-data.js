/**
 *  Document   : google-maps-data.js
 *  Author     : redstar
 *  Description: Google map data script
 *
 **/

var MapsGoogle = function() {
    var o = function() {
            new GMaps({
                div: "#basic_gmap",
                lat: 23.0128440,
                lng: 72.5289980
            })
        },
        t = function() {
            var o = new GMaps({
                div: "#gmap_marker",
                lat: 23.0196181,
                lng: 72.5287620
            });
            o.addMarker({
                lat: 23.0196181,
                lng: 72.5287620,
                title: "Lima",
                details: {
                    database_id: 42,
                    author: "HPNeo"
                },
                click: function(o) {
                    console.log && console.log(o), alert("You clicked in this marker")
                }
            }), o.addMarker({
                lat: 23.2599330,
                lng: 77.4126150,
                title: "Marker with InfoWindow",
                infoWindow: {
                    content: '<span style="color:#000">HTML Content!</span>'
                }
            }), o.setZoom(5)
        },
        n = function() {
            var o = new GMaps({
                div: "#gmap_polylines",
                lat: 23.0128440,
                lng: 72.5289980,
                click: function(o) {
                    console.log(o)
                }
            });
            path = [
                [23.0128440, 72.5289980],
                [23.0104542, 72.5297705],
                [23.0102172, 72.5270883],
                [23.0090717, 72.5275818],
                [23.0084989, 72.5235907],
                [23.0080447, 72.5189344],
                [23.0078077, 72.5148574],
            ], o.drawPolyline({
                path: path,
                strokeColor: "#e7505a",
                strokeOpacity: .6,
                strokeWeight: 6
            })
        },
        e = function() {
            var o = new GMaps({
                div: "#gmap_geo",
                lat: 23.0128440,
                lng: 72.5289980
            });
            GMaps.geolocate({
                success: function(t) {
                    o.setCenter(t.coords.latitude, t.coords.longitude)
                },
                error: function(o) {
                    alert("Geolocation failed: " + o.message)
                },
                not_supported: function() {
                    alert("Your browser does not support geolocation")
                },
                always: function() {}
            })
        },
        a = function() {
            var o = new GMaps({
                    div: "#gmap_geocoding",
                    lat: 23.0128440,
                    lng: 72.5289980
                }),
                t = function() {
                    var t = $.trim($("#gmap_geocoding_address").val());
                    GMaps.geocode({
                        address: t,
                        callback: function(t, n) {
                            if ("OK" == n) {
                                var e = t[0].geometry.location;
                                o.setCenter(e.lat(), e.lng()), o.addMarker({
                                    lat: e.lat(),
                                    lng: e.lng()
                                }), App.scrollTo($("#gmap_geocoding"))
                            }
                        }
                    })
                };
            $(document).on("click","#gmap_geocoding_btn",function(o) { 
                o.preventDefault(), t()
            }), $("#gmap_geocoding_address").keypress(function(o) {
                var n = o.keyCode ? o.keyCode : o.which;
                "13" == n && (o.preventDefault(), t())
            })
        },
        i = function() {
            var o = new GMaps({
                    div: "#gmap_polygons",
                    lat: 23.0128440,
                    lng: 72.5289980
                }),
                t = [
                    [23.0116195, 72.5221315],
                    [23.0092099, 72.5235478],
                    [23.0087557, 72.5197283],
                    [23.0105727, 72.5182048]
                ];
            o.drawPolygon({
                paths: t,
                strokeColor: "#BBD8E9",
                strokeOpacity: 1,
                strokeWeight: 3,
                fillColor: "#BBD8E9",
                fillOpacity: .6
            })
        },
        l = function() {
            var o = new GMaps({
                div: "#gmap_routes",
                lat: 23.0128440,
                lng: 72.5289980
            });
            $(document).on("click","#routes_start",function(t) { 
                t.preventDefault(), App.scrollTo($(this), 400), o.travelRoute({
                    origin: [23.0128440, 72.5289980],
                    destination: [23.0048648, 72.5013820],
                    travelMode: "driving",
                    step: function(t) {
                        $("#routes_instructions").append("<li>" + t.instructions + "</li>"), $("#routes_instructions li:eq(" + t.step_number + ")").delay(800 * t.step_number).fadeIn(500, function() {
                            o.setCenter(t.end_location.lat(), t.end_location.lng()), o.drawPolyline({
                                path: t.path,
                                strokeColor: "#131540",
                                strokeOpacity: .6,
                                strokeWeight: 6
                            })
                        })
                    }
                })
            })
        };
    return {
        init: function() {
            o(), t(), e(), a(), n(), i(), l()
        }
    }
}();
jQuery(document).ready(function() {
	'use strict';
    MapsGoogle.init()
});