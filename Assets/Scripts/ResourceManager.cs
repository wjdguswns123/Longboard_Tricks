using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    //Object Pool.
    Dictionary<string, Object> m_ObjectPool = new Dictionary<string, Object>();

    //단일 프리팹 위치 지정 로딩.
    public GameObject LoadResourceInitPos(string path, float x = 0, float y = 0, float z = 0)
    {
        GameObject go = LoadResource(path);

        Vector3 pos = go.transform.localPosition;
        pos.x = x;
        pos.y = y;
        pos.z = z;
        go.transform.localPosition = pos;
        go.transform.localRotation = Quaternion.identity;
        go.transform.localScale = Vector3.one;

        return go;
    }

    //단일 프리팹 로딩.
    public GameObject LoadResource(string path)
    {
        Object obj = null;

        if(m_ObjectPool.ContainsKey(path))
        {
            obj = m_ObjectPool[path];
        }
        else
        {
            obj = Resources.Load(path);
            m_ObjectPool.Add(path, obj);
        }
        
        return Instantiate(obj) as GameObject;
    }

    //폴더 내 모든 프리팹 로딩.
    public void LoadResources(string path)
    {
        Object[] objs = Resources.LoadAll(path);
        foreach(Object o in objs)
        {
            if(!m_ObjectPool.ContainsValue(o))
            {
                m_ObjectPool.Add(path + o.name, o);
            }

            Instantiate(o);
        }
    }
}
