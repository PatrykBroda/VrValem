using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInput : MonoBehaviour
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
       float triigerValue = pinchAnimationAction.action.ReadValue<float >();
        handAnimator.SetFloat("Trigger", triigerValue);

        float gripValue = gripAnimationAction.action.ReadValue<float >();
        handAnimator.SetFloat("Grip", gripValue);
    }
}
