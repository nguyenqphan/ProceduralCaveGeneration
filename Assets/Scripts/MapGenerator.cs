﻿using UnityEngine;
using System.Collections;
using System;

public class MapGenerator : MonoBehaviour {

	public int width;
	public int height;

	public string seed;
	public bool useRandomSeed;

	[Range(0,100)]
	public int randomFillPercent;

	int [,] map;

	void Start()
	{
		GenerateMap();

	}


	void GenerateMap()
	{
		map = new int[width,height];
		RandomFillMap();
	}

	void RandomFillMap()
	{
		if(useRandomSeed)
		{
			seed = Time.time.ToString();
		}

		System.Random psuedoRandom = new System.Random(seed.GetHashCode());

		for(int x = 0; x < width; x++)
		{
			for(int y = 0; y < height; y++)
			{
				map[x,y] = (psuedoRandom.Next(0,100) < randomFillPercent)? 1 : 0;
			}
		}
	}

	void OnDrawGizmos()
	{
		if(map != null)
		{
			for(int x = 0; x < width; x++)
			{
				for(int y = 0; y < height; y++)
				{
					Gizmos.color = (map[x,y] == 1)? Color.black : Color.white;
					Vector3 pos = new Vector3(-width/2 + x + 0.5f, 0, -height/2 + y + 0.5f);
					Gizmos.DrawCube(pos, Vector3.one);
				}
			}
		}
	}











}
