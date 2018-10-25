using CqrsExample.Abstract;
using CqrsExample.Concrete;
using Domain.Abstract;
using Domain.Models;
using DapperRepo.Concrete;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.App_Start
{
#warning DI Container
    /**в зависимости от ссылки используются различные источники данных
     * using EfRepo.Concrete;
     * using DapperRepo.Concrete;
     * 
     */
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<ITemplateRepository<Department>>().To<DepartmentRepository>();
            Bind<ITemplateRepository<Employee>>().To<EmployeeRepository>();

            Bind<IQuery<Department>>().To<Query<Department>>();
            Bind<IQuery<Employee>>().To<Query<Employee>>();

            Bind<ICommand<Department>>().To<Command<Department>>();
            Bind<ICommand<Employee>>().To<Command<Employee>>();

        }
    }
}