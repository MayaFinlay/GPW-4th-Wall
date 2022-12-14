using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawn : MonoBehaviour
{
    public GameObject token;

    public GameObject projectile;

    public string spawn;
    public List<GameObject> snapPoints = new List<GameObject>();
    public List<GameObject> ScreenGrid = new List<GameObject>();



    // Update is called once per frame
    void Start()
    {
        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("SnapPoints"))
        {
            snapPoints.Add(fooObj);
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "SnapPoints")
        {
            col.gameObject.tag = "SnapPointsBlacklist";
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "SnapPointsBlacklist")
        {
            col.gameObject.tag = "SnapPoints";
        }
    }

    void Update()
    {

        spawn = token.GetComponent<GridSystemForPersonalComputer>().spawnPoint;

            switch (spawn)
            {
                case "(0,0)":
                    transform.position = snapPoints[80].transform.position;
                    break;
                case "(1,0)":
                    transform.position = snapPoints[79].transform.position;
                    break;
                case "(2,0)":
                    transform.position = snapPoints[78].transform.position;
                    break;
                case "(3,0)":
                    transform.position = snapPoints[77].transform.position;
                    break;
                case "(4,0)":
                    transform.position = snapPoints[76].transform.position;
                    break;
                case "(5,0)":
                    transform.position = snapPoints[75].transform.position;
                    break;
                case "(6,0)":
                    transform.position = snapPoints[74].transform.position;
                    break;
                case "(7,0)":
                    transform.position = snapPoints[73].transform.position;
                    break;
                case "(8,0)":
                    transform.position = snapPoints[72].transform.position;
                    break;
                case "(0,1)":
                    transform.position = snapPoints[71].transform.position;
                    break;
                case "(1,1)":
                    transform.position = snapPoints[70].transform.position;
                    break;
                case "(2,1)":
                    transform.position = snapPoints[69].transform.position;
                    break;
                case "(3,1)":
                    transform.position = snapPoints[68].transform.position;
                    break;
                case "(4,1)":
                    transform.position = snapPoints[67].transform.position;
                    break;
                case "(5,1)":
                    transform.position = snapPoints[66].transform.position;
                    break;
                case "(6,1)":
                    transform.position = snapPoints[65].transform.position;
                    break;
                case "(7,1)":
                    transform.position = snapPoints[64].transform.position;
                    break;
                case "(8,1)":
                    transform.position = snapPoints[63].transform.position;
                    break;
                case "(0,2)":
                    transform.position = snapPoints[62].transform.position;
                    break;
                case "(1,2)":
                    transform.position = snapPoints[61].transform.position;
                    break;
                case "(2,2)":
                    transform.position = snapPoints[60].transform.position;
                    break;
                case "(3,2)":
                    transform.position = snapPoints[59].transform.position;
                    break;
                case "(4,2)":
                    transform.position = snapPoints[58].transform.position;
                    break;
                case "(5,2)":
                    transform.position = snapPoints[57].transform.position;
                    break;
                case "(6,2)":
                    transform.position = snapPoints[56].transform.position;
                    break;
                case "(7,2)":
                    transform.position = snapPoints[55].transform.position;
                    break;
                case "(8,2)":
                    transform.position = snapPoints[54].transform.position;
                    break;
                case "(0,3)":
                    transform.position = snapPoints[53].transform.position;
                    break;
                case "(1,3)":
                    transform.position = snapPoints[52].transform.position;
                    break;
                case "(2,3)":
                    transform.position = snapPoints[51].transform.position;
                    break;
                case "(3,3)":
                    transform.position = snapPoints[50].transform.position;
                    break;
                case "(4,3)":
                    transform.position = snapPoints[49].transform.position;
                    break;
                case "(5,3)":
                    transform.position = snapPoints[48].transform.position;
                    break;
                case "(6,3)":
                    transform.position = snapPoints[47].transform.position;
                    break;
                case "(7,3)":
                    transform.position = snapPoints[46].transform.position;
                    break;
                case "(8,3)":
                    transform.position = snapPoints[45].transform.position;
                    break;
                case "(0,4)":
                    transform.position = snapPoints[44].transform.position;
                    break;
                case "(1,4)":
                    transform.position = snapPoints[43].transform.position;
                    break;
                case "(2,4)":
                    transform.position = snapPoints[42].transform.position;
                    break;
                case "(3,4)":
                    transform.position = snapPoints[41].transform.position;
                    break;
                case "(4,4)":
                    transform.position = snapPoints[40].transform.position;
                    break;
                case "(5,4)":
                    transform.position = snapPoints[39].transform.position;
                    break;
                case "(6,4)":
                    transform.position = snapPoints[38].transform.position;
                    break;
                case "(7,4)":
                    transform.position = snapPoints[37].transform.position;
                    break;
                case "(8,4)":
                    transform.position = snapPoints[36].transform.position;
                    break;
                case "(0,5)":
                    transform.position = snapPoints[35].transform.position;
                    break;
                case "(1,5)":
                    transform.position = snapPoints[34].transform.position;
                    break;
                case "(2,5)":
                    transform.position = snapPoints[33].transform.position;
                    break;
                case "(3,5)":
                    transform.position = snapPoints[32].transform.position;
                    break;
                case "(4,5)":
                    transform.position = snapPoints[31].transform.position;
                    break;
                case "(5,5)":
                    transform.position = snapPoints[30].transform.position;
                    break;
                case "(6,5)":
                    transform.position = snapPoints[29].transform.position;
                    break;
                case "(7,5)":
                    transform.position = snapPoints[28].transform.position;
                    break;
                case "(8,5)":
                    transform.position = snapPoints[27].transform.position;
                    break;
                case "(0,6)":
                    transform.position = snapPoints[26].transform.position;
                    break;
                case "(1,6)":
                    transform.position = snapPoints[25].transform.position;
                    break;
                case "(2,6)":
                    transform.position = snapPoints[24].transform.position;
                    break;
                case "(3,6)":
                    transform.position = snapPoints[23].transform.position;
                    break;
                case "(4,6)":
                    transform.position = snapPoints[22].transform.position;
                    break;
                case "(5,6)":
                    transform.position = snapPoints[21].transform.position;
                    break;
                case "(6,6)":
                    transform.position = snapPoints[20].transform.position;
                    break;
                case "(7,6)":
                    transform.position = snapPoints[19].transform.position;
                    break;
                case "(8,6)":
                    transform.position = snapPoints[18].transform.position;
                    break;
                case "(0,7)":
                    transform.position = snapPoints[17].transform.position;
                    break;
                case "(1,7)":
                    transform.position = snapPoints[16].transform.position;
                    break;
                case "(2,7)":
                    transform.position = snapPoints[15].transform.position;
                    break;
                case "(3,7)":
                    transform.position = snapPoints[14].transform.position;
                    break;
                case "(4,7)":
                    transform.position = snapPoints[13].transform.position;
                    break;
                case "(5,7)":
                    transform.position = snapPoints[12].transform.position;
                    break;
                case "(6,7)":
                    transform.position = snapPoints[11].transform.position;
                    break;
                case "(7,7)":
                    transform.position = snapPoints[10].transform.position;
                    break;
                case "(8,7)":
                    transform.position = snapPoints[9].transform.position;
                    break;
                case "(0,8)":
                    transform.position = snapPoints[8].transform.position;
                    break;
                case "(1,8)":
                    transform.position = snapPoints[7].transform.position;
                    break;
                case "(2,8)":
                    transform.position = snapPoints[6].transform.position;
                    break;
                case "(3,8)":
                    transform.position = snapPoints[5].transform.position;
                    break;
                case "(4,8)":
                    transform.position = snapPoints[4].transform.position;
                    break;
                case "(5,8)":
                    transform.position = snapPoints[3].transform.position;
                    break;
                case "(6,8)":
                    transform.position = snapPoints[2].transform.position;
                    break;
                case "(7,8)":
                    transform.position = snapPoints[1].transform.position;
                    break;
                case "(8,8)":
                    transform.position = snapPoints[0].transform.position;
                    break;
            }
        

            
    }


}

