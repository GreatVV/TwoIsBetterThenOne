using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PhotonMulpiplayer
{
    public class Launcher : Photon.PunBehaviour
    {
        string _gameVersion = "1";

        #region Photon.PunBehaviour CallBacks


        public override void OnConnectedToMaster()
        {
            Debug.Log("DemoAnimator/Launcher: OnConnectedToMaster() was called by PUN");
        }


        public override void OnDisconnectedFromPhoton()
        {
            Debug.LogWarning("DemoAnimator/Launcher: OnDisconnectedFromPhoton() was called by PUN");
        }


        #endregion

        
        void Awake()
        {
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
            if (PhotonNetwork.connected)
            {
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                PhotonNetwork.ConnectUsingSettings(_gameVersion);
            }
        }


    }
}
    
