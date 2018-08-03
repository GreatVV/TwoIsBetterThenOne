using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PlayerRole { Driver, Shooter };

namespace PhotonMulpiplayer
{
    public class LobbyManager : MonoBehaviour
    {
        public static LobbyManager lobbyManager;
        int teamIdCount = -1;
        [SerializeField] int teamCount = 5;
        const int teamSize = 2;
        PhotonPlayer[,] teams;
        [SerializeField] LobbyUI lobbyUI;
        [SerializeField] PunTeams punTeams;


        void Awake()
        {
            if (lobbyManager != null)
                Debug.Log("There are two or more lobby managers on the scene");

            lobbyManager = this;
        }

        void Start()
        {
            teams = new PhotonPlayer[teamCount, teamSize];
            lobbyUI.InitUI(teamCount, teamSize);
        }

        public static LobbyManager Instance()
        {
            if (lobbyManager == null)
                lobbyManager = GameObject.Find("LobbyManager").GetComponent<LobbyManager>();

            if (lobbyManager == null)
                Debug.Log("There is no lobby manager on the scene");

            return lobbyManager;
        }

        public void TryAssignPlayer(PhotonPlayer player, PunTeams.Team team, PunTeams.Role role)
        {
            punTeams.JoinTeam(player, team, role);
        }

        public void SwapPlayers(PunTeams.Team team)
        {
            punTeams.SwapPlayers(team);
        }
        
    }
}
