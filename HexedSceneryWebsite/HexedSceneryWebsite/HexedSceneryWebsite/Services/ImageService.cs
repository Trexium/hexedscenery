using AutoMapper;
using HexedSceneryCommon.Main;
using HexedSceneryData.Data;

namespace HexedSceneryWebsite.Services
{
    public interface IImageService
    {
        List<Image> GetTestData();
        List<Image> GetImages();
    }

    public class ImageService : IImageService
    {
        private readonly HexedSceneryContext _context;
        private readonly IMapper _mapper;

        public ImageService(HexedSceneryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Image> GetImages()
        {
            var dbImages = _context.Images.OrderBy(m => m.Priority).ToList();
            var images = _mapper.Map<List<Image>>(dbImages);
            return images;
        }

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
