using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spovest.Domain.Entities;


namespace Spovest.Persistence.Configurations
{
    public class PostsConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasData(
                new Post { Id = 1, UserId = 1, Title = "Поднял бабло на баскетболе", Content = "Не ожидал настолько хорошей игры, повешу счет игры в рамочке на стену !!!", Img = "/images/user/stat.png" },
                new Post { Id = 2, UserId = 1, Title = "Больше не боюсь делать ставки", Content = "Опыт растёт с каждой игрой, теперь понимаю, где стоит рисковать, а где лучше подождать." },
                new Post { Id = 3, UserId = 2, Title = "Поставил на проигравшую команду", Content = "Но не расстроен, зато теперь знаю, как это работает на деле.", Img = "/images/user/stat.png" },
                new Post { Id = 4, UserId = 2, Title = "Стало интереснее следить за спортом", Content = "Раньше не особо разбирался в баскетболе, а сейчас даже прогнозы читаю перед матчами." },
                new Post { Id = 5, UserId = 3, Title = "Выиграл первый крупный куш!", Content = "Это был шикарный момент! Теперь верю в свои силы и играю увереннее.", Img = "/images/user/stat.png" },
                new Post { Id = 6, UserId = 3, Title = "Сложная игра, но очень увлекательная", Content = "Требует внимания и анализа, но когда всё сходится — адреналин зашкаливает!" },
                new Post { Id = 7, UserId = 4, Title = "Обидное поражение", Content = "Всё было почти идеально, но в последние минуты всё пошло не так...", Img = "/images/user/stat.png" },
                new Post { Id = 8, UserId = 4, Title = "Учу статистику перед ставками", Content = "Раньше действовал наугад, теперь проверяю форму игроков и результаты предыдущих встреч." },
                new Post { Id = 9, UserId = 5, Title = "Моя стратегия начала работать", Content = "Изучил несколько подходов, адаптировал под себя — теперь стабильный плюс в кошельке.", Img = "/images/user/stat.png" },
                new Post { Id = 10, UserId = 5, Title = "Играю аккуратно, но уверенно", Content = "Главное — не гнаться за большими выигрышами, а держаться плана." },
                new Post { Id = 11, UserId = 6, Title = "Крутой опыт за эти пару месяцев", Content = "Научился анализировать, стал больше понимать в спорте, чем раньше.", Img = "/images/user/stat.png" },
                new Post { Id = 12, UserId = 6, Title = "Делюсь опытом с друзьями", Content = "Теперь они тоже начали интересоваться, советуются по ставкам." },
                new Post { Id = 13, UserId = 7, Title = "Фора оказалась моим спасением", Content = "Уже несколько раз помогала выйти в плюс даже при небольших потерях.", Img = "/images/user/stat.png" },
                new Post { Id = 14, UserId = 7, Title = "Играть стало как хобби", Content = "Анализирую матчи, слежу за новостями, веду свою статистику — весело и полезно." },
                new Post { Id = 15, UserId = 8, Title = "Первый минус, но не последний", Content = "Проиграл, но без фанатизма, теперь буду учиться на этом опыте.", Img = "/images/user/stat.png" },
                new Post { Id = 16, UserId = 8, Title = "Ищу свой стиль игры", Content = "Пробую разные подходы, экспериментирую с суммами и выбором событий." },
                new Post { Id = 17, UserId = 9, Title = "Стал осторожнее с коэффициентами", Content = "Раньше гнался за высокими цифрами, теперь выбираю более реальные варианты.", Img = "/images/user/stat.png" },
                new Post { Id = 18, UserId = 9, Title = "Создал телеграм-канал для обмена опытом", Content = "Думаю развивать это дальше, может, станет проектом на постоянной основе." },
                new Post { Id = 19, UserId = 10, Title = "Люблю делать ставки в прямом эфире", Content = "Это добавляет адреналина, особенно если игра идет напряжённо до самого конца.", Img = "/images/user/stat.png" },
                new Post { Id = 20, UserId = 10, Title = "Смотрю матчи уже совсем по-другому", Content = "Теперь каждый момент важен, пытаюсь предсказать развитие событий." }
            );
        }
    }
}
