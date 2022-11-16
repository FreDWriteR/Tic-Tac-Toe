using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emission_X : MonoBehaviour
{
    // Start is called before the first frame update
    //Color ColorOption;
    //public bool bEndChangeColor = false;
    //public GameObject Camera;

    //public IEnumerator ChangeColor(float color1, float color2, float color3) //»зменение цвета пол¤ после ответа игрока и перед возвращением в стартовое состо¤ние
    //{
    //    float c_olor1 = gameObject.GetComponent<MeshRenderer>().material.GetColor("_EmissionColor").r;
    //    float c_olor2 = gameObject.GetComponent<MeshRenderer>().material.GetColor("_EmissionColor").g;
    //    float c_olor3 = gameObject.GetComponent<MeshRenderer>().material.GetColor("_EmissionColor").b;
    //    ColorOption = gameObject.GetComponent<MeshRenderer>().material.GetColor("_EmissionColor");
    //    yield return new WaitForSeconds(0.1f);
    //    float t = 0f;
    //    while (ColorOption.r != color1 || ColorOption.g != color2 || ColorOption.b != color3)
    //    {
    //        ColorOption.r = Mathf.Lerp(c_olor1, color1, t);
    //        ColorOption.g = Mathf.Lerp(c_olor2, color2, t);
    //        ColorOption.b = Mathf.Lerp(c_olor3, color3, t);

    //        gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", ColorOption);
    //        t += 0.02f;
    //        yield return new WaitForSeconds(0.01f);
    //    }
    //    bEndChangeColor = true;
    //}

    //public IEnumerator BlinkTicTac()
    //{
        
    //    yield return new WaitForSeconds(0.01f);
    //}

    void Start()
    {
       // ChangeColor();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;
        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        if (hit.collider.gameObject.name == "X")
        //        {
        //            //ChangeColor()


        //            return;
        //        }
        //        else if (hit.collider.gameObject.name == "Zero")
        //        {

        //        }
        //    }
        //}
    }
}
