using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LiveButton : MonoBehaviour
{
    // Start is called before the first frame update

    private IEnumerator coroutine;
    private float StartScale, StartScaleEnter, StartScaleExit, TempCo = 1f, TempCoDecriaseLarger = 1f;
    public Texture2D CursorEnter, CursorExit;

    private void ChangeCursor(bool bOver)
    {
        if (bOver)
        {
            Cursor.SetCursor(CursorEnter, Vector2.zero, CursorMode.ForceSoftware);
        }
        else
        {
            Cursor.SetCursor(CursorExit, Vector2.zero, CursorMode.ForceSoftware);
        }
    }

    void playSound(string NameSound)
    {
        AudioSource[] AS = gameObject.GetComponents<AudioSource>();
        AS[0].Play();
    }

    public IEnumerator ScaleUI(float delta, float SmallerScale, float LargerScale) //Изменение размера поля
    {
        Vector3 TempScale;
        Vector3 TempScaleConst = gameObject.transform.localScale;
        while (SmallerScale < LargerScale)
        {
            TempCo += delta;
            TempCoDecriaseLarger += System.Math.Abs(delta);
            TempScale = TempScaleConst * TempCo;
            gameObject.transform.localScale = TempScale;
            LargerScale -= TempScaleConst.x * System.Math.Abs(delta);
            yield return new WaitForSeconds(0.00001f);
        }

    }

    void OnMouseEnter()
    {
        ChangeCursor(true);
        StartScaleEnter = gameObject.transform.localScale.x;
        TempCo = 1f;
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = ScaleUI(0.005f, StartScaleEnter, StartScale * 1.1f);
        StartCoroutine(coroutine);
    }

    void OnMouseExit()
    {
        ChangeCursor(false);
        StartScaleExit = gameObject.transform.localScale.x;
        TempCo = 1f;
        StopCoroutine(coroutine);
        coroutine = ScaleUI(-0.005f, StartScale, StartScaleExit);
        StartCoroutine(coroutine);
    }

    void Start()
    {
        ChangeCursor(false);
        StartScale = gameObject.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
