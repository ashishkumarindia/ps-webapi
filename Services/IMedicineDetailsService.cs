using Demo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Services
{
    public interface IMedicineDetailsService
    {
        public Task<IEnumerable<MedicineDetails>> GetAll();
        public Task<IEnumerable<MedicineDetails>> Reset();
        public Task<int> Add(MedicineDetails medicineDetails);
        void Update(int id, MedicineDetails medicineDetails);
    }
}
