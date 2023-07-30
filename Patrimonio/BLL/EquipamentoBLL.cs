using Patrimonio.DAL;
using Patrimonio.Entity;
using System.Collections.Generic;

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
            EquipamentoDAL.save(equipamento);
        }

        public static List<Equipamento> getAll()
        {
            return EquipamentoDAL.getAll();
        }

        public static Equipamento get(int id)
        {
            return EquipamentoDAL.get(id);
        }
    }
}
