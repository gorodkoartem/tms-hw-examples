using System.Collections;

namespace Sandbox
{
    class MyListItem<T>
    {
        public T Value { get; set; }
        public MyListItem<T> Next { get; set; }
    }

    interface IMyList<T> : IEnumerable<T>
    {
        void Add(T param);
    }

    // 1 => 3 => 2 => 4

    internal class MyList<T> : IMyList<T>
    {
        private MyListItem<T> head;

        public T this[int index]
        {
            get
            {
                var currentItem = head;
                for (var i = 0; i < index; i++)
                {
                    if(currentItem == null)
                        throw new IndexOutOfRangeException();

                    currentItem = currentItem.Next;
                }

                return currentItem.Value;
            }
        }

        public void Add(T value)
        {
            if (head == null)
            {
                head = new MyListItem<T> { Value = value };
                return;
            }

            head = new MyListItem<T> { Value = value, Next = head };
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnymerator<T>(head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class MyEnymerator<T> : IEnumerator<T>
    {
        private readonly MyListItem<T> head;
        private MyListItem<T> current;

        public MyEnymerator(MyListItem<T> head)
        {
            this.head = head;
        }

        public T Current => current.Value;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if(current == null)
            {
                current = head;
                return head != null;
            }

            if(current.Next == null)
                return false;

            current = current.Next;
            return true;
        }

        public void Reset()
        {
        }
    }
}
