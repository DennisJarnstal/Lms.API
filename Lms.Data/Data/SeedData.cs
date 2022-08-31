using Lms.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Data.Data
{
    public class SeedData
    {
        private static LmsAPIContext db = default!;
        public static async Task InitAsync(LmsAPIContext context, IServiceProvider services)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            db = context;

            ArgumentNullException.ThrowIfNull(nameof(services));

            if (db.Course.Any()) return;

            var courses = GetCourses();
            await db.AddRangeAsync(courses);

            var modules = GetModules();
            await db.AddRangeAsync(modules);
        }

        private static IEnumerable<Course> GetCourses()
        {
            throw new NotImplementedException();
        }

        private static IEnumerable<Module> GetModules()
        {
            throw new NotImplementedException();
        }
    }
}
