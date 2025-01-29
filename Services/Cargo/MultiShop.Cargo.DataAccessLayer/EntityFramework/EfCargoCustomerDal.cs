using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.Repositories;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoCustomerDal : GenericRepository<CargoCustomer>, ICargoCustomerDal
    {
        private readonly CargoContext _cargocontext;
        public EfCargoCustomerDal(CargoContext cargoContext, CargoContext cargocontext) : base(cargoContext)
        {
            _cargocontext = cargocontext;
        }

        public CargoCustomer GetCargoCustomerById(string id)
        {
            var values = _cargocontext.CargoCustomers.Where(x => x.UserCustomerId == id).FirstOrDefault();
            return values;
        }
    }
}
