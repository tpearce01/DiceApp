using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.UI;

public class InitiativeTrackerManager : MonoBehaviour
{
    private int currentInitiative = Int32.MaxValue;

    public class Trackable
    {
        public int initiative;
        public GameObject unitPanel;

        public Trackable(int i, GameObject p)
        {
            initiative = i;
            unitPanel = p;
        }
    }

    //Variables for Adding a new unit
    public InputField inputName;
    public InputField inputHP;
    public InputField inputInitiative;
    public GameObject addUnitPanel;

    public GameObject parentPanel;
    public GameObject unitPanelPrefab;

    //List<Trackable> trackables = new List<Trackable>();
    ArrayList trackables = new ArrayList();

    public void AddUnitButton()
    {
        addUnitPanel.SetActive(!addUnitPanel.activeSelf);
    }

    //Add a unit panel
    public void DoneButton()
    {
        if (trackables.Count < 100)
        {
            GameObject temp = Instantiate(unitPanelPrefab, parentPanel.transform) as GameObject; //Instantiate a panel
            temp.GetComponent<RectTransform>().sizeDelta = new Vector2(0, -315);
            Text[] inputFields = temp.GetComponentsInChildren<Text>(); //Get input components
            inputFields[0].text = inputName.text; //Set name text
            inputFields[1].text = inputHP.text; //Set HP text
            inputFields[2].text = inputInitiative.text; //Set initiative text
            InsertPanel(new Trackable(int.Parse(inputFields[2].text), temp));

        }

        AddUnitButton();
    }

    /*
     * Insert a new unit panel at the correct location, and shift all panels with a lower initiative down
     */ 
    public void InsertPanel(Trackable t)
    {
        List<Trackable> temp = new List<Trackable>();
        bool found = false;
        for (int i = 0; i < trackables.Count; i++)
        {
            if (!found && t.initiative > ((Trackable) trackables[i]).initiative)
            {
                trackables.Insert(i, t);
                t.unitPanel.GetComponent<RectTransform>().transform.localPosition = new Vector3(0, 115 - i*40, 0);

                found = true;
            }
            else if (found)
            {
                ((Trackable)trackables[i]).unitPanel.GetComponent<RectTransform>().transform.localPosition = new Vector3(0, 115 - i * 40, 0);
            }
        }
        if (!found)
        {
            t.unitPanel.GetComponent<RectTransform>().transform.localPosition = new Vector3(0, 115 - trackables.Count * 40, 0);
            trackables.Add(t);
        }
    }

    public void NextTurn()
    {
        Trackable toMove = (Trackable)trackables[0];    //Store previous top initiative
        trackables.RemoveAt(0);                         //and remove it from the top of list
        trackables.Add(toMove);                         //then add it to the end of the list
        
        SetPanelLocations();
        
    }


    public void RemoveUnit(Trackable t)
    {
        for (int i = 0; i < trackables.Count; i++)
        {
            if (((Trackable) trackables[i]).unitPanel == t.unitPanel)
            {
                trackables.RemoveAt(i);
                break;
            }
        }
        Destroy(t.unitPanel);
        SetPanelLocations();
    }

    public void SetPanelLocations()
    {
        for (int i = 0; i < trackables.Count; i++)
        {
            ((Trackable)trackables[i]).unitPanel.GetComponent<RectTransform>().transform.localPosition = new Vector3(0, 115 - i * 40, 0);
        }
    }
}
