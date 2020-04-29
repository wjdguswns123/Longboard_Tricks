using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamaManager : MonoBehaviour
{
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
    }

    public void OnClick()
    {
        Timer.Start();
        for (int i = 0; i < 200; ++i)
        {
            ResourceManager.Instance.LoadResourceInitPos("longboard_0");
        }
        Timer.Stop();
        Debug.Log(string.Format("{0} ms", Timer.GetTime()));
    }
}
