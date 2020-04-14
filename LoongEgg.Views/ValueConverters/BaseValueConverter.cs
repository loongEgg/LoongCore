using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

/* 
 | 个人微信：InnerGeeker
 | 联系邮箱：LoongEgg@163.com 
 | 创建时间：2020/4/14 20:07:32
 | 主要用途：
 | 更改记录：
 |			 时间		版本		更改
 */
namespace LoongEgg.Views
{
    // TODO: 20-3 一劳永逸的IValueConverter基类
    /// <summary>
    /// 值转换器的基类，是一个泛型方法，传入你要实现的值转换本身
    /// </summary>
    /// <typeparam name="T">你要的值转换器它本身类型</typeparam>
    public abstract class BaseValueConverter <T>
        : MarkupExtension, IValueConverter
        where T: class, new()
    {
        /*---------------------------------------- Fields ---------------------------------------*/
        /// <summary>
        /// 值转换器的实例
        /// </summary>
        private static T _Instance; 
          
        /*------------------------------------ Public Methods -----------------------------------*/
        /// <summary>
        /// 为了在Xaml中直接使用<see cref="IValueConverter"/>必须实现的一个方法<see cref="MarkupExtension.ProvideValue(IServiceProvider)"/>
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns>返回值转换器的单实例</returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
            => _Instance ?? (_Instance = new T());
            

        /// <summary>
        /// <see cref="IValueConverter.Convert(object, Type, object, CultureInfo)"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);
            

        /// <summary>
        /// 将前台UI中的值转换给后台ViewModel一般用不上
        /// </summary>
        /// <param name="value">UI中的值</param>
        /// <param name="targetType">目标类型</param>
        /// <param name="parameter">额外的转换参数</param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)  
            => throw new NotImplementedException();

       
    }
}
