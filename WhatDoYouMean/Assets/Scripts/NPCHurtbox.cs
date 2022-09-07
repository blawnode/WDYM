using UnityEngine;

public class NPCHurtbox : MonoBehaviour
{
    private Knockable _knockable;

    private void Start()
    {
        _knockable = transform.parent.GetComponent<Knockable>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Punch")) return;
        Vector2 direction = (transform.position - collision.transform.position).normalized;
        _knockable.HurtboxTriggered(direction);
    }
}
