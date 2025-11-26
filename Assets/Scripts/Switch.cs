using UnityEngine;
using TMPro;
public class Switch : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI text;
    private bool cirilica;
    public GameObject Cirilica;
    public GameObject Latinica;
    void Start()
    {
        cirilica = true;
        Zamena();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Zamena()
    {
        if (cirilica)
        {
            text.text = "ćirilica-azbuka";
            cirilica = false;
            Cirilica.SetActive(true);
            Latinica.SetActive(false);
        }
        else
        {
            cirilica = true;
            text.text = "latinica-abeceda";
            Cirilica.SetActive(false);
            Latinica.SetActive(true);
        }
    }
}
