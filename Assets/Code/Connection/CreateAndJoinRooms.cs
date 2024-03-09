using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public InputField createInput;
    public InputField joinInput;

    public GameObject playerPrefab; // Assign this in the Unity Inspector
    public Transform[] spawnPoints;

    private void Start()
    {
       // SpawnPlayer();
    }

    void SpawnPlayer()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            // Choose a spawn point based on the player's actor number to avoid spawning players too close together
            Transform spawnPoint = spawnPoints[PhotonNetwork.LocalPlayer.ActorNumber % spawnPoints.Length];

            // Instantiate the player across the network
            PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, spawnPoint.rotation);
        }
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text, new Photon.Realtime.RoomOptions { MaxPlayers = 4 }); // Example max players set to 4
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    /// <summary>
    /// use this for joining any room 
    /// </summary>
    public void QuickJoin()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Arena");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("No available rooms, creating a new room.");
        CreateRoomWithRandomName();
    }

    void CreateRoomWithRandomName()
    {
        // Generate a random room name
        string roomName = "Room_" + Random.Range(1000, 9999);
        PhotonNetwork.CreateRoom(roomName, new Photon.Realtime.RoomOptions { MaxPlayers = 4 }); // Adjust MaxPlayers as needed
    }
}
