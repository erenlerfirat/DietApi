using Entity.Abstract;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Domain
{
    [Table("UserRole", Schema = "app")]
    public class UserRole : IEntity
    {
        public long Id { get; set; }
        public string RoleType { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
