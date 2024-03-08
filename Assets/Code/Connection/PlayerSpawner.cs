using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    public List<Transform> spawnPoints = new List<Transform>();

    private void Start()
    {
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        // Ensure there is a playerPrefab assigned and there are spawn points available
        if (playerPrefab == null || spawnPoints.Count == 0)
        {
            Debug.LogError("Player prefab or spawn points not assigned.");
            return;
        }

        // Choose a spawn point based on the player's Photon ActorNumber to avoid spawn point conflicts
        int spawnIndex = (PhotonNetwork.LocalPlayer.ActorNumber - 1) % spawnPoints.Count;
        Transform spawnPoint = spawnPoints[spawnIndex];

        // Instantiate the player object for the local player
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, spawnPoint.rotation);
    }
}
