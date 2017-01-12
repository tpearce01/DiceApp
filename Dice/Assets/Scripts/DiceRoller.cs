using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DiceRoller : MonoBehaviour
{
    public GameObject macroPanel;

    public Text resultText;
    public Text previousRollText;

    private Macro macro1 = new Macro();
    private Macro macro2 = new Macro();
    
    public Button macro1Button;
    public Button macro2Button;

    private byte activeMacro = 1;

    public Dropdown d4Dropdown;
    public Dropdown d6Dropdown;
    public Dropdown d8Dropdown;
    public Dropdown d10Dropdown;
    public Dropdown d12Dropdown;
    public Dropdown d20Dropdown;

    //private Queue<int> lastRoll = new Queue<int>();

    void Start()
    {
        //Create a list of numbers 1-30 to add to each dropdown
        System.Collections.Generic.List<Dropdown.OptionData> options = new System.Collections.Generic.List<Dropdown.OptionData>();
        for (int i = 0; i < 31; i++)
        {
            options.Add(new Dropdown.OptionData(i.ToString()));
        }

        //Clear existing dropdown options
        d4Dropdown.ClearOptions();
        d6Dropdown.ClearOptions();
        d8Dropdown.ClearOptions();
        d10Dropdown.ClearOptions();
        d12Dropdown.ClearOptions();
        d20Dropdown.ClearOptions();

        //Add numbers 1-30 as options to all dropdown menus
        d4Dropdown.AddOptions(options);
        d6Dropdown.AddOptions(options);
        d8Dropdown.AddOptions(options);
        d10Dropdown.AddOptions(options);
        d12Dropdown.AddOptions(options);
        d20Dropdown.AddOptions(options);

        SelectMacro1();

    }

    //Roll 1 d4
    public void d4()
    {
        resultText.text = Random.Range(1, 5).ToString();
        previousRollText.text = "1d4";
    }

    //Roll 1d6
    public void d6()
    {
        resultText.text = Random.Range(1, 7).ToString();
        previousRollText.text = "1d6";
    }

    //Roll 1d8
    public void d8()
    {
        resultText.text = Random.Range(1, 9).ToString();
        previousRollText.text = "1d8";
    }

    //Roll 1d10
    public void d10()
    {
        resultText.text = Random.Range(1, 11).ToString();
        previousRollText.text = "1d10";
    }

    //Roll 1d12
    public void d12()
    {
        resultText.text = Random.Range(1, 13).ToString();
        previousRollText.text = "1d12";
    }

    //Roll 1d20
    public void d20()
    {
        resultText.text = Random.Range(1, 21).ToString();
        previousRollText.text = "1d20";
    }

    public void d100()
    {
        resultText.text = Random.Range(1, 101).ToString();
        previousRollText.text = "1d100";
    }

    //Roll macro1
    public void macro1Roll()
    {
        previousRollText.text = "";
        int total = 0;

        for (int i = 0; i < macro1.d4; i++)
        {
            total += Random.Range(1, 5);
        }
        if (macro1.d4 > 0)
        {
            previousRollText.text += macro1.d4 + "d4";
        }

        for (int i = 0; i < macro1.d6; i++)
        {
            total += Random.Range(1, 7);
        }
        if (macro1.d6 > 0)
        {
            if (previousRollText.text.Length > 0)
            {
                previousRollText.text += " + ";
            }
            previousRollText.text += macro1.d6 + "d6";
        }

        for (int i = 0; i < macro1.d8; i++)
        {
            total += Random.Range(1, 9);
        }
        if (macro1.d8 > 0)
        {
            if (previousRollText.text.Length > 0)
            {
                previousRollText.text += " + ";
            }
            previousRollText.text += macro1.d8 + "d8";
        }

        for (int i = 0; i < macro1.d10; i++)
        {
            total += Random.Range(1, 11);
        }
        if (macro1.d10 > 0)
        {
            if (previousRollText.text.Length > 0)
            {
                previousRollText.text += " + ";
            }
            previousRollText.text += macro1.d10 + "d10";
        }

        for (int i = 0; i < macro1.d12; i++)
        {
            total += Random.Range(1, 13);
        }
        if (macro1.d12 > 0)
        {
            if (previousRollText.text.Length > 0)
            {
                previousRollText.text += " + ";
            }
            previousRollText.text += macro1.d12 + "d12";
        }

        //Modifier
        total += macro1.d20;
        if (macro1.d20 > 0)
        {
            if (previousRollText.text.Length > 0)
            {
                previousRollText.text += " + ";
            }
            previousRollText.text += macro1.d20;
        }

        resultText.text = total.ToString();
    }

    //Roll macro2
    public void macro2Roll()
    {
        previousRollText.text = "";
        int total = 0;

        for (int i = 0; i < macro2.d4; i++)
        {
            total += Random.Range(1, 5);
        }
        if (macro2.d4 > 0)
        {
            previousRollText.text += macro2.d4 + "d4";
        }

        for (int i = 0; i < macro2.d6; i++)
        {
            total += Random.Range(1, 7);
        }
        if (macro2.d6 > 0)
        {
            if (previousRollText.text.Length > 0)
            {
                previousRollText.text += " + ";
            }
            previousRollText.text += macro2.d6 + "d6";
        }

        for (int i = 0; i < macro2.d8; i++)
        {
            total += Random.Range(1, 9);
        }
        if (macro2.d8 > 0)
        {
            if (previousRollText.text.Length > 0)
            {
                previousRollText.text += " + ";
            }
            previousRollText.text += macro2.d8 + "d8";
        }

        for (int i = 0; i < macro2.d10; i++)
        {
            total += Random.Range(1, 11);
        }
        if (macro2.d10 > 0)
        {
            if (previousRollText.text.Length > 0)
            {
                previousRollText.text += " + ";
            }
            previousRollText.text += macro2.d10 + "d10";
        }

        for (int i = 0; i < macro2.d12; i++)
        {
            total += Random.Range(1, 13);
        }
        if (macro2.d12 > 0)
        {
            if (previousRollText.text.Length > 0)
            {
                previousRollText.text += " + ";
            }
            previousRollText.text += macro2.d12 + "d12";
        }

        //Modifier
        total += macro2.d20;
        if (macro2.d20 > 0)
        {
            if (previousRollText.text.Length > 0)
            {
                previousRollText.text += " + ";
            }
            previousRollText.text += macro2.d20;
        }

        resultText.text = total.ToString();
    }

    //Toggle the macro panel
    public void EditMacro()
    {
        macroPanel.SetActive(!macroPanel.activeSelf);
    }

    //Save the values of the currently selected macro
    public void SaveMacro()
    {
        if (activeMacro == 1)
        {
            macro1.d4 = d4Dropdown.value;
            macro1.d6 = d6Dropdown.value;
            macro1.d8 = d8Dropdown.value;
            macro1.d10 = d10Dropdown.value;
            macro1.d12 = d12Dropdown.value;
            macro1.d20 = d20Dropdown.value;
        }
        else
        {
            macro2.d4 = d4Dropdown.value;
            macro2.d6 = d6Dropdown.value;
            macro2.d8 = d8Dropdown.value;
            macro2.d10 = d10Dropdown.value;
            macro2.d12 = d12Dropdown.value;
            macro2.d20 = d20Dropdown.value;
        }

        Debug.Log(macro1.d4);
        Debug.Log(macro1.d6);
        Debug.Log(macro1.d8);
        Debug.Log(macro1.d10);
        Debug.Log(macro1.d12);
        Debug.Log(macro1.d20);

        macroPanel.SetActive(!macroPanel.activeSelf);
    }

    void ButtonSelected(Button b)
    {
        b.image.color = Color.cyan;
    }

    void ButtonUnselected(Button b)
    {
        b.image.color = Color.white;
    }

    public void SelectMacro1()
    {
        activeMacro = 1;
        ButtonSelected(macro1Button);
        ButtonUnselected(macro2Button);
        d4Dropdown.value = macro1.d4;
        d6Dropdown.value = macro1.d6;
        d8Dropdown.value = macro1.d8;
        d10Dropdown.value = macro1.d10;
        d12Dropdown.value = macro1.d12;
        d20Dropdown.value = macro1.d20;
    }

    public void SelectMacro2()
    {
        activeMacro = 2;
        ButtonSelected(macro2Button);
        ButtonUnselected(macro1Button);
        d4Dropdown.value = macro2.d4;
        d6Dropdown.value = macro2.d6;
        d8Dropdown.value = macro2.d8;
        d10Dropdown.value = macro2.d10;
        d12Dropdown.value = macro2.d12;
        d20Dropdown.value = macro2.d20;
    }

    public void ReturnToHomeScene()
    {
        SceneManager.LoadScene("home_scene");
    }
}
