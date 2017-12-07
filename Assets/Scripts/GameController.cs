using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public GameObject[] hazards;
	public GameObject flagShip;
	public Vector3 spawnValues;
	public int hazardCount;
	public int bossWait;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	private int waveCount;
	public int bossWave;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
    public GUIText bossText;
	public GUIText bonusText;
   

    private bool gameOver;
	private bool restart;
	private int score;

	void Start ()
	{
		gameOver = false;
		gameOver = false;
		restartText.text = "";
		gameOverText.text = "";
        bossText.text = "";
        score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
		waveCount = 0;
	}

	void Update ()
	{
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}

	}


	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);

		while (true) {
			waveCount = waveCount + 1;

            if (score < 500)
            {
                for (int i = 0; i < hazardCount; i++)
                {
                    GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                    Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(hazard, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
					bonusText.text = "";
                }
            }
            else
            {
                for (int i = 0; i < hazardCount * score * 0.002; i++)
                {
                    GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                    Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(hazard, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
					bonusText.text = "";
                    
                }

            }
			yield return new WaitForSeconds (waveWait);



			if (gameOver) {
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
			if (waveCount == bossWave) 
			{
                waveCount = 0;
                bossText.text = "Boss Fight";
                yield return new WaitForSeconds(startWait);
                bossText.text = "";
                Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (flagShip, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (bossWait);
			}
		}

	}


	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}