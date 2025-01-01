using Entity.Abstract;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Domain
{
    [Table("UserPasswordReset", Schema = "app")]
    public class UserPasswordReset : IEntity
    {
        public string Email { get; set; }
        public string ResetKey { get; set; }
        public DateTime Expire { get; set; }
        public bool IsDeleted { get; set; }
    }
}
