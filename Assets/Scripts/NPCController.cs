using System.Collections;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public NodeController nodeController;
    public Transform player;
    private Node currentNode;
    private Node targetNode;
    private Node previousNode = null;
    public float speed = 5f;
    public float energy = 20f;
    public float restDuration = 4f;
    public float chaseDuration = 5f;
    private bool isChasingPlayer = false;
    private float chaseTimer;
    private BoxCollider2D visionCollider;
    void Start()
    {
        currentNode = nodeController.GetRandomNode();
        transform.position = currentNode.transform.position;
        chaseTimer = chaseDuration;
        visionCollider = GetComponent<BoxCollider2D>();
        visionCollider.isTrigger = true;
        visionCollider.size = new Vector2(10f, 1f);
    }

    void Update()
    {
        if (energy <= 0)
        {
            StartCoroutine(Rest());
        }
        else if (isChasingPlayer)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isChasingPlayer = true;
            chaseTimer = chaseDuration;
            targetNode = null;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isChasingPlayer = false;
            chaseTimer = chaseDuration;
        }
    }

    void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        energy -= Time.deltaTime;
        chaseTimer -= Time.deltaTime;
        if (chaseTimer <= 0 || Vector2.Distance(transform.position, player.position) < 0.1f)
        {
            isChasingPlayer = false;
            chaseTimer = chaseDuration;
        }
    }

    void Patrol()
    {
        if (targetNode == null)
        {
            targetNode = currentNode.GetRandomNeighbor(previousNode);
        }
        if (targetNode != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetNode.transform.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, targetNode.transform.position) < 0.1f)
            {
                energy -= targetNode.weight;
                previousNode = currentNode;
                currentNode = targetNode;
                targetNode = null;
            }
        }
    }

    IEnumerator Rest()
    {
        yield return new WaitForSeconds(restDuration);
        energy = 20f;
    }
}