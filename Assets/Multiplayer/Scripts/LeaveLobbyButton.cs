using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PhotonMulpiplayer
{
    public class LeaveLobbyButton : MonoBehaviour
    {
        public void LeaveLobby()
        {
            LobbyManager.Instance().LeaveLobby();
        }
    }

}
