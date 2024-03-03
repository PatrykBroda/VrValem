using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class NetworkPlayer : NetworkBehaviour
{
    public Transform root;
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;

    public Renderer[] meshToDisable;

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        if (IsOwner)
        {
            foreach (var item in meshToDisable)
            {
                item.enabled = false;

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOwner)
        {
            root.position = VrRigRefernces.Singleton.root.position;
            root.rotation = VrRigRefernces.Singleton.root.rotation;

            head.position = VrRigRefernces.Singleton.head.position;
            head.rotation = VrRigRefernces.Singleton.head.rotation;

            leftHand.position = VrRigRefernces.Singleton.leftHand.position;
            leftHand.rotation = VrRigRefernces.Singleton.leftHand.rotation;

            rightHand.position = VrRigRefernces.Singleton.rightHand.position;
            rightHand.rotation = VrRigRefernces.Singleton.rightHand.rotation;
        }
       

    }
}
