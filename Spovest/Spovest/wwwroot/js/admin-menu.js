document.addEventListener('DOMContentLoaded', function() {
    // Находим все элементы с классом menu-toggle
    const menuToggles = document.querySelectorAll('.menu-toggle');

    // Добавляем обработчик для каждой кнопки
    menuToggles.forEach(toggle => {
        toggle.addEventListener('click', function(e) {
            e.preventDefault();
            
            // Находим родительский элемент menu-item
            const menuItem = this.closest('.menu-item');
            
            // Находим подменю
            const subMenu = menuItem.querySelector('.menu-sub');
            
            // Если меню уже открыто, закрываем его
            if (menuItem.classList.contains('open')) {
                menuItem.classList.remove('open');
                subMenu.style.maxHeight = '0px';
            } else {
                // Закрываем все открытые подменю
                const openMenus = document.querySelectorAll('.menu-item.open');
                openMenus.forEach(menu => {
                    menu.classList.remove('open');
                    menu.querySelector('.menu-sub').style.maxHeight = '0px';
                });

                // Открываем текущее подменю
                menuItem.classList.add('open');
                subMenu.style.maxHeight = subMenu.scrollHeight + 'px';
            }
        });
    });

    // Добавляем стили для анимации
    const style = document.createElement('style');
    style.textContent = `
        .menu-sub {
            max-height: 0;
            overflow: hidden;
            transition: max-height 0.3s ease-out;
        }
        
        .menu-item.open > .menu-sub {
            max-height: 1000px; /* Достаточно большое значение для любого подменю */
        }

        .menu-toggle::after {
            content: '';
            display: inline-block;
            width: 0;
            height: 0;
            margin-left: 0.5em;
            border-left: 4px solid transparent;
            border-right: 4px solid transparent;
            border-top: 4px solid currentColor;
            transition: transform 0.3s ease;
        }

        .menu-item.open > .menu-link.menu-toggle::after {
            transform: rotate(180deg);
        }

        /* Анимация при наведении */
        .menu-sub .menu-item:hover {
            background-color: rgba(0, 0, 0, 0.04);
        }

        .menu-sub .menu-link {
            padding-left: 3rem;
            transition: color 0.3s ease;
        }

        .menu-sub .menu-link:hover {
            color: var(--primary-color, #696cff);
        }
    `;
    document.head.appendChild(style);
}); 