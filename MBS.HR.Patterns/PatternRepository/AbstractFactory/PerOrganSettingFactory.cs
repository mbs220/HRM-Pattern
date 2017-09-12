using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBS.HR.Patterns.BusinessModel;
using MBS.HR.Patterns.PatternRepository.AbstractFactory.Interfaces;
using MBS.HR.Patterns.PatternRepository.Strategy;
using Newtonsoft.Json;

using MBS.HR.Patterns.JsonConfig;

namespace MBS.HR.Patterns.PatternRepository.AbstractFactory
{
    public abstract class PerOrganSettingFactory : IStep1, IStep2, IStep3
    {
        #region fields

        private GlobalSystemSetting _setting;
        private Enums.Organ organ;
        private Enums.IssueDateState issueDateState = Enums.IssueDateState.Normal;
        private Enums.IssueType issueType = Enums.IssueType.Normal;
        private IssueInitialModel _init;
        private bool allowReInit = false;
        private LastIssueViewModel _lastIssue;
        private CheckHasPermissionViewModel _permission;
        private List<WageFactorItem> _wages = new  List<WageFactorItem>();
        private List<OutputFactorItem> _outputs = new List<OutputFactorItem>();
        #endregion

        #region Property
        /// <summary>
        /// سازمان
        /// </summary>
        [JsonProperty]
        protected Enums.Organ Organ
        {
            get { return organ; }
            private set { organ = value; }
        }
        /// <summary>
        /// مقدار دهی اولیه لازم جهت صدور حکم
        /// </summary>
        [JsonProperty]
        public IssueInitialModel InitialValue
        {
            get
            {
                return _init;
            }
            private set
            {
                _init = value;
            }
        }
        /// <summary>
        /// تنظیمات اولیه نرم افزار
        /// </summary>
        [JsonProperty]
        protected GlobalSystemSetting Setting
        {
            get { return _setting; }
            private set { _setting = value; }
        }
        /// <summary>
        /// آخرین حکم
        /// </summary>
        [JsonProperty]
        public LastIssueViewModel LastIssue
        {
            get { return _lastIssue; }
            private set { _lastIssue = value; }

        }
        /// <summary>
        /// مجوز صدور
        /// </summary>
        [JsonProperty]
        public CheckHasPermissionViewModel Permission
        {
            get { return _permission; }
            private set { _permission = value; }

        }
        /// <summary>
        /// وضعیت حکم از نظر تاریخ = معوق/عادی
        /// </summary>
        [JsonProperty]
        public Enums.IssueDateState IssueDateState
        {
            get
            {
                return issueDateState;
            }

            private set
            {
                issueDateState = value;
            }
        }


        /// <summary>
        /// وضعیت حکم از نظر نوع = اصلاحیه/لغو/عادی
        /// </summary>
        [JsonProperty]
        public Enums.IssueType IssueType
        {
            get
            {
                return issueType;
            }

            private set
            {
                issueType = value;
            }
        }

        /// <summary>
        /// لسیت آیتم های حقوقی حکم جدید و در حال صدور
        /// </summary>
        [JsonProperty]
        public List<WageFactorItem> Wages {
            get { return _wages; }
        }


        /// <summary>
        /// لسیت آیتم های کارکردی حکم جدید و در حال صدور
        /// </summary>
        [JsonProperty]
        public List<OutputFactorItem> Outputs
        {
            get { return _outputs; }
        }



        #endregion


        #region Event

        public delegate FormulaResponse CommunicateWithFormula(FormulaRequest request);
        /// <summary>
        /// مراجعه به تابع فرمول ها هنگام محاسبه آیتم ها
        /// </summary>
        public event CommunicateWithFormula onCommunicateWithFormula;


        public delegate void AfterCreateIssue(IssueViewModel issue);
        /// <summary>
        /// فراخوانی متد هنگام ایجاد شدن حکم
        /// </summary>
        public event AfterCreateIssue onIssueCreated;

        #endregion

        #region EventWrapper
        FormulaResponse InvokeCommunicateWithFormula(FormulaRequest request)
        {
            return onCommunicateWithFormula?.Invoke(request);
        }

        void InvokeAfterCreateIssue(IssueViewModel issue)
        {
            onIssueCreated?.Invoke(issue);
        }

        #endregion

        /// <summary>
        /// لود کردن تنظمیات سازمان به صورت داخل آبجکت
        /// </summary>
        private PerOrganSettingFactory()
        {
            _setting = Singleton.LoadGlobalSetting.Instance;
        }

        /// <summary>
        /// متد تشخیص اینکه حکم معوق است یا نه
        /// </summary>
        /// <returns>وضعیت</returns>
        public virtual Enums.IssueDateState DetectIssueDateState()
        {
            var impl = InitialValue.ImpleDate.Date;//تاریخ صدور
            var now = DateTime.Now.Date; // تاریخ اکنون

            if (now > impl)
            {
                return Enums.IssueDateState.Postponement;
            }

            return Enums.IssueDateState.Normal;
        }

        ///// <summary>
        ///// ایجاد آبجکت صادر کننده حکم
        ///// </summary>
        ///// <param name="org"></param>
        //protected PerOrganSettingFactory(Enums.Organ org):this()
        //{
        //    organ = org;
        //    _init = null;
        //    Console.WriteLine(nameof(PerOrganSettingFactory));
        //    Console.WriteLine(Organ);
        //}
        /// <summary>
        /// ایجاد آبجکت صادر کننده حکم
        /// </summary>
        /// <param name="org"></param>
        /// <param name="init"></param>
        [JsonConstructor]
        protected PerOrganSettingFactory(Enums.Organ org,
            IssueInitialModel init) : this()//this(org)
        {
            organ = org;
            Init(init);

            //یافتن وضعیت حکم از نظر تاریخ اجرا
            IssueDateState = DetectIssueDateState();
            //نوع حکم از نظر ماهیت آن
            IssueType = init.IssueType;

            Console.WriteLine(nameof(PerOrganSettingFactory));
            Console.WriteLine(Organ);
            Console.WriteLine(init);
        }

        /// <summary>
        /// مقدار دهی اولیه بابت صدور حکم
        /// </summary>
        /// <param name="init"></param>
        public virtual void Init(IssueInitialModel init)
        {
            if (_init != null && allowReInit == false)
            {
                throw new Exception("قبلا این آبجکت شکل گرفته است");
            }
            _init = init;
        }
        /// <summary>
        /// پیدا کردن حکم آخر
        /// </summary>
        /// <param name="strategy">استراتژی یافتن حکم آخر</param>
        /// <returns>حکم آخر</returns>
        public virtual LastIssueViewModel FindLastIssue(IFindLastIssueStrategy strategy)
        {
            return _lastIssue = strategy.FindLastIssue(this);
        }
        /// <summary>
        /// بررسی مجوز صدور حکم
        /// </summary>
        /// <param name="strategy"></param>
        /// <returns></returns>
        public virtual CheckHasPermissionViewModel HasPermission
            (ICheckHasPermissionStrategy strategy)
        {
            return _permission = strategy.CheckPermission(this);
        }

        /// <summary>
        /// فراخوانی محاسبه هر آیتم کارکردی
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual OutputFactorItem CalculateOutputFactorItem(OutputFactorItem item)
        {
            return item;
        }

        /// <summary>
        /// فراخوانی محاسبه هر آیتم حقوقی
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual WageFactorItem CalculateWageFactorItem(WageFactorItem item)
        {
            return item;
        }


        /// <summary>
        /// محاسبه آیتم های حقوقی
        /// </summary>
        public void CalculateWges()
        {

        }

        /// <summary>
        /// محاسبه آیتم های کارکردی
        /// </summary>
        public void CalculateOutputs()
        {

        }

        #region statics

        public static TResult LoadFromJson<TResult>(string json)
            where TResult : PerOrganSettingFactory
        {
            //میتوان فرایند کار با json را 
            // با رمزنگاری ترکیب کرد تا امنیت ارتقاء یابد
            var setting = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented,
                MaxDepth = 50,
                //ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
                //PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            };

            setting.Converters.Add(new PerOrganSettingFactoryJsonConverter());

            var factory = JsonConvert
                .DeserializeObject<TResult>(json, setting);

            return factory;
        }


        #endregion

    }
}
