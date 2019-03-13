using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startScreenPress : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Example());
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(8);
        this.transform.Translate(0f,2f,0f);
    }
}