using Lesson6.Console;
LogisticPath path;
path = new LogisticPath("a", "b");

var timeSpan = path.EstimateDuration();

path = new WaterLogisticPath("a", "b", true);
path = new LandLogisticPath("a", "b");

path.EstimateDuration();
path.EstimateDuration();
