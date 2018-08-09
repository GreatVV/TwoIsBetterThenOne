using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace PhotonMulpiplayer
{
    public class LobbyUI : MonoBehaviour
    {
        [SerializeField] GameObject teamButtonPrefab;
        TeamButton[][] teamButtons;
        [SerializeField] FreePlayerList playerList;
        [SerializeField] Button leaveButton;
        int teamCount;
        int teamSize;

        /// <summary>
        /// Initialize UI with given parameters
        /// </summary>
        /// <param name="teamCount"></param>
        /// <param name="teamSize"></param>
        public void InitUI(int teamCount, int teamSize)
        {
            this.teamCount = teamCount;
            this.teamSize = teamSize;
            teamButtons = new TeamButton[teamCount][];
            for (int i = 0; i < teamCount; i++)
            {
                GameObject obj = Instantiate(teamButtonPrefab, this.transform);
                TeamButton[] teams = obj.GetComponentsInChildren<TeamButton>();
                teams[0].team = (PunTeams.Team)(i + 1);
                teams[1].team = (PunTeams.Team)(i + 1);
                teams[0].role = PunTeams.Role.driver;
                teams[1].role = PunTeams.Role.shooter;

                SwapButton swap = obj.GetComponentInChildren<SwapButton>();
                swap.team = (PunTeams.Team)(i + 1);

                teamButtons[i] = teams;
            }

            UpdateUI();
        }

        /// <summary>
        /// Update all Team Buttons and list of free players
        /// </summary>
        public void UpdateUI()
        {
            for (int i = 0; i < teamCount; i++)
            {
                for (int j = 0; j < teamSize; j++)
                {
                    teamButtons[i][j].UpdateButton();
                }
            }
            playerList.UpdatePlayerList();
        }
    }
}
