using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Textmanipulation : MonoBehaviour
{

    string[] azbuka = {"а","б","в","г","д","ђ","е","ж","з","и",
                       "ј","к","л","љ","м","н","њ","о","п","р",
                       "с","т","ћ","у","ф","х","ц","ч","џ","ш"};
    List<string> lista=new List<string>();
    public TMP_Text TextComponent;
    void Start()
    {
       


    }
    
    // Update is called once per frame
    void Update()
    {
       


       



    }
    public void Back()
    {
        try
        {
            int a = TextComponent.text.Length;
            string b = TextComponent.text.Substring(0, a - 1);
            TextComponent.text = b;
        }
        catch
        {

        }
    }
    public void activate()
    {
       
       

    }
    
}
