using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Game inst;
    public GameObject deathScreen;
    public AudioClip clipshoot;
    public AudioClip clipjump;
    public AudioClip clipstep;
    public AudioClip cliphurt;
    public AudioClip clipdeath;
    public string currentLocation = "Jeff's Home";
    public string lastLocation = "Jeff's Home";

    public int impRep = 0;
    public int skeleRep = 0;

    public List<string> characterDeaths;


    public void SwitchScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
        lastLocation = currentLocation;
        currentLocation = nextScene;
        deathScreen.SetActive(false);
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
        audiosrc.PlayOneShot(clipdeath);
        StartCoroutine(DeathScreen());
    }

    IEnumerator DeathScreen()
    {
        yield return new WaitForSeconds(0.5f);
        deathScreen.SetActive(true);
    }

    public void Respawn()
    {
        SwitchScene(SceneManager.GetActiveScene().name);
    }

    public void EndingAnarchy()
    {
        SwitchScene("EndingAnarchy");
    }public void EndingAllied()
    {
        SwitchScene("EndingAllied");
    }public void EndingBetrayal()
    {
        SwitchScene("EndingBetrayal");
    }public void EndingHappy()
    {
        SwitchScene("EndingHappy");
    }public void EndingSad()
    {
        SwitchScene("EndingSad");
    }
    
}
