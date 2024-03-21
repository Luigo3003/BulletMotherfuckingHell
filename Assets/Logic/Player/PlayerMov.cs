using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMov : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private float Bulletforce = 0.5f;

    private Rigidbody2D _RB2D;
    private PlayerInputs inputActions;
    [SerializeField] private Transform OffSetBullets;
    [SerializeField] GameObject BulletPoolref;

    private void Awake()
    {
        inputActions = new PlayerInputs();
        _RB2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        inputActions.Enable();


        inputActions.PlayerActions.Shoot.performed += shoot;
    }

    private void FixedUpdate()
    {
        moveSprite();
    }

    private void moveSprite()
    {
        Vector2 direction = new Vector2(inputActions.PlayerActions.MoveHoz.ReadValue<float>(), inputActions.PlayerActions.MoveVer.ReadValue<float>());
        _RB2D.AddForce(direction * speed);
    }

    private void shoot(InputAction.CallbackContext callbackContext)
    {
        GameObject bullet = BulletPoolref.GetComponent<PoolScript>().RequestObject();
        bullet.SetActive(true);
        bullet.transform.position = OffSetBullets.transform.position;
        bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.up * Bulletforce);

    }

    public void Dead()
    {
        GameManager.instance.ResetScore();
    }

}
