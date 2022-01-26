using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 0;
    private Rigidbody enemyRb;
    private GameObject player;
    private Vector3 lookDirection;
    public bool isDead = false;
    PlayerController playerControllerScript;
    private GameObject lastContacted = null;
    private MeshRenderer meshRenderer;
    public Texture[] texture;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            lookDirection = (player.transform.position - transform.position).normalized;
            enemyRb.AddForce(lookDirection * speed * Time.deltaTime);
            if (transform.position.y < 0 && lastContacted != null)
            {
                PlayerDeath(playerControllerScript);
            }
        }

    }

    void PlayerDeath(PlayerController player)
    {
        isDead = true;
        int playerTexture = Random.Range(0, texture.Length);
        meshRenderer = lastContacted.gameObject.GetComponent<MeshRenderer>();
        lastContacted.transform.localScale += transform.localScale;
        lastContacted.gameObject.GetComponent<Rigidbody>().mass += 1;
        meshRenderer.material.SetTexture("_MainTex", texture[playerTexture]);
        player.killCounter++;
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground"))
        {
            lastContacted = collision.gameObject;
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 2, ForceMode.Impulse);
        }
    }
}
