using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models;
public class EmployeeModel
{
    public int Id { get; set; }
    public string PayrollNumber { get; set; }
    public string Forename { get; set; }
    public string Surname { get; set; }
    public DateTime BirthDate { get; set; }
    public string Phone { get; set; }
    public string CellPhone { get; set; }
    public string Email { get; set; }
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string Postcode { get; set; }
    public DateTime StartDate { get; set; } = DateTime.UtcNow;
}
