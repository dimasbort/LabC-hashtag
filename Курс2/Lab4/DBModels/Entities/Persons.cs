using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModels.Entities
{

    public class Persons
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public string PhoneNumber { get; set; }
        public string Job { get; set; }
        public DateTime? BirthDay { get; set; }
    }
}
