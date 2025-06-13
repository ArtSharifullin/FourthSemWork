$(document).ready(function () {
    console.log('Subscribe actions script loaded');

    // Находим все кнопки подписки/отписки
    $('.subscribe-btn').each(function () {
        console.log('Found subscribe button:', $(this).data('user-id'), $(this).data('action'));
    });

    // Обработчик клика
    $(document).on('click', '.subscribe-btn', async function (e) {
        e.preventDefault();
        console.log('Button clicked');

        const $button = $(this);
        const userId = $button.data('user-id');
        const action = $button.data('action');
        const url = `/Main/${action === 'unsubscribe' ? 'Unsubscribe' : 'Subscribe'}/${userId}`;

        console.log('Making request to:', url);

        try {
            const response = await fetch(url, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                }
            });

            const result = await response.json();
            console.log('Response:', result);

            if (result.success) {
                // Меняем внешний вид кнопки
                if (action === 'unsubscribe') {
                    $button.text('Follow')
                        .removeClass('btn-primary3')
                        .addClass('btn-primary2')
                        .data('action', 'subscribe');
                } else {
                    $button.text('Unfollow')
                        .removeClass('btn-primary2')
                        .addClass('btn-primary3')
                        .data('action', 'unsubscribe');
                }
            } else {
                console.error('Ошибка при выполнении операции');
            }
        } catch (error) {
            console.error('Ошибка при выполнении запроса:', error);
        }
    });
}); 