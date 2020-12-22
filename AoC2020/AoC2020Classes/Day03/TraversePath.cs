namespace AoC2020Classes.Day03
{
    public class TraversePath
    {
        public TraversePath(int rightSteps, int downSteps)
        {
            RightSteps = rightSteps;
            DownSteps = downSteps;
        }

        public int RightSteps { get; set; }
        public int DownSteps { get; set; }
    }
}