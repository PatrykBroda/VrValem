using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun; // Import Photon

public class AnimateHandOnInput : MonoBehaviourPun
{
    [SerializeField]
    private XRController leftController;
    [SerializeField]
    private XRController rightController;

    private Animator handAnimator;
    public PhotonView photonView;

    private void Awake()
    {
        handAnimator = GetComponent<Animator>();
        photonView = GetComponent<PhotonView>(); // Get the PhotonView component
    }

    private void Update()
    {
        // Only the local player should check their input and update animations
        if (photonView.IsMine)
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
    }

    private void UpdateHandAnimation(XRController controller, string pinchParameter, string grabParameter)
    {
        if (controller.inputDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out bool pinchValue))
        {
            photonView.RPC("UpdateAnimationState", RpcTarget.AllBuffered, pinchParameter, pinchValue ? 1f : 0f);
        }

        if (controller.inputDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out bool grabValue))
        {
            photonView.RPC("UpdateAnimationState", RpcTarget.AllBuffered, grabParameter, grabValue ? 1f : 0f);
        }
    }

    [PunRPC]
    public void UpdateAnimationState(string parameterName, float value)
    {
        // This method will be called across the network
        // Set the animator parameter based on the received values
        handAnimator.SetFloat(parameterName, value);
    }
}
