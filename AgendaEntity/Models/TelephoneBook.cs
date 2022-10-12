using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Policy;

namespace AgendaEntity.Models {
    internal class TelephoneBook {

        [Key()]
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        [ForeignKey("Person")]
        public String NameId {get; set; }
        public virtual Person Person { get; set; } 
        
        public override string ToString() {

            return $"\nID: { this.Id} \nName:{ this.NameId} \nPhone:{ this.Phone}\nMobile:{ this.Mobile}";
        }
    }
}
