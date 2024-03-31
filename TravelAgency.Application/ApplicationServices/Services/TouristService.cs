using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TravelAgency.Application.ApplicationServices.IServices;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Security;
using TravelAgency.Domain.Entities;
using TravelAgency.Infrastructure.DataAccess.IRepository;
using TravelAgency.Infrastructure.Identity;

namespace TravelAgency.Application.ApplicationServices.Services
{
    public class TouristService : ITouristService
    {
        private readonly ITouristRepository _touristRepository;
        private readonly IMapper _mapper;

        public TouristService(ITouristRepository touristRepository,IMapper mapper)
        {
            _touristRepository = touristRepository;
            _mapper = mapper;
        }
        public async Task<Tourist> CreateTouristAsync(User touristUser)
        {
            Tourist tourist = new();
            tourist.Nationality=touristUser.Nationality.ToString();
            tourist.Name=touristUser.UserName!;

            await _touristRepository.CreateAsync(tourist);
            return _mapper.Map<Tourist>(tourist);
        }
       

         public async Task<IEnumerable<Tourist>> ListTouristAsync()
        {
            var tourists = await _touristRepository.ListAsync();
            var list = tourists.ToList();
            List <Tourist> touristsfinal = new();
            for (int i = 0; i < tourists.Count(); i++)
            {
                touristsfinal.Add(_mapper.Map<Tourist>(list[i]));
            }
            return touristsfinal;
        }

        public async Task<Tourist> UpdateTouristAsync(Tourist touristDto)
        {
            var tourist = _mapper.Map<Tourist>(touristDto);
            await _touristRepository.UpdateAsync(tourist);
            return _mapper.Map<Tourist>(tourist);
            
        }
         public async Task DeleteTouristByIdAsync(int touristDto)
        {
            await _touristRepository.DeleteByIdAsync(touristDto);
        }
    }
}