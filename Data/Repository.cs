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
                query = query.Include(pe => pe.StudentsDisciplines)
                             .ThenInclude(ad => ad.Discipline)
                             .ThenInclude(d => d.Teacher);
            }

            query = query.AsNoTracking()
                         .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Student> GetStudentAsyncById(int studentId, bool includeDiscipline)
        {
            IQueryable<Student> query = _context.Students;

            if (includeDiscipline)
            {
                query = query.Include(a => a.StudentsDisciplines)
                             .ThenInclude(ad => ad.Discipline)
                             .ThenInclude(d => d.Teacher);
            }

            query = query.AsNoTracking()
                         .OrderBy(aluno => aluno.Id)
                         .Where(aluno => aluno.Id == studentId);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Student[]> GetStudentsAsyncByDisciplineId(int disciplineId, bool includeDiscipline)
        {
            IQueryable<Student> query = _context.Students;

            if (includeDiscipline)
            {
                query = query.Include(p => p.StudentsDisciplines)
                             .ThenInclude(ad => ad.Discipline)                             
                             .ThenInclude(d => d.Teacher);
            }

            query = query.AsNoTracking()
                         .OrderBy(aluno => aluno.Id)
                         .Where(aluno => aluno.StudentsDisciplines.Any(ad => ad.StudentId == disciplineId));

            return await query.ToArrayAsync();
        }

        public async Task<Teacher[]> GetTeachersAsyncByStudentId(int studentId, bool includeDiscipline)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeDiscipline)
            {
                query = query.Include(p => p.Disciplines);
            }

            query = query.AsNoTracking()
                         .OrderBy(aluno => aluno.Id)
                         .Where(aluno => aluno.Disciplines.Any(d => 
                            d.StudentsDisciplines.Any(ad => ad.StudentId == studentId)));

            return await query.ToArrayAsync();
        }

        public async Task<Teacher[]> GetAllTeachersAsync(bool includeDisciplines = true)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeDisciplines)
            {
                query = query.Include(c => c.Disciplines);
            }

            query = query.AsNoTracking()
                         .OrderBy(professor => professor.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Teacher> GetTeacherAsyncById(int teacherId, bool includeDisciplines = true)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeDisciplines)
            {
                query = query.Include(pe => pe.Disciplines);
            }

            query = query.AsNoTracking()
                         .OrderBy(professor => professor.Id)
                         .Where(professor => professor.Id == teacherId);

            return await query.FirstOrDefaultAsync();
        }
    }
}