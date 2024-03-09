using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpellCasting : MonoBehaviour
{
    public Transform playerCamera;

    private int handInBaseZone = 0;

    private float timeUntilNeedingBase = 3;
    private float baseTimer;

    private void FixedUpdate()
    {
        float y = playerCamera.transform.rotation.eulerAngles.y;
        Debug.Log(y);

        gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, y, gameObject.transform.rotation.z);
        
        gameObject.transform.position = new Vector3(playerCamera.position.x , gameObject.transform.position.y , playerCamera.transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "LeftHandZone")
        {
            SpellZone spellZone = other.gameObject.GetComponent<SpellZone>();
            string ZoneName = spellZone.GetNameOfZone();
            if( ZoneName == "BaseZone")
            {
                InitStartSpell();
                handInBaseZone++;
            }
        }

        if (other.gameObject.tag == "RightHandZone")
        {
            SpellZone spellZone = other.gameObject.GetComponent<SpellZone>();
            string ZoneName = spellZone.GetNameOfZone();
            if (ZoneName == "BaseZone")
            {
                InitStartSpell();
                handInBaseZone++;
            }
        }
    }

    private IEnumerator InitStartSpell()
    {
        while (baseTimer < timeUntilNeedingBase)
        {
            baseTimer += Time.deltaTime;
            if(handInBaseZone == 2)
            {

            }
        }

        ResetBase();
        yield return null;
    }

    private void ResetBase()
    {
        baseTimer = 0;
        handInBaseZone = 0;
    }

}