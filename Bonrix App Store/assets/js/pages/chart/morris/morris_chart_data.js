jQuery(document).ready(function() {
    'use strict';
    new Morris.Line({
        element: "morris_chart_1",
        data: [{
            y: "2006",
            a: 98,
            b: 88
        }, {
            y: "2007",
            a: 71,
            b: 68
        }, {
            y: "2008",
            a: 49,
            b: 37
        }, {
            y: "2009",
            a: 70,
            b: 61
        }, {
            y: "2010",
            a: 45,
            b: 35
        }, {
            y: "2011",
            a: 68,
            b: 59
        }, {
            y: "2012",
            a: 100,
            b: 92
        }],
        xkey: "y",
        ykeys: ["a", "b"],
        labels: ["Values A", "Values B"],
        lineColors: ["#F08080", "#20B2AA"],
        pointFillColors: ["#F08080", "#20B2AA"]
    }), new Morris.Area({
        element: "morris_chart_2",
        data: [{
            y: "2006",
            a: 98,
            b: 88
        }, {
            y: "2007",
            a: 71,
            b: 68
        }, {
            y: "2008",
            a: 49,
            b: 37
        }, {
            y: "2009",
            a: 70,
            b: 61
        }, {
            y: "2010",
            a: 45,
            b: 35
        }, {
            y: "2011",
            a: 68,
            b: 59
        }, {
            y: "2012",
            a: 100,
            b: 92
        }],
        xkey: "y",
        ykeys: ["a", "b"],
        labels: ["Series A", "Series B"],
        lineColors: ["#72BBC5", "#F79263"]
    }), new Morris.Bar({
        element: "morris_chart_3",
        data: [{
            y: "2006",
            a: 98,
            b: 88
        }, {
            y: "2007",
            a: 71,
            b: 68
        }, {
            y: "2008",
            a: 49,
            b: 37
        }, {
            y: "2009",
            a: 70,
            b: 61
        }, {
            y: "2010",
            a: 45,
            b: 35
        }, {
            y: "2011",
            a: 68,
            b: 59
        }, {
            y: "2012",
            a: 100,
            b: 92
        }],
        xkey: "y",
        ykeys: ["a", "b"],
        labels: ["Series A", "Series B"],
        barColors: function(a, b, c) {
            return "a" == b.key ? "#1F77B4" : "#FF7F0E"
        }
    }), new Morris.Donut({
        element: "morris_chart_4",
        data: [{
            label: "Sales type 1",
            value: 38
        }, {
            label: "Sales type 2",
            value: 16
        }, {
            label: "Sales type 3",
            value: 27
        }],
        colors: ["#EAA228", "#4BB2C5", "#559BD7"]
    })
});