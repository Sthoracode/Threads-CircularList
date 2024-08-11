

public interface IQueue<T>
{
    void Enqueue(T value);
    void Clear();
    T Dequeue();
    T Peek();
    int Count { get; }
} //interface

class DynamicQueue<T> : IQueue<T>
{
    #region Private embedded class for individual nodes in the queue
    protected class Node 
    {
        public T element { get; private set; }
        public Node Next { get; set; }

        //Constructor
        public Node(T element, Node prevNode)
        {
            this.element = element;
            Next = null;
            if (prevNode != null) 
                prevNode.Next = this;
        } //Constructor

    } //embedded class Node
    #endregion Embedded class

    #region private data members of the queue
    protected Node head, tail; 
    #endregion

    #region Property for count
    public int Count { get; protected set; } 
    #endregion

    #region Constructor   
    public DynamicQueue()
    {
        Clear();
    } //Constructor
    #endregion

    public void Enqueue(T item)
    {
        if (this.head == null) 
            this.head = this.tail = new Node(item, null);
        else
            tail = new Node(item, tail);
        Count++;
    } //Enqueue

    public void Clear()
    {
        head = null;
        tail = null;
        Count = 0;
    } //Clear

    public T Dequeue()
    {
        if (head != null)
        {
            T item = head.element;
            head = head.Next;
            Count--;
            return item;
        }
        return default(T);
    } //Dequeue

    public T Peek()
    {
        if (head != null)
            return head.element;
        else
            return default(T);
    } //Peek 

    //To be completed
    public T[] ToArray()
    {
        //Dummy return - to be replaced
        T[] arr = new T[Count];
        int i = 0;
        if(Count > 0)
        {
            Node current = head;
            while (current != null)
            {
                arr[i] = current.element;
                current = current.Next;
                i++;
            }
            return arr;
        }
        return default(T[]); 
    } //ToArray

} //class DynamicQueue

