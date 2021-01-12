using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BertOutcome : MonoBehaviour
{
    public GameObject happyChicken;
    public GameObject sadChicken;
    void Start()
    {
        if (Game.inst.characterDeaths.Contains("SkeletonGolden"))
        {
            happyChicken.SetActive(false);
        }
        else sadChicken.SetActive(false);

            
    }

}
