using ReTask.Artsofte.Common.Attributes;

namespace ReTask.Artsofte.Domain.Enums
{
    public enum Post
    {
        [StringValue("")]
        None,

        [StringValue("Стажёр")]
        Intern,

        [StringValue("Джуниор")]
        Junior,

        [StringValue("Мидл")]
        Middle,

        [StringValue("Синьор")]
        Senior,

        [StringValue("Лид")]
        Lead
    }
}
