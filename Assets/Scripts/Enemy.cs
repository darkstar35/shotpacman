using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float targetScale = 1.0f;
    [SerializeField] float currentVelocity = 0.0f;
    [SerializeField] float smoothTime = 0.3f;
    [SerializeField] DotSpawner dotSpawner = null;
    [SerializeField] Transform dotHelperRadius = null;
    [SerializeField] float spawnInterval = 0.5f;
    [SerializeField] GameObject BulletPrefab = null;
    [SerializeField] Camera cam = null;
    [SerializeField] Player player = null;
    [SerializeField] RectTransform gameWorldRt = null;

    public float TargetScale {
        get => targetScale;
        private set => targetScale = value;
    }
    // Start is called before the first frame update
       IEnumerator Start() {
        yield return new WaitForSeconds(Random.Range(0.5f, 1.0f));
        while (TargetScale > 0) {
            yield return new WaitForSeconds(spawnInterval);
            var bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<Bullet>().Player = player;
          //  TargetScale -= 0.1f;
        }
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
      //   var Bullet = Instantiate(BulletPrefab, gameWorldRt.transform).GetComponent<Dot>();
       // dot.transform.localPosition = localPoint;
      //  Bullet.Player = player;
    }

      void OnCollisionEnter2D(Collision2D collision) {
     
        if(collision.gameObject.tag == "Bullet")
          Destroy(this);

       // if (collision.relativeVelocity.magnitude > 2)
       //     audio.Play();
        
    }


}
