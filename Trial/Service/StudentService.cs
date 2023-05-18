using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trial.Interface;

namespace Trial.Service
{

    public class StudentService : IStudentService
    {
        private IGenericRepository<Student> managementEntities;
        private IGenericRepository<Standard> entities;
        private IGenericRepository<CountryCode> contryEntities;
        public StudentService(IGenericRepository<Student> managementEntities, IGenericRepository<Standard> entities,IGenericRepository<CountryCode> contryEntities)
        {
            this.managementEntities = managementEntities;
            this.entities = entities;
            this.contryEntities = contryEntities;
        }
        public List<Student> GetStudentList()
        {
            List<Standard> standardList = new List<Standard>();
            var standards = entities.GetAllList();

            List<CountryCode> countryCodeList = new List<CountryCode>();
            var countrycodes = contryEntities.GetAllList();
            List<Student> studentlist = new List<Student>();
            var student = managementEntities.GetAllList();

            foreach (var std in student)
            {
                Standard dp = standards.FirstOrDefault(p => p.Id == std.StandardId);
                CountryCode countryCode = countrycodes.FirstOrDefault(x => x.Id == std.CountryCodeId);
                Student students = new Student();
                students.Id = std.Id;
                students.Name = std.Name;
                students.Age = std.Age;
                students.DateOfBirth = std.DateOfBirth;
                students.Email = std.Email;
                students.Gender = std.Gender;
                students.MobileNo = std.MobileNo;
                students.CountryCodeId = std.CountryCodeId;
                students.StandardName = dp.Name;
                studentlist.Add(students);
            }
            return studentlist;
        }
        public List<Standard> GetStd()
        {
            List<Standard> standardlist = new List<Standard>();
            var standard = entities.GetAllList();
            foreach (var std in standard)
            {
                if (std.IsActive == true)
                {
                    standardlist.Add(std);
                }
            }
            return standardlist;
        }

        public List<CountryCode> GetCountryCode()
        {
            List<CountryCode> codeList = new List<CountryCode>();
            var countryCodes = contryEntities.GetAllList();
            foreach (var country in countryCodes)
            {
                if (country.IsActive == true)
                {
                    codeList.Add(country);
                }
            }
            return codeList;
        }
        public Student AddOrEditStudent(Student student)
        {
            var country = contryEntities.GetById(student.CountryCodeId);
            var std = managementEntities.GetById(student.Id);
            if (std == null)
            {
                Student students = new Student();
                students.Name = student.Name;
                students.Age = student.Age;
                students.DateOfBirth = student.DateOfBirth;
                students.Email = student.Email;
                students.Gender = student.Gender;
                students.MobileNo =country.Code + student.MobileNo;
                students.StandardId = student.StandardId;
                students.CountryCodeId = student.CountryCodeId;
                managementEntities.Insert(students);
                managementEntities.Save();
                return student;
            }
            else
            {
                std.Name = student.Name;
                std.Age = student.Age;
                std.DateOfBirth = student.DateOfBirth;
                std.Email = student.Email;
                std.Gender = student.Gender;
                std.MobileNo = country.Code+student.MobileNo;
                std.StandardId = student.StandardId;
                std.CountryCodeId = student.CountryCodeId;
                managementEntities.Save();
                return student;
            }
        }
        public Student DeleteStudent(Student student)
        {
            if (student != null)
            {

                managementEntities.Delete(student.Id);
                managementEntities.Save();
                return student;
            }
            return student;
        }
        public Student GetByStudentId(int id)
        {
            Student stud = new Student();
            Student data = managementEntities.GetById(id);
            if (data != null)
            {
                stud.Id = data.Id;
                stud.Name = data.Name;
                stud.Age = data.Age;
                stud.DateOfBirth = data.DateOfBirth;
                stud.Email = data.Email;
                stud.Gender = data.Gender;
                stud.MobileNo = data.MobileNo;
                stud.StandardId = data.StandardId;
                stud.CountryCodeId = data.CountryCodeId;
            }
            return stud;
        }
    }
}
