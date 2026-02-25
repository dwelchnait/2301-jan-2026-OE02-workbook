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


        #region Manipluate Data (Add, Update, Delete services)

        //Add a department to the database
        //you could pass in each pieces of data as a separate parameter
        //you could pass in an instance of the class as the parameter
        //Task is used when nothing is returned
        public async Task Department_Add(Department department)
        {
            //Guard Rail
            //ensures that you have data to use with
            //basically validate that you have data to use
            ArgumentNullException.ThrowIfNull(department, nameof(department));

            //Stage the add
            //remember this is done in memory and NOT to the database
            //  therefore this does NOT need to use await/async
            //  BUT there exists Async staging command if you wish to use them
            _context.Departments.Add(department);
            //could also stage using the following
            //await _context.Departments.AddAsync(department);

            //Commit to database
            //this will touch the database
            //this will use await/async
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
