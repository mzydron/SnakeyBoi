using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    // Start is called before the first frame update

    // Prefabs
    public GameObject foodPrefab;

    // Borders
    public Transform bTop;
    public Transform bBottom;
    public Transform bLeft;
    public Transform bRight;

    void Spawn()
    {
        float x = Random.Range(bLeft.position.x, bRight.position.x);

        float y = Random.Range(bBottom.position.y, bTop.position.y);

        Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity);


    }

    void Start()
    {
        InvokeRepeating("Spawn", 3, 4);
    }

}
