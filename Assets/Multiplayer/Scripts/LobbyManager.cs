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
        [SerializeField] int teamCount = 5;
        const int teamSize = 2;
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
            lobbyUI.InitUI(teamCount, teamSize);
            PhotonNetwork.player.SetCustomProperties(new ExitGames.Client.Photon.Hashtable() { { "isReady", false } });
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

        /// <summary>
        /// Check if all players are ready to start
        /// </summary>
        void CheckReadyStatus()
        {
            bool everyoneReady = true;
            for (int i = 0; i < PhotonNetwork.playerList.Length; i++)
            {
                PhotonPlayer player = PhotonNetwork.playerList[i];
                object ready;
                player.CustomProperties.TryGetValue("isReady", out ready);
                if (!(bool)ready)
                {
                    everyoneReady = false;
                }
            }
            if (!everyoneReady)
            {
                print("not everyone is ready");
            }
            else
            {
                print("everyone is ready");
                StartGame();
            }
        }

        /// <summary>
        /// Start loading game scene
        /// </summary>
        void StartGame()
        {
            print("game starting");
        }

        public void PlayerIsReady()
        {
            object teamId = PunTeams.Team.none;
            if ((PhotonNetwork.player.CustomProperties.TryGetValue("team", out teamId))&&(PunTeams.Team)teamId != PunTeams.Team.none)
            {
                PhotonNetwork.player.SetCustomProperties(new ExitGames.Client.Photon.Hashtable() { { "isReady", true } });
                CheckReadyStatus();
            }
            else
            {
                print("team is not assigned");
            }
        }

        /// <summary>
        /// Leave lobbby and go back to Main Menu
        /// </summary>
        public void LeaveLobby()
        {
            print("leave lobby");
            PhotonNetwork.LeaveRoom();
            PhotonNetwork.LoadLevel("MainMenu");
        }
    }
}
