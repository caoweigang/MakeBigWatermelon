using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> where T : new()
{
    private static T m_instacne;
    public static T Instance {
        get
        {
            if(m_instacne == null)
            {
                m_instacne = new T();
            }
            return m_instacne;
        }
    }
}
