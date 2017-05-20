using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePred : MonoBehaviour {
    public GameObject projectileObj;
    public GameObject projectilePredictor;
    public float predictionHeight = 0.0f;
    public float speed;
    public Vector2 direction;
    List<GameObject> projectiles;
    [SerializeField]
    Renderer myRenderer;
    ProjectileSimple p;

    private void Awake()
    {
        projectiles = new List<GameObject>();
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (projectiles.Count == 0)
        {
            Vector2 firePos = transform.position;
            firePos.y += this.myRenderer.bounds.size.y / 2.0f;
            direction = Random.insideUnitCircle;
            direction.y = Mathf.Abs(direction.y);
            speed = Random.Range(5.0f, 10.0f);
            GameObject p = Instantiate(projectileObj, firePos, new Quaternion()) as GameObject;
            p.GetComponent<ProjectileSimple>().Set(firePos, direction, speed);
            projectiles.Add(p);
        }
        else
        {
            p = projectiles[0].GetComponent<ProjectileSimple>();
            projectilePredictor.transform.position = p.GetLandingPos(predictionHeight);
            if (projectiles[0].transform.position.y < predictionHeight)
            {
                Destroy(projectiles[0]);
                projectiles.Clear();
                projectilePredictor.transform.position = Vector2.zero;
                p = null;
            }
        }
    }
}
