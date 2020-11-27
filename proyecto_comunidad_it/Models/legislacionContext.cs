using System;
using Microsoft.EntityFrameworkCore;

namespace proyecto_comunidad_it.Models
{
   public class legislacionContext :DbContext
    {
      
      public legislacionContext(DbContextOptions<legislacionContext> options)
        :base(options)   
      {

      }   
      // public DbSet <legislacion> legislacion { get;set }



    }


}
