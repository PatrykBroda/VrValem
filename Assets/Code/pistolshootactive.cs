using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class pistolshootactive : MonoBehaviour
{

    public GameObject bullet;
    public Transform spawnPoint;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);
    }

    public void FireBullet(ActivateEventArgs arg)
    {
        GameObject spawnBullet = Instantiate(bullet);
        spawnBullet.transform.position = spawnPoint.transform.position;
        spawnBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * speed;
        Destroy(spawnBullet, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
