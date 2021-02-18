using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Entities.Concrete.Car { CarId = 2, BrandId = 1, ColorId = 1, DailyPrice = 120, ModelYear = 2010, Description = "Audi" });

             Console.WriteLine("CarId \t BrandId \t ColorId \t DailyPrice \t ModelYear \t Description");
             Console.WriteLine("----------------------------------------------------------------------");
           
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarId + "\t" + car.BrandId + "\t" + car.ColorId + "\t" + car.DailyPrice + "\t  " + car.ModelYear + "\t" + car.Description);
            }

            var result = carManager.GetCarDetails();
             if(result.Success == true)
             {
                 foreach (var car in result.Data )
                 {
                     Console.WriteLine(car.CarName + "  " + car.BrandName + "  " + car.ColorName + "  " + car.DailyPrice);
                 }
             }
             else
             {
                 Console.WriteLine(result.Message);
             }
        }
    }
}
