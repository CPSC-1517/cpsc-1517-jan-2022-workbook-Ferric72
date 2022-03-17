#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using WestWindSystem.DAL;
using WestWindSystem.Entities;
#endregion

namespace WestWindSystem.BLL
{
    public class RegionServices
    {
        #region setup of the context connection variable and class constructor

        //variable to hold an instance of the context class
        private readonly WestWindContext _context;

        //constructor to create an instance of the registered context class
        internal RegionServices(WestWindContext regcontext)
        {
            _context = regcontext;
        }
        #endregion

        #region Queries
        //this query will have a parameter which will receive an argument value from
        //  the web page
        //this query will return a single instance of the entity Region (sql table Region)
        //  which matches the incoming argument value
        public Region Region_GetByID(int regionid)
        {
            Region info = _context.Regions
                            .Where(acollectionrow => acollectionrow.RegionID == regionid)
                            .FirstOrDefault();
            return info;
        }

        //get all the records of the sql Region table
        //return as a List<T>
        public List<Region> Region_List()
        {
            //Linq querys use two generic collection types
            //  IQueryable this is the data collection returned from sql
            //  IEnumberable this is the data collection in local memory
            //You can convert either of these collections to a List<T> using .ToList()
            IEnumerable<Region> info = _context.Regions
                                        .OrderBy(x => x.RegionDescription); //OrderByDescending for opposite order sort
            return info.ToList();
        }
        #endregion
    }
}
