using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class areashoot : MonoBehaviour
{
    public dron dro;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<enemy>())
        {
            dro.target.Add(collision.gameObject.transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<enemy>())
        {
            dro.target.Remove(collision.gameObject.transform);
        }
    }
}
