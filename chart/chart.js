
$(document).ready(function () {
    $ajax({
        type: "POST",
        url: 'NRs1/Stat',
        data: JSON.stringify({}),
        contentType: "application/json:charset=utf-8",
        dataType: "json",
        success: function (json) {
            var values = json.Chart;
            var delivre = parseInt(values[0]);
            var nontraite = parseInt(values[1]);
            var encours = parseInt(values[2]);

            Highcharts.chart('container', {
                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false,
                    type: 'pie'
                },
                title: {
                    text: 'Browser market shares in January, 2018'
                },
                tooltip: {
                    pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                },
                accessibility: {
                    point: {
                        valueSuffix: '%'
                    }
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: false
                        },
                        showInLegend: true
                    }
                },
                series: [{
                    name: 'Count',
                    colorByPoint: true,
                    data: [{
                        name: 'Delivre',
                        y: delivre,
                        sliced: true,
                        selected: true
                    }, {
                        name: 'Non traite',
                            y: nontraite
                    }, {
                        name: 'En cours',
                            y: encours
                    }]
                }]
            });
        }
    })
});



        
