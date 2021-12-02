using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ParticleScaler))]
public class ParticleScalerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        ParticleScaler scaler = (ParticleScaler)target;

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("-- ��ƼŬ ������ ���� �� --");
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("ScalingMode�� Hierarchy�� �Ǿ��־�� Scale ������ ��Ȱ�ϰ� �˴ϴ�.");
        EditorGUILayout.LabelField("ó�� �ѹ��� �����ϸ� �˴ϴ�.");

        if (GUILayout.Button("Hierarchy�� ����"))
        {
            scaler.ParticleScalingModeChange();
        }

        EditorGUILayout.Space();
        EditorGUILayout.Space();

        scaler.scaleFactor = EditorGUILayout.FloatField("��ƼŬ ũ��", scaler.scaleFactor);

        if (GUILayout.Button("��ƼŬ ������ ����"))
        {
            scaler.ParticleScaleChange();
        }


    }
}