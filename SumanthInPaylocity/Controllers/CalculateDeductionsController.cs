using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using SIP.Entities;
using SIP.Business.Services;
using SumanthInPaylocity.Models;
using SIP.Entities.Enums;

namespace SumanthInPaylocity.Controllers
{
    public class CalculateDeductionsController : Controller
    {
        private readonly Lazy<IGetCalculations> _getCalculations;

        public CalculateDeductionsController(Lazy<IGetCalculations> getCalculations)
        {
            _getCalculations = getCalculations;
        }

        public ActionResult EmployeeEntry()
        {
            var employee = new EmployeeVM
            {
                Type = EntityTypes.Employee
            };

            return View(employee);
        }

        [HttpPost]
        public ActionResult EmployeeEntry(EmployeeVM model)
        {
            if (!ModelState.IsValid)
            {
                if(model.Dependents.Count > 0)
                {
                    var items = GetTypeListItems().ToList();
                    model.Dependents.ForEach(x => x.TypeList = items);
                }
                return View("EmployeeEntry", model);
            }

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeVM, Employee>();
                cfg.CreateMap<DependentVM, Dependent>();
                cfg.CreateMap<PersonVM, Person>();

            });
            var mapper = new Mapper(config);
            var entityBusinessModel = mapper.Map<Employee>(model);

            var service = _getCalculations.Value;

            var responseModel = new ResultsVM();
            //Employee deductions 
            responseModel.EmployeePayCheckDeductions = service.GetEmployeePayCheckDeductions(entityBusinessModel);
            responseModel.EmployeeYearlyDeductions = service.GetEmployeeYearlyDeductions(entityBusinessModel);
            responseModel.EmployeeFinalPayCheckDeductions = service.GetFinalPayCheckDeductions(responseModel.EmployeePayCheckDeductions, responseModel.EmployeeYearlyDeductions);

            //Dependents Deductions
            responseModel.DependentsPayCheckDeductions = service.GetDependentPayCheckDeductions(entityBusinessModel.Dependents);
            responseModel.DependentsYearlyDeductions = service.GetDependentYearlyPayCheckDeductions(entityBusinessModel.Dependents);
            responseModel.DependentsFinalPayCheckDeductions = service.GetFinalPayCheckDeductions(responseModel.DependentsPayCheckDeductions, responseModel.DependentsYearlyDeductions);

            //Total Deductions
            responseModel.TotalPayCheckDeductions = responseModel.EmployeePayCheckDeductions + responseModel.DependentsPayCheckDeductions;
            responseModel.TotalYearlyDeductions = responseModel.EmployeeYearlyDeductions + responseModel.DependentsYearlyDeductions;
            responseModel.TotalFinalPayCheckDeductions = responseModel.EmployeeFinalPayCheckDeductions + responseModel.DependentsFinalPayCheckDeductions;

            //Paycheck Details
            responseModel.DeductedPayCheck = service.GetPaycheckAfterDeductions(responseModel.TotalPayCheckDeductions);
            responseModel.DeductedFinalPayCheck = service.GetPaycheckAfterDeductions(responseModel.TotalFinalPayCheckDeductions);
            responseModel.DeductedYearlyPayCheck = service.GetYearlyPaycheckAfterDeductions(responseModel.TotalYearlyDeductions);



            return View("Results", responseModel);
        }

        public ActionResult AddNewDependent()
        {
            var dependent = new DependentVM();

            dependent.TypeList = GetTypeListItems().ToList();
            return PartialView("_Dependents", dependent);
        }

        private IEnumerable<SelectListItem> GetTypeListItems()
        {
            return from EntityTypes d in Enum.GetValues(typeof(EntityTypes))
                   where d != EntityTypes.Employee
                   select new SelectListItem
                   {
                       Text = d.ToString(),
                       Value = Convert.ToInt32(d).ToString()
                   };
        }
    }
}