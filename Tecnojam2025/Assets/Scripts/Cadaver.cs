 using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cadaver : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Q))
        {    
            gameObject.localScale = new Vector3(10f, 0, 0);  
        }
    }
}
