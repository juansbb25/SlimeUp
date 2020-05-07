using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public int maxchilds;
    public GameObject clone;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int childs = transform.childCount;

        if (childs < maxchilds)
        {
            Instantiate(clone, transform);
        }
    }
}
