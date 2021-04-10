using UnityEngine;

namespace ScriptableObjects.SerializedVariables
{
    [CreateAssetMenu]
    public class SerializedFMODEvent : ScriptableObject
    {
        private FMOD.Studio.EventInstance instance;

        [FMODUnity.EventRef]
        public string fmodEvent;

        public void SetParameter(string ename, float value)
        {
            instance.setParameterByName(ename, value);
        }

        public void Enable()
        {
            instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
            instance.start();
        }

        private void OnDisable()
        {
            instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }

        private void OnDestroy()
        {
            instance.release();
        }
    }
}
