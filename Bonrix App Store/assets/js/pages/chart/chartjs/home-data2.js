$(document).ready(function() 
		{
	new Chart(document.getElementById("bar-chart"), {
		type: 'bar',
		data: {
			labels: ["2013", "2014", "2015", "2016"],
			datasets: [
			           {
			        	   label: "Cost",
			        	   backgroundColor: "#3e95cd",
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
			        	   label: "Earing",
			        	   backgroundColor: "#8e5ea2",
			        	   data: [
			                      randomScalingFactor(),
			                      randomScalingFactor(),
			                      randomScalingFactor(),
			                      randomScalingFactor(),
			                      randomScalingFactor(),
			                      randomScalingFactor(),
			                      randomScalingFactor()
			                  ]
			           }
			           ]
		},
		options: {
			title: {
				display: true,
				text: 'University Earing & Cost (in Millions)'
			}
		}
	});
		});