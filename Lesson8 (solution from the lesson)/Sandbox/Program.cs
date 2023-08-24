
using Sandbox;
using Sandbox.Builder;
using Sandbox.Logger;

Builder builder = new ArtemBuilder(9);
builder.Build();

var service = new Service(new CompositeLogger(new ConsoleLogger(), new FileLogger("test.txt")), builder);
service.BuildHouse();
