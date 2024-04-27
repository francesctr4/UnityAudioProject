using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public string groundType;

    // Start is called before the first frame update
    void Start()
    {
        groundType = "None";
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
}
