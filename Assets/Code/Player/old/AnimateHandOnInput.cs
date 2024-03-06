using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AnimateHandOnInput : MonoBehaviour
{
    [SerializeField]
    private XRController leftController;
    [SerializeField]
    private XRController rightController;

    private Animator handAnimator;

    private void Awake()
    {
        handAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (leftController != null)
        {
            UpdateHandAnimation(leftController, "LeftPinch", "LeftGrab");
        }

        if (rightController != null)
        {
            UpdateHandAnimation(rightController, "RightPinch", "RightGrab");
        }
    }

    private void UpdateHandAnimation(XRController controller, string pinchParameter, string grabParameter)
    {
        // Assuming your animator has parameters for pinch and grab as per the image you've shown
        if (controller.inputDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out bool pinchValue))
        {
            handAnimator.SetBool(pinchParameter, pinchValue);
           
        }

        if (controller.inputDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out bool grabValue))
        {
            handAnimator.SetBool(grabParameter, grabValue);
        }

        // You can also map the analog values of the grip and trigger if needed
        // For example, if you want to use the analog grip strength instead of a boolean pressed/released state
        if (controller.inputDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.grip, out float gripStrength))
        {
            handAnimator.SetFloat(grabParameter, gripStrength);
            Debug.Log(grabParameter);
        }

        if (controller.inputDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.trigger, out float triggerStrength))
        {
            handAnimator.SetFloat(pinchParameter, triggerStrength);
            Debug.Log(pinchParameter);
        }
    }
}
