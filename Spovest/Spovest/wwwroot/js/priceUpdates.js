// Создаем подключение к хабу SignalR
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/priceHub")
    .withAutomaticReconnect()
    .configureLogging(signalR.LogLevel.Information)
    .build();

// Обработчик получения обновлений цен
connection.on("ReceivePriceUpdates", (newPrices, oldPrices) => {
    console.log("Получены новые цены:", newPrices);
    console.log("Старые цены:", oldPrices);
    
    newPrices.forEach(newPrice => {
        // Находим соответствующую старую цену
        const oldPrice = oldPrices.find(p => p.playerId === newPrice.playerId);
        
        // Обновляем данные на странице NBA
        updateNBAPagePrices(newPrice, oldPrice);
        
        // Обновляем данные на странице профиля
        updateProfilePagePrices(newPrice);

        // Обновляем данные на странице игрока
        updatePlayerPagePrices(newPrice);
    });
});

// Функция обновления цен на странице NBA
function updateNBAPagePrices(newPrice, oldPrice) {
    // Обновляем цену покупки
    const purchaseElement = document.querySelector(`[data-player-id="${newPrice.playerId}"][data-price-type="purchase"]`);
    if (purchaseElement) {
        purchaseElement.textContent = newPrice.purchase_price.toFixed(2);
        flashElement(purchaseElement);
    }

    // Обновляем изменение цены
    const changeElement = document.querySelector(`[data-player-id="${newPrice.playerId}"][data-price-type="sale"]`);
    if (changeElement) {
        // Рассчитываем изменение цены
        const change = oldPrice 
            ? newPrice.purchase_price - oldPrice.purchase_price
            : 0;
        
        // Обновляем стиль и значение
        const parentElement = changeElement.parentElement;
        const changeFormatted = change.toFixed(2);
        
        if (change > 0) {
            parentElement.style.color = '#28a745';
            parentElement.innerHTML = `+${changeFormatted}`;
        } else if (change < 0) {
            parentElement.style.color = '#dc3545';
            parentElement.innerHTML = changeFormatted;
        } else {
            parentElement.style.color = '#000000';
            parentElement.innerHTML = changeFormatted;
        }

        flashElement(parentElement);
    }

    // Обновляем цену продажи
    const salePriceElement = document.querySelector(`[data-player-id="${newPrice.playerId}"][data-price-type="sale-price"]`);
    if (salePriceElement) {
        salePriceElement.textContent = newPrice.sale_price.toFixed(2);
        flashElement(salePriceElement);
    }
}

// Функция обновления цен на странице профиля
function updateProfilePagePrices(newPrice) {
    // Обновляем актуальную цену продажи
    const salePriceElement = document.querySelector(`[data-player-sale-price="${newPrice.playerId}"]`);
    if (salePriceElement) {
        const newSalePrice = newPrice.sale_price;
        salePriceElement.textContent = newSalePrice.toFixed(2);
        flashElement(salePriceElement);

        // Получаем цену покупки и количество акций
        const purchasePriceElement = document.querySelector(`[data-player-purchase-price="${newPrice.playerId}"]`);
        if (purchasePriceElement) {
            const purchasePrice = parseFloat(purchasePriceElement.textContent);
            const quantityElement = purchasePriceElement.closest('tr').querySelector('.share');
            if (quantityElement) {
                const quantity = parseInt(quantityElement.textContent);
                
                // Рассчитываем разницу в цене (за одну акцию)
                const priceDifference = ((newSalePrice - purchasePrice) * quantity);
                
                const earningsElement = purchasePriceElement.closest('tr').querySelector('.earning');
                
                if (earningsElement) {
                    // Показываем разницу в цене
                    if (parseFloat(priceDifference) >= 0) {
                        earningsElement.style.color = '';
                        earningsElement.innerHTML = `<i class="fas fa-dollar-sign"></i>${priceDifference}`;
                    } else {
                        earningsElement.style.color = '#dc3545';
                        earningsElement.innerHTML = `<i class="fas fa-dollar-sign"></i>${priceDifference}`;
                    }
                    flashElement(earningsElement);

                    // Выводим детали расчета в консоль для отладки
                    console.log(`Расчет для игрока ${newPrice.playerId}:`, {
                        newSalePrice,
                        purchasePrice,
                        quantity,
                        priceDifference
                    });
                }
            }
        }
    }
}

// Функция обновления цен на странице игрока
function updatePlayerPagePrices(newPrice) {
    // Обновляем текущую цену покупки
    const purchaseElement = document.querySelector(`[data-player-id="${newPrice.playerId}"][data-price-type="purchase"]`);
    if (purchaseElement) {
        purchaseElement.textContent = newPrice.purchase_price.toFixed(2);
        flashElement(purchaseElement);
    }

    // Обновляем общую стоимость (total value)
    const totalElement = document.querySelector(`[data-player-id="${newPrice.playerId}"][data-price-type="total"]`);
    if (totalElement) {
        // Получаем количество акций из span после total value
        const sharesText = totalElement.nextElementSibling.textContent;
        const shares = parseInt(sharesText.match(/\d+/)[0]); // Извлекаем число из текста "(X Shares)"
        
        // Рассчитываем общую стоимость
        const totalValue = newPrice.sale_price * shares;
        totalElement.textContent = totalValue.toFixed(2);
        flashElement(totalElement);

        console.log(`Обновление данных для игрока ${newPrice.playerId}:`, {
            currentPrice: newPrice.purchase_price,
            shares,
            totalValue
        });
    }
}

// Функция для создания эффекта мигания
function flashElement(element) {
    element.style.transition = 'background-color 0.5s ease';
    element.style.backgroundColor = 'rgba(255, 255, 0, 0.3)';
    setTimeout(() => {
        element.style.backgroundColor = 'transparent';
    }, 500);
}

// Функция для запуска подключения
async function startConnection() {
    try {
        await connection.start();
        console.log("Подключение к SignalR успешно установлено");
    } catch (err) {
        console.error("Ошибка при подключении к SignalR:", err);
        setTimeout(startConnection, 5000);
    }
}

// Обработчик потери соединения
connection.onclose(async () => {
    console.log("Соединение потеряно. Пробуем переподключиться...");
    await startConnection();
});

// Запускаем подключение при загрузке страницы
startConnection(); 