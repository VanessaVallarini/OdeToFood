using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
    //EntityFramework cria e gerencia banco de dados para nós através das informações passadas no DbContext
    public class OdeToFoodDbContext : DbContext
    {
        public DbSet<Restaurante> Restaurantes { get; set; }

        public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options)
            :base(options)//passando as infromações de conexões para o DbContext
        {

        }
    }
}
