using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestauranteData
    {
        //IEnumerable<Restaurante> GetAll();
        IEnumerable<Restaurante> GetRestaurantByName(string name);
        Restaurante GetById(int id);
        Restaurante Update(Restaurante updateRestaurante);
        Restaurante Add(Restaurante newRestaurante);
        Restaurante Delete(int id);
        int Commit();//geralmente é utilizado após uma ação no banco de dados
    }
}
