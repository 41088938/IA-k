using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Liting : MonoBehaviour
{
    //[SerializeField] private GameObject light;
    [SerializeField] private float speed=1;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right * Time.deltaTime*speed);//if rataionx>180=night
    }
}
