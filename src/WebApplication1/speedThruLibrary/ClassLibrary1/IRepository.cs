using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedThruLibrary
{
    public interface IRepository<T> where T: Car
    {
        T GetById(int id);
        IEnumerable<T> ListAll();
        void NewCar(T newCar);
        void EditCar(T editedCar);
        void DeleteCar(int id);
    }
}
