using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandCasting : MonoBehaviour
{
    public FireSpellCastingManager spellManager;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "LeftHandZone")
        {
            SpellZone spellZone = other.gameObject.GetComponent<SpellZone>();
            string ZoneName = spellZone.GetNameOfZone();
            if (ZoneName == "BaseZone")
            {
               
                spellManager.leftHandInBaseZone = true;

                
              
            }

            if (ZoneName == "FlameThrower")
            {
                spellManager.leftHandFlameThrower = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "LeftHandZone")
        {
            SpellZone spellZone = other.gameObject.GetComponent<SpellZone>();
            string ZoneName = spellZone.GetNameOfZone();
            if (ZoneName == "BaseZone")
            {

                spellManager.leftHandInBaseZone = false;
            }

            if (ZoneName == "FlameThrower")
            {
                spellManager.leftHandFlameThrower = false;
            }
        }
    }
}
