using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RAD_Lab5.Models
{
    public class FluentUser
    {
        public int UniqueIdentifier {get;set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Title Title { get; set; }
        public string Biography { get; set; }
        public int Age { get; set; }
    }
}
