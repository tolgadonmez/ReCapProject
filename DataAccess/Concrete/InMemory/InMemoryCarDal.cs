using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{CarId=1, BrandId=1, ColorId=1, DailyPrice=150, ModelYear=2010, Description="Honda Civic"},
                new Car{CarId=2, BrandId=1, ColorId=2, DailyPrice=150, ModelYear=2010, Description="Seat Leon FR"},
                new Car{CarId=3, BrandId=2, ColorId=1, DailyPrice=150, ModelYear=2010, Description="Fiat Doblo"},
                new Car{CarId=4, BrandId=2, ColorId=2, DailyPrice=150, ModelYear=2010, Description="BMW 3.20"},
                new Car{CarId=5, BrandId=2, ColorId=3, DailyPrice=150, ModelYear=2010, Description="Mini Cooper"}
            };
        }
        public void Add(Car car)
        {
             _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }
    }
}
