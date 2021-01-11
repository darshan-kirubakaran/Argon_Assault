using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;

    ScoreBoard scoreBoard;

    // Start is called before the first frame update
    void Start()
    {
        AddBocCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddBocCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnParticleCollision(GameObject other)
    {
        scoreBoard.ScoreHit(scorePerHit);
        GameObject VFX = Instantiate(deathVFX, transform.position, Quaternion.identity);
        VFX.transform.parent = parent;;
        Destroy(gameObject);
    }
}

