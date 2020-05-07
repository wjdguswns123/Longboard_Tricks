using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamaManager : MonoBehaviour
{
    ObjectPool pool = new ObjectPool();
    ObjectPool pool1 = new ObjectPool();

    public GameObject temp;
    public GameObject temp1;
    // Start is called before the first frame update
    void Start()
    {
        ResourceManager.Instance.UseAssetBundle = false;

        //ResourceManager.Instance.PreLoadAssetBundles();

        //m_ResourceMgr.LoadResource("longboard_0");
        //m_ResourceMgr.LoadResources("cosmo");
        //ResourceManager.Instance.LoadResourceInitPos("longboard_0", x : 2f, z : 5f);
        //ResourceManager.Instance.LoadResource("longboard_0");

        //Timer.Start();
        //for (int i = 0; i < 200; ++i)
        //{
        //    ResourceManager.Instance.LoadResourceInitPos("longboard_0");
        //}
        //Timer.Stop();
        //Debug.Log(string.Format("{0} ms", Timer.GetTime()));


        //ResourceManager.Instance.LoadResource("longboard_0");

        //ResourceManager.Instance.PreLoadAssetBundles();
        //ResourceManager.Instance.LoadResource("longboard_0");

        //pool = new ObjectPool();
        pool.InitPool(temp, 10);
        pool1.InitPool(temp1, 5);
    }

    public void OnClick()
    {
        //Timer.Start();
        //for (int i = 0; i < 200; ++i)
        //{
        //    ResourceManager.Instance.LoadResourceInitPos("longboard_0");
        //}
        //Timer.Stop();
        //Debug.Log(string.Format("{0} ms", Timer.GetTime()));


        //pool.ClearPool();
        //pool.DestroyPool();

        GameObject go = pool.GetObject();
        GameObject go1 = pool1.GetObject();

        StartCoroutine(DestroyObj(go, pool));
        StartCoroutine(DestroyObj(go1, pool1));
    }

    IEnumerator DestroyObj(GameObject go, ObjectPool pool)
    {
        yield return new WaitForSeconds(3f);

        pool.ReturnObject(go);
    }
}
