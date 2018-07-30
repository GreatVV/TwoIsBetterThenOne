using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUI : MonoBehaviour
{
    [SerializeField] GameObject teamButtonPrefab;
	
	public void InitUI(int teamCount, int teamSize)
    {
        for (int i=0;i<teamCount;i++)
        {
            Instantiate(teamButtonPrefab, this.transform);
        }
    }

    public void UpdateUI()
    {

    }
}
