using System.Data.Linq.Mapping;

namespace ADO_NET_26
{
    [Table(Name = "Users")]
    public class User
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        [Column(Name = "Name")]
        public string FirstName { get; set; }
        [Column]
        public int Age { get; set; }
    }
}
