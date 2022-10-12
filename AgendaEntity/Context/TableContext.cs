using AgendaEntity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaEntity.Context {
    internal class TableContext :DbContext{

        public TableContext() : base("Phone_Book") { }
        public DbSet<Person> Persons { get; set; }

        public DbSet<TelephoneBook> Phones { get; set; }
    }
}
