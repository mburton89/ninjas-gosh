using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject ninjaStarPrefab;
    public float secondsToWaitBeforeThrow;
    public float throwingForce;
    public Vector2 directionToThrowStar;

    void Start()
    {
        DelayThrowStar();
    }

    void DelayThrowStar()
    {
        StartCoroutine(ThrowStarCo());
    }

    private IEnumerator ThrowStarCo()
    {
        yield return new WaitForSeconds(secondsToWaitBeforeThrow);
        GameObject newStar = Instantiate(ninjaStarPrefab, transform.position, transform.rotation, null);
        newStar.GetComponent<Rigidbody2D>().AddForce(directionToThrowStar * throwingForce);
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
