using ef_core_mastering.Context;
using Microsoft.EntityFrameworkCore;

namespace ef_core_mastering.DatedServices
{
    public static class service_practice_11032024
    {
        private static readonly SpeedrunsContext _context = new SpeedrunsContext();

        public static void trackings() 
        {
            //Difference between trackings:

            //returns readonly with dublicates
            //if two users has one country, both have different countries as a object 
            _context.Users
                .AsNoTracking()
                .Include(u => u.CountryId);

            //returns readonly
            //now this county is one object
            _context.Users
                .AsNoTrackingWithIdentityResolution()
                .Include(u => u.CountryId);
        }

        public static void groupings() 
        {
            //use nullable variables with aggregate ops:
            _context.Runs
                .AsNoTrackingWithIdentityResolution()
                .Max(r => (int?)r.Id);
        }



    }
}
