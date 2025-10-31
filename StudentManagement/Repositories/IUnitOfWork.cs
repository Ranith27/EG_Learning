<<<<<<< HEAD
﻿using StudentManagement.Models;

namespace StudentManagement.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Student> Students { get; }
        IGenericRepository<Course> Courses { get; }
=======
﻿namespace StudentManagement.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository Students { get; }
>>>>>>> 3b849fae12456242c080b4470fccf4572f111ad9
        Task<int> SaveAsync();
    }
}
