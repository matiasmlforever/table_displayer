using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadTable : MonoBehaviour
{
    public GameObject tableContainer;

    // Start is called before the first frame update
    void Start() 
    {
        // Add event listeners
        this.GetComponent<Button>().onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
    }

}
