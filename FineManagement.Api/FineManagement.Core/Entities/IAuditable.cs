namespace FineManagement.Core.Entities
{
    public interface IAuditable
    {
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}
