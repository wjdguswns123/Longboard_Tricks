using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T m_Instance;

    public static T Instance
    {
        get
        {
            if(m_Instance == null)
            {
                GameObject obj = GameObject.Find(typeof(T).Name);
                if(obj == null)
                {
                    obj = new GameObject(typeof(T).Name);
                    m_Instance = obj.AddComponent<T>();
                }
                else
                {
                    m_Instance = obj.GetComponent<T>();
                }
            }

            return m_Instance;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
