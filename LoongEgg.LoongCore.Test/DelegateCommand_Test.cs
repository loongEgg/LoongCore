using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoongEgg.LoongCore.Test
{
    [TestClass]
    public class DelegateCommand_Test
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_ThrowExeceptionIfExecuteParameterIsNULL() {
            var command = new DelegateCommand(null);
        }

        [TestMethod]
        public void Execute_CanInvokes() {
            bool invoked = false;

            var command = new DelegateCommand(
                                                   obj => { invoked = true; }
                                             );
            command.Execute(null);
            Assert.IsTrue(invoked);
        }

        [TestMethod]
        public void CanExecute_IsTrueByDefault() {
            var command = new DelegateCommand(obj => { });

           Assert.IsTrue(  command.CanExecute(null));
        }

        [TestMethod]
        public void CanExecute_TruePredicate() {
            var command = new DelegateCommand
                (
                    obj => { },
                    obj =>  (int)obj == 666
                );
            Assert.IsTrue(command.CanExecute(666));
        }

        [TestMethod]
        public void CanExecute_FalsePredicate() {
            var command = new DelegateCommand
                (
                    obj => { },
                    obj =>  (int)obj == 666
                );
            Assert.IsFalse(command.CanExecute(66));
        }
    }
}
