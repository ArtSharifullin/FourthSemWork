const subscribeConnection = new signalR.HubConnectionBuilder()
    .withUrl("/subscribeHub")
    .withAutomaticReconnect()
    .build();

subscribeConnection.on("ReceiveSubscribeUpdates", (followers, following) => {
    console.log("Получены обновления подписок:", followers, following);
    
    const followersCount = followers ? followers.length : 0;
    const followingCount = following ? following.length : 0;

    // Обновляем счетчики в LeftSideBar
    updateCountInElements('.follower .amount p[style*="font-size:18px"]', followersCount);
    updateCountInElements('.following .amount p[style*="font-size:18px"]', followingCount);

    // Обновляем счетчики в профиле
    updateCountInElements('.follower .amount a', followersCount);
    updateCountInElements('.following .amount a', followingCount);
});

// Вспомогательная функция для обновления значений
function updateCountInElements(selector, count) {
    const elements = document.querySelectorAll(selector);
    elements.forEach(element => {
        if (element) {
            element.textContent = count;
            console.log(`Обновлено значение для ${selector}:`, count);
        } else {
            console.log(`Элемент не найден: ${selector}`);
        }
    });
}

subscribeConnection.start()
    .then(() => console.log("Подключение к SignalR успешно установлено"))
    .catch(err => console.error("Ошибка подключения к SignalR:", err)); 