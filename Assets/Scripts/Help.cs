using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Help : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        GameObject.Find("Popup").GetComponent<MeshRenderer>().enabled = true;
        foreach (Transform child in GameObject.Find("Popup").transform)
        {
            child.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    void OnMouseExit()
    {
        GameObject.Find("Popup").GetComponent<MeshRenderer>().enabled = false;
        foreach (Transform child in GameObject.Find("Popup").transform)
        {
            child.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
