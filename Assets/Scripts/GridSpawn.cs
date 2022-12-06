using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawn : MonoBehaviour
{
    public GameObject token;
    public string spawn;

    // Update is called once per frame
    void Start()
    {
        token = GameObject.Find("token");
    }

    void Update()
    {
        spawn = token.GetComponent<GridSystemForPersonalComputer>().spawnPoint;
    }
}
