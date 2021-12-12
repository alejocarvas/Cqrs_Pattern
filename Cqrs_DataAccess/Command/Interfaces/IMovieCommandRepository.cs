using Cqrs_DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cqrs_DataAccess.Command.Interfaces
{
    public interface IMovieCommandRepository
    {
        Movie GetById(long id);
        void Save(Movie movie);
        void Update(Movie movie);
        void Delete(long id);
    }
}
