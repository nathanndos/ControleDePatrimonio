﻿using ConstantManager.Exception;
using DAL;
using Entity;
using Patrimonio.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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

        public static List<Equipamento> getBySearch(string textSearch)
        {
            Expression<Func<Equipamento, bool>>? expressionWhere = null;

            if (textSearch.isNotEmpty())
            {
                expressionWhere = equipamento =>
                                  equipamento.Serial.Contains(textSearch) ||
                                  equipamento.Nome.Contains(textSearch) ||
                                  equipamento.Id.ToString().Contains(textSearch) &&
                                  equipamento.Status.Equals(0);
            }

            var result = from equipamento in dbContext.get.Equipamento
                         orderby equipamento.Nome
                         select equipamento;

            return expressionWhere is null ? result.ToList() : result.Where(expressionWhere).ToList();
        }
    }
}
