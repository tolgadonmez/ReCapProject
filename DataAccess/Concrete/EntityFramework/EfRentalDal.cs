using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from u in context.Users
                             join cus in context.Customers
                             on u.UserId equals cus.UserId
                             from car in context.Cars
                             join r in context.Rentals
                             on car.CarId equals r.CarId
                             select new RentalDetailDto
                             {
                                 Id = r.RentalId,
                                 CarName = car.Description,
                                 CustomerName = cus.CompanyName,
                                 CarId = car.CarId,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };

                return result.ToList();
            }
        }
    }

}
