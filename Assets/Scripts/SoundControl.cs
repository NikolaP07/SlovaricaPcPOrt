using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SoundControl : MonoBehaviour
{
    public TMP_Text TextComponent;
    public AudioSource audioData;
    public string text;

    private void Start()
    {
      
    }
    public void OnPress()
    {
        audioData.Play();
        TextComponent.text += text;
    }
}
