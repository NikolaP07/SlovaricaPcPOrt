using System;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    float ScreenWitdh;
    float ScreenHight;
    float Padding;
    public RectTransform Canavas;
    public GridLayoutGroup grid;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        ScreenWitdh = Canavas.sizeDelta.x;
        ScreenHight = Canavas.sizeDelta.y;
        //100% 100%/5 =20%;
        //padding==Scacing;
        //6* ScreenHight*0.15
        //pading==10%*ScreenHight/7
       


        Debug.Log("Screen witdh " + ScreenWitdh);
    }

    // Update is called once per frame
    void Update()
    {
        grid.cellSize = new Vector2(ScreenWitdh * 0.10f, ScreenHight * 0.15f);
        int paddingUpDown = Convert.ToInt32(ScreenHight*0.05);
        int paddingLeftRight = Convert.ToInt32(2);

        grid.padding = new RectOffset(paddingLeftRight, paddingLeftRight, paddingUpDown, paddingUpDown);
        grid.spacing = new Vector2(paddingLeftRight, paddingUpDown);


    }
}
