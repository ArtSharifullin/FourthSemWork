$(document).ready(function () {

    const $balanceBtn = $('#balanceLink');
    const $btnWithdraw = $('#btnWithdraw');

    // Функция получения текущего баланса
    function getCurrentBalance() {
        return parseFloat($balanceBtn.data('balance')) || 0;
    }

    // Обновляем состояние кнопки "Вывести"
    function updateWithdrawButtonState() {
        const balance = getCurrentBalance();
        const isBlocked = $balanceBtn.data('withdraw-blocked') === true;
        
        if (balance <= 0 || isBlocked) {
            $btnWithdraw.prop('disabled', true).addClass('disabled');
            if (isBlocked) {
                $btnWithdraw.attr('title', 'Вывод средств заблокирован администратором');
            }
        } else {
            $btnWithdraw.prop('disabled', false).removeClass('disabled');
            $btnWithdraw.removeAttr('title');
        }
    }

    // Вызываем при загрузке страницы
    updateWithdrawButtonState();

    // Функция для выполнения запроса и обновления баланса
    function sendBalanceRequest(url, changeText) {
        const $balanceBtn = $('#balanceLink');
        const originalText = $balanceBtn.text();
        const amountText = changeText;

        // Анимация обновления текста кнопки
        $balanceBtn.text('Updating...');

        $.ajax({
            url: url,
            type: 'POST',
            success: function (response) {
                if (response.success) {
                    $balanceBtn.data('balance', response.balance);
                    $balanceBtn.text('$' + response.balance);
                    updateWithdrawButtonState();
                } else {
                    $balanceBtn.text(originalText);
                    alert(response.message || 'Произошла ошибка при обновлении баланса');
                }
            },
            error: function (jqXHR) {
                $balanceBtn.text(originalText);
                let errorMessage = 'Произошла ошибка при обновлении баланса';
                if (jqXHR.responseJSON && jqXHR.responseJSON.message) {
                    errorMessage = jqXHR.responseJSON.message;
                }
                alert(errorMessage);
            }
        });
    }

    // Обработчик пополнения
    $('#btnRefill').on('click', function (e) {
        e.preventDefault();
        sendBalanceRequest('/Main/Balance', '+100');
    });

    $btnWithdraw.on('click', function (e) {
        e.preventDefault();

        const currentBalance = getCurrentBalance();
        const isBlocked = $balanceBtn.data('withdraw-blocked') === true;

        if (isBlocked) {
            alert('Вывод средств заблокирован администратором');
            return;
        }

        if (currentBalance <= 0) {
            alert('Баланс пуст. Невозможно вывести средства.');
            return;
        }

        const amountText = () => `-${currentBalance}`;
        sendBalanceRequest('/Main/Withdraw', amountText);
    });
});

// Добавляем стили для анимации
$('<style>')
    .text(`
        .balance-notification {
            position: fixed;
            top: 0;
            right: 20px;
            background-color: #28a745;
            color: white;
            padding: 10px 20px;
            border-radius: 5px;
            opacity: 0;
            z-index: 9999;
            font-weight: bold;
            box-shadow: 0 2px 5px rgba(0,0,0,0.2);
        }
    `)
    .appendTo('head'); 