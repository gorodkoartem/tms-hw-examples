using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq.Expressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExpenseTracker.UnitTesting.Mocks;

internal class DbContextMockHelper
{
    public static TContext GetMock<TData, TContext>(List<TData> lstData, Expression<Func<TContext, DbSet<TData>>> dbSetSelectionExpression) where TData : class where TContext : DbContext
    {
        IQueryable<TData> lstDataQueryable = lstData.AsQueryable();
        IAsyncEnumerator<TData> asyncEnumerable = new TestDbAsyncEnumerator<TData>(lstData.GetEnumerator());

        Mock<DbSet<TData>> dbSetMock = new Mock<DbSet<TData>>();
        Mock<TContext> dbContext = new Mock<TContext>();

        dbSetMock.As<IQueryable<TData>>().Setup(s => s.Provider).Returns(lstDataQueryable.Provider);
        dbSetMock.As<IQueryable<TData>>().Setup(s => s.Expression).Returns(lstDataQueryable.Expression);
        dbSetMock.As<IQueryable<TData>>().Setup(s => s.ElementType).Returns(lstDataQueryable.ElementType);
        dbSetMock.As<IQueryable<TData>>().Setup(s => s.GetEnumerator()).Returns(lstDataQueryable.GetEnumerator);
        dbSetMock.As<IAsyncEnumerable<TData>>().Setup(s => s.GetAsyncEnumerator(It.IsAny<CancellationToken>())).Returns(asyncEnumerable);
        //dbSetMock.Setup(x => x.AsAsyncEnumerable<TData>()).Returns(lstDataQueryable);
        dbSetMock.Setup(x => x.Add(It.IsAny<TData>())).Callback<TData>(lstData.Add);
        dbSetMock.Setup(x => x.AddRange(It.IsAny<IEnumerable<TData>>())).Callback<IEnumerable<TData>>(lstData.AddRange);
        dbSetMock.Setup(x => x.Remove(It.IsAny<TData>())).Callback<TData>(t => lstData.Remove(t));
        dbSetMock.Setup(x => x.RemoveRange(It.IsAny<IEnumerable<TData>>())).Callback<IEnumerable<TData>>(ts =>
        {
            foreach (var t in ts) { lstData.Remove(t); }
        });


        dbContext.Setup(dbSetSelectionExpression).Returns(dbSetMock.Object);

        return dbContext.Object;
    }
}

internal class TestDbAsyncEnumerable<T> : IAsyncEnumerable<T>
{
    private IEnumerable<T> _enumerable;

    public TestDbAsyncEnumerable(IEnumerable<T> enumerable)
    {
        _enumerable = enumerable;
    }

    public TestDbAsyncEnumerator<T> GetAsyncEnumerator()
    {
        return new TestDbAsyncEnumerator<T>(_enumerable.GetEnumerator());
    }

    public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        return new TestDbAsyncEnumerator<T>(_enumerable.GetEnumerator());
    }
}

internal class TestDbAsyncEnumerator<T> : IAsyncEnumerator<T>
{
    private readonly IEnumerator<T> _inner;

    public TestDbAsyncEnumerator(IEnumerator<T> inner)
    {
        _inner = inner;
    }

    public ValueTask<bool> MoveNextAsync()
    {
        return ValueTask.FromResult(_inner.MoveNext());
    }

    public ValueTask DisposeAsync()
    {
        _inner?.Dispose();
        return ValueTask.CompletedTask;
    }

    public T Current
    {
        get { return _inner.Current; }
    }
}
