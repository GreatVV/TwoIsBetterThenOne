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

        public void SetPlayer(PhotonPlayer player, int teamId,int position)
        {
            RemovePlayer(player);
            teams[teamId, position] = player;
            UpdateTeams();
        }

        public void RemovePlayer(PhotonPlayer player)
        {
            for (int i = 0; i < teamCount; i++)
            {
                for (int j = 0; j < teamSize; j++)
                {
                    if (player==teams[i,j])
                    {
                        teams[i, j] = null;
                    }
                }
            }
            UpdateTeams();
        }

        void UpdateTeams()
        {

        }

        public int GetTeamId()
        {
            teamIdCount++;

            return teamIdCount;
        }
    }
}
