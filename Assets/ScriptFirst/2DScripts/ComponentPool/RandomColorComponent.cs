using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColorComponent : PoolableComponent {

    [SerializeField]
    Renderer _renderer;
    //Color defalut;
    [SerializeField]
    BoxCollider2D box;
    /*
    private void Start()
    {
        defalut = Color.white;
    }
    */
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Spawned();
        }
        else if (Input.GetKeyDown(KeyCode.RightAlt))
        {
            Despawned();
        }
    }

    public override void Spawned()
    {
        base.Spawned();
        box.enabled = true;
        //_renderer.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
    public override void Despawned()
    {
        base.Despawned();
        box.enabled = false;
        //_renderer.material.color = defalut;
    }
}
