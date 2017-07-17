using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBS.HR.Patterns.BusinessModel;
using MBS.HR.Patterns.PatternRepository.AbstractFactory.Interfaces;
using MBS.HR.Patterns.PatternRepository.Strategy;
using Newtonsoft.Json;

namespace MBS.HR.Patterns.PatternRepository.AbstractFactory
{
    public abstract class PerOrganSettingFactory: IStep1, IStep2, IStep3
    {
        #region fields

        private GlobalSystemSetting _setting;
        private Enums.Organ organ;
        private IssueInitialModel _init;
        private bool allowReInit = false;
        private LastIssueViewModel _lastIssue;
        private CheckHasPermissionViewModel _permission;
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
            get { return _init; }
            private set { _init = value; }
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



        #endregion

        /// <summary>
        /// لود کردن تنظمیات سازمان به صورت داخل آبجکت
        /// </summary>
        private PerOrganSettingFactory()
        {
            _setting = Singleton.LoadGlobalSetting.Instance;
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
        protected PerOrganSettingFactory(Enums.Organ org, IssueInitialModel init) :this()//this(org)
        {
            organ = org;
            Init(init);
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
            if (_init != null && allowReInit==false)
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





        #region statics

        public static TResult LoadFromJson<TResult>(string json) 
            where TResult : PerOrganSettingFactory
        {
            var setting = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented,
                MaxDepth = 50
            };


            var factory = JsonConvert
                .DeserializeObject<TResult>(json, setting);

            return factory;
        }


        #endregion

    }
}
