﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Papu.Entities;
using Papu.Models;
using Papu.Models.Create;
using System.Collections.Generic;
using System.Linq;

namespace Papu.Services
{
    public class TimesOfDayService : ITimesOfDayService
    {
        private readonly PapuDbContext _dbContext;
        private readonly IMapper _mapper;

        public TimesOfDayService(PapuDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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

            Breakfast breakfast2 = _dbContext.Breakfasts
                .Include(c => c.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.BreakfastId == breakfast.BreakfastId);

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

            SecondBreakfast secondBreakfast2 = _dbContext.SecondBreakfasts
                .Include(c => c.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.SecondBreakfastId == secondBreakfast.SecondBreakfastId);

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

            Lunch lunch2 = _dbContext.Lunches
                .Include(c => c.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.LunchId == lunch.LunchId);

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

            Snack snack2 = _dbContext.Snacks
                .Include(c => c.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.SnackId == snack.SnackId);

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

            Dinner dinner2 = _dbContext.Dinners
                .Include(c => c.Products).ThenInclude(cs => cs.Product)
                .Include(c => c.Dishes).ThenInclude(cs => cs.Dish)
                .FirstOrDefault(c => c.DinnerId == dinner.DinnerId);

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
    }
}
