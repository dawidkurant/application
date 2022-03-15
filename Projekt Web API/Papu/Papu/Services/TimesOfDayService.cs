using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Papu.Entities;
using Papu.Exceptions;
using Papu.Models;
using Papu.Models.Update.TimesOfDay;
using System.Collections.Generic;
using System.Linq;

namespace Papu.Services
{
    public class TimesOfDayService : ITimesOfDayService
    {
        private readonly PapuDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<TimesOfDayService> _logger;

        public TimesOfDayService(PapuDbContext dbContext, IMapper mapper, ILogger<TimesOfDayService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        //Wyświetlanie jednego śniadania
        public BreakfastDto GetByIdBreakfast(int id)
        {
            Breakfast breakfast = _dbContext
                .Breakfasts
                .Include(c => c.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.BreakfastId == id);


            if (breakfast is null)
            {
                return null;
            }

            var result = _mapper.Map<BreakfastDto>(breakfast);

            return result;
        }

        //Wyświetlanie jednego drugiego śniadania
        public SecondBreakfastDto GetByIdSecondBreakfast(int id)
        {
            SecondBreakfast secondBreakfast = _dbContext
                .SecondBreakfasts
                .Include(c => c.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.SecondBreakfastId == id);


            if (secondBreakfast is null)
            {
                return null;
            }

            var result = _mapper.Map<SecondBreakfastDto>(secondBreakfast);

            return result;
        }

        //Wyświetlanie jednego obiadu
        public LunchDto GetByIdLunch(int id)
        {
            Lunch lunch = _dbContext
                .Lunches
                .Include(c => c.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.LunchId == id);


            if (lunch is null)
            {
                return null;
            }

            var result = _mapper.Map<LunchDto>(lunch);

            return result;
        }

        //Wyświetlanie jednego podwieczorku
        public SnackDto GetByIdSnack(int id)
        {
            Snack snack = _dbContext
                .Snacks
                .Include(c => c.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.SnackId == id);


            if (snack is null)
            {
                return null;
            }

            var result = _mapper.Map<SnackDto>(snack);

            return result;
        }

        //Wyświetlanie jednej kolacji
        public DinnerDto GetByIdDinner(int id)
        {
            Dinner dinner = _dbContext
                .Dinners
                .Include(c => c.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.DinnerId == id);


            if (dinner is null)
            {
                return null;
            }

            var result = _mapper.Map<DinnerDto>(dinner);

            return result;
        }

        //Wyświetlanie wszystkich śniadań
        public IEnumerable<BreakfastDto> GetAllBreakfast()
        {
            var breakfasts = _dbContext
                .Breakfasts
                .Include(c => c.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dishes).ThenInclude(cs => cs.Dish)
                .ToList();

            var breakfastsDto = _mapper.Map<List<BreakfastDto>>(breakfasts);

            return breakfastsDto;
        }

        //Wyświetlanie wszystkich drugich śniadań
        public IEnumerable<SecondBreakfastDto> GetAllSecondBreakfast()
        {
            var secondBreakfasts = _dbContext
                .SecondBreakfasts
                .Include(c => c.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dishes).ThenInclude(cs => cs.Dish)
                .ToList();

            var secondBreakfastsDto = _mapper.Map<List<SecondBreakfastDto>>(secondBreakfasts);

            return secondBreakfastsDto;
        }

        //Wyświetlanie wszystkich obiadów
        public IEnumerable<LunchDto> GetAllLunch()
        {
            var lunches = _dbContext
                .Lunches
                .Include(c => c.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dishes).ThenInclude(cs => cs.Dish)
                .ToList();

            var lunchesDto = _mapper.Map<List<LunchDto>>(lunches);

            return lunchesDto;
        }

        //Wyświetlanie wszystkich podwieczorków
        public IEnumerable<SnackDto> GetAllSnack()
        {
            var snacks = _dbContext
                .Snacks
                .Include(c => c.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dishes).ThenInclude(cs => cs.Dish)
                .ToList();

            var snacksDto = _mapper.Map<List<SnackDto>>(snacks);

            return snacksDto;
        }

        //Wyświetlanie wszystkich kolacji
        public IEnumerable<DinnerDto> GetAllDinner()
        {
            var dinners = _dbContext
                .Dinners
                .Include(c => c.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dishes).ThenInclude(cs => cs.Dish)
                .ToList();

            var dinnersDto = _mapper.Map<List<DinnerDto>>(dinners);

            return dinnersDto;
        }

        //Tworzenie nowego śniadania 
        public int CreateBreakfast(CreateBreakfastDto dtoBreakfast)
        {

            var breakfast = _mapper.Map<Breakfast>(dtoBreakfast);

            foreach (var addProduct in dtoBreakfast.ProductId)
            {

                Product product = _dbContext.Products
                    .FirstOrDefault(s => s.ProductId == addProduct);

                BreakfastProduct productBreakfast = new BreakfastProduct
                {
                    Breakfast = breakfast,
                    Product = product
                };

                _dbContext.ProductBreakfasts.Add(productBreakfast);

            }

            foreach (var addDish in dtoBreakfast.DishId)
            {

                Dish dish = _dbContext.Dishes
                    .FirstOrDefault(s => s.DishId == addDish);

                BreakfastDish dishBreakfast = new BreakfastDish
                {
                    Dish = dish,
                    Breakfast = breakfast
                };

                _dbContext.DishBreakfasts.Add(dishBreakfast);
            }


            _dbContext.SaveChanges();

            return breakfast.BreakfastId;
        }

        //Tworzenie nowego drugiego śniadania 
        public int CreateSecondBreakfast(CreateSecondBreakfastDto dtoSecondBreakfast)
        {

            var secondBreakfast = _mapper.Map<SecondBreakfast>(dtoSecondBreakfast);

            foreach (var addProduct in dtoSecondBreakfast.ProductId)
            {

                Product product = _dbContext.Products
                    .FirstOrDefault(s => s.ProductId == addProduct);

                SecondBreakfastProduct secondProductBreakfast = new SecondBreakfastProduct
                {
                    SecondBreakfast = secondBreakfast,
                    Product = product
                };

                _dbContext.ProductSecondBreakfasts.Add(secondProductBreakfast);

            }

            foreach (var addDish in dtoSecondBreakfast.DishId)
            {

                Dish dish = _dbContext.Dishes
                    .FirstOrDefault(s => s.DishId == addDish);

                SecondBreakfastDish dishSecondBreakfast = new SecondBreakfastDish
                {
                    Dish = dish,
                    SecondBreakfast = secondBreakfast
                };

                _dbContext.DishSecondBreakfasts.Add(dishSecondBreakfast);
            }


            _dbContext.SaveChanges();

            return secondBreakfast.SecondBreakfastId;
        }

        //Tworzenie nowego obiadu 
        public int CreateLunch(CreateLunchDto dtoLunch)
        {

            var lunch = _mapper.Map<Lunch>(dtoLunch);

            foreach (var addProduct in dtoLunch.ProductId)
            {

                Product product = _dbContext.Products
                    .FirstOrDefault(s => s.ProductId == addProduct);

                LunchProduct lunchProduct = new LunchProduct
                {
                    Lunch = lunch,
                    Product = product
                };

                _dbContext.LunchProducts.Add(lunchProduct);

            }

            foreach (var addDish in dtoLunch.DishId)
            {

                Dish dish = _dbContext.Dishes
                    .FirstOrDefault(s => s.DishId == addDish);

                LunchDish lunchDish = new LunchDish
                {
                    Dish = dish,
                    Lunch = lunch
                };

                _dbContext.LunchDishes.Add(lunchDish);
            }


            _dbContext.SaveChanges();

            return lunch.LunchId;
        }

        //Tworzenie nowego podwieczorku
        public int CreateSnack(CreateSnackDto dtoSnack)
        {

            var snack = _mapper.Map<Snack>(dtoSnack);

            foreach (var addProduct in dtoSnack.ProductId)
            {

                Product product = _dbContext.Products
                    .FirstOrDefault(s => s.ProductId == addProduct);

                SnackProduct snackProduct = new SnackProduct
                {
                    Snack = snack,
                    Product = product
                };

                _dbContext.SnackProducts.Add(snackProduct);

            }

            foreach (var addDish in dtoSnack.DishId)
            {

                Dish dish = _dbContext.Dishes
                    .FirstOrDefault(s => s.DishId == addDish);

                SnackDish snackDish = new SnackDish
                {
                    Snack = snack,
                    Dish = dish
                };

                _dbContext.SnackDishes.Add(snackDish);
            }


            _dbContext.SaveChanges();

            return snack.SnackId;
        }

        //Tworzenie nowej kolacji
        public int CreateDinner(CreateDinnerDto dtoDinner)
        {

            var dinner = _mapper.Map<Dinner>(dtoDinner);

            foreach (var addProduct in dtoDinner.ProductId)
            {

                Product product = _dbContext.Products
                    .FirstOrDefault(s => s.ProductId == addProduct);

                DinnerProduct dinnerProduct = new DinnerProduct
                {
                    Dinner = dinner,
                    Product = product
                };

                _dbContext.DinnerProducts.Add(dinnerProduct);

            }

            foreach (var addDish in dtoDinner.DishId)
            {

                Dish dish = _dbContext.Dishes
                    .FirstOrDefault(s => s.DishId == addDish);

                DinnerDish dinnerDish = new DinnerDish
                {
                    Dinner = dinner,
                    Dish = dish
                };

                _dbContext.DinnerDishes.Add(dinnerDish);
            }


            _dbContext.SaveChanges();

            return dinner.DinnerId;
        }

        //Edycja śniadania
        public void UpdateBreakfast(int id, UpdateBreakfastDto dtoBreakfast)
        {
            var breakfast = _dbContext
                .Breakfasts
                .Include(c => c.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.BreakfastId == id);

            //Jeśli jesteśmy pewni, że dane śniadanie nie istnieje, zwracamy wyjątek
            if (breakfast is null)
            {
                throw new NotFoundException("Breakfast not found");
            }

            foreach (var old in breakfast.Products)
            {
                _dbContext.ProductBreakfasts.Remove(old);
            }

            breakfast.Products.Clear();

            foreach (var addProduct in dtoBreakfast.ProductId)
            {

                Product product = _dbContext.Products
                    .FirstOrDefault(s => s.ProductId == addProduct);

                BreakfastProduct productBreakfast = new BreakfastProduct
                {
                    Breakfast = breakfast,
                    Product = product
                };

                _dbContext.ProductBreakfasts.Add(productBreakfast);

            }

            foreach (var old in breakfast.Dishes)
            {
                _dbContext.DishBreakfasts.Remove(old);
            }

            breakfast.Products.Clear();

            foreach (var addDish in dtoBreakfast.DishId)
            {

                Dish dish = _dbContext.Dishes
                    .FirstOrDefault(s => s.DishId == addDish);

                BreakfastDish dishBreakfast = new BreakfastDish
                {
                    Dish = dish,
                    Breakfast = breakfast
                };

                _dbContext.DishBreakfasts.Add(dishBreakfast);
            }

            _dbContext.SaveChanges();
        }

        //Edycja drugiego śniadania
        public void UpdateSecondBreakfast(int id, UpdateSecondBreakfastDto dtoSecondBreakfast)
        {
            var secondBreakfast = _dbContext
                .SecondBreakfasts
                .Include(c => c.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.SecondBreakfastId == id);

            //Jeśli jesteśmy pewni, że dane drugie śniadanie nie istnieje, zwracamy wyjątek
            if (secondBreakfast is null)
            {
                throw new NotFoundException("Second breakfast not found");
            }

            foreach (var old in secondBreakfast.Products)
            {
                _dbContext.ProductSecondBreakfasts.Remove(old);
            }

            secondBreakfast.Products.Clear();

            foreach (var addProduct in dtoSecondBreakfast.ProductId)
            {

                Product product = _dbContext.Products
                    .FirstOrDefault(s => s.ProductId == addProduct);

                SecondBreakfastProduct productSecondBreakfast = new SecondBreakfastProduct
                {
                    SecondBreakfast = secondBreakfast,
                    Product = product
                };

                _dbContext.ProductSecondBreakfasts.Add(productSecondBreakfast);

            }

            foreach (var old in secondBreakfast.Dishes)
            {
                _dbContext.DishSecondBreakfasts.Remove(old);
            }

            secondBreakfast.Products.Clear();

            foreach (var addDish in dtoSecondBreakfast.DishId)
            {

                Dish dish = _dbContext.Dishes
                    .FirstOrDefault(s => s.DishId == addDish);

                SecondBreakfastDish dishSecondBreakfast = new SecondBreakfastDish
                {
                    Dish = dish,
                    SecondBreakfast = secondBreakfast
                };

                _dbContext.DishSecondBreakfasts.Add(dishSecondBreakfast);
            }

            _dbContext.SaveChanges();
        }

        //Edycja obiadu
        public void UpdateLunch(int id, UpdateLunchDto dtoLunch)
        {
            var lunch = _dbContext
                .Lunches
                .Include(c => c.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.LunchId == id);

            //Jeśli jesteśmy pewni, że dany obiad nie istnieje, zwracamy wyjątek
            if (lunch is null)
            {
                throw new NotFoundException("Lunch not found");
            }

            foreach (var old in lunch.Products)
            {
                _dbContext.LunchProducts.Remove(old);
            }

            lunch.Products.Clear();

            foreach (var addProduct in dtoLunch.ProductId)
            {

                Product product = _dbContext.Products
                    .FirstOrDefault(s => s.ProductId == addProduct);

                LunchProduct lunchProduct = new LunchProduct
                {
                    Lunch = lunch,
                    Product = product
                };

                _dbContext.LunchProducts.Add(lunchProduct);

            }

            foreach (var old in lunch.Dishes)
            {
                _dbContext.LunchDishes.Remove(old);
            }

            lunch.Products.Clear();

            foreach (var addDish in dtoLunch.DishId)
            {

                Dish dish = _dbContext.Dishes
                    .FirstOrDefault(s => s.DishId == addDish);

                LunchDish lunchDish = new LunchDish
                {
                    Dish = dish,
                    Lunch = lunch
                };

                _dbContext.LunchDishes.Add(lunchDish);
            }

            _dbContext.SaveChanges();
        }

        //Edycja podwieczorka
        public void UpdateSnack(int id, UpdateSnackDto dtoSnack)
        {
            var snack = _dbContext
                .Snacks
                .Include(c => c.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.SnackId == id);

            //Jeśli jesteśmy pewni, że dany podwieczorek nie istnieje, zwracamy wyjątek
            if (snack is null)
            {
                throw new NotFoundException("Snack not found");
            }

            foreach (var old in snack.Products)
            {
                _dbContext.SnackProducts.Remove(old);
            }

            snack.Products.Clear();

            foreach (var addProduct in dtoSnack.ProductId)
            {

                Product product = _dbContext.Products
                    .FirstOrDefault(s => s.ProductId == addProduct);

                SnackProduct snackProduct = new SnackProduct
                {
                    Snack = snack,
                    Product = product
                };

                _dbContext.SnackProducts.Add(snackProduct);

            }

            foreach (var old in snack.Dishes)
            {
                _dbContext.SnackDishes.Remove(old);
            }

            snack.Products.Clear();

            foreach (var addDish in dtoSnack.DishId)
            {

                Dish dish = _dbContext.Dishes
                    .FirstOrDefault(s => s.DishId == addDish);

                SnackDish snackDish = new SnackDish
                {
                    Snack = snack,
                    Dish = dish
                };

                _dbContext.SnackDishes.Add(snackDish);
            }

            _dbContext.SaveChanges();
        }

        //Edycja kolacji
        public void UpdateDinner(int id, UpdateDinnerDto dtoDinner)
        {
            var dinner = _dbContext
                .Dinners
                .Include(c => c.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.DinnerId == id);

            //Jeśli jesteśmy pewni, że dana kolacja nie istnieje, zwracamy wyjątek
            if (dinner is null)
            {
                throw new NotFoundException("Dinner not found");
            }

            foreach (var old in dinner.Products)
            {
                _dbContext.DinnerProducts.Remove(old);
            }

            dinner.Products.Clear();

            foreach (var addProduct in dtoDinner.ProductId)
            {

                Product product = _dbContext.Products
                    .FirstOrDefault(s => s.ProductId == addProduct);

                DinnerProduct dinnerProduct = new DinnerProduct
                {
                    Dinner = dinner,
                    Product = product
                };

                _dbContext.DinnerProducts.Add(dinnerProduct);

            }

            foreach (var old in dinner.Dishes)
            {
                _dbContext.DinnerDishes.Remove(old);
            }

            dinner.Products.Clear();

            foreach (var addDish in dtoDinner.DishId)
            {

                Dish dish = _dbContext.Dishes
                    .FirstOrDefault(s => s.DishId == addDish);

                DinnerDish dinnerDish = new DinnerDish
                {
                    Dinner = dinner,
                    Dish = dish
                };

                _dbContext.DinnerDishes.Add(dinnerDish);
            }

            _dbContext.SaveChanges();
        }

        //Usuwanie śniadania
        public bool DeleteBreakfast(int id)
        {
            _logger.LogError($"Breakfast with id: {id} DELETE action invoked");

            var breakfast =
                _dbContext
                .Breakfasts
                .Include(c => c.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.BreakfastId == id);

            if (breakfast is null)
            {
                return false;
            }

            _dbContext.Breakfasts.Remove(breakfast);
            _dbContext.SaveChanges();

            return true;
        }

        //Usuwanie drugiego śniadania
        public bool DeleteSecondBreakfast(int id)
        {
            _logger.LogError($"Second breakfast with id: {id} DELETE action invoked");

            var secondBreakfast =
                _dbContext
                .SecondBreakfasts
                .Include(c => c.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.SecondBreakfastId == id);

            if (secondBreakfast is null)
            {
                return false;
            }

            _dbContext.SecondBreakfasts.Remove(secondBreakfast);
            _dbContext.SaveChanges();

            return true;
        }

        //Usuwanie obiadu
        public bool DeleteLunch(int id)
        {
            _logger.LogError($"Lunch with id: {id} DELETE action invoked");

            var lunch =
                _dbContext
                .Lunches
                .Include(c => c.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.LunchId == id);

            if (lunch is null)
            {
                return false;
            }

            _dbContext.Lunches.Remove(lunch);
            _dbContext.SaveChanges();

            return true;
        }

        //Usuwanie podwieczorka
        public bool DeleteSnack(int id)
        {
            _logger.LogError($"Snack with id: {id} DELETE action invoked");

            var snack =
                _dbContext
                .Snacks
                .Include(c => c.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.SnackId == id);

            if (snack is null)
            {
                return false;
            }

            _dbContext.Snacks.Remove(snack);
            _dbContext.SaveChanges();

            return true;
        }

        //Usuwanie kolacji
        public bool DeleteDinner(int id)
        {
            _logger.LogError($"Dinner with id: {id} DELETE action invoked");

            var dinner =
                _dbContext
                .Dinners
                .Include(c => c.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.DinnerId == id);

            if (dinner is null)
            {
                return false;
            }

            _dbContext.Dinners.Remove(dinner);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
