

class CircularQueue<T> : DynamicQueue<T>
{
    //Private attributes
    private int maxSize;


    public CircularQueue(int maxSize)
    {
        this.maxSize = maxSize;
    }//Constructor

    public new void Enqueue(T item)
    {
        if (Count <= maxSize)
        {
            base.Enqueue(item);
            tail.Next = head;
        }
    }//Enqueue

    public new T Dequeue()
    {
        tail.Next = head.Next;
        return base.Dequeue();


    }//Dequeue

   public T Next()
    {
        tail = head;
        head = tail.Next;
        return tail.element;
    }//Next

} //class