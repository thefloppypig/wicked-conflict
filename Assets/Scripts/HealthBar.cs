using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    protected Image bar;


    private void Start()
    {
        bar = GetComponent<Image>();
    }
    // Update is called once per frame
    public void UpdateBar(float v)
    {
        bar.fillAmount = v;
    }
}
