using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class WeepingAngelAIScript : MonoBehaviour
{
    public static WeepingAngelAIScript instance;
    public bool canMove = false;
    public Transform target;
    public float catchDistance = 1.5f;
    public string gameOverSceneName = "GameOver";

    private NavMeshAgent agent;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (agent == null)
        {
            Debug.LogError("NavMeshAgent component not found!");
            enabled = false;
            return;
        }

        agent.stoppingDistance = catchDistance;
        agent.updateRotation = false;   // we rotate manually
        agent.updateUpAxis = true;
    }

    void Update()
    {
        if (!target) return;

        // Move using NavMesh
        agent.SetDestination(target.position);

        // Rotate ONLY when moving
        Vector3 velocity = agent.velocity;
        velocity.y = 0;

        if (velocity.sqrMagnitude > 0.01f)
        {
            Quaternion lookRot = Quaternion.LookRotation(velocity);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                lookRot,
                Time.deltaTime * 10f
            );
        }

        // Catch player

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){other.GetComponent<PlayerHealth>().TakeDamage(); Freeze();}
    }

    public void Freeze()
    {
        // agent.speed = 0;
        canMove = false;
        agent.isStopped = true;
    }

    public void Chase()
    { 
        // agent.speed = 3.5f;
        canMove = true;
        agent.isStopped = false;
        
    }
}
 