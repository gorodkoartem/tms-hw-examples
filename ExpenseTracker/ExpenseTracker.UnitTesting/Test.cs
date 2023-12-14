using ExpenseTracker.DAL;
using ExpenseTracker.DAL.Models;
using ExpenseTracker.UnitTesting.Mocks;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;

namespace ExpenseTracker.UnitTesting;

public class Test
{
    private ExpenseTrackerDbContext _dbContext;
    private List<Category> _categories;
    private List<Category> _notSavedCategories;


    [SetUp]
    public void Setup()
    {
        _categories = new List<Category>()
        {
            new Category
            {
                Name = "Test",
            },
            new Category
            {
                Name = "Test1",
            }
        };

        var myDbContextMock = new Mock<ExpenseTrackerDbContext>();
        myDbContextMock.Setup(x => x.Categories).ReturnsDbSet(_categories);
        myDbContextMock.Setup(x => x.Categories.Add(It.IsAny<Category>())).Callback<Category>(_categories.Add);
        myDbContextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).Callback(() => { }).Returns(Task.FromResult(1));

        _dbContext = myDbContextMock.Object;
    }

    [Test]
    public async Task Test1()
    {
        _dbContext.Categories.Add(new Category() { Name = "sdf" });
        await _dbContext.SaveChangesAsync();

        var a = await _dbContext.Categories.ToListAsync();
        var b = await _dbContext.Categories.FirstOrDefaultAsync();
    }
}
