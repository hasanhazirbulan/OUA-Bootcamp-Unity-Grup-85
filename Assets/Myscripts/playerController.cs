using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class playerController : MonoBehaviour
{
    public float Speed;
    public Vector2 _velocity = new(0, 0);
    public Vector2 Max;
    public Vector2 Min;
    private void Start()
    {
       
    }

    void Update()
    {
        _velocity = HandleHorizantal(Input.GetAxis("Horizontal"));
        _velocity += HandleVertical(Input.GetAxis("Vertical"));
        MoveCruiser();
        
    }

    private Vector2 HandleVertical(float v)
    {
        return new Vector2(0, Mathf.Clamp(v, -1, 1));
    }


    private Vector2 HandleHorizantal(float h)
    {
        return new Vector2(Mathf.Clamp(h, -1, 1), 0);
    }

    private void MoveCruiser()
    {
        float movex = transform.position.x + (_velocity.x * Speed* Time.deltaTime);
        float movey = transform.position.y + (_velocity.y * Speed*Time.deltaTime);
        movex = Mathf.Clamp(movex,Min.x,Max.x);
        movey = Mathf.Clamp(movey,Min.x,Max.x); //clamp is a method for taking min and max values. wse use it for bounding.
        
        transform.position = new Vector2(movex, movey);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Uzay aracı başka bir nesneyle temas ettiğinde gerçekleşecek işlemler
        Debug.Log("Collision Detected with: " + other.gameObject.name);

        // Örneğin, çarpıştığımız nesneyi etkisiz hale getirebiliriz
        Destroy(other.gameObject);
    }
}


