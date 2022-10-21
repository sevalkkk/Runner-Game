using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject Trap;
    public Transform spawnPoint;
    int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject playButton;
    public GameObject player;

   

    IEnumerator SpawnTraps()
    {
        while(true)
        {
            float waitTime = Random.Range(0.5f, 2);

            yield return new WaitForSeconds(waitTime);

            Instantiate(Trap, spawnPoint.position, Quaternion.identity);
        }
    }

    void ScoreUpdate()
    {
        score++;
        scoreText.text = score.ToString();
    }
    public void GameStart()
    {
        scoreText.gameObject.SetActive(true);
        player.SetActive(true);
        playButton.SetActive(false);

        StartCoroutine("SpawnTraps");
        InvokeRepeating("ScoreUpdate",2f,1f);
    }
}
