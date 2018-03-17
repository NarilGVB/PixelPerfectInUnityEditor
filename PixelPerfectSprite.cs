#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class PixelPerfectSprite : MonoBehaviour 
{
    [SerializeField]
    private int pixelsPerUnit = 16;

    private void LateUpdate() 
    {
		if (!Application.isPlaying && UnityEditor.Selection.Contains(gameObject)) {
			SetPixelPerfect();
		}
    }

	public void SetPixelPerfect(){

        SpriteRenderer renderer;

        if((renderer = GetComponent<SpriteRenderer>())!= null && renderer.drawMode == SpriteDrawMode.Sliced){
            Vector2 newForm = Vector2.zero;

            newForm.x = (Mathf.Round(renderer.size.x * pixelsPerUnit) / pixelsPerUnit);
            newForm.y = (Mathf.Round(renderer.size.y * pixelsPerUnit) / pixelsPerUnit);

            renderer.size = newForm;
        }

		Vector3 newLocalPosition = Vector3.zero;

        newLocalPosition.x = (Mathf.Round(transform.position.x * pixelsPerUnit) / pixelsPerUnit);
        newLocalPosition.y = (Mathf.Round(transform.position.y * pixelsPerUnit) / pixelsPerUnit);

        transform.position = newLocalPosition;
	}
}

#endif