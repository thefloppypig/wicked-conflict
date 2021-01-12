using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeleGold : MonoBehaviour
{
    public GameObject dialog1;
    public GameObject dialog2;
    public GameObject dialog3;
    public GameObject dialog4;
    // Start is called before the first frame update
    void Start()
    {
        if (Game.inst.characterDeaths.Contains("ImpBronzeS"))
        {
            dialog1.SetActive(false);
            dialog3.SetActive(true);
        } 
        else if (Game.inst.characterDeaths.Contains("ImpBronze") && Game.inst.characterDeaths.Contains("Chicken"))
        {
            dialog1.SetActive(false);
            dialog4.SetActive(true);
        }
        else if (Game.inst.characterDeaths.Contains("Chicken"))
        {
            dialog1.SetActive(false);
            dialog2.SetActive(true);
        }
        else dialog1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoAction1()
    {
        StartCoroutine(Action1());
    }

    IEnumerator Action1()
    {
        NPC npc = GetComponent<NPC>();
        npc.state = NPC.NPCstates.Scripted;
        dialog2.SetActive(false);
        for (int i = 0; i < 200; i++)
        {
            yield return new WaitForFixedUpdate();
            npc.MoveLeft();
        }
        for (int i = 0; i < 200; i++)
        {
            yield return new WaitForFixedUpdate();
            npc.MoveRight();
        }
        Game.inst.skeleRep += 10;
        Game.inst.impRep += -1;
        Game.inst.characterDeaths.Add("ImpBronzeS");
        Game.inst.UpdateRep();
        npc.state = NPC.NPCstates.Idle;
        GameObject.Find("Player").GetComponent<Player>().SetPlayerMove(true);
        dialog3.SetActive(true);

    }
}
