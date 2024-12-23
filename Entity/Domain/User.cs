using Entity.Abstract;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Domain
{
    [Table("User",Schema ="app")]
    public class User : IEntity
    {
        public long Id { get; set; }
        public long UserRoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Phone { get; set; }
        public short FailedTryCount { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

    }
}
