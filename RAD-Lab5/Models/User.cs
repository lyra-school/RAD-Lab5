using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RAD_Lab5.Models
{
    public enum Title
    {
        Mr,
        Mrs,
        Ms,
        Miss
    }
    public class User
    {
        [Key]
        public int UniqueIdentifier {get;set;}
        [MinLength(5)]
        public string FirstName { get; set; }
        [MinLength(4)]
        public string LastName { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Title Title { get; set; }
        [MinLength(100)]
        public string Biography { get; set; }
        [Column("user_age")]
        public int Age { get; set; }
    }
}
