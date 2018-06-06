using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {

	public GameObject[] hazards;
	public Vector3 spawnValue;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public float spawnDecrease;

	//Movement movement;

	void Start()
	{
		//GameObject movementObject = GameObject.FindWithTag ("Platform");
		//movement = movementObject.GetComponent<Movement>();

		StartCoroutine (SpawnWaves ());   // Iniciar a corrotina (SpawnWaves)
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for(int i = 0; i < hazardCount; i++)
			{
				GameObject hazard = hazards[Random.Range (0, hazards.Length)];
				Vector3 spawnPosition = new Vector3 (spawnValue.x, Random.Range (-spawnValue.y, spawnValue.y), spawnValue.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
				spawnWait *= (1 - spawnDecrease/100);
				//if (movement.speed > movement.maxSpeed)
				//	spawnDecrease = 0;
			}
			yield return new WaitForSeconds (waveWait);

		}
	}
}