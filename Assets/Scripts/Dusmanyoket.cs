using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// erhan
public class Dusmanyoket : MonoBehaviour
{
    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "mermi")
        {
            DestroyGameObject();
        }
    }
}
