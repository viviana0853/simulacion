using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GeneradorDeCarros : MonoBehaviour {
	
	public GameObject carro;
	public Transform origen;
	GameObject copiaCarro;
	int i=0,time=0;
	MarkovGenerate.MarkovNameGenerator datos =null;
	// Use this for initialization
	void Start () {
		copiaCarro = carro;
		datos = new MarkovGenerate.MarkovNameGenerator (new List<string> { "300", "110","240","310","100","240","290","140","320"},1,1);
		time=int.Parse(datos.NextTime);
	}
	
	// Update is called once per frame
	void Update () {
		if (i == time) {
			time=int.Parse(datos.NextTime);

			this.copiaCarro = Instantiate (carro.transform,
			                               origen.position,
			                               origen.rotation) as GameObject;
			i=0;
		}
		if (i > 360) {
			datos = new MarkovGenerate.MarkovNameGenerator (new List<string> { "300", "110","240","310","100","240","290","140","320"},1,1);
			time=int.Parse(datos.NextTime);
			i=0;
		}
		i++;
		
	}
}