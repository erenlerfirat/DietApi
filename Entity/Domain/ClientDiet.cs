using Entity.Abstract;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Domain
{
    [Table("ClientDiet", Schema = "app")]
    public class ClientDiet : IEntity
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public long DietId { get; set; }
        public long Description { get; set; }
        public short Progress { get; set; }
        public decimal StartWeight { get; set; }
        public decimal EndWeight { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
