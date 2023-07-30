using Patrimonio.DAL;
using Patrimonio.Entity;

namespace Patrimonio.BLL
{
    public class EquipamentoBLL
    {
        public static void isValid(Equipamento equipamento)
        {

        }
        public static void save(Equipamento equipamento)
        {
            isValid(equipamento);
            dbContext.insert(equipamento);
        }

        public static Equipamento get(int id)
        {
            return EquipamentoDAL.get(id);
        }
    }
}
