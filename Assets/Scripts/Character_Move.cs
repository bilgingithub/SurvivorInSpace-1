using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// erhan
public class Character_Move : MonoBehaviour
{

    public float m_moveSpeed = 5f; // Hareket hızı

    private void Update()
    {

        karakterHareket();
        
    }

    private void karakterHareket()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * m_moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * m_moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * m_moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * m_moveSpeed * Time.deltaTime);
        }
    }

}
