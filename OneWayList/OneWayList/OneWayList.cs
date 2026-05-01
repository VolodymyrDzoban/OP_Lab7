using System.Collections;

namespace OWList
{
    public class OneWayList : IEnumerable<char>
    {
        const string errMsgIdOutOfRange = "Index out of range";

        private OneWayListNode? Head { get; set; }
        private OneWayListNode? Tail { get; set; }
        public int Size { get; private set; }

        public OneWayList(char item)
        {
            this.Head = new OneWayListNode(item);
            this.Tail = this.Head;
            this.Size = 1;
        }

        public OneWayList()
        {
            this.Head = null;
            this.Tail = this.Head;
            this.Size = 0;
        }

        public void Add(char item)
        {
            OneWayListNode element = new OneWayListNode(item);
            this.Size++;
            if (this.Head == null)
            {
                this.Head = element;
                this.Tail = this.Head;
                return;
            }
            this.Tail!.Next = element;
            this.Tail = element;
        }

        public char At(int index)
        {
            if (index < 0 || index >= this.Size)
            {
                throw new ArgumentOutOfRangeException(nameof(index), errMsgIdOutOfRange);
            }
            OneWayListNode item = this.Head!;
            for (int i = 0; i < index; i++)
            {
                item = item.Next!;
            }
            return item!.Item;
        }

        public char this[int index]
        {
            get => this.At(index);
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.Size)
            {
                throw new ArgumentOutOfRangeException(nameof(index), errMsgIdOutOfRange);
            }
            if (index == 0)
            {
                this.Head = this.Head!.Next;
                if (this.Size == 1)
                {
                    this.Tail = this.Head;
                }
            }
            else
            {
                OneWayListNode current = this.Head!;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next!;
                }
                current.Next = current.Next!.Next;
                if (index == this.Size - 1)
                {
                    this.Tail = current;
                }
            }
            this.Size--;
        }

        public int Find(char c)
        {
            if (this.Size == 0)
            {
                return -1;
            }
            OneWayListNode current = this.Head!;
            for (int i = 0; i < this.Size; i++)
            {
                if (c == current.Item)
                {
                    return i;
                }
                current = current.Next!;
            }
            return -1;
        }

        public OneWayList GetListAfterElementAt(int index)
        {
            if (index < 0 || index >= this.Size)
            {
                throw new ArgumentOutOfRangeException(nameof(index), errMsgIdOutOfRange);
            }
            OneWayList newList = new OneWayList();
            OneWayListNode? current = this.Head!;
            for ( int i = 0; i <= index; i++)
            {
                current = current!.Next;
            }
            for ( int i = index + 1;  i < this.Size; i++)
            {
                newList.Add(current!.Item);
                current = current.Next;
            }
            return newList;
        }

        public OneWayList GetListAfterElement(char c)
        {
            int index = this.Find(c);
            if (index < 0 || index >= this.Size)
            {
                return new OneWayList();
            }
            return GetListAfterElementAt(index);
        }

        public void RemoveAfterElementAt(int index)
        {
            if (index < 0 || index >= this.Size)
            {
                throw new ArgumentOutOfRangeException(nameof(index), errMsgIdOutOfRange);
            }
            OneWayListNode? current = this.Head!;
            for (int i = 0; i < index; i++)
            {
                current = current!.Next;
            }
            current!.Next = null;
            this.Tail = current;
            this.Size = index + 1;
        }

        public void RemoveAfterElement(char c)
        {
            int index = this.Find(c);
            if (index < 0 || index >= this.Size)
            {
                return;
            }
            this.RemoveAfterElementAt(index);
        }

        public int SumOfElementsAtEvenPositions()
        {
            if (this.Size == 0)
            {
                return 0;
            }
            OneWayListNode? current = this.Head!;
            int sum = 0;
            for (int i = 0; i < this.Size; i++)
            {
                if (i % 2 == 0)
                {
                    sum += current!.Item;
                }
                current = current!.Next;
            }
            return sum;
        }

        public IEnumerator<char> GetEnumerator()
        {
            OneWayListNode? current = this.Head;
            while (current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
