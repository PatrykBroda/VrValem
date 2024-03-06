using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VrRigRefernces : MonoBehaviour
{

    public static VrRigRefernces Singleton;

    public Transform root;
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;


    private void Awake()
    {
        Singleton = this;
    }

}
