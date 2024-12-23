using Entity.Abstract;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Domain
{
    [Table("Diet", Schema = "app")]
    public class Diet : IEntity
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
