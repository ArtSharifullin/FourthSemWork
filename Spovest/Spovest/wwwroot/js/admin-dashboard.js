/**
 * Инициализация линейного графика для отображения изменения общего баланса пользователей
 * @param {Array<Object>} balanceHistory - Массив объектов с Date и TotalBalance
 */
function initTotalBalanceChart(balanceHistory) {
    const dates = balanceHistory.map(item => new Date(item.date).toLocaleDateString('ru-RU'));
    const balances = balanceHistory.map(item => item.totalBalance);

    const options = {
        series: [{
            name: "Общий баланс",
            data: balances
        }],
        chart: {
            height: 450,
            type: 'line',
            zoom: {
                enabled: false
            }
        },
        dataLabels: {
            enabled: false
        },
        stroke: {
            curve: 'smooth'
        },
        title: {
            text: 'Изменение общего баланса',
            align: 'left'
        },
        grid: {
            row: {
                colors: ['#f3f3f3', 'transparent'], // takes 2 colors for the grid lines
                opacity: 0.5
            },
        },
        xaxis: {
            categories: dates,
            title: {
                text: 'Дата'
            }
        },
        yaxis: {
            title: {
                text: 'Баланс ($)'
            },
            labels: {
                formatter: function (val) {
                    return val.toLocaleString('ru-RU', { style: 'currency', currency: 'USD' });
                }
            }
        },
        tooltip: {
            y: {
                formatter: function (val) {
                    return val.toLocaleString('ru-RU', { style: 'currency', currency: 'USD' });
                }
            }
        }
    };

    const chart = new ApexCharts(document.querySelector("#totalBalanceChart"), options);
    chart.render();
}

// Экспортируем функцию для использования в других файлах
window.initTotalBalanceChart = initTotalBalanceChart; 