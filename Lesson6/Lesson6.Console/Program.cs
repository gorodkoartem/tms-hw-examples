using Lesson6.Console;
LogisticPath path;
path = new LogisticPath("a", "b");

path.EstimateDuration();

// Polymorphism illustration (WaterLogisticPath methods are called instead of LogisticPath despite path variable type is LogisticPath)
// Иллюстрация полиморфизма (вызываются методы из WaterLogisticPath вместо LogisticPath несмотря на то, что переменная path типа LogisticPath)
path = new WaterLogisticPath("a", "b", true);
path.EstimateDuration();
