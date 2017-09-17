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
using MBS.HR.Patterns.Security;

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
                EmployeeId =  3490,
                ImpleDate = DateTime.Now.AddDays(-3),

            };

            List<string> hashList = new List<string>();
            ModelSignManager security = new ModelSignManager();


            PerOrganSettingFactory defaultIssue =
                new DefaultImplementation(request);

            var stream = security.SerializeModelArray(defaultIssue);
            var md5_1 = security.CalculateMD5Hash(stream);
            hashList.Add(md5_1);

            IIssueProxy proxy = new ExportStepsToUI(defaultIssue);
            var step1 = proxy.ExecuteFirst(); // pass to UI
            // pass to UI
            var jsonStep1 = JsonConvert.SerializeObject(step1);
            
            // gather from UI
            var factory = PerOrganSettingFactory.LoadFromJson<DefaultImplementation>(jsonStep1);

            var stream2 = security.SerializeModelArray(factory);
            var md5_2 = security.CalculateMD5Hash(stream2);
            hashList.Add(md5_2);


            var change1 = security.HasModelChangedBySign(md5_1, md5_2);

            var empl = factory.InitialValue.EmployeeId;

            factory.InitialValue.ImpleDate = DateTime.Now;

            IIssueProxy proxy2 = new ExportStepsToUI(factory);


            var step2 = proxy2.ExecuteSecond(); // Gather from UI

            var jsonStep2 = JsonConvert.SerializeObject(step2);

            // gather from UI
            var factory2 = PerOrganSettingFactory.LoadFromJson<DefaultImplementation>(jsonStep2);


            var stream3 = security.SerializeModelArray(factory2);
            var md5_3 = security.CalculateMD5Hash(stream3);
            var change2 = security.HasModelChangedBySign(md5_2, md5_3);
            hashList.Add(md5_3);


            IIssueProxy proxy3 = new ExportStepsToUI(factory2);


            var step3 = proxy3.ExecuteThird(); // Gather form UI

            var jsonStep3 = JsonConvert.SerializeObject(step3);

            var factory3 = PerOrganSettingFactory.LoadFromJson<DefaultImplementation>(jsonStep3);

            var stream4 = security.SerializeModelArray(factory3);
            var md5_4 = security.CalculateMD5Hash(stream4);
            var change3 = security.HasModelChangedBySign(md5_3, md5_4);
            hashList.Add(md5_4);

            var tmp = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            hashList.ForEach(sec => {

                Console.WriteLine(sec);


            });

            Console.ForegroundColor = tmp;

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
