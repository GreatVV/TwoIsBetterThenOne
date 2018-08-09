using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PhotonMulpiplayer
{
    public class TeamButton : MonoBehaviour
    {
        public PunTeams.Role role;
        public PunTeams.Team team;
        public PhotonPlayer assignedPlayer;
        Image image;
        Text text;

        void Awake()
        {
            image = GetComponent<Image>();
            text = GetComponentInChildren<Text>();
            assignedPlayer = null;
        }

        /// <summary>
        /// Update button color and text
        /// </summary>
        public void UpdateButton()
        {
            assignedPlayer = null;
            for (int i = 0; i < PhotonNetwork.playerList.Length; i++)
            {
                PhotonPlayer player = PhotonNetwork.playerList[i];
                PunTeams.Team playerTeam = player.GetTeam();
                PunTeams.Role playerRole = player.GetRole();

                if ((playerTeam == team)&&(playerRole == role))
                {
                    assignedPlayer = player;
                    break;
                }
            }
            
            if (assignedPlayer != null)
            {
                image.color = Color.red;
                text.text = assignedPlayer.NickName;
            }
            else
            {
                image.color = Color.green;
                text.text = "<empty>";
            }
        }

        /// <summary>
        /// Try to assign player to the current team and role
        /// </summary>
        public void TryAssignPlayer()
        {
            if (assignedPlayer == null)
            {
                LobbyManager.Instance().TryAssignPlayer(PhotonNetwork.player, team, role);
            }
        }
    }
}
