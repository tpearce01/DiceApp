using UnityEngine;
using System.Collections;

public class CharacterScreenManager : MonoBehaviour
{
    public GameObject newCharacterPanel;
    public GameObject loadCharacterPanel;
    private bool[] slotInUse = {false, false, false};

    public void LoadOrCreateButton()
    {
        loadCharacterPanel.SetActive(!loadCharacterPanel.activeSelf);
    }

    public void NewCharacterButton()
    {
        loadCharacterPanel.SetActive(false);
        newCharacterPanel.SetActive(!newCharacterPanel.activeSelf);
    }

    public void LoadCharacterButton()
    {
        
    }

    public class SaveData
    {
        private string name;
    }
}
