using Papu.Entities;
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
            //Sprawdzamy połączenie do bazy danych zostało nawiązane
            if (_dbContext.Database.CanConnect())
            {

                //Sprawdzamy czy tabela z produktami jest pusta
                if (!_dbContext.Products.Any())
                {
                    var products = GetProducts();
                    _dbContext.Products.AddRange(products);
                    _dbContext.SaveChanges();
                }

                //Sprawdzamy czy tabela z potrawami jest pusta
                if (!_dbContext.Dishes.Any())
                {
                    var dishes = GetDishes();
                    _dbContext.Dishes.AddRange(dishes);
                    _dbContext.SaveChanges();
                }

                //Sprawdzamy czy tabela z rodzajami potraw jest pusta
                if (!_dbContext.KindsOf.Any())
                {
                    var kindsOf = GetKindsOf();
                    _dbContext.KindsOf.AddRange(kindsOf);
                    _dbContext.SaveChanges();
                }

                //Sprawdzamy czy tabela z typami potraw jest pusta
                if (!_dbContext.Types.Any())
                {
                    var types = GetTypes();
                    _dbContext.Types.AddRange(types);
                    _dbContext.SaveChanges();
                }

                //Sprawdzamy czy tabela z kategoriami produktów jest pusta
                if (!_dbContext.Categories.Any())
                {
                    var categories = GetCategories();
                    _dbContext.Categories.AddRange(categories);
                    _dbContext.SaveChanges();
                }

                //Sprawdzamy czy tabela z jednostkami miar produktów jest pusta
                if (!_dbContext.Units.Any())
                {
                    var units = GetUnits();
                    _dbContext.Units.AddRange(units);
                    _dbContext.SaveChanges();
                }

                //Sprawdzamy czy tabela z grupami produktów jest pusta
                if (!_dbContext.Groups.Any())
                {
                    var groups = GetGroups();
                    _dbContext.Groups.AddRange(groups);
                    _dbContext.SaveChanges();
                }

                //Sprawdzamy czy tabela z poniedziałkami jest pusta
                if (!_dbContext.Mondays.Any())
                {
                    var mondays = GetMondays();
                    _dbContext.Mondays.AddRange(mondays);
                    _dbContext.SaveChanges();
                }

                //Sprawdzamy czy tabela z soboty jest pusta
                if (!_dbContext.Saturdays.Any())
                {
                    var saturdays = GetSaturdays();
                    _dbContext.Saturdays.AddRange(saturdays);
                    _dbContext.SaveChanges();
                }

                //Sprawdzamy czy tabela z piątkami jest pusta
                if (!_dbContext.Fridays.Any())
                {
                    var fridays = GetFridays();
                    _dbContext.Fridays.AddRange(fridays);
                    _dbContext.SaveChanges();
                }

                //Sprawdzamy czy tabela z wtorkami jest pusta
                if (!_dbContext.Tuesdays.Any())
                {
                    var tuesdays = GetTuesdays();
                    _dbContext.Tuesdays.AddRange(tuesdays);
                    _dbContext.SaveChanges();
                }

                //Sprawdzamy czy tabela z środami jest pusta
                if (!_dbContext.Wednesdays.Any())
                {
                    var wednesdays = GetWednesdays();
                    _dbContext.Wednesdays.AddRange(wednesdays);
                    _dbContext.SaveChanges();
                }

                //Sprawdzamy czy tabela z czwartkami jest pusta
                if (!_dbContext.Thursdays.Any())
                {
                    var thursdays = GetThursdays();
                    _dbContext.Thursdays.AddRange(thursdays);
                    _dbContext.SaveChanges();
                }

                //Sprawdzamy czy tabela z niedzielami jest pusta
                if (!_dbContext.Sundays.Any())
                {
                    var sundays = GetSundays();
                    _dbContext.Sundays.AddRange(sundays);
                    _dbContext.SaveChanges();
                }

                //Sprawdzamy czy tabela z jadłospisami jest pusta
                if (!_dbContext.Menus.Any())
                {
                    var menus = GetMenus();
                    _dbContext.Menus.AddRange(menus);
                    _dbContext.SaveChanges();
                }
            }
        }

        //Metoda zwracająca kolekcję grup produktów, które będą zawsze istnieć w tabeli group
        //baza automatycznie przydzieli id
        private IEnumerable<Group> GetGroups()
        {
            var groups = new List<Group>()
            {
                new Group()
                {
                    GroupName = "Algi"
                },
                new Group()
                {
                    GroupName = "Drożdże"
                },
                new Group()
                {
                    GroupName = "Grzyby"
                },
                new Group()
                {
                    GroupName = "Inne"
                },
                new Group()
                {
                    GroupName = "Jaja"
                },
                new Group()
                {
                    GroupName = "Kawa herbata"
                },
                new Group()
                {
                    GroupName = "Konserwanty"
                },
                new Group()
                {
                    GroupName = "Mięso"
                },
                new Group()
                {
                    GroupName = "Nasiona i orzechy"
                },
                new Group()
                {
                    GroupName = "Owoce"
                },
                new Group()
                {
                    GroupName = "Owoce morza"
                },
                new Group()
                {
                    GroupName = "Pozostałe"
                },
                new Group()
                {
                    GroupName = "Produkty mleczne"
                },
                new Group()
                {
                    GroupName = "Produkty słodzące"
                },
                new Group()
                {
                    GroupName = "Przyprawy i zioła"
                },
                new Group()
                {
                    GroupName = "Ryby"
                },
                new Group()
                {
                    GroupName = "Sałaty"
                },
                new Group()
                {
                    GroupName = "Warzywa"
                },
                new Group()
                {
                    GroupName = "Warzywa strączkowe"
                },
                new Group()
                {
                    GroupName = "Zagęstniki"
                },
                new Group()
                {
                    GroupName = "Zamienniki zbóż"
                },
                new Group()
                {
                    GroupName = "Zboża niezawierające glutenu"
                },
                new Group()
                {
                    GroupName = "Zboża zawierające gluten"
                }
            };

            return groups;
        }

        //Metoda zwracająca kolekcję jednostek miary produktów, które będą zawsze istnieć w tabeli unit
        //baza automatycznie przydzieli id
        private IEnumerable<Unit> GetUnits()
        {
            var units = new List<Unit>()
            {
                new Unit()
                {
                    UnitName = "Garść"
                },
                new Unit()
                {
                    UnitName = "Łyżka"
                },
                new Unit()
                {
                    UnitName = "Sztuka"
                },
                new Unit()
                {
                    UnitName = "Litr"
                },
                new Unit()
                {
                    UnitName = "Plaster"
                },
                new Unit()
                {
                    UnitName = "Porcja"
                },
                new Unit()
                {
                    UnitName = "Plasterek"
                },
                new Unit()
                {
                    UnitName = "Opakowanie"
                },
                new Unit()
                {
                    UnitName = "Łyżeczka"
                },
                new Unit()
                {
                    UnitName = "Listek"
                },
                new Unit()
                {
                    UnitName = "Kromka"
                },
                new Unit()
                {
                    UnitName = "Szklanka"
                },
                new Unit()
                {
                    UnitName = "Kostka"
                },
                new Unit()
                {
                    UnitName = "Ząbek"
                },
                new Unit()
                {
                    UnitName = "Liść"
                },
                new Unit()
                {
                    UnitName = "Łodyga"
                },
                new Unit()
                {
                    UnitName = "Kieliszek"
                },
                new Unit()
                {
                    UnitName = "Kropla"
                },
                new Unit()
                {
                    UnitName = "Szczypta"
                },
                new Unit()
                {
                    UnitName = "Płat"
                },
                new Unit()
                {
                    UnitName = "Rurka"
                },
                new Unit()
                {
                    UnitName = "Kapsułka"
                },
                new Unit()
                {
                    UnitName = "Miarka"
                },
                new Unit()
                {
                    UnitName = "Pęczek"
                },
                new Unit()
                {
                    UnitName = "Gałka"
                },
                new Unit()
                {
                    UnitName = "Kawałek"
                },
            };

            return units;
        }

        //Metoda zwracająca kolekcję kategorii produktów, które będą zawsze istnieć w tabeli category
        //baza automatycznie przydzieli id
        private IEnumerable<Category> GetCategories()
        {
            var categories = new List<Category>()
            {
                new Category()
                {
                    CategoryName = "Nabiał"
                },
                new Category()
                {
                    CategoryName = "Mięso i wyroby mięsne"
                },
                new Category()
                {
                    CategoryName = "Ryby i owoce morza"
                },
                new Category()
                {
                    CategoryName = "Pieczywo"
                },
                new Category()
                {
                    CategoryName = "Zbożowe"
                },
                new Category()
                {
                    CategoryName = "Orzechy i ziarna"
                },
                new Category()
                {
                    CategoryName = "Napoje"
                },
                new Category()
                {
                    CategoryName = "Tłuszcze"
                },
                new Category()
                {
                    CategoryName = "Inne"
                },
                new Category()
                {
                    CategoryName = "Owoce i Warzywa"
                },
                new Category()
                {
                    CategoryName = "Przyprawy i zioła"
                }
            };

            return categories;
        }

        //Metoda zwracająca kolekcję typów potraw, które będą zawsze istnieć w tabeli type
        //baza automatycznie przydzieli id
        private IEnumerable<Type> GetTypes()
        {
            var types = new List<Type>()
            {
                new Type()
                {
                    TypeName = "Śniadanie"
                },
                new Type()
                {
                    TypeName = "Drugie śniadanie"
                },
                new Type()
                {
                    TypeName = "Obiad"
                },
                new Type()
                {
                    TypeName = "Podwieczorek"
                },
                new Type()
                {
                    TypeName = "Kolacja"
                },
                new Type()
                {
                    TypeName = "Przekąska"
                }
            };

            return types;
        }

        //Metoda zwracająca kolekcję rodzajów potraw, które będą zawsze istnieć w tabeli kindOf
        //baza automatycznie przydzieli id
        private IEnumerable<KindOf> GetKindsOf()
        {
            var kindsOf = new List<KindOf>()
            {
                new KindOf()
                {
                    KindOfName = "Paleo"
                },
                new KindOf()
                {
                    KindOfName = "Potreningowy"
                },
                new KindOf()
                {
                    KindOfName = "Szybki"
                },
                new KindOf()
                {
                    KindOfName = "Fit"
                },
                new KindOf()
                {
                    KindOfName = "Z niskim IG"
                }
            };

            return kindsOf;
        }

        //Metoda zwracająca kolekcję produktów, które będą zawsze istnieć w tabeli product
        //baza automatycznie przydzieli id
        private IEnumerable<Product> GetProducts()
        {
            var products = new List<Product>()
            {
                new Product()
                {
                    ProductName = "Pomidor",
                    /*Category = new Category()
                    {
                        CategoryName = "Owoce i Warzywa"
                    },
                    Groups = new List<Group>()
                    {
                        new Group()
                        {
                            GroupName = "Algi"
                        }
                    },
                    Unit = new Unit()
                    {
                        UnitName = "Sztuka"
                    },*/
                    Weight = 100
                },
                new Product()
                {
                    ProductName = "Cytryna",
                    /*Category = new Category()
                    {
                        CategoryName = "Owoce i Warzywa"
                    },
                    Groups = new List<Group>()
                    {
                        new Group()
                        {
                            GroupName = "Drożdże"
                        }
                    },
                    Unit = new Unit()
                    {
                        UnitName = "Sztuka"
                    },*/
                    Weight = 200
                }
            };

            return products;
        }

        //Metoda zwracająca kolekcję potraw, które będą zawsze istnieć w tabeli product
        //baza automatycznie przydzieli id
        private IEnumerable<Dish> GetDishes()
        {
            var dishes = new List<Dish>()
            {
                new Dish()
                {
                    DishName = "Pomidorowa",
                    Products = new List<Product>()
                    {
                        new Product()
                        {
                            ProductName = "Cytryna",
                            /*Category = new Category()
                            {
                                CategoryName = "Owoce i Warzywa"
                            },
                            Groups = new List<Group>()
                            {
                                new Group()
                                {
                                    GroupName = "Algi"
                                }
                            },
                            Unit = new Unit()
                            {
                                UnitName = "Sztuka"
                            },*/
                            Weight = 200
                        }
                    },
                    /*KindsOf = new List<KindOf>()
                    {
                        new KindOf()
                        {
                            KindOfName = "Rodzaj1"
                        }
                    },
                    Types = new List<Type>()
                    {
                        new Type()
                        {
                            TypeName = "Typ1"
                        }
                    },*/
                    DishDescription = "Przykładowy opis",
                    Size = 1,
                    MethodOfPeparation = "Mięso opłukać pod bieżącą " +
                    "chłodną wodą, włożyć do garnka, dodać szczyptę soli, " +
                    "zalać zimną wodą i moczyć przez około 15 minut. " +
                    "Następnie wylać wodę z moczenia kurczaka, dodać czystą " +
                    "zimną wodę (2 litry), posolić i zagotować na większym ogniu.",
                    PreparationTime = 1,
                    Portions = 2
                },
                new Dish()
                {
                    DishName = "Pomidorowa",
                    Products = new List<Product>()
                    {
                        new Product()
                        {
                            ProductName = "Cytryna",
                            /*Category = new Category()
                            {
                                CategoryName = "Owoce i Warzywa"
                            },
                            Groups = new List<Group>()
                            {
                                new Group()
                                {
                                    GroupName = "Algi"
                                }
                            },
                            Unit = new Unit()
                            {
                                UnitName = "Sztuka"
                            },*/
                            Weight = 200
                        }
                    },
                    /*KindsOf = new List<KindOf>()
                    {
                        new KindOf()
                        {
                            KindOfName = "Rodzaj2"
                        }
                    },
                    Types = new List<Type>()
                    {
                        new Type()
                        {
                            TypeName = "Typ2"
                        }
                    },*/
                    DishDescription = "Przykładowy opis",
                    Size = 2,
                    MethodOfPeparation = "Mięso opłukać pod bieżącą " +
                    "chłodną wodą, włożyć do garnka, dodać szczyptę soli, " +
                    "zalać zimną wodą i moczyć przez około 15 minut. " +
                    "Następnie wylać wodę z moczenia kurczaka, dodać czystą " +
                    "zimną wodę (2 litry), posolić i zagotować na większym ogniu.",
                    PreparationTime = 1,
                    Portions = 1
                }
            };

            return dishes;
        }

        //Metoda zwracająca kolekcję poniedziałków, które będą zawsze istnieć w tabeli product
        //baza automatycznie przydzieli id
        private IEnumerable<Monday> GetMondays()
        {
            var mondays = new List<Monday>()
            {
                new Monday()
                {
                    MondayDishes = new List<Dish>()
                    {
                        new Dish()
                        {
                        DishName = "Buraczki",
                        Products = new List<Product>()
                        {
                            new Product()
                            {
                                ProductName = "Cytryna",
                                /*Category = new Category()
                            {
                                CategoryName = "Owoce i Warzywa"
                            },
                            Groups = new List<Group>()
                            {
                                new Group()
                                {
                                    GroupName = "Algi"
                                }
                            },
                            Unit = new Unit()
                            {
                                UnitName = "Sztuka"
                            },*/
                            Weight = 400
                            }
                        },
                        DishDescription = "Przykładowy opis",
                        Size = 3,
                        MethodOfPeparation = "Cebule obieram, szatkuję w drobniutką " +
                        "kostkę i podsmażam na oleju. Buraki studzę, ścieram na " +
                        "tarce o grubych oczkach, właściwie grubość tarcia można " +
                        "dostawać do swoich preferencji. Dodaję przyprawy, sok " +
                        "wyciśnięty z cytryny, syrop daktylowy lub ryżowy, sól oraz " +
                        "pieprz. Mieszam bardzo dokładnie i podgrzewam ponownie.",
                        PreparationTime = 1,
                        Portions = 3
                        }
                    }
                }
            };

            return mondays;
        }

        //Metoda zwracająca kolekcję sobót, które będą zawsze istnieć w tabeli product
        //baza automatycznie przydzieli id
        private IEnumerable<Saturday> GetSaturdays()
        {
            var saturdays = new List<Saturday>()
            {
                new Saturday()
                {
                    SaturdayDishes = new List<Dish>()
                    {
                        new Dish()
                        {
                        DishName = "Jajko na twardo",
                        Products = new List<Product>()
                        {
                            new Product()
                            {
                                ProductName = "Jajko",
                                /*Category = new Category()
                            {
                                CategoryName = "Owoce i Warzywa"
                            },
                            Groups = new List<Group>()
                            {
                                new Group()
                                {
                                    GroupName = "Algi"
                                }
                            },
                            Unit = new Unit()
                            {
                                UnitName = "Sztuka"
                            },*/
                            Weight = 120
                            }
                        },
                        DishDescription = "Przykładowy opis",
                        Size = 1,
                        MethodOfPeparation = "Nalej do garnka wodę i włóż " +
                        "do niej jajka. Czekaj aż woda się zagotuje. " +
                        "Od momentu zagotowania się wody, gotuj jajka dokładnie " +
                        "8 minut. Po upływie tego czasu wylej wodę z garnka.",
                        PreparationTime = 1,
                        Portions = 4
                        }
                    }
                }
            };

            return saturdays;
        }

        //Metoda zwracająca kolekcję piątków, które będą zawsze istnieć w tabeli product
        //baza automatycznie przydzieli id
        private IEnumerable<Friday> GetFridays()
        {
            var fridays = new List<Friday>()
            {
                new Friday()
                {
                    FridayDishes = new List<Dish>()
                    {
                        new Dish()
                        {
                        DishName = "Grzanki",
                        Products = new List<Product>()
                        {
                            new Product()
                            {
                                ProductName = "Chleb",
                                /*Category = new Category()
                            {
                                CategoryName = "Owoce i Warzywa"
                            },
                            Groups = new List<Group>()
                            {
                                new Group()
                                {
                                    GroupName = "Algi"
                                }
                            },
                            Unit = new Unit()
                            {
                                UnitName = "Sztuka"
                            },*/
                            Weight = 500
                            }
                        },
                        DishDescription = "Przykładowy opis",
                        Size = 2,
                        MethodOfPeparation = "Chleb pokroić na kromki. Każdą " +
                        "kromkę posmarować ok. 1 łyżeczką masła czosnkowo-ziołowego. " +
                        "Ułożyć na blasze wyłożonej papierem do pieczenia i piec " +
                        "przez 5 minut w piekarniku nagrzanym do 200 stopni C.",
                        PreparationTime = 2,
                        Portions = 1
                        }
                    }
                }
            };

            return fridays;
        }

        //Metoda zwracająca kolekcję wtorków, które będą zawsze istnieć w tabeli product
        //baza automatycznie przydzieli id
        private IEnumerable<Tuesday> GetTuesdays()
        {
            var tuesdays = new List<Tuesday>()
            {
                new Tuesday()
                {
                    TuesdayDishes = new List<Dish>()
                    {
                        new Dish()
                        {
                        DishName = "Tosty",
                        Products = new List<Product>()
                        {
                            new Product()
                            {
                                ProductName = "Chleb tostowy",
                                /*Category = new Category()
                            {
                                CategoryName = "Owoce i Warzywa"
                            },
                            Groups = new List<Group>()
                            {
                                new Group()
                                {
                                    GroupName = "Algi"
                                }
                            },
                            Unit = new Unit()
                            {
                                UnitName = "Sztuka"
                            },*/
                            Weight = 350
                            }
                        },
                        DishDescription = "Przykładowy opis",
                        Size = 3,
                        MethodOfPeparation = "Chleb posmaruj masłem, na 2 " +
                        "kromkach połóż ser, szynkę, ogórka, pomidora, przykryj " +
                        "pozostałymi kromkami. Kanapki włóż do opiekacza na kilka " +
                        "minut, aż chleb się zarumieni. Gotowe tosty przekrój na " +
                        "trójkąty, podawaj z kiełkami rzeżuchy i domowym ketchupem.",
                        PreparationTime = 3,
                        Portions = 1
                        }
                    }
                }
            };

            return tuesdays;
        }

        //Metoda zwracająca kolekcję śród, które będą zawsze istnieć w tabeli product
        //baza automatycznie przydzieli id
        private IEnumerable<Wednesday> GetWednesdays()
        {
            var wednesdays = new List<Wednesday>()
            {
                new Wednesday()
                {
                    WednesdayDishes = new List<Dish>()
                    {
                        new Dish()
                        {
                        DishName = "Żurek",
                        Products = new List<Product>()
                        {
                            new Product()
                            {
                                ProductName = "Kiełbasa",
                                /*Category = new Category()
                            {
                                CategoryName = "Owoce i Warzywa"
                            },
                            Groups = new List<Group>()
                            {
                                new Group()
                                {
                                    GroupName = "Algi"
                                }
                            },
                            Unit = new Unit()
                            {
                                UnitName = "Sztuka"
                            },*/
                            Weight = 240
                            }
                        },
                        DishDescription = "Przykładowy opis",
                        Size = 1,
                        MethodOfPeparation = "Bulion lub wywar zagotować z " +
                        "dodatkiem pokrojonych na 2 - 3 części wędzonych żeberek " +
                        "lub kości lub pokrojonego na 4 części boczku.",
                        PreparationTime = 4,
                        Portions = 1
                        }
                    }
                }
            };

            return wednesdays;
        }

        //Metoda zwracająca kolekcję czwartków, które będą zawsze istnieć w tabeli product
        //baza automatycznie przydzieli id
        private IEnumerable<Thursday> GetThursdays()
        {
            var thursdays = new List<Thursday>()
            {
                new Thursday()
                {
                    ThursdayDishes = new List<Dish>()
                    {
                        new Dish()
                        {
                        DishName = "Zupa z dyni",
                        Products = new List<Product>()
                        {
                            new Product()
                            {
                                ProductName = "Dynia",
                                /*Category = new Category()
                            {
                                CategoryName = "Owoce i Warzywa"
                            },
                            Groups = new List<Group>()
                            {
                                new Group()
                                {
                                    GroupName = "Algi"
                                }
                            },
                            Unit = new Unit()
                            {
                                UnitName = "Sztuka"
                            },*/
                            Weight = 1000
                            }
                        },
                        DishDescription = "Przykładowy opis",
                        Size = 2,
                        MethodOfPeparation = "Dynię umyć, przekroić na pół, " +
                        "oczyścić z pestek i włókien. Następnie pokroić w kostkę " +
                        "razem ze skórką. Ziemniaki i marchewki umyć, obrać i " +
                        "pokroić w kostkę. Cebulę obrać i pokroić w kostkę.",
                        PreparationTime = 5,
                        Portions = 1
                        }
                    }
                }
            };

            return thursdays;
        }

        //Metoda zwracająca kolekcję niedziel, które będą zawsze istnieć w tabeli product
        //baza automatycznie przydzieli id
        private IEnumerable<Sunday> GetSundays()
        {
            var sundays = new List<Sunday>()
            {
                new Sunday()
                {
                    SundayDishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            DishName = "Kurczak",
                            Products = new List<Product>()
                            {
                                new Product()
                                {
                                    ProductName = "Kura",
                                    /*Category = new Category()
                                    {
                                        CategoryName = "Owoce i Warzywa"
                                    },
                                    Groups = new List<Group>()
                                    {
                                        new Group()
                                        {
                                            GroupName = "Algi"
                                        }
                                    },
                                    Unit = new Unit()
                                    {
                                        UnitName = "Sztuka"
                                    },*/
                                    Weight = 2000
                                }
                            },
                            DishDescription = "Przykładowy opis",
                            Size = 3,
                            MethodOfPeparation = "Wyciśnij sok z pomarańczy. " +
                                "Na patelni na rozgrzanej oliwie podsmaż pokrojoną " +
                                "w półplasterki cebulę. Gdy się zeszkli, dodaj łyżkę " +
                                "cukru, smaż aż cukier zacznie się karmelizować. " +
                                "Następnie dodaj sok z pomarańczy. Gotuj aż sok " +
                                "zupełnie odparuje. Cebulę przełóż do miski i odstaw " +
                                "na chwilę, aby wystygła.",
                            PreparationTime = 3,
                            Portions = 2
                        }
                    }
                }
            };

            return sundays;
        }

        //Metoda zwracająca kolekcję jadłospisów, które będą zawsze istnieć w tabeli product
        //baza automatycznie przydzieli id
        private IEnumerable<Menu> GetMenus()
        {
            var menus = new List<Menu>()
            {
                new Menu()
                {
                    MenuName = "Treningowy",
                    MenuDescription = "Jadłospis na rzeźbę",
                    Monday = new Monday()
                    {
                        MondayDishes = new List<Dish>()
                        {
                            new Dish()
                            {
                                DishName = "Kurczak",
                                Products = new List<Product>()
                                {
                                    new Product()
                                    {
                                        ProductName = "Kura",
                                        /*Category = new Category()
                                        {
                                        CategoryName = "Owoce i Warzywa"
                                        },
                                        Groups = new List<Group>()
                                        {
                                            new Group()
                                            {
                                                GroupName = "Algi"
                                            }
                                        },
                                        Unit = new Unit()
                                        {
                                            UnitName = "Sztuka"
                                        },*/
                                        Weight = 2000
                                    }
                                },
                                DishDescription = "Przykładowy opis",
                                Size = 1,
                                MethodOfPeparation = "Wyciśnij sok z pomarańczy. " +
                                "Na patelni na rozgrzanej oliwie podsmaż pokrojoną " +
                                "w półplasterki cebulę. Gdy się zeszkli, dodaj łyżkę " +
                                "cukru, smaż aż cukier zacznie się karmelizować. " +
                                "Następnie dodaj sok z pomarańczy. Gotuj aż sok " +
                                "zupełnie odparuje. Cebulę przełóż do miski i odstaw " +
                                "na chwilę, aby wystygła.",
                                PreparationTime = 3,
                                Portions = 3
                            }
                        }
                    },
                    Friday = new Friday()
                    {
                        FridayDishes = new List<Dish>()
                        {
                            new Dish()
                            {
                                DishName = "Pyzy",
                                Products = new List<Product>()
                                {
                                    new Product()
                                    {
                                        ProductName = "Ziemniaki",
                                        /*Category = new Category()
                                        {
                                            CategoryName = "Owoce i Warzywa"
                                        },
                                        Groups = new List<Group>()
                                        {
                                            new Group()
                                            {
                                                GroupName = "Algi"
                                            }
                                        },
                                        Unit = new Unit()
                                        {
                                            UnitName = "Sztuka"
                                        },*/
                                        Weight = 5000
                                    }
                                },
                                DishDescription = "Przykładowy opis",
                                Size = 2,
                                MethodOfPeparation = "Połowę ziemniaków ugotować w " +
                                "osolonej wodzie do miękkości, odcedzić i rozgnieść " +
                                "tłuczkiem lub praską, odparować i ostudzić. Drugą " +
                                "połowę ziemniaków zetrzeć na tarce o jak " +
                                "najdrobniejszych oczkach. Odcisnąć i dodać do " +
                                "ziemniaków ugotowanych. Dodać mąkę ziemniaczaną, " +
                                "wbić jajko i doprawić delikatnie solą.",
                                PreparationTime = 4,
                                Portions = 5
                            }
                        }
                    }
                }
            };

            return menus;
        }
    }
}
