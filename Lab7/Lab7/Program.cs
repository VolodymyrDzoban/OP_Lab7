using OWList;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            OneWayList L = new OneWayList();
            L.Add('b');
            L.Add('c');
            L.Add('"');
            Console.Write("L: ");
            PrintList(L);
            L.RemoveAt(1);
            Console.Write("L: ");
            PrintList(L);
            List<char> charlist1 = ['a', 'g', '7', 'j', '8', 'z', 'o', 'q', 'k', 'p', 'a'];

            OneWayList L2 = new OneWayList('t');
            foreach (char c in charlist1)
            {
                L2.Add(c);
            }

            Console.Write("L2: ");
            PrintList(L2);
            Console.WriteLine("First enter of 8 : " + L2.Find('8'));
            L2.RemoveAt(3);
            L2.RemoveAt(6);
            Console.WriteLine("First enter of 8 : " + L2.Find('8'));
            Console.Write("L2: ");
            PrintList(L2);

            List<char> charlist2 = ['5', 'g', 'e', 'a', 'i', '/', 't','*', 'q', '\\', 's', 'm', '9', '*', '3', 'x', 'u'];
            OneWayList L3 = new OneWayList();
            foreach (char c in charlist2)
            {
                L3.Add(c);
            }
            Console.Write("L3: ");
            PrintList(L3);
            Console.WriteLine("First enter of * : " + L3.Find('*'));
            Console.WriteLine("Sum of even id: " + L3.SumOfElementsAtEvenPositions());
            OneWayList newL = L3.GetListAfterElement('*');
            Console.Write("newL: ");
            PrintList(newL);
            L3.RemoveAfterElement('*');
            Console.Write("L3: ");
            PrintList(L3);
        }

        static void PrintList(OneWayList list)
        {
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}