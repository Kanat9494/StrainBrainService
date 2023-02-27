namespace StrainBrainService.Models;

public class User
{
    [Key]
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string? AccessToken { get; set; }
    public double? UserBalance { get; set; }
    public string? UserScore { get; set; }
}
