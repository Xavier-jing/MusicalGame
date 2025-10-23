using UnityEngine;

public class NoteMover : MonoBehaviour
{
    private NoteController noteController;
    private Vector2 targetPos;
    private float moveSpeed;
    private bool isMoving = false;

    public void Initialize(Vector2 target, float speed)
    {
        targetPos = target;
        moveSpeed = speed;
        isMoving = true;
        noteController = gameObject.GetComponent<NoteController>();
    }

    private void Update()
    {
        if (!isMoving) return;

        transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPos) < 0.05f)
        {
            isMoving = false;
            noteController.Die();
        }
        //Debug.Log($"{gameObject.name} moving to {targetPos}, current {transform.position}");
    }

    
}
