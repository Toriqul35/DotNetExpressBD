using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Design;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DotNetExpress.Model.Model
{
    public class Admin_Login
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Please enter your username")]
        public string User_Name { get; set; }


        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "Minimum 4 characters number")]
        [Required(ErrorMessage = "Please enter your password")]
        public string Pin { get; set; }
    }
}
