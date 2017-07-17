using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBS.HR.Patterns.BusinessModel;

namespace MBS.HR.Patterns.PatternRepository.Singleton
{
    public static class LoadGlobalSetting
    {

        static GlobalSystemSetting _settings;
        static readonly object _lock = new object();
        /// <summary>
        /// بازآوری تمامی تنظمیات نیازمند راه ندازی اولیه نرم افزار
        /// </summary>
        public static void Renew()
        {
            _settings = null;
        }
        /// <summary>
        /// دریافت نمونه معتبر و ایمن از تنظیمات
        /// </summary>
        public static GlobalSystemSetting Instance
        {
            get
            {
                //a thread safe model
                lock (_lock)
                {
                    return _settings ?? (_settings = new GlobalSystemSetting());
                }
            }
        }

        private static readonly Lazy<GlobalSystemSetting> lazy = 
            new Lazy<GlobalSystemSetting>(() => new GlobalSystemSetting());
        /// <summary>
        /// دریافت نمونه معتبر و ایمن از تنظیمات - پشتیبانی در دات نت 4 به بعد
        /// </summary>
        public static GlobalSystemSetting Instance2
        {
            get { return lazy.Value; }
        }




    }
}
