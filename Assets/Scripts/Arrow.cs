using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    Rigidbody body;
    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody>();
    }



    void Shoot()
    {

        body.AddForce(transform.forward*100.0f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
