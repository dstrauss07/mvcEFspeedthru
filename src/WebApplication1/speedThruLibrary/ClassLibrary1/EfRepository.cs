using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedThruLibrary
{
    public class EfRepository<T> : IRepository<T> where T : Car
    {
        private readonly SpeedDbContext _speedDbContext;

        public EfRepository(SpeedDbContext speedDbContext)
        {
            _speedDbContext = speedDbContext;
        }

        public IEnumerable<T> ListAll()
        {
            IEnumerable<T> cars = _speedDbContext.Set<T>();
            return cars;
         }

        public T GetById(int id)
        {
            return _speedDbContext.Set<T>().Find(id);
        }


        public void DeleteCar(int id)
        {
           var carToRemove = GetById(id);
            _speedDbContext.Set<T>().Remove(carToRemove);
            _speedDbContext.SaveChanges();

        }

        public void EditCar(T editedCar)
        {
            _speedDbContext.Set<T>().Update(editedCar);
            _speedDbContext.SaveChanges();
        }

            public void NewCar(T newCar)
        {
            _speedDbContext.Set<T>().Add(newCar);
            _speedDbContext.SaveChanges();
        }
    }
}
