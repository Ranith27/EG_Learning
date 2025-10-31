using StudentManagement.Models;
using StudentManagement.Repositories;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            var courses = await _unitOfWork.Courses.GetAllAsync();
            return courses ?? new List<Course>();
        }

        public async Task<Course?> GetCourseByIdAsync(int id)
        {
            return await _unitOfWork.Courses.GetByIdAsync(id);
        }

        public async Task<Course> CreateCourseAsync(Course course)
        {
            await _unitOfWork.Courses.AddAsync(course);
            await _unitOfWork.SaveAsync();
            return course;
        }

        public async Task<bool> UpdateCourseAsync(int id, Course course)
        {
            if (id != course.Id)
                return false;

            var existing = await _unitOfWork.Courses.GetByIdAsync(id);
            if (existing == null)
                return false;

            _unitOfWork.Courses.Update(course);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            var existing = await _unitOfWork.Courses.GetByIdAsync(id);
            if (existing == null)
                return false;

            _unitOfWork.Courses.Delete(existing);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}
