using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [HideInInspector]
    public string groundType;
    public bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        groundType = "None";
        grounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Metal")
        {
            groundType = "Metal";
        }
        else
        {
            groundType = "Concrete";
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Untagged" || collision.gameObject.tag == "Metal")
        {
            grounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Untagged" || collision.gameObject.tag == "Metal")
        {
            grounded = false;
        }
    }
}
