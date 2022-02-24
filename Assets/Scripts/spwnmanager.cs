using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spwnmanager : MonoBehaviour
{
   [SerializeField] private GameObject _otherPlayer;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("OtherPlayer"))
        {
            Destroy(collision.gameObject);
            spwnenemy();
            Debug.Log("ohtePol");
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(0);

        }
    }

    void spwnenemy()
    {
        Instantiate(_otherPlayer, new Vector3(Random.Range(-9, 9), 0, Random.Range(-9, 9)), Quaternion.identity);
    }
}
