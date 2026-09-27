using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SongChart))]
public class SongChartEditor : Editor
{
    private int currentMeasureIndex = 0;

    //----------------------------------------Session State------------------------------------//

    private string GetMeasureSessionKey()
    {
        string assetPath = AssetDatabase.GetAssetPath(target);
        string assetGUID = AssetDatabase.AssetPathToGUID(assetPath);

        return "SongChartEditor_CurrentMeasure_" + assetGUID;
    }

    private void OnEnable()
    {
        currentMeasureIndex =
            SessionState.GetInt(GetMeasureSessionKey(), 0);
    }

    private void SaveCurrentMeasure()
    {
        SessionState.SetInt
        (
            GetMeasureSessionKey(),
            currentMeasureIndex
        );
    }

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
                Undo.RecordObject(chart, "Add Measure");

                chart.AddMeasure();

                currentMeasureIndex = 0;
                SaveCurrentMeasure();

                EditorUtility.SetDirty(chart);
            }

            serializedObject.ApplyModifiedProperties();
            return;
        }

        //keeps saved measure index from going past the end of the chart
        if (currentMeasureIndex >= measuresProperty.arraySize)
        {
            currentMeasureIndex =
                measuresProperty.arraySize - 1;

            SaveCurrentMeasure();
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
                SaveCurrentMeasure();
            }
        }

        if (GUILayout.Button("Next Measure"))
        {
            if (currentMeasureIndex < measuresProperty.arraySize - 1)
            {
                currentMeasureIndex++;
                SaveCurrentMeasure();
            }
        }

        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("Add Measure"))
        {
            Undo.RecordObject(chart, "Add Measure");

            chart.AddMeasure();

            currentMeasureIndex = chart.measures.Count - 1;

            SaveCurrentMeasure();

            EditorUtility.SetDirty(chart);
        }

        if (GUILayout.Button("Remove Measure"))
        {
            //keeps at least one measure in the chart
            if (chart.measures.Count > 1)
            {
                bool confirmed = EditorUtility.DisplayDialog
                (
                    "Remove Measure",
                    "Are you sure you want to remove Measure " +
                    (currentMeasureIndex + 1) + "?",
                    "Remove",
                    "Cancel"
                );

                if (confirmed)
                {
                    Undo.RecordObject(chart, "Remove Measure");

                    chart.measures.RemoveAt(currentMeasureIndex);

                    //if the last measure was removed, move back to the new last measure
                    if (currentMeasureIndex >= chart.measures.Count)
                    {
                        currentMeasureIndex =
                            chart.measures.Count - 1;
                    }

                    SaveCurrentMeasure();

                    EditorUtility.SetDirty(chart);
                }
            }
        }

        EditorGUILayout.EndHorizontal();

        serializedObject.ApplyModifiedProperties();
    }
}