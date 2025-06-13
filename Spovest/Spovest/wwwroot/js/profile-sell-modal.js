$(document).ready(function() {
    // Обработчик для кнопок продажи в профиле
    $('.sell-btn').on('click', function() {
        // Получаем данные из data-атрибутов
        const playerId = $(this).data('player-id');
        const playerName = $(this).data('player-name');
        const playerPrice = $(this).data('player-price');
        const shares = $(this).data('shares');

        // Открываем модальное окно
        const profileSellModal = new bootstrap.Modal(document.getElementById('profileSellModal'));
        
        // Заполняем данные в модальном окне
        $('#profilePlayerName').text(playerName);
        $('#profileSellPlayerId').val(playerId);
        $('#profileSellCurrentPrice').text(playerPrice);
        $('#profileUserShares').text(shares);
        $('#profileCurrentShares').text(shares);
        
        // Устанавливаем максимальное значение для поля ввода
        $('#profileSellQuantity').attr('max', shares);
        
        // Обновляем общую сумму
        updateProfileSellTotal();

        // Показываем модальное окно
        profileSellModal.show();
    });

    // Обработчики кнопок +/-
    $('.profile-minus-btn').on('click', function() {
        const input = $(this).siblings('input[type="number"]');
        const currentValue = parseInt(input.val());
        if (currentValue > 1) {
            input.val(currentValue - 1);
            input.trigger('change');
        }
    });

    $('.profile-plus-btn').on('click', function() {
        const input = $(this).siblings('input[type="number"]');
        const currentValue = parseInt(input.val());
        const maxShares = parseInt($('#profileUserShares').text());
        
        if (currentValue < maxShares) {
            input.val(currentValue + 1);
            input.trigger('change');
        }
    });

    // Обработчик кнопки "Sell All"
    $('#sellAllProfileBtn').on('click', function() {
        const maxShares = parseInt($('#profileUserShares').text());
        $('#profileSellQuantity').val(maxShares);
        $('#profileSellQuantity').trigger('change');
    });

    // Обработчик изменения количества акций
    $('#profileSellQuantity').on('change', function() {
        const quantity = parseInt($(this).val());
        const maxShares = parseInt($('#profileUserShares').text());
        
        if (quantity > maxShares) {
            $(this).val(maxShares);
        }
        updateProfileSellTotal();
    });

    // Функция обновления общей стоимости продажи
    function updateProfileSellTotal() {
        const quantity = parseInt($('#profileSellQuantity').val());
        const price = parseFloat($('#profileSellCurrentPrice').text());
        const userShares = parseInt($('#profileUserShares').text());
        const total = quantity * price;

        $('#profileSellTotalReturn').text(total.toFixed(2));

        // Проверяем, достаточно ли акций
        if (quantity > userShares) {
            $('#confirmProfileSellBtn').prop('disabled', true);
            $('#profileSellQuantity').addClass('is-invalid');
            $('#profileSellError').text(`У вас недостаточно акций. Доступно для продажи: ${userShares}`);
            $('#profileSellError').show();
        } else {
            $('#confirmProfileSellBtn').prop('disabled', false);
            $('#profileSellQuantity').removeClass('is-invalid');
            $('#profileSellError').hide();
        }
    }

    // Обработчик кнопки подтверждения
    $('#confirmProfileSellBtn').on('click', function() {
        const playerId = $('#profileSellPlayerId').val();
        const quantity = parseInt($('#profileSellQuantity').val());
        const userShares = parseInt($('#profileUserShares').text());

        // Проверка перед отправкой
        if (quantity > userShares) {
            $('#profileSellError').text('Недостаточно акций для продажи');
            $('#profileSellError').show();
            return;
        }

        // Отправляем запрос на сервер
        $.post('/Main/Sell', {
            playerId: playerId,
            quantity: quantity
        })
        .done(function(response) {
            if (response.success) {
                // Закрываем модальное окно
                bootstrap.Modal.getInstance(document.getElementById('profileSellModal')).hide();
                
                // Перезагружаем страницу для обновления данных
                location.reload();
            } else {
                $('#profileSellError').text('Произошла ошибка при выполнении операции');
                $('#profileSellError').show();
            }
        })
        .fail(function(jqXHR) {
            let errorMessage = 'Произошла ошибка при выполнении операции';
            if (jqXHR.responseJSON && jqXHR.responseJSON.message) {
                errorMessage = jqXHR.responseJSON.message;
            }
            $('#profileSellError').text(errorMessage);
            $('#profileSellError').show();
        });
    });
}); 