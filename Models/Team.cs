using System.ComponentModel.DataAnnotations;

namespace Players.Models;

public class Team
{
    public int TeamID {get; set;}


    [Display(Name = "Team")]
    public string TeamName {get; set;} = string.Empty;

    public int PlayerID {get; set;} // Foreign Key
    public Player? Player {get; set;} = default!;
}