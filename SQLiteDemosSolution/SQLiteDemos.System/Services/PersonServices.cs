using System;
using System.Collections.Generic;
using System.Text;

#region Additional Namespaces
using Microsoft.EntityFrameworkCore;
using SQLiteDemos.System.DAL;
using SQLiteDemos.System.Models;
#endregion

namespace SQLiteDemos.System.Services
{
    public class PersonServices
    {
        #region context connection and constructor setup
        private readonly AppDBContext _context;

        //the context connection will be supplied to this service class
        //  from the UI project
        //UI project indicates the datastore to use

        public PersonServices(AppDBContext contextConnection)
        {
            _context = contextConnection;
        }
        #endregion

        #region Queries
       
        //return all people ordered by Name
        public async Task<List<Person>> Person_GetAll()
        {
            //the return of the query is a collection : List<Person>
            return await _context.People
                                .OrderBy(x => x.Name)
                                .ToListAsync();
        }

        //return all people who do not need to pay into CPP (age > 65)
        public async Task<List<Person>> Person_GetAllOver65()
        {
            //the return of the query is a collection : List<Person>
            return await _context.People
                                .Where(x => x.Age > 65)
                                .OrderBy(x => x.Name)
                                .ToListAsync();
        }
        #endregion
    }
}
