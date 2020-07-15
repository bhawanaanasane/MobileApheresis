using CRM.Core.Domain.Equipments;
using CRM.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace CRM.Services.Equipments
{
  public partial class EquipmentServices :IEquipmentServices
    {
        #region Fields
        private IRepository<Equipment> _equipmentRepository;
      //  private IRepository<PolicyAndProcedure> _policyAndProcedureRepository;
        #endregion

        #region Ctor
        public EquipmentServices(IRepository<Equipment> equipmentRepository)
        {
            this._equipmentRepository = equipmentRepository;
        }


        #endregion

        #region General
        public Equipment GetEquiipmentInfoById(int Id)
        {
            var query = from data in _equipmentRepository.Table
                        where data.Id == Id
                        select data;
            var data1 = query.FirstOrDefault();

            return data1;
        }

        public void InsertEquipment(Equipment equipment)
        {
            if (equipment == null)
                throw new ArgumentNullException(nameof(equipment));

            _equipmentRepository.Insert(equipment);
        }

        public void Updateequipment(Equipment equipment)
        {
            if (equipment == null)
                throw new ArgumentNullException(nameof(equipment));

            _equipmentRepository.Update(equipment);
        }

       public void DeleteEquipment(Equipment equipment)
        {
            if (equipment == null)
                throw new ArgumentNullException(nameof(equipment));

            equipment.Deleted = true;
            Updateequipment(equipment);
        }

        public IList<Equipment> GetAllEquiipmentInfo() {
            var query = from q in _equipmentRepository.Table
                        select q;
            return query.ToList();
        }
        #endregion
    }
}
