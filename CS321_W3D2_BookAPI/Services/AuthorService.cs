using CS321_W3D2_BookAPI.Data;
using CS321_W3D2_BookAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS321_W3D2_BookAPI.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly BookContext _bookContext;
        public AuthorService(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public Author Add(Author addAuthor)
        {
            _bookContext.Authors.Add(addAuthor);
            _bookContext.SaveChanges();
            return addAuthor;
        }

        public Author Get(int Id)
        {
            Author author = _bookContext.Authors
                .Include(x=>x.Books)
                .FirstOrDefault(x => x.Id == Id);

            if (author != null)
            {
                return author;
            }
            throw new Exception("Author Not Found");
        }

        public IEnumerable<Author> GetAll()
        {
            return _bookContext.Authors
                .Include(x=>x.Books)
                .ToList();
        }

        public void Remove(Author removeAuthor)
        {
            _bookContext.Remove(removeAuthor);
        }

        public Author Update(Author updateAuthor)
        {
            Author author = this.Get(updateAuthor.Id);
            if (author != null)
            {
                _bookContext.Entry(author)
                    .CurrentValues
                    .SetValues(updateAuthor);
                _bookContext.Authors.Update(author);
                _bookContext.SaveChanges();
                return author;
            }
            throw new Exception("Cannot update Author!");
        }
    }
}
