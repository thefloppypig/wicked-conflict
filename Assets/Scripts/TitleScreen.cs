using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject game = GameObject.Find("GameManager");
        if (game != null) Destroy(game);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Jeff's Home");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Exit game");
    }
}
