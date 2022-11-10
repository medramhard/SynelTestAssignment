using System.ComponentModel.DataAnnotations;

namespace SynelEmployees.Models;

public class EmployeeDisplayModel
{
    [Display(Name = "Payroll Number")]
    public string PayrollNumber { get; set; }

    [Display(Name = "Forename")]
    public string Forename { get; set; }

    [Display(Name = "Surname")]
    public string Surname { get; set; }

    [Display(Name = "Birth Date")]
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }

    [Display(Name = "Phone")]
    [DataType(DataType.PhoneNumber)]
    public string Phone { get; set; }

    [Display(Name = "Cell Phone")]
    [DataType(DataType.PhoneNumber)]
    public string CellPhone { get; set; }

    [Display(Name = "Email Address")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Display(Name = "Street Address")]
    public string StreetAddress { get; set; }

    [Display(Name = "City")]
    public string City { get; set; }

    [Display(Name = "Postcode")]
    [DataType(DataType.PostalCode)]
    public string Postcode { get; set; }

    [Display(Name = "Start Date")]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; } = DateTime.UtcNow;
}
