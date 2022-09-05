using Lms.Core.Entities;
using Lms.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Data.Repositories
{
    internal class CourseRepository : ICourseRepository
    {
        private readonly ICourseRepository _courseRepository;

        public void Add(Course course)
        {
            _courseRepository.Add(course);
        }

        public Task<bool> AnyAsync(int? id)
        {
            return _courseRepository.AnyAsync(id);
        }

        public Task<Course> FindAsync(int? id)
        {
            return _courseRepository.FindAsync(id);
        }

        public Task<IEnumerable<Course>> GetAllCourses()
        {
            return _courseRepository.GetAllCourses();
        }

        public Task<Course> GetCourse(int? id)
        {
            return _courseRepository.GetCourse(id);
        }

        public void Remove(Course course)
        {
            _courseRepository.Remove(course);
        }

        public void Update(Course course)
        {
            _courseRepository.Update(course);
        }
    }
}
