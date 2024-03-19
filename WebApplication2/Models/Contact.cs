namespace WebApplication2.Models;
using System.ComponentModel.DataAnnotations;
public class Contact
{
     
    [StringLength(50, MinimumLength = 3, ErrorMessage = "The length of the string must be between 3 and 50 characters")]
    public string Name { get; set; }
    [RegularExpression(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}", ErrorMessage = "Invalid phone")]
    public string Phone { get; set; }
     
    [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid email")]
    public string Email { get; set; }
    [StringLength(100,MinimumLength = 20, ErrorMessage = "The length of the line must be 20 characters or more")]
    public string Text { get; set; }
}