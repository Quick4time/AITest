using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {
    // Определим класс Path с узлами и сегментами, из которых только узлы являются общедоступными и являются общедоступными и должны задаваться вручную.
    public List<GameObject> nodes;
    List<PathSegment> segments;

    // Определим функцию Start для подготовки сегментов при ззапуске сцены.
    void Start()
    {
        segments = GetSegments();
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

    private PathSegment GetNearestSegment(Vector3 position)
    {
        float nearestDistance = Mathf.Infinity;
        float distance = nearestDistance;
        Vector3 centroid = Vector3.zero;
        PathSegment segment = new PathSegment();
        foreach (PathSegment s in segments)
        {
            centroid = (s.a + s.b) / 2.0f;
            distance = Vector3.Distance(position, centroid);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                segment = s;
            }
        }
        return segment;
    }

    // Определим функцию GetSegments для создания сегментов из узлов.
    public List<PathSegment> GetSegments()
    {
        List<PathSegment> segments = new List<PathSegment>();
        int i;
        for (i = 0; i < nodes.Count - 1; i++)
        {
            Vector3 src = nodes[i].transform.position;
            Vector3 dst = nodes[i+1].transform.position;
            PathSegment segment = new PathSegment(src, dst);
            segments.Add(segment);
        }
        return segments;
    }

    //Определим первую функцию для абстрагирования GetParam.
    public float GetParam(Vector3 position, float lastParam)
    {
        // Она должна найти ближайший к агенту сегмент.
        float param = 0.0f;
        PathSegment currentSegment = null;
        float tempParam = 0.0f;
        foreach (PathSegment ps in segments)
        {
            tempParam += Vector3.Distance(ps.a, ps.b);
            if (lastParam <= tempParam)
            {
                currentSegment = ps;
                break;
            }
        }
        if (currentSegment == null)
            return 0.0f;

        // Вычеслить направление движения из ткущей позиции.
        Vector3 segmentDirection = currentSegment.b - currentSegment.a;
        segmentDirection.Normalize();
        Vector3 currPos = position - currentSegment.a;
        // Найти точку в сегменте с помощью проекции вектора.
        Vector3 pointInSegment = Vector3.Project(currPos, segmentDirection);
        // И наконец, вернуть следующую позицию на линии маршрута.
        param = tempParam - Vector3.Distance(currentSegment.a, currentSegment.b);
        param += pointInSegment.magnitude;
        return param;
    }
    // Определим функцию GetPosition
    public Vector3 GetPosition(float param)
    {
        // По текущему местоположению находим соответвующий сегмент
        Vector3 position = Vector3.zero;
        PathSegment currentSegment = null;
        float tempParam = 0.0f;

        foreach(PathSegment ps in segments)
        {
            tempParam += Vector3.Distance(ps.a, ps.b);
            if (param <= tempParam)
            {
                currentSegment = ps;
                break;
            }
        }
        if (currentSegment == null) 
            return Vector3.zero;

        // Преобразуем параметр в точку пространства и возвращаем ее
        Vector3 segmentDirection = currentSegment.b - currentSegment.a;
        segmentDirection.Normalize();
        tempParam -= Vector3.Distance(currentSegment.a, currentSegment.b);
        tempParam = param - tempParam;
        position = currentSegment.a + segmentDirection * tempParam;
        return position;
    }
}
