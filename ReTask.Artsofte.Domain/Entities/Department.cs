using System.Collections.Generic;

namespace ReTask.Artsofte.Domain.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }
        public ICollection<Employee> Employees { get; set; }

        public Department()
        {
            Employees = new List<Employee>();
        }
    }
}
