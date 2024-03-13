using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandCasting : MonoBehaviour
{
    public FireSpellCastingManager spellManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RightHandZone")
        {
            Debug.Log("rightHandIn");
            SpellZone spellZone = other.gameObject.GetComponent<SpellZone>();
            string ZoneName = spellZone.GetNameOfZone();
            if (ZoneName == "BaseZone")
            {

                spellManager.rightHandInBaseZone = true;

                
               
            }

            if (ZoneName == "FlameThrower")
            {
                spellManager.rightHandFlameThrower = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "RightHandZone")
        {
            SpellZone spellZone = other.gameObject.GetComponent<SpellZone>();
            string ZoneName = spellZone.GetNameOfZone();
            if (ZoneName == "BaseZone")
            {

                spellManager.rightHandInBaseZone = false;
            }

            if (ZoneName == "FlameThrower")
            {
                spellManager.rightHandFlameThrower = false;
            }
        }
    }
}
