using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TravelAgency.Application.ApplicationServices.IServices;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Agency;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Package;
using TravelAgency.Domain.Entities;
using TravelAgency.Infrastructure.DataAccess.IRepository;

namespace TravelAgency.Application.ApplicationServices.Services
{
    public class PackageService : IPackageService
    {
        private readonly IPackageRepository _packageRepository;
        private readonly IAgencyRepository _agencyRepository;
        private readonly IMapper _mapper;

        public PackageService(IAgencyRepository agencyRepository, IPackageRepository packageRepository, IMapper mapper)
        {
            _packageRepository = packageRepository;
            _agencyRepository = agencyRepository;
            _mapper = mapper;
        }

        public async Task<PackageDto> CreatePackageAsync(PackageDto packageDto)
        {
            //var package = _mapper.Map<Domain.Entities.Package>(packageDto);

            List<PackageFacility> _packageFacilities = new List<PackageFacility>();

            foreach (int facility in packageDto.facilityDtos)
            {
                PackageFacility packageFacility = new PackageFacility{ FacilityId = facility, PackageId = packageDto.Id};
                _packageFacilities.Add(packageFacility);
            }

            Package p = new Package
            {
                Id = packageDto.Id,
                Capacity = packageDto.Capacity,
                Duration = packageDto.Duration,
                StartDate = packageDto.StartDate,
                EndDate = packageDto.EndDate,
                Description = packageDto.Description,
                AgencyID = packageDto.AgencyID,
            };

            p.AddFacilities(_packageFacilities);

            var _package = await _packageRepository!.CreateAsync(p);

            return _mapper.Map<PackageDto>(_package);
        }

        public async Task DeletePackageByIdAsync(int packageId)
        {
            var package = _packageRepository.GetById(packageId);
            var agency = package.agency;
            agency.Packages.Remove(package);
            await _packageRepository!.DeleteByIdAsync(packageId);
        }

        public async Task<IEnumerable<PackageDto>> ListPackageAsync()
        {
            var packages = await _packageRepository!.ListAsync();
            var list = packages.ToList();
            List<PackageDto> packagesfinal = new();
            for (int i = 0; i < packages.Count(); i++)
            {
                packagesfinal.Add(_mapper.Map<PackageDto>(list[i]));
            }
            return packagesfinal;
        }

        public async Task<PackageDto> UpdatePackageAsync(PackageDto packageDto)
        {
            if (packageDto == null)
            {
                throw new ArgumentNullException(nameof(packageDto));
            }
            var package = _packageRepository.GetById(packageDto.Id);
            _mapper.Map(packageDto, package);
            await _packageRepository.UpdateAsync(package);
            return _mapper.Map<PackageDto>(package);

        }
    }
}