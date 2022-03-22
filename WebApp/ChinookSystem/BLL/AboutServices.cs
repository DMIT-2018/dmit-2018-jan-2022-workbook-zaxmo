#nullable disable
using ChinookSystem.DAL;
using ChinookSystem.Entities;
using ChinookSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookSystem.BLL
{
    public class AboutServices
    {
        //this class needs to be accessed by an "outside user" (WebApp)
        //therefore the class needs to be public

        #region Constructor and Context Dependency
        private readonly Chinook2018Context _context;

        //obtain the context link from IServiceCollection when this set of servicesis injected into the "Outside user"

        internal AboutServices(Chinook2018Context context)
        {
            _context = context;
        }
        #endregion

        #region Services
        //services are methods
        //query to obtain the DbVersion

        public DbVersionInfo GetDbVersion()
        {
            //DbVersionInfo is a public view of the data defined in a class
            //DbVersionInfo can be a class used BOTH internally and by external users
            //DbVersion is an internal entity description used ONLY in the library
            DbVersionInfo info = _context.DbVersions
                .Select(x => new DbVersionInfo
                {
                    Major = x.Major,
                    Minor = x.Minor,
                    Build = x.Build,
                    ReleaseDate = x.ReleaseDate
                })
                .SingleOrDefault();
            return info;
        }
        #endregion
    }
}
