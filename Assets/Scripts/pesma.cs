using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class pesma : MonoBehaviour
{
  
    [SerializeField] List<Image> lista;
    [SerializeField] List<Sprite> ListaSlike;
    [SerializeField] List<Sprite> ListaSlovaISLike;
    [SerializeField] List<Sprite> ListaSlova;
    [SerializeField]  TextMeshProUGUI text;
    [SerializeField] TextMeshProUGUI textZaZadataSlova;
    public AudioSource As;
    bool zapoceto = false;
    private string zadatoSlovo="";
    private bool pogodioSlovo = false;
    private bool ZapocetoPOgadjanje = false;
    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
       foreach(Image image in lista)
        {
            image.sprite = ListaSlike[i];
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ZapocetoPOgadjanje)
            IspitajTacnost(textZaZadataSlova.text);
    }
    int brojilac = 0;
  public  void Zasvetli()
    {
        try
        {
            if (brojilac > 0)
            {
                lista[brojilac - 1].color = Color.white;
            }
            lista[brojilac].color = Color.yellow;
        
            brojilac++;
            if (brojilac > 29)
            {
                brojilac = 0;
                FunctionTimer.Create(() =>
                {
                    foreach (Image a in lista)
                    {
                        a.color = Color.white;
                    }
                }, 1);
                zapoceto = false;
                return;

            }
            if (brojilac < 20)
            {
                FunctionTimer.Create(() => Zasvetli(), 0.35f);
            }
            else if (brojilac > 25)
            {
                FunctionTimer.Create(() => Zasvetli(), 0.25f);
            }
            else
            {
                FunctionTimer.Create(() => Zasvetli(), 0.25f);
            }
        }
        catch
        {

        }
    }
    public void Mod1()
    {
        int j = 0;
        foreach (Image image in lista)
        {
            image.sprite = ListaSlike[j];
            j++;
        }
    }public void Mod2()
    {
        int k = 0;
        foreach (Image image in lista)
        {
            image.sprite = ListaSlovaISLike[k];
            k++;
        }
    }
    public void Mod3()
    {
        int d = 0;
        foreach (Image image in lista)
        {
            image.sprite = ListaSlova[d];
            d++;
        }
    }
    public void Zapocni()
    {
        if (!zapoceto)
        {
            FunctionTimer.Create(() => Zasvetli(), 7f);
            As.Play();
            zapoceto = true;
        }
    }
    int posloSlovo = 0;
    int selectedSlovo = 0;
    public void ZasvetliOdredjenoSlovo(string a)
    {
        Debug.Log(a);
        switch (a)
        {
            case "MODE 2":
                int k = 0;
                foreach (Image image in lista)
                {
                    image.sprite = ListaSlovaISLike[k];
                    k++;
                }
                break;
            case "MODE 1":
                int j = 0;
                foreach (Image image in lista)
                {
                    image.sprite = ListaSlike[j];
                    j++;
                }
                break;
            case "MODE 3":
                int d = 0;
                foreach (Image image in lista)
                {
                    image.sprite = ListaSlova[d];
                    d++;
                }
                break;
            case "D":
                if (selectedSlovo < 20)
                    selectedSlovo += 10;
                else
                    selectedSlovo -= 20;
                break;
            case "U":
                if (selectedSlovo > 10)
                    selectedSlovo -= 10;
                else
                    selectedSlovo += 20;

                break;
            case "L":
                if (selectedSlovo > -1)
                    selectedSlovo--;
                else
                    selectedSlovo = 29;
                break;
            case "R":
                if (selectedSlovo < 29)
                    selectedSlovo++;
                else
                    selectedSlovo = 0;
                break;
            case "P":
                cujSlovo();
                break;


        }
        
          
        



            lista[selectedSlovo].color = Color.yellow;
        if (selectedSlovo == posloSlovo)
        {

        }
        else
        {
            lista[posloSlovo].color = Color.white;
            posloSlovo = selectedSlovo;
        }


        }
    public void ZadajSlovo()
    {
        ZapocetoPOgadjanje = true;
        textZaZadataSlova.text = textZaZadataSlova.text;
        FunctionTimer.Create(() => { ZapocetoPOgadjanje = false; }, 30f);

    }
    public void cujSlovo()
    {
        
        lista[posloSlovo].GetComponent<SoundControl>().OnPress();
    }
    public void IspitajTacnost(string a)
    {
        
        if (text.text == a)
        {
            //win
            foreach (Image image in lista)
            {
                image.color = Color.green;
            }
            FunctionTimer.Create(() => {
                foreach (Image image in lista)
                {
                    image.color = Color.white;
                }
            }, 1f);
        }
        else
        {
            //lose
            foreach (Image image in lista)
            {
                image.color = Color.red;
            }
            FunctionTimer.Create(() => {
                foreach (Image image in lista)
                {
                    image.color = Color.white;
                }
            }, 1f);
        }
    }




}
