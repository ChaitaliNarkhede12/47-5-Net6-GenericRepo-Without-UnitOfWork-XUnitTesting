using AutoMapper;

namespace TCCS.UnitTesting.Core
{
    public class AutoMapping
    {
        public IMapper GetMapper(Profile profile)
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(profile);
            });
            var mapper = mockMapper.CreateMapper();
            return mapper;
        }
    }
}