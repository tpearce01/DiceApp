using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreateCharacter : MonoBehaviour
{
    public InputField name;
    public InputField level;
    public InputField hp;
    public InputField ac;
    public InputField strInput;
    public InputField dexInput;
    public InputField conInput;
    public InputField intInput;
    public InputField wisInput;
    public InputField chaInput;

    public GameObject newCharacterPanel;
    public GameObject proficienciesPanel;
    public GameObject statsPanel;

    public Text mainName;
    public Text mainLevel;
    public Text mainAC;
    public Text mainHP;
    public GameObject[] mainStatPanel;

    private int selectedSaveSlot;

    private Character slot1 = new Character();
    private Character slot2 = new Character();
    private Character slot3 = new Character();

    public void NextButton()
    {
        statsPanel.SetActive(!statsPanel.activeSelf);
    }

    public void SaveCharacter()
    {
        switch (selectedSaveSlot)
        {
            case 1:
                slot1 = new Character(name.text, Int32.Parse(level.text), Int32.Parse(hp.text), Int32.Parse(ac.text),
                    Int32.Parse(strInput.text), Int32.Parse(dexInput.text), Int32.Parse(conInput.text),
                    Int32.Parse(intInput.text), Int32.Parse(wisInput.text), Int32.Parse(chaInput.text));
                break;
            case 2:
                slot2 = new Character(name.text, Int32.Parse(level.text), Int32.Parse(hp.text), Int32.Parse(ac.text),
                    Int32.Parse(strInput.text), Int32.Parse(dexInput.text), Int32.Parse(conInput.text),
                    Int32.Parse(intInput.text), Int32.Parse(wisInput.text), Int32.Parse(chaInput.text));
                break;
            case 3:
                slot3 = new Character(name.text, Int32.Parse(level.text), Int32.Parse(hp.text), Int32.Parse(ac.text),
                    Int32.Parse(strInput.text), Int32.Parse(dexInput.text), Int32.Parse(conInput.text),
                    Int32.Parse(intInput.text), Int32.Parse(wisInput.text), Int32.Parse(chaInput.text));
                break;
            default:
                throw new Exception("Fatal Error when creating character. Data not saved.");
        }

        newCharacterPanel.SetActive(false);
        proficienciesPanel.SetActive(false);
        statsPanel.SetActive(false);
    }

    public void SaveSlot1()
    {
        selectedSaveSlot = 1;
        newCharacterPanel.SetActive(true);
    }

    public void SaveSlot2()
    {
        selectedSaveSlot = 2;
        newCharacterPanel.SetActive(true);
    }

    public void SaveSlot3()
    {
        selectedSaveSlot = 3;
        newCharacterPanel.SetActive(true);
    }

    public void UpdateCharacterData()
    {
        Character temp;

        switch (selectedSaveSlot)
        {
            case 1:
                temp = slot1;
                break;
            case 2:
                temp = slot2;
                break;
            case 3:
                temp = slot3;
                break;
            default:
                throw new Exception("Fatal Error when loading character data. Data not loaded");
        }

        mainName.text = temp.name;
        mainLevel.text = "Level " + temp.level;
        mainAC.text = "AC " + temp.ac;
        mainHP.text = "HP " + temp.hp;

        /*
         * !@!@!@!@!@!@@!@!@!@!@!@!@!@!@!@
         * SAMPLE FOR STRENGTH PANEL - NOT TESTED, NEED TO COMPLETE ALL OTHER PANELS
         */ 
        Text[] data = mainStatPanel[0].GetComponentsInChildren<Text>();
        data[1].text = GetModifier(temp.strength);
        data[2].text = temp.strength.ToString();
        data[3].text = (temp.GetValue(temp.skills[(int) SkillAsInt.StrSave]) >= 0)
            ? "+" + temp.GetValue(temp.skills[(int) SkillAsInt.StrSave])
            : temp.GetValue(temp.skills[(int) SkillAsInt.StrSave]).ToString();
    }

    public string GetModifier(int value)
    {
        int temp = value - 10;
        temp /= 2;
        if (temp >= 0)
        {
            return "+" + temp;
        }
        else
        {
            return temp.ToString();
        }
    }
}
