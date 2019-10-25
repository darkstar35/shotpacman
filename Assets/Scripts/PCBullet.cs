using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
	public Vector2 vel;
	public SpriteRenderer sr;

	public void Update()
	{
		this.transform.position += (Vector3) vel * Time.deltaTime;
	}
}
