using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] Text statusText;
    [SerializeField] Button joinLobbyButton;
    [SerializeField] Button createLobbyButton;
    [SerializeField] GameObject lobbyPanel;

    //Think if I really need this function//////////////////////////////////////////////////////
	public void Connect()
    {
        joinLobbyButton.interactable = true;
        createLobbyButton.interactable = true;
        statusText.text = "Connected";
    }

    /// <summary>
    /// Initialize UI
    /// </summary>
    public void Init()
    {
        if (PhotonNetwork.connectionState!=ConnectionState.Connected)
        {
            joinLobbyButton.interactable = false;
            createLobbyButton.interactable = false;
            statusText.text = "Connecting...";
        }
        else
        {
            joinLobbyButton.interactable = true;
            createLobbyButton.interactable = true;
            statusText.text = "Connected";
        }
        
        lobbyPanel.SetActive(false);
    }
}
