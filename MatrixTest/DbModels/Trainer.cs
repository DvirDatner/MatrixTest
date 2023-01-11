using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatrixTest
{
    public class Trainer
    {
        public int Id { get; set; }
        public int GuidId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public DateTime CreatedDate { get; set; }

        public Trainer() 
        {
            CreatedDate = DateTime.Now;
        }

        public Trainer (int id, int guidId, string email, string password, string fullName)
        {
            Id = id;
            GuidId = guidId;
            Email = email;
            Password = password;
            CreatedDate = DateTime.Now;
            FullName = fullName;
        }
    }
}