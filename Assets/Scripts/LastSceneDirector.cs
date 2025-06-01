using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class LastSceneDirector : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public ParticleSystem particle1;
    public ParticleSystem particle2;
    public float delayBeforeLoadMenu = 3f;

    private bool hasFinished = false;

    void Start()
    {
        if (playableDirector != null)
        {
            playableDirector.stopped += OnTimelineStopped;
            playableDirector.Play();
        }
    }

    void OnTimelineStopped(PlayableDirector director)
    {
        if (!hasFinished)
        {
            hasFinished = true;
            PlayParticles();
            StartCoroutine(GoToMainMenuAfterDelay());
        }
    }

    void PlayParticles()
    {
        if (particle1 != null) particle1.Play();
        if (particle2 != null) particle2.Play();
    }

    IEnumerator GoToMainMenuAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeLoadMenu);

      
        if (SoundManager.instance != null)
        {
            SoundManager.instance.BGSound.Stop();
           
        }

        SceneManager.LoadScene("Menu"); 
    }
}
