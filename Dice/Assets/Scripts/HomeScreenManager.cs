using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HomeScreenManager : MonoBehaviour {

    void Start()
    {
        Screen.SetResolution(320, 568, true);
    }

    public void LoadDiceRollerScene()
    {
        SceneManager.LoadScene("dice_scene");
    }

    public void LoadCharacterSheetScene()
    {
        SceneManager.LoadScene("character_scene");
    }

    public void LoadInitiativeTrackerScene()
    {
        SceneManager.LoadScene("initiative_scene");
    }

    public void LoadStatsScene()
    {
        SceneManager.LoadScene("stats_scene");
    }

    public void LoadSpellsScene()
    {
        SceneManager.LoadScene("spells_scene");
    }
}
