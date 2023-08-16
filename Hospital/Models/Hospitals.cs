using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public enum Department
    {
        EMERGENCY,GENERAL,COVID
    }
    public class Hospitals
    {
        [Key]
        [Required(ErrorMessage ="Field is empty")]
        public  String name { get; set; }
        public String location { get; set; }
        [EnumDataType(typeof(Department))]  
        public Department department { get; set; }
        public String mainSpecialty { get; set; }
        public string roomName { get; set; }
        public DateOnly registeredDate { get; set; }
    }
}
