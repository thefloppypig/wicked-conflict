using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpBronze : MonoBehaviour
{
    public GameObject talk1;
    public GameObject talk2;
    // Start is called before the first frame update
    void Start()
    {
        if (Game.inst.characterDeaths.Contains("SkeletonGolden"))
        {
            talk1.SetActive(false);
            talk2.SetActive(true);
        }
    }

    public void SetChickenInDanger()
    {
        Game.inst.characterDeaths.Add("Chicken");
    }

    
}
