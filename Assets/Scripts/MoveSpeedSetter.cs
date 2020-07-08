using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[Serializable]
public struct SettingSpeedStruct
{
    public float  time;
    public float  speed;
    public bool   isInit;

    public SettingSpeedStruct(float time, float speed, bool init)
    {
        this.time   = time;
        this.speed  = speed;
        this.isInit = init;
    }
}

public class MoveSpeedSetter : StateMachineBehaviour
{
    float currentTime = 0f;

    public SettingSpeedStruct[] settingValues = new SettingSpeedStruct[1];

    Queue<SettingSpeedStruct> settingValsQueue = new Queue<SettingSpeedStruct>();

    Vector3 initSpeed;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        currentTime = 0f;

        int count = settingValues.Length;
        for(int i = 0; i < count; ++i)
        {
            settingValsQueue.Enqueue(settingValues[i]);
        }

        Player p = animator.GetComponent<Player>();

        if (p != null)
        {
            initSpeed = p.Speed;
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        currentTime += Time.deltaTime;

        if (settingValsQueue.Count > 0 && settingValsQueue.Peek().time <= currentTime)
        {
            Player p = animator.GetComponent<Player>();

            if(p != null)
            {
                SettingSpeedStruct val = settingValsQueue.Dequeue();
                if(val.isInit)
                {
                    p.Speed = initSpeed;
                }
                else
                {
                    p.Speed = p.transform.forward * val.speed;
                }
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
