$(document).ready(function() {
    // Обработчик для кнопок торговли (buy/sell)
    $('.trade-btn').on('click', function() {
        // Получаем данные из data-атрибутов
        const playerId = $(this).data('player-id');
        const playerName = $(this).data('player-name');
        const playerPrice = $(this).data('player-price');
        const userBalance = $(this).data('user-balance');
        const shares = $(this).data('shares');
        const action = $(this).data('action');

        // Открываем модальное окно
        const tradeModal = new bootstrap.Modal(document.getElementById('tradeModal'));
        
        // Активируем соответствующую вкладку
        $('.trade-tab').removeClass('active');
        $('.trade-tab[data-tab="' + action + '"]').addClass('active');
        $('.trade-tab-content').removeClass('active');
        $('#' + action + 'Content').addClass('active');

        // Заполняем общие данные
        $('#' + action + 'PlayerId').val(playerId);
        $('#' + action + 'CurrentPrice').text(playerPrice);

        if (action === 'buy') {
            $('#userBalance').text(userBalance);
            updateBuyTotal();
        } else {
            $('#userShares').text(shares);
            updateSellTotal();
        }

        // Показываем модальное окно
        tradeModal.show();
    });

    // Обработчик переключения вкладок
    $('.trade-tab').on('click', function() {
        const tab = $(this).data('tab');
        $('.trade-tab').removeClass('active');
        $(this).addClass('active');
        $('.trade-tab-content').removeClass('active');
        $('#' + tab + 'Content').addClass('active');
    });

    // Обработчики кнопок +/-
    $('.minus-btn').on('click', function() {
        const input = $(this).siblings('input[type="number"]');
        const currentValue = parseInt(input.val());
        if (currentValue > 1) {
            input.val(currentValue - 1);
            input.trigger('change');
        }
    });

    $('.plus-btn').on('click', function() {
        const input = $(this).siblings('input[type="number"]');
        const currentValue = parseInt(input.val());
        const maxValue = input.attr('id') === 'sellQuantity' 
            ? parseInt($('#userShares').text()) 
            : Math.floor(parseFloat($('#userBalance').text()) / parseFloat($('#buyCurrentPrice').text()));
        
        if (currentValue < maxValue) {
            input.val(currentValue + 1);
            input.trigger('change');
        }
    });

    // Обработчики изменения количества акций
    $('#buyQuantity').on('change', updateBuyTotal);
    $('#sellQuantity').on('change', function() {
        const quantity = parseInt($(this).val());
        const maxShares = parseInt($('#userShares').text());
        
        if (quantity > maxShares) {
            $(this).val(maxShares);
        }
        updateSellTotal();
    });

    // Функция обновления общей стоимости покупки
    function updateBuyTotal() {
        const quantity = parseInt($('#buyQuantity').val());
        const price = parseFloat($('#buyCurrentPrice').text());
        const userBalance = parseFloat($('#userBalance').text());
        const total = quantity * price;
        const maxPossibleShares = Math.floor(userBalance / price);

        $('#buyTotalCost').text(total.toFixed(2));
        $('#maxPossibleShares').text(maxPossibleShares);

        // Проверяем, достаточно ли средств
        if (total > userBalance) {
            $('#confirmTradeBtn').prop('disabled', true);
            $('#buyQuantity').addClass('is-invalid');
            $('#buyError').text(`Недостаточно средств. Максимально возможное количество акций для покупки: ${maxPossibleShares}`);
            $('#buyError').show();
        } else {
            $('#confirmTradeBtn').prop('disabled', false);
            $('#buyQuantity').removeClass('is-invalid');
            $('#buyError').hide();
        }
    }

    // Функция обновления общей стоимости продажи
    function updateSellTotal() {
        const quantity = parseInt($('#sellQuantity').val());
        const price = parseFloat($('#sellCurrentPrice').text());
        const userShares = parseInt($('#userShares').text());
        const total = quantity * price;

        // Устанавливаем максимальное значение для поля ввода
        $('#sellQuantity').attr('max', userShares);
        
        // Обновляем информацию о текущем количестве акций
        $('#currentShares').text(userShares);
        $('#sellTotalReturn').text(total.toFixed(2));

        // Проверяем, достаточно ли акций
        if (quantity > userShares) {
            $('#confirmTradeBtn').prop('disabled', true);
            $('#sellQuantity').addClass('is-invalid');
            $('#sellError').text(`У вас недостаточно акций. Доступно для продажи: ${userShares}`);
            $('#sellError').show();
        } else {
            $('#confirmTradeBtn').prop('disabled', false);
            $('#sellQuantity').removeClass('is-invalid');
            $('#sellError').hide();
        }
    }

    // Обработчик кнопки подтверждения
    $('#confirmTradeBtn').on('click', function() {
        const activeTab = $('.trade-tab.active').data('tab');
        const playerId = $('#' + activeTab + 'PlayerId').val();
        const quantity = parseInt($('#' + activeTab + 'Quantity').val());

        // Дополнительная проверка перед отправкой
        if (activeTab === 'buy') {
            const price = parseFloat($('#buyCurrentPrice').text());
            const userBalance = parseFloat($('#userBalance').text());
            const total = quantity * price;
            
            if (total > userBalance) {
                $('#buyError').text('Недостаточно средств для совершения покупки');
                $('#buyError').show();
                return;
            }
        } else {
            const userShares = parseInt($('#userShares').text());
            if (quantity > userShares) {
                $('#sellError').text('Недостаточно акций для продажи');
                $('#sellError').show();
                return;
            }
        }

        // Отправляем запрос на сервер
        $.post('/Main/' + activeTab.charAt(0).toUpperCase() + activeTab.slice(1), {
            playerId: playerId,
            quantity: quantity
        })
        .done(function(response) {
            if (response.success) {
                // Закрываем модальное окно
                bootstrap.Modal.getInstance(document.getElementById('tradeModal')).hide();
                
                // Перезагружаем страницу для обновления данных
                location.reload();
            } else {
                // Показываем сообщение об ошибке в соответствующем месте
                $('#' + activeTab + 'Error').text('Произошла ошибка при выполнении операции');
                $('#' + activeTab + 'Error').show();
            }
        })
        .fail(function(jqXHR) {
            let errorMessage = 'Произошла ошибка при выполнении операции';
            if (jqXHR.responseJSON && jqXHR.responseJSON.message) {
                errorMessage = jqXHR.responseJSON.message;
            }
            $('#' + activeTab + 'Error').text(errorMessage);
            $('#' + activeTab + 'Error').show();
        });
    });
}); 