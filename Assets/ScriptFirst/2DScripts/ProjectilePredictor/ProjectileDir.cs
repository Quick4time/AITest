using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDir : MonoBehaviour
{
    public GameObject projectileSim;
    public float speed = 7.0f;
    public float shootDelay = 1.0f;

    public GameObject target;
    public float targetSpeed = 2.0f;

    Vector2 targetDirection;
    float shootTimer = 0.0f;
    Vector2 direction;
    [SerializeField] // Указываем SpriteRenderer.
    Renderer myRenderer;

    private void Start()
    {
        targetDirection = Vector2.right; // Движение цели в правую сторону при инициализации.
    }

    private void Update()
    {
        if (target.transform.position.x > 6.0f)
            targetDirection = Vector2.left;
        if (target.transform.position.x < 6.0f)
            targetDirection = Vector2.right;
        target.transform.Translate(targetDirection * targetSpeed * Time.deltaTime);

        shootTimer += Time.deltaTime;// Таймер для выстрела.
        if (shootTimer >= shootDelay)
        {
            shootTimer -= shootDelay;
        }
    }
    void Shoot()
    {
        Vector2 firePos = transform.position;
        firePos.y = myRenderer.bounds.max.y;
        Vector2 startPos = transform.position;
        Vector2 endPos = target.transform.position;
        Vector2 direction = ProjectileSimple.GetFireDirection(startPos, endPos, speed);
        GameObject projectile = Instantiate(projectileSim, firePos, new Quaternion()) as GameObject;
        projectile.GetComponent<ProjectileSimple>().Set(firePos, direction, speed);
    }
}
