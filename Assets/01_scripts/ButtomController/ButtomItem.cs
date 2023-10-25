using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ButtomItem : MonoBehaviour
{
    public items item;
    public TextMeshProUGUI texto;
    public Button bt;
    public Player pl;

    
    void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Cancelacion.iscancel)
        {
            switch (item)
            {
                case items.Sword:
                    if (General.sword)
                        texto.text = "espada";
                    break;
                case items.Drone:
                    if (General.drone)
                        texto.text = "Drone";
                    break;
                case items.BallEnergy:
                    if (General.ballEnergy)
                        texto.text = "bola de energia";
                    break;
                case items.Area:
                    if (General.area)
                        texto.text = "area de efuego";
                    break;
                default:
                    break;
            }
        }
       
    }
    public enum items
    {
        Sword,
        Drone,
        BallEnergy,
        Area
    }
}
