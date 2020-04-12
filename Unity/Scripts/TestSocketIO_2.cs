﻿#region License
/*
 * TestSocketIO.cs
 *
 * The MIT License
 *
 * Copyright (c) 2014 Fabio Panettieri
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
#endregion

using System.Collections;
using UnityEngine;
using SocketIO;
using System.Collections.Generic;

public class TestSocketIO_2 : MonoBehaviour
{
    private SocketIOComponent socket;

    private List<JSONObject> coordinates;

    private List<GameObject> objects;
    private bool allObjectsGenerated = false;

    private int screenHeight;
    private int screenWidth;
    public int distanceFromCamera = 10;

    Camera cam;

    public void Start()
    {
        GameObject go = GameObject.Find("SocketIO");
        socket = go.GetComponent<SocketIOComponent>();
        objects = new List<GameObject>();

        socket.On("data", ReceivedData);
        coordinates = new List<JSONObject>();

        cam = Camera.main;
        screenHeight = Screen.height;
        screenWidth = Screen.width;
    }

    public void ReceivedData(SocketIOEvent e)
    {
        coordinates = e.data[0][0].list;
    }

    private void Update()
    {
        visualiseJoints(coordinates);
    }

    private void visualiseJoints(List<JSONObject> coordinates)
    {

        // CHECK IF THE OBJECT LIST HAS AS MANY ITEMS AS THE COORDINATES LIST
        allObjectsGenerated = objects.Count == coordinates.Count;

        foreach (JSONObject item in coordinates)
        {
            int index = coordinates.IndexOf(item);

            // CREATE ALL GAMEOBJECTS
            if (!allObjectsGenerated)
            {

                // CREATE THE SPHERES
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.name = "sphere_" + index;
                objects.Add(sphere);

            }

            // EXTRACT AND CONVERT COORDINATES
            float x = item[0].f;
            float y = 1 - item[1].f;

            Vector3 pos = cam.ScreenToWorldPoint(new Vector3(screenWidth * x, screenHeight * y, distanceFromCamera));

            // APPLY COORDINATES TO SPHERES
            objects[index].transform.position = pos;

        }
    }


}
