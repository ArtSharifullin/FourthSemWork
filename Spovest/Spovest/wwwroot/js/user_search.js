$(document).ready(function () {
    let typingTimer;
    const doneTypingInterval = 500;
    const searchInput = $('#searchInput');

    // Обработка ввода в поле поиска
    searchInput.on('keyup', function () {
        clearTimeout(typingTimer);
        typingTimer = setTimeout(performSearch, doneTypingInterval);
    });

    searchInput.on('keydown', function () {
        clearTimeout(typingTimer);
    });

    // Обработка клика по пагинации
    $(document).on('click', '.pagination .page-link', function (e) {
        e.preventDefault();
        const page = $(this).data('page');
        performSearch(page);
    });

    function performSearch(page = 1) {
        const searchQuery = searchInput.val();
        
        $.get('/Main/Users', {
            search: searchQuery,
            page: page
        })
        .done(function (response) {
            $('#usersList').html($(response).find('#usersList').html());
            
            // Обновляем URL без перезагрузки страницы
            const url = new URL(window.location);
            url.searchParams.set('search', searchQuery);
            url.searchParams.set('page', page);
            window.history.pushState({}, '', url);
        })
        .fail(function (error) {
            console.error('Ошибка при поиске:', error);
        });
    }
}); 