using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.Abstract
{
    public interface ICargoCustomerDal : IGenericDal<CargoCustomer>
    {
        CargoCustomer GetCargoCustomerById(string id);
    }
}
