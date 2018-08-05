using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PhotonMulpiplayer
{
    public class Launcher : Photon.PunBehaviour
    {
        string _gameVersion = "1";
       // [SerializeField] Button joinButton;
        [SerializeField] MainMenuUI menuUI;


        #region Photon.PunBehaviour CallBacks


        public override void OnConnectedToMaster()
        {
            Debug.Log("OnConnectedToMaster() was called by PUN");
            //PhotonNetwork.JoinRandomRoom();
        }


        public override void OnDisconnectedFromPhoton()
        {
            Debug.LogWarning(" OnDisconnectedFromPhoton() was called by PUN");
        }

        public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
        {
            // Debug.Log("OnPhotonRandomJoinFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom();");
            Debug.Log("OnPhotonRandomJoinFailed() was called by PUN. No random room available");

        }

        public override void OnJoinedRoom()
        {
            Debug.Log("OnJoinedRoom() called by PUN. Now this client is in a room.");
            PhotonNetwork.LoadLevel("Lobby");
        }


        public override void OnConnectedToPhoton()
        {
            Debug.Log("Connected to Photon");
            menuUI.Connect();
            //joinButton.interactable = true;
        }

        #endregion


        void Awake()
        {
            menuUI.Init();
            PhotonNetwork.autoJoinLobby = false;

            PhotonNetwork.automaticallySyncScene = true;
        }

      
        void Start()
        {
            Connect();
        }

        /// <summary>
        /// Start the connection process.
        /// </summary>
        public void Connect()
        {
            if (!PhotonNetwork.connected)
            {
                PhotonNetwork.ConnectUsingSettings(_gameVersion);
            }
        }

        public void JoinRoom()
        {
            if (PhotonNetwork.connected)
            {
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                PhotonNetwork.ConnectUsingSettings(_gameVersion);
            }
        }

        public void CreateRoom()
        {
            PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = 10 }, null);
        }

    }
}
    
