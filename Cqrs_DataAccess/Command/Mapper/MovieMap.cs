using Cqrs_DTO;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cqrs_DataAccess.Command.Mapper
{
    public class MovieMap
    {
        public MovieMap(EntityTypeBuilder<Movie> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Title).IsRequired();
            entityBuilder.Property(t => t.ReleaseDate);
            entityBuilder.Property(t => t.Distributor);
            entityBuilder.Property(t => t.MajorGenre);
            entityBuilder.Property(t => t.Director);
            entityBuilder.Property(t => t.Rating);
            entityBuilder.Property(t => t.Votes);
        }
    }
}
