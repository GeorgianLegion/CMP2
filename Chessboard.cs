using UnityEngine;
using System.Collections;

public class Chessboard : MonoBehaviour {

	public int m_iSize = 10;
	GameObject[,] m_Grid;

	// Use this for initialization
	void Start () {
		m_Grid = new GameObject[m_iSize, m_iSize];

		for (int i =0; i < m_iSize; i++)
			for (int j =0; j < m_iSize; j++) {
				GameObject kachel = GameObject.CreatePrimitive (PrimitiveType.Quad);
				kachel.name = "Kachel [" + i + "] [" + j + "]";
				m_Grid [i, j] = kachel;
				kachel.transform.position = new Vector3 (i, j, 0);
				kachel.transform.parent = this.transform;
			}

		Camera.main.transform.position = new Vector3 (m_iSize / 2, m_iSize / 2, -10);
		Camera.main.orthographicSize = m_iSize;
		transform.position = new Vector3 (0.5f, 0.5f, 0);

		for (int i = 0; i < m_iSize; i++) 
			for (int j = 0; j < m_iSize; j++) {
				float Farben = Random.value;
				if (Farben <= 0.5)
					m_Grid [i, j].GetComponent<Renderer> ().material.color = Color.blue;
			}
			Debug.Log (GetAliveNeighbours (0, 0));

	}

		int GetAliveNeighbours (int _iColumn, int _iRow){
			int AliveNeighboursCounter = 0;
			for (int i = 0; i < 3; i++) {
				int iTemp = i + _iColumn - 1;
				for (int j = 0; j < 3; j++) {
					int jTemp = j + _iRow - 1;
					if (!(iTemp == _iColumn && jTemp == _iRow) && !(iTemp <0) && !(jTemp<0))
						if (m_Grid [iTemp,jTemp].GetComponent<Renderer>().material.color == Color.blue)
							AliveNeighboursCounter ++;
						

			}
		}
		return AliveNeighboursCounter;
	
	}
	
	
	// Update is called once per frame
	void Update () {
	
	}


}
