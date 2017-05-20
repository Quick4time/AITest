using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPooledRigidbodyComponent : MonoBehaviour, IPoolableComponent {
    [SerializeField] Rigidbody2D _body;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Spawned();
        }
        else if (Input.GetKeyDown(KeyCode.RightAlt))
        {
            Despawned();
        }
    }
    public void Spawned()
    {

    }
    public void Despawned()
    {
        if (_body == null)
        {
            _body = GetComponent<Rigidbody2D>();
            if (_body == null)
            {
                return;
            }
        }
        _body.velocity = Vector2.zero;
        _body.angularVelocity = 0.0f;
    }
}
