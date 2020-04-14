using System;
using System.Globalization;
using System.Windows.Media;

/* 
 | 个人微信：InnerGeeker
 | 联系邮箱：LoongEgg@163.com 
 | 创建时间：2020/4/14 20:18:51
 | 主要用途：
 | 更改记录：
 |			 时间		版本		更改
 */
namespace LoongEgg.Views
{
    // TODO: 20-4 最简单的值转换器实现
    /// <summary>
    /// 最简单的值转换器实现
    /// </summary>
    public class AdvanceIntToBrushConverter : BaseValueConverter<AdvanceIntToBrushConverter>
    { 
        /*------------------------------------ Public Methods -----------------------------------*/
         
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value == null) {
                return null;
            }else if( (int) value < 18) {
                return Brushes.Green;
            }else {
                return Brushes.Yellow;
            }
        }
    }
}
