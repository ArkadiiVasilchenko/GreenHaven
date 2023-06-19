using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatingDate { get; set; }

        public string IdPost { get; set; }
        public Post Post { get; set; }

        public string IdUser { get; set; }
        public IdentityUser User { get; set; }

        public Comment() { }

        public Comment(string text, string idPost, string idUser)
        {
            Id = Guid.NewGuid().ToString();
            Text = text;
            CreatingDate = DateTime.Now;
            IdPost = idPost;
            IdUser = idUser;
        }
    }
}
