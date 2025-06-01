using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElephantKnockDown : MonoBehaviour
{
    public int maxBreaks = 10;
    private int currentBreaks = 0;
    [SerializeField] private GameObject Angry;
    [SerializeField] private AudioSource ElephantSound;
    public KnockDownBar knockdownbar;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Breakable"))
        {
            Angry.SetActive(true);

            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.gravityScale = 1.5f;
            }
            ElephantSound.Play();
            currentBreaks++;
            knockdownbar?.UpdateBar(currentBreaks, maxBreaks);

           
            StartCoroutine(DestroyAfterDelay(collision.gameObject, 2.5f));

            if (currentBreaks >= maxBreaks)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        if (collision.gameObject.CompareTag("Door"))
        {
            SceneManager.LoadScene("LastScene");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Breakable"))
        {
            Angry.SetActive(false);
        }
    }

    private IEnumerator DestroyAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(obj);
    }
}
