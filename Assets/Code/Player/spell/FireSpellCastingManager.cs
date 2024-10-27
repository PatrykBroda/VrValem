using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpellCastingManager : MonoBehaviour
{
    // Reference to the player's camera
    public Transform playerCamera;

    // Flags to indicate if hands are in the base zone
    public bool leftHandInBaseZone, rightHandInBaseZone;

    // Flags to indicate if hands are holding the flamethrower
    public bool leftHandFlameThrower, rightHandFlameThrower;

    // Prefab for the flamethrower effect
    public GameObject flameThrowerPrefab;

    // Spawn point for the flamethrower
    public Transform forwardSpawnPoint;

    // Configuration for the flamethrower
    public FireConfiguration flamethrowerConfig;

    // FixedUpdate adjusts the position and rotation to match the player's camera
    private void FixedUpdate()
    {
        // Align the object's Y rotation with the player's camera
        float y = playerCamera.transform.rotation.eulerAngles.y;
        gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, y, gameObject.transform.rotation.z);

        // Align the object's X and Z position with the player's camera, keep Y position unchanged
        gameObject.transform.position = new Vector3(playerCamera.position.x, gameObject.transform.position.y, playerCamera.transform.position.z);
    }

    // Update is called once per frame
    private void Update()
    {
        // Check if both hands are in the base zone and are holding flamethrowers
        if (leftHandInBaseZone && rightHandInBaseZone && leftHandFlameThrower && rightHandFlameThrower)
        {
            Debug.LogError("[FireSpellCastingManager] Both hands are in the base zone and holding flamethrowers. Casting FlameThrower.");
            FlameThrowerAttack();
        }
    }

    // Method to handle the flamethrower attack
    private void FlameThrowerAttack()
    {
        Debug.LogError("[FireSpellCastingManager] FLAME! Casting FlameThrower.");

        // Instantiate the flamethrower prefab at the forward spawn point
        GameObject fire = Instantiate(flameThrowerPrefab, forwardSpawnPoint.position, forwardSpawnPoint.rotation);

        // Optionally, you can set the parent if needed
        // fire.transform.parent = forwardSpawnPoint;

        // Schedule the destruction of the flamethrower prefab after its lifetime
        Destroy(fire, flamethrowerConfig.ProjectileLifeTime);
    }

    // Optional: Handle OnTriggerExit if needed
    private void OnTriggerExit(Collider other)
    {
        // You can add logic here if you need to handle when a hand leaves the base zone
        // For example, resetting flags or stopping ongoing spells
        Debug.Log($"[FireSpellCastingManager] OnTriggerExit called by: {other.gameObject.name} on layer {LayerMask.LayerToName(other.gameObject.layer)}");
    }
}
