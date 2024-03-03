using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Netcode;

using Unity.Netcode;

public class NetworkAnimateHandOnInput : NetworkBehaviour
{

    public InputActionProperty pinchAnimationAction;
    public InputActionProperty gripAnimationAction;
    private Animator handAnimator;


    private void Awake()
    {
        handAnimator = GetComponent<Animator>();
    }

    void Update()
    {

        if (IsOwner)
        {
            float triigerValue = pinchAnimationAction.action.ReadValue<float>();
            handAnimator.SetFloat("Trigger", triigerValue);

            float gripValue = gripAnimationAction.action.ReadValue<float>();
            handAnimator.SetFloat("Grip", gripValue);
        }
      
    }
}
