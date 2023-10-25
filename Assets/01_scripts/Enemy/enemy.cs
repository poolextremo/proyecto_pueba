using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float life = 20, lifeTotal;
    public Transform lifeUI;
    public bool isdamage;
    public SpriteRenderer paint;
    void Start()
    {
        lifeTotal = life;
        paint = lifeUI.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Cancelacion.iscancel)
            LifeUI();
    }
    public void TakeDamage(float damage)
    {
        isdamage = true;
        life -= damage;
        
        if (life <= 0)
        {
            life = 0;
            lifeUI.localScale = new Vector3(1 * (life / lifeTotal), 0.2f, 1);
            Destroy(gameObject);
        }
        lifeUI.localScale = new Vector3(1 * (life / lifeTotal), 0.2f, 1);
    }
    void LifeUI()
    {
        if (isdamage)
        {
            isdamage = false;
            paint.color = new Color(paint.color.r, paint.color.g, paint.color.b, 1);
        }
        else
        {
            if (paint.color.a > 0)
            {
                paint.color = new Color(paint.color.r, paint.color.g, paint.color.b, paint.color.a - Time.deltaTime);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("sword"))
        {
            TakeDamage(General.sworddamage);
        }
    }
}
