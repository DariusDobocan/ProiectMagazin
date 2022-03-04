using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Lab5MIPex1
{
    public class IstoricVanzari
    {
       [Key]
        public int Id { get; set; }

        [Required]
        public int Id_user { get; set; }

        [Required]
        public string Denumire_produs { get; set; }

        [Required]
        public int Cantitate { get; set; }
    }
    public class IstoricVanzariDbContext : DbContext
    {
        public DbSet<IstoricVanzari> Vanzari { get; set; }
    }

}
