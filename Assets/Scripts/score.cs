using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class score : MonoBehaviour
{
    public static int gems;
    Text txt;
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        gems = 0;
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = gems.ToString();
    }
}
