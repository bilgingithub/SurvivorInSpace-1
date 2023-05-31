using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// erhan
public class CameraController : MonoBehaviour
{
    public Transform Character; 

    private Vector3 offset; // Kamera ile Character arasındaki mesafe

    private void Start()
    {
        // Character ile kamera arasındaki mesafeyi kaydet
        offset = transform.position - Character.position;
    }

    private void LateUpdate()
    {
        
        transform.position = Character.position + offset;
    }
}
