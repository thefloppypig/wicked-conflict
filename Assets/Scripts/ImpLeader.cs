using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpLeader : MonoBehaviour
{
    public GameObject talk1;
    public GameObject talk2;
    // Start is called before the first frame update
    void Start()
    {
        CheckRep();
    }

    void OnCollisionEnter(Collision collision)
    {
        CheckRep();
    }

    void CheckRep()
    {
        if (Game.inst.impRep < 15)
        {
            talk1.SetActive(true);
            talk2.SetActive(false);
        }
        else
        {
            talk1.SetActive(false);
            talk2.SetActive(true);
        }
    }

    private void OnDisable()
    {
        if (Game.inst.characterDeaths.Contains("SkeletonKing") && Game.inst.characterDeaths.Contains("ImpLeader")) Game.inst.EndingAnarchy();
    }
}
