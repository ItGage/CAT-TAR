using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SongChart))]
public class SongChartEditor : Editor
{
    private int currentMeasureIndex = 0;

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        SongChart chart = (SongChart)target;

        SerializedProperty measuresProperty =
            serializedObject.FindProperty("measures");

        if (measuresProperty.arraySize == 0)
        {
            EditorGUILayout.LabelField("No measures in chart.");

            if (GUILayout.Button("Add Measure"))
            {
                chart.AddMeasure();
                EditorUtility.SetDirty(chart);
            }

            serializedObject.ApplyModifiedProperties();
            return;
        }

        EditorGUILayout.LabelField
        (
            "Measure " + (currentMeasureIndex + 1),
            EditorStyles.boldLabel
        );

        EditorGUILayout.Space();

        //----------------------------------------Current Measure------------------------------------//

        SerializedProperty currentMeasureProperty =
            measuresProperty.GetArrayElementAtIndex(currentMeasureIndex);

        SerializedProperty lanesProperty =
            currentMeasureProperty.FindPropertyRelative("lanes");

        //----------------------------------------Lane Headers------------------------------------//

        EditorGUILayout.BeginHorizontal();

        GUILayout.Label("", GUILayout.Width(50));

        for (int laneIndex = 0; laneIndex < lanesProperty.arraySize; laneIndex++)
        {
            GUILayout.Label("Lane " + (laneIndex + 1));
        }

        EditorGUILayout.EndHorizontal();

        //----------------------------------------Chart Grid------------------------------------//

        //draws sixteenths backwards so the earliest note is at the bottom
        for (int sixteenthIndex = 15; sixteenthIndex >= 0; sixteenthIndex--)
        {
            EditorGUILayout.BeginHorizontal();

            GUILayout.Label
            (
                (sixteenthIndex + 1).ToString(),
                GUILayout.Width(50)
            );

            for (int laneIndex = 0; laneIndex < lanesProperty.arraySize; laneIndex++)
            {
                SerializedProperty laneProperty =
                    lanesProperty.GetArrayElementAtIndex(laneIndex);

                SerializedProperty sixteenthsProperty =
                    laneProperty.FindPropertyRelative("sixteenths");

                SerializedProperty sixteenthProperty =
                    sixteenthsProperty.GetArrayElementAtIndex(sixteenthIndex);

                SerializedProperty interactableProperty =
                    sixteenthProperty.FindPropertyRelative("interactable");

                EditorGUILayout.PropertyField
                (
                    interactableProperty,
                    GUIContent.none
                );
            }

            EditorGUILayout.EndHorizontal();

            //adds a little separation between beats
            if (sixteenthIndex % 4 == 0)
            {
                EditorGUILayout.Space(6);
            }
        }

        //----------------------------------------Measure Controls------------------------------------//

        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("Previous Measure"))
        {
            if (currentMeasureIndex > 0)
            {
                currentMeasureIndex--;
            }
        }

        if (GUILayout.Button("Next Measure"))
        {
            if (currentMeasureIndex < measuresProperty.arraySize - 1)
            {
                currentMeasureIndex++;
            }
        }

        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Add Measure"))
        {
            chart.AddMeasure();

            currentMeasureIndex = chart.measures.Count - 1;

            EditorUtility.SetDirty(chart);
        }

        serializedObject.ApplyModifiedProperties();
    }
}