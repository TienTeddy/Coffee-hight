
//function removeData(chart) {
//    chart.data.labels.pop();
//    chart.data.datasets.forEach((dataset) => {
//        dataset.data.pop();
//    });
//    chart.update();
//}

//addData(myChart, 'Tháng', [12]);

var data = {
    labels: ["January", "February", "March", "April", "May", "June", "July"],
    datasets: [{
        label: "Compras",
        backgroundColor: 'rgba(255, 99, 132, 0.2)',
        borderColor: 'rgba(255,99,132,1)',
        borderWidth: 1,
        data: [65, 59, 80, 81, 56, 55, 40],
    }]
};
var ctx = $("#myChart").get(0).getContext("2d");

var myBarChart = new Chart(ctx, {
    type: "pie",
    data: data,
});

$('#chart-button').click(function () {
    var newDataset = {
        label: "Vendas",
        backgroundColor: 'rgba(99, 255, 132, 0.2)',
        borderColor: 'rgba(99, 255, 132, 1)',
        borderWidth: 1,
        data: [10, 20, 30, 40, 50, 60, 70],
    }
    data.datasets.push(newDataset);
    myBarChart.update();
});