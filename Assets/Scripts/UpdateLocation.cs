using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpdateLocation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Game.inst.currentLocation = SceneManager.GetActiveScene().name;
        GetComponent<Text>().text = SceneManager.GetActiveScene().name;
    }

  
}
