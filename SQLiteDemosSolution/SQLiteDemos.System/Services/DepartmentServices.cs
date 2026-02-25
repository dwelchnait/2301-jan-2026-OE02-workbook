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
    public class DepartmentServices
    {
        #region context connection and constructor setup
        private readonly AppDBContext _context;

        //the context connection will be supplied to this service class
        //  from the UI project
        //UI project indicates the datastore to use

        public DepartmentServices(AppDBContext contextConnection)
        {
            _context = contextConnection;
        }
        #endregion

        #region Queries
        /* ******************** Modern Industry Standard using async and await ***********************/

        //Modern EF Core is async-first
        //Most examples in Microsoft docs use async now.

        //Consistency

        //If your service layer ever moves to:
        //  ASP.NET Core
        //  Blazor
        //  Background services
        //  APIs
        //Then async is already in place.

        //Industry Reality(2026)
        //Web/API apps:  Async everywhere

        //Rule of Thumb

        //If your method touches the database:
        //   Prefer async
        //   ReturnDataType Task/Task<T>
        //   Use await SaveChangesAsync() and queries

        //It future-proofs your architecture.
        //That’s clean and industry-standard.

        /* ***************** You are already thinking at a professional architecture level. *********** */

        //return all departments ordered by department name
        //A queries is a service
        //A service is a method
        public async Task<List<Department>> Department_GetAll()
        {
            //the return of the query is a collection : List<Department>
            return await _context.Departments
                                .OrderBy(d => d.DepartmentName)
                                .ToListAsync();
        }
        #endregion
    }
}
