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
                .Include(c => c.CountryId);

            //returns readonly
            //now this county is one object
            _context.Users
                .AsNoTrackingWithIdentityResolution()
                .Include(c => c.CountryId);
        }


    }
}
