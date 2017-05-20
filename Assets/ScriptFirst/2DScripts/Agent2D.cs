using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent2D : MonoBehaviour
{
    public bool blendWeight = false;
    public bool blendPriority = false;
    public bool blendPripeline = false;
    public float maxSpeed;
    public float maxAccel;
    public float orientation;
    public float rotation;
    public float maxRotation;
    public float maxAngularAccel;
    public Vector2 velocity;
    protected Steering2D steering2d;
    // Добавляем свойство минимального значения управляющенго воздействия для групп моделей поведения.
    public float priorityTreshold = 0.2f;
    // Добавим свойство для хранения управдяющих воздействий группы моделей.
    private Dictionary<int, List<Steering2D>> groups;

    private void Start()
    {
        // Инициализируем переменную в Функции Старт
        groups = new Dictionary<int, List<Steering2D>>();
        velocity = Vector2.zero;
        steering2d = new Steering2D();
    }
    public void SetSteering2D(Steering2D steering2d)
    {
        this.steering2d = steering2d;
    }
    public void SetSteering2D(Steering2D steering2d, float weight)
    {
        this.steering2d.linear += (weight * steering2d.linear);
        this.steering2d.angular += (weight * steering2d.angular);
    }
    public void SetSteering2D(Steering2D steering2d, int priority)
    {
        if(!groups.ContainsKey(priority))
        {
            groups.Add(priority, new List<Steering2D>());
        }
        groups[priority].Add(steering2d);
    }
    public void SetSteering2D(Steering2D steering, bool pipeline)
    {
        if (!pipeline)
        {
            this.steering2d = steering;
            return;
        }
    }
    private Steering2D GetPrioritySteering()
    {
        Steering2D steering2d = new Steering2D();
        float sqrThreshold = priorityTreshold * priorityTreshold;
        foreach (List<Steering2D> group in groups.Values)
        {
            steering2d = new Steering2D();
            foreach (Steering2D singleSteering in group)
            {
                steering2d.linear += singleSteering.linear; // возможно использовать с * weight
                steering2d.angular += singleSteering.angular; // возможно использовать с * weight
            }
            if (steering2d.linear.sqrMagnitude > sqrThreshold || Mathf.Abs(steering2d.angular) > priorityTreshold)
            {
                return steering2d;
            }
        }
        return steering2d;
    }
    public virtual void Update()
    {
        Vector2 displacement = velocity * Time.deltaTime;
        orientation += rotation * Time.deltaTime;
        if (orientation < 0.0f)
            orientation += 360.0f;
        else if (orientation > 360.0f)
            orientation -= 360.0f;
        transform.Translate(displacement, Space.World);
        transform.rotation = new Quaternion(); //Quaternion.Euler(0.0f, 0.0f, orientation);
        transform.Rotate(Vector3.forward, orientation);
    }
    public virtual void LateUpdate()
    {
        // Изменим Функцию так, что бы она присваивала переменной управления значение, возвращаемое функцией GetPrioritySteering.
        if (blendPriority)
        {
            steering2d = GetPrioritySteering();
            groups.Clear();
        }
        velocity += steering2d.linear * Time.deltaTime;
        rotation += steering2d.angular * Time.deltaTime;
        if (velocity.magnitude > maxSpeed)
        {
            velocity.Normalize();
            velocity = velocity * maxSpeed;
        }
        if (rotation > maxRotation)
        {
            rotation = maxRotation;
        }
        if (steering2d.angular == 0.0f)
        {
            rotation = 0.0f;
        }
        if (steering2d.linear.sqrMagnitude == 0.0f)
        {
            velocity = Vector2.zero;
        }
        steering2d = new Steering2D();
    }
}
