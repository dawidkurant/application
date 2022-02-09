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

        //Metoda zwracająca kolekcję produktów, które będą zawsze istnieć w tabeli product
        //baza automatycznie przydzieli id
        private IEnumerable<Product> GetProducts()
        {
            var products = new List<Product>()
            {
                new Product()
                {
                    Name = "Pomidor",
                    Category = new Category()
                    {
                        Name = "Owoce i Warzywa"
                    },
                    Groups = new List<Group>()
                    {
                        new Group()
                        {
                            Name = "Warzywa"
                        }
                    },
                    Unit = new Unit()
                    {
                        Name = "Sztuka"
                    },
                    Weight = 100.00
                },
                new Product()
                {
                    Name = "Cytryna",
                    Category = new Category()
                    {
                        Name = "Owoce i Warzywa"
                    },
                    Groups = new List<Group>()
                    {
                        new Group()
                        {
                            Name = "Owoce"
                        }
                    },
                    Unit = new Unit()
                    {
                        Name = "Sztuka"
                    },
                    Weight = 200.00
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
                    Name = "Pomidorowa",
                    Products = new List<Product>()
                    {
                        new Product()
                        {
                            Name = "Cytryna",
                            Category = new Category()
                            {
                                Name = "Owoce i Warzywa"
                            },
                            Groups = new List<Group>()
                            {
                                new Group()
                                {
                                    Name = "Owoce"
                                }
                            },
                            Unit = new Unit()
                            {
                                Name = "Sztuka"
                            },
                            Weight = 200.00
                        }
                    },
                    KindsOf = new List<KindOf>()
                    {
                        new KindOf()
                        {
                            Name = "Rodzaj1"
                        }
                    },
                    Types = new List<Type>()
                    {
                        new Type()
                        {
                            Name = "Typ1"
                        }
                    }
                },
                new Dish()
                {
                    Name = "Pomidorowa",
                    Products = new List<Product>()
                    {
                        new Product()
                        {
                            Name = "Cytryna",
                            Category = new Category()
                            {   
                                Name = "Owoce i Warzywa"
                            },
                            Groups = new List<Group>()
                            {
                                new Group()
                                {
                                    Name = "Owoce"
                                }
                            },
                            Unit = new Unit()
                            {
                                Name = "Sztuka"
                            },
                            Weight = 200.00
                        }
                    },
                    KindsOf = new List<KindOf>()
                    {
                        new KindOf()
                        {
                            Name = "Rodzaj2"
                        }
                    },
                    Types = new List<Type>()
                    {
                        new Type()
                        {
                            Name = "Typ2"
                        }
                    }
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
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                        Name = "Buraczki",
                        Products = new List<Product>()
                        {
                            new Product()
                            {
                                Name = "Cytryna",
                                Category = new Category()
                            {
                                Name = "Owoce i Warzywa"
                            },
                            Groups = new List<Group>()
                            {
                                new Group()
                                {
                                    Name = "Owoce"
                                }
                            },
                            Unit = new Unit()
                            {
                                Name = "Sztuka"
                            },
                            Weight = 400.00
                            }
                        }
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
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                        Name = "Jajko na twardo",
                        Products = new List<Product>()
                        {
                            new Product()
                            {
                                Name = "Jajko",
                                Category = new Category()
                            {
                                Name = "Owoce i Warzywa"
                            },
                            Groups = new List<Group>()
                            {
                                new Group()
                                {
                                    Name = "Owoce"
                                }
                            },
                            Unit = new Unit()
                            {
                                Name = "Sztuka"
                            },
                            Weight = 120.00
                            }
                        }
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
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                        Name = "Grzanki",
                        Products = new List<Product>()
                        {
                            new Product()
                            {
                                Name = "Chleb",
                                Category = new Category()
                            {
                                Name = "Owoce i Warzywa"
                            },
                            Groups = new List<Group>()
                            {
                                new Group()
                                {
                                    Name = "Owoce"
                                }
                            },
                            Unit = new Unit()
                            {
                                Name = "Sztuka"
                            },
                            Weight = 500.00
                            }
                        }
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
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                        Name = "Tosty",
                        Products = new List<Product>()
                        {
                            new Product()
                            {
                                Name = "Chleb tostowy",
                                Category = new Category()
                            {
                                Name = "Owoce i Warzywa"
                            },
                            Groups = new List<Group>()
                            {
                                new Group()
                                {
                                    Name = "Owoce"
                                }
                            },
                            Unit = new Unit()
                            {
                                Name = "Sztuka"
                            },
                            Weight = 350.00
                            }
                        }
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
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                        Name = "Żurek",
                        Products = new List<Product>()
                        {
                            new Product()
                            {
                                Name = "Kiełbasa",
                                Category = new Category()
                            {
                                Name = "Owoce i Warzywa"
                            },
                            Groups = new List<Group>()
                            {
                                new Group()
                                {
                                    Name = "Owoce"
                                }
                            },
                            Unit = new Unit()
                            {
                                Name = "Sztuka"
                            },
                            Weight = 240.00
                            }
                        }
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
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                        Name = "Zupa z dyni",
                        Products = new List<Product>()
                        {
                            new Product()
                            {
                                Name = "Dynia",
                                Category = new Category()
                            {
                                Name = "Owoce i Warzywa"
                            },
                            Groups = new List<Group>()
                            {
                                new Group()
                                {
                                    Name = "Owoce"
                                }
                            },
                            Unit = new Unit()
                            {
                                Name = "Sztuka"
                            },
                            Weight = 1000.00
                            }
                        }
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
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Kurczak",
                            Products = new List<Product>()
                            {
                                new Product()
                                {
                                    Name = "Kura",
                                    Category = new Category()
                                    {
                                        Name = "Owoce i Warzywa"
                                    },
                                    Groups = new List<Group>()
                                    {
                                        new Group()
                                        {
                                            Name = "Owoce"
                                        }
                                    },
                                    Unit = new Unit()
                                    {
                                        Name = "Sztuka"
                                    },
                                    Weight = 2000
                                }
                            }
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
                    Name = "Treningowy",
                    Description = "Jadłospis na rzeźbę",
                    Monday = new Monday()
                    {
                        Dishes = new List<Dish>()
                        {
                            new Dish()
                            {
                                Name = "Kurczak",
                                Products = new List<Product>()
                                {
                                    new Product()
                                    {
                                        Name = "Kura",
                                        Category = new Category()
                                        {
                                        Name = "Owoce i Warzywa"
                                        },
                                        Groups = new List<Group>()
                                        {
                                            new Group()
                                            {
                                                Name = "Owoce"
                                            }
                                        },
                                        Unit = new Unit()
                                        {
                                            Name = "Sztuka"
                                        },
                                        Weight = 2000
                                    }
                                }
                            }
                        }
                    },
                    Friday = new Friday()
                    {
                        Dishes = new List<Dish>()
                        {
                            new Dish()
                            {
                                Name = "Pyzy",
                                Products = new List<Product>()
                                {
                                    new Product()
                                    {
                                        Name = "Ziemniaki",
                                        Category = new Category()
                                        {
                                            Name = "Owoce i Warzywa"
                                        },
                                        Groups = new List<Group>()
                                        {
                                            new Group()
                                            {
                                                Name = "Owoce"
                                            }
                                        },
                                        Unit = new Unit()
                                        {
                                            Name = "Sztuka"
                                        },
                                        Weight = 5000
                                    }
                                }
                            }
                        }
                    }
                }
            };

            return menus;
        }
    }
}
