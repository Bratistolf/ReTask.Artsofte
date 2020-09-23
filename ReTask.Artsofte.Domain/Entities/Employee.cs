using ReTask.Artsofte.Domain.Enums;

namespace ReTask.Artsofte.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Age { get; set; }
        public Gender Gender { get; set; }
        public Post Post { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public int? LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
