using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonLoadedTable
{

    private string title;
    private List<string> columnHeaders;
    private List<Dictionary<string, string>> data;

    public string Title { get => title; set => title = value; }
    public List<string> ColumnHeaders { get => columnHeaders; set => columnHeaders = value; }
    public List<Dictionary<string, string>> Data { get => data; set => data = value; }
}
