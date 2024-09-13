using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoOperationManager : ICargoOperationService
    {
        private readonly ICargoOpertaionDal _cargoOpertaionDal;

        public CargoOperationManager(ICargoOpertaionDal cargoOpertaionDal)
        {
            _cargoOpertaionDal = cargoOpertaionDal;
        }

        public void TDelete(int id)
        {
            _cargoOpertaionDal.Delete(id);
        }

        public List<CargoOperation> TGetAll()
        {
            return _cargoOpertaionDal.GetAll();
        }

        public CargoOperation TGetById(int id)
        {
            return _cargoOpertaionDal.GetById(id);
        }

        public void TInsert(CargoOperation entity)
        {
            _cargoOpertaionDal.Insert(entity);
        }

        public void TUpdate(CargoOperation entity)
        {
            _cargoOpertaionDal.Update(entity);
        }
    }
}
