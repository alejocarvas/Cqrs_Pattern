using Cqrs_DTO;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cqrs_DataAccess.Mapper
{
    public class UserMap
    {
        public UserMap(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Name).IsRequired();
            entityBuilder.Property(t => t.Age).IsRequired();
        }
    }
}
