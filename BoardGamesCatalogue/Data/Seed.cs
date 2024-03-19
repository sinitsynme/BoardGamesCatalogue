using BoardGamesCatalogue.Models;

namespace BoardGamesCatalogue.Data;

public class Seed
{
    private readonly DataContext _dataContext;

    public Seed(DataContext context)
    {
        _dataContext = context;
    }

    public void SeedDataContext()
    {
        if (!_dataContext.BoardGames.Any())
        {
            var boardCategory = new Category() { Name = "Настольные" };
            var cardCategory = new Category() { Name = "Карточные" };
            var traditionalCategory = new Category() { Name = "Традиционные" };
            var wargameCategory = new Category() { Name = "Варгеймы" };
            var hobbyGamesCreator = new Creator() { Name = "HobbyGames" };
            var nastolkiRuCreator = new Creator() { Name = "Настолки.ru" };
            var boardGames = new List<BoardGame>()
            {
                new(
                    "100000000",
                    1000.0m,
                    "Каркассон",
                    GameDurationInMinutes.SixtyOneToOneHundredTwenty,
                    new List<BoardGameCategory>()
                    {
                        new() { Category = boardCategory },
                        new() { Category = traditionalCategory },
                    },
                    hobbyGamesCreator,
                    PlayersQuantity.THREE,
                    "https://hobbyworld.cdnvideo.ru/image/cache/hobbyworld/data/HobbyWorld/Karkasson/1000/Karkasson00-1200x800.jpg"
                ),
                new(
                    "100000001",
                    990.0m,
                    "Затерянный остров",
                    GameDurationInMinutes.MoreThanOneHundredTwenty,
                    new List<BoardGameCategory>()
                    {
                        new() { Category = boardCategory },
                        new() { Category = cardCategory },
                    },
                    new() { Name = "Мосигра" },
                    PlayersQuantity.TWO,
                    "https://hobbygames.ru/image/data/Magellan/Zapretniy_Ostrov/HG/Zateryanniy_Ostrov00.JPG"
                ),
                new(
                    "1234234234",
                    599.99m,
                    "Манчкин",
                    GameDurationInMinutes.MoreThanOneHundredTwenty,
                    new List<BoardGameCategory>()
                    {
                        new() { Category = cardCategory },
                        new() { Category = wargameCategory },
                    },
                    hobbyGamesCreator,
                    PlayersQuantity.MORE_THAN_FOUR,
                    "https://madcube.ru/wp-content/uploads/2015/11/manchkin-e1448140335157.jpg"
                ),
                new(
                    "21921894213",
                    199.99m,
                    "Мафия",
                    GameDurationInMinutes.MoreThanOneHundredTwenty,
                    new List<BoardGameCategory>()
                    {
                        new() { Category = cardCategory },
                        new() { Category = traditionalCategory },
                    },
                    nastolkiRuCreator,
                    PlayersQuantity.MORE_THAN_FOUR,
                    "https://hobbyworld.cdnvideo.ru/image/cache/hobbyworld/data/HobbyWorld/Mafia/1000/Mafiya_Vsya_Semya_V_Sbore00-1200x800-wm.jpg"
                ),
            };

            _dataContext.BoardGames.AddRange(boardGames);
            _dataContext.SaveChanges();
        }

        if (!_dataContext.Region.Any())
        {
            var regions = new List<String>()
            {
                "Алтайский край",
                "Амурская область",
                "Архангельская область",
                "Астраханская область",

                "Белгородская область",
                "Брянская область",

                "Владимирская область",
                "Волгоградская область",
                "Вологодская область",
                "Воронежская область",

                "Донецкая Народная Республика",

                "Еврейская автономная область",

                "Забайкальский край",
                "Запорожская область",

                "Ивановская область",
                "Иркутская область",

                "Кабардино-Балкарская Республика",
                "Калининградская область",
                "Калужская область",
                "Камчатский край",
                "Карачаево-Черкесская Республика",
                "Кемеровская область",
                "Кировская область",
                "Костромская область",
                "Краснодарский край",
                "Красноярский край",
                "Курганская область",
                "Курская область",

                "Ленинградская область",
                "Липецкая область",
                "Луганская Народная Республика",

                "Магаданская область",
                "Москва",
                "Московская область",
                "Мурманская область",

                "Ненецкий автономный округ",
                "Нижегородская область",
                "Новгородская область",
                "Новосибирская область",

                "Омская область",
                "Оренбургская область",
                "Орловская область",

                "Пензенская область",
                "Пермский край",
                "Приморский край",
                "Псковская область",

                "Республика Адыгея",
                "Республика Алтай",
                "Республика Башкортостан",
                "Республика Бурятия",
                "Республика Дагестан",
                "Республика Ингушетия",
                "Республика Калмыкия",
                "Республика Карелия",
                "Республика Коми",
                "Республика Крым",
                "Республика Марий Эл",
                "Республика Мордовия",
                "Республика Саха (Якутия)",
                "Республика Северная Осетия — Алания",
                "Республика Татарстан",
                "Республика Тыва",
                "Республика Хакасия",
                "Ростовская область",
                "Рязанская область",

                "Самарская область",
                "Санкт-Петербург",
                "Саратовская область",
                "Сахалинская область",
                "Свердловская область",
                "Севастополь",
                "Смоленская область",
                "Ставропольский край",

                "Тамбовская область",
                "Тверская область",
                "Томская область",
                "Тульская область",
                "Тюменская область",

                "Удмуртская Республика",
                "Ульяновская область",

                "Хабаровский край",
                "Ханты-Мансийский автономный округ — Югра",
                "Херсонская область",

                "Челябинская область",
                "Чеченская Республика",
                "Чувашская Республика",
                "Чукотский автономный округ",

                "Ямало-Ненецкий автономный округ",
                "Ярославская область"
            }.Select(it => new Region() { Name = it });

            _dataContext.Region.AddRange(regions);
            _dataContext.SaveChanges();
        }

        if (!_dataContext.ShopAddress.Any())
        {
            var shopAddresses = new List<ShopAddress>()
            {
                new()
                {
                    City = "г. Солнечногорск",
                    Address = "наб. Бухарестская, 88",
                    Phone = "88005553535",
                    Email = "solnechnogorsk@nastolki.ru"
                },
                new()
                {
                    City = "г. Дмитров",
                    Address = "наб. 1905 года, 69",
                    Phone = "84005553534",
                    Email = "dmitrov@nastolki.ru"
                },
                new()
                {
                    City = "г. Красногорск",
                    Address = "проезд Славы, 92",
                    Phone = "81005553531",
                    Email = "krasnogorsk@nastolki.ru"
                },
                new()
                {
                    City = "г. Егорьевск",
                    Address = "шоссе Ломоносова, 82",
                    Phone = "85005553535",
                    Email = "egoryevsk@nastolki.ru"
                },
            };
            
            _dataContext.ShopAddress.AddRange(shopAddresses);
            _dataContext.SaveChanges();
        }
    }
}