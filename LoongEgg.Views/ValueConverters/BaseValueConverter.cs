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
    /// ValueConverter要继承这个基类
    /// </summary>
    /// <typeparam name="T">你要实现的ValueConverter类型本身</typeparam>
    public abstract  class BaseValueConverter<T> 
        : MarkupExtension, IValueConverter
        where T: class, new ()
    { 
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        /// <summary>
        /// 不重要
        /// </summary> 
        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) 
           => throw new NotImplementedException();

        private static T _Instance;

        public override object ProvideValue(IServiceProvider serviceProvider)
            => _Instance ?? (_Instance = new T());
    }
}
