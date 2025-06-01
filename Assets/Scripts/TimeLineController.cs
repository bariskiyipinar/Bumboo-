using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class TimeLineController : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public string nextSceneName; 

    void Start()
    {
        if (playableDirector != null)
        {
            playableDirector.stopped += OnTimelineFinished;
        }
        if(SoundManager.instance.BGSound != null)
        {
            SoundManager.instance.BGSound.Stop();
        }
    }

    void OnTimelineFinished(PlayableDirector director)
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
