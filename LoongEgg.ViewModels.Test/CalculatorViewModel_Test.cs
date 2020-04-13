using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoongEgg.ViewModels.Test
{
    // TODO: 18-2 CalculatorViewModel的单元测试
    [TestClass]
    public class CalculatorViewModel_Test
    {
        /// <summary>
        /// 加法运算
        /// </summary>
        [TestMethod]
        public void Operation_Add() {
            var calc = new CalculatorViewModel
            {
                Left = 666,
                Right = 123
            };
            calc.OperationCommand.Execute("+");
            Assert.AreEqual(666 + 123, calc.Answer);
        }

        /// <summary>
        /// 减法运算
        /// </summary>
         [TestMethod]
        public void Operation_Sub() {
            var calc = new CalculatorViewModel
            {
                Left = 666,
                Right = 123
            };
            calc.OperationCommand.Execute("-");
            Assert.AreEqual(666 - 123, calc.Answer);
        }
         
        /// <summary>
        /// 乘法运算
        /// </summary>
        [TestMethod]
        public void Operation_Mul() {
            var calc = new CalculatorViewModel
            {
                Left = 99,
                Right = 66
            };

            calc.OperationCommand.Execute("*");

            Assert.AreEqual(99 * 66, calc.Answer);
        }

        /// <summary>
        /// 除法运算
        /// </summary>
        [TestMethod]
        public void Operation_Div() {
            var calc = new CalculatorViewModel
            {
                Left = 99,
                Right = 66
            };

            calc.OperationCommand.Execute("/");

            Assert.AreEqual(99 / 66, calc.Answer);
        }

    }
}
