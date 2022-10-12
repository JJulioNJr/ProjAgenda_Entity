using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaEntity.Models {
    internal class Person {
        [Key]
        public String Name { get; set; }
        public String Email { get; set; }
        public String Idade { get; set; }

        public override String ToString() {
            return $"\nName: { this.Name} \nEmail: {this.Email}\nIdade:{this.Idade}";
        }
    }
}
