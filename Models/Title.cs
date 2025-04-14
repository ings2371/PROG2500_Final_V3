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


        //public string CastList
        //{
        //    get
        //    {
        //        var castNames = Names
        //            .SelectMany(n => n.Principals)
        //            .Where(p =>
        //                p.TitleId == TitleId &&
        //                (p.JobCategory?.ToLower().Contains("actor") == true ||
        //                 p.Job?.ToLower().Contains("actor") == true))
        //            .Select(p => p.Name?.PrimaryName)
        //            .Where(name => !string.IsNullOrWhiteSpace(name))
        //            .Distinct()
        //            .Take(5)
        //            .ToList(); // Force evaluation here

        //        return castNames.Any() ? string.Join(", ", castNames) : "Cast unknown";
        //    }
        //}

        public string IsAdultStatus
        {
            get
            {
                return IsAdult == true ? "Yes" : "No";
            }
        }
    }
}
