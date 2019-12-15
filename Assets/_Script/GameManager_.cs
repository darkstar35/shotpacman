using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_ : MonoBehaviour
{

    [SerializeField]
    BulletLauncher launcherPrefab;
    BulletLauncher launcher;
    // Start is called before the first frame update
    void Start()
    {
       // launcher = Instantiate(launcherPrefab);
       // launcher.SetGameController(new KeyGameController());
        launcher = new BulletLauncher(new KeyGameController());

        MouseGameController mouseController =
        gameObject.AddComponent<MouseGameController>();

       // mouseController.FireButtonPressed += launcher.OnFireButtonPressed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
