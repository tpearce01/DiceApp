using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UnitPanel : MonoBehaviour
{
    public Text name;
    public Text hp;
    public Text initiative;

    private InitiativeTrackerManager initiativeScript;

    void Start()
    {
        initiativeScript = GameObject.Find("EventSystem").GetComponent<InitiativeTrackerManager>();
    }

    public void IncrementHP()
    {
        hp.text = (int.Parse(hp.text) + 1).ToString();
    }

    public void DecrementHP()
    {
        hp.text = (int.Parse(hp.text) - 1).ToString();
    }

    public void RemoveUnit()
    {
        initiativeScript.RemoveUnit(new InitiativeTrackerManager.Trackable(Int32.Parse(initiative.text), gameObject));
    }

}
