using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using Random=UnityEngine.Random;

public class Player : MonoBehaviour {

	public GameObject bulletPrefab;
	public List<GameObject> bulletInven;

	public float timeToSpawn;
	public float turnSpeed = 90f;
	public float maxSpeed = 5f;
	private float hue;
[SerializeField] float targetScale = 1.0f;

[SerializeField]public int nHP = 5;
[SerializeField] enum Mode 	{ NORMAL, ABSORB };

[SerializeField] Mode PlayerMode = Mode.NORMAL;

public float TargetScale {
        get => targetScale;
        private set => targetScale = value;
    }
	private Vector2 vel;

	public SFLight headlight;
	public SFLight engineGlow;
	public Color engineBaseGlow;
	private float headlightIntensity;
	private float engineGlowIntensity;
	public float bulletIntensity;
	public SFRenderer sfRenderer;
	private bool headlightOn = true;

	public int nbulletcnt;

	private void Start(){


		nbulletcnt = 8;
		for(int n =0; n<nbulletcnt; n++)
		bulletInven.Add(bulletPrefab);

		headlightIntensity = headlight.intensity;
		if (engineGlow != null) {
			engineGlowIntensity = engineGlow.intensity;
		}
	}

	private void Update(){
		
		
	switch(PlayerMode)
		{

		case Player.Mode.NORMAL :
           this.transform.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
		   break;


		   case Player.Mode.ABSORB :
         this.transform.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
		   break;

		  // break;
		}

		if(nHP <= 0)
			Destroy(this.gameObject);
	//	Instantiate(boom);


		if(Input.GetKeyDown(KeyCode.Space)){
			if(nbulletcnt > 0 && PlayerMode == Mode.NORMAL)
			Fire();
		}
			if(Input.GetKeyDown (KeyCode.G)){
			if(PlayerMode == Mode.NORMAL)
			{
				PlayerMode = Mode.ABSORB;
			}
			else
			    PlayerMode = Mode.NORMAL;

		}



// Player movement
		float vert = Input.GetAxis("Vertical");
		float hori = Input.GetAxis("Horizontal");

		transform.Translate(new Vector2(hori, vert));
		// bounce the player off the bounds
//	if(Mathf.Abs(transform.position.x) > 10f)
//			vel.x = -vel.x;		
//		if(Mathf.Abs(transform.position.y) > 10f)
//			vel.y = -vel.y;
		
/*
		if(Input.GetKeyDown (KeyCode.G)){
			sfRenderer.enabled = !sfRenderer.enabled;
		}

		// headlights!
		if(Input.GetKeyDown(KeyCode.F)){
			headlightOn = !headlightOn;
		}
 */
		headlight.intensity = Mathf.Clamp(headlight.intensity + (headlightOn ? 1f : -1f) * 30f * Time.deltaTime, 0f, headlightIntensity);

		if (engineGlow != null) 
		{
			engineGlow.intensity = 10f + engineGlowIntensity * Mathf.Abs (vert) * (Mathf.PerlinNoise (0f, Time.time * 20f) / 4f + 0.75f);
			engineGlow.color = Color.HSVToRGB (0.08f + 0.07f * Mathf.PerlinNoise (Time.time * 5f, 0f), 1f, 1f);
		}
		
	}


	public void Fire()
	{

		GameObject go = (GameObject) Instantiate(bulletPrefab, transform.position + new Vector3(0,2,0), Quaternion.identity);
		PCBullet b = go.GetComponent<PCBullet>();
		b.vel = maxSpeed * 3.0f *  transform.up;

		SFLight bulletLight = go.GetComponent<SFLight>();

		bulletLight.intensity = bulletIntensity;
	//	bulletLight.color = Color.HSVToRGB(hue, 1f, 1f);
	//		b.sr.color  = bulletLight.color;

		hue = (hue + 0.15f) % 1.0f;

		Destroy(go, 5.0f);

		nbulletcnt -= 1;
	}


	    void OnCollisionEnter2D(Collision2D collision) 
		{
     
	 
	      if(collision.gameObject.tag == "Bullet")
		  {

		switch(PlayerMode)
		{

			case Player.Mode.NORMAL :
        //   TargetScale -= 0.1f;
		   nHP -= 1;
		   Destroy(collision.gameObject);		   
		   transform.localScale -= Vector3.one* 0.1f;
		   break;


		   case Player.Mode.ABSORB :
        //   TargetScale += 0.1f;
		   nHP += 1;
		   	
		   Destroy(collision.gameObject);	   
		   transform.localScale += Vector3.one* 0.1f;
		   if(bulletInven.Count < 6)
		   {

		   GameObject bullet = (GameObject) Instantiate(bulletPrefab, transform.position + new Vector3(0,2,0), Quaternion.identity);
		   bulletInven.Add(bullet);

		   }
		   break;
		}
		   

		  // break;
		
          }
		}
		
		 void OnTriggerEnter2D(Collider2D collider) 
		{
     
	 
	      if(collider.tag == "Bullet")
		  {
        //   TargetScale -= 0.1f;
		   nHP -= 1;
		   transform.localScale -= Vector3.one* 0.1f;
		   Destroy(collider.gameObject);

		  // break;
          }
   
//		if(transform.localScale.magnitude < 0)
//		Destroy(this);
		}
	 
       // if (collision.relativeVelocity.magnitude > 2)
       //     audio.Play();
        
    }
	


