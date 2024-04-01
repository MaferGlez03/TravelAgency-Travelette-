using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TravelAgency.Application.ApplicationServices.IServices;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Agency;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.ExtendedExcursion;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Facility;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Package;
using TravelAgency.Application.Common.PaginatedList;
using TravelAgency.Domain.Entities;
using TravelAgency.Domain.Relations;
using TravelAgency.Infrastructure.DataAccess.IRepository;

namespace TravelAgency.Application.ApplicationServices.Services
{
    public class PackageService : IPackageService
    {
        private readonly IExtendedExcursionRepository _extendedExcursionRepository;
        private readonly IPackageRepository _packageRepository;
        private readonly IAgencyRepository _agencyRepository;
        private readonly IMapper _mapper;

        public PackageService(IAgencyRepository agencyRepository, IPackageRepository packageRepository, IMapper mapper, IExtendedExcursionRepository extendedExcursionRepository)
        {
            _packageRepository = packageRepository;
            _agencyRepository = agencyRepository;
            _mapper = mapper;
            _extendedExcursionRepository = extendedExcursionRepository;
        }

        public async Task<PackageDto> CreatePackageAsync(PackageDto packageDto)
        {
            //var package = _mapper.Map<Domain.Entities.Package>(packageDto);

            List<PackageFacility> _packageFacilities = new List<PackageFacility>();
            List<PackageExtendedExcursion> _packageExcursions = new List<PackageExtendedExcursion>();

            foreach (int facility in packageDto.FacilitiesId)
            {
                PackageFacility packageFacility = new PackageFacility { FacilityId = facility, PackageId = packageDto.Id };
                _packageFacilities.Add(packageFacility);
            }
            foreach (int excursionId in packageDto.ExcursionsId)
            {
                var excursion = await _extendedExcursionRepository.GetByIdAsync(excursionId);
                if (excursion.ArrivalDate >= packageDto.StartDate && excursion.DepartureDate <= packageDto.EndDate)
                {
                    PackageExtendedExcursion packageExcursion = new PackageExtendedExcursion { PackageId = packageDto.Id, ExtendedExcursionId = excursionId };

                    _packageExcursions.Add(packageExcursion);
                }
                else throw new Exception("Excursion dates are out of then bond of the package dates");
            }

            Package p = new Package
            {
                Id = packageDto.Id,
                Capacity = packageDto.Capacity,
                Price = packageDto.Price,
                Duration = packageDto.Duration,
                StartDate = packageDto.StartDate,
                EndDate = packageDto.EndDate,
                Description = packageDto.Description,
                AgencyID = packageDto.AgencyID,
            };

            p.AddFacilities(_packageFacilities);
            p.AddExcursions(_packageExcursions);

            var _package = await _packageRepository!.CreateAsync(p);

            return _mapper.Map<PackageDto>(_package);
        }

        public async Task DeletePackageByIdAsync(int packageId)
        {
            var package = _packageRepository.GetById(packageId);
            var agencyID = package.AgencyID;
            var agency = _agencyRepository.GetById(agencyID);
            agency.Packages.Remove(package);
            await _packageRepository!.DeleteByIdAsync(packageId);
        }

        public async Task<PaginatedList<PackageResponseDto>> ListPackageAsync(int pageNumber,int pageSize)
        {
            var packages = await _packageRepository!.GetPackageWithFacilities();
            var list = packages.ToList();
            List<PackageResponseDto> packagesfinal = new();
            for (int i = 0; i < packages.Count(); i++)
            {
                packagesfinal.Add(_mapper.Map<PackageResponseDto>(list[i]));
                foreach (var facility in list[i].packageFacilities)
                {
                    packagesfinal[i].Facilities.Add(_mapper.Map<FacilityDto>(facility));
                }
                foreach (var excursion in list[i].PackageExtendedExcursions)
                {
                    packagesfinal[i].Excursions.Add(_mapper.Map<ExcursionExtResponseDto>(excursion));
                }
            }
           return  PaginatedList<PackageResponseDto>.CreatePaginatedListAsync(packagesfinal,pageNumber,pageSize);
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