using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(InteractiveObject)), CanEditMultipleObjects]
public class InteractiveObjectEditor : Editor {

    //int examineIndex;
    //string[] dialogueOptions = new string[0];

    //private void OnEnable()
    //{
    //    if (DialogueManager.Dialogues == null)
    //        return;

    //    dialogueOptions = DialogueManager.Dialogues.Select(d => d.name).ToArray();
    //}

    //public override void OnInspectorGUI()
    //{
    //    EditorGUILayout.LabelField("Dialogues", vnc.Editor.VNCStyles.CenteredLabelBold);
    //    examineIndex = EditorGUILayout.Popup("Examine Dialogue", examineIndex, dialogueOptions);
    //    base.OnInspectorGUI();


    //}
}
