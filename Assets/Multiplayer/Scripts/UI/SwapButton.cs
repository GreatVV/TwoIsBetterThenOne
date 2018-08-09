using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PhotonMulpiplayer
{
    public class SwapButton : MonoBehaviour
    {
        public PunTeams.Team team;

        public void Swap()
        {
            LobbyManager.lobbyManager.SwapPlayers(team);
        }
    }
}