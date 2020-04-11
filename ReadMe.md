# LoongCore
>最好的深入了解，动手实践

个人手撸, 并通过单元测试来了解MVVM框架的内涵

## 01.Abstract和单元测试初体验

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