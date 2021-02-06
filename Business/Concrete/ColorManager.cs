using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ColorManager : IService<Color>
    {
        IRepository<Color> _dal;

        public ColorManager(IRepository<Color> dal)
        {
            _dal = dal;
        }

        public void AddOrEdit(Color entity)
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

        public void Delete(Color entity)
        {
            _dal.Delete(entity);
        }

        public List<Color> GetAll(Func<Color,bool> filter = null)
        {
            return _dal.GetAll(filter);
        }

        public Color Get(Func<Color,bool> filter)
        {
            return _dal.Get(filter);
        }


    }

}
