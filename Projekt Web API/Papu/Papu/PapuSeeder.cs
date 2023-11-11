using Microsoft.EntityFrameworkCore;
using Papu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Papu
{
    public class PapuSeeder
    {
        private readonly PapuDbContext _dbContext;

        public PapuSeeder(PapuDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            /// <summary>
            /// Sprawdzamy czy połączenie do bazy danych zostało nawiązane
            /// </summary>
            if (!_dbContext.Database.CanConnect())
                return;

            if (_dbContext.Database.IsRelational())
                MigrateDatabase();

            SeedTable<Role>(() => Roles);
            SeedTable<Product>(() => Products);
            SeedTable<Dish>(() => GetDishes());
            SeedTable<KindOf>(() => KindsOf);
            SeedTable<Entities.Type>(() => Types);
            SeedTable<Category>(() => Categories);
            SeedTable<Unit>(() => Units);
            SeedTable<Group>(() => Groups);
            SeedTable<Breakfast>(() => GetBreakfasts());
            SeedTable<Monday>(() => GetMondays());
            SeedTable<Saturday>(() => GetSaturdays());
            SeedTable<Friday>(() => GetFridays());
            SeedTable<Tuesday>(() => GetTuesdays());
            SeedTable<Wednesday>(() => GetWednesdays());
            SeedTable<Thursday>(() => GetThursdays());
            SeedTable<Sunday>(() => GetSundays());
            SeedTable<Menu>(() => GetMenus());
        }

        private void MigrateDatabase()
        {
            var pendingMigrations = _dbContext.Database.GetPendingMigrations();
            if (pendingMigrations != null && pendingMigrations.Any())
            {
                _dbContext.Database.Migrate();
            }
        }


        private void SeedTable<TEntity>(Func<IEnumerable<TEntity>> dataFunc) where TEntity : class
        {
            /// <summary>
            /// Sprawdzamy czy tabele są wypełnione danymi
            /// </summary>
            if (!_dbContext.Set<TEntity>().Any())
            {
                var entities = dataFunc();
                _dbContext.Set<TEntity>().AddRange(entities);
                _dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Metoda zwracająca kolekcję ról, które będą zawsze istnieć w tabeli role
        /// baza automatycznie przydzieli id
        /// </summary>
        private static readonly List<Role> Roles = new()
        {
            new() { Name = "User" },
            new() { Name = "Manager" },
            new() { Name = "Admin" }
        };

        /// <summary>
        /// Metoda zwracająca kolekcję grup produktów, które będą zawsze istnieć w tabeli group
        /// baza automatycznie przydzieli id
        /// </summary>
        private static readonly List<Group> Groups = new()
        {
            new() { GroupName = "Algi" },
            new() { GroupName = "Drożdże" },
            new() { GroupName = "Grzyby" },
            new() { GroupName = "Inne" },
            new() { GroupName = "Jaja" },
            new() { GroupName = "Kawa herbata" },
            new() { GroupName = "Konserwanty" },
            new() { GroupName = "Mięso" },
            new() { GroupName = "Nasiona i orzechy" },
            new() { GroupName = "Owoce" },
            new() { GroupName = "Owoce morza" },
            new() { GroupName = "Pozostałe" },
            new() { GroupName = "Produkty mleczne" },
            new() { GroupName = "Produkty słodzące" },
            new() { GroupName = "Przyprawy i zioła" },
            new() { GroupName = "Ryby" },
            new() { GroupName = "Sałaty" },
            new() { GroupName = "Warzywa" },
            new() { GroupName = "Warzywa strączkowe" },
            new() { GroupName = "Zagęstniki" },
            new() { GroupName = "Zamienniki zbóż" },
            new() { GroupName = "Zboża niezawierające glutenu" },
            new() { GroupName = "Zboża zawierające gluten" }
        };

        /// <summary>
        /// Metoda zwracająca kolekcję jednostek miary produktów, które będą zawsze istnieć w tabeli unit
        /// baza automatycznie przydzieli id
        /// </summary>
        private static readonly List<Unit> Units = new()
        {
            new() { UnitName = "Garść" },
            new() { UnitName = "Łyżka" },
            new() { UnitName = "Sztuka" },
            new() { UnitName = "Litr" },
            new() { UnitName = "Plaster" },
            new() { UnitName = "Porcja" },
            new() { UnitName = "Plasterek" },
            new() { UnitName = "Opakowanie" },
            new() { UnitName = "Łyżeczka" },
            new() { UnitName = "Listek" },
            new() { UnitName = "Kromka" },
            new() { UnitName = "Szklanka" },
            new() { UnitName = "Kostka" },
            new() { UnitName = "Ząbek" },
            new() { UnitName = "Liść" },
            new() { UnitName = "Łodyga" },
            new() { UnitName = "Kieliszek" },
            new() { UnitName = "Kropla" },
            new() { UnitName = "Szczypta" },
            new() { UnitName = "Płat" },
            new() { UnitName = "Rurka" },
            new() { UnitName = "Kapsułka" },
            new() { UnitName = "Miarka" },
            new() { UnitName = "Pęczek" },
            new() { UnitName = "Gałka" },
            new() { UnitName = "Kawałek" }
        };

        /// <summary>
        /// Metoda zwracająca kolekcję kategorii produktów, które będą zawsze istnieć w tabeli category
        /// baza automatycznie przydzieli id
        /// </summary>
        private static readonly List<Category> Categories = new()
        {
            new() { CategoryName = "Nabiał" },
            new() { CategoryName = "Mięso i wyroby mięsne" },
            new() { CategoryName = "Ryby i owoce morza" },
            new() { CategoryName = "Pieczywo" },
            new() { CategoryName = "Zbożowe" },
            new() { CategoryName = "Orzechy i ziarna" },
            new() { CategoryName = "Napoje" },
            new() { CategoryName = "Tłuszcze" },
            new() { CategoryName = "Inne" },
            new() { CategoryName = "Owoce i Warzywa" },
            new() { CategoryName = "Przyprawy i zioła" }
        };

        /// <summary>
        /// Metoda zwracająca kolekcję typów potraw, które będą zawsze istnieć w tabeli type
        /// baza automatycznie przydzieli id
        /// </summary>
        private static readonly List<Entities.Type> Types = new()
        {
            new() { TypeName = "Śniadanie" },
            new() { TypeName = "Drugie śniadanie" },
            new() { TypeName = "Obiad" },
            new() { TypeName = "Podwieczorek" },
            new() { TypeName = "Kolacja" },
            new() { TypeName = "Przekąska" }
        };

        /// <summary>
        /// Metoda zwracająca kolekcję rodzajów potraw, które będą zawsze istnieć w tabeli kindOf
        /// baza automatycznie przydzieli id
        /// </summary>
        private static readonly List<KindOf> KindsOf = new()
        {
            new() { KindOfName = "Paleo" },
            new() { KindOfName = "Potreningowy" },
            new() { KindOfName = "Szybki" },
            new() { KindOfName = "Fit" },
            new() { KindOfName = "Z niskim IG" }
        };

        /// <summary>
        /// Metoda zwracająca kolekcję produktów, które będą zawsze istnieć w tabeli product
        /// baza automatycznie przydzieli id
        /// </summary>
        private static readonly List<Product> Products = new()
        {
            new() { ProductName = "Pomidor", Weight = 180 },
            new() { ProductName = "Cytryna", Weight = 103 }
        };

        /// <summary>
        /// Metoda zwracająca kolekcję potraw, które będą zawsze istnieć w tabeli product
        /// baza automatycznie przydzieli id
        /// </summary>
        private static IEnumerable<Dish> GetDishes()
        {
            return new List<Dish>
            {
                new Dish
                {
                    DishName = "Focaccia",
                    DishProducts = new List<ProductDish>()
                    {
                        new ProductDish()
                        {
                            Product = new Product()
                            {
                                ProductName = "Świeże drożdże",
                                Weight = 30
                            }
                        }
                    },
                    DishDescription = "Focaccia to włoskie pieczywo, najczęściej podawane jako przystawka przed posiłkiem. Doskonale sprawdzi się jako przekąska podczas weekendowej uczty – do zjedzenia w domu lub w plenerze. Rozrobione ciasto posmarujcie łyżką oliwy, a na wierzchu ułóżcie pomidorki koktajlowe. Możecie też posypać mozzarellą lub parmezanem. Gwarantujemy, że focaccia z pomidorami zasmakuje każdemu, nie tylko amatorom włoskiej kuchni.",
                    Size = 1,
                    MethodOfPeparation = "Drożdże rozpuszczamy w wodzie z dodatkiem piwa i odstawiamy na bok na około 10 minut. Dodajemy jedną łyżkę oliwy, sól, pieprz, cukier, posiekany drobno czosnek, zioła oraz mąkę. Drewnianą łyżką łączymy składniki.",
                    PreparationTime = 90,
                    Portions = 2
                }
            };
        }

        /// <summary>
        /// Metoda zwracająca kolekcję śniadań, które będą zawsze istnieć w tabeli breakfast
        /// baza automatycznie przydzieli id
        /// </summary>
        private static IEnumerable<Breakfast> GetBreakfasts()
        {
            return new List<Breakfast>()
            {
                new Breakfast()
                {
                    Dishes = new List<BreakfastDish>()
                    {
                        new BreakfastDish()
                        {
                            Dish = new Dish()
                            {
                                DishName = "Krem pomidorowy z grzankami z mozzarellą",
                                DishProducts = new List<ProductDish>()
                                {
                                    new ProductDish()
                                    {
                                        Product = new Product()
                                        {
                                            ProductName = "Pomidory w puszce",
                                            Weight = 500
                                        }
                                    }
                                },
                                DishDescription = "Ulubiona zupa wszystkich dzieci w jeszcze smaczniejszej odsłonie. W końcu kto się oprze grzankom z mozzarellą? Ten pyszny krem sprawi, że zapomnicie o pomidorowej z makaronem. Jeśli szukacie prostego i jednocześnie wyrafinowanego przepisu na szybki obiad, ta propozycja jest dla was! Na rancie talerza z zupą ułóżcie grzanki i udekorujcie ją odrobiną pesto i oliwą.",
                                Size = 3,
                                MethodOfPeparation = "Na patelni rozpuszczamy masło i oliwę, dodajemy posiekany ząbek czosnku oraz drobno pokrojoną cebulę. Smażymy chwilę, aż cebula się zeszkli. Dodajemy pomidory i smażymy przez jeszcze kilka minut, aż smaki się połączą. Dolewamy 2 szklanki bulionu, dobrze mieszamy i gotujemy przez chwilę. Energicznie mieszając, wsypujemy do zupy semolinę i gotujemy, aż zupa zgęstnieje. Przyprawiamy do smaku cukrem, solą i pieprzem.",
                                PreparationTime = 30,
                                Portions = 3
                            }
                        }
                    }
                }
            };
        }

        /// <summary>
        /// Metoda zwracająca kolekcję poniedziałków, które będą zawsze istnieć w tabeli monday
        /// baza automatycznie przydzieli id
        /// </summary>
        private static IEnumerable<Monday> GetMondays()
        {
            return new List<Monday>()
            {
                new Monday
                {
                    Breakfast = new Breakfast()
                    {
                        Dishes = new List<BreakfastDish>()
                        {
                            new BreakfastDish()
                            {
                                Dish = new Dish()
                                {
                                    DishName = "Adżapsandal",
                                    DishProducts = new List<ProductDish>()
                                    {
                                        new ProductDish()
                                        {
                                            Product = new Product()
                                            {
                                                ProductName = "Papryka",
                                                Weight = 100
                                            }
                                        }
                                    },
                                    DishDescription = "Do czego użyć pieczonych warzyw? Stwórzcie z nich pożywne danie kuchni gruzińskiej z dodatkiem bakłażana, ziemniaków i fasolki szparagowej. Upieczone wcześniej warzywa przez chwilę gotujcie w garnku lub na patelni z grubym dnem. Adżapsandal doskonale nadaje się jako podstawa szakszuki – wystarczy podgrzać warzywa na patelni, wbić jajko i gotowe danie posypać fetą i natką pietruszki.",
                                    Size = 3,
                                    MethodOfPeparation = "Bakłażany i cukinie kroimy w krążki. Dodajemy do nich całe papryczki, polewamy obficie oliwą i grillujemy na patelni lub w piekarniku rozgrzanym do 200°C przez 15 minut.",
                                    PreparationTime = 20,
                                    Portions = 3
                                }
                            }
                        }
                    },
                    SecondBreakfast = new SecondBreakfast()
                    {
                        Dishes = new List<SecondBreakfastDish>()
                        {
                            new SecondBreakfastDish()
                            {
                                Dish = new Dish()
                                {
                                    DishName = "Chłodnik jogurtowy z pomidorową salsą",
                                    DishProducts = new List<ProductDish>()
                                    {
                                        new ProductDish()
                                        {
                                            Product = new Product()
                                            {
                                                ProductName = "Oliwa",
                                                Weight = 50
                                            }
                                        }
                                    },
                                    DishDescription = "W tym przepisie z pewnością rozsmakują się wszyscy miłośnicy chłodników! Niesamowity kolor danie zyskuje nie tylko dzięki pomidorowo-malinowej salsie, ale także bazylii. Swój wyjątkowy smak zawdzięcza natomiast prawdziwie królewskiemu połączeniu gęstego, cierpkiego jogurtu z czosnkiem i ogórkiem. Mimo że ten chłodnik świetnie sprawdza się jako sycąca letnia zupa, może być też traktowany jako dip lub sos. Gwarantujemy, że w każdej odsłonie smakuje rewelacyjnie!",
                                    Size = 3,
                                    MethodOfPeparation = "Przygotowujemy salsę. Pomidory zanurzamy we wrzątku na 3-5 sekund, wyjmujemy, studzimy i obieramy ze skórki. Usuwamy gniazda nasienne (można je potem wykorzystać do przygotowania bakłażana w pomidorach >> ), miąższ kroimy w drobną kostkę. Maliny przecinamy na pół lub na ćwiartki. Cebulę kroimy w drobną kostkę. Listki bazylii składamy razem i kroimy w cieniutkie paseczki. W misce mieszamy składniki salsy, doprawiamy sokiem z cytryny, solą, pieprzem i cukrem, odstawiamy.",
                                    PreparationTime = 0,
                                    Portions = 3
                                }
                            }
                        }
                    },
                    Lunch = new Lunch()
                    {
                        Dishes = new List<LunchDish>()
                        {
                            new LunchDish()
                            {
                                Dish = new Dish()
                                {
                                    DishName = "Wytrawne ciastko z pomidorem i oregano",
                                    DishProducts = new List<ProductDish>()
                                    {
                                        new ProductDish()
                                        {
                                            Product = new Product()
                                            {
                                                ProductName = "Sól",
                                                Weight = 5
                                            }
                                        }
                                    },
                                    DishDescription = "Jeśli zastanawiacie się, co przygotować na letnie spotkanie z przyjaciółmi, ten prosty przepis z pewnością się wam spodoba. To pomysł na nieoczywistą przekąskę, która znika z talerza w mgnieniu oka. Z ciasta francuskiego wytnijcie nieduże kółka, posmarujcie je musztardą i na każdym z nich ułóżcie plaster pomidora. Wierzch delikatnie posólcie, posłodźcie i posypcie oregano. Później zostanie wam już tylko pieczenie. Ciasteczka wstawcie do piekarnika, gdy goście już się schodzą – najlepiej smakują prosto z pieca.Ta prosta przekąska świetnie pasuje do chłodnego różowego wina.",
                                    Size = 3,
                                    MethodOfPeparation = "Ciasto rozmrażamy powoli w lodówce, w opakowaniu. Rozwijamy ciasto na pergaminie i wycinamy z niego nieduże kółka, mniej więcej równe średnicy pomidora. Piekarnik rozgrzewamy do 200 stopni. Pomidory kroimy poziomo („po równiku”) w plastry grubości ½ centymetra. Kółka ciasta smarujemy musztardą. Na każdym układamy plaster pomidora. Wierzch delikatnie solimy, słodzimy, posypujemy oregano.",
                                    PreparationTime = 1,
                                    Portions = 3
                                }
                            }
                        }
                    },
                    Snack = new Snack()
                    {
                        Dishes = new List<SnackDish>()
                        {
                            new SnackDish()
                            {
                                Dish = new Dish()
                                {
                                    DishName = "Pieczone powoli pomidory",
                                    DishProducts = new List<ProductDish>()
                                    {
                                        new ProductDish()
                                        {
                                            Product = new Product()
                                            {
                                                ProductName = "Pieprz",
                                                Weight = 5
                                            }
                                        }
                                    },
                                    DishDescription = "Z soczystych, pękatych pomidorów – niekwestionowanych gwiazd letniego sezonu – tym razem przygotowujemy pyszne wegańskie danie. Pieczenie tych warzyw wydobywa z nich słodycz i sprawia, że świetnym smakiem można cieszyć się też poza sezonem. Pst! Pieczone pomidory mają wspaniały, skoncentrowany smak. Po ich przygotowaniu możecie zalać je oliwą i przechowywać w lodówce przez kilka-kilkanaście dni albo zamrozić na zimę.",
                                    Size = 3,
                                    MethodOfPeparation = "Pomidory płuczemy, osuszamy, kroimy na pół (pionowo) i wycinamy miejsca po ogonkach. Czosnek kroimy w cienkie plasterki Rozkładamy połówki ciasno na pergaminie na blasze do pieczenia, cięciem do góry. Delikatnie skrapiamy oliwą po wierzchu, posypujemy ziołami, plasterkami czosnku i przyprawami.",
                                    PreparationTime = 1,
                                    Portions = 3
                                }
                            }
                        }
                    },
                    Dinner = new Dinner()
                    {
                        Dishes = new List<DinnerDish>()
                        {
                            new DinnerDish()
                            {
                                Dish = new Dish()
                                {
                                    DishName = "Bakłażan duszony w pomidorach",
                                    DishProducts = new List<ProductDish>()
                                    {
                                        new ProductDish()
                                        {
                                            Product = new Product()
                                            {
                                                ProductName = "Cukier",
                                                Weight = 5
                                            }
                                        }
                                    },
                                    DishDescription = "To pyszne danie można podać zarówno na ciepło, jak i na zimno. Świetnie sprawdzi się też w formie zmiksowanego kremu. Choć we Włoszech tę wersję bakłażana często podaje się jako antipasti, śmiało można serwować ją też na obiad. Uwaga – bakłażany smażone na ciepłej oliwie chłoną ją jak gąbka. Oliwa musi być bardzo gorąca, ale nie dymiąca. Bakłażany smażcie partiami i odsączajcie z tłuszczu.",
                                    Size = 3,
                                    MethodOfPeparation = "Bakłażany kroimy wzdłuż w plastry grubości 1½ centymetra, a następnie w grube słupki. Solimy, odstawiamy na sicie, by puściły sok. Po 20 minutach wyciskamy nadmiar wody i osuszamy słupki bakłażana ręcznikiem papierowym. Na patelni rozgrzewamy oliwę, smażymy na niej bakłażany partiami, by nie przepełnić patelni. Usmażone zdejmujemy i odkładamy. Pomidory grubo kroimy, czosnek siekamy.",
                                    PreparationTime = 1,
                                    Portions = 3
                                }
                            }
                        }
                    }
                }
            };
        }

        /// <summary>
        /// Metoda zwracająca kolekcję wtorków, które będą zawsze istnieć w tabeli tuesday
        /// baza automatycznie przydzieli id
        /// </summary>
        private static IEnumerable<Tuesday> GetTuesdays()
        {
            return new List<Tuesday>
            {
                new Tuesday()
                {
                    Breakfast = new Breakfast()
                    {
                        Dishes = new List<BreakfastDish>()
                        {
                            new BreakfastDish()
                            {
                                Dish = new Dish()
                                {
                                    DishName = "Sałatka z żółtych pomidorów, fety i bobu",
                                    DishProducts = new List<ProductDish>()
                                    {
                                        new ProductDish()
                                        {
                                            Product = new Product()
                                            {
                                                ProductName = "Sok z cytryny",
                                                Weight = 40
                                            }
                                        }
                                    },
                                    DishDescription = "W tej prostej sałatce znajdują się nasze ulubione letnie składniki! Soczyste pomidory, sycący bób, słona feta i koperkowo-cytrynowy winegret to połączenie, które sprawdzi się na lunch lub lekki obiad. To danie doda wam energii i sprawi, że nawet w największe upały będziecie uśmiechać się przez cały dzień. Czas, gdy bób jest jeszcze młody, a pomidory już dojrzałe, trwa krótko. Jeśli bób już wyrósł i stał się zbyt mączysty, lepiej sięgnąć po ten mrożony. Wtedy blanszujcie go w posłodzonym i posolonym wrzątku, odcedźcie i obierzcie.",
                                    Size = 1,
                                    MethodOfPeparation = "W słoiku umieszczamy składniki sosu – oprócz przypraw. Zakręcamy słoik i mieszamy, energicznie potrząsając. Dodajemy sól i pieprz do smaku.",
                                    PreparationTime = 1,
                                    Portions = 4
                                }
                            }
                        }
                    },
                    SecondBreakfast = new SecondBreakfast()
                    {
                        Dishes = new List<SecondBreakfastDish>()
                        {
                            new SecondBreakfastDish()
                            {
                                Dish = new Dish()
                                {
                                    DishName = "Zupa z soczewicy z morelami",
                                    DishProducts = new List<ProductDish>()
                                    {
                                        new ProductDish()
                                        {
                                            Product = new Product()
                                            {
                                                ProductName = "Bulion warzywny",
                                                Weight = 1000
                                            }
                                        }
                                    },
                                    DishDescription = "To propozycja pożywnej i gęstej zupy, która rozgrzeje was w chłodne popołudnie. Przypomina klasyczny dahl, ale dzięki morelom ma słodki, karmelowy posmak. Ten prosty przepis świetnie sprawdzi się na szybki obiad lub wczesną kolację. Gotowanie zajmie wam jedynie 30 minut. Soczewicę opłuczcie, a potem ugotujcie z morelami i bulionem warzywnym. Przyprawcie sokiem z cytryny i pieprzem. Ostrość chili świetnie zbalansuje słodycz suszonych moreli.",
                                    Size = 1,
                                    MethodOfPeparation = "Soczewicę przebieramy i dokładnie opłukujemy.",
                                    PreparationTime = 30,
                                    Portions = 4
                                }
                            }
                        }
                    },
                    Lunch = new Lunch()
                    {
                        Dishes = new List<LunchDish>()
                        {
                            new LunchDish()
                            {
                                Dish = new Dish()
                                {
                                    DishName = "Aromatyczna szakszuka z botwiną",
                                    DishProducts = new List<ProductDish>()
                                    {
                                        new ProductDish()
                                        {
                                            Product = new Product()
                                            {
                                                ProductName = "Cebula",
                                                Weight = 120
                                            }
                                        }
                                    },
                                    DishDescription = "Cebulę obierz i drobno posiekaj. Chili przekrój wzdłuż na pół. Jeśli wolisz wersję mniej pikantną, usuń pestki. Posiekaj w drobną kostkę. Czosnek utrzyj na tarce o drobnych oczkach. Botwinę umyj, łodygi drobno posiekaj, liście porwij na grube wstążki, mniejsze zostaw w całości. Kumin i kolendrę upraż na suchej patelni i utrzyj w moździerzu. Do głębokiej patelni wlej olej i wrzuć cebulę z chili. Posól i postaw patelnię na średnim ogniu. Smaż powoli, aż cebula stanie się szklista. Następnie dorzuć posiekane łodygi botwiny i czosnek. Podgrzewaj, aż poczujesz zapach czosnku. Pilnuj, by się nie przypalił. Dodaj kumin, kolendrę i wędzoną paprykę i smaż przez około 1 minutę. ",
                                    Size = 1,
                                    MethodOfPeparation = "Nalej do garnka wodę i włóż do niej jajka. Czekaj aż woda się zagotuje. Od momentu zagotowania się wody, gotuj jajka dokładnie 8 minut. Po upływie tego czasu wylej wodę z garnka.",
                                    PreparationTime = 25,
                                    Portions = 4
                                }
                            }
                        }
                    },
                    Snack = new Snack()
                    {
                        Dishes = new List<SnackDish>()
                        {
                            new SnackDish()
                            {
                                Dish = new Dish()
                                {
                                    DishName = "Caponata",
                                    DishProducts = new List<ProductDish>()
                                    {
                                        new ProductDish()
                                        {
                                            Product = new Product()
                                            {
                                                ProductName = "Bakłażan",
                                                Weight = 300
                                            }
                                        }
                                    },
                                    DishDescription = "Jak zrobić caponatę? Każda kucharka i każdy kucharz z południowych Włoch ma swój własny przepis na to słynne danie. Caponata to po prostu potrawa z bakłażana i pomidorów. Jeśli macie na nią ochotę, zróbcie ją szybko i nie żałujcie oliwy – na pewno wyjdzie pyszna! To proste, jednogarnkowe danie wegańskie świetnie sprawdzi się jako obiad dla całej rodziny – zasmakuje nie tylko dorosłym, ale także dzieciom. Gotowej caponaty nie zapomnijcie posypać grubo pokrojoną natką pietruszki!",
                                    Size = 1,
                                    MethodOfPeparation = "Na dużym ogniu obsmażamy bakłażana pokrojonego w spore kawałki, będzie pił oliwę jak szalony, nie przejmujcie się tym, posypcie go oregano. Gdy go trochę ozłoci, wrzucamy pokrojony czosnek i smażymy jeszcze chwilę.",
                                    PreparationTime = 25,
                                    Portions = 4
                                }
                            }
                        }
                    },
                    Dinner = new Dinner()
                    {
                        Dishes = new List<DinnerDish>()
                        {
                            new DinnerDish()
                            {
                                Dish = new Dish()
                                {
                                    DishName = "Bozbasz – gruzińska zupa z jagnięciną",
                                    DishProducts = new List<ProductDish>()
                                    {
                                        new ProductDish()
                                        {
                                            Product = new Product()
                                            {
                                                ProductName = "Czosnek",
                                                Weight = 50
                                            }
                                        }
                                    },
                                    DishDescription = "Prosty przepis, który z pewnością spodoba się wszystkim amatorom kuchni gruzińskiej. Ta rozgrzewająca i sycąca dzięki dodatkowi kaszy jęczmiennej i klopsów z jagnięciny zupa doskonale sprawdzi się jako szybki i pożywny obiad dla całej rodziny. Cebulę obierzcie, pokrójcie w drobną kostkę i razem ze startym czosnkiem, z pastą chili i przyprawami usmażcie na oliwie w dużym garnku. Potem dodajcie koncentrat pomidorowy i bulion i doprowadźcie do wrzenia. Z mięsa uformujcie klopsy i dodajcie do gotującego się bulionu. Gotową zupę koniecznie posypcie obficie kolendrą!",
                                    Size = 1,
                                    MethodOfPeparation = "Cebulę obieramy, kroimy w drobną kostkę i podsmażamy w dużym garnku na oliwie wraz ze startym czosnkiem, pastą chili i przyprawami. Kiedy się zeszkli, dodajemy koncentrat pomidorowy, dolewamy bulion i doprowadzamy do wrzenia.",
                                    PreparationTime = 40,
                                    Portions = 4
                                }
                            }
                        }
                    }
                }
            };
        }

        /// <summary>
        /// Metoda zwracająca kolekcję śród, które będą zawsze istnieć w tabeli wednesday
        /// baza automatycznie przydzieli id
        /// </summary>
        private static IEnumerable<Wednesday> GetWednesdays()
        {
            return new List<Wednesday>
            {
                new Wednesday()
                {
                    Breakfast = new Breakfast()
                    {
                        Dishes = new List<BreakfastDish>()
                        {
                            new BreakfastDish()
                            {
                                Dish = new Dish()
                                {
                                    DishName = "Krem pomidorowy z pieczoną papryką",
                                    DishProducts = new List<ProductDish>()
                                    {
                                        new ProductDish()
                                        {
                                            Product = new Product()
                                            {
                                                ProductName = "Czerowna papryka",
                                                Weight = 200
                                            }
                                        }
                                    },
                                    DishDescription = "Niestraszny nam chłodny wieczór, gdy mamy przed sobą miskę gorącej zupy. Delikatny i aromatyczny krem pomidorowy z pieczoną papryką to jedna z pyszniejszych propozycji na lato. I doskonały pomysł na obiad dla dziecka niejadka – co więcej, do przygotowania w zaledwie 40 minut. Nie tylko rozgrzewa, ale także przenosi w słoneczne rejony świata, gdy pogoda nie rozpieszcza!",
                                    Size = 2,
                                    MethodOfPeparation = "Pomidory kroimy na ćwiartki, cebulę w piórka, czosnek i paprykę przekrawamy na pół. Układamy na blaszce z papierem do pieczenia, posypujemy solą, pieprzem i polewamy oliwą. ",
                                    PreparationTime = 40,
                                    Portions = 1
                                }
                            }
                        }
                    },
                    SecondBreakfast = new SecondBreakfast()
                    {
                        Dishes = new List<SecondBreakfastDish>()
                        {
                            new SecondBreakfastDish()
                            {
                                Dish = new Dish()
                                {
                                    DishName = "Śniadaniowy podpłomyk z awokado i pomidorami",
                                    DishProducts = new List<ProductDish>()
                                    {
                                        new ProductDish()
                                        {
                                            Product = new Product()
                                            {
                                                ProductName = "Woda",
                                                Weight = 150
                                            }
                                        }
                                    },
                                    DishDescription = "To proste danie wyciągnie z łóżka nawet największych śpiochów. Podpłomyk z dodatkiem jajka, awokado i mozzarelli nie ma sobie równych. Ciasto przygotujcie z mąki pszennej, drożdży i odrobiny cukru. Po rozwałkowaniu przełóżcie je na rozgrzaną blachę wyłożoną papierem do pieczenia i upieczcie. Jajka dodajcie na koniec – na wierzch pizzy – i zapieczcie placek. Ciasto na pizzę możecie przygotować dzień wcześniej i zostawić na noc do wyrośnięcia.",
                                    Size = 2,
                                    MethodOfPeparation = "Mieszamy mąkę z drożdżami, solą oraz cukrem. Stopniowo dodajemy wodę i oliwę. Mieszamy, aż składniki się połączą. Przekładamy ciasto na posypaną mąką powierzchnię i ugniatamy przez około 10 minut, aż stanie się gładkie i elastyczne. Gotowe umieszczamy w nasmarowanej olejem misce, przykrywamy i odkładamy w ciepłe miejsce na ok. 60 minut, do podwojenia objętości. ",
                                    PreparationTime = 90,
                                    Portions = 1
                                }
                            }
                        }
                    },
                    Lunch = new Lunch()
                    {
                        Dishes = new List<LunchDish>()
                        {
                            new LunchDish()
                            {
                                Dish = new Dish()
                                {
                                    DishName = "Domowy ketchup",
                                    DishProducts = new List<ProductDish>()
                                    {
                                        new ProductDish()
                                        {
                                            Product = new Product()
                                            {
                                                ProductName = "Łyżka oleju kokosowego",
                                                Weight = 25
                                            }
                                        }
                                    },
                                    DishDescription = "Ten domowy ketchup z dojrzałych letnich pomidorów jest aromatyczny i pełen smaku. Pasuje niemal do wszystkiego, jest także znacznie zdrowszy niż sklepowy! Na start dajemy wam małą podpowiedź – aby obrać pomidory ze skórki, zalejcie je w dużej misce wrzątkiem z czajnika. Po kilku minutach wystarczy je wyjąć i naciąć na krzyż po stronie przeciwnej do ogonka, a skórka sama zacznie schodzić. To najtrudniejsza część przepisu – dalej pójdzie szybko, wystarczy zmiksować wszystkie składniki, by całą jesień i zimę cieszyć się pomidorowym smakiem.",
                                    Size = 2,
                                    MethodOfPeparation = "Pomidory obieramy i kroimy w niewielkie kawałki. W garnku rozgrzewamy olej, dodajemy poszatkowaną cebulę i smażymy, mieszając od czasu do czasu, aż się zeszkli. Dodajemy czosnek i smażymy, mieszając przez kolejną minutę.Dolewamy ocet, dorzucamy pokrojone pomidory i wszystkie przyprawy, gotujemy przez około 20 minut.",
                                    PreparationTime = 60,
                                    Portions = 1
                                }
                            }
                        }
                    },
                    Snack = new Snack()
                    {
                        Dishes = new List<SnackDish>()
                        {
                            new SnackDish()
                            {
                                Dish = new Dish()
                                {
                                    DishName = "Zupa krem z pomidorów i dyni",
                                    DishProducts = new List<ProductDish>()
                                    {
                                        new ProductDish()
                                        {
                                            Product = new Product()
                                            {
                                                ProductName = "Dynia",
                                                Weight = 1000
                                            }
                                        }
                                    },
                                    DishDescription = "Zanim skończy się sezon na pomidory, na straganach pojawią się pierwsze dynie – warto więc dać im szansę w duecie. Warzywa upieczcie z rozmarynem, a potem zblendujcie z mleczkiem kokosowym. Zupę posypcie pestkami dyni i skropcie paroma kroplami oliwy.",
                                    Size = 2,
                                    MethodOfPeparation = "Piekarnik rozgrzewamy do 180 stopni. Wszystkie warzywa myjemy i kroimy na pół. Rozkładamy kawałki na blaszce, następnie skrapiamy oliwą z oliwek. Gałązkę rozmarynu kładziemy na wierzch i wstawiamy do piekarnika. Pieczemy aż dynia zmieknie - około 60 minut.",
                                    PreparationTime = 30,
                                    Portions = 1
                                }
                            }
                        }
                    },
                    Dinner = new Dinner()
                    {
                        Dishes = new List<DinnerDish>()
                        {
                            new DinnerDish()
                            {
                                Dish = new Dish()
                                {
                                    DishName = "Kluski śląskie z sosem grzybowym",
                                    DishProducts = new List<ProductDish>()
                                    {
                                        new ProductDish()
                                        {
                                            Product = new Product()
                                            {
                                                ProductName = "Pieczarki",
                                                Weight = 200
                                            }
                                        }
                                    },
                                    DishDescription = "Przykładowy opis",
                                    Size = 2,
                                    MethodOfPeparation = "Przygotowujemy kluski. Ziemniaki gotujemy w osolonej wodzie do miękkości. Odcedzamy i odparowujemy. Jeszcze gorące przecieramy lub przeciskamy przez praskę. Zostawiamy do ostygnięcia. ",
                                    PreparationTime = 40,
                                    Portions = 1
                                }
                            }
                        }
                    }
                }
            };
        }

        /// <summary>
        /// Metoda zwracająca kolekcję czwartków, które będą zawsze istnieć w tabeli thursday
        /// baza automatycznie przydzieli id
        /// </summary>
        private static IEnumerable<Thursday> GetThursdays()
        {
            return new List<Thursday>
            {
                new Thursday()
                {
                    Breakfast = new Breakfast()
                    {
                        Dishes = new List<BreakfastDish>()
                        {
                            new BreakfastDish()
                            {
                                Dish = new Dish()
                                {
                                    DishName = "Placki ziemniaczane z sosem buraczanym",
                                    DishProducts = new List<ProductDish>()
                                    {
                                        new ProductDish()
                                        {
                                            Product = new Product()
                                            {
                                                ProductName = "Serek kremowy",
                                                Weight = 200
                                            }
                                        }
                                    },
                                    DishDescription = "Przykładowy opis",
                                    Size = 3,
                                    MethodOfPeparation = "Przygotowujemy sos. Buraka obieramy i kroimy w drobną kostkę. Gotujemy do miękkości, studzimy, a następnie blendujemy razem z serkiem i octem balsamicznym. Doprawiamy solą i pieprzem.",
                                    PreparationTime = 60,
                                    Portions = 1
                                }
                            }
                        }
                    },
                    SecondBreakfast = new SecondBreakfast()
                    {
                        Dishes = new List<SecondBreakfastDish>()
                        {
                            new SecondBreakfastDish()
                            {
                                Dish = new Dish()
                                {
                                    DishName = "Karczochy z ricottą, ziemniakami i jabłkami w cieście",
                                    DishProducts = new List<ProductDish>()
                                    {
                                        new ProductDish()
                                        {
                                            Product = new Product()
                                            {
                                                ProductName = "Mąka",
                                                Weight = 300
                                            }
                                        }
                                    },
                                    DishDescription = "Przykładowy opis",
                                    Size = 3,
                                    MethodOfPeparation = "Przygotowujemy ciasto do ryby – do miski wsypujemy mąkę, drożdże i wlewamy zimną wodę gazowaną. Mieszamy składniki łyżką, aż ciasto będzie gęste i płynne. Przykrywamy je folią i odstawiamy na 30 minut w ciepłe miejsce. ",
                                    PreparationTime = 90,
                                    Portions = 1
                                }
                            }
                        }
                    },
                    Lunch = new Lunch()
                    {
                        Dishes = new List<LunchDish>()
                        {
                            new LunchDish()
                            {
                                Dish = new Dish()
                                {
                                    DishName = "Dorada z ziemniakami i pomidorkami cherry",
                                    DishProducts = new List<ProductDish>()
                                    {
                                        new ProductDish()
                                        {
                                            Product = new Product()
                                            {
                                                ProductName = "Dorada",
                                                Weight = 900
                                            }
                                        }
                                    },
                                    DishDescription = "Przykładowy opis",
                                    Size = 3,
                                    MethodOfPeparation = "Oczyszczoną doradę wypełniamy gałązkami rozmarynu i tymianku, dwoma ząbkami czosnku, przyprawiamy solą i pieprzem. Odstawiamy. ",
                                    PreparationTime = 35,
                                    Portions = 1
                                }
                            }
                        }
                    },
                    Snack = new Snack()
                    {
                        Dishes = new List<SnackDish>()
                        {
                            new SnackDish()
                            {
                                Dish = new Dish()
                                {
                                    DishName = "Pieczone ziemniaki z sosem grzybowym z boczkiem",
                                    DishProducts = new List<ProductDish>()
                                    {
                                        new ProductDish()
                                        {
                                            Product = new Product()
                                            {
                                                ProductName = "Prawdziwki",
                                                Weight = 300
                                            }
                                        }
                                    },
                                    DishDescription = "Przykładowy opis",
                                    Size = 3,
                                    MethodOfPeparation = "Piekarnik nagrzewamy do 200 stopni. Ziemniaki dokładnie myjemy i nacinamy na krzyż. Polewamy je oliwą i posypujemy solą – dokładnie ją na nich rozsmarowujemy. Pieczemy 60-90 minut – do miękkości.",
                                    PreparationTime = 3,
                                    Portions = 1
                                }
                            }
                        }
                    },
                    Dinner = new Dinner()
                    {
                        Dishes = new List<DinnerDish>()
                        {
                            new DinnerDish()
                            {
                                Dish = new Dish()
                                {
                                    DishName = "Delikatne placki ziemniaczane z sosem kurkowym i jajkiem w koszulce",
                                    DishProducts = new List<ProductDish>()
                                    {
                                        new ProductDish()
                                        {
                                            Product = new Product()
                                            {
                                                ProductName = "Dwie łyżki masła",
                                                Weight = 24
                                            }
                                        }
                                    },
                                    DishDescription = "Przykładowy opis",
                                    Size = 3,
                                    MethodOfPeparation = "Obrane ziemniaki gotujemy w osolonej wodzie do miękkości. Odcedzamy, zgniatamy i odstawiamy do ostudzenia na 10-15 minut. Cebulę ścieramy na tarce o małych oczkach, dodajemy mąkę i sól (⅓ łyżeczki) i dokładnie mieszamy. Z ciasta formujemy kulki i spłaszczamy je. Smażymy z dwóch stron na rozgrzanej patelni, na oleju. Odkładamy na papierowy ręcznik, by odsączyć z nadmiaru tłuszczu.",
                                    PreparationTime = 3,
                                    Portions = 1
                                }
                            }
                        }
                    }
                }
            };
        }

        /// <summary>
        /// Metoda zwracająca kolekcję piątków, które będą zawsze istnieć w tabeli friday
        /// baza automatycznie przydzieli id
        /// </summary>
        private static IEnumerable<Friday> GetFridays()
        {
            return new List<Friday>
            {
                new Friday()
                {
                    Breakfast = new Breakfast()
                    {
                        Dishes = new List<BreakfastDish>()
                        {
                            new BreakfastDish()
                            {
                                Dish = new Dish()
                                {
                                    DishName = "Zupa z pora i pomidorów malinowych z chrupiącymi pulpetami",
                                    DishProducts = new List<ProductDish>()
                                    {
                                        new ProductDish()
                                        {
                                            Product = new Product()
                                            {
                                                ProductName = "Tarty parmezan",
                                                Weight = 20
                                            }
                                        }
                                    },
                                    DishDescription = "Przykładowy opis",
                                    Size = 1,
                                    MethodOfPeparation = "Mielonego indyka wkładamy do miski. Pośrodku robimy wgłębienie, do którego wrzucamy przeciśnięty przez praskę ząbek czosnku, całe jajko, sól, pieprz, gałkę muszkatołową, mieloną kolendrę, starty parmezan i panko (20 gramów). Energicznie zagniatamy, aż powstanie spójna masa. Z mięsa formujemy pulpeciki wielkości orzecha włoskiego, obtaczamy je dokładnie w panko i układamy na desce wyłożonej papierem do pieczenia. Tak przygotowane pulpety wstawiamy do lodówki na 20 minut.",
                                    PreparationTime = 60,
                                    Portions = 1
                                }
                            }
                        }
                    },
                    SecondBreakfast = new SecondBreakfast()
                    {
                        Dishes = new List<SecondBreakfastDish>()
                        {
                            new SecondBreakfastDish()
                            {
                                Dish = new Dish()
                                {
                                    DishName = "Sycąca zupa z pora z mięsem mielonym",
                                    DishProducts = new List<ProductDish>()
                                    {
                                        new ProductDish()
                                        {
                                            Product = new Product()
                                            {
                                                ProductName = "Por",
                                                Weight = 300
                                            }
                                        }
                                    },
                                    DishDescription = "Przykładowy opis",
                                    Size = 1,
                                    MethodOfPeparation = "Cebulę, czosnek i ziemniaki obieramy, kroimy w kostkę. Pora myjemy, osuszamy i kroimy w plasterki.",
                                    PreparationTime = 60,
                                    Portions = 1
                                }
                            }
                        }
                    },
                    Lunch = new Lunch()
                    {
                        Dishes = new List<LunchDish>()
                        {
                            new LunchDish()
                            {
                                Dish = new Dish()
                                {
                                    DishName = "Sałatka ziemniaczana z porem i marynowanymi grzybami",
                                    DishProducts = new List<ProductDish>()
                                    {
                                        new ProductDish()
                                        {
                                            Product = new Product()
                                            {
                                                ProductName = "Ogórek konserwowy",
                                                Weight = 100
                                            }
                                        }
                                    },
                                    DishDescription = "Przykładowy opis",
                                    Size = 1,
                                    MethodOfPeparation = "Ziemniaki obieramy, kroimy w grube półplastry i gotujemy al dente w osolonej wodzie. Pora oczyszczamy i kroimy w cienkie plasterki. Na patelni rozgrzewamy oliwę i wrzucamy na nią pora. Dusimy go przez 3-4 minuty, do miękkości. Zdejmujemy z patelni i studzimy.",
                                    PreparationTime = 4,
                                    Portions = 1
                                }
                            }
                        }
                    },
                    Snack = new Snack()
                    {
                        Dishes = new List<SnackDish>()
                        {
                            new SnackDish()
                            {
                                Dish = new Dish()
                                {
                                    DishName = "Tarta z porem na ziemniaczanym spodzie",
                                    DishProducts = new List<ProductDish>()
                                    {
                                        new ProductDish()
                                        {
                                            Product = new Product()
                                            {
                                                ProductName = "Śmietana 18%",
                                                Weight = 30
                                            }
                                        }
                                    },
                                    DishDescription = "Przykładowy opis",
                                    Size = 1,
                                    MethodOfPeparation = "Piekarnik rozgrzewamy do 185 stopni. Ugotowane i przestudzone ziemniaki przeciskamy przez praskę lub blendujemy w malakserze na gładkie purée. Do masy dodajemy jajko, mąkę i sól i wyrabiamy zwarte ciasto.",
                                    PreparationTime = 70,
                                    Portions = 1
                                }
                            }
                        }
                    },
                    Dinner = new Dinner()
                    {
                        Dishes = new List<DinnerDish>()
                        {
                            new DinnerDish()
                            {
                                Dish = new Dish()
                                {
                                    DishName = "Faworki z ziemniaków",
                                    DishProducts = new List<ProductDish>()
                                    {
                                        new ProductDish()
                                        {
                                            Product = new Product()
                                            {
                                                ProductName = "Mąka pszenna",
                                                Weight = 250
                                            }
                                        }
                                    },
                                    DishDescription = "Przykładowy opis",
                                    Size = 1,
                                    MethodOfPeparation = "Ziemniaki obierz, ugotuj, odcedź. Gorące dokładnie utłucz na purée. Dodaj mąkę, sól i cukier puder lub zioła, jeśli robisz faworki wytrawne. Dokładnie i szybko wyrób elastyczne ciasto. Ilość mąki zależy od rodzaju ziemniaków, więc jeśli ciasto klei ci się do rąk, dodaj jej trochę więcej. Ciasto podziel na kilka części. Posyp blat mąką i rozwałkuj ciasto na prostokąt grubości 5 mm, będzie ci łatwiej go pokroić na prostokąty. Wykrawaj kawałki o wymiarach 3 x 10 cm. W każdym prostokącie zrób na środku nacięcie i przewlecz przez nie jeden koniec, jak w klasycznych faworkach.",
                                    PreparationTime = 60,
                                    Portions = 1
                                }
                            }
                        }
                    }
                }
            };
        }

        /// <summary>
        /// Metoda zwracająca kolekcję sobót, które będą zawsze istnieć w tabeli saturday
        /// baza automatycznie przydzieli id
        /// </summary>
        private static IEnumerable<Saturday> GetSaturdays()
        {
            return new List<Saturday>
            {
                new Saturday()
                {
                    Breakfast = new Breakfast()
                    {
                        Dishes = new List<BreakfastDish>()
                        {
                            new BreakfastDish()
                            {
                                Dish = new Dish()
                                {
                                    DishName = "Podlaska babka ziemniaczana",
                                    DishProducts = new List<ProductDish>()
                                    {
                                        new ProductDish()
                                        {
                                            Product = new Product()
                                            {
                                                ProductName = "Grzyby suszone",
                                                Weight = 200
                                            }
                                        }
                                    },
                                    DishDescription = "Przykładowy opis",
                                    Size = 2,
                                    MethodOfPeparation = "Obierz ziemniaki i zetrzyj na tarce o małych oczkach. Cebulę pokrój w kostkę. Na patelni rozgrzej olej, wrzuć cebulę i zeszklij. Do masy ziemniaczanej dodaj mąkę, cebulę, olej. Dopraw solą i niewielką ilością świeżo zmielonego pieprzu. Masa powinna być nieco luźniejsza niż na placki ziemniaczane.",
                                    PreparationTime = 90,
                                    Portions = 1
                                }
                            }
                        }
                    },
                    SecondBreakfast = new SecondBreakfast()
                    {
                        Dishes = new List<SecondBreakfastDish>()
                        {
                            new SecondBreakfastDish()
                            {
                                Dish = new Dish()
                                {
                                    DishName = "Sałatka ziemniaczana z groszkiem",
                                    DishProducts = new List<ProductDish>()
                                    {
                                        new ProductDish()
                                        {
                                            Product = new Product()
                                            {
                                                ProductName = "Dwie łyżki octu winnego",
                                                Weight = 20
                                            }
                                        }
                                    },
                                    DishDescription = "Przykładowy opis",
                                    Size = 2,
                                    MethodOfPeparation = "Młode ziemniaki dokładnie myjemy, niebieskie lub fioletowe obieramy i kroimy na połówki. Wszystkie ziemniaki gotujemy w osolonej wodzie do miękkości. Odcedzamy i studzimy.",
                                    PreparationTime = 30,
                                    Portions = 1
                                }
                            }
                        }
                    },
                    Lunch = new Lunch()
                    {
                        Dishes = new List<LunchDish>()
                        {
                            new LunchDish()
                            {
                                Dish = new Dish()
                                {
                                    DishName = "Sałatka ziemniaczana z fasolką szparagową",
                                    DishProducts = new List<ProductDish>()
                                    {
                                        new ProductDish()
                                        {
                                            Product = new Product()
                                            {
                                                ProductName = "Fasolka szparagowa",
                                                Weight = 150
                                            }
                                        }
                                    },
                                    DishDescription = "Przykładowy opis",
                                    Size = 2,
                                    MethodOfPeparation = "Fasolkę i ziemniaki dokładnie myjemy. Odcinamy zdrewniałe końcówki fasolki i tniemy strączki na pół. Jeśli ziemniaki są młode, zostawiamy je w skórce, jeśli nie – obieramy i kroimy na kawałki. Warzywa gotujemy w osolonej wodzie w oddzielnych garnkach, aż będą miękkie, ale nie rozgotowane. Odsączamy i studzimy. Do ziemniaków wlewamy wino i dokładnie mieszamy.",
                                    PreparationTime = 30,
                                    Portions = 1
                                }
                            }
                        }
                    },
                    Snack = new Snack()
                    {
                        Dishes = new List<SnackDish>()
                        {
                            new SnackDish()
                            {
                                Dish = new Dish()
                                {
                                    DishName = "Ogórkowa na ogórkach małosolnych",
                                    DishProducts = new List<ProductDish>()
                                    {
                                        new ProductDish()
                                        {
                                            Product = new Product()
                                            {
                                                ProductName = "Marchewka",
                                                Weight = 60
                                            }
                                        }
                                    },
                                    DishDescription = "Przykładowy opis",
                                    Size = 2,
                                    MethodOfPeparation = "Cebulę i czosnek obieramy, a następnie siekamy. Obrane marchewkę i ziemniaki kroimy w większą kostkę.",
                                    PreparationTime = 45,
                                    Portions = 1
                                }
                            }
                        }
                    },
                    Dinner = new Dinner()
                    {
                        Dishes = new List<DinnerDish>()
                        {
                            new DinnerDish()
                            {
                                Dish = new Dish()
                                {
                                    DishName = "Kalafiorowa z ziemniakami",
                                    DishProducts = new List<ProductDish>()
                                    {
                                        new ProductDish()
                                        {
                                            Product = new Product()
                                            {
                                                ProductName = "Połowa pęczka kopru",
                                                Weight = 32
                                            }
                                        }
                                    },
                                    DishDescription = "Przykładowy opis",
                                    Size = 2,
                                    MethodOfPeparation = "Białą część dymki i pora kroimy w grube plasterki. Czosnek obieramy i siekamy. Marchewki obieramy i kroimy w plastry. Obrane ziemniaki kroimy w kostkę, a kalafior myjemy i dzielimy na różyczki.",
                                    PreparationTime = 45,
                                    Portions = 1
                                }
                            }
                        }
                    }
                }
            };
        }

        /// <summary>
        /// Metoda zwracająca kolekcję niedziel, które będą zawsze istnieć w tabeli sunday
        /// baza automatycznie przydzieli id
        /// </summary>
        private static IEnumerable<Sunday> GetSundays()
        {
            return new List<Sunday>
            {
                new Sunday()
                {
                    Breakfast = new Breakfast()
                    {
                        Dishes = new List<BreakfastDish>()
                        {
                            new BreakfastDish()
                            {
                                Dish = new Dish()
                                {
                                    DishName = "Szczawiowa na wędzonce ze smażonymi ziemniakami",
                                    DishProducts = new List<ProductDish>()
                                    {
                                        new ProductDish()
                                        {
                                            Product = new Product()
                                            {
                                                ProductName = "Żeberka wędzone",
                                                Weight = 300
                                            }
                                        }
                                    },
                                    DishDescription = "Przykładowy opis",
                                    Size = 3,
                                    MethodOfPeparation = "Żeberka myjemy, a następnie wkładamy do garnka. Mięso zalewamy wodą i gotujemy na wolnym ogniu przez 30 minut. W trakcie gotowania zbieramy powstały biały szum.",
                                    PreparationTime = 80,
                                    Portions = 2
                                }
                            }
                        }
                    },
                    SecondBreakfast = new SecondBreakfast()
                    {
                        Dishes = new List<SecondBreakfastDish>()
                        {
                            new SecondBreakfastDish()
                            {
                                Dish = new Dish()
                                {
                                    DishName = "Papryka nadziewana ryżem z warzywami z sosem ziołowym i ziemniakami konfitowanymi",
                                    DishProducts = new List<ProductDish>()
                                    {
                                        new ProductDish()
                                        {
                                            Product = new Product()
                                            {
                                                ProductName = "Cukinia",
                                                Weight = 200
                                            }
                                        }
                                    },
                                    DishDescription = "Przykładowy opis",
                                    Size = 3,
                                    MethodOfPeparation = "Ścinamy kapelusz papryki i czyścimy ją od środka. Czerwoną cebulę kroimy w kostkę, siekamy 2-3 ząbki czosnku, cukinię tniemy na drobne kawałki. Przygotowane warzywa odkładamy na bok. Ryż gotujemy w osolonej wodzie, aż będzie średnio miękki.",
                                    PreparationTime = 40,
                                    Portions = 2
                                }
                            }
                        }
                    },
                    Lunch = new Lunch()
                    {
                        Dishes = new List<LunchDish>()
                        {
                            new LunchDish()
                            {
                                Dish = new Dish()
                                {
                                    DishName = "Szaszłyk drobiowy z sosem Ljutenica, ziemniakami pieczonymi i sałatą z " +
                                    "kwaśną śmietaną",
                                    DishProducts = new List<ProductDish>()
                                    {
                                        new ProductDish()
                                        {
                                            Product = new Product()
                                            {
                                                ProductName = "Mielona wędzona papryka",
                                                Weight = 2
                                            }
                                        }
                                    },
                                    DishDescription = "Przykładowy opis",
                                    Size = 3,
                                    MethodOfPeparation = "Szatkujemy zioła, czosnek rozgniatamy i również siekamy, a chili drobno kroimy. Wszystko dokładnie mieszamy w misce z pozostałymi składnikami marynaty. Pierś kurczaka kroimy w kostkę i wkładamy do marynaty. Mięso odstawiamy do lodówki na 2-3 godziny.",
                                    PreparationTime = 45,
                                    Portions = 2
                                }
                            }
                        }
                    },
                    Snack = new Snack()
                    {
                        Dishes = new List<SnackDish>()
                        {
                            new SnackDish()
                            {
                                Dish = new Dish()
                                {
                                    DishName = "Ośmiornica z ziemniakami",
                                    DishProducts = new List<ProductDish>()
                                    {
                                        new ProductDish()
                                        {
                                            Product = new Product()
                                            {
                                                ProductName = "Szpinak",
                                                Weight = 500
                                            }
                                        }
                                    },
                                    DishDescription = "Przykładowy opis",
                                    Size = 3,
                                    MethodOfPeparation = "Ośmiornicę kroimy na nieduże kawałki, podgrzewamy na patelni razem z małymi ziemniakami.",
                                    PreparationTime = 3,
                                    Portions = 2
                                }
                            }
                        }
                    },
                    Dinner = new Dinner()
                    {
                        Dishes = new List<DinnerDish>()
                        {
                            new DinnerDish()
                            {
                                Dish = new Dish()
                                {
                                    DishName = "Pieczone w ognisku ziemniaki z chili",
                                    DishProducts = new List<ProductDish>()
                                    {
                                        new ProductDish()
                                        {
                                            Product = new Product()
                                            {
                                                ProductName = "Feta",
                                                Weight = 100
                                            }
                                        }
                                    },
                                    DishDescription = "Przykładowy opis",
                                    Size = 3,
                                    MethodOfPeparation = "Ognisko rozpalamy zawczasu, by powstało dużo żaru. Zakopujemy ziemniaki w gorącym żarze (podtrzymujemy niezbyt duży płomień ogniska), pieczemy co najmniej godzinę. Nakłuwamy i sprawdzamy, czy są miękkie.",
                                    PreparationTime = 60,
                                    Portions = 2
                                }
                            }
                        }
                    }
                }
            };
        }

        /// <summary>
        /// Metoda zwracająca kolekcję jadłospisów, które będą zawsze istnieć w tabeli menu
        /// baza automatycznie przydzieli id
        /// </summary>
        private static IEnumerable<Menu> GetMenus()
        {
            return new List<Menu>
            {
                new Menu()
                {
                    MenuName = "Treningowy",
                    MenuDescription = "Jadłospis na rzeźbę",
                    Monday = new Monday()
                    {
                        Breakfast = new Breakfast()
                        {
                            Dishes = new List<BreakfastDish>()
                            {
                                new BreakfastDish()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Sformato z karczochów, ziemniaków i ze schabu cielęcego",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Dwie sztuki karczocha",
                                                    Weight = 490
                                                }
                                            }
                                        },
                                        DishDescription = "Przykładowy opis",
                                        Size = 3,
                                        MethodOfPeparation = "Czyścimy karczochy w rękawiczkach – usuwamy najtwardsze liście, twardy rdzeń i ukryte w środku włoski. Karczochy namaczamy w misce z wodą zakwaszoną plastrami cytryny. Po upływie około 10 minut wyjmujemy karczochy z wody, odsączamy je, suszymy i kroimy w bardzo cienkie paski.",
                                        PreparationTime = 60,
                                        Portions = 3
                                    }
                                }
                            }
                        },
                        SecondBreakfast = new SecondBreakfast()
                        {
                            Dishes = new List<SecondBreakfastDish>()
                            {
                                new SecondBreakfastDish()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Pierogi z ziemniakami, kozim twarogiem i natką pietruszki",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Ciepłe mleko",
                                                    Weight = 300
                                                }
                                            }
                                        },
                                        DishDescription = "Przykładowy opis",
                                        Size = 3,
                                        MethodOfPeparation = "Składniki ciasta mieszamy w misce, a następnie zagniatamy. Gdy uzyskamy jednolitą i gładką masę, zawijamy ciasto w folię lub ściereczkę. Odstawiamy na 30 minut, aby odpoczęło.",
                                        PreparationTime = 90,
                                        Portions = 3
                                    }
                                }
                            }
                        },
                        Lunch = new Lunch()
                        {
                            Dishes = new List<LunchDish>()
                            {
                                new LunchDish()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Tortilla z ziemniaków ze szpinakiem i z natką pietruszki",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Liście szpinaku",
                                                    Weight = 250
                                                }
                                            }
                                        },
                                        DishDescription = "Przykładowy opis",
                                        Size = 3,
                                        MethodOfPeparation = "Cebulę kroimy w kostkę, szpinak i natkę pietruszki myjemy, a następnie siekamy. W garnku rozgrzewamy 3 łyżki oliwy i szklimy na niej cebulę. Dodajemy szpinak i natkę pietruszki. Solimy i smażymy do momentu, aż liście zwilgotnieją. Przekładamy z garnka na sito.",
                                        PreparationTime = 30,
                                        Portions = 3
                                    }
                                }
                            }
                        },
                        Snack = new Snack()
                        {
                            Dishes = new List<SnackDish>()
                            {
                                new SnackDish()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Dorsz w słodko-kwaśnej marynacie z pieczonymi ziemniakami",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Mango",
                                                    Weight = 400
                                                }
                                            }
                                        },
                                        DishDescription = "Przykładowy opis",
                                        Size = 3,
                                        MethodOfPeparation = "Przygotowujemy marynatę. Mango, ananasa z puszki, imbir i kolendrę kroimy na drobne kawałki. Wrzucamy do miski, dokładnie mieszamy i doprawiamy do smaku sokiem z cytryny, solą, białym pieprzem i ostrym sosem.",
                                        PreparationTime = 90,
                                        Portions = 3
                                    }
                                }
                            }
                        },
                        Dinner = new Dinner()
                        {
                            Dishes = new List<DinnerDish>()
                            {
                                new DinnerDish()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Pieczony seler z brukselką, ziemniakami i sosem z parmezanem",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Seler",
                                                    Weight = 525
                                                }
                                            }
                                        },
                                        DishDescription = "Przykładowy opis",
                                        Size = 3,
                                        MethodOfPeparation = "Piekarnik nagrzewamy do 170 stopni. Seler obieramy i płuczemy. Wcieramy w niego gałkę muszkatołową, pieprz, oliwę i sól. Owijamy warzywo w folię aluminiową i wstawiamy do piekarnika na mniej więcej 2 godziny.",
                                        PreparationTime = 165,
                                        Portions = 3
                                    }
                                }
                            }
                        }
                    },
                    Tuesday = new Tuesday()
                    {
                        Breakfast = new Breakfast()
                        {
                            Dishes = new List<BreakfastDish>()
                            {
                                new BreakfastDish()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Papryka faszerowana ziemniakami z kminkiem" +
                                        " i fetą z masłem cytrynowo-tymiankowym",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Łyżka miodu",
                                                    Weight = 25
                                                }
                                            }
                                        },
                                        DishDescription = "Przykładowy opis",
                                        Size = 1,
                                        MethodOfPeparation = "Papryki przecinamy w górnej części, pozbywamy się nasion. Odkładamy papryki na bok.",
                                        PreparationTime = 90,
                                        Portions = 4
                                    }
                                }
                            }
                        },
                        SecondBreakfast = new SecondBreakfast()
                        {
                            Dishes = new List<SecondBreakfastDish>()
                            {
                                new SecondBreakfastDish()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Fasola w orientalnym sosie na purée ziemniaczanym z boczniakami," +
                                        " wędzonym twarogiem i cytrynową sałatką",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Boczniaki ostrygowe",
                                                    Weight = 200
                                                }
                                            }
                                        },
                                        DishDescription = "Przykładowy opis",
                                        Size = 1,
                                        MethodOfPeparation = "Fasolę namaczamy w zimnej wodzie przez mniej więcej 12 godzin. Po tym czasie wymieniamy wodę, dodajemy zioła, posiekaną szalotkę i oliwę. Solimy i gotujemy na wolnym ogniu do miękkości, co zajmie około godziny.",
                                        PreparationTime = 120,
                                        Portions = 4
                                    }
                                }
                            }
                        },
                        Lunch = new Lunch()
                        {
                            Dishes = new List<LunchDish>()
                            {
                                new LunchDish()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Powidła ze słodkich ziemniaków z kardamonem",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Suszone daktyle",
                                                    Weight = 100
                                                }
                                            }
                                        },
                                        DishDescription = "Przykładowy opis",
                                        Size = 1,
                                        MethodOfPeparation = "Ziemniaki obieramy i kroimy w kostkę. Wkładamy do garnka z grubym dnem, dodajemy daktyle. Strączki kardamonu otwieramy nożykiem i wrzucamy je do garnka. Zalewamy wodą ponad poziom ziemniaków i zaczynamy podgrzewać na dużym ogniu.",
                                        PreparationTime = 180,
                                        Portions = 4
                                    }
                                }
                            }
                        },
                        Snack = new Snack()
                        {
                            Dishes = new List<SnackDish>()
                            {
                                new SnackDish()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Pieczone ziemniaki z dipem na bazie puszystego serka Almette z pomidorami",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Serek twarogowy Almette z pomidorami",
                                                    Weight = 80
                                                }
                                            }
                                        },
                                        DishDescription = "Przykładowy opis",
                                        Size = 1,
                                        MethodOfPeparation = "Ziemniaki myjemy i gotujemy w całości w osolonej wodzie przez 15 minut. Studzimy.",
                                        PreparationTime = 45,
                                        Portions = 4
                                    }
                                }
                            }
                        },
                        Dinner = new Dinner()
                        {
                            Dishes = new List<DinnerDish>()
                            {
                                new DinnerDish()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Kiszony ziemniak z rozmarynem",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Woda",
                                                    Weight = 1000
                                                }
                                            }
                                        },
                                        DishDescription = "Przykładowy opis",
                                        Size = 1,
                                        MethodOfPeparation = "Przygotowujemy zalewę. Na jeden litr zagotowanej wody, dorzucamy 20 gramów soli. Studzimy.",
                                        PreparationTime = 15,
                                        Portions = 4
                                    }
                                }
                            }
                        }
                    },
                    Wednesday = new Wednesday()
                    {
                        Breakfast = new Breakfast()
                        {
                            Dishes = new List<BreakfastDish>()
                            {
                                new BreakfastDish()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Szybki chłodnik na jogurcie naturalnym z ogórkiem małosolnym i rzodkiewką",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Jogurt naturalny",
                                                    Weight = 500
                                                }
                                            }
                                        },
                                        DishDescription = "Przykładowy opis",
                                        Size = 2,
                                        MethodOfPeparation = "Młode ziemniaki dokładnie myjemy i gotujemy w mundurkach w osolonej wodzie.",
                                        PreparationTime = 30,
                                        Portions = 1
                                    }
                                }
                            }
                        },
                        SecondBreakfast = new SecondBreakfast()
                        {
                            Dishes = new List<SecondBreakfastDish>()
                            {
                                new SecondBreakfastDish()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Polskie tradycyjne kotlety mielone z mizerią i młodymi ziemniakami",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Bułka",
                                                    Weight = 80
                                                }
                                            }
                                        },
                                        DishDescription = "Przykładowy opis",
                                        Size = 2,
                                        MethodOfPeparation = "Cebulę obieramy, kroimy w kostkę i podsmażamy na łyżce oleju. Bułkę namaczamy w mleku.",
                                        PreparationTime = 60,
                                        Portions = 1
                                    }
                                }
                            }
                        },
                        Lunch = new Lunch()
                        {
                            Dishes = new List<LunchDish>()
                            {
                                new LunchDish()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Soczyste szwedzkie klopsiki z purée ziemniaczanym i konfiturą borówkową",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Bulion warzywny",
                                                    Weight = 250
                                                }
                                            }
                                        },
                                        DishDescription = "Przykładowy opis",
                                        Size = 2,
                                        MethodOfPeparation = "Bułkę zalewamy mlekiem i odstawiamy na kilka minut, by się namoczyła. Cebulę obieramy i kroimy w drobną kostkę. Na patelnię wlewamy łyżkę oleju i przesmażamy na nim cebulę.",
                                        PreparationTime = 60,
                                        Portions = 1
                                    }
                                }
                            }
                        },
                        Snack = new Snack()
                        {
                            Dishes = new List<SnackDish>()
                            {
                                new SnackDish()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Zupa botwinka z wiśniami i opiekanymi ziemniakami",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Wiśnie mrożone",
                                                    Weight = 100
                                                }
                                            }
                                        },
                                        DishDescription = "Przykładowy opis",
                                        Size = 2,
                                        MethodOfPeparation = "Botwinę, marchewkę i pietruszkę myjemy, a następnie obieramy i kroimy w bardzo drobną kostkę. Łodygi i liście botwiny siekamy na wąskie paski. Cebulę obieramy i kroimy w kostkę.",
                                        PreparationTime = 45,
                                        Portions = 1
                                    }
                                }
                            }
                        },
                        Dinner = new Dinner()
                        {
                            Dishes = new List<DinnerDish>()
                            {
                                new DinnerDish()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Zupa krem z porów i ziemniaków",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Dwa ząbki czosnku",
                                                    Weight = 12
                                                }
                                            }
                                        },
                                        DishDescription = "Przykładowy opis",
                                        Size = 2,
                                        MethodOfPeparation = "Pory myjemy. Odcinamy z jednego zieloną część i odkładamy na bok. Pozostałe pory w całości kroimy na cienkie plasterki.",
                                        PreparationTime = 50,
                                        Portions = 1
                                    }
                                }
                            }
                        }
                    },
                    Thursday = new Thursday()
                    {
                        Breakfast = new Breakfast()
                        {
                            Dishes = new List<BreakfastDish>()
                            {
                                new BreakfastDish()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Sałatka z młodych ziemniaków i rzodkiewki",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Trzy łyżki majonezu",
                                                    Weight = 75
                                                }
                                            }
                                        },
                                        DishDescription = "Przykładowy opis",
                                        Size = 3,
                                        MethodOfPeparation = "Ziemniaki porządnie myjemy i wkładamy do niedużego garnka. Zalewamy zimną wodą, dodajemy sól i gotujemy do miękkości – około 25 minut.",
                                        PreparationTime = 40,
                                        Portions = 1
                                    }
                                }
                            }
                        },
                        SecondBreakfast = new SecondBreakfast()
                        {
                            Dishes = new List<SecondBreakfastDish>()
                            {
                                new SecondBreakfastDish()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Ziemniaki zapiekane z fasolą, jabłkiem i żurawiną",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Jabłko",
                                                    Weight = 175
                                                }
                                            }
                                        },
                                        DishDescription = "Przykładowy opis",
                                        Size = 3,
                                        MethodOfPeparation = "Fasolę zalewamy wodą i odstawiamy na noc. Rano odcedzamy, zalewamy świeżą wodą i gotujemy do miękkości z dodatkiem soli.",
                                        PreparationTime = 40,
                                        Portions = 1
                                    }
                                }
                            }
                        },
                        Lunch = new Lunch()
                        {
                            Dishes = new List<LunchDish>()
                            {
                                new LunchDish()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Gołąbki z bigosem, ziemniakami i sosem pieczeniowym",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Kiszona kapusta",
                                                    Weight = 500
                                                }
                                            }
                                        },
                                        DishDescription = "Przykładowy opis",
                                        Size = 3,
                                        MethodOfPeparation = "Śliwki i grzyby moczymy w gorącej wodzie, po czym kroimy w kostkę. Cebulę siekamy i smażymy na oliwie na niewielkim ogniu, aż zmięknie. Dodajemy pokrojoną kiełbasę, grzyby, śliwki, poszatkowaną kapustę kiszoną i włoską, liść laurowy, ziele angielskie, kminek. Smażymy chwilę, przykrywamy i dusimy około 45 minut. Usuwamy ziele angielskie i liść laurowy.",
                                        PreparationTime = 90,
                                        Portions = 1
                                    }
                                }
                            }
                        },
                        Snack = new Snack()
                        {
                            Dishes = new List<SnackDish>()
                            {
                                new SnackDish()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Frittata z ziemniakami, ze szpinakiem i z fetą",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Szpinak",
                                                    Weight = 100
                                                }
                                            }
                                        },
                                        DishDescription = "Przykładowy opis",
                                        Size = 3,
                                        MethodOfPeparation = "W misce roztrzepujemy jajka, doprawiamy je solą, pieprzem i wsypujemy łyżkę posiekanego szczypiorku. Szpinak myjemy i pozostawiamy do osuszenia.",
                                        PreparationTime = 25,
                                        Portions = 1
                                    }
                                }
                            }
                        },
                        Dinner = new Dinner()
                        {
                            Dishes = new List<DinnerDish>()
                            {
                                new DinnerDish()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Smażony dorsz z ziemniakami w emulsji maślano-musztardowej",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Kaszanka",
                                                    Weight = 300
                                                }
                                            }
                                        },
                                        DishDescription = "Przykładowy opis",
                                        Size = 3,
                                        MethodOfPeparation = "Kaszankę wyjmujemy z osłonki i smażymy na oliwie, dokładnie rozdrabniając, aż ściemnieje. Przekładamy do piekarnika rozgrzanego do 140 stopni i podsuszamy, aż będzie niemal sucha i chrupiąca. Odsączamy z tłuszczu.",
                                        PreparationTime = 60,
                                        Portions = 1
                                    }
                                }
                            }
                        }
                    },
                    Friday = new Friday()
                    {
                        Breakfast = new Breakfast()
                        {
                            Dishes = new List<BreakfastDish>()
                            {
                                new BreakfastDish()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Wędzony łosoś zapiekany pod purée ziemniaczanym",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Cheddar",
                                                    Weight = 60
                                                }
                                            }
                                        },
                                        DishDescription = "Przykładowy opis",
                                        Size = 1,
                                        MethodOfPeparation = "Ziemniaki obieramy, gotujemy w osolonej wodzie do miękkości. Jeszcze gorące przeciskamy przez praskę lub przecieramy przez sito. Dodajemy masło i śmietankę, dokładnie mieszamy. Kiedy nieco przestygnie, dodajemy żółtka i dokładnie mieszamy. Odstawiamy.",
                                        PreparationTime = 85,
                                        Portions = 1
                                    }
                                }
                            }
                        },
                        SecondBreakfast = new SecondBreakfast()
                        {
                            Dishes = new List<SecondBreakfastDish>()
                            {
                                new SecondBreakfastDish()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Placki z kaszki kukurydzianej z nadzieniem ziemniaczanym",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Mąka kukurydziana",
                                                    Weight = 50
                                                }
                                            }
                                        },
                                        DishDescription = "Przykładowy opis",
                                        Size = 1,
                                        MethodOfPeparation = "Wszystkie składniki mieszamy, wyrabiamy ciasto na placki i smażymy na teflonowej patelni. Placki mogą się trochę kleić, ale ich smak jest wyśmienity (dzieci nazywają go „popcornowym”).",
                                        PreparationTime = 75,
                                        Portions = 1
                                    }
                                }
                            }
                        },
                        Lunch = new Lunch()
                        {
                            Dishes = new List<LunchDish>()
                            {
                                new LunchDish()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Pieczone ziemniaki z sosem ziołowym",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Świeża kolendra",
                                                    Weight = 100
                                                }
                                            }
                                        },
                                        DishDescription = "Przykładowy opis",
                                        Size = 1,
                                        MethodOfPeparation = "Bulion lub wywar zagotować z dodatkiem pokrojonych na 2 - 3 części wędzonych żeberek lub kości lub pokrojonego na 4 części boczku.",
                                        PreparationTime = 30,
                                        Portions = 1
                                    }
                                }
                            }
                        },
                        Snack = new Snack()
                        {
                            Dishes = new List<SnackDish>()
                            {
                                new SnackDish()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Sałatka z pieczoną wołowiną, młodymi ziemniakami i fasolką",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Stek z rostbefu",
                                                    Weight = 1000
                                                }
                                            }
                                        },
                                        DishDescription = "Przykładowy opis",
                                        Size = 1,
                                        MethodOfPeparation = "Wołowinę myjemy i smarujemy musztardą z drobno posiekanym czosnkiem oraz odrobiną oliwy. Pozostawiamy na 2 godziny w temperaturze pokojowej. Po upływie tego czasu nagrzewamy piekarnik do 250 stopni. Wkładamy mięso i po 10 minutach wyłączamy. Nie otwieramy piekarnika i czekamy 2 godziny, aż dokładnie wystygnie. Dopiero wtedy wyciągamy mięso i kroimy w plastry.",
                                        PreparationTime = 45,
                                        Portions = 1
                                    }
                                }
                            }
                        },
                        Dinner = new Dinner()
                        {
                            Dishes = new List<DinnerDish>()
                            {
                                new DinnerDish()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Krokiety z ziemniaków",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Bułka tarta",
                                                    Weight = 200
                                                }
                                            }
                                        },
                                        DishDescription = "Przykładowy opis",
                                        Size = 1,
                                        MethodOfPeparation = "Ziemniaki myjemy i gotujemy. Jeszcze ciepłe dokładnie rozgniatamy. Gdy przestygną, doprawiamy solą i pieprzem. Dodajemy ser, 1 jajko i połowę posiekanego szczypiorku. Formujemy z ziemniaków kulki. Obtaczamy je w mące, pozostałych rozbełtanych jajkach i bułce tartej. Czynność powtarzamy dwa razy. Krokiety smażymy w oleju rozgrzanym do 170 stopni. Gdy zrobią się chrupiące i rumiane, wyjmujemy je z tłuszczu i odsączamy na ręczniku papierowym. Podajemy ze zsiadłym mlekiem, posypane resztą szczypiorku.",
                                        PreparationTime = 45,
                                        Portions = 1
                                    }
                                }
                            }
                        }
                    },
                    Saturday = new Saturday()
                    {
                        Breakfast = new Breakfast()
                        {
                            Dishes = new List<BreakfastDish>()
                            {
                                new BreakfastDish()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Sałatka z wędzonych ziemniaków i grillowanych warzyw",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Płatki chili",
                                                    Weight = 25
                                                }
                                            }
                                        },
                                        DishDescription = "Przykładowy opis",
                                        Size = 2,
                                        MethodOfPeparation = "Ziemniaki dokładnie myjemy i gotujemy w mundurkach w osolonej wodzie. Na rozgrzanym ruszcie kładziemy pory, rabarbar, przepołowioną cytrynę oraz podzielone na 8 części białe rzepy – wszystkie te składniki smarujemy uprzednio oliwą. Grillujemy, aż będą mocno przypieczone z wierzchu i miękkie w środku (około 8 minut). Do węgli dorzucamy garstkę szczapek drewna do wędzenia, układamy na ruszcie ziemniaki, przykrywamy i wędzimy około 20 minut.",
                                        PreparationTime = 35,
                                        Portions = 1
                                    }
                                }
                            }
                        },
                        SecondBreakfast = new SecondBreakfast()
                        {
                            Dishes = new List<SecondBreakfastDish>()
                            {
                                new SecondBreakfastDish()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Biała kiełbasa z sosem żurkowym, purée ziemniaczanym i botwiną",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Ocet winny czerwony",
                                                    Weight = 50
                                                }
                                            }
                                        },
                                        DishDescription = "Przykładowy opis",
                                        Size = 2,
                                        MethodOfPeparation = "Botwinę dokładnie myjemy. Jeden pęczek w całości ścieramy na tarce na sito – odciskamy sok do garnuszka. Drugi pęczek spinamy gumką i gotujemy w delikatnie posłodzonej wodzie, aż buraczki zmiękną. Wyjmujemy z wody i studzimy. Wstawiamy garnuszek z sokiem na mały gaz, dodajemy ocet i szczyptę cukru. Gdy sok się zredukuje, przelewamy do słoiczka i wkładamy do niego ugotowane bulwy z liśćmi, ale tak, żeby tylko buraczki były zanurzone w soku. Odstawiamy.",
                                        PreparationTime = 90,
                                        Portions = 1
                                    }
                                }
                            }
                        },
                        Lunch = new Lunch()
                        {
                            Dishes = new List<LunchDish>()
                            {
                                new LunchDish()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Silakkalaatikko – ziemniaczana zapiekanka śledziowa",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Filet ze śledzia",
                                                    Weight = 300
                                                }
                                            }
                                        },
                                        DishDescription = "Przykładowy opis",
                                        Size = 2,
                                        MethodOfPeparation = "Ziemniaki dokładnie myjemy i kroimy w bardzo cienkie plasterki.",
                                        PreparationTime = 40,
                                        Portions = 1
                                    }
                                }
                            }
                        },
                        Snack = new Snack()
                        {
                            Dishes = new List<SnackDish>()
                            {
                                new SnackDish()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Pieczone pierożki z porem, ziemniakami i serem",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Kminek",
                                                    Weight = 12
                                                }
                                            }
                                        },
                                        DishDescription = "Przykładowy opis",
                                        Size = 2,
                                        MethodOfPeparation = "Drożdże mieszamy z ciepłym mlekiem, cukrem, trzema łyżkami mąki i odstawiamy na pół godziny, aż zaczyn podwoi objętość.",
                                        PreparationTime = 180,
                                        Portions = 1
                                    }
                                }
                            }
                        },
                        Dinner = new Dinner()
                        {
                            Dishes = new List<DinnerDish>()
                            {
                                new DinnerDish()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Ziemniaczane gnocchi z sosem serowym",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Parmezan",
                                                    Weight = 40
                                                }
                                            }
                                        },
                                        DishDescription = "Przykładowy opis",
                                        Size = 2,
                                        MethodOfPeparation = "Ziemniaki nakłuwamy wykałaczką, nie obieramy. Pieczemy w piekarniku nagrzanym do 200°C, aż będą całkowicie miękkie – trwa to mniej więcej godzinę. Upieczone kroimy na połówki i pozwalamy im nieco odparować. Gdy nieco przestygną, wydłubujemy łyżką miąższ, przeciskamy go przez praskę i rozkładamy na blacie, by całkowicie ostygł.",
                                        PreparationTime = 60,
                                        Portions = 1
                                    }
                                }
                            }
                        }
                    },
                    Sunday = new Sunday()
                    {
                        Breakfast = new Breakfast()
                        {
                            Dishes = new List<BreakfastDish>()
                            {
                                new BreakfastDish()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Placki ziemniaczane z salsą paprykową",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Cztery papryki",
                                                    Weight = 800
                                                }
                                            }
                                        },
                                        DishDescription = "Przykładowy opis",
                                        Size = 3,
                                        MethodOfPeparation = "Ziemniaki obieramy i ścieramy na tarce o grubych oczkach. Starte kładziemy na sitku, posypujemy solą, mieszamy i pozostawiamy na mniej więcej 15 minut, by odsączyć nadmiar wody.",
                                        PreparationTime = 25,
                                        Portions = 2
                                    }
                                }
                            }
                        },
                        SecondBreakfast = new SecondBreakfast()
                        {
                            Dishes = new List<SecondBreakfastDish>()
                            {
                                new SecondBreakfastDish()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Raita ze zsiadłego mleka z pieczonymi ziemniakami",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Kumin",
                                                    Weight = 4
                                                }
                                            }
                                        },
                                        DishDescription = "Przykładowy opis",
                                        Size = 3,
                                        MethodOfPeparation = "Zsiadłe mleko delikatnie solimy. Dodajemy pozostałe przyprawy, pokrojone w kostkę: ogórek i rzodkiewki oraz kolendrę i szczypiorek. Wstawiamy do lodówki na kilka godzin, aby smaki raity się połączyły.",
                                        PreparationTime = 40,
                                        Portions = 2
                                    }
                                }
                            }
                        },
                        Lunch = new Lunch()
                        {
                            Dishes = new List<LunchDish>()
                            {
                                new LunchDish()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Soczewica z ziemniakami i kruszoną fetą",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Przecier pomidorowy",
                                                    Weight = 25
                                                }
                                            }
                                        },
                                        DishDescription = "Przykładowy opis",
                                        Size = 3,
                                        MethodOfPeparation = "Soczewicę dokładnie płuczemy. Cebulę i czerwoną paprykę drobno siekamy, ziemniaki kroimy w kostkę.",
                                        PreparationTime = 30,
                                        Portions = 2
                                    }
                                }
                            }
                        },
                        Snack = new Snack()
                        {
                            Dishes = new List<SnackDish>()
                            {
                                new SnackDish()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Krem z ziemniaków z oliwą truflową i bekonem",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Korzeń selera",
                                                    Weight = 525
                                                }
                                            }
                                        },
                                        DishDescription = "Przykładowy opis",
                                        Size = 3,
                                        MethodOfPeparation = "Oliwę podgrzewamy w garnku do zupy na średnim ogniu. Na tłuszcz wrzucamy poszatkowaną cebulę, marchewkę i selera. Mieszamy przez mniej więcej 2 minuty, po czym dorzucamy pokrojone w drobną kostkę ziemniaki. Dodajemy sól, pieprz czarny i pieprz cayenne. Smażymy przez kolejnych 5 minut.",
                                        PreparationTime = 30,
                                        Portions = 2
                                    }
                                }
                            }
                        },
                        Dinner = new Dinner()
                        {
                            Dishes = new List<DinnerDish>()
                            {
                                new DinnerDish()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Placki ziemniaczane",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Olej z pestek winogron",
                                                    Weight = 75
                                                }
                                            }
                                        },
                                        DishDescription = "Przykładowy opis",
                                        Size = 3,
                                        MethodOfPeparation = "Ziemniaki myjemy i obieramy. ¾ ścieramy na tarce o grubych oczkach, ¼ – o drobnych oczkach, solimy i odstawiamy na 10 minut.",
                                        PreparationTime = 30,
                                        Portions = 2
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
