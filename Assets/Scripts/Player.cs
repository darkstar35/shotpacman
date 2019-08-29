using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using Random=UnityEngine.Random;

public class Player : MonoBehaviour {

	public GameObject bulletPrefab;

	public float timeToSpawn;
	public float turnSpeed = 90f;
	public float maxSpeed = 5f;
	private float hue;
[SerializeField] float targetScale = 1.0f;
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

	private void Start(){
		headlightIntensity = headlight.intensity;
		if (engineGlow != null) {
			engineGlowIntensity = engineGlow.intensity;
		}
	}

	private void Update(){
		
		// Player movement
		float vert = Input.GetAxis("Vertical");
		float hori = Input.GetAxis("Horizontal");

		transform.Translate(new Vector2(hori, vert));

		if(Input.GetKeyDown(KeyCode.Space)){
			Fire();
		}

		// bounce the player off the bounds
/* 		if(Mathf.Abs(transform.position.x) > 10f)
			vel.x = -vel.x;
		
		if(Mathf.Abs(transform.position.y) > 10f)
			vel.y = -vel.y;
*/		

		if(Input.GetKeyDown (KeyCode.G)){
			sfRenderer.enabled = !sfRenderer.enabled;
		}

		// headlights!
		if(Input.GetKeyDown(KeyCode.F)){
			headlightOn = !headlightOn;
		}

		headlight.intensity = Mathf.Clamp(headlight.intensity + (headlightOn ? 1f : -1f) * 30f * Time.deltaTime, 0f, headlightIntensity);

		if (engineGlow != null) {
			engineGlow.intensity = 10f + engineGlowIntensity * Mathf.Abs (vert) * (Mathf.PerlinNoise (0f, Time.time * 20f) / 4f + 0.75f);
			engineGlow.color = Color.HSVToRGB (0.08f + 0.07f * Mathf.PerlinNoise (Time.time * 5f, 0f), 1f, 1f);
		}
	}


	public void Fire(){
		GameObject go = (GameObject) Instantiate(bulletPrefab, transform.position + Vector3.up, Quaternion.identity);
		AsteroidBullet b = go.GetComponent<AsteroidBullet>();
		b.vel = maxSpeed * 3.0f * (Vector2) transform.up;

		SFLight bulletLight = go.GetComponent<SFLight>();

		bulletLight.intensity = bulletIntensity;
	//	bulletLight.color = Color.HSVToRGB(hue, 1f, 1f);
	//		b.sr.color  = bulletLight.color;

		hue = (hue + 0.15f) % 1.0f;

		Destroy(go, 5.0f);
	}
	    void OnCollisionEnter2D(Collision2D collision) 
		{
     
	 
	     // if(collider.tag == "Bullet")
		  {
           //TargetScale -= 0.1f;
		   
		   transform.localScale -= Vector3.one* 0.1f;
		   Destroy(collision.gameObject);

		  // break;
          }
		}
		 void OnTriggerEnter2D(Collider2D collider) 
		{
     
	 
	     // if(collider.tag == "Bullet")
		  {
           //TargetScale -= 0.1f;
		   
		   transform.localScale -= Vector3.one* 0.1f;
		   Destroy(collider.gameObject);

		  // break;
          }
   
		if(transform.localScale.magnitude < 0)
		Destroy(this);
		}
	 
        //if(collision.gameObject.tag == "bullet")
        //  Destroy(this);

       // if (collision.relativeVelocity.magnitude > 2)
       //     audio.Play();
        
    }
	


