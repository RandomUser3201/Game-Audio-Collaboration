using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using System.Diagnostics.Tracing;

public class GuardWarning : MonoBehaviour
{
    public Transform Player;

    [Header("Distances")]
    public float WarningDistance1 = 20f; // Far
    public float WarningDistance2 = 10f; // Mid
    public float WarningDistance3 = 5f; // Close

    [Header("Events")]
    public EventReference WarningEvent1;
    public EventReference WarningEvent2;
    public EventReference WarningEvent3;
    
    [Header("Cooldown")]
    public float CooldownTime1 = 10f;
    public float CooldownTime2 = 10f;
    public float CooldownTime3 = 10f;

    private float _timer1 = 0f;
    private float _timer2 = 0f;
    private float _timer3 = 0f;

    void Update()
    {
        float distance = Vector3.Distance(Player.position, transform.position);

        // --- Decrease cooldown timers over time ---
        if (_timer1 > 0)
        {
            _timer1 -= Time.deltaTime;
        }
        if (_timer2 > 0)
        {
            _timer2 -= Time.deltaTime;
        }
        if (_timer3 > 0)
        {
            _timer3 -= Time.deltaTime;
        }

        // --- Check if player is in range for warning, and cooldown has passed --- 
        if (distance <= WarningDistance1 && distance >= WarningDistance2 && _timer1 <= 0f)
        {
            RuntimeManager.PlayOneShot(WarningEvent1, transform.position);
            _timer1 = CooldownTime1;
        }

        if (distance <= WarningDistance2 && distance >= WarningDistance3 && _timer2 <= 0f)
        {
            RuntimeManager.PlayOneShot(WarningEvent2, transform.position);
            _timer2 = CooldownTime2;
        }

        if (distance < WarningDistance3 && _timer3 <= 0f)
        {
            RuntimeManager.PlayOneShot(WarningEvent3, transform.position);
            _timer3 = CooldownTime3;
        }
    }
}
