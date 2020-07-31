using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLineSceneManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TimeLineController ctrl = ResourceManager.Instance.LoadResource("Pivot").GetComponentInChildren<TimeLineController>();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ResourceManager.Instance.LoadResource("180Step");
        }
    }
}
