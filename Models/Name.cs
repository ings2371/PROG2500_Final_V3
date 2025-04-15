using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB_final_Project.Models
{
    public partial class Name
    {
        //this is checking if someone is dead or not
        public string isDead => string.IsNullOrEmpty(DeathYear.ToString()) ? "Is not Dead" : "Died On: " + DeathYear;

      
    }
}
