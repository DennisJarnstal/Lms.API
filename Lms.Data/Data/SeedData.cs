using Bogus;
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
        public static LmsAPIContext db = default!;
        private static IEnumerable<Module> modules;
        private static IEnumerable<Course> courses;

        public static async Task InitAsync(LmsAPIContext context, IServiceProvider services)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            db = context;

            ArgumentNullException.ThrowIfNull(nameof(services));

            if (db.Course.Any()) return;

            modules = GetModules();
            courses = GetCourses();
            await db.AddRangeAsync(courses);

            ////await db.AddRangeAsync(modules);

            await db.SaveChangesAsync();
        }

        public static IEnumerable<Module> GetModules()
        {
            var faker = new Faker("sv");
            var modules = new List<Module>();
            Random rnd = new Random();

            for (int i = 0; i < 50; i++)
            {
                var temp = new Module
                {
                    Title = faker.Finance.AccountName(),
                    StartDate = DateTime.Now.AddDays(faker.Random.Int(-10, 15))
                };
                modules.Add(temp);
            }
            return modules;
        }
        public static IEnumerable<Course> GetCourses()
        {
            var faker = new Faker("sv");
            var courses = new List<Course>();
            Random rnd = new Random();

            for (int i = 0; i < 30; i++)
            {
                var temp = new Course
                {
                    Title = faker.Commerce.ProductName(),
                    StartDate = DateTime.Now.AddDays(faker.Random.Int(-10, 15)),
                    Modules = modules.OrderBy(x => rnd.Next()).Take(5).ToList()
                };
                courses.Add(temp);
            }
            return courses;
        }
    }
}
