using ConstantManager.Exception;
using DAL;
using Entity;
using Patrimonio.ConstantManager.Exception;
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
            EquipamentoDAL db = new EquipamentoDAL();

            db.save(equipamento);
        }

        public static List<Equipamento> getAll()
        {
            EquipamentoDAL db = new EquipamentoDAL();
            return db.getAll().Where(i => i.Status.Equals(0)).ToList();
        }

        public static Equipamento get(int id)
        {
            EquipamentoDAL db = new EquipamentoDAL();
            return db.get(id);
        }

        public static void delete(Equipamento equipamento)
        {
            if (equipamento.Emprestimos.Any())
                throw new Exception(EmprestimoExceptionConstant.DeletarEquipamentoComEmprestimo);
            EquipamentoDAL db = new EquipamentoDAL();
            db.del(equipamento);
        }

        public static List<Equipamento> listBySearch(string textSearch)
        {
            EquipamentoDAL db = new EquipamentoDAL();

            db.select = equipamento => equipamento;

            db.where = equipamento =>
                       (equipamento.Serial.Contains(textSearch) ||
                       equipamento.Nome.Contains(textSearch) ||
                       equipamento.Id.ToString().Contains(textSearch)) &&
                       equipamento.Status.Equals(0);

            db.orderBy = equipamento => equipamento.Nome;

            if (textSearch.isNotEmpty())
                db.where = db.where.and(equipamento => equipamento.Nome.Contains(textSearch));

            return db.list();
        }
    }
}
