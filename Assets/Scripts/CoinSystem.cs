using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSystem : MonoBehaviour
{

    private PlayerController player;
    public GameObject effect;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.coin++;
            Destroy(gameObject);

            Instantiate(effect, transform.position, Quaternion.identity);
        }
    }
}
