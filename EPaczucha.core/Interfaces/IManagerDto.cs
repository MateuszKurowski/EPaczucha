using System.Collections.Generic;

namespace EPaczucha.core
{
    public interface IManagerDto
    {
        void AddNewCustomer(CustomerDto customer);
        void AddNewPackages(PackageDto package, int userId, int sendMethodId, int packagePriceId, int packageTypeId);
        bool DeleteCustomer(CustomerDto customer);
        bool DeletePackage(PackageDto package);
        List<CustomerDto> GetCustomers(string filterString);
        List<PackageDto> GetPackagesByCustomer(int customerId, string filterString);
        int? AddNewPackagePrice(PackagePriceDto packagePrice);
        PackageDto GetPackageById(int packageId);
        decimal GetPriceFromPackageType(int typeId);
        decimal GetPriceFromSendMethod(int sendMethodId);
        void EditCustomer(CustomerDto customer);
    }
}
