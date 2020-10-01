using System;
using System.ComponentModel.DataAnnotations;

public class FamilyMember
{
    public Guid id {get; set;}
    [Required(ErrorMessage ="Please enter firstname")]
    public string firstname { get; set; }
    [Required(ErrorMessage = "Please enter lastname")]
    public string lastname { get; set; }
    [Required(ErrorMessage = "Please enter email")]
    [EmailAddress(ErrorMessage ="Please enter valid email")]
    public string email { get; set; }
    public string role { get; set; }
    public string avtar { get; set; }
}
