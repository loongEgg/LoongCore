# LoongCore 深入理解MVVM
>最好的深入了解，动手实践

个人手撸, 并通过单元测试来了解MVVM框架的内涵

## 12.Abstract和单元测试初体验

1. 定义ObservableObject类
由于这是我们将来ViewModel的基类，所以它并没有实际含义，应该定为抽象类，但此处故意忘记
```c#
    public class ObservableObject : INotifyPropertyChanged
    {
              public event PropertyChangedEventHandler PropertyChanged;
 
    }
```
2. 新建单元测试
![01.Is Abstract](Figures/01.IsAbstract.png)

3. 在单元测试项目中确认ObservableObject为抽象类
```c#
    [TestClass]
    public class ObservableObject_Test
    {
        [TestMethod]
        public void IsAbstract() {

            var type = typeof(ObservableObject);
            Assert.IsTrue(type.IsAbstract);
        }
    }
```

4. 在测试资源管理器中运行测试   
![01.Is Abstract Test](Figures/01.IsAbstractTest.png)

5. 修改ObservableObject后测试通过
```c# 
    public abstract class ObservableObject : INotifyPropertyChanged
    {
              public event PropertyChangedEventHandler PropertyChanged;
 
    } 
```

## 13.PropertyChanged属性改变时发生了什么

1. ```ObservableObject.cs```属性改变时引发事件的底层方法
```c#
        // TODO: 13-1 引发属性改变事件的方法
        /// <summary>
        ///     引发属性改变事件
        /// </summary>
        ///     <param name="propertyName">发生改变的属性的名称</param>
        /// <remarks>
        ///     ?. 操作符如果有人给ViewModel留了“名片”才会引发，即外部有人订阅了PropertyChanged
        ///     没有这个方法是可以的，但是你可能得硬编码写propertyName
        /// </remarks>
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke
                                (
                                    this,
                                    new PropertyChangedEventArgs(propertyName)
                                );
```
2. ```ObservableObject.cs```属性设置器，当待设置的值确实为新值时会调用RaisePropertyChanged
```c#
        // TODO: 13-2 属性设置器
        /// <summary>
        /// 设置新的属性值,如果是“真的新”，调用<seealso cref="RaisePropertyChanged(string)"/>
        /// </summary>
        ///     <typeparam name="T">目标属性的类型</typeparam>
        ///     <param name="target">目标属性</param>
        ///     <param name="value">可能是新的值</param>
        ///     <param name="propertyName">[不要设置]目标属性的名称，自动推断</param>
        /// <returns>[true]目标属性已被更新？</returns>
        protected bool SetProperty<T>
            (
                    ref T target, // 目标属性
                    T value,      // “新”值
                    [CallerMemberName] string propertyName = null
            ) {
            if (EqualityComparer<T>.Default.Equals(target, value))
                return false;

            target = value;
            RaisePropertyChanged(propertyName);
            return true;
        }
```
3. 单元测试
```c#
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// TODO: 13-3 引用Logger记录器
using LoongEgg.LoongLogger;

namespace LoongEgg.LoongCore.Test
{
    [TestClass]
    public class ObservableObject_Test
    {
        // TODO: 13-4 测试初始化
        /// <summary>
        /// 初始化测试，会在所有测试方法前调用
        /// </summary>
        /// <remarks>
        ///     LoongEgg.LoongLogger是我的一个开源项目，你可以不使用
        /// </remarks>
        [TestInitialize]
        public void EnabledLogger() {
            LoggerManager.Enable(LoggerType.File, LoggerLevel.Debug);
        }
        
        /// <summary>
        /// 抽象类确认
        /// </summary>
        [TestMethod]
        public void IsAbstract() {
            var type = typeof(ObservableObject);
            Assert.IsTrue(type.IsAbstract);
        }

        // TODO: 13-5 设计一个测试类
        /// <summary>
        /// <see cref="ObservableObject"/>的一个测试样本
        /// </summary>
        public class ObservableObjectSample : ObservableObject
        {
            /// <summary>
            /// 测试属性
            /// </summary>
            public int PropertySample {
                get => _PropertySample;
                set => SetProperty(ref _PropertySample, value);
            }
            /// <summary>
            /// 测试字段
            /// </summary>
            private int _PropertySample;

        }

        // TODO: 13-6 属性改变时会发生什么
        /// <summary>
        /// 属性改变，且会引发事件确认
        /// </summary>
        [TestMethod] 
        public void CanPropertyChangedRaised() {
            bool isPropertyChangeRaised = false;// 事件引发标记

            // 初始化一个检测样本
            ObservableObjectSample sample = new ObservableObjectSample();

            // 注册属性改变时的处理事件
            sample.PropertyChanged += (s, args) =>
                                        {
                                            isPropertyChangeRaised = true;
                                            LoggerManager.WriteDebug($"PropertyName:{args.PropertyName}");
                                        };

            // 改变属性
            sample.PropertySample = 666;
            Assert.IsTrue(isPropertyChangeRaised);
            Assert.AreEqual(sample.PropertySample, 666);
        }

        // TODO: 13-7 清理测试环境
        /// <summary>
        /// 在所有测试完成后调用，注销LoggerManager
        /// </summary>
        [TestCleanup]
        public void DisableLogger() {
            LoggerManager.WriteDebug("LoggerManager is clean up...");
            LoggerManager.Disable();
        }

    }
}

```