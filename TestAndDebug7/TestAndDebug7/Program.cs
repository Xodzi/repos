using System.Text;

NewStack<int> st = new NewStack<int>(new int[] {1,2,3,4,5},10);
st.Push(1);
Console.WriteLine(st.Count);
Console.WriteLine(st.Peek());
st.Pop();
Console.WriteLine(st.Peek());
Console.WriteLine(st.Count);

public class NewStack<T>
{
    private T[] items;
    private int count; 
    public int Count { get { return count; } }
    public bool IsEmpty { get { return count == 0; } }
    
    public NewStack(int length)
    {
        items = new T[length];
    }
    public NewStack(T[] arr, int length)
    {
        items = new T[length];
        for(int i = 0; i < arr.Length;i++)
        {
            items[i] = arr[i];
        }
        count = arr.Length;
    }
    public void Push(T item)
    {
        if (count == items.Length)
            throw new InvalidOperationException("Переполнение стека");
        items[count++] = item;
    }
    public T Pop()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Стек пуст");
        T item = items[--count];
        items[count] = default(T);
        return item;
    }
    public T Peek()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Стек пуст");
        return items[count - 1];

    }
    public void PrintStack()
    {
        if (count == 0)
        {
            Console.WriteLine("Стек пуст.");
        }
        else
        {
            Console.Write("Элементы стека: ");
            for (int i = 0; i <= count; i++)
            {
                Console.Write(items[i] + " ");
            }
            Console.WriteLine();
        }
    }
    public string PrintStackTest()
    {
        StringBuilder sb = new StringBuilder();
        if (count == 0)
        {
            sb.Append("Стек пуст.");
            return sb.ToString();
        }
        else
        {
            sb.Append("Элементы стека: ");
            //Console.Write("Элементы стека: ");
            for (int i = 0; i < count; i++)
            {
                sb.Append(items[i] + " ");
               // Console.Write(items[i] + " ");
            }
            //Console.WriteLine();
            return sb.ToString();
        }
    }

}