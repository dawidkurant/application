using Microsoft.EntityFrameworkCore;
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
            SeedTable<Type>(() => Types);
            SeedTable<Category>(() => Categories);
            SeedTable<Unit>(() => Units);
            SeedTable<Group>(() => Groups);
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

        private void SeedTable<TEntity>(System.Func<IEnumerable<TEntity>> dataFunc) where TEntity : class
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
        private static List<Role> Roles = new()
        {
            new() { Name = "User" },
            new() { Name = "Manager" },
            new() { Name = "Admin" }
        };

        /// <summary>
        /// Metoda zwracająca kolekcję grup produktów, które będą zawsze istnieć w tabeli group
        /// baza automatycznie przydzieli id
        /// </summary>
        private static List<Group> Groups = new()
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
        private static List<Unit> Units = new()
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
        private static List<Category> Categories = new()
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
        private static List<Type> Types = new()
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
        private static List<KindOf> KindsOf = new()
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
        private static List<Product> Products = new()
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
        /// Metoda zwracająca jadłospis, który będzie zawsze istnieć w tabeli menu,
        /// zwraca kolekcję dni, które będą zawsze istnieć w tabeli dayMenu,
        /// zwraca kolekcję pór dnia, które będą zawsze istnieć w tabeli meal,
        /// 
        /// baza automatycznie przydzieli id
        /// </summary>
        private static IEnumerable<Menu> GetMenus()
        {
            return new List<Menu>()
            {
                new Menu()
                {
                    Days = new List<DayMenu>()
                    {
                        new DayMenu()
                {
                    DayOfWeek = Entities.DayOfWeek.Monday,
                    Meals = new List<Meal>()
                    {
                        new Meal()
                        {
                            MealType = MealType.Snack,
                            DishMeals = new List<DishMeal>()
                            {
                                new DishMeal()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Kaczka pieczona z sosem żurawinowym",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Kaczka",
                                                    Weight = 1500
                                                }
                                            },
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Żurawina",
                                                    Weight = 200
                                                }
                                            }
                                        },
                                        DishDescription = "Delikatna i soczysta kaczka podana z aromatycznym sosem żurawinowym. Doskonała propozycja na świąteczny obiad dla całej rodziny.",
                                        Size = 4,
                                        MethodOfPeparation = "Kaczkę myjemy i dokładnie osuszamy. Nacieramy ją solą i pieprzem, następnie wkładamy do rozgrzanego piekarnika nagrzanego do 180 stopni. Pieczemy przez około 2 godziny. W międzyczasie gotujemy żurawinę, dodając odrobinę wody i cukru. Gdy kaczka będzie gotowa, podajemy ją z sosem żurawinowym i ulubionymi dodatkami.",
                                        PreparationTime = 120,
                                        Portions = 6
                                    }
                                }
                            }
                        }
                    }
                },
                new DayMenu()
                {
                    DayOfWeek = Entities.DayOfWeek.Tuesday,
                    Meals = new List<Meal>()
                    {
                        new Meal()
                        {
                            MealType = MealType.Breakfast,
                            DishMeals = new List<DishMeal>()
                            {
                                new DishMeal()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Krewetki curry z ryżem basmati",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Krewetki",
                                                    Weight = 300
                                                }
                                            },
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Ryż basmati",
                                                    Weight = 250
                                                }
                                            },
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Mleko kokosowe",
                                                    Weight = 200
                                                }
                                            }
                                        },
                                        DishDescription = "Aromatyczne krewetki w sosie curry podane z lekkim ryżem basmati. Idealne danie dla miłośników kuchni azjatyckiej.",
                                        Size = 3,
                                        MethodOfPeparation = "Krewetki podsmażamy na patelni, dodajemy mleko kokosowe i curry, gotujemy przez kilka minut. Ryż gotujemy oddzielnie. Podajemy krewetki z sosem curry i ryżem basmati.",
                                        PreparationTime = 25,
                                        Portions = 2
                                    }
                                }
                            }
                        }
                    }
                },
                new DayMenu()
                {
                    DayOfWeek = Entities.DayOfWeek.Wednesday,
                    Meals = new List<Meal>()
                    {
                        new Meal()
                        {
                            MealType = MealType.SecondBreakfast,
                            DishMeals = new List<DishMeal>()
                            {
                                new DishMeal()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Schabowy z ziemniakami",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Schab",
                                                    Weight = 400
                                                }
                                            },
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Ziemniaki",
                                                    Weight = 300
                                                }
                                            },
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Marchew",
                                                    Weight = 150
                                                }
                                            },
                                        },
                                        DishDescription = "Tradycyjny polski schabowy podany z ziemniakami i surówką z marchewki.",
                                        Size = 4,
                                        MethodOfPeparation = "Schab panierujemy, smażymy na patelni. Ziemniaki gotujemy lub smażymy. Marchew ścieramy na tarce, dodajemy trochę octu i oleju.",
                                        PreparationTime = 40,
                                        Portions = 4
                                    }
                                }
                            }
                        }
                    }
                },
                new DayMenu()
                {
                    DayOfWeek = Entities.DayOfWeek.Thursday,
                    Meals = new List<Meal>()
                    {
                        new Meal()
                        {
                            MealType = MealType.Lunch,
                            DishMeals = new List<DishMeal>()
                            {
                                new DishMeal()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Lasagne bolognese",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Makaron do lasagne",
                                                    Weight = 250
                                                }
                                            },
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Mięso mielone",
                                                    Weight = 500
                                                }
                                            },
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Pomidory krojone",
                                                    Weight = 400
                                                }
                                            },
                                        },
                                        DishDescription = "Pyszna warstwowa lasagne z sosem bolognese, zapiekana z serem.",
                                        Size = 6,
                                        MethodOfPeparation = "Mięso podsmażamy, dodajemy pomidory, gotujemy sos bolognese. Warstwujemy makaron z sosem i serem. Pieczemy w piekarniku.",
                                        PreparationTime = 60,
                                        Portions = 6
                                    }
                                }
                            }
                        }
                    }
                },
                new DayMenu()
                {
                    DayOfWeek = Entities.DayOfWeek.Friday,
                    Meals = new List<Meal>()
                    {
                        new Meal()
                        {
                            MealType = MealType.Dinner,
                            DishMeals = new List<DishMeal>()
                            {
                                new DishMeal()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Sushi mix",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Ryż sushi",
                                                    Weight = 300
                                                }
                                            },
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Łosoś",
                                                    Weight = 200
                                                }
                                            },
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Awokado",
                                                    Weight = 150
                                                }
                                            },
                                        },
                                        DishDescription = "Wyśmienite sushi z ryżem, łososiem i awokado.",
                                        Size = 2,
                                        MethodOfPeparation = "Ryż gotujemy, rozkładamy na nori, układamy łososia i awokado. Zwijamy i kroimy na kawałki.",
                                        PreparationTime = 50,
                                        Portions = 2
                                    }
                                }
                            }
                        }
                    }
                },
                new DayMenu()
                {
                    DayOfWeek = Entities.DayOfWeek.Saturday,
                    Meals = new List<Meal>()
                    {
                        new Meal()
                        {
                            MealType = MealType.Breakfast,
                            DishMeals = new List<DishMeal>()
                            {
                                new DishMeal()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Kotlety z soczewicy",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Soczewica",
                                                    Weight = 300
                                                }
                                            },
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Kasza jaglana",
                                                    Weight = 200
                                                }
                                            },
                                        },
                                        DishDescription = "Pyszne kotlety z soczewicy podane z kaszą jaglaną, idealne dla wegetarian.",
                                        Size = 3,
                                        MethodOfPeparation = "Soczewicę gotujemy, blendujemy. Dodajemy kaszę jaglaną, formujemy kotlety i smażymy na patelni.",
                                        PreparationTime = 35,
                                        Portions = 4
                                    }
                                }
                            }
                        }
                    }
                },
                new DayMenu()
                {
                    DayOfWeek = Entities.DayOfWeek.Sunday,
                    Meals = new List<Meal>()
                    {
                        new Meal()
                        {
                            MealType = MealType.SecondBreakfast,
                            DishMeals = new List<DishMeal>()
                            {
                                new DishMeal()
                                {
                                    Dish = new Dish()
                                    {
                                        DishName = "Filet z dorsza z warzywami",
                                        DishProducts = new List<ProductDish>()
                                        {
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Filet z dorsza",
                                                    Weight = 400
                                                }
                                            },
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Marchew",
                                                    Weight = 150
                                                }
                                            },
                                            new ProductDish()
                                            {
                                                Product = new Product()
                                                {
                                                    ProductName = "Cebula",
                                                    Weight = 100
                                                }
                                            },
                                        },
                                        DishDescription = "Delikatny filet z dorsza zapieczony w piekarniku z warzywami.",
                                        Size = 3,
                                        MethodOfPeparation = "Filet z dorsza układamy na blaszce, dodajemy pokrojone warzywa, przyprawy. Pieczemy w piekarniku.",
                                        PreparationTime = 30,
                                        Portions = 3
                                    }
                                }
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
