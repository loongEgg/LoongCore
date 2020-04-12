using System;
using LoongEgg.LoongLogger;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoongEgg.LoongCore.Test
{
    [TestClass]
    public class DelegateCommand_Test
    {
        /// <summary>
        /// 初始化测试，会在所有测试方法前调用
        /// </summary>
        /// <remarks>
        ///     LoongEgg.LoongLogger是我的一个开源项目，你可以不使用
        /// </remarks>
        [TestInitialize]
        public void EnabledLogger() {
            LoggerManager.Enable(LoggerType.File, LoggerLevel.Debug);
            LoggerManager.WriteDebug("Test initialized ok ....");
        }

        /// <summary>
        /// 检查在构造器中execute不能为null
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_ThrowExectptionIfActionParameterIsNull() {
            var command = new DelegateCommand(null);
        }

        /// <summary>
        /// Action可以被正常委托执行
        /// </summary>
        [TestMethod]
        public void ExecuteAction_CanInvokes() {
            bool invoked = false;

            void action(object obj) => invoked = true;

            var command = new DelegateCommand(action);
            command.Execute(null);

            Assert.IsTrue(invoked);
        }

        /// <summary>
        /// CanExecute为Null时命令默认可以执行
        /// </summary>
        [TestMethod]
        public void CanExecute_IsTrueByDefault() {
            var command = new DelegateCommand(obj => { });
            Assert.IsTrue(command.CanExecute(null));
        }

        /// <summary>
        /// CanExecute可以判断命令不能执行
        /// </summary>
        [TestMethod]
        public void CanExecute_FalsePredicate() {
            var command = new DelegateCommand
                                    (
                                        obj => { },
                                        obj => (int)obj == 0
                                    );
            Assert.IsFalse(command.CanExecute(6));
        }

        /// <summary>
        /// CanExecute可以判断命令可以执行
        /// </summary>
        [TestMethod]
        public void CanExecute_TruePredicate() {
            var command = new DelegateCommand
                                    (
                                        obj => { },
                                        obj => (int)obj == 6
                                    );
            Assert.IsTrue(command.CanExecute(6));
        }

        [TestMethod]
        public void CanExecuteChanged_Raised() {
            var command = new DelegateCommand
                                    (
                                        obj => { },
                                        obj => (int)obj == 6
                                    );
            bool isCanExecuteChanged = false;
            command.CanExecuteChanged += (s, e) =>
            {
                isCanExecuteChanged = true;
                LoggerManager.WriteDebug($"CanExecuteChanged Raised by {s.ToString()}");
            };
            Assert.IsTrue(command.CanExecute(6));
            Assert.IsFalse(command.CanExecute(66));
            Assert.IsTrue(isCanExecuteChanged);
        }

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
