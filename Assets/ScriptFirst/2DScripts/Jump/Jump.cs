using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : VelocityMath
{
    public JumpPoint jumpPoint;
    bool canAchive = false; // Признак допустимости прыжка.
    public float maxYVelocity; // Максимальная вертикальная скорость при прыжке.
    public Vector2 gravity = new Vector2(0.0f, -9.8f); // Гравитация действующая при прыжке.
    private ProjectileSimple projectile;
    private List<AgentBehaviour2D> behaviours;// (Povedenie || Rejim).

    // Отключает все модели поведения за исключением компонента Jump.
    public void Isolate(bool state)
    {
        foreach (AgentBehaviour2D b in behaviours)
            b.enabled = !state;
        this.enabled = state;
    }

    // Определим функцию, реализующую прыжок с использованием модели снаряда (ProjectileSimple).
    public void DoJump()
    {
        projectile.enabled = true;
        Vector2 direction;
        direction = ProjectileSimple.GetFireDirection(jumpPoint.jumpLocation, jumpPoint.landingLocation, agent2d.maxSpeed);// Jump.jumpLoc change and jump.landLoc
        projectile.Set(jumpPoint.jumpLocation, direction, agent2d.maxSpeed, false); // mb chage this jumpPoint.JumpLoc Bouds //SpriteRenderer myRenderer.bounds.size.y / 2.0f;
    }

    // Переопределим метод Awake. Самым важным здесь является кэширование ссылок на другие присоединенные модели поведию, что придает смысл функции Isolate.
    public override void Awake()
    {
        base.Awake();
        this.enabled = false;
        projectile = gameObject.AddComponent<ProjectileSimple>();
        behaviours = new List<AgentBehaviour2D>();
        AgentBehaviour2D[] abs;
        abs = gameObject.GetComponents<AgentBehaviour2D>();
        foreach (AgentBehaviour2D b in abs)
        {
            if (b == this)
                continue;
            behaviours.Add(b);
        }
    }
    // Переопределим метод GetSteering2D();
    public override Steering2D GetSteering2D()
    {
        Steering2D steering = new Steering2D();
        // Проверить наличие траектории и, если она отсутствует, содать ее.
        if (jumpPoint != null && target == null)
        {
            CalculateTarget();
        }
        // Проверить равенство траектории нулю. Если нет, усорение не требуется.
        if (!canAchive)
        {
            return steering;
        }
        // Проверить попадание в точку прыжка.
        if (Mathf.Approximately((transform.position - target.transform.position).magnitude, 0.0f) && 
            Mathf.Approximately((agent2d.velocity - target.GetComponent<Agent2D>().velocity).magnitude, 0.0f))
        {
            DoJump();
            return steering;
        }
        return base.GetSteering2D();
    }
    // Реализуем метод для выбора скорости в зависимости от цели.
    protected void CalculateTarget()
    {
        target = new GameObject();
        target.AddComponent<Agent2D>();
        // Вычеслить время прыжка
        float sqrtTerm = Mathf.Sqrt(2.0f * gravity.y * jumpPoint.deltaPosition.y + maxYVelocity * agent2d.maxSpeed);
        float time = (maxYVelocity - sqrtTerm) / gravity.y;
        // Проверить допустимость и при необходимости вычислить другое время.
        if (!CheckJumpTime(time))
        {
            time = (maxYVelocity + sqrtTerm) / gravity.y;
        }
    }
    // Реализуем функцию вычесления времени.
    bool CheckJumpTime (float time)
    {
        // Вычеслить горизонтальную скорость.
        float vx = jumpPoint.deltaPosition.x / time;
        float speedSq = vx * vx;
        // Проверить полученное решение на допустимость.
        if (speedSq < agent2d.maxSpeed * agent2d.maxSpeed)
        {
            target.GetComponent<Agent2D>().velocity = new Vector2(vx, 0.0f);
            canAchive = true;
            return true;
        }
        return false;
    }
}
