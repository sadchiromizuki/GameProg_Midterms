using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public enum EnemyColor
{
    Red, Green, Blue
}

public class EnemyBehavior : MonoBehaviour
{
    public EnemyColor enemyColor;   
    public float speed;
    public GameObject redEnemy, greenEnemy, blueEnemy;
    public PlayerBehavior playerBehavior;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
        LookRotation();
        
    }

    void EnemyMovement()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, GameManager.Instance.player.position, step);
    }

    void LookRotation()
    {
        Vector3 relativePos = GameManager.Instance.player.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;
    }
    void ChangeColor()
    {
        switch (enemyColor)
        {
            case EnemyColor.Red:
                redEnemy.SetActive(true);
                blueEnemy.SetActive(false);
                greenEnemy.SetActive(false);
                break;
            case EnemyColor.Green:
                greenEnemy.SetActive(true);
                redEnemy.SetActive(false);
                blueEnemy.SetActive(false);
                break;
            case EnemyColor.Blue:
                blueEnemy.SetActive(true);
                greenEnemy.SetActive(false);
                redEnemy.SetActive(false);
                break;
            default:
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (enemyColor == EnemyColor.Red)
        {
            if (other.CompareTag("RedBullet"))
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
                LookRotation();
                Debug.Log("RedBullet");
            }
            else
            {
                Destroy(other.gameObject);
            }

        }
        if (enemyColor == EnemyColor.Green)
        {
            if (other.CompareTag("GreenBullet"))
            {
                Destroy (other.gameObject);
                Destroy(gameObject);
                LookRotation();
                Debug.Log("GreenBullet");
            }
            else
            {
                Destroy(other.gameObject) ;
            }
        }
        if (enemyColor == EnemyColor.Blue)
        {
            if (other.CompareTag("BlueBullet"))
            {
                Destroy (other.gameObject);
                Destroy(gameObject);
                LookRotation();
                Debug.Log("BlueBullet");
            }
            else
            {
                Destroy(other.gameObject);
            }
        }


    }
}
