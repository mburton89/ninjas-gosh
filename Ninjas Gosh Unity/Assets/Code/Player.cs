using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidBody2D;
    PlayerWeapon playerWeapon;
    public float runSpeed;
    public float normalJumpHeight;
    public float weaponJumpHeight;
    public float secondsForWeaponToExist;

    void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        playerWeapon = GetComponentInChildren<PlayerWeapon>();
    }

    private void Start()
    {
        playerWeapon.Init(this);
        playerWeapon.gameObject.SetActive(false);
    }

    void Update()
    {
        TryMoveRight();
        HandleKeyboardInput();
    }

    public void Jump(bool isWithWeapon)
    {
        if (isWithWeapon)
        {
            rigidBody2D.AddForce(Vector2.up * weaponJumpHeight);
        }
        else
        {
            rigidBody2D.AddForce(Vector2.up * normalJumpHeight);
        }
    }

    void TryMoveRight()
    {
        rigidBody2D.velocity = new Vector2(runSpeed, rigidBody2D.velocity.y);
    }

    void UseWeapon()
    {
        StartCoroutine(UseWeaponCo());
    }

    private IEnumerator UseWeaponCo()
    {
        playerWeapon.gameObject.SetActive(true);
        yield return new WaitForSeconds(secondsForWeaponToExist);
        playerWeapon.gameObject.SetActive(false);
    }

    void HandleKeyboardInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            Jump(false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UseWeapon();
        }
    }

    public void Kill()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
