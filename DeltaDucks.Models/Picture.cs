namespace DeltaDucks.Models
{
   public class Picture
    {
        public int PictureId { get; set; }

        public string Name { get; set; }

        public byte[] ImageData { get; set; }

        public virtual Landmark Landmark { get; set; }

        public int? LandmarkId { get; set; }

    }
}
