using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCenter
{
    private static Dictionary<Enum, Delegate> m_EventTable = new Dictionary<Enum, Delegate>();

    private static void OnListenerAdding(Enum Enum, Delegate callBack)
    {
        if (!m_EventTable.ContainsKey(Enum))
        {
            m_EventTable.Add(Enum, null);
        }
        Delegate d = m_EventTable[Enum];
        if (d != null && d.GetType() != callBack.GetType())
        {
            throw new Exception(string.Format("尝试为事件{0}添加不同类型的委托，当前事件所对应的委托是{1}，要添加的委托类型为{2}", Enum, d.GetType(), callBack.GetType()));
        }
    }
    private static void OnListenerRemoving(Enum Enum, Delegate callBack)
    {
        if (m_EventTable.ContainsKey(Enum))
        {
            Delegate d = m_EventTable[Enum];
            if (d == null)
            {
                throw new Exception(string.Format("移除监听错误：事件{0}没有对应的委托", Enum));
            }
            else if (d.GetType() != callBack.GetType())
            {
                throw new Exception(string.Format("移除监听错误：尝试为事件{0}移除不同类型的委托，当前委托类型为{1}，要移除的委托类型为{2}", Enum, d.GetType(), callBack.GetType()));
            }
        }
        else
        {
            throw new Exception(string.Format("移除监听错误：没有事件码{0}", Enum));
        }
    }
    private static void OnListenerRemoved(Enum Enum)
    {
        if (m_EventTable[Enum] == null)
        {
            m_EventTable.Remove(Enum);
        }
    }
    //no parameters
    public static void AddListener(Enum Enum, CallBack callBack)
    {
        OnListenerAdding(Enum, callBack);
        m_EventTable[Enum] = (CallBack)m_EventTable[Enum] + callBack;
    }
    //Single parameters
    public static void AddListener<T>(Enum Enum, CallBack<T> callBack)
    {
        OnListenerAdding(Enum, callBack);
        m_EventTable[Enum] = (CallBack<T>)m_EventTable[Enum] + callBack;
    }
    //two parameters
    public static void AddListener<T, X>(Enum Enum, CallBack<T, X> callBack)
    {
        OnListenerAdding(Enum, callBack);
        m_EventTable[Enum] = (CallBack<T, X>)m_EventTable[Enum] + callBack;
    }
    //three parameters
    public static void AddListener<T, X, Y>(Enum Enum, CallBack<T, X, Y> callBack)
    {
        OnListenerAdding(Enum, callBack);
        m_EventTable[Enum] = (CallBack<T, X, Y>)m_EventTable[Enum] + callBack;
    }
    //four parameters
    public static void AddListener<T, X, Y, Z>(Enum Enum, CallBack<T, X, Y, Z> callBack)
    {
        OnListenerAdding(Enum, callBack);
        m_EventTable[Enum] = (CallBack<T, X, Y, Z>)m_EventTable[Enum] + callBack;
    }
    //five parameters
    public static void AddListener<T, X, Y, Z, W>(Enum Enum, CallBack<T, X, Y, Z, W> callBack)
    {
        OnListenerAdding(Enum, callBack);
        m_EventTable[Enum] = (CallBack<T, X, Y, Z, W>)m_EventTable[Enum] + callBack;
    }

    //no parameters
    public static void RemoveListener(Enum Enum, CallBack callBack)
    {
        OnListenerRemoving(Enum, callBack);
        m_EventTable[Enum] = (CallBack)m_EventTable[Enum] - callBack;
        OnListenerRemoved(Enum);
    }
    //single parameters
    public static void RemoveListener<T>(Enum Enum, CallBack<T> callBack)
    {
        OnListenerRemoving(Enum, callBack);
        m_EventTable[Enum] = (CallBack<T>)m_EventTable[Enum] - callBack;
        OnListenerRemoved(Enum);
    }
    //two parameters
    public static void RemoveListener<T, X>(Enum Enum, CallBack<T, X> callBack)
    {
        OnListenerRemoving(Enum, callBack);
        m_EventTable[Enum] = (CallBack<T, X>)m_EventTable[Enum] - callBack;
        OnListenerRemoved(Enum);
    }
    //three parameters
    public static void RemoveListener<T, X, Y>(Enum Enum, CallBack<T, X, Y> callBack)
    {
        OnListenerRemoving(Enum, callBack);
        m_EventTable[Enum] = (CallBack<T, X, Y>)m_EventTable[Enum] - callBack;
        OnListenerRemoved(Enum);
    }
    //four parameters
    public static void RemoveListener<T, X, Y, Z>(Enum Enum, CallBack<T, X, Y, Z> callBack)
    {
        OnListenerRemoving(Enum, callBack);
        m_EventTable[Enum] = (CallBack<T, X, Y, Z>)m_EventTable[Enum] - callBack;
        OnListenerRemoved(Enum);
    }
    //five parameters
    public static void RemoveListener<T, X, Y, Z, W>(Enum Enum, CallBack<T, X, Y, Z, W> callBack)
    {
        OnListenerRemoving(Enum, callBack);
        m_EventTable[Enum] = (CallBack<T, X, Y, Z, W>)m_EventTable[Enum] - callBack;
        OnListenerRemoved(Enum);
    }


    //no parameters
    public static void Broadcast(Enum Enum)
    {
        Delegate d;
        if (m_EventTable.TryGetValue(Enum, out d))
        {
            CallBack callBack = d as CallBack;
            if (callBack != null)
            {
                callBack();
            }
            else
            {
                throw new Exception(string.Format("广播事件错误：事件{0}对应委托具有不同的类型", Enum));
            }
        }
    }
    //single parameters
    public static void Broadcast<T>(Enum Enum, T arg)
    {
        Delegate d;
        if (m_EventTable.TryGetValue(Enum, out d))
        {
            CallBack<T> callBack = d as CallBack<T>;
            if (callBack != null)
            {
                callBack(arg);
            }
            else
            {
                throw new Exception(string.Format("广播事件错误：事件{0}对应委托具有不同的类型", Enum));
            }
        }
    }
    //two parameters
    public static void Broadcast<T, X>(Enum Enum, T arg1, X arg2)
    {
        Delegate d;
        if (m_EventTable.TryGetValue(Enum, out d))
        {
            CallBack<T, X> callBack = d as CallBack<T, X>;
            if (callBack != null)
            {
                callBack(arg1, arg2);
            }
            else
            {
                throw new Exception(string.Format("广播事件错误：事件{0}对应委托具有不同的类型", Enum));
            }
        }
    }
    //three parameters
    public static void Broadcast<T, X, Y>(Enum Enum, T arg1, X arg2, Y arg3)
    {
        Delegate d;
        if (m_EventTable.TryGetValue(Enum, out d))
        {
            CallBack<T, X, Y> callBack = d as CallBack<T, X, Y>;
            if (callBack != null)
            {
                callBack(arg1, arg2, arg3);
            }
            else
            {
                throw new Exception(string.Format("广播事件错误：事件{0}对应委托具有不同的类型", Enum));
            }
        }
    }
    //four parameters
    public static void Broadcast<T, X, Y, Z>(Enum Enum, T arg1, X arg2, Y arg3, Z arg4)
    {
        Delegate d;
        if (m_EventTable.TryGetValue(Enum, out d))
        {
            CallBack<T, X, Y, Z> callBack = d as CallBack<T, X, Y, Z>;
            if (callBack != null)
            {
                callBack(arg1, arg2, arg3, arg4);
            }
            else
            {
                throw new Exception(string.Format("广播事件错误：事件{0}对应委托具有不同的类型", Enum));
            }
        }
    }
    //five parameters
    public static void Broadcast<T, X, Y, Z, W>(Enum Enum, T arg1, X arg2, Y arg3, Z arg4, W arg5)
    {
        Delegate d;
        if (m_EventTable.TryGetValue(Enum, out d))
        {
            CallBack<T, X, Y, Z, W> callBack = d as CallBack<T, X, Y, Z, W>;
            if (callBack != null)
            {
                callBack(arg1, arg2, arg3, arg4, arg5);
            }
            else
            {
                throw new Exception(string.Format("广播事件错误：事件{0}对应委托具有不同的类型", Enum));
            }
        }
    }
}
