using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public bool IsCubeInside = false;

    [SerializeField] KeyCode keyOne;
    [SerializeField] KeyCode keyTwo;
    [SerializeField] Vector3 moveDirection;

    private void FixedUpdate()
    {
        if (Input.GetKey(keyOne))
        {
            GetComponent<Rigidbody>().velocity += moveDirection;
        }
        if (Input.GetKey(keyTwo))
        {
            GetComponent<Rigidbody>().velocity -= moveDirection;
        }
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKey(KeyCode.T))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("Player") && other.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (this.CompareTag("Player") && other.CompareTag("Finish7"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 7);
        }
        if (this.CompareTag("Player") && other.CompareTag("NoFinish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        if ((this.CompareTag("Cube") && other.CompareTag("Cube")) || (this.CompareTag("Player") && other.CompareTag("Cube")))
        {
            IsCubeInside = true;

            foreach (Activator button in FindObjectsOfType<Activator>())
            {
                button.canPush = false;
            };
        };
    }
    private void OnTriggerExit(Collider other)
    {
        if ((this.CompareTag("Cube") && other.CompareTag("Cube")) || (this.CompareTag("Player") && other.CompareTag("Cube")))
        {
            IsCubeInside = false;

            int CountCubeInside = 0;
            foreach (Player player in FindObjectsOfType<Player>())
            {
                if (player.IsCubeInside)
                    CountCubeInside++;
            };

            if (CountCubeInside == 0)
                foreach (Activator button in FindObjectsOfType<Activator>())
                {
                    button.canPush = true;
                };
        };
    }
}
