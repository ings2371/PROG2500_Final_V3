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
        
        public string isDead => string.IsNullOrEmpty(DeathYear.ToString()) ? "Is not Dead" : "Died On: " + DeathYear;

        //public string Filmography
        //{
        //    get
        //    {
        //        // Get titles where this person was in a principal role
        //        var titles = Principals?
        //            .Where(p => p.Title != null && (p.Job?.ToLower().Contains("actor") == true || p.JobCategory?.ToLower().Contains("actor") == true))
        //            .Select(p => p.Title?.PrimaryTitle)
        //            .Where(t => !string.IsNullOrWhiteSpace(t))
        //            .Distinct()
        //            .Take(5) // or more
        //            .ToList();

        //        return titles != null && titles.Any()
        //            ? string.Join(", ", titles)
        //            : "No known films";
        //    }
        //}



    }
}
