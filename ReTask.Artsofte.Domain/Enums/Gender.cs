using ReTask.Artsofte.Common.Attributes;

namespace ReTask.Artsofte.Domain.Enums
{
    public enum Gender
    {
        [StringValue("")]
        None, 

        [StringValue("Мужской")]
        Male, 

        [StringValue("Женский")]
        Female
    }
}
