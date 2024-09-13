using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HexedSceneryMobileApp.Services
{
    public interface IGradeService
    {
        Task<List<Models.Grade>> GetGradesAsync();
    }
    public class GradeService : IGradeService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;

        private static List<Models.Grade> _gradesCache = new List<Models.Grade>();

        public GradeService(IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
        }

        public async Task<List<Models.Grade>> GetGradesAsync()
        {
            var url = "grade";

            if (!_gradesCache.Any())
            {
                try
                {
                    using (var httpClient = _httpClientFactory.CreateClient("HexedApi"))
                    {
                        var data = await httpClient.GetFromJsonAsync<IEnumerable<ApiModels.Grade>>(url);
                        var grades = _mapper.Map<IEnumerable<Models.Grade>>(data);
                        _gradesCache.AddRange(grades);
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

            return _gradesCache;
        }
    }
}
