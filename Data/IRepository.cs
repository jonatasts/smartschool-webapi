using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using smartschool_webapi.Models;

namespace smartschool_webapi.Data
{
    public interface IRepository
    {
        //GENERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //Student
        Task<Student[]> GetAllStudentsAsync(bool includeTeacher);
        Task<Student[]> GetStudentsAsyncByDisciplineId(int disciplineId, bool includeDiscipline);
        Task<Student> GetStudentAsyncById(int studentId, bool includeTeacher);

        //Teacher
        Task<Teacher[]> GetAllTeachersAsync(bool includeStudent);
        Task<Teacher> GetTeacherAsyncById(int teacherId, bool includeStudent);
        Task<Teacher[]> GetTeachersAsyncByStudentId(int studentId, bool includeDiscipline);
    }
}