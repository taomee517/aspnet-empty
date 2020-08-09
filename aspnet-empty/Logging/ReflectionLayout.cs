using System.IO;
using log4net.Core;
using log4net.Layout;
using log4net.Layout.Pattern;

namespace aspnet_empty.Logging
{
    public class ReflectionLayout :PatternLayout 
    { 
        public ReflectionLayout () 
        {  
            //添加Convert 
            this.AddConverter("property", typeof(ReflectionPatternConverter));
        } 
    }

    public class ReflectionPatternConverter : PatternLayoutConverter

    {
        protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
        {
            if (Option != null)
            {
                // 写入指定键的值
                WriteObject(writer, loggingEvent.Repository, LookupProperty(Option, loggingEvent));
            }
            else
            {
                // 写入所有关键值对
                WriteDictionary(writer, loggingEvent.Repository, loggingEvent.GetProperties());
            }
        }
        
        /// <summary>
        /// 通过反射获取传入的日志对象的某个属性的值
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>

        private object LookupProperty(string property,LoggingEvent loggingEvent)
        {
            object propertyValue = string.Empty;
            var propertyInfo = loggingEvent.MessageObject.GetType().GetProperty(property);
            if (propertyInfo != null)
            {
                propertyValue = propertyInfo.GetValue(loggingEvent.MessageObject, null);
            }
            return propertyValue;
        }

    }
}