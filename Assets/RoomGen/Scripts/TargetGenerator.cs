using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


namespace RoomGen
{
    [RequireComponent(typeof(PresetEditorComponent))]
    public class TargetGenerator : MonoBehaviour
    {
        public RoomPreset preset;


        public float radius = 5;
        public int objectDensity = 500;

        [Range(0, 99999)] public int seed;

        public bool alignToSurface;
        public LayerMask surfaceLayer;
        public bool debug;
        private float angle = 0.5f;


        List<GameObject> generated = new List<GameObject>();
        List<DecoratorPoint> points = new List<DecoratorPoint>();


        void SpiralSequence()
        {
            Random.InitState(seed);

            for (int x = 0; x < objectDensity; x++)
            {
                float r = Mathf.Sqrt((x + angle) / objectDensity);
                float theta = Mathf.PI * (1 + Mathf.Pow(5, angle)) * (x + angle);

                float xPos = r * Mathf.Cos(theta) * radius;
                float yPos = 0;
                float zPos = r * Mathf.Sin(theta) * radius;

                Vector3 pos = new Vector3(transform.position.x + xPos, transform.position.y + yPos, transform.position.z + zPos);

                if (alignToSurface)
                {
                    Ray ray = new Ray(pos + (Vector3.up * 5f), Vector3.down);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit, 100f, surfaceLayer))
                    {
                        DecoratorPoint decorPoint = new DecoratorPoint(null, null, hit.point, PointType.Floor, false, 0);
                        if (!points.Contains(decorPoint))
                        {
                            points.Add(decorPoint);
                        }
                    }
                }
                else
                {
                    DecoratorPoint decorPoint = new DecoratorPoint(null, null, pos, PointType.Floor, false, 0);
                    if (!points.Contains(decorPoint))
                    {
                        points.Add(decorPoint);
                    }
                }
            }


            GenerateObjects(preset.floorDecorations);
        }


        void GenerateObjects(List<Decoration> decorList)
        {
            for (int i = 0; i < decorList.Count; i++)
            {
                if (preset == null)
                {
                    return;
                }
                else
                {
                    if (!debug)
                    {
                        if (preset.floorDecorations.Count == 0)
                            return;

                        // Grab the decoration from our decoration collection.
                        Decoration decoration = decorList[i];

                        if (decoration.prefab == null)
                            continue;

                        List<DecoratorPoint> validPoints = new List<DecoratorPoint>(Tools.GetValidPoints(points, false, PointType.Floor));

                        // Get a random amount based on the provided min/max specified.
                        int randomAmount = Random.Range(decoration.amountRange.x, decoration.amountRange.y);

                        // Spawn the amount of decorations required to meet our min/max spawning requirement.
                        for (int decorCount = 0; decorCount < randomAmount; decorCount++)
                        {
                            //Get a random point to spawn the decoration.
                            DecoratorPoint randomPoint = Tools.RandomPoint(validPoints, false, PointType.Floor, decoration.prefab);
                            if (randomPoint == null || decoration.prefab == null)
                            {
                                continue;
                            }

                            // The spawning buffer will prevent items of the same type from spawning too close together.
                            for (int pointIndex = validPoints.Count - 1; pointIndex >= 0; pointIndex--)
                            {
                                DecoratorPoint point = validPoints[pointIndex];
                                if (Vector3.Distance(point.point, randomPoint.point) <= decoration.spacingBuffer)
                                {
                                    validPoints.Remove(point);
                                }
                            }

                            randomPoint.occupied = true;

                            GameObject decor = Instantiate(decoration.prefab, randomPoint.point, Quaternion.identity);
                            if (randomPoint.tileObject != null)
                            {
                                decor.transform.rotation *= randomPoint.tileObject.transform.rotation;
                            }

                            decor.transform.rotation *= Quaternion.Euler(decoration.rotationOffset);
                            Tools.AdjustPosition(decor, decoration.positionOffset);

                            decor.transform.Rotate(Vector3.up * Random.Range(0, decoration.randomRotation), Space.World);

                            decor.transform.localScale *= Random.Range(decoration.scaleRange.x, decoration.scaleRange.y);
                            decor.transform.parent = transform;
                            generated.Add(decor);
                        }
                    }
                }
            }
        }


        void ClearObjects()
        {
            foreach (GameObject obj in generated)
            {
                DestroyImmediate(obj);
            }

            foreach (Transform child in transform)
            {
                DestroyImmediate(child.gameObject);
            }

            generated.Clear();
        }


        private void OnDrawGizmos()
        {
            if (debug)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Gizmos.color = Color.white;
                    Gizmos.DrawWireSphere(points[i].point, 0.125f);
                }
            }
#if UNITY_EDITOR
            if (UnityEditor.Selection.activeGameObject == this.gameObject)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawWireSphere(transform.position, radius);
            }
#endif
        }


        public void Generate()
        {
            points.Clear();
            ClearObjects();
            SpiralSequence();
        }
    }
}