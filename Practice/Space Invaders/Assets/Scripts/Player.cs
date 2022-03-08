using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public AudioClip clip;
  public GameObject bullet;

  public Transform shottingOffset;
  public float speed = 20;

  private AudioSource source;
  // Update is called once per frame

  void Start()
  {
    source = GetComponent<AudioSource>();
    source.clip = clip;
  }

  void Update()
    {
      float axis = Input.GetAxis("Horizontal");
      Vector3 v3 = new Vector3(axis * speed * Time.deltaTime, 0f, 0f);
      // rBody2D.AddForce(v2, ForceMode2D.Impulse);
      if (transform.position.x >= 20.95)
      {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
      }else if (transform.position.x <= -20.95)
      {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
      }
      else
      {
        transform.position += v3;
      }
      
      if (Input.GetKeyDown(KeyCode.Space))
      {
        
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
        // Debug.Log("Bang!");
        source.Play();
        Destroy(shot, 3f);

      }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
      if (col.gameObject.name == "Enemy_Bullet(Clone)")
      {
        Destroy(gameObject);
        Debug.Log("Player got shot");
      }
    }
}
