using UnityEngine;
using UnityEngine.Events;

public class LoadSceneOnTrigger : MonoBehaviour
{
    public UnityEvent _action;

    private bool IsPlayer(Collider2D collider)
    {
        return collider.GetComponent<PlayerMovement>() != null
            || collider.transform.parent.GetComponent<PlayerMovement>() != null;  // Hurtbox?
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!IsPlayer(collision))
        {
            return;
        }
        _action.Invoke();
    }
}
