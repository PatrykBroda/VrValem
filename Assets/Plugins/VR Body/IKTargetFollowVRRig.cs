using UnityEngine;

[System.Serializable]
public class VRMap
{
    public Transform vrTarget;
    public Transform ikTarget;
    public Vector3 trackingPositionOffset;
    public Vector3 trackingRotationOffset;

    public void Map()
    {
        // Directly mapping position and rotation with offsets
        ikTarget.position = vrTarget.TransformPoint(trackingPositionOffset);
        ikTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset);
    }
}

public class IKTargetFollowVRRig : MonoBehaviour
{
    [Range(0, 1)]
    public float turnSmoothness = 0.1f;
    public VRMap head;
    public VRMap leftHand;
    public VRMap rightHand;

    private float smoothedYaw = 0f;
    // Removed headBodyPositionOffset application to the parent object to prevent unintended movements
    // public Vector3 headBodyPositionOffset;
    // public float headBodyYawOffset;

    void LateUpdate()
    {
        head.Map();
        leftHand.Map();
        rightHand.Map();

        // Calculate target yaw from VR target, potentially smoothing it
        float targetYaw = head.vrTarget.eulerAngles.y;

        // Smooth the transition of the yaw value to prevent abrupt changes
        smoothedYaw = Mathf.LerpAngle(smoothedYaw, targetYaw, turnSmoothness);

        // Apply the smoothed yaw to the parent object
        Quaternion targetRotation = Quaternion.Euler(0, smoothedYaw, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSmoothness);
    }
}
