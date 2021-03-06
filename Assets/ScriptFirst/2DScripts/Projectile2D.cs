﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile2D : MonoBehaviour {

    public bool set = false;
    private Vector2 firePos;
    private Vector2 direction;
    private float speed;
    private float timeElapsed;
    ProjictileShooter2D p;
    GameObject go;

    public Vector2 FirePosition
    {
        get { return firePos; }
    }
    public Vector2 Direction
    {
        get { return direction; }
    }
    public float Speed
    {
        get { return speed; }
    }

    private void Start()
    {
        go = GameObject.FindGameObjectWithTag("wall");
        p = (ProjictileShooter2D)go.GetComponent(typeof(ProjictileShooter2D));
    }

    private void Update()
    {
        if (!set)
            return;
        timeElapsed += Time.deltaTime;
        transform.position = firePos + direction * speed * timeElapsed;
        transform.position += (Vector3)Physics2D.gravity * (timeElapsed * timeElapsed) / 2.0f;
        
        if (transform.position.y < -1.0f)
        {  
            OnDespawn(p._go);
        }     
    }
    // Функция реализующая метание обьекта.
    public void Set (Vector2 firPos, Vector2 direction, float speed)
    {
        this.firePos = firPos;
        this.direction = direction.normalized;
        this.speed = speed;
        transform.position = firePos;
        set = true;
    }
    
    void OnDespawn(List<GameObject> list)
    {
        if (list.Count == 0)
        {
            return;
        }
        PrefabPoolSystem_AsSingleton.Despawn(list[0]);
        list.RemoveAt(0);
    }
    
    // Вычесления времени времени падения.
    public float GetLandingTime (float height = 0.0f)
    {
        Vector2 position = transform.position;
        float time = 0.0f;
        float valueInt = (direction.y * direction.y) * (speed * speed);
        valueInt = valueInt - (Physics2D.gravity.y * 2 * (position.y - height));
        valueInt = Mathf.Sqrt(valueInt);
        float valueAdd = (-direction.y) * speed;
        float vaueSub = (-direction.y) * speed;
        valueAdd = (valueAdd + valueInt) / Physics2D.gravity.y;
        vaueSub = (vaueSub - valueInt) / Physics2D.gravity.y;
        if (float.IsNaN(valueAdd) && !float.IsNaN(vaueSub))
        {
            return valueAdd;
        }
        else if (!float.IsNaN(valueAdd) && float.IsNaN(vaueSub))
        {
            return valueAdd;
        }
        else if (float.IsNaN(valueAdd) && float.IsNaN(vaueSub))
        {
            return -1.0f;
        }
        time = Mathf.Max(valueAdd, vaueSub);
        return time;
    }
    // Вычесления предположительного места падения.
    public Vector2 GetLandingPos(float height = 0.0f)
    {
        Vector2 landPos = Vector2.zero;
        float time = GetLandingTime();
        if (time < 0.0f)
            return landPos;
        landPos.y = height;
        landPos.x = firePos.x + direction.x * speed * time;
        return landPos;
    }
    // Функция направления выстрела.
    public static Vector2 GetFireDirection (Vector2 startPos, Vector2 endPos, float speed)
    {
        Vector2 direction = Vector2.zero;
        Vector2 delta = endPos - startPos;
        float a = Vector2.Dot(Physics2D.gravity, Physics2D.gravity);
        float b = -4 * (Vector2.Dot(Physics2D.gravity, delta) + speed * speed);
        float c = 4 * Vector2.Dot(delta, delta);
        if (4 * a * c > b * b)
            return direction;
        float time0 = Mathf.Sqrt((-b + Mathf.Sqrt(b * b - 4 * a * c)) / (2 * a));
        float time1 = Mathf.Sqrt((-b - Mathf.Sqrt(b * b - 4 * a * c)) / (2 * a));
        // Если можно послать снаряд в соответствии с заданными параметрами, вернуть нулевой вектор направления.
        float time;

        if (time0 < 0.0f)
        {
            if (time1 < 0)
                return direction;
            time = time1;
        }
        else
        {
            if (time1 < 0)
                time = time0;
            else
                time = Mathf.Min(time0, time1);
        }
        direction = 2 * delta - Physics2D.gravity * (time * time);
        direction = direction / (2 * speed * time);
        return direction;
    }
}
