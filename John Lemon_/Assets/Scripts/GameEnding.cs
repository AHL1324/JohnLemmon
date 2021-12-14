using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 0f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public AudioSource exitSource;
    public AudioSource caughtSource;
    bool m_HasAudioPlayed;
    bool m_isPlayerAtExit;
    bool m_isPlayerCaught;
    float m_Timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_isPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false, exitSource);
        }
        else if(m_isPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtSource);
        }
      
    }

    public void CaughtPlayer()
    {
        m_isPlayerCaught = true;
        //El enemigo atrapó al juagdor
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            m_isPlayerAtExit = true;
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool dorestart, AudioSource audioSource)
    {
        //Si no se ha reproducido el sonido
        if(!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }
        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;
        if(m_Timer > fadeDuration + displayImageDuration)
        {
            if(dorestart)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
            
        }
    }

}
