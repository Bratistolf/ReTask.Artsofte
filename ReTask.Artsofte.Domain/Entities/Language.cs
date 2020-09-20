using System.Collections.Generic;

namespace ReTask.Artsofte.Domain.Entities
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; private set; }

        public Language()
        {
            Employees = new List<Employee>();
        }
    }
}
