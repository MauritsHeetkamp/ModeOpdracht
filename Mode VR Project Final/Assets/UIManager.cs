using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class UIManager : MonoBehaviour
{
    public GameObject mapSwitcher;
    public SteamVR_Input_Sources mapSwitcherSource;
    public SteamVR_Action_Boolean mapSwitcherButton;

    // Update is called once per frame
    void Update()
    {
        if (mapSwitcherButton.GetStateDown(mapSwitcherSource))
        {
            mapSwitcher.SetActive(!mapSwitcher.activeSelf);
        }
    }
}
