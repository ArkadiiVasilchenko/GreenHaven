using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreatingDate { get; set; }

        public string IdUser { get; set; }
        public IdentityUser User { get; set; }

        public Post(){}

        public Post(string title, string text, string idUser)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
            Text = text;
            CreatingDate = DateTime.Now;
            IdUser = idUser;
        }
    }
}
