using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class NPCBehaviour : MonoBehaviour
{
    private Rigidbody2D _rb;
    private PlayerMovement _playerMovement;
    private Transform _playerTransform;
    private Animator _animator;

    public UnityEvent _onHit;

    public float _detectPlayerRange = 5;
    public float _speed = 1;

    public enum AttackType
    {
        PANIC_IN_PLACE,
        NOTHING,
        CHASE,
        RUN_AWAY
    }
    public AttackType _attackType = AttackType.CHASE;
    public float _attackDamage = 1;

    private const float DIE_AFTER_SECONDS = 1.25f;
    private bool _isKnocked = false;

    private bool IsPlayerClose()
    {
        float dist = (transform.position - _playerTransform.position).magnitude;
        return dist < _detectPlayerRange;
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerMovement = FindObjectOfType<PlayerMovement>();
        _playerTransform = _playerMovement.transform;
        _animator = GetComponent<Animator>();
    }
    
    // Chase or whatever
    void Update()
    {
        if(_isKnocked)
        {
            return;
        }
        if(IsPlayerClose())
        {
            print("AHHHHH " + gameObject.name);
            switch (_attackType)
            {
                case AttackType.NOTHING:
                case AttackType.PANIC_IN_PLACE:
                    PlayAnimation("Panic");
                    break;
                case AttackType.CHASE:
                    Chase();
                    break;
                case AttackType.RUN_AWAY:
                    RunAway();
                    break;
                default:
                    Debug.LogError("WTF");
                    break;
            }
        }
        else
        {
            // Do nothing?
            PlayAnimation("None");
        }
    }

    private void Chase()
    {
        Vector2 direction = (transform.position - _playerTransform.position).normalized;
        _rb.velocity = direction * _speed;
        PlayAnimation("Move");
    }

    private void RunAway()
    {
        Vector2 direction = -(transform.position - _playerTransform.position).normalized;
        _rb.velocity = direction * _speed;
        PlayAnimation("Move");
    }

    bool _gotHit = false;

    public void GetHit()
    {
        if (_gotHit) return;
        _gotHit = true;
        _onHit.Invoke();
        SFXManager.Main.PlaySFX("Death");
    }

    public void Die()
    {
        StartCoroutine(I_Die());
    }

    private IEnumerator I_Die()
    {
        yield return I_Die(DIE_AFTER_SECONDS);
    }

    private IEnumerator I_Die(float afterSeconds)
    {
        yield return new WaitForSeconds(afterSeconds);
        Instantiate(GameManager.Main._deathParticle, transform.position, Quaternion.identity, null);
        GameManager.Main.UnitWasKilled();
        Destroy(gameObject);
    }

    public void PlayAnimation(string animation)
    {
        if(_animator != null)
        {
            _animator.Play(animation);
        }
    }

    public void SetKnockedTrue()
    {
        _isKnocked = true;
    }
}
