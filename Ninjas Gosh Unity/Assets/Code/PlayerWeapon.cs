using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    Player player;

    public void Init(Player player)
    {
        this.player = player;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            collision.GetComponent<Enemy>().Kill();
            player.Jump(true);
        }
        else if (collision.GetComponent<NinjaStar>())
        {
            collision.GetComponent<NinjaStar>().hasBeenDeflected = true;
            collision.GetComponent<Rigidbody2D>().velocity = -collision.GetComponent<Rigidbody2D>().velocity * 3;
        }
    }
}
