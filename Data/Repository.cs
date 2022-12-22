using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using smartschool_webapi.Models;

namespace smartschool_webapi.Data
{
    public class Repository : IRepository
    {
        private readonly SmartSchoolContext _context;

        public Repository(SmartSchoolContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Student[]> GetAllStudentsAsync(bool includeDiscipline = false)
        {
            IQueryable<Student> query = _context.Students;

            if (includeDiscipline)
            {
                query = query.Include(student => student.StudentsDisciplines)
                             .ThenInclude(studentsDisciplines => studentsDisciplines.Discipline)
                             .ThenInclude(discipline => discipline.Teacher);
            }

            query = query.AsNoTracking()
                         .OrderBy(student => student.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Student> GetStudentAsyncById(int studentId, bool includeDiscipline)
        {
            IQueryable<Student> query = _context.Students;

            if (includeDiscipline)
            {
                query = query.Include(student => student.StudentsDisciplines)
                             .ThenInclude(studentsDisciplines => studentsDisciplines.Discipline)
                             .ThenInclude(discipline => discipline.Teacher);
            }

            query = query.AsNoTracking()
                         .OrderBy(student => student.Id)
                         .Where(student => student.Id == studentId);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Student[]> GetStudentsAsyncByDisciplineId(int disciplineId, bool includeDiscipline)
        {
            IQueryable<Student> query = _context.Students;

            if (includeDiscipline)
            {
                query = query.Include(student => student.StudentsDisciplines)
                             .ThenInclude(studentsDisciplines => studentsDisciplines.Discipline)
                             .ThenInclude(discipline => discipline.Teacher);
            }

            query = query.AsNoTracking()
                         .OrderBy(student => student.Id)
                         .Where(student => student.StudentsDisciplines.Any(studentsDisciplines => studentsDisciplines.StudentId == disciplineId));

            return await query.ToArrayAsync();
        }

        public async Task<Teacher[]> GetTeachersAsyncByStudentId(int studentId, bool includeDisciplines = true)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeDisciplines)
            {
                query = query.Include(teacher => teacher.Disciplines);
            }

            query = query.AsNoTracking()
                         .OrderBy(teacher => teacher.Id)
                         .Where(teacher => teacher.Disciplines.Any(discipline =>
                            discipline.StudentsDisciplines.Any(discipline => discipline.StudentId == studentId)));

            return await query.ToArrayAsync();
        }

        public async Task<Teacher[]> GetAllTeachersAsync(bool includeDisciplines = true)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeDisciplines)
            {
                query = query.Include(teacher => teacher.Disciplines);
            }

            query = query.AsNoTracking()
                         .OrderBy(teacher => teacher.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Teacher> GetTeacherAsyncById(int teacherId, bool includeDisciplines = true)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeDisciplines)
            {
                query = query.Include(teacher => teacher.Disciplines);
            }

            query = query.AsNoTracking()
                         .OrderBy(teacher => teacher.Id)
                         .Where(teacher => teacher.Id == teacherId);

            return await query.FirstOrDefaultAsync();
        }
    }
}