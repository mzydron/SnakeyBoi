using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public int score; 

    // Start is called before the first frame update
    void Start()
    {
        score = 0;    
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Text>().text = "Score: " + score.ToString();
        //var StatementText = textTransform.GetComponent<Text>();
    }
}
