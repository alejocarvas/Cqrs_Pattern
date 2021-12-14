using Cqrs_DTO;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cqrs_DataAccess.Mapper
{
    public class MovieClickMap
    {
        public MovieClickMap(EntityTypeBuilder<MovieClick> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.IdMovie).IsRequired();
            entityBuilder.Property(t => t.IdUser).IsRequired();
            entityBuilder.Property(t => t.DateClick).IsRequired();
        }
    }
}
