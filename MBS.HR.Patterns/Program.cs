using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBS.HR.Patterns.BusinessLayer;
using MBS.HR.Patterns.BusinessModel;
using MBS.HR.Patterns.PatternRepository;
using MBS.HR.Patterns.PatternRepository.AbstractFactory;
using MBS.HR.Patterns.PatternRepository.Proxy;
using MBS.HR.Patterns.PatternRepository.Singleton;
using MBS.HR.Patterns.PatternRepository.Strategy;
using MBS.HR.Patterns.PatternRepository.Strategy.Implementations;
using Newtonsoft.Json;

namespace MBS.HR.Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var request = new IssueInitialModel
            {
                //اطلاعات نوع حکم و تاریخ و پرسنل و ...
                // اینجا پر می شود
                EmployeeId =  3490
            };

            PerOrganSettingFactory defaultIssue =
                new DefaultImplementation(Enums.Organ.Shared, request);


            IIssueProxy proxy = new ExportStepsToUI(defaultIssue);
            var step1 = proxy.ExecuteFirst(); // pass to UI
            // pass to UI
            var jsonStep1 = JsonConvert.SerializeObject(step1);
            // gather from UI



            var factory = PerOrganSettingFactory.LoadFromJson<DefaultImplementation>(jsonStep1);



            var empl = factory.InitialValue.EmployeeId;




            var step2 = proxy.ExecuteSecond(); // Gather from UI
            var step3 = proxy.ExecuteThird(); // Gather form UI

            var jsonStep2 = JsonConvert.SerializeObject(step2);
            var jsonStep3 = JsonConvert.SerializeObject(step3);


            Console.WriteLine();
            Console.WriteLine(jsonStep1);
            Console.WriteLine();
            Console.WriteLine(jsonStep2);
            Console.WriteLine();
            Console.WriteLine(jsonStep3);
            Console.ReadKey();


        }
    }
}
