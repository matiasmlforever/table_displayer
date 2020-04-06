using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadTable : MonoBehaviour
{
    public GameObject tableContainer;
    public GameObject tablePrefab;
    public string jsonFilename;
    public string loadedJson;
    public JsonLoadedTable jsonLoadedObject;

    // Start is called before the first frame update
    void Start() 
    {
        // Add event listeners
        GetComponent<Button>().onClick.AddListener(TaskOnClick);
        LoadJson(jsonFilename);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        Debug.Log("Reloading table data...!");
        LoadJson();
    }

    private void LoadJson()
    {
        LoadJson(jsonFilename);
    }

    private void LoadJson(string jsonFilename) 
    {
        loadedJson = File.ReadAllText(Application.dataPath + "/StreamingAssets/" + jsonFilename);
        jsonLoadedObject = JsonConvert.DeserializeObject<JsonLoadedTable>(loadedJson);
        Debug.Log("breakpoint");
    }

}
