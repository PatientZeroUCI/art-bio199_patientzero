namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEngine.UI;
    using VRTK.Controllables;

    public class ControllableReactor : MonoBehaviour
    {
        public VRTK_BaseControllable controllable;
        public Text displayText;
        public string outputOnMax = "Maximum Reached";
        public string outputOnMin = "Minimum Reached";
        private Vector3 restingPos;
        private Vector3 maxLimitPos;

        protected virtual void OnEnable()
        {
            restingPos = transform.position;
            controllable = (controllable == null ? GetComponent<VRTK_BaseControllable>() : controllable);
            controllable.ValueChanged += ValueChanged;
            controllable.MaxLimitReached += MaxLimitReached;
            controllable.MinLimitReached += MinLimitReached;
        }

        protected virtual void ValueChanged(object sender, ControllableEventArgs e)
        {
            // Prevent button from going beyond its 'natural' boundaries
            if(restingPos != null) {
                if (controllable.AtMinLimit()) {
                    transform.position = restingPos;
                }
                if (controllable.AtMaxLimit()) {
                    transform.position = maxLimitPos;
                }
            }

            if (displayText != null)
            {
                displayText.text = e.value.ToString("F1");
            }
        }

        protected virtual void MaxLimitReached(object sender, ControllableEventArgs e)
        {
            // Get max limit here since idk where else to get it.
            if(maxLimitPos == new Vector3(0, 0, 0)) {
                maxLimitPos = transform.position;
            }
            if (outputOnMax != "")
            {
                Debug.Log(outputOnMax);
            }
        }

        protected virtual void MinLimitReached(object sender, ControllableEventArgs e)
        {
            if (outputOnMin != "")
            {
                Debug.Log(outputOnMin);
            }
        }
    }
}