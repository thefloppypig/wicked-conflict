using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Game inst;
    public AudioClip clipshoot;
    public AudioClip clipjump;
    public AudioClip clipstep;
    public string currentLocation = "Jeff's Home";
    public string lastLocation = "Jeff's Home";

    public int impRep = 0;
    public int skeleRep = 0;

    public List<string> characterDeaths;


    internal void SwitchScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
        lastLocation = currentLocation;
        currentLocation = nextScene;
    }

    protected AudioSource audiosrc;

    void Awake()
    {
        if (inst == null)
        {
            inst = this;
            DontDestroyOnLoad(this.gameObject);
            audiosrc = gameObject.AddComponent<AudioSource>();
        }
        else
        {
            Destroy(this); return;
        }
    }

    public void SoundShoot()
    {
        audiosrc.PlayOneShot(clipshoot);
    }

    public void SoundJump()
    {
        audiosrc.PlayOneShot(clipjump);
    }
    public void SoundStep()
    {
        audiosrc.PlayOneShot(clipstep);
    }
}
