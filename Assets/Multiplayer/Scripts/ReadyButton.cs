using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PhotonMulpiplayer
{
    public class ReadyButton : MonoBehaviour
    {
        public void isReady()
        {
            LobbyManager.lobbyManager.PlayerIsReady();
        }
    }
}


