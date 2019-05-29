using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SimManager : MonoBehaviour
{
    public EventSystem startEvents;
    public bool instantLoad;
    // Start is called before the first frame update
    void Start()
    {
        if (instantLoad)
        {
            LoadMap("SampleScene");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadMap(string mapName)
    {
        print("SWITCHED");
        SceneManager.LoadScene(mapName);
    }
}
