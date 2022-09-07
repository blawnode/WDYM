using UnityEngine;

public class PlayerPunch : MonoBehaviour
{
    public Transform _punchRotator;
    public Animator _punchAnimator;
    private Camera _camera;

    float _punchTime = 0;
    float _punchCooldown = 0.75f;
    bool PunchInCooldown => Time.time - _punchTime < _punchCooldown;

    void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        AimPunch();
        if(Input.GetMouseButtonDown(0) && !PunchInCooldown)
        {
            Punch();
        }
    }

    void AimPunch()
    {
        Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        _punchRotator.rotation = Quaternion.Euler(0, 0, angle);
    }

    void Punch()
    {
        _punchAnimator.Play("Punch", 1);
        _punchTime = Time.time;
    }
}
