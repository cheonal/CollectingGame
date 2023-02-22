using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptTestCs : MonoBehaviour
{
    public Text tx;
    // Start is called before the first frame update
    void Start()
    {
        List<Dictionary<string, object>> data = CSVReader.Read("Story1TEtest");

        for(var i = 0; i < data.Count; i++)
        {
            tx.text = data[i]["StoryScr"].ToString();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
