using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Trial.Service;
using Trial.Interface;

namespace Trial
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<IEmployeeService, EmployeeService>();
            container.RegisterType<IDepartmentService, DepartmentService>();
            container.RegisterType<IStudentService, StudentService>();
            container.RegisterType<IStandardService, StandardService>();
            container.RegisterType<ICountryCodeService, CountryCodeService>();

            container.RegisterType(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}