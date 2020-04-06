using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadTable : MonoBehaviour
{
    public GameObject tableContainer;
    public GameObject tablePrefab, headColumnPrefab, rowPrefab, rowColumnContentPrefab;
    private GameObject table;
    public string jsonFilename;
    public string loadedJson;
    private JsonLoadedTable jsonLoadedObject;

    // Start is called before the first frame update
    void Start() 
    {
        // Add event listeners
        GetComponent<Button>().onClick.AddListener(TaskOnClick);
        LoadJson(jsonFilename);
        RefreshTable();
        Debug.Log("breakpoint");

    }

    private void FillTable(JsonLoadedTable jsonLoadedObject, GameObject table)
    {
        GameObject title = table.transform.GetChild(0).gameObject;
        GameObject head = table.transform.GetChild(1).gameObject;

        //sets title
        title.GetComponent<Text>().text = jsonLoadedObject.Title;

        //sets headers
        for (int i = 0; i < jsonLoadedObject.ColumnHeaders.Count; i++)
        {
            var temp = Instantiate(headColumnPrefab, head.transform, false);
            temp.GetComponent<Text>().text = jsonLoadedObject.ColumnHeaders[i];
        }

        //sets row(s) and its content
        foreach (var row in jsonLoadedObject.Data)
        {
            Debug.Log("fila -   ");
            var tempRow = Instantiate(rowPrefab, table.transform, false);
            foreach (KeyValuePair<string,string> item in row)
            {
                Debug.Log(item.Key + " - "+ item.Value);
                var tempRowColunmContent = Instantiate(rowColumnContentPrefab, tempRow.transform, false);
                tempRowColunmContent.GetComponent<Text>().text = item.Value;
            }
        }

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
        Destroy(table.gameObject);
        LoadJson(jsonFilename);
        RefreshTable();
    }

    private void LoadJson(string jsonFilename) 
    {
        loadedJson = File.ReadAllText(Application.dataPath + "/StreamingAssets/" + jsonFilename);
        jsonLoadedObject = JsonConvert.DeserializeObject<JsonLoadedTable>(loadedJson);
        Debug.Log("breakpoint");
    }

    private void RefreshTable()
    {
        table = Instantiate(tablePrefab, transform.parent, false);
        FillTable(jsonLoadedObject, table);
    }

}
