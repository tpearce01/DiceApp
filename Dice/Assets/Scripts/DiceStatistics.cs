using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Assertions.Comparers;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DiceStatistics : MonoBehaviour
{
    public Dropdown modifierDropdown;
    public Dropdown valueToBeatDropdown;
    public Dropdown advantageDropdown;
    public Text resultText;

    private int modifierDropdownOffset = -10;

    void Start()
    {
        modifierDropdown.ClearOptions();
        valueToBeatDropdown.ClearOptions();

        System.Collections.Generic.List<Dropdown.OptionData> options = new System.Collections.Generic.List<Dropdown.OptionData>();

        for (int i = -10; i < 31; i++)
        {
            if (i > 0)
            {
                options.Add(new Dropdown.OptionData("+" + i.ToString()));
            }
            else
            {
                options.Add(new Dropdown.OptionData(i.ToString()));
            }
        }

        modifierDropdown.AddOptions(options);
        modifierDropdown.value = -modifierDropdownOffset;
        options.Clear();

        for (int i = 0; i < 40; i++)
        {
            options.Add(new Dropdown.OptionData(i.ToString()));
        }

        valueToBeatDropdown.AddOptions(options);
        valueToBeatDropdown.value = 10;
    }

    public void Calculate()
    {
        resultText.text = "I have a " + string.Format("{0:0.0}", PercentToBeat()*100) + "% chance to roll at least a " + valueToBeatDropdown.value;
    }

    private float PercentToBeat()
    {
        int result = valueToBeatDropdown.value - (modifierDropdown.value + modifierDropdownOffset); //Example Calculation: ValueToBeat = 24, Modifier = +8, Result = 24 - 8 = 16

        //Advantage Example: Result = 16, Returns .437 (43.7%)
        //Normal Example: Result = 16, Returns .250 (25.0%)
        //Disadvantage Example: Result = 16, Returns .062 (6.2%)
        switch (advantageDropdown.value)
        {
            case 2:
                return GetDisdvantage(result);
            case 1:
                return GetNormal(result);
            case 0:
                return GetAdvantage(result);
            default:
                throw new System.ArgumentException("Advantage Value Error. Value: " + advantageDropdown.value);
        }
    }

    float GetAdvantage(int value)
    {
        switch (value)
        {
            case 1:
                return 1.0f;
            case 2:
                return .998f;
            case 3:
                return .990f;
            case 4:
                return .978f;
            case 5:
                return .960f;
            case 6:
                return .938f;
            case 7:
                return .910f;
            case 8:
                return .877f;
            case 9:
                return .840f;
            case 10:
                return .798f;
            case 11:
                return .751f;
            case 12:
                return .698f;
            case 13:
                return .639f;
            case 14:
                return .576f;
            case 15:
                return .510f;
            case 16:
                return .437f;
            case 17:
                return .359f;
            case 18:
                return .278f;
            case 19:
                return .191f;
            case 20:
                return .098f;
            default:
                if (value < 1)
                {
                    return 1.0f;
                }
                else
                {
                    return 0f;
                }
        }
    }

    float GetDisdvantage(int value)
    {
        switch (value)
        {
            case 1:
                return 1.0f;
            case 2:
                return .903f;
            case 3:
                return .811f;
            case 4:
                return .723f;
            case 5:
                return .640f;
            case 6:
                return .564f;
            case 7:
                return .492f;
            case 8:
                return .424f;
            case 9:
                return .361f;
            case 10:
                return .303f;
            case 11:
                return .249f;
            case 12:
                return .202f;
            case 13:
                return .160f;
            case 14:
                return .123f;
            case 15:
                return .089f;
            case 16:
                return .062f;
            case 17:
                return .039f;
            case 18:
                return .022f;
            case 19:
                return .010f;
            case 20:
                return .002f;
            default:
                if (value < 1)
                {
                    return 1.0f;
                }
                else
                {
                    return 0f;
                }
        }
    }

    float GetNormal(int value)
    {
        switch (value)
        {
            case 1:
                return 1.00f;
            case 2:
                return .950f;
            case 3:
                return .900f;
            case 4:
                return .850f;
            case 5:
                return .800f;
            case 6:
                return .750f;
            case 7:
                return .700f;
            case 8:
                return .650f;
            case 9:
                return .600f;
            case 10:
                return .550f;
            case 11:
                return .500f;
            case 12:
                return .450f;
            case 13:
                return .400f;
            case 14:
                return .350f;
            case 15:
                return .300f;
            case 16:
                return .250f;
            case 17:
                return .200f;
            case 18:
                return .150f;
            case 19:
                return .100f;
            case 20:
                return .050f;
            default:
                if (value < 1)
                {
                    return 1.0f;
                }
                else
                {
                    return 0f;
                }
        }
    }
}
