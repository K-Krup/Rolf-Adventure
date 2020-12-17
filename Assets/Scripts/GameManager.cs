using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public Text text;

    private void Awake()
    {
        if (instance == null)
            instance = gameObject.GetComponent<GameManager>();
        else
            Destroy(gameObject);
    }

	void Update()
	{
		if (Input.GetKeyDown("r"))
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public static GameManager GetInstance()
    {
        return instance;
    }

	bool passed = false;

    public void GameOver()
    {
		if(!passed)
        text.text = "YOU DIED";
    }

	public void NailedIt()
	{
		passed = true;
		text.text = "NAILED IT";
	}
}
