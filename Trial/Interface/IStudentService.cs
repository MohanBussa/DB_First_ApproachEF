using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trial.Service;
using Trial.Interface;

namespace Trial.Interface
{
    public interface IStudentService
    {
        List<Student> GetStudentList();
        Student AddOrEditStudent(Student student);
        Student DeleteStudent(Student student);
        Student GetByStudentId(int Id);
        List<Standard> GetStd();
        List<CountryCode> GetCountryCode();

    }
}