using Entity.Abstract;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Domain
{
    [Table("Client", Schema = "app")]
    public class Client : IEntity
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long UserRoleId { get; set; }
        public string Gender { get; set; }
        public short Height { get; set; }
        public decimal Weight { get; set; }
        public short Age { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
