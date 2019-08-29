using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    [SerializeField] Player player = null;
    [SerializeField] Vector3 currentVelocity;
    [SerializeField] float smoothTime = 0.1f;

    public Player Player {
        get => player;
        set => player = value;
    }

    void Update() {
        transform.position = Vector3.SmoothDamp(transform.position, Player.transform.position, ref currentVelocity, smoothTime);
    }


     void OnCollisionEnter2D(Collision2D collision) 
		{
     
	 
	 
       // if(collision.gameObject.tag == "Player")
       //   Destroy(this);

       // if (collision.relativeVelocity.magnitude > 2)
       //     audio.Play();
        
    }
}
