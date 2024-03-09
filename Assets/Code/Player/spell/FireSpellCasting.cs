using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpellCasting : MonoBehaviour
{
    public Transform playerCamera;


    private void FixedUpdate()
    {
        gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, playerCamera.rotation.y, gameObject.transform.rotation.z);
        gameObject.transform.position = new Vector3(playerCamera.position.x , gameObject.transform.position.y , playerCamera.transform.position.z);
    }


}
