using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB_final_Project.Models
{
    public partial class Title
    {
        public string DirectorName
        {
            get
            {
                var director = Names
                    .SelectMany(name => name.Principals)
                    .FirstOrDefault(p =>
                        p.TitleId == TitleId &&
                        (p.JobCategory?.ToLower() == "director" || p.Job?.ToLower() == "director"));

                return director?.Name?.PrimaryName ?? "Unknown Director";
            }
        }

        public string CastList
        {
            get
            {
                var castNames = Names
                    .SelectMany(n => n.Principals)
                    .Where(p =>
                        p.TitleId == TitleId &&
                        (p.JobCategory?.ToLower().Contains("actor") == true ||
                         p.Job?.ToLower().Contains("actor") == true))
                    .Select(p => p.Name?.PrimaryName)
                    .Where(name => !string.IsNullOrWhiteSpace(name))
                    .Distinct()
                    .Take(5)
                    .ToList(); // Force evaluation here

                return castNames.Any() ? string.Join(", ", castNames) : "Cast unknown";
            }
        }

        public string IsAdultStatus
        {
            get
            {
                return IsAdult == true ? "Yes" : "No";
            }
        }
    }
}
