using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
/*
This editor scripts aplies: the collider, the rigidBoddy and the OVRGrable script, to selected objects 
Usefull when you need to grabe multiple objects in your game  
*/
// the OVRGrable script is incluced in the oculus integration package

public class MakeObjectGrabable : EditorWindow
{
    public int selGridInt = 0;
    [MenuItem("Tools/Make Grabable")]
    static void CreateAddGenericColider()
    {
        EditorWindow.GetWindow<MakeObjectGrabable>();
    }

    //the functions that aplies the physics
    void Addphysics(GameObject object1,int selection )
    {
        switch (selection)
        {
            case 0:
                object1.AddComponent<BoxCollider>();
                break;
            case 1:
                 object1.AddComponent<SphereCollider>();
                break;
            case 2:
                object1.AddComponent<CapsuleCollider>();
                break;
            case 3:
                object1.AddComponent<MeshCollider>();
                break;

            default:
                object1.AddComponent<BoxCollider>();
                break;

        }
        Rigidbody gameObjectsRigidBody = object1.AddComponent<Rigidbody>();
        object1.AddComponent<OVRGrabbable>();
    }

    private void OnGUI()
    {
        //selGrid for the type of collider you want to use, preset to boxcollider 
        string[] selStrings = new string[] { "Box Collider", "Shpere Collider","Capsule Collider", "Mesh Collider" };        
        selGridInt = GUILayout.SelectionGrid(selGridInt, selStrings, 2);
        GUILayout.Space(15);
        if (GUILayout.Button("Make Grabable"))
        {
            var selection = Selection.gameObjects;
            for (var i = selection.Length - 1; i >= 0; --i)
            {

                Addphysics(selection[i], selGridInt);
            }
        }

        GUI.enabled = false;
        //count the selectec objects
        EditorGUILayout.LabelField("Selection count: " + Selection.objects.Length);
    }
}


