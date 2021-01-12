using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayScript : MonoBehaviour
{
    public GameObject obj;
    public float delay;
    void Start()
    {
        obj.SetActive(false);
        StartCoroutine(ShowIn());
    }

    IEnumerator ShowIn()
    {
        yield return new WaitForSeconds(delay);
        obj.SetActive(true);
    }
}
