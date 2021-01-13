using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;
    [SerializeField] int hits = 100;

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
        ProccessHit();
        if (hits < 1)
        {
            KillEnemy();
        }
    }

    private void ProccessHit()
    {
        scoreBoard.ScoreHit(scorePerHit);
        hits = hits - 1;
    }

    private void KillEnemy()
    {
        GameObject VFX = Instantiate(deathVFX, transform.position, Quaternion.identity);
        VFX.transform.parent = parent; ;
        Destroy(gameObject);
    }
}

