using System.Collections.Generic;

namespace EPaczucha.core
{
    public interface IManagerDto
    {
        int AddNewCustomer(CustomerDto customer);
        int AddNewPackages(PackageDto package, int customerId, int packageTypeId, int packagePriceId, int sendMethodId, int destinationId);
        bool DeleteCustomer(CustomerDto customer);
        bool DeletePackage(PackageDto package);
        List<CustomerDto> GetCustomers(string filterString);
        List<PackageDto> GetPackagesByCustomer(int customerId, string filterString = null);
        int AddNewPackagePrice(PackagePriceDto packagePrice);
        PackageDto GetPackageById(int packageId);
        decimal GetPriceFromPackageType(int typeId);
        decimal GetPriceFromSendMethod(int sendMethodId);
        void EditCustomer(CustomerDto customer);
        int AddNewDestination(DestinationDto destination);
        bool DeleteDestination(DestinationDto destination);
        PackageTypeDto GetPackageTypeById(int packageTypeById);
        SendMethodDto GetSendMethodById(int sendMethodById);

        void AddDefaultSendMethod(bool areYouSure = false);
        void AddDefaultPackageType(bool areYouSure = false);
    }
}