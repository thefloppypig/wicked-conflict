using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepBar : MonoBehaviour
{
    Text t;
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Text>();
        UpdateText();
    }

    // Update is called once per frame
    public void UpdateText()
    {
        t.text = Game.inst.skeleRep + "    " + Game.inst.impRep;
    }
}
