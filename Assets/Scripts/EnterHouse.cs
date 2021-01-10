using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterHouse : MonoBehaviour
{
    public GameObject ePrompt;
    public string scene;
    bool colliding = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            ePrompt.SetActive(true);
            colliding = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            ePrompt.SetActive(false);
            colliding = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("e") && colliding) Game.inst.SwitchScene(scene);
    }
}
