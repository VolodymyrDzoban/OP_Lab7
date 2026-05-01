
namespace OWList
{
    public class OneWayListNode
    {
        public char Item { get; set; }
        public OneWayListNode? Next { get; set; }

        public OneWayListNode(char item, OneWayListNode? next)
        {
            this.Item = item;
            this.Next = next;
        }

        public OneWayListNode(char item)
            : this(item, null)
        {
        }
    }
}