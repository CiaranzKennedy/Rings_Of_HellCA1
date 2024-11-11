using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    Player player;

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
        player = GameObject.Find("Player").GetComponent<Player>();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int counter = 0;
        if (collision.gameObject.tag == "Player" && this.tag == "Enemy" && Input.GetKeyDown(KeyCode.Mouse1))
        {
            counter++;
            Debug.Log("Gay");
            if (counter == 1)
            {
                Destroy(this.gameObject);
                player.addEnemy();
            }
        }
    }
}
