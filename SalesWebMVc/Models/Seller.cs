using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVc.Models
{
    public class Seller
    {

        
        public int Id { get; set; }
        
        [Required(ErrorMessage ="{0} requerido")]
        [StringLength(maximumLength:60,MinimumLength =3,ErrorMessage ="Tamanho do nome entre  {1} e {2} Caracteres")]
        [Display(Name = "Nome")]
        public string Name { get; set; }
        [Display(Name = "Salário Base")]
        [DisplayFormat(DataFormatString ="{0:C}")]
        [Required(ErrorMessage = "{0} requerido")]
        [Range(100.0,50000.0,ErrorMessage ="O salário fica entre {0} e {1}")]
        public double BaseSalary { get; set; }

        [Required(ErrorMessage = "{0} requerido")]
        [Display(Name="Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }
        
        [Required(ErrorMessage = "{0} requerido")]
        [Display(Name = "Departamento")]
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();


        public Seller()
        {

        }

        public Seller(int id, string name, double baseSalary, DateTime birthDate, Department department)
        {
            Id = id;
            Name = name;
            BaseSalary = baseSalary;
            BirthDate = birthDate;
            Department = department;
        }


        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);

        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }


    }
}
