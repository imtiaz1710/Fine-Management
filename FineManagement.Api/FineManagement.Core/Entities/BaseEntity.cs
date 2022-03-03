namespace FineManagement.Core.Entities
{
    public abstract class BaseEntity<TKey> : IAuditable
    {
        public TKey Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }

    }
}
