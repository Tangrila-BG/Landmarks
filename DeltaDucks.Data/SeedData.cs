using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using DeltaDucks.Data.Properties;
using DeltaDucks.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DeltaDucks.Data
{
    public class SeedData : DropCreateDatabaseAlways<DeltaDucksContext>
    {
        protected override void Seed(DeltaDucksContext context)
        {
            GetLandmarks().ForEach(l => context.Landmarks.Add(l));
            GetTowns().ForEach(t => context.Towns.Add(t));
            //GetAdminUsers().ForEach(u => context.Users.Add(u));
            //context.Commit();
            //GetRoles().ForEach(r => context.Roles.Add(r));
            //context.Commit();
            //AsignAdminRole().ForEach(ar => context.Roles.FirstOrDefault(r => r.Name == "Admin").Users.Add(ar));
            //context.Commit();
            GetPictures().ForEach(p => context.Pictures.Add(p));
            GetLocations().ForEach(l=> context.Locations.Add(l));
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

        private static List<Location> GetLocations()
        {
            return new List<Location>
            {
                new Location
                {
                    Latitude = 42.6892896,
                    Longitude = 23.3218674
                },
                new Location
                {
                    Latitude = 41.767222,
                    Longitude = 23.3967001
                },
                new Location
                {
                    Latitude = 41.970058,
                    Longitude = 23.477194
                },
                new Location
                {
                    Latitude = 41.5231612,
                    Longitude = 23.3982906
                },
                new Location
                {
                    Latitude = 41.444126,
                    Longitude = 23.239662
                },
                new Location
                {
                    Latitude = 41.4042377,
                    Longitude = 23.0150922
                },
                new Location
                {
                    Latitude =42.6583164,
                    Longitude = 23.730732
                },
                new Location
                {
                    Latitude = 42.565577,
                    Longitude = 27.6318675
                },
                new Location
                {
                    Latitude = 42.5907597,
                    Longitude = 27.5874142
                },
                new Location
                {
                 Latitude   = 42.4463412,
                 Longitude = 27.4625411
                },
                new Location
                {
                    Latitude = 41.979991,
                    Longitude = 27.524679
                },
                new Location
                {
                    Latitude = 42.420425,
                    Longitude = 27.692867
                },
                new Location
                {
                    Latitude = 42.1715358,
                    Longitude = 27.8522611
                },
                new Location
                {
                    Latitude = 43.200318,
                    Longitude = 27.9215004
                },
                new Location
                {
                    Latitude = 43.225442,
                    Longitude = 27.5849247
                },
                new Location
                {
                    Latitude = 43.0837812,
                    Longitude = 25.6520446
                },
                new Location
                {
                    Latitude = 43.095609,
                    Longitude = 25.663183
                },
                new Location
                {
                    Latitude = 43.6205982,
                    Longitude =25.3400556
                },
                new Location
                {
                    Latitude = 43.993026,
                    Longitude = 22.864998
                },
                new Location
                {
                    Latitude = 43.7280314,
                    Longitude = 22.5829063
                },
                new Location
                {
                    Latitude = 43.6115544,
                    Longitude = 22.6771202
                    //Белоградчишски скали
                },
                new Location
                {
                    Latitude = 43.2044194,
                    Longitude = 23.4936989
                    //Леденика
                },
                new Location
                {
                    Latitude = 43.151,
                    Longitude = 23.5778113
                    //Околчица
                },
                new Location
                {
                    Latitude = 43.798718,
                    Longitude = 23.6776728
                    //Радецки
                },
                new Location
                {
                    Latitude = 42.8705605,
                    Longitude = 25.3168318
                    //Музей на образованието, Габрово
                },
                new Location
                {
                    Latitude = 42.873031,
                    Longitude = 25.424006
                    //АИР Боженци
                },
                new Location
                {
                    Latitude = 42.8676041,
                    Longitude = 25.4874226
                    //Трявна, Даскалова къща
                },
                new Location
                {
                    Latitude = 42.9500327,
                    Longitude = 25.4323938
                    //Дряновски манастир
                },
                new Location
                {
                    Latitude = 42.9795702,
                    Longitude = 25.4770053
                    //гр. Дряново – Музей „Кольо Фичето“
                },
                new Location
                {
                    Latitude = 43.4031288,
                    Longitude = 28.1456719
                    //гр. Балчик – комплекс „Двореца“
                },
                new Location
                {
                    Latitude = 43.4139288,
                    Longitude = 28.354459
                    //нос Калиакра-археологически резерват „Калиакра”
                },
                new Location
                {
                    Latitude = 41.6264152,
                    Longitude = 25.3701454
                    //гр. Кърджали – Манастир „Св. Йоан Предтеча“
                },
                new Location
                {
                    Latitude = 41.7154279,
                    Longitude = 25.4656735
                    //Kърджали, Перперикон
                },
                new Location
                {
                    Latitude = 42.2835244,
                    Longitude = 22.68874
                    //гр. Кюстендил - Къща-музей „Димитър Пешев“
                },
                new Location
                {
                    Latitude = 42.0204962,
                    Longitude = 23.1031504
                    //гр. Благоевград - Регионален исторически музей
                },
                new Location
                {
                    Latitude = 42.158024,
                    Longitude = 22.5140893
                    //връх Руен
                },
                new Location
                {
                    Latitude = 42.1333838,
                    Longitude = 23.3401215
                    //Музей Рилски манастир в Рилска света обител
                },
                new Location
                {
                    Latitude = 42.0964618,
                    Longitude = 23.1130692
                    //Стобски пирамиди - с. Стоб
                },
                new Location
                {
                    Latitude = 42.2305238,
                    Longitude = 23.3036197
                    //хижа „Скакавица“ и Седемте рилски езера
                },
                new Location
                {
                    Latitude = 43.129946,
                    Longitude = 24.7174735
                    //гр. Ловеч – Музей „Васил Левски“
                },
                new Location
                {
                    Latitude = 43.2077,
                    Longitude = 24.1585
                    // гр. Луковит – Национален пещерен дом
                },
                new Location
                {
                    Latitude = 42.8413752,
                    Longitude = 24.7680955
                    //Природонаучен музей - с. Черни Осъм
                },
                new Location
                {
                    Latitude = 42.918321,
                    Longitude = 24.264804
                    //гр. Тетевен – Исторически музей (осн. 1911 г.)
                },
                new Location
                {
                    Latitude = 43.0471357,
                    Longitude = 24.1854932
                    //с. Брестница – пещера „Съева дупка“ (400 м.)
                },
                new Location
                {
                    Latitude = 43.2392278,
                    Longitude = 23.1260618
                    //гр. Берковица – Етнографски музей
                },
                new Location
                {
                    Latitude = 42.1864485,
                    Longitude = 24.3252059
                    //гр. Пазарджик – Къща-музей „Станислав Доспевски”
                },
                new Location
                {
                    Latitude = 42.5375145,
                    Longitude = 24.116351
                    //Оборище
                },
                new Location
                {
                    Latitude = 42.00042201,
                    Longitude = 24.27872
                    //Пещера, Снежанка
                },
                new Location
                {
                    Latitude = 41.9428527,
                    Longitude = 24.2184775
                    //Музей в Батак
                },
                new Location
                {
                    Latitude = 42.8619908,
                    Longitude = 22.6502499
                    //Ждрело на река Ерма
                }
            };
        }

        private static List<Landmark> GetLandmarks()
        {
            return new List<Landmark>
            {
                new Landmark
                {
                    Name = "Музей \"Никола Вапцаров\"",
                    Number = 1,
                    
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

        public static List<Picture> GetPictures()
        {
            return new List<Picture>
            {
                new Picture
                {
                    Name = "Магурата",
                    ImageData = File.ReadAllBytes(HttpContext.Current.Server.MapPath(Resources.ImagesSeed+"Magurata.jpg"))
                },
                new Picture
                {
                    Name = "Крепост Баба Вида",
                    ImageData = File.ReadAllBytes(HttpContext.Current.Server.MapPath(Resources.ImagesSeed+"baba-vida.jpg"))
                },
                new Picture
                {
                    Name = "Царевец",
                    ImageData = File.ReadAllBytes(HttpContext.Current.Server.MapPath(Resources.ImagesSeed+"tsarevets.jpg"))
                }
            };
        }

        public static List<IdentityRole> GetRoles()
        {
            return new List<IdentityRole>
                {
                    new IdentityRole
                    {
                        Name = "Admin"
                    }
                };

        }

        public static List<IdentityUserRole> AsignAdminRole()
        {
            using (var context = new DeltaDucksContext())
            {
                return new List<IdentityUserRole>
                {
                    new IdentityUserRole
                    {
                        UserId = context.Users.FirstOrDefault(u => u.UserName == "admin").Id,
                        RoleId = context.Roles.FirstOrDefault(r => r.Name == "Admin").Id,
                    }
                };
            }
        }

    }
}