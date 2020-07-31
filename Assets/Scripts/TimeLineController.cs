using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimeLineController : MonoBehaviour
{
    PlayableDirector playableDirector;

    [SerializeField]
    TimelineAsset[]  timelineAssets = new TimelineAsset[1];

    [SerializeField]
    bool             isLoop = false;

    int currentPlayIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(playableDirector == null)
        {
            playableDirector = this.GetComponent<PlayableDirector>();
        }
        playableDirector.stopped += EndPlayTimeLineAsset;
        currentPlayIndex = 0;

        playableDirector.Play(timelineAssets[currentPlayIndex]);
    }

    void EndPlayTimeLineAsset(PlayableDirector pd)
    {
        if(timelineAssets.Length - 1 >  currentPlayIndex)
        {
            playableDirector.Play(timelineAssets[++currentPlayIndex]);
        }
        else if(isLoop)
        {
            currentPlayIndex = 0;
            playableDirector.Play(timelineAssets[currentPlayIndex]);
        }
    }
}
