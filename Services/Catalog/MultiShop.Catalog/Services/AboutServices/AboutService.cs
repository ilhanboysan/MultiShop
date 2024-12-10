using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.AboutDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly IMongoCollection<About> _Aboutcollection;
        private readonly IMapper _mapper;

        public AboutService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _Aboutcollection = database.GetCollection<About>(_databaseSettings.AboutCollectionName);
            _mapper = mapper;
        }

        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            var value = _mapper.Map<About>(createAboutDto);
            await _Aboutcollection.InsertOneAsync(value);
        }

        public async Task DeleteAboutAsync(string id)
        {
            await _Aboutcollection.DeleteOneAsync(x => x.AboutID == id);
        }

        public async Task<List<ResultAboutDto>> GetAllAboutAsync()
        {
            var value = await _Aboutcollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultAboutDto>>(value);
        }

        public async Task<GetByIdAboutDto> GetByIdAboutAsync(string id)
        {
            var value = await _Aboutcollection.Find<About>(x => x.AboutID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdAboutDto>(value);
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            var value = _mapper.Map<About>(updateAboutDto);
            await _Aboutcollection.FindOneAndReplaceAsync(x => x.AboutID == updateAboutDto.AboutID, value);
        }
    }
}
