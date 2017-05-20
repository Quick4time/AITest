using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path2D : MonoBehaviour
{
    // Определим класс Path с узлами и сегментами, из которых только узлы являются общедоступными и являются общедоступными и должны задаваться вручную.
    public List<GameObject> nodes;
    List<PathSegment2D> segments;

    // Определим функцию Start для подготовки сегментов при ззапуске сцены.
    private void Start()
    {
        segments = GetSegments();
    }
    // Определим функцию GetSegments для создания сегментов из узлов.
    public List<PathSegment2D> GetSegments()
    {
        List<PathSegment2D> segments = new List<PathSegment2D>();
        int i;
        for (i = 0; i < nodes.Count - 1; i++)
        {
            Vector2 src = nodes[i].transform.position;
            Vector2 dst = nodes[i + 1].transform.position;
            PathSegment2D segment = new PathSegment2D(src, dst);
            segments.Add(segment);
        }
        return segments;
    }
    private void OnDrawGizmos()
    {
        Vector3 direction;
        Color tmp = Gizmos.color;
        Gizmos.color = Color.blue;
        int i;
        for (i = 0; i < nodes.Count - 1; i++)
        {
            Vector3 src = nodes[i].transform.position;
            Vector3 dst = nodes[i + 1].transform.position;
            direction = dst - src;
            Gizmos.DrawRay(src, direction);
        }
        Gizmos.color = tmp;
    }
    private PathSegment2D GetNearestSegment(Vector2 position)
    {
        float nearestDistance = Mathf.Infinity;
        float distance = nearestDistance;
        Vector2 centroid = Vector2.zero;
        PathSegment2D segment = new PathSegment2D();
        foreach (PathSegment2D s in segments)
        {
            centroid = (s.a + s.b) / 2.0f;
            distance = Vector2.Distance(position, centroid);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                segment = s;
            }
        }
        return segment;
    }
    //Определим первую функцию для абстрагирования GetParam.
    public float GetParam (Vector2 position, float lastParam)
    {   
        // Находим ближайший к агенту сегмент.
        float param = 0.0f;
        PathSegment2D currentSegment = null;
        float tempParam = 0.0f;
        foreach(PathSegment2D ps in segments)
        {
            tempParam += Vector2.Distance(ps.a, ps.b);
            if (lastParam <= tempParam)
            {
                currentSegment = ps;
                break;
            }
        }
        
        if (currentSegment == null)
            return 0.0f;
        
        // Вычеслить направление движения из ткущей позиции.
        Vector2 segmentDirection = currentSegment.b - currentSegment.a;
        segmentDirection.Normalize();
        Vector2 currPos = position - currentSegment.a;
        // Найти точку в сегменте с помощью проекции вектора.
        Vector2 pointInSegment = Vector3.Project(currPos, segmentDirection);
        // И наконец, вернуть следующую позицию на линии маршрута.
        param = tempParam - Vector2.Distance(currentSegment.a, currentSegment.b);
        param += pointInSegment.magnitude;
        return param;
    }
    // Определим функцию GetPosition
    public Vector2 GetPosition (float param)
    {
        // По текущему местоположению находим соответвующий сегмент
        Vector2 position = Vector2.zero;
        PathSegment2D currentSegment = null;
        float tempParam = 0.0f;
        foreach (PathSegment2D ps in segments)
        {
            tempParam += Vector2.Distance(ps.a, ps.b);
            if (param <= tempParam)
            {
                currentSegment = ps;
                break;
            }
        }
        if (currentSegment == null)
            return Vector2.zero;

        // Преобразуем параметр в точку пространства и возвращаем ее
        Vector2 segmentDirection = currentSegment.b - currentSegment.a;
        segmentDirection.Normalize();
        tempParam -= Vector2.Distance(currentSegment.a, currentSegment.b);
        tempParam = param - tempParam;
        position = currentSegment.a + segmentDirection * tempParam;
        return position;
    }
} 