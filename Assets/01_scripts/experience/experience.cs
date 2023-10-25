using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class experience : MonoBehaviour
{
    public Player pl;
    public float velocity = 2;
    public type tipo;
    void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (tipo == type.Experience)
        {
            velocity = 2;
        }
        else if (tipo == type.Coin)
        {
            velocity = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!Cancelacion.iscancel)
        {
            //Debug.Log("a");
            if (collision.CompareTag("area"))
            {
                Vector3 dir = gameObject.transform.position - pl.transform.position;
                float angulo = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg + 180;
                gameObject.transform.rotation = Quaternion.Euler(0, 0, -angulo);
                transform.Translate(Vector2.up * velocity * Time.deltaTime);
            }
            if (collision.CompareTag("Player"))
            {
                if (tipo == type.Experience)
                {
                    pl.TakeExperience(5);
                    Destroy(gameObject);
                }
                else if (tipo == type.Coin)
                {
                    pl.TakeCoin();
                    Destroy(gameObject);
                }
            }
        }
    }


    public enum type
    {
        Coin,
        Experience
    }
}
