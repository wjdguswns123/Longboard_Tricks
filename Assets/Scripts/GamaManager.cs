using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamaManager : MonoBehaviour
{
    public ResourceManager m_ResourceMgr;

    // Start is called before the first frame update
    void Start()
    {
        //m_ResourceMgr.LoadResource("longboard_0");
        //m_ResourceMgr.LoadResources("cosmo");
        m_ResourceMgr.LoadResourceInitPos("longboard_0", x : 2f, z : 5f);
        m_ResourceMgr.LoadResource("longboard_0");
    }
}
