using UnityEngine;

public class JumpscareTrigger : MonoBehaviour
{
    public AudioSource jumpscareAudio; // Drag your character's Audio Source here in the Inspector
    public Animator playerAnimator;     // Drag your player's Animator here (if you have a jumpscare animation)
    public string triggerAnimationName = ""; // Name of your jumpscare animation trigger parameter (optional)
    private bool hasTriggered = false;    // To ensure the jumpscare only happens once

    // OnTriggerEnter is called when another Collider enters this object's Collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering object is the player and the jumpscare hasn't happened yet
        if (!hasTriggered && other.CompareTag("Player"))
        {
            TriggerJumpscare(); // Call the function to trigger the jumpscare
        }
    }

    // Function to trigger the jumpscare
    public void TriggerJumpscare()
    {
        hasTriggered = true; // Set the flag to true so it doesn't trigger again

        // Play the jumpscare audio, if an AudioSource is assigned
        if (jumpscareAudio != null)
        {
            jumpscareAudio.Play();
        }
        else
        {
            Debug.LogError("Jumpscare AudioSource is not assigned!  Make sure to drag the AudioSource from your character to the Jumpscare Audio field in the Inspector.");
        }

        // Play the jumpscare animation, if an Animator and trigger name are provided
        if (playerAnimator != null && !string.IsNullOrEmpty(triggerAnimationName))
        {
            playerAnimator.SetTrigger(triggerAnimationName);
        }
        else if (playerAnimator == null)
        {
            Debug.LogWarning("Player Animator is not assigned. No jumpscare animation will play.  Drag the player's Animator component to the Player Animator field in the Inspector if you want an animation.");
        }
        else if (string.IsNullOrEmpty(triggerAnimationName))
        {
            Debug.LogWarning("Jumpscare Animation Trigger Name is empty. No jumpscare animation will play.  Enter the name of the trigger parameter in your Animator that starts the animation.");
        }

        // Optional: You can disable or destroy the trigger after it's used
        // Destroy(gameObject); // Destroys the entire trigger object
        // GetComponent<Collider>().enabled = false; // Disables the Collider, so it can't trigger again
    }
}