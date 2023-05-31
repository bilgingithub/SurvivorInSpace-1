using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// erhan

public class UzayliTakipEtsin : MonoBehaviour
{
    public Transform target; // Takip edilecek hedef
    public float moveSpeed = 5f; // Hareket hızı

    private void Update()
    {
        // Hedefin konumuna doğru hareket et
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }
}
