using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages Audio in the scene
/// 
/// author: Trenton Plager tlp6760@rit.edu
/// </summary>
public class AudioManager : MonoBehaviour
{
    #region Fields
    //[SerializeField]
    //private AudioClip dungeonAmbience, buttonClick, demonLaugh;     //audio clips for the button, demon laugh, and the ambience
    //private AudioSource globalSource, stoneSource;                  //audio sources to manage what plays when
    //[SerializeField]
    //private GameObject stoneSourceObject;                           //the game object containing the stone audio source

    private StudioEventEmitter menuMusic;
    private StudioEventEmitter bossMusic;
    private StudioEventEmitter spookyMusic;

    //private Dresden player;

    //private string previousLevelName;
    //private string currentLevelName; 
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        ////initialization
        //globalSource = gameObject.GetComponent<AudioSource>();
        //stoneSource = stoneSourceObject.GetComponent<AudioSource>();

        DontDestroyOnLoad(gameObject);

        StudioEventEmitter[] emitters = gameObject.GetComponents<StudioEventEmitter>();
        foreach (StudioEventEmitter em in emitters)
        {
            if (em.Event == "event:/Music/SpookyMusic")
                spookyMusic = em;
            else if (em.Event == "event:/Music/MenuMusic")
                menuMusic = em;
            else if (em.Event == "event:/Music/BossMusic")
                bossMusic = em;
        }

        //Debug.Log(spookyMusic);
        //Debug.Log(menuMusic);
        //Debug.Log(bossMusic); 
    }

    // Update is called once per frame
    void Update()
    {
        //if (player == null)
        //    player = GameObject.Find("Dresden").GetComponent<Dresden>();

        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("PlayerHealth", GameObject.Find("Dresden").GetComponent<Dresden>().Health / GameObject.Find("Dresden").GetComponent<Dresden>().MAX_HEALTH); 
    }

    public void PlayMenuMusic()
    {
        if (!menuMusic.IsPlaying())
        {
            menuMusic.Play(); 
        }

        bossMusic.Stop();
        spookyMusic.Stop(); 
    }

    public void PlaySpookyMusic()
    {
        if (!spookyMusic.IsPlaying())
        {
            spookyMusic.Play();
        }

        bossMusic.Stop();
        menuMusic.Stop();
    }

    public void PlayBossMusic()
    {
        if (!bossMusic.IsPlaying())
        {
            bossMusic.Play();
        }

        spookyMusic.Stop();
        menuMusic.Stop();
    }
    ///// <summary>
    ///// Plays the button click one time
    ///// </summary>
    //public void PlayButtonClick()
    //{
    //    globalSource.PlayOneShot(buttonClick); 
    //}

    ///// <summary>
    ///// Plays the demon laugh one time
    ///// </summary>
    //public void PlayDemonLaugh()
    //{
    //    globalSource.PlayOneShot(demonLaugh); 
    //}

    ///// <summary>
    ///// Tells the stone source to start playing
    ///// </summary>
    //public void PlayStoneGrinding()
    //{
    //    stoneSource.Play(); 
    //}

    ///// <summary>
    ///// Tells the stone source to stop playing
    ///// </summary>
    //public void StopStoneGrinding()
    //{
    //    stoneSource.Stop(); 
    //}
}
