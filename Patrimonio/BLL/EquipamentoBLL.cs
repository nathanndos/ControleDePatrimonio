using Patrimonio.DAL;
using Patrimonio.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

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
            return EquipamentoDAL.getAll().Where(i => i.Status.Equals(0)).ToList();
        }

        public static Equipamento get(int id)
        {
            return EquipamentoDAL.get(id);
        }

        public static void delete(Equipamento equipamento)
        {
            EquipamentoDAL.del(equipamento);
        }
    }
}
