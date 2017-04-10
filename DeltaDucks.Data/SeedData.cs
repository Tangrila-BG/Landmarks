using System.Collections.Generic;
using System.Data.Entity;
using DeltaDucks.Models;

namespace DeltaDucks.Data
{
    public class SeedData : DropCreateDatabaseAlways<DeltaDucksContext>
    {
        protected override void Seed(DeltaDucksContext context)
        {
            GetLandmarks().ForEach(l => context.Landmarks.Add(l));
            GetTowns().ForEach(t => context.Towns.Add(t));
            context.Commit();
        }

        private static List<Town> GetTowns()
        {
            return new List<Town>
            {
                new Town
                {
                    Name = "гр. Банско"
                },
                new Town
                {
                    Name = "Пирин"
                },
                new Town
                {
                    Name = "с. Добърско"
                },
                new Town
                {
                    Name = "гр. Мелник"
                },
                new Town
                {
                    Name = "гр. Петрич"
                },
                new Town
                {
                    Name = "гр. Несебър"
                },
                new Town
                {
                    Name = "гр. Поморие"
                },
                new Town
                {
                    Name = "гр. Бургас"
                },
                new Town
                {
                    Name = "гр. Малко Търново"
                },
                new Town
                {
                    Name = "гр. Созопол"
                },
                new Town
                {
                    Name = "гр. Царево"
                },
                new Town
                {
                    Name = "гр. Варна"
                },
                new Town
                {
                    Name = "гр. Девня"
                },
                new Town
                {
                    Name = "гр. Велико Търново"
                },
                new Town
                {
                    Name = "гр. Свищов"
                },
                new Town
                {
                    Name = "гр. Видин"
                },
                new Town
                {
                    Name = "гр. Белоградчик"
                },
                new Town
                {
                    Name = "гр. Враца"
                },
                new Town
                {
                    Name = "гр. Козлодуй"
                },


            };
        }

        //private static List<Location> GetLocations()
        //{
        //    return new List<Location>
        //    {

        //    };
        //}

        private static List<Landmark> GetLandmarks()
        {
            return new List<Landmark>
            {
                new Landmark
                {
                    Name = "Музей \"Никола Вапцаров\"",
                    Number = 1
                    // Град Банско
                },
                new Landmark
                {
                    Name = "Връх Вихрен",
                    Number = 2
                    // Пирин
                },
                new Landmark
                {
                    Name = "Църква \"Св.св. Теодор Тирон и Теодор Стратилат\"",
                    Number = 3
                    // с. Добърско
                },
                new Landmark
                {
                    Name = "Кордопулова къща",
                    Number = 4
                    // гр. Мелник
                },
                new Landmark
                {
                    Name = "Местност \"Рупите\" - храм-паметник \"Света Петка Българска\"",
                    Number = 5
                    // град Петрич
                },
                new Landmark
                {
                    Name = "Самуилова крепост",
                    Number = 6
                    // град Петрич
                },
                new Landmark
                {
                    Name = "Архитектурно-исторически резерват - Архитектурен музей",
                    Number = 7
                    // град Несебър
                },
                new Landmark
                {
                    Name = "Музей на солта",
                    Number = 8
                    // град Поморие
                },
                new Landmark
                {
                    Name = "Поморийско езеро",
                    Number = 9
                    // град Поморие
                },
                new Landmark
                {
                    Name = "Природозащитен център \"Пода\"",
                    Number = 10
                    // град Бургас
                },
                new Landmark
                {
                    Name = "Историческа местност \"Петрова нива\"",
                    Number = 11
                    // град Малко Търново
                },
                new Landmark
                {
                    Name = "Археологически музей",
                    Number = 12
                    // град Созопол
                },
                new Landmark
                {
                    Name = "Общински исторически музей",
                    Number = 13
                    // град Царево
                },
                new Landmark
                {
                    Name = "Военноморски музей",
                    Number = 14
                    // град Варна
                },
                new Landmark
                {
                    Name = "Музей на мозайките",
                    Number = 15
                    // град Девня
                },
                new Landmark
                {
                    Name = "Архитектурно - исторически резерват \"Царевец\"",
                    Number = 16
                    // град Велико Търново
                },
                new Landmark
                {
                    Name = "Архитектурно - музеен резерват \"Арбанаси\"",
                    Number = 17
                    // град Велико Търново
                },
                new Landmark
                {
                    Name = "Къща-музей \"Алеко Константинов\"",
                    Number = 18
                    // град Свищов
                },
                new Landmark
                {
                    Name = "Музей-крепост \"Баба Вида\"",
                    Number = 19
                    // град Видин
                },
                new Landmark
                {
                    Name = "Пещера \"Магурата\"",
                    Number = 20
                    // Стара планина
                }
            };
        }

    }
}