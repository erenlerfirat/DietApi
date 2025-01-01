using Entity.Abstract;

namespace Entity.Dtos
{
    public class ClientAddRequest : IDto
    {
        public long UserId { get; set; }
        public string Gender { get; set; }
        public short Height { get; set; }
        public decimal Weight { get; set; }
        public short Age { get; set; }
    }
}
