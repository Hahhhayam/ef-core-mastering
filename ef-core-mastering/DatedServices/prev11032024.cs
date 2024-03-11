using ef_core_mastering.Context;
using ef_core_mastering.DTOs;
using ef_core_mastering.Models;
using Microsoft.EntityFrameworkCore;

namespace ef_core_mastering.DatedServices
{
    internal class prev11032024
    {
        public void CreateMany<T>(T[] entities) where T : class
        {
            using SpeedrunsContext connection = new();
            foreach (T entity in entities)
            {
                connection.Set<T>().Add(entity);
            }
            connection.SaveChanges();
        }

        public IList<T> GetAll<T>() where T : class
        {
            using SpeedrunsContext connection = new();
            return connection.Set<T>().AsNoTracking().ToList();
        }

        public IList<ProfileDTO> GetProfiles()
        {
            using SpeedrunsContext connection = new();
            return connection.Users
                .Include(u => u.Country)
                .Select(user => new ProfileDTO
                {
                    Nickname = user.Nickname,
                    CountyName = user.Country.Name,
                    Flag = user.Country.Flag,
                })
                .OrderBy(p => p.Nickname)
                .ToList();
        }

        public IList<ProfileDTO> Va()
        {
            IQueryable<User> orderQuery = IQueryable<User>.
        }
    }
}
