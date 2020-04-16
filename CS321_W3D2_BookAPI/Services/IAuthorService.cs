using CS321_W3D2_BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS321_W3D2_BookAPI.Services
{
    public interface IAuthorService
    {
        Author Add(Author addAuthor);
        Author Get(int Id);
        Author Update(Author updateAuthor);
        void Remove(Author removeAuthor);
        IEnumerable<Author> GetAll();
    }
}
