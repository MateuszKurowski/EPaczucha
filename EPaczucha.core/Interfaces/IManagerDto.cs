using System.Collections.Generic;

namespace EPaczucha.core
{
    public interface IManagerDto
    {
        void AddNewCustomer(CustomerDto customer);
        void AddNewPackages(PackageDto package, int userId, int sendMethodId, int packagePriceId, int packageTypeId);
        bool DeleteCustomer(CustomerDto customer);
        bool DeletePackage(PackageDto package);
        IEnumerable<CustomerDto> GetCustomers(string filterString);
        IEnumerable<PackageDto> GetPackagesByCustomer(int customerId, string filterString);
        int? AddNewPackagePrice(PackagePriceDto packagePrice);
        PackageDto GetPackageById(int packageId);
        decimal GetPriceFromPackageType(int typeId);
        decimal GetPriceFromSendMethod(int sendMethodId);
        void EditCustomer(int customerId);
    }
}
