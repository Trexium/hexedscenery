using HexedSceneryCommon.Main;

namespace HexedSceneryWebsite.Services
{
    public interface IImageService
    {
        List<Image> GetTestData();
    }

    public class ImageService : IImageService
    {
        public List<Image> GetTestData()
        {
            var imageList = new List<Image>();
            for (int i = 0; i < 10;  i++)
            {
                imageList.Add(new Image
                {
                    Id = i,
                    Name = $"Test {i}",
                    Description = $"Test test test test test<br />Test test test.",
                    Priority = 1,
                    ImagePath = "/images/hexedscenery/mordheim_map_1.jpg"
                });
            }

            return imageList;
        }
    }
}
