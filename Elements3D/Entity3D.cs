namespace Elements3D
{
    public abstract class Entity3D
    {
        /// <summary>
        /// relative X position on the camera chip between 0 and 1.
        /// </summary>
        public double RelativeX { get; set; }

        /// <summary>
        /// relative Y position on the camera chip between 0 and 1.
        /// </summary>
        public double RelativeY { get; set; }
    }
}