using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeloitteProject.Models
{
    public class UserUpload
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string filePath { get; set; }
        public UserUpload()
        {
            this.CreatedDate = DateTime.UtcNow;
        }
    }
}
