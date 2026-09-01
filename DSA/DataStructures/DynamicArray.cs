
namespace DSA.DataStructures;
public class DynamicArray<T>
{
    private T[] _items;
    private int _size;

    public int Count => _size;
   
    public DynamicArray()
    {
        _items = new T[2];
        _size = 0;
    }

    public void Add(T item)
    {
        if (_size == _items.Length)
        {
           Resize();
        }
        _items[_size] = item;
        _size++;
        
    }

    private void Resize()
    {
        T[] newItems = new T[_items.Length *2];
        for(int i = 0; i < _items.Length; i++)
        {
            newItems[i] = _items[i];
        }
        _items = newItems;
    }

    public T Get (int index)
    {
        if(index < 0 || index >= _size)
        {
            throw new IndexOutOfRangeException("ïndex is out of range");
        }
        return _items[index];
    }

    public void RemoveAt(int index)
    {
        if(index < 0 || index >= _size)
        {
            throw new IndexOutOfRangeException("ïndex is out of range");
        }

        for(int i= index; i< _size - 1; i++)
        {
            _items[i] = _items[i+1];
        }

        _items[_size - 1] = default!;
        _size--;
    }

    public void Insert(int index, T item)
    {
        if(index < 0 || index > _size)
            throw new IndexOutOfRangeException("index is out of range");
    
        if(_size == _items.Length)
        {
            Resize();
        }

        Array.Copy(_items, index, _items, index + 1, _size-index);
        _items[index] = item;
        _size++;
    }
    public int IndexOf(T item)
            => Array.IndexOf(_items, item, 0, _size);

    public bool Contains(T item)
    {
        return _size != 0 && IndexOf(item) >= 0;
    } 
}