
namespace OWList
{
    public class OneWayListNode
    {
        public char Item { get; set; }
        public OneWayListNode? Next { get; set; }

        public OneWayListNode(char item)
        {
            this.Item = item;
            this.Next = null;
        }
    }
}
