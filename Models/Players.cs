using System.ComponentModel.DataAnnotations;

namespace Players.Models;

public class Player
{
    public int PlayerID {get; set;}

    [StringLength(60, MinimumLength = 3)]
    public string Name {get; set;} = string.Empty;

    public int Age {get; set;}

    public decimal BA {get; set;}

    public decimal KRate {get; set;}

    public decimal WalkRate {get; set;}

    public int HR {get; set;}

    [Display(Name = "Team")]
    public List<Team> Teams {get; set;} = default!;
}