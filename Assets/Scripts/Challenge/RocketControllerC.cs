using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class RocketControllerC : MonoBehaviour
{
    private EnergySystemC _energySystem;
    private RocketMovementC _rocketMovement;

    private bool _isMoving = false;

    private float _upDirection;
    private float _movementDirection;

    private readonly float ENERGY_TURN = 0.5f;
    private readonly float ENERGY_BURST = 2f;

    private void Awake()
    {
        _energySystem = GetComponent<EnergySystemC>();
        _rocketMovement = GetComponent<RocketMovementC>();
    }
    
    private void FixedUpdate()
    {
        if (!_isMoving) return;

        if (!_energySystem.UseEnergy(Time.fixedDeltaTime * ENERGY_TURN)) return;

        _rocketMovement.ApplyMovementY(_upDirection);
        _rocketMovement.ApplyMovement(_movementDirection);
    }

    private void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        
        _upDirection = moveInput.y;
        _movementDirection = moveInput.x;
        _isMoving = moveInput.magnitude > 0;
        _energySystem.isCharge = !_isMoving;
    }

    private void OnBoost(InputValue value)
    {
        // 속도 3배 증가
        _rocketMovement.ApplyBoost();
        _energySystem.UseEnergy(ENERGY_BURST);
    }
}