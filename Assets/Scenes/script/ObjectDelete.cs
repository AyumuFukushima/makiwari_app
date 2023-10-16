using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ObjectDelete : MonoBehaviour
{
    IEnumerator GameObjectDestroy()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject.Destroy (gameObject);
    }

    void OnDestroy()
    {
        
    }
}
