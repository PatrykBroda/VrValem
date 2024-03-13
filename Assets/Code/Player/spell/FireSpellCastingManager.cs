using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpellCastingManager : MonoBehaviour
{
    public Transform playerCamera;

    public bool leftHandInBaseZone, rightHandInBaseZone;

    public bool leftHandFlameThrower, rightHandFlameThrower;

    private float timeToGetHandInBase = 2;

    private float baseTimer;

    private float timeUntilBaseIsNeededAgain = 3;

    private float nextMoveTimer;

    public GameObject flameThrowerPrefab;
    public Transform forwardSpawnPoint;

    private bool isCheckingHandMovement = false;


    private void FixedUpdate()
    {
        float y = playerCamera.transform.rotation.eulerAngles.y;
      

        gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, y, gameObject.transform.rotation.z);
        
        gameObject.transform.position = new Vector3(playerCamera.position.x , gameObject.transform.position.y , playerCamera.transform.position.z);
      

        
    }

    private void Update()
    {
        if (leftHandInBaseZone && rightHandInBaseZone && !isCheckingHandMovement)
        {
            Debug.Log("lets go");
            StartCoroutine(checkNextHandMovement());
            //search for next hand movement
        }

        if (leftHandFlameThrower && rightHandFlameThrower)
        {
            Debug.Log("Fire");
        }
    }


    private IEnumerator checkNextHandMovement()
    {
        isCheckingHandMovement = true;
        ResetBase();

        // Reset the timer at the start.
        baseTimer = 0;

        while (baseTimer <= timeUntilBaseIsNeededAgain)
        {
            baseTimer += Time.deltaTime;
            Debug.Log(baseTimer);
            if(leftHandFlameThrower && rightHandFlameThrower)
            {
                FlameThrowerAttack();
            }
            yield return null; // Wait until next frame before continuing the loop.
        }

        ResetBase();
        isCheckingHandMovement = false;
    }




    private void ResetBase()
    {
        baseTimer = 0;
    }


    
    

    private void FlameThrowerAttack()
    {
        Debug.LogError("FLAME");
        Instantiate(flameThrowerPrefab, forwardSpawnPoint.transform);
    }
}