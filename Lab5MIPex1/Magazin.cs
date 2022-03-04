using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Lab5MIPex1
{
    public class Produs
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30,ErrorMessage = "Denumire prea lunga")]
        public string Denumire { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "Descriere prea lunga")]
        public string Descriere { get; set; }

        public DateTime DataIntrare { get; set; }

        public DateTime DataExpirare { get; set; }

        public int Cantitate { get; set; }
    }

    public class MagazinDbContext:DbContext
    {
        public DbSet<Produs> Produse { get; set; }
    }
}
