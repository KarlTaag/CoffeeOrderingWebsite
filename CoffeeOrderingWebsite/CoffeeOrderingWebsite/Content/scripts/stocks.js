var options2 = {
    title: {
        text: "Column Chart in jQuery CanvasJS"
    },
    data: [
	{
	    // Change type to "doughnut", "line", "splineArea", etc.
	    type: "column",
	    dataPoints: [
			{ label: "apple", y: 10 },
			{ label: "orange", y: 15 },
			{ label: "banana", y: 25 },
			{ label: "mango", y: 30 },
			{ label: "grape", y: 28 }
	    ]
	}
    ]
};

$(document).ready(function () {
    $("#chartContainer2").CanvasJSChart(options2);


});