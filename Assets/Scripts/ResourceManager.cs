using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class ResourceManager : Singleton<ResourceManager>
{
    //Object Pool.
    Dictionary<string, Object> objectPool = new Dictionary<string, Object>();

    private bool useAssetBundle = false;
    public bool UseAssetBundle
    {
        get { return useAssetBundle; } set { useAssetBundle = value; }
    }

    //에셋 번들 메모리에 미리 로딩.
    public void PreLoadAssetBundles()
    {
        if(!useAssetBundle)
        {
            return;
        }

        //"Project Folder/AssetBundles/Windows" 폴더 경로 만들기.
        string path = Application.dataPath.Remove(Application.dataPath.Length - 7, 7) + "/AssetBundles/Windows";

        if(!Directory.Exists(path))
        {
            //해당 경로 없으면 종료.
            return;
        }

        DirectoryInfo info = new DirectoryInfo(path);

        //에셋 번들 파일만 골라낸 파일 배열.
        FileInfo[] files = info.GetFiles().Where(f => (f.Extension != ".manifest")).ToArray();

        foreach (FileInfo fi in files)
        {
            AssetBundle bundle = AssetBundle.LoadFromFile(fi.FullName);
            if (bundle == null)
            {
                Debug.Log("Asset Bundle not exist.");
                continue;
            }
            Object[] objs = bundle.LoadAllAssets();
            foreach(Object o in objs)
            {
                if(!objectPool.ContainsKey(o.name))
                {
                    objectPool.Add(o.name, o);
                }
            }

            bundle.Unload(false);
        }
    }

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
        if(!useAssetBundle)
        {
            return LoadResourcesFolder(path);
        }
        else
        {
            return LoadAssetBundle(path);
        }
    }

    GameObject LoadResourcesFolder(string path)
    {
        Object obj = Resources.Load(path);

        if(obj == null)
        {
            Debug.Log("Resource not exist.");
            return null;
        }

        return Instantiate(obj) as GameObject;
    }

    GameObject LoadAssetBundle(string path)
    {
        Object obj = null;
        AssetBundle bundle = null;

        if (objectPool.ContainsKey(path))
        {
            obj = objectPool[path];
        }
        else
        {
            bundle = AssetBundle.LoadFromFile(Path.Combine(Application.dataPath.Remove(Application.dataPath.Length - 7, 7) + "/AssetBundles/Windows/", path));
            if(bundle == null)
            {
                Debug.Log("Asset Bundle not exist.");
                return null;
            }
            obj = bundle.LoadAsset<Object>(path);
            objectPool.Add(path, obj);
        }

        GameObject prefab = Instantiate(obj) as GameObject;

        if(bundle != null)
        {
            bundle.Unload(false);
        }

        return prefab;
    }

    private void OnDestroy()
    {
        objectPool.Clear();
    }
}
