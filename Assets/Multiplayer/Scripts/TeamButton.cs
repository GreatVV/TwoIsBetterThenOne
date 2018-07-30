using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamButton : MonoBehaviour
{
    public PunTeams.Role role;
    public PunTeams.Team team;
    PhotonPlayer assignedPlayer;
    Image image;

    void Start()
    {
        image = GetComponent<Image>();
    }

    public void UpdateButton(PhotonPlayer player)
    {
        assignedPlayer = player;

        if (assignedPlayer != null)
        {
            image.color = Color.red;
        }
        else
        {
            image.color = Color.green;
        }
    }


}
