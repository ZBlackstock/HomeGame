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
        /*switch (collision.gameObject.tag)
        {
            //remember to make the walls an actual collision using the moveInput values
            case "Floor":
                isGrounded = true;
                ;

                break;

            case "RWall":
                ;

                break;

            case "LWall":
                ;

                break;

            case "Roof":
                ;

                break;

        }*/
    }
}

