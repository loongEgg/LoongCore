using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

/* 
 | 个人微信：InnerGeeker
 | 联系邮箱：LoongEgg@163.com 
 | 创建时间：2020/4/14 19:51:26
 | 主要用途：
 | 更改记录：
 |			 时间		版本		更改
 */
namespace LoongEgg.Views
{
    // TODO: 20-1 一般方法的值转换器实现
    /// <summary>
    /// 整型转<see cref="Brush"/>
    /// </summary>
    public class IntToBrushConverter : IValueConverter
    {         
        /*------------------------------------ Public Methods -----------------------------------*/
        
        /// <summary>
        /// 整数转<see cref="Brush"/><see cref="IValueConverter.Convert(object, Type, object, CultureInfo)"/>
        /// </summary> 
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value == null) {
                return null;
            }else if((int) value < 18) {
                return Brushes.Green;
            }else {
                return Brushes.Blue;
            }
        }

        /// <summary>
        /// 不重要
        /// </summary> 
        public object ConvertBack
            (
                object value, 
                Type targetType, 
                object parameter, 
                CultureInfo culture
            ) => throw new NotImplementedException(); 
    }
}
