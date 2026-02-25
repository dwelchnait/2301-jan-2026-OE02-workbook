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
    public class ProjectServices
    {
        #region context connection and constructor setup
        private readonly AppDBContext _context;

        //the context connection will be supplied to this service class
        //  from the UI project
        //UI project indicates the datastore to use

        public ProjectServices(AppDBContext contextConnection)
        {
            _context = contextConnection;
        }
        #endregion

        #region Queries

        //return all projects ordered by ProjectName
        public async Task<List<Project>> Project_GetAll()
        {
            //the return of the query is a collection : List<Project>
            return await _context.Projects
                                .OrderBy(x => x.ProjectName)
                                .ToListAsync();
        }
        #endregion
    }
}
