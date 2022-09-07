using System.Collections;
using UnityEngine;

public class Knockable : MonoBehaviour
{
    private Rigidbody2D _rb;
    private NPCBehaviour _npcBehaviour;
    [SerializeField] protected Collider2D _hurtBox = null;
    private float knockTime = 0;
    private float knockTimeDelta = 0.5f;

    bool ReadyToBeKnockedAgain => Time.time - knockTime > knockTimeDelta;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _npcBehaviour = GetComponent<NPCBehaviour>();
    }

    void GetKnocked(Vector2 direction, float force = 175)
    {
        print("AAAGH " + gameObject.name);
        _rb.constraints = RigidbodyConstraints2D.None;
        _rb.AddForce(direction.normalized * force);
        //_rb.angularVelocity = 99;
        _hurtBox.enabled = false;
        _npcBehaviour.PlayAnimation("None");
        _npcBehaviour.SetKnockedTrue();
        knockTime = Time.time;

        _npcBehaviour.Die();
    }

    public void HurtboxTriggered(Vector2 direction)
    {
        if (ReadyToBeKnockedAgain)
        {
            SFXManager.Main.PlaySFX("PUNCH");
            GetKnocked(direction, GameManager.PUNCH_POWER);
        }
        _npcBehaviour.GetHit();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (!collision.CompareTag("Punch")) return;
        print("Ouch! " + collision.ToString());
        Vector2 direction = (transform.position - collision.transform.position).normalized;
        if(ReadyToBeKnockedAgain) GetKnocked(direction);*/
    }
}
