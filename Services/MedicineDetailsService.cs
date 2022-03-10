using Demo.Data;
using Demo.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Services
{
    public class MedicineDetailsService : IMedicineDetailsService
    {
        public Task<IEnumerable<MedicineDetails>> Reset()
        {
            return  Task.FromResult(DataBase.ResetData());
        }

        public Task<int> Add(MedicineDetails medicineDetails)
        {
            medicineDetails.Id = DataBase.MedicineDetails.Count;
            DataBase.MedicineDetails.Add(medicineDetails);
            return Task.FromResult(medicineDetails.Id);
        }


        public Task<IEnumerable<MedicineDetails>> GetAll()
        {
            return Task.FromResult(DataBase.MedicineDetails.AsEnumerable());
        }

        public void Update(int id, MedicineDetails medicineDetails)
        {

            var data = DataBase.MedicineDetails.FirstOrDefault(s => s.Id == id);
            DataBase.MedicineDetails.FirstOrDefault(s => s.Id == id).Notes = medicineDetails?.Notes;
        }
    }
}
