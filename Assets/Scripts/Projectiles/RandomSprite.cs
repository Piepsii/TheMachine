using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprite : MonoBehaviour
{
    public List<Sprite> Sprites;
    void Awake()
    {
        int index = Random.Range(0, Sprites.Count - 1);
        gameObject.GetComponent<SpriteRenderer>().sprite = Sprites[index];
    }
}
