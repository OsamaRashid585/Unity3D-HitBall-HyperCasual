using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OtherPlayer : MonoBehaviour
{

    private float _movSpeed = 0.2f;
    private Rigidbody _OtherPlayerRb;

    [SerializeField] private GameObject[] _patrolingPoints;
    private int _randomPatrollingPoint;

    [SerializeField] private Material[] _AllMaterials;
    private MeshRenderer _meshRandera;
    [SerializeField] private Text _killScoreTxt;
    private int _killScore;
    // Start is called before the first frame update
    void Start()
    {
        _OtherPlayerRb = GetComponent<Rigidbody>();
        _meshRandera = GetComponent<MeshRenderer>();
        _killScoreTxt = GameObject.FindGameObjectWithTag("OtherPlayerTxt").GetComponent<Text>();
        _killScore = 0;
        
    }
    private void Update()
    {
        _randomPatrollingPoint = Random.Range(0, 4);
    }
    void FixedUpdate()
    {
        PatrollingAI();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("OtherPlayer") ) //|| collision.gameObject.CompareTag("Player")
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
        transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
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

    private void PatrollingAI()
    {
        var dir = _patrolingPoints[_randomPatrollingPoint].transform.position - transform.position;
        _OtherPlayerRb.AddForce(dir.normalized * _movSpeed, ForceMode.Impulse);
    }

}
