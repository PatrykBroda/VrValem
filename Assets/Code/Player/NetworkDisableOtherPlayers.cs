using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System.Linq;
using RootMotion.FinalIK;

public class NetworkDisableOtherPlayers : NetworkBehaviour
{
    private List<GameObject> Players = new List<GameObject>();

    private void Awake()
    {
        if (IsOwner)
        {
            findAllOtherPlayers();
        }
    }

    private void findAllOtherPlayers()
    {
        int layer = LayerMask.NameToLayer("Player");

        // Find all game objects in the scene, then filter them by layer
        // Also, exclude the current game object from the results
        GameObject[] objectsWithLayer = FindObjectsOfType<GameObject>()
                                            .Where(go => go.layer == layer && go != this.gameObject)
                                            .ToArray();

        // Example usage: iterate through the found objects and disable the VRIK component
        foreach (var obj in objectsWithLayer)
        {
            Debug.Log("Found object: " + obj.name);
            // Assuming VRIK is a type of MonoBehaviour that you want to disable
            var vrikComponents = obj.GetComponentsInChildren<VRIK>(true); // true to include inactive children
            foreach (var vrik in vrikComponents)
            {
                Debug.LogError(vrik.gameObject.name);
                vrik.enabled = false; // Disable the VRIK component
            }
        }
    }
}

// Note: Replace 'VRIK' with the actual type name of your VRIK script/component
