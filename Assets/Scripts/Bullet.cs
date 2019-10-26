using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    enum direciton { DOWN, TOP, RIGHT, LEFT }

    [SerializeField] Player player = null;
    [SerializeField] Vector3 currentVelocity;
    [SerializeField] float smoothTime = 0.1f;
    [SerializeField] float fLifeTime = 0;
    public int nLevel;

    [SerializeField] float fSpeed = 0.2f;


    public Player Player {
        get => player;
        set => player = value;
    }

    void Update() {


        if(nLevel == 0)
        {
            transform.Translate(Vector3.down*fSpeed); 
        }

        else if(nLevel == 1)
        {
        if(player != null)
            transform.position = Vector3.SmoothDamp(transform.position, Player.transform.position, ref currentVelocity, smoothTime);
        }

        fLifeTime += Time.deltaTime;

        if(fLifeTime > 10)
        {
        //this.gameObject.SetActive(false);
        Destroy(this.gameObject);
        }
        
       
    }


     void OnCollisionEnter2D(Collision2D collision) 
		{
     
        if(collision.gameObject.tag == "Wall")
          Destroy(this);

       // if (collision.relativeVelocity.magnitude > 2)
       //     audio.Play();
        
    }
}
