// Создаем подключение к хабу SignalR
const balanceConnection = new signalR.HubConnectionBuilder()
    .withUrl("/balanceHub")
    .withAutomaticReconnect()
    .build();

let totalBalanceChart = null; // Объявляем переменную для хранения экземпляра графика

// Обработчик получения обновлений баланса
balanceConnection.on("ReceivePriceUpdates", (balanceHistory) => {
    console.log("Получены новые данные баланса:", balanceHistory);
    
    initTotalBalanceChart(balanceHistory);
});
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

    if (totalBalanceChart) {
        // Если график уже существует, обновляем его серии и категории
        totalBalanceChart.updateOptions({
            xaxis: {
                categories: dates
            },
            series: [{
                data: balances
            }]
        });
    } else {
        // В противном случае, создаем новый экземпляр графика
        totalBalanceChart = new ApexCharts(document.querySelector("#totalBalanceChart"), options);
        totalBalanceChart.render();
    }
}


// Функция для запуска подключения
async function startBalanceConnection() {
    try {
        await balanceConnection.start();
        console.log("Подключение к BalanceHub установлено");
    } catch (err) {
        console.error("Ошибка при подключении к BalanceHub:", err);
        setTimeout(startBalanceConnection, 5000);
    }
}

// Запускаем подключение при загрузке страницы
startBalanceConnection(); 