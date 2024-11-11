using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator _animator;
    public float distanceTime;
    public float speed;
    float direction = 1;
    float timeIndirection;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        timeIndirection = distanceTime;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        position.x = position.x + speed * Time.deltaTime * direction;
        transform.position = position;
        timeIndirection -= Time.deltaTime;

        if (timeIndirection < 0)
        {
            direction *= -1;
            timeIndirection = distanceTime;
            _animator.SetFloat("Move X", direction);
            _animator.SetFloat("Move Y", (direction < 0 ? -0.8f : 0.8f));
        }
        else
        {
            _animator.SetFloat("Move X", 0);
        }

    }
}
