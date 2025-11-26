using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Flying : MonoBehaviour
{
    
    public Transform pointEnd;
    private int Speed = 50;
      
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, pointEnd.position, Speed*Time.deltaTime);
        if(Vector2.Distance(transform.position,pointEnd.position)<=0)
        {
            Destroy(gameObject);
        }

    }
}
