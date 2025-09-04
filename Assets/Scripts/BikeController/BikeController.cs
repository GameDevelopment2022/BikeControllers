using System;
using UnityEngine;

public class BikeController : MonoBehaviour
{
    [Header("Inputs")] [SerializeField] private InputData _inputData;

    [SerializeField] private bool race;
    [SerializeField] private bool brake;

    [Header("Bike Settings")] [SerializeField]
    private float _speed;


    [Header("Wheels")] [SerializeField] private Rigidbody _rearWheel;
    [SerializeField] private Rigidbody _frontWheel;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_inputData.moveInputData);

        if (_inputData.moveInputData.x >= 1)
        {
            race = true;
        }
        else
        {
            race = false;
        }
        if (_inputData.moveInputData.x <= -1)
        {
            brake = true;
        }
        else
        {
            brake = false;
        }
    }

    private void FixedUpdate()
    {
        if (race == true)
        {
            _rearWheel.freezeRotation = false;
            _rearWheel.AddTorque(_rearWheel.transform.right * _speed * Time.fixedDeltaTime, ForceMode.Impulse);
        }
        else if (brake == true)
        {
        }
    }
}