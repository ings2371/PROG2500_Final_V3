using System;
using System.Collections.Generic;

namespace IMDB_final_Project.Models;

public partial class Genre
{
    public int GenreId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Title> Titles { get; set; } = new List<Title>();
}
