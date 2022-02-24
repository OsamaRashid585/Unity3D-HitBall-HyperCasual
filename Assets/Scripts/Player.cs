using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private float _movSpeed = 0.1f;
    private Rigidbody _playerRb;
    private Vector3 _moveInp;

    [SerializeField] private Material[] _AllMaterials;
    private MeshRenderer _meshRandera;
    [SerializeField] private Text _killScoreTxt;
    private int _killScore;

    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _meshRandera = GetComponent<MeshRenderer>();
        _killScore = 0;
        
    }

    void Update()
    {
        _moveInp = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
    }

    void FixedUpdate()
    {
        _playerRb.AddForce(_moveInp.normalized * _movSpeed, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.CompareTag("OtherPlayer") || collision.gameObject.CompareTag("Player"))
        {
            var OtherPlayers = collision.gameObject.GetComponent<Rigidbody>();

            var distance = collision.gameObject.transform.position - transform.position;

            OtherPlayers.AddForce(distance * 12f, ForceMode.Impulse);
            SizeIncreaseOnKill();
            ChangeTextureOnKill();
            ADDKillScore();
        }
    }

    private void SizeIncreaseOnKill()
    {
        transform.localScale += new Vector3(0.15f, 0.15f, 0.15f);
    }
    private void ChangeTextureOnKill()
    {
        _meshRandera.material = _AllMaterials[Random.Range(0, 4)];
    }
    private void ADDKillScore()
    {
        _killScore++;
        _killScoreTxt.text = gameObject.name + "kills: " + _killScore;
    }
}
