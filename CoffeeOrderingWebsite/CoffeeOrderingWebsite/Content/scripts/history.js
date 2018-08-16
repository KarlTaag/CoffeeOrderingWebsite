var orderTable = {
    title: {
        text: "Drink Order Distribution"
    },
    data: [
	{	  
	    type: "column",
	    dataPoints: historyDataPoints
	}]
};

$(document).ready(function () {
    $(".distribution").CanvasJSChart(orderTable);
});
