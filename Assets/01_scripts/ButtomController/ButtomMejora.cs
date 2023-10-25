using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ButtomMejora : MonoBehaviour
{
    public Player pl;
    public TextMeshProUGUI text;
    public Player.Mejoras upgrade;
    public Button bt;
    public bool mejora;
    public bool lista;
    void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        upgrade = Player.Mejoras.damagedron;
        //Debug.Log("Hola mamahuevoi");
    }

    // Update is called once per frame
    void Update()
    {
        while (!mejora)
        {
            int i = Random.Range(1, 6);
            switch (i)
            {
                case 1:
                    upgrade = Player.Mejoras.SwordVelocity;
                    break;
                case 2:
                    upgrade = Player.Mejoras.dronextra;
                    break;
                case 3:
                    upgrade = Player.Mejoras.velocitydron;
                    break;
                case 4:
                    upgrade = Player.Mejoras.damagedron;
                    break;
                case 5:
                    upgrade = Player.Mejoras.damageSword;
                    break;
                default:
                    break;
            }
            mejora = true;

            if (pl.drones[pl.drones.Count - 1].activeSelf && i == 2)
            {
                mejora = false;
            }
        }
        switch (upgrade)
        {
            case Player.Mejoras.SwordVelocity:
                
                if (!lista)
                {
                    text.text = "Armadura nivel " + General.armaduraLvl;
                    bt.onClick.AddListener(ArmorLvlUp);
                    lista = true;
                }
                    
                break;
            case Player.Mejoras.dronextra:
                
                if (!lista)
                {
                    text.text = "+1 dron";
                    bt.onClick.AddListener(DronExtra);
                    lista = true;
                }
                    
                break;
            case Player.Mejoras.velocitydron:
               
                if (!lista)
                {
                    text.text = "ataque nivel " + General.atackLvl;
                    bt.onClick.AddListener(atackLvlUp);
                    lista = true;
                }
                    
                break;
            case Player.Mejoras.damagedron:
             
                if (!lista)
                {
                    text.text = "velocidad nivel " + General.speedLvl;
                    bt.onClick.AddListener(SpeedLvlUp);
                    lista = true;

                }
                break;
            case Player.Mejoras.damageSword:
                
                if (!lista)
                {
                    text.text = "criticos nivel " + General.criticosLvl;
                    bt.onClick.AddListener(CriticosLvlUp);
                    lista = true;
                }
                    
                break;
            default:
                text.text = "error inesperado";
                break;
        }
    }
    public void CriticosLvlUp()
    {
        General.criticos = General.criticos + 5;
        General.criticosLvl++;
        bt.onClick.RemoveListener(CriticosLvlUp);
       
    }
    public void ArmorLvlUp()
    {
        //Debug.Log("curioso: " + General.swordvelocity * 0.05f);
        General.armadura += General.armadura + 10;
        General.armaduraLvl++;
        bt.onClick.RemoveListener(ArmorLvlUp);
    }
    public void SpeedLvlUp()
    {
        General.speed = General.speed + 25;
        General.speedLvl++;
        pl.AplicChange();
        bt.onClick.RemoveListener(SpeedLvlUp);
    }
    public void atackLvlUp()
    {
        General.atack = General.atack + 15;
        General.atackLvl++;
        bt.onClick.RemoveListener(atackLvlUp);
    }
    public void DronExtra()
    {
        pl.ActivarDron();
        //Debug.Log("el dron esta aqui");
        bt.onClick.RemoveListener(DronExtra);
    }
}