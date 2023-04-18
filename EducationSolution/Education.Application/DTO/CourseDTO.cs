namespace Education.Application.DTO
{
    public class CourseDTO
    {
        public Guid CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? PublishDate { get; set; }
        public Decimal Price { get; set; }
    }
}
