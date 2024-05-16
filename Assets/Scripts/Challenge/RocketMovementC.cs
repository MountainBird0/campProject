using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class RocketMovementC : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private readonly float SPEED = 5;
    private readonly float ROTATIONSPEED = 1f;
    private readonly float BOOSTDURATION = 1f;

    private float highScore = -1;

    public static Action<float> OnHighScoreChanged;

    private bool isBoosting;
    private bool isChecking  = false;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (highScore > transform.position.y || isChecking) return;
        StartCoroutine(CheckScore());        
    }

    public void ApplyMovementY(float inputY)
    {
        if (inputY > 0 && !isBoosting)
        {
            _rb2d.velocity = transform.up * SPEED;
        }
        else
        {
            // _rb2d.velocity = Vector2.zero;
        }
    }

    public void ApplyMovement(float inputX)
    {
        Rotate(inputX);
    }

    public void ApplyBoost()
    {
        isBoosting = true;
        _rb2d.AddForce(transform.up * SPEED * 3, ForceMode2D.Impulse);
        StartCoroutine(Boosting());    
    }

    private void Rotate(float inputX)
    {
        float targetRotation = -Mathf.Atan2(inputX, 1) * Mathf.Rad2Deg;
        Quaternion targetQuaternion = Quaternion.Euler(0, 0, targetRotation);
        Quaternion newRotation = Quaternion.Slerp(transform.rotation, targetQuaternion, Time.deltaTime * ROTATIONSPEED);
        transform.rotation = newRotation;

        //float rotationAngle = -inputX * ROTATIONSPEED;
        //transform.Rotate(Vector3.forward, rotationAngle);
    }

    private IEnumerator Boosting()
    {      
        yield return new WaitForSeconds(BOOSTDURATION);
        isBoosting = false;
    }

    private IEnumerator CheckScore()
    {
        isChecking = true;
        highScore = transform.position.y;
        OnHighScoreChanged?.Invoke(highScore);
        yield return new WaitForSeconds(2f);
        isChecking = false;
    }
}