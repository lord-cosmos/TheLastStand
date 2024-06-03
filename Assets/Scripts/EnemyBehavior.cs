using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float movementSpeed = 5f; // Speed at which the enemy moves towards the player
    public float minDistance = 100f; // Minimum distance to maintain from the player

    private void Update()
    {
        // Check if the player's transform is assigned
        if (player != null)
        {
            // Calculate the direction towards the player
            Vector3 directionToPlayer = (player.position - transform.position).normalized;

            // Calculate the distance to the player
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // If the enemy is too close to the player, move away
            if (distanceToPlayer < minDistance)
            {
                directionToPlayer *= -1; // Move away from the player
            }

            // Smoothly rotate towards the player's position
            Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

            // Move towards the player
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
        }
    }
}
