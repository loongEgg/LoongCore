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
