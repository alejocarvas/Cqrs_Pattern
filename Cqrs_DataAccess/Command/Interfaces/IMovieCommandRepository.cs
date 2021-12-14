using Cqrs_DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cqrs_DataAccess.Command.Interfaces
{
    public interface IMovieCommandRepository
    {
        Task<int> Save(Movie movie);
        void Save(MovieClick movieclick);
        void Update(Movie movie);
        void Delete(long id);
    }
}
