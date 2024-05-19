namespace TicmansoWebApiV2.Context
{
    public class UserImage
    {
        public int Id { get; set; }
        public string IdUser { get; set; }
        public ApplicationUser applicationUser { get; set; }
        public byte[] Image { get; set; }
        public string FileName { get; set; }
    }
}
