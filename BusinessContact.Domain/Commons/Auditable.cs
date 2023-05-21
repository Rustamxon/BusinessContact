namespace BusinessContact.Domain.Commons
{
    public class Auditable
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastUpdatedAt { get; set; }
        public long DeletedBy { get; set; }
        public long UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
