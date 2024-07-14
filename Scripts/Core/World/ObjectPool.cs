// 编写一个通用的对象池类，用于管理对象的创建、回收和复用。
// 该对象池类支持对象的创建、回收和复用，可以通过对象池类的接口获取对象、回收对象和清空对象池。

using System;
using System.Collections.Generic;

namespace GameCore
{
    public class ObjectPool<T> where T : class, new()
    {
        private readonly Stack<T> m_Stack = new Stack<T>();
        private readonly Action<T> m_OnGet;
        private readonly Action<T> m_OnRelease;

        public ObjectPool(Action<T> onGet = null, Action<T> onRelease = null)
        {
            m_OnGet = onGet;
            m_OnRelease = onRelease;
        }

        public T Get()
        {
            var element = this.m_Stack.Count == 0 ? new T() : m_Stack.Pop();

            m_OnGet?.Invoke(element);

            return element;
        }

        public void Release(T element)
        {
            if (m_Stack.Count > 0 && ReferenceEquals(m_Stack.Peek(), element))
            {
                throw new Exception("Internal error. Trying to destroy object that is already released to pool.");
            }

            m_OnRelease?.Invoke(element);

            m_Stack.Push(element);
        }

        public void Clear()
        {
            m_Stack.Clear();
        }
    }
}
