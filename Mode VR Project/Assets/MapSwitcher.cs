using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Serialization;
using System.Xml.Serialization;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Valve.VR;

public class MapSwitcher : MonoBehaviour
{
    public MapData[] maps;
    public int currentMap;

    public Image mapImage;
    public Text mapText;

    public SteamVR_Input_Sources interactHand;
    public SteamVR_Action_Boolean interactButton;
    public SteamVR_Action_Boolean mapChangeButton;
    public SteamVR_Action_Vector2 mapChangeValue;
    // Start is called before the first frame update
    void Awake()
    {
        LoadData();
    }

    public void Update()
    {
        if(mapChangeButton.GetStateDown(interactHand) && Mathf.RoundToInt(mapChangeValue.axis.x) != 0)
        {
            UpdateMapShown(Mathf.RoundToInt(mapChangeValue.axis.x));
        }
    }

    [System.Serializable]
    public struct MapData
    {
        public Sprite mapIcon;
        public string mapName;
    }

    public void SaveData()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(int));
        FileStream stream = new FileStream(Application.dataPath + "/Assets/SaveData/MapSaveData", FileMode.Create);
        serializer.Serialize(stream, currentMap);
        stream.Close();
    }
    public void LoadData()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(int));
        FileStream stream = new FileStream(Application.dataPath + "/Assets/SaveData/MapSaveData", FileMode.OpenOrCreate);
        currentMap = (int)serializer.Deserialize(stream);
        stream.Close();
    }
    public void Initialize()
    {
        mapImage.sprite = maps[currentMap].mapIcon;
        mapText.text = maps[currentMap].mapName;
    }
    public void UpdateMapShown(int modifyValue)
    {
        currentMap += modifyValue;
        if(currentMap >= maps.Length)
        {
            currentMap = 0;
        }
        else
        {
            if(currentMap < 0)
            {
                currentMap = maps.Length - 1;
            }
        }

        Initialize();
    }
    public void LoadMap()
    {
        SceneManager.LoadScene(maps[currentMap].mapName);
    }
}
