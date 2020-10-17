using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    Rigidbody2D rigid;
    public float force;
  
    public bool shooting = false;

    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShootThe()
    {
        shooting = true;
        rigid.AddForce(new Vector2(force, force));
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
    }
    
}
