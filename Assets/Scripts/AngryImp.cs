using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryImp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<NPC>().BecomeAggressive();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
