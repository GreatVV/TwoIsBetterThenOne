using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PhotonMulpiplayer
{
    public class FreePlayerList : MonoBehaviour
    {
        List<PhotonPlayer> players;
        [SerializeField] Text text;


        void Awake()
        {
            players = new List<PhotonPlayer>();
        }


        /// <summary>
        /// Update list of players without team
        /// </summary>
        public void UpdatePlayerList()
        {
            string list = "";
            for (int i = 0; i < PhotonNetwork.playerList.Length; i++)
            {
                PhotonPlayer player = PhotonNetwork.playerList[i];
                PunTeams.Team team = player.GetTeam();
                if (team == PunTeams.Team.none)
                {
                    //players.Add(player);
                    list += "\n" + player.NickName;
                }
            }

            text.text = list;
        }
    }

}
