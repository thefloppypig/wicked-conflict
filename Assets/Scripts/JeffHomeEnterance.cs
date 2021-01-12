using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeffHomeEnterance : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneSwitcher exit = GetComponent<SceneSwitcher>();
        if (Game.inst.characterDeaths.Contains("Chicken")) exit.scene = "Bert's Home";
    }

}
