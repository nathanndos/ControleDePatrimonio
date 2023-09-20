using DAL;
using ConstantManager.Exception;
using Patrimonio.Entity;
using Patrimonio.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class EquipamentoBLL
    {
        public static void isValid(Equipamento equipamento)
        {
            if (equipamento.Nome.isEmpty())
                throw new Exception(EquipamentoExceptionConstant.NomeInvalido);
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
