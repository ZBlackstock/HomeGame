using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rb;
   

    void FixedUpdate()
    {

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.tag);
        
        
    }
}

