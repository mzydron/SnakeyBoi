using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SnakeScript : MonoBehaviour
{


    Vector2 dir = new Vector2(0.01f,0);
    
    List<Transform> tail = new List<Transform>();

    bool ate = false;
    bool gameOver = false;

    public GameObject tailPrefab;

    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Move", 0.15f, 0.15f);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.RightArrow))
            dir = new Vector2(0.01f, 0);
        else if (Input.GetKey(KeyCode.DownArrow))
            dir = new Vector2(0, -0.01f);
        else if (Input.GetKey(KeyCode.LeftArrow))
            dir = new Vector2(-0.01f, 0);
        else if (Input.GetKey(KeyCode.UpArrow))
            dir = new Vector2(0, 0.01f); 
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.StartsWith("FoodPrefab"))
        {
            ate = true;
            Destroy(collision.gameObject);
        }
        else
        {
            GameObject[] go = UnityEngine.Object.FindObjectsOfType<GameObject>();
            foreach(GameObject gobj in go)
            if (gobj.name.StartsWith("FoodPrefab"))
                {
                    Destroy(gobj);
                }
            gameOver = true;
        }
    }

    void Move()
    {
        Vector2 v = transform.position;
        transform.Translate(dir);

        if (tail.Count > 0)
        {
            tail.Last().position = v;

            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);

        }

        if (ate)
        {
            GameObject g = (GameObject)Instantiate(tailPrefab, v, Quaternion.identity);
            tail.Insert(0, g.transform);
            ate = false;
        }

        if (gameOver)
        {
            dir = new Vector2(0, 0);
            tail = new List<Transform>();
            gameOver = false;
        }
    }

}
