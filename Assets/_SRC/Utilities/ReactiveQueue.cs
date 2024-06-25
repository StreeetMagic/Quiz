using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Utilities
{
  [Serializable]
  public class ReactiveQueue<T>
  {
    private Queue<T> _queue;

    public ReactiveQueue()
    {
      _queue = new Queue<T>();
    }

    public ReactiveQueue(IEnumerable<T> queue)
    {
      _queue = new Queue<T>(queue);
    }

    public event Action<Queue<T>> Changed;

    public Queue<T> Value
    {
      get => _queue;
      set
      {
        _queue = new Queue<T>(value);
        Changed?.Invoke(_queue);
      }
    }
    
    public void Peek()
    {
      _queue.Peek();
    }

    public void Enqueue(T value)
    {
      _queue.Enqueue(value);
      Changed?.Invoke(_queue);
    }
    
    public T Dequeue()
    {
      T value = _queue.Dequeue();
      Changed?.Invoke(_queue);
      return value;
    }
  }
}