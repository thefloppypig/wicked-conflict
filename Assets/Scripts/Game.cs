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
    public AudioClip cliphurt;
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

    public void UpdateRep()
    {
        GameObject hud = GameObject.Find("HUD");
        if (hud != null && hud.GetComponentInChildren<RepBar>() != null) hud.GetComponentInChildren<RepBar>().UpdateText();
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
    public void SoundHurt()
    {
        audiosrc.PlayOneShot(cliphurt);
    }

    public void PlayerDeath()
    {

    }
}
