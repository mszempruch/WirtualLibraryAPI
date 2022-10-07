using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WirtualLibrary.Models;
using WirtualLibrary.Services;
using Microsoft.EntityFrameworkCore;


namespace WirtualLibrary
{
    public class BookSeeder
    {
        private readonly BookDbContext _dbContext;

        public BookSeeder(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (_dbContext.Database.IsRelational())
                {
                    var pendingMigrations = _dbContext.Database.GetPendingMigrations();
                    if (pendingMigrations != null && pendingMigrations.Any())
                    {
                        _dbContext.Database.Migrate();
                    }
                }


                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.BookAuthors.Any())
                {
                    var booksAuthors = GetBooksAuthors();
                    _dbContext.BookAuthors.AddRange(booksAuthors);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },
                
                new Role()
                {
                    Name = "Admin"
                },
            };

            return roles;
        }
        private IEnumerable<BookAuthor> GetBooksAuthors()
        {

            var booksAuthors = new List<BookAuthor>()
            {
                new BookAuthor()
                {
                    Book = new Book()
                    {
                        Isbn = "123",
                        Title = "Chlopi",
                    },
                    Author = new Author()
                    {
                        FirstName = "Wladyslaw",
                        LastName = "Reymont",
                    }
                },
                new BookAuthor()
                {
                    Book = new Book()
                    {
                        Isbn = "1234",
                        Title = "Potop",
                    },
                    Author = new Author()
                    {
                        FirstName = "Henryk",
                        LastName = "Sienkiewicz",
                    }
                },
                new BookAuthor()
                {
                    Book = new Book()
                    {
                        Isbn = "12345",
                        Title = "Lalka",
                    },
                    Author = new Author()
                    {
                        FirstName = "Boleslaw",
                        LastName = "Prus",
                    }
                },
                new BookAuthor()
                {
                    Book = new Book()
                    {
                        Isbn = "123456",
                        Title = "Wesele",
                    },
                    Author = new Author()
                    {
                        FirstName = "Stanislaw",
                        LastName = "Wyspianski",
                    }
                },
                new BookAuthor()
                {
                    Book = new Book()
                    {
                        Isbn = "1234567",
                        Title = "Przedwiosnie",
                    },
                    Author = new Author()
                    {
                        FirstName = "Stefan",
                        LastName = "Zeromski",
                    }
                }
            };

            return booksAuthors;

        }
    }
    
}

