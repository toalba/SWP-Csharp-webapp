using System.ComponentModel.DataAnnotations;

namespace HTL_yolov8.Models;

public class User
{
    [Key]
    public string email { get; set; }
    
    public string name { get; set; }
    public string password { get; set; }
}