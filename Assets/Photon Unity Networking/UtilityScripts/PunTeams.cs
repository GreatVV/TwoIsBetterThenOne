using System;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;


/// <summary>
/// Implements teams in a room/game with help of player properties. Access them by PhotonPlayer.GetTeam extension.
/// </summary>
public class PunTeams : MonoBehaviour
{
    PhotonMulpiplayer.LobbyUI lobbyUI;
    /// <summary>Enum defining the teams available. First team should be neutral (it's the default value any field of this enum gets).</summary>
    public enum Team : byte {none, red, blue,yellow,orange,green};
    public enum Role : byte { none,driver,shooter};

    /// <summary>The main list of teams with their player-lists. Automatically kept up to date.</summary>
    /// <remarks>Note that this is static. Can be accessed by PunTeam.PlayersPerTeam. You should not modify this.</remarks>
    public static Dictionary<Team, List<PhotonPlayer>> PlayersPerTeam;
    
    public const string TeamPlayerProp = "team";
    public const string RolePlayerProp = "role";


    #region Events by Unity and Photon

    public void Start()
    {
        lobbyUI = GetComponent<PhotonMulpiplayer.LobbyUI>();
        PlayersPerTeam = new Dictionary<Team, List<PhotonPlayer>>();
        Array enumVals = Enum.GetValues(typeof (Team));
        foreach (var enumVal in enumVals)
        {
            PlayersPerTeam[(Team)enumVal] = new List<PhotonPlayer>();
        }
    }

	public void OnDisable()
	{
		PlayersPerTeam = new Dictionary<Team, List<PhotonPlayer>>();
	}

    /// <summary>Needed to update the team lists when joining a room.</summary>
    /// <remarks>Called by PUN. See enum PhotonNetworkingMessage for an explanation.</remarks>
    public void OnJoinedRoom()
    {
        this.UpdateTeams();
    }

	public void OnLeftRoom()
	{
		Start();
	}

    /// <summary>Refreshes the team lists. It could be a non-team related property change, too.</summary>
    /// <remarks>Called by PUN. See enum PhotonNetworkingMessage for an explanation.</remarks>
    public void OnPhotonPlayerPropertiesChanged(object[] playerAndUpdatedProps)
    {
        this.UpdateTeams();
    }

	public void OnPhotonPlayerDisconnected(PhotonPlayer otherPlayer)
	{
		this.UpdateTeams();
	}

	public void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
	{
		this.UpdateTeams();
	}

    #endregion

    /// <summary>
    /// Swap player roles in a team. Only works if there are both players in a team.
    /// </summary>
    /// <param name="team"></param>
    public void SwapPlayers(Team team)
    {
        List<PhotonPlayer> players = PlayersPerTeam[team];

        if (players.Count < 2)
            return;

        Role role = players[0].GetRole();
        players[0].SetRole(players[1].GetRole());
        players[1].SetRole(role);
    }

    /// <summary>
    /// Swap roles for players in a team
    /// </summary>
    public void UpdateTeams()
    {
        Array enumVals = Enum.GetValues(typeof(Team));
        foreach (var enumVal in enumVals)
        {
            PlayersPerTeam[(Team)enumVal].Clear();
        }

        for (int i = 0; i < PhotonNetwork.playerList.Length; i++)
        {
            PhotonPlayer player = PhotonNetwork.playerList[i];
            Team playerTeam = player.GetTeam();
            PlayersPerTeam[playerTeam].Add(player);
          
        }

        lobbyUI.UpdateUI();
    }


    public bool JoinTeam(PhotonPlayer currentPlayer, Team team,Role role)
    {
        bool positionAvailable = true;
        for (int i = 0; i < PhotonNetwork.playerList.Length; i++)
        {
            PhotonPlayer player = PhotonNetwork.playerList[i];
            if ((player.GetTeam()==team)&&(player.GetRole()==role))
            {
                positionAvailable = false;
            }
        }

        if (positionAvailable)
        {
            currentPlayer.SetTeam(team);
            currentPlayer.SetRole(role);
            UpdateTeams();
            return true;
        }
   
        return false;
    }
}

/// <summary>Extension used for PunTeams and PhotonPlayer class. Wraps access to the player's custom property.</summary>
public static class TeamExtensions
{
    /// <summary>Extension for PhotonPlayer class to wrap up access to the player's custom property.</summary>
    /// <returns>PunTeam.Team.none if no team was found (yet).</returns>
    public static PunTeams.Team GetTeam(this PhotonPlayer player)
    {
        object teamId;
        if (player.CustomProperties.TryGetValue(PunTeams.TeamPlayerProp, out teamId))
        {
            return (PunTeams.Team)teamId;
        }

        return PunTeams.Team.none;
    }


    /// <summary>Switch that player's team to the one you assign.</summary>
    /// <remarks>Internally checks if this player is in that team already or not. Only team switches are actually sent.</remarks>
    /// <param name="player"></param>
    /// <param name="team"></param>
    public static void SetTeam(this PhotonPlayer player, PunTeams.Team team)
    {
        if (!PhotonNetwork.connectedAndReady)
        {
            Debug.LogWarning("JoinTeam was called in state: " + PhotonNetwork.connectionStateDetailed + ". Not connectedAndReady.");
            return;
        }

        PunTeams.Team currentTeam = player.GetTeam();
        if (currentTeam != team)
        {
            player.SetCustomProperties(new Hashtable() {{PunTeams.TeamPlayerProp, (byte) team}});
        }
    }


    public static PunTeams.Role GetRole(this PhotonPlayer player)
    {
        object role;
        if (player.CustomProperties.TryGetValue(PunTeams.RolePlayerProp, out role))
        {
            return (PunTeams.Role)role;
        }

        return PunTeams.Role.none;
    }


    /// <summary>Switch that player's team to the one you assign.</summary>
    /// <remarks>Internally checks if this player is in that team already or not. Only team switches are actually sent.</remarks>
    /// <param name="player"></param>
    /// <param name="team"></param>
    public static void SetRole(this PhotonPlayer player, PunTeams.Role role)
    {
        if (!PhotonNetwork.connectedAndReady)
        {
            Debug.LogWarning("JoinTeam was called in state: " + PhotonNetwork.connectionStateDetailed + ". Not connectedAndReady.");
            return;
        }

        PunTeams.Role currentRole = player.GetRole();
        if (currentRole != role)
        {
            player.SetCustomProperties(new Hashtable() { { PunTeams.RolePlayerProp, (byte)role } });
        }
    }
    

}