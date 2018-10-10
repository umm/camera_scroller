using UnityEngine;

namespace UnityModule.CameraScroller
{
    public class OrthographicCameraScroller : MonoBehaviour
    {
        public float ScrollSpeed = 1f;
        public Camera Camera;
        private Vector3 previousMousePosition;

        void Awake()
        {
            if (this.Camera == default(Camera))
            {
                this.Camera = Camera.main;
            }
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                this.previousMousePosition = Input.mousePosition;
            }

            if (Input.GetMouseButton(0))
            {
                var previousPosition = this.Camera.ScreenToWorldPoint(this.previousMousePosition);
                var position = this.Camera.ScreenToWorldPoint(Input.mousePosition);
                this.Move(this.ScrollSpeed * -(position - previousPosition));
                this.previousMousePosition = Input.mousePosition;
            }
        }

        void Move(Vector2 diff)
        {
            this.Camera.transform.localPosition += new Vector3(diff.x, diff.y, 0);
        }
    }
}