using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;

namespace ToDoEf.Models
{
    public class ToDoItems
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ToDoGroup Group { get; set; }
        public int  GroupId {get;set;}

    }
}
