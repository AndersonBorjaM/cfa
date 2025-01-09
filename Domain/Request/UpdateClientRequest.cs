namespace Domain.Request
{
    public class UpdateClientRequest
    {
        public string DocumentType { get; set; }
        public long Document { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
