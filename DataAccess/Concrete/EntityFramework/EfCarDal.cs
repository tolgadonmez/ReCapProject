using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,ReCapContext>,ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from car in context.Cars
                             join b in context.Brands
                             on car.BrandId equals b.BrandId
                             join col in context.Colors
                             on car.ColorId equals col.ColorId
                             select new CarDetailDto
                             {
                                 CarName = car.Description,
                                 BrandName = b.BrandName,
                                 ColorName = col.ColorName,
                                 DailyPrice = car.DailyPrice,

                             };
                return result.ToList();
            }
        }
    }   
}
