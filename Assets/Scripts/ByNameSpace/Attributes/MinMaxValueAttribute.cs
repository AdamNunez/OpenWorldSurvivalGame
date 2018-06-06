namespace UnityEngine.PostProcessing
{
    public sealed class MixMaxValueAttribute : PropertyAttribute
    {
        public readonly float min;
        public readonly float max;

        public MixMaxValueAttribute(int min, int max)
        {
            this.min = min;
            this.max = max;
        }
    }
}
