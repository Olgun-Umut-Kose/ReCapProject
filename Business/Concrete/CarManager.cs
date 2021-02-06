using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private IRepository<Car> _dal;

        public CarManager(IRepository<Car> dal)
        {
            _dal = dal;
        }

        public void AddOrEdit(Car entity)
        {

            if (entity.Description.Length > 2 && entity.DailyPrice > 0)
            {
                if (entity.Id == 0)
                {
                    _dal.Add(entity);
                }
                else
                {
                    _dal.Update(entity);
                }
            }
            else
            {
                Console.WriteLine("değişiklik yapamazsın çünkü kurallara uymuyorsun");
            }
            
        }

        public void Delete(Car entity)
        {
            _dal.Delete(entity);
        }

        public List<Car> GetAll(Func<Car,bool> filter = null)
        {
            return _dal.GetAll(filter);
        }

        public Car Get(Func<Car,bool> filter)
        {
            return _dal.Get(filter);
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return GetAll(c => c.ColorId == id);
        }
    }
}
