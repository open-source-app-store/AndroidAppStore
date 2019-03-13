
$(document).ready(function() {
	var MONTHS = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
    var config = {
        type: 'line',
        data: {
            labels: ["January", "February", "March", "April", "May", "June", "July"],
            datasets: [{
                label: "New Students",
                backgroundColor: window.chartColors.red,
                borderColor: window.chartColors.red,
                data: [
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor()
                ],
                fill: false,
            }, {
                label: "Old Students",
                fill: false,
                backgroundColor: window.chartColors.blue,
                borderColor: window.chartColors.blue,
                data: [
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor()
                ],
            }]
        },
        options: {
            responsive: true,
            title:{
                display:true,
                text:'UNIVERSITY SURVEY'
            },
            tooltips: {
                mode: 'index',
                intersect: false,
            },
            hover: {
                mode: 'nearest',
                intersect: true
            },
            scales: {
                xAxes: [{
                    display: true,
                    scaleLabel: {
                        display: true,
                        labelString: 'Month'
                    }
                }],
                yAxes: [{
                    display: true,
                    scaleLabel: {
                        display: true,
                        labelString: 'Students'
                    }
                }]
            }
        }
    };
    var ctx = document.getElementById("chartjs_line").getContext("2d");
    window.myLine = new Chart(ctx, config);
	});
        
      
$(document).ready(function() {
	var randomScalingFactor = function() {
        return Math.round(Math.random() * 100);
    };

    var config = {
        type: 'pie',
    data: {
        datasets: [{
            data: [
                randomScalingFactor(),
                randomScalingFactor(),
                randomScalingFactor(),
                randomScalingFactor(),
                randomScalingFactor(),
            ],
            backgroundColor: [
                window.chartColors.red,
                window.chartColors.orange,
                window.chartColors.yellow,
                window.chartColors.green,
                window.chartColors.blue,
            ],
            label: 'Dataset 1'
        }],
        labels: [
            "Red",
            "Orange",
            "Yellow",
            "Green",
            "Blue"
        ]
    },
    options: {
        responsive: true
    }
};

    var ctx = document.getElementById("chartjs_pie").getContext("2d");
    window.myPie = new Chart(ctx, config);
}); 

$(document).ready(function() {
	 var MONTHS = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
     var color = Chart.helpers.color;
     var barChartData = {
         labels: ["January", "February", "March", "April", "May", "June", "July"],
         datasets: [{
             label: 'New Students',
             backgroundColor: color(window.chartColors.red).alpha(0.5).rgbString(),
             borderColor: window.chartColors.red,
             borderWidth: 1,
             data: [
                 randomScalingFactor(),
                 randomScalingFactor(),
                 randomScalingFactor(),
                 randomScalingFactor(),
                 randomScalingFactor(),
                 randomScalingFactor(),
                 randomScalingFactor()
             ]
         }, {
             label: 'Old Students',
             backgroundColor: color(window.chartColors.blue).alpha(0.5).rgbString(),
             borderColor: window.chartColors.blue,
             borderWidth: 1,
             data: [
                 randomScalingFactor(),
                 randomScalingFactor(),
                 randomScalingFactor(),
                 randomScalingFactor(),
                 randomScalingFactor(),
                 randomScalingFactor(),
                 randomScalingFactor()
             ]
         }]

     };

         var ctx = document.getElementById("chartjs_bar").getContext("2d");
         window.myBar = new Chart(ctx, {
             type: 'bar',
             data: barChartData,
             options: {
                 responsive: true,
                 legend: {
                     position: 'top',
                 },
                 title: {
                     display: true,
                     text: 'Bar Chart'
                 }
             }
         });

	});

$(document).ready(function() {
	var randomScalingFactor = function() {
        return Math.round(Math.random() * 100);
    };

    var chartColors = window.chartColors;
    var color = Chart.helpers.color;
    var config = {
        data: {
            datasets: [{
                data: [
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor(),
                ],
                backgroundColor: [
                    color(chartColors.red).alpha(0.5).rgbString(),
                    color(chartColors.orange).alpha(0.5).rgbString(),
                    color(chartColors.yellow).alpha(0.5).rgbString(),
                    color(chartColors.green).alpha(0.5).rgbString(),
                    color(chartColors.blue).alpha(0.5).rgbString(),
                ],
                label: 'My dataset' // for legend
            }],
            labels: [
                "Red",
                "Orange",
                "Yellow",
                "Green",
                "Blue"
            ]
        },
        options: {
            responsive: true,
            legend: {
                position: 'right',
            },
            title: {
                display: true,
                text: 'Polar Area Chart'
            },
            scale: {
              ticks: {
                beginAtZero: true
              },
              reverse: false
            },
            animation: {
                animateRotate: false,
                animateScale: true
            }
        }
    };

        var ctx = document.getElementById("chartjs_polar");
        window.myPolarArea = Chart.PolarArea(ctx, config);

	});

$(document).ready(function() {
	var randomScalingFactor = function() {
        return Math.round(Math.random() * 100);
    };

    var config = {
        type: 'doughnut',
        data: {
            datasets: [{
                data: [
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor(),
                ],
                backgroundColor: [
                    window.chartColors.red,
                    window.chartColors.orange,
                    window.chartColors.yellow,
                    window.chartColors.green,
                    window.chartColors.blue,
                ],
                label: 'Dataset 1'
            }],
            labels: [
                "Red",
                "Orange",
                "Yellow",
                "Green",
                "Blue"
            ]
        },
        options: {
            responsive: true,
            legend: {
                position: 'top',
            },
            title: {
                display: true,
                text: 'Doughnut Chart'
            },
            animation: {
                animateScale: true,
                animateRotate: true
            }
        }
    };

        var ctx = document.getElementById("chartjs_doughnut").getContext("2d");
        window.myDoughnut = new Chart(ctx, config);
    
	});

$(document).ready(function() {
	var randomScalingFactor = function() {
        return Math.round(Math.random() * 100);
    };

    var color = Chart.helpers.color;
    var config = {
        type: 'radar',
        data: {
            labels: [["Eating", "Dinner"], ["Drinking", "Water"], "Sleeping", ["Designing", "Graphics"], "Coding", "Cycling", "Running"],
            datasets: [{
                label: "New Students",
                backgroundColor: color(window.chartColors.red).alpha(0.2).rgbString(),
                borderColor: window.chartColors.red,
                pointBackgroundColor: window.chartColors.red,
                data: [
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor()
                ]
            }, {
                label: "Old Students",
                backgroundColor: color(window.chartColors.blue).alpha(0.2).rgbString(),
                borderColor: window.chartColors.blue,
                pointBackgroundColor: window.chartColors.blue,
                data: [
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor(),
                    randomScalingFactor()
                ]
            },]
        },
        options: {
            legend: {
                position: 'top',
            },
            title: {
                display: true,
                text: 'Radar Chart'
            },
            scale: {
              ticks: {
                beginAtZero: true
              }
            }
        }
    };

        window.myRadar = new Chart(document.getElementById("radar_chart"), config);

   
	});

