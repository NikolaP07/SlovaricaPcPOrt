
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManagment : MonoBehaviour
{
    public List<GameObject> Objects;
    public List<Transform> Leftpoints;
    public List<Transform> Rightpoints;

    // Start is called before the first frame update
    void Start()
    {
        SpawnObejct();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    void SpawnObejct()
    {
        Flying a;
        GameObject g;
        g = Objects[Random.Range(0,Objects.Count)];
        if (Random.Range(0, 1) == 1)
        {
            Debug.Log("Spawn");
            Instantiate(g, Leftpoints[Random.Range(0, Leftpoints.Count)].transform);
              
            a = g.GetComponent<Flying>();

            a.pointEnd = Rightpoints[Random.Range(0, Rightpoints.Count)];
        }
        else
        {
            
            Instantiate(g, Rightpoints[Random.Range(0, Leftpoints.Count)].transform);
            a = g.GetComponent<Flying>();

            a.pointEnd = Leftpoints[Random.Range(0, Leftpoints.Count)];
        }
        FunctionTimer.Create( ()=> { SpawnObejct(); },60);
       
    }
}
