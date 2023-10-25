using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullets : MonoBehaviour
{
    public float velocity = 5;
    public float damage = 1;
    void Start()
    {
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Cancelacion.iscancel)
        {
            transform.Translate(Vector2.up * Time.deltaTime * velocity);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            if(Random.Range(1,101) <= General.criticos)
                collision.gameObject.GetComponent<enemy>().TakeDamage(General.dronDamage*2);
            else
                collision.gameObject.GetComponent<enemy>().TakeDamage(General.dronDamage);
            Destroy(gameObject);
        }
    }
}
