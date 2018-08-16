var stocksTable = {
    title: {
        text: "Remaning Ingredient Packs"
    },
    data: [
	{
	    type: "column",
	    dataPoints: stocksDataPoints
	}]
};

$(document).ready(function () {
    $(".remaining-stocks").CanvasJSChart(stocksTable);
});