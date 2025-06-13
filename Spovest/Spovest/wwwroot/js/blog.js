$(document).ready(function() {

    // Обработчик клика по кнопкам Followers и Following
    $('.dr_btn').on('click', function() {
        const type = $(this).text().trim().toLowerCase().split(' ')[0]; // получаем followers или following
    });

    // Обработчик клика по кнопкам табов
    $('.tab_btn').on('click', function() {
        const tabId = $(this).data('tab');
        
        // Убираем активный класс со всех кнопок и добавляем на нажатую
        $('.tab_btn').removeClass('active');
        $(this).addClass('active');
        
        // Скрываем все табы и показываем нужный
        $('.profile_tab').removeClass('active');
        $(`#${tabId}`).addClass('active');
    });
}); 