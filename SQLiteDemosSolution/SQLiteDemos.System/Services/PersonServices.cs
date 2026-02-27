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

        #region Manipluate Data (Add, Update, Delete services)

        //Add a person to the database
        //you could pass in each pieces of data as a separate parameter
        //you could pass in an instance of the class as the parameter
        //Task is used when nothing is returned
        public async Task Person_Add(Person person)
        {
            //Guard Rail
            ArgumentNullException.ThrowIfNull(person, nameof(person));

            //Stage the add
            _context.People.Add(person);

            //Commit to database
            await _context.SaveChangesAsync();
        }

        public async Task AssignPersonToProject(int personId, List<string> projectCodes)
        {
            //get the projects for current person
            var person = await _context.People
                .Include(p => p.Projects) // load existing M:M links
                .SingleOrDefaultAsync(p => p.Id == personId);

            //does the person exist??
            if (person == null)
                throw new ArgumentException("Person not found.");

            //get the projects that match your parameter projectCodes (projects being added to)
            var projects = await _context.Projects
                                    .Where(p => projectCodes.Contains(p.Code)).ToListAsync();

            foreach (var project in projects)
            {
                //check if the person is already attached to project
                //  if not add person to project
                //no validation of entities is needed as they alreay exists (thus valid)
                //  only creating a link on database between two instances
                if (!person.Projects.Contains(project))
                    person.Projects.Add(project);
            }

            await _context.SaveChangesAsync();
        }

        public async Task Person_RemovePersonFromProjectAsync(int personId, int projectId)
        {


            var project = await _context.Projects
                .Include(p => p.People)
                .FirstOrDefaultAsync(p => p.Id == projectId);

            if (project == null)
                throw new KeyNotFoundException("Project not found.");

            var person = project.People
                .FirstOrDefault(p => p.Id == personId);

            if (person == null)
                throw new KeyNotFoundException("Person not assigned to this project.");


            //EF will:

            //Remove the row from the hidden join table
            //Leave Person intact
            //Leave Project intact

            _context.People.Remove(person);

            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
