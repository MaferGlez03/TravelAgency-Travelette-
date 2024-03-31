using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.LodgingOffer;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Package;

namespace TravelAgency.Application.ApplicationServices.IServices
{
    public interface IPackageService
    {
        Task<PackageDto> CreatePackageAsync(PackageDto packageDto);
        Task<PackageDto> UpdatePackageAsync(PackageDto packageDto);
        Task<IEnumerable<PackageDto>> ListPackageAsync();
        Task DeletePackageByIdAsync(int PackageId);
    }
}