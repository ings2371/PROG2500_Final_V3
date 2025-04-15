using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB_final_Project.Models
{
    public partial class Title
    {

        public virtual ICollection<Principal> Principals { get; set; } = new List<Principal>();

        //this function gets the director for films and games
        public string DirectorName
        {
            get
            {
                var director = Principals?
                    .FirstOrDefault(p =>
                        p.JobCategory?.ToLower() == "director" &&
                        p.Name != null);

                return director?.Name?.PrimaryName ?? "Director Not Listed";
            }
        }

        //this is a yes or no checker to see if a item isAdult
        public string IsAdultStatus
        {
            get
            {
                return IsAdult == true ? "Yes" : "No";
            }
        }
    }
}
