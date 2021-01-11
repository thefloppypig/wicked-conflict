using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarOwner : MonoBehaviour
{
    NPC npc;
    public GameObject dialog1;
    public GameObject dialog2;
    public GameObject dialog3;
    public GameObject dialog4;
    // Start is called before the first frame update
    void Start()
    {
        npc = GetComponent<NPC>();
    }

    public void DoAction0()
    {
        dialog1.SetActive(false);
        dialog2.SetActive(true);
    }

    public void DoAction1()
    {
        StartCoroutine(Action1());
    }

    IEnumerator Action1()
    {
        npc.state = NPC.NPCstates.Scripted;
        for (int i = 0; i < 200; i++)
        { 
            yield return new WaitForFixedUpdate();
            npc.MoveRight();
        }
        dialog2.SetActive(false);
        Game.inst.skeleRep += 8;
        if (Game.inst.characterDeaths.Contains("Imp11"))//player killed imp
        {
            transform.position = new Vector2(30.2f, -3.825019f);
            dialog4.SetActive(true);
        }
        else//skeleton kills imp
        {
            GameObject imp = GameObject.Find("Imp11");
            transform.position = imp.transform.position;
            imp.GetComponent<NPC>().TakeDamage(10);
            dialog3.SetActive(true);
        }
        Game.inst.UpdateRep();
        npc.MoveLeft();
        npc.state = NPC.NPCstates.Idle;
        GameObject.Find("Player").GetComponent<Player>().SetPlayerMove(true);
    }
}
