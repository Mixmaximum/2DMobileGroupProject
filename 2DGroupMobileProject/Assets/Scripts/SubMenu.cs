using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMenu : MonoBehaviour
{
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Canvas2()
    {
        canvas.GetComponent<Canvas>().enabled = true;
        GetComponent<Canvas>().enabled = false;
    }
}
